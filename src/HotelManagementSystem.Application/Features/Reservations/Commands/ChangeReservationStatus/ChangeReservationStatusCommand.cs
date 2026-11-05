using HotelManagementSystem.Domain.Enums;
using MediatR;

namespace HotelManagementSystem.Application.Features.Reservations.Commands.ChangeReservationStatus;

public class ChangeReservationStatusCommand : IRequest
{
    public int Id { get; set; }

    public ReservationStatus Status { get; set; }
}