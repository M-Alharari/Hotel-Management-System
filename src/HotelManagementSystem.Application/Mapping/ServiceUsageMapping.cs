using HotelManagementSystem.Application.Features.ServiceUsages.Commands.CreateServiceUsage;
using HotelManagementSystem.Application.Features.ServiceUsages.Models;
using HotelManagementSystem.Domain.Entities;

namespace HotelManagementSystem.Application.Mapping;

public static class ServiceUsageMapping
{
    public static ServiceUsage ToEntity(
        this CreateServiceUsageCommand request,
        decimal unitPrice,
        DateTime usedAt)
    {
        return new ServiceUsage
        {
            ReservationId = request.ReservationId,
            HotelServiceId = request.HotelServiceId,
            Quantity = request.Quantity,
            UnitPrice = unitPrice,
            UsedAt = usedAt
        };
    }

    public static ServiceUsageResponse ToResponse(
        this ServiceUsage usage)
    {
        return new ServiceUsageResponse
        {
            Id = usage.Id,
            ReservationId = usage.ReservationId,
            HotelServiceId = usage.HotelServiceId,
            ServiceName = usage.HotelService.Name,
            Quantity = usage.Quantity,
            UnitPrice = usage.UnitPrice,
            TotalPrice = usage.Quantity * usage.UnitPrice,
            UsedAt = usage.UsedAt
        };
    }
}