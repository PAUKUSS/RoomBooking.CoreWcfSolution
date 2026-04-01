
using RoomBooking.Domain.Entities;

namespace RoomBooking.ServiceHost.Security;

public interface ISessionManager
{
    string CreateSession(User user);
    SessionInfo? GetSession(string token);
    void RemoveSession(string token);
}
