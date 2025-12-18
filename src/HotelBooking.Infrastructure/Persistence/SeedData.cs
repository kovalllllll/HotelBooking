using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Enums;
using HotelBooking.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HotelBooking.Infrastructure.Persistence;

public static class SeedData
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var services = scope.ServiceProvider;

        var context = services.GetRequiredService<ApplicationDbContext>();
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        await context.Database.MigrateAsync();

        await SeedRolesAsync(roleManager);
        await SeedAdminUserAsync(userManager);
        await SeedHotelsAndRoomsAsync(context);
    }

    private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        string[] roles = ["Administrator", "Client"];

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }

    private static async Task SeedAdminUserAsync(UserManager<ApplicationUser> userManager)
    {
        const string adminEmail = "admin@hotel.com";
        const string adminPassword = "Admin123!";

        if (await userManager.FindByEmailAsync(adminEmail) == null)
        {
            var admin = new ApplicationUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                FirstName = "Admin",
                LastName = "User",
                EmailConfirmed = true
            };

            await userManager.CreateAsync(admin, adminPassword);
            await userManager.AddToRoleAsync(admin, "Administrator");
        }
    }

    private static async Task SeedHotelsAndRoomsAsync(ApplicationDbContext context)
    {
        if (await context.Hotels.AnyAsync())
        {
            return;
        }

        var hotels = GetHotels();
        context.Hotels.AddRange(hotels);
        await context.SaveChangesAsync();

        var rooms = GetRooms();
        context.Rooms.AddRange(rooms);
        await context.SaveChangesAsync();
    }

    private static Hotel[] GetHotels() =>
    [
        new Hotel
        {
            Name = "Grand Hotel Kyiv",
            Address = "вул. Хрещатик, 1",
            City = "Київ",
            Description = "Розкішний 5-зірковий готель у самому серці столиці",
            StarRating = 5,
            ImageUrl = "https://images.unsplash.com/photo-1566073771259-6a8506099945?w=800"
        },
        new Hotel
        {
            Name = "Lviv Palace",
            Address = "пл. Ринок, 10",
            City = "Львів",
            Description = "Історичний готель у центрі старого Львова",
            StarRating = 4,
            ImageUrl = "https://images.unsplash.com/photo-1542314831-068cd1dbfeeb?w=800"
        },
        new Hotel
        {
            Name = "Odesa Sea Resort",
            Address = "Французький бульвар, 50",
            City = "Одеса",
            Description = "Курортний готель з видом на море",
            StarRating = 4,
            ImageUrl = "https://images.unsplash.com/photo-1520250497591-112f2f40a3f4?w=800"
        }
    ];

    private static Room[] GetRooms() =>
    [
        new Room
        {
            HotelId = 1, RoomNumber = "101", RoomType = RoomType.Standard,
            PricePerNight = 2500, Capacity = 2, Description = "Стандартний номер з видом на місто"
        },
        new Room
        {
            HotelId = 1, RoomNumber = "102", RoomType = RoomType.Deluxe,
            PricePerNight = 4000, Capacity = 2, Description = "Покращений номер з балконом"
        },
        new Room
        {
            HotelId = 1, RoomNumber = "201", RoomType = RoomType.Suite,
            PricePerNight = 7500, Capacity = 4, Description = "Люкс з вітальнею та спальнею"
        },
        new Room
        {
            HotelId = 1, RoomNumber = "301", RoomType = RoomType.Presidential,
            PricePerNight = 15000, Capacity = 4, Description = "Президентський люкс"
        },

        new Room
        {
            HotelId = 2, RoomNumber = "11", RoomType = RoomType.Standard,
            PricePerNight = 1800, Capacity = 2, Description = "Затишний номер у історичному стилі"
        },
        new Room
        {
            HotelId = 2, RoomNumber = "12", RoomType = RoomType.Deluxe,
            PricePerNight = 2800, Capacity = 2, Description = "Номер з видом на площу Ринок"
        },
        new Room
        {
            HotelId = 2, RoomNumber = "21", RoomType = RoomType.Family,
            PricePerNight = 3500, Capacity = 5, Description = "Сімейний номер"
        },

        new Room
        {
            HotelId = 3, RoomNumber = "A1", RoomType = RoomType.Standard,
            PricePerNight = 2000, Capacity = 2, Description = "Стандартний номер"
        },
        new Room
        {
            HotelId = 3, RoomNumber = "A2", RoomType = RoomType.Deluxe,
            PricePerNight = 3500, Capacity = 2, Description = "Номер з видом на море"
        },
        new Room
        {
            HotelId = 3, RoomNumber = "B1", RoomType = RoomType.Suite,
            PricePerNight = 5500, Capacity = 4, Description = "Люкс з терасою"
        }
    ];
}