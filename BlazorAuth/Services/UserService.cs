using System.Net.Http;
using System.Net.Http.Headers;
using BlazorAuth.Commands;
using BlazorAuth.Error;
using Blazored.LocalStorage;
using Blazored.SessionStorage;

namespace BlazorAuth.Services;

public class UserService : IUserService
{
    private readonly HttpClient _httpClient;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ISessionStorageService _sessionStorageService;

    private const string _url = "https://localhost:7025";
    private static string Token = null;
    private static Guid? UserId = null;

    public UserService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor, ISessionStorageService sessionStorageService)
    {
        _httpClient = httpClient;
        _httpContextAccessor = httpContextAccessor;
        _httpClient.BaseAddress = new Uri(_url);
        _sessionStorageService = sessionStorageService;
    }

    public async Task<ApiResult> ChangePasswordAsync(ChangePasswordCommand changePasswordRequest)
    {
        await AddAuthHeaderAsync();

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
        var response = await _httpClient.PostAsJsonAsync("/api/users", userRequest);

        if (response.IsSuccessStatusCode)
        {
            var loginResult = await response.Content.ReadFromJsonAsync<LoginResult>();
            await _sessionStorageService.SetItemAsync("authToken", loginResult.Token);
            Token = loginResult.Token;
            UserId = loginResult.UserId;
            return new ApiResult { Success = true };
        }
        var errorResponse = await response.Content.ReadFromJsonAsync<ApiResult>();
        return errorResponse!;
    }

    public async Task DeleteAsync(Guid id)
    {
        await AddAuthHeaderAsync();
        var request = await _httpClient.DeleteAsync($"/api/users/{id}");
    }

    public async Task<List<UserCommand>> GetUsersAsync()
    {
        await AddAuthHeaderAsync();

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
            await _sessionStorageService.SetItemAsync("authToken", loginResult.Token);
            var teste = await _sessionStorageService.GetItemAsync<string>("authToken");
            Token = loginResult.Token;
            UserId = loginResult.UserId;
        }

        return null;
    }

    private async Task AddAuthHeaderAsync()
    {
        var token = await GetAuthTokenAsync();
        if (!string.IsNullOrEmpty(token))
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }
    private async Task<string> GetAuthTokenAsync()
    {
        var teste = await _sessionStorageService.GetItemAsync<string>("authToken");
        return (await _sessionStorageService.GetItemAsync<string>("authToken"))!;
    }
}

