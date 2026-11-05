using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Application.Mapping;
using MediatR;

namespace HotelManagementSystem.Application.Features.ServiceUsages.Commands.CreateServiceUsage;

public class CreateServiceUsageHandler
    : IRequestHandler<CreateServiceUsageCommand, int>
{
    private readonly IServiceUsageRepository _usageRepository;
    private readonly IReservationRepository _reservationRepository;
    private readonly IHotelServiceRepository _serviceRepository;

    public CreateServiceUsageHandler(
        IServiceUsageRepository usageRepository,
        IReservationRepository reservationRepository,
        IHotelServiceRepository serviceRepository)
    {
        _usageRepository = usageRepository;
        _reservationRepository = reservationRepository;
        _serviceRepository = serviceRepository;
    }

    public async Task<int> Handle(
        CreateServiceUsageCommand request,
        CancellationToken cancellationToken)
    {
        // Validate reservation
        var reservation = await _reservationRepository.GetByIdAsync(
            request.ReservationId);

        if (reservation == null)
            throw new KeyNotFoundException(
                "Reservation was not found.");

        // Validate hotel service
        var service = await _serviceRepository.GetByIdAsync(
            request.HotelServiceId);

        if (service == null)
            throw new KeyNotFoundException(
                "Hotel service was not found.");

        if (!service.IsActive)
            throw new InvalidOperationException(
                "This service is inactive and cannot be used.");

        // Create usage with a historical price snapshot
        var usage = request.ToEntity(
            service.Price,
            DateTime.UtcNow);

        await _usageRepository.AddAsync(usage);

        return usage.Id;
    }
}