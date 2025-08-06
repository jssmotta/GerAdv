
using MenphisSI.GerEntityTools.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using static System.Net.WebRequestMethods;
using AuthenticateRequest = MenphisSI.BaseCommon.AuthenticateRequest;
using AuthenticateResponse = MenphisSI.BaseCommon.AuthenticateResponse;

namespace MenphisSI.GerAdv.Client;
public static class EntityApi
{
#if (DEBUG)
    public static string BaseUrlApi => "localhost:7179";
#else
    public static string BaseUrlApi => System.Diagnostics.Debugger.IsAttached ? "localhost:7179" :  "api.ajfanibrahim.com.br";

#endif
    private static string APIUrl = $"https://{BaseUrlApi}/api/v1/";

    const string bearer = "VGhlVWx0aW1hdGVNRFMyMDI1VGhlVWx0aW1hdGVNRFMyMDI1";

    public static string? uri;
    public static string? usuario;
    public static string? senha;

    private static string Token { get; set; } = "";

    public static T? Read<T>(string table, string method, dynamic data)
    {
        if (Token.Length == 0)
        {
            Token = GetToken().Result;
            if (Token.Length == 0) return default;
        }

        var apiUrl = $"{APIUrl}{uri}/";

        using var client = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(10)
        };
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.DecodeBase64());

        var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json")
        {
            Headers =
            {
                ContentType = new MediaTypeHeaderValue("application/json")
            }
        };
        var response = client.PostAsync($"{apiUrl}{table}/{method}", content).Result;
        response.EnsureSuccessStatusCode();

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = response.Content.ReadAsStringAsync().Result;
            throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {errorContent}");
        }

        var responseContent = response.Content.ReadAsStringAsync().Result;
        var result = JsonConvert.DeserializeObject<T>(responseContent);
        return result == null ? default : result;
    }

    private static async Task<string> GetToken()
    {
        var authApi = new AuthenticateRequest
        {
            Password = senha ?? throw new Exception("PASSWORD MISSING"),
            Username = usuario ?? throw new Exception("USERNAME MISSING")
        };

        using var client = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(10)
        };

        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearer.DecodeBase64());

        var content = new StringContent(JsonConvert.SerializeObject(authApi), Encoding.UTF8, "application/json");
        try
        {
            //var response = await client.PostAsync($"{apiUrl}users/authenticate", content);
            var response = client.PostAsync($"{APIUrl}{uri}/users/authenticate", content).Result;
            response.EnsureSuccessStatusCode();

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = response.Content.ReadAsStringAsync().Result;
                throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {errorContent}");
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var tokenResponse = JsonConvert.DeserializeObject<AuthenticateResponse>(responseContent);
            return tokenResponse?.Token ?? "";
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"Request failed: {ex.Message}");
        }
    }
  
}
