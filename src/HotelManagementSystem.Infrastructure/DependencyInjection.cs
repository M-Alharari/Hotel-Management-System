using HotelManagementSystem.Application.Abstractions.Persistence;
using HotelManagementSystem.Application.Abstractions.Services;
using HotelManagementSystem.Infrastructure.Persistence;
using HotelManagementSystem.Infrastructure.Persistence.Data;
using HotelManagementSystem.Infrastructure.Persistence.Repositories;
using HotelManagementSystem.Infrastructure.Repositories;
using HotelManagementSystem.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotelManagementSystem.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IGuestRepository, GuestRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPasswordHasherService, PasswordHasherService>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IRoomRepository, RoomRepository>();
        services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
        services.AddScoped<IReservationRepository, ReservationRepository>();
        services.AddScoped<IHotelServiceRepository, HotelServiceRepository>();
        services.AddScoped<IServiceUsageRepository, ServiceUsageRepository>();
        services.AddScoped<IPaymentRepository, PaymentRepository>();
        services.AddScoped<IInvoiceRepository, InvoiceRepository>();
        services.AddScoped<IPaymentAllocationRepository, PaymentAllocationRepository>();











        return services;
    }
}