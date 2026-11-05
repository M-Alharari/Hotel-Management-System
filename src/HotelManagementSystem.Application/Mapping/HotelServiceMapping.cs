using HotelManagementSystem.Application.Features.HotelServices;
using HotelManagementSystem.Application.Features.HotelServices.Commands.CreateHotelService;
using HotelManagementSystem.Application.Features.HotelServices.Commands.UpdateHotelService;
using HotelManagementSystem.Domain.Entities;

namespace HotelManagementSystem.Application.Mapping;

public static class HotelServiceMapping
{
    public static HotelService ToEntity(
        this CreateHotelServiceCommand request)
    {
        return new HotelService
        {
            Name = request.Name.Trim(),
            Description = request.Description?.Trim(),
            Price = request.Price,
            IsActive = true
        };
    }

    public static void UpdateEntity(
        this UpdateHotelServiceCommand request,
        HotelService service)
    {
        service.Name = request.Name.Trim();
        service.Description = request.Description?.Trim();
        service.Price = request.Price;
    }

    public static HotelServiceResponse ToResponse(
        this HotelService service)
    {
        return new HotelServiceResponse
        {
            Id = service.Id,
            Name = service.Name,
            Description = service.Description,
            Price = service.Price,
            IsActive = service.IsActive
        };
    }
}