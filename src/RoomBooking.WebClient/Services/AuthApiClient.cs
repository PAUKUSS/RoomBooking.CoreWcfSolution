
using RoomBooking.Contracts.DataContracts;
using RoomBooking.Contracts.ServiceContracts;

namespace RoomBooking.WebClient.Services;

public class AuthApiClient
{
    private readonly SoapClientExecutor _executor;

    public AuthApiClient(SoapClientExecutor executor)
    {
        _executor = executor;
    }

    public Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
    {
        return _executor.ExecuteAsync<IAuthService, LoginResponseDto>(
            _executor.AuthServiceUrl,
            client => client.LoginAsync(request));
    }

    public Task<OperationResultDto> LogoutAsync(string sessionToken)
    {
        return _executor.ExecuteAsync<IAuthService, OperationResultDto>(
            _executor.AuthServiceUrl,
            client => client.LogoutAsync(sessionToken));
    }
}
