
using System.ServiceModel;
using RoomBooking.Contracts.DataContracts;

namespace RoomBooking.Contracts.ServiceContracts;

[ServiceContract(Name = "AuthService", Namespace = ContractNamespaces.Services)]
public interface IAuthService
{
    [OperationContract]
    Task<LoginResponseDto> LoginAsync(LoginRequestDto request);

    [OperationContract]
    Task<OperationResultDto> LogoutAsync(string sessionToken);
}
