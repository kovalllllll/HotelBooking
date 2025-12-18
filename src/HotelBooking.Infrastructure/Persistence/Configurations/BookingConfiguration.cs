using HotelBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBooking.Infrastructure.Persistence.Configurations;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.CheckInDate)
            .IsRequired();

        builder.Property(b => b.CheckOutDate)
            .IsRequired();

        builder.Property(b => b.TotalPrice)
            .IsRequired()
            .HasPrecision(18, 2);

        builder.Property(b => b.Status)
            .IsRequired();

        builder.Property(b => b.SpecialRequests)
            .HasMaxLength(1000);

        builder.Property(b => b.UserId)
            .IsRequired()
            .HasMaxLength(450);

        builder.HasIndex(b => b.UserId);
        builder.HasIndex(b => b.RoomId);
        builder.HasIndex(b => new { b.CheckInDate, b.CheckOutDate });
    }
}

