
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RoomBooking.Contracts.Enums;
using RoomBooking.Domain.Entities;
using RoomBooking.Domain.Security;

namespace RoomBooking.Infrastructure.Persistence;

public static class SeedData
{
    public static async Task InitializeAsync(AppDbContext dbContext, ILogger? logger = null, CancellationToken cancellationToken = default)
    {
        if (!await dbContext.Users.AnyAsync(cancellationToken))
        {
            dbContext.Users.AddRange(
                new User
                {
                    DisplayName = "System Administrator",
                    Email = "admin@room-booking.local",
                    PasswordHash = PasswordHasher.HashPassword("Admin123!"),
                    Role = UserRole.Admin,
                    CreatedAtUtc = DateTime.UtcNow
                },
                new User
                {
                    DisplayName = "Regular Employee",
                    Email = "employee@room-booking.local",
                    PasswordHash = PasswordHasher.HashPassword("Employee123!"),
                    Role = UserRole.Employee,
                    CreatedAtUtc = DateTime.UtcNow
                });

            await dbContext.SaveChangesAsync(cancellationToken);
            logger?.LogInformation("Тестовые пользователи добавлены.");
        }

        if (!await dbContext.Rooms.AnyAsync(cancellationToken))
        {
            dbContext.Rooms.AddRange(
                new Room
                {
                    Name = "Переговорная Альфа",
                    Location = "Этаж 2, блок А",
                    Capacity = 6,
                    HasProjector = true,
                    HasWhiteboard = true,
                    Description = "Небольшая переговорная для быстрых встреч.",
                    CreatedAtUtc = DateTime.UtcNow
                },
                new Room
                {
                    Name = "Переговорная Бета",
                    Location = "Этаж 3, блок C",
                    Capacity = 12,
                    HasProjector = true,
                    HasWhiteboard = false,
                    Description = "Комната для презентаций и командных обсуждений.",
                    CreatedAtUtc = DateTime.UtcNow
                });

            await dbContext.SaveChangesAsync(cancellationToken);
            logger?.LogInformation("Тестовые комнаты добавлены.");
        }
    }
}
