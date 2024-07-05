using System.Net.Http;
using System.Net.Http.Headers;
using BlazorAuth.Commands;
using BlazorAuth.Error;

namespace BlazorAuth.Services;

public class UserService : IUserService
{
    private readonly HttpClient _httpClient;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private const string _url = "https://localhost:7025";
    private static string Token = null;
    private static Guid? UserId = null;

    public UserService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
    {
        _httpClient = httpClient;
        _httpContextAccessor = httpContextAccessor;

        _httpClient.BaseAddress = new Uri(_url);
    }

    public async Task<ApiResult> ChangePasswordAsync(ChangePasswordCommand changePasswordRequest)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

        var response = await _httpClient.PutAsJsonAsync($"/api/users/change-password", changePasswordRequest);

        if (response.IsSuccessStatusCode)
            return new ApiResult { Success = true };

        else
        {
            var errorResponse = await response.Content.ReadFromJsonAsync<ApiResult>();
            return errorResponse!;
        }
    }

    public async Task<ApiResult> CreateAsync(UserCommand userRequest)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("/api/users", userRequest);

            if (response.IsSuccessStatusCode)
            {
                var loginResult = await response.Content.ReadFromJsonAsync<LoginResult>();
                Token = loginResult.Token;
                UserId = loginResult.UserId;
                return new ApiResult { Success = true };
            }
                
            else
            {
                var errorResponse = await response.Content.ReadFromJsonAsync<ApiResult>();
                return errorResponse!;
            }
            //var response = await cliente.Content.ReadFromJsonAsync<UserCommand>();
            //return response!;
        }
        catch (Exception ex)
        {
            string message = ex.Message;
        }

        return null;
    }

    public async Task DeleteAsync(Guid id)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
        var request = await _httpClient.DeleteAsync($"/api/users/{id}");
    }

    public async Task<List<UserCommand>> GetUsersAsync()
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

        var request = await _httpClient.GetAsync("/api/users");
        var users = await request.Content.ReadFromJsonAsync<List<UserCommand>>();

        return users!;
    }

    public async Task<string> LoginAsync(LoginCommand loginRequest)
    {
        var response = await _httpClient.PostAsJsonAsync("/api/users/login", loginRequest);

        if (response.IsSuccessStatusCode)
        {
            var loginResult = await response.Content.ReadFromJsonAsync<LoginResult>();
            Token = loginResult.Token;
            UserId = loginResult.UserId;
        }

        return null;
    }
}

