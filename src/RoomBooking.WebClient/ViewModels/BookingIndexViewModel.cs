
using RoomBooking.Contracts.DataContracts;

namespace RoomBooking.WebClient.ViewModels;

public class BookingIndexViewModel
{
    public DateTime? FromLocal { get; set; }
    public DateTime? ToLocal { get; set; }
    public int? RoomId { get; set; }
    public bool OnlyMyBookings { get; set; }
    public List<RoomDto> Rooms { get; set; } = new();
    public List<BookingDto> Bookings { get; set; } = new();
}
