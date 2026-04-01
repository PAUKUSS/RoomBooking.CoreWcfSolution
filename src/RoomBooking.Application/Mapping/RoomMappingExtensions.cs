
using RoomBooking.Contracts.DataContracts;
using RoomBooking.Domain.Entities;

namespace RoomBooking.Application.Mapping;

public static class RoomMappingExtensions
{
    public static RoomDto ToDto(this Room room)
    {
        return new RoomDto
        {
            Id = room.Id,
            Name = room.Name,
            Location = room.Location,
            Capacity = room.Capacity,
            HasProjector = room.HasProjector,
            HasWhiteboard = room.HasWhiteboard,
            Description = room.Description
        };
    }
}
