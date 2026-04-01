using CoreWCF.Configuration;
using Microsoft.EntityFrameworkCore;
using RoomBooking.Application.Services;
using RoomBooking.Domain.Interfaces;
using RoomBooking.Infrastructure.Persistence;
using RoomBooking.Infrastructure.Repositories;
using RoomBooking.ServiceHost.Security;
using RoomBooking.ServiceHost.Services;

namespace RoomBooking.ServiceHost.Extensions;

public static class ServiceRegistrationExtensions
{
    public static IServiceCollection AddRoomBookingServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection")
                               ?? "Data Source=room_booking.db";

        services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoomRepository, RoomRepository>();
        services.AddScoped<IBookingRepository, BookingRepository>();

        services.AddScoped<AuthAppService>();
        services.AddScoped<RoomAppService>();
        services.AddScoped<BookingAppService>();

        services.AddSingleton<ISessionManager, InMemorySessionManager>();

        services.AddScoped<AuthService>();
        services.AddScoped<RoomService>();
        services.AddScoped<BookingService>();

        services.AddServiceModelServices();
        services.AddServiceModelMetadata();

        return services;
    }
}
