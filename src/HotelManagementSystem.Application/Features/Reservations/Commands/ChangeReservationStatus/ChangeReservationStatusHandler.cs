using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Domain.Enums;
using MediatR;

namespace HotelManagementSystem.Application.Features.Reservations.Commands.ChangeReservationStatus;

public class ChangeReservationStatusHandler
    : IRequestHandler<ChangeReservationStatusCommand>
{
    private readonly IReservationRepository _repository;

    public ChangeReservationStatusHandler(
        IReservationRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(
        ChangeReservationStatusCommand request,
        CancellationToken cancellationToken)
    {
        var reservation = await _repository.GetByIdAsync(request.Id);

        if (reservation is null)
            throw new KeyNotFoundException("Reservation not found.");

        var now = DateTime.UtcNow;

        var currentStatus = reservation.Status;
        var newStatus = request.Status;

        var validTransition = currentStatus switch
        {
            ReservationStatus.Pending =>
                newStatus == ReservationStatus.Confirmed ||
                newStatus == ReservationStatus.Cancelled,

            ReservationStatus.Confirmed =>
                newStatus == ReservationStatus.CheckedIn ||
                newStatus == ReservationStatus.Cancelled ||
                newStatus == ReservationStatus.NoShow,

            ReservationStatus.CheckedIn =>
                newStatus == ReservationStatus.CheckedOut,

            _ => false
        };

        if (!validTransition)
            throw new InvalidOperationException(
                $"Cannot change reservation from {currentStatus} to {newStatus}.");

        if (currentStatus == ReservationStatus.Pending &&
            reservation.HoldExpiresAt <= now)
        {
            throw new InvalidOperationException(
                "Reservation hold has expired.");
        }

        var today = DateOnly.FromDateTime(now);

        if (newStatus == ReservationStatus.CheckedIn &&
            today < reservation.CheckInDate)
        {
            throw new InvalidOperationException(
                "Cannot check in before the reservation date.");
        }

        if (newStatus == ReservationStatus.CheckedOut &&
            today < reservation.CheckOutDate)
        {
            throw new InvalidOperationException(
                "Invalid check-out date.");
        }

        if (newStatus == ReservationStatus.NoShow &&
            today <= reservation.CheckInDate)
        {
            throw new InvalidOperationException(
                "Cannot mark reservation as NoShow before the check-in date has passed.");
        }

        reservation.Status = newStatus;

        if (newStatus != ReservationStatus.Pending)
            reservation.HoldExpiresAt = null;

        reservation.UpdatedAt = now;

        await _repository.UpdateAsync(reservation);
    }
}