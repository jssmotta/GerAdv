//// copyright © 2000-2025 Menphis - Sistemas Inteligentes
//// This file is part of the Source Genesys project

//using DevToolApiInterface;
//using MenphisSI.BaseCommon;
//using MenphisSI.BaseCommon.UserController;
//using Microsoft.Extensions.Options;

//namespace API.Services;

///// <summary>
///// Adaptador que implementa ILoginValidationService usando DevToolsApiClient
///// </summary>
//public class DevToolsLoginValidationService : ILoginValidationService
//{
    
//    private readonly IOptions<AppSettings> _appSettings;

//    public DevToolsLoginValidationService(        
//        IOptions<AppSettings> appSettings)
//    {
        
//        //_devToolsApiClient = devToolsApiClient ?? throw new ArgumentNullException(nameof(devToolsApiClient));
//        _appSettings = appSettings ?? throw new ArgumentNullException(nameof(appSettings));
//    }

//    /// <inheritdoc />
//    public async Task<UserValidationResult> ValidateUserAsync(string uri, string userAgent, string ipv4, string? ipv6 = null)
//    {
//        var apiKey = _appSettings.Value.DevToolsApiKey;
        
//        if (string.IsNullOrEmpty(apiKey))
//        {
//            // Se não há API key configurada, permitir acesso
//            return new UserValidationResult
//            {
//                IsValid = true,
//                Message = "DevTools API Key não configurada - validação ignorada"
//            };
//        }

//        try
//        {
//            var response = await _devToolsApiClient.ValidateUserAsync(uri, apiKey, userAgent, ipv4, ipv6);
            
//            return new UserValidationResult
//            {
//                IsValid = response.IsValid,
//                Message = response.Message,
//                LockdownUntil = response.LockdownUntil
//            };
//        }
//        catch (Exception ex)
//        {
//            // Em caso de falha na comunicação, não bloquear o usuário
//            return new UserValidationResult
//            {
//                IsValid = true,
//                Message = $"Erro na validação externa: {ex.Message}"
//            };
//        }
//    }

//    /// <inheritdoc />
//    public async Task<LoginValidationResult> ValidateLoginAsync(string uri, string userId, string userAgent, string ipv4, string? ipv6, bool passwordRejected)
//    {
//        var apiKey = _appSettings.Value.DevToolsApiKey;
        
//        if (string.IsNullOrEmpty(apiKey))
//        {
//            // Se não há API key configurada, permitir acesso
//            return new LoginValidationResult
//            {
//                IsValid = true,
//                Message = "DevTools API Key não configurada - validação ignorada"
//            };
//        }

//        try
//        {
//            var response = await _devToolsApiClient.ValidateLoginAsync(uri, apiKey, userId, userAgent, ipv4, ipv6, passwordRejected);
            
//            return new LoginValidationResult
//            {
//                IsValid = response.IsValid,
//                Message = response.Message,
//                IpLockdownUntil = response.IpLockdownUntil,
//                UserLockdownUntil = response.UserLockdownUntil,
//                AttemptCount = response.AttemptCount,
//                MaxAttempts = response.MaxAttempts
//            };
//        }
//        catch (Exception ex)
//        {
//            // Em caso de falha na comunicação, não bloquear o usuário
//            return new LoginValidationResult
//            {
//                IsValid = true,
//                Message = $"Erro na validação de login: {ex.Message}"
//            };
//        }
//    }
//}
