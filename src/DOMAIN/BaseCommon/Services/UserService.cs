using MenphisSI.BaseCommon.UserController;
using MenphisSI.GerEntityTools.Entity;
using MenphisSI.Shared.BaseCommon.API.Models;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MenphisSI.AppSG.BaseCommon;

/// <summary>
/// UserService específico
/// Implementa IUserService com OperadorResponse.
/// </summary>
public class UserService : IUserService<OperadorResponse>, IDisposable
{
    private const string RESET_KEY = "reset";
    private const string RESET_KEY_ACTION = "action-reset";

    private readonly IOptions<AppSettings> _appSettings;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly HybridCache _cache;
    private readonly Stopwatch _stopwatch = new();
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

    private readonly IOperadorReader _reader;
    private readonly IFOperadorFactory _operadorFactory;
    private readonly IOperadorService _operService;
    private readonly IConnectionService _connectionService;
    private readonly IEntityService _entityService;
    private readonly IHttpClientFactory _httpClientFactory;

    private bool _disposed;

    public UserService(
        IOptions<AppSettings> appSettings,
        HybridCache cache,
        IOperadorReader reader,
        IOperadorService operService,
        IFOperadorFactory operadorFactory,
        IHttpContextAccessor httpContextAccessor,
        IConnectionService connectionService,
        IEntityService entityService,
        IHttpClientFactory httpClientFactory)
    {
        _appSettings = appSettings;
        _cache = cache;
        _reader = reader;
        _operadorFactory = operadorFactory;
        _operService = operService;
        _httpContextAccessor = httpContextAccessor;
        _connectionService = connectionService;
        _entityService = entityService;
        _httpClientFactory = httpClientFactory;
    }

    #region Helper Methods

    private string GetClientIpAddress()
    {
        var httpContext = _httpContextAccessor?.HttpContext;
        if (httpContext == null) return string.Empty;

        var forwardedFor = httpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault();
        if (!string.IsNullOrEmpty(forwardedFor))
        {
            var ips = forwardedFor.Split(',', StringSplitOptions.RemoveEmptyEntries);
            if (ips.Length > 0)
                return ips[0].Trim();
        }

        var realIp = httpContext.Request.Headers["X-Real-IP"].FirstOrDefault();
        if (!string.IsNullOrEmpty(realIp))
            return realIp.Trim();

        return httpContext.Connection.RemoteIpAddress?.ToString() ?? string.Empty;
    }

    private void LogPerformanceMetrics(string methodName, long elapsedMs, long memoryUsedBytes)
    {
        _logger.Info("Performance - {MethodName}: Time={ElapsedMs}ms, Memory={MemoryKB}KB",
            methodName, elapsedMs, memoryUsedBytes / 1024);
    }

    private async Task<T?> ExecuteWithMetrics<T>(string methodName, Func<Task<T>> operation)
    {
        _stopwatch.Restart();
        var initialMemory = GC.GetTotalMemory(false);

        try
        {
            return await operation();
        }
        finally
        {
            _stopwatch.Stop();
            var finalMemory = GC.GetTotalMemory(false);
            LogPerformanceMetrics(methodName, _stopwatch.ElapsedMilliseconds, finalMemory - initialMemory);
        }
    }

    private async Task<string> GenerateJwtToken(OperadorResponse user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Value.SecretJwt);

        var claims = new[]
        {
            new Claim("id", user.Id.ToString()),
            new Claim("tipo", "Funcionario"),
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
#if DEBUG
            Expires = DateTime.UtcNow.AddHours(1),
#else
            Expires = DateTime.UtcNow.AddHours(8),
#endif
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = await Task.Run(() => tokenHandler.CreateToken(tokenDescriptor));
        return tokenHandler.WriteToken(token);
    }

    private static string GetTipo(OperadorResponse user) => "Funcionario";

    #endregion

    #region IUserService Implementation

    public async Task<ResultApi<ValidaUsernameResponse>> ValidaUsername(ValidaUsernameRequest model, string uri)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(model);
            if (string.IsNullOrEmpty(uri))
                return ResultApi<ValidaUsernameResponse>.Fail("URI não pode ser vazia", 400);

            if (!(await Uris.ValidaUriAsync(uri, _entityService)))
            {
                _logger.Warn("ValidaUsername: URI não é valida {Uri}", uri);
                return ResultApi<ValidaUsernameResponse>.Fail("Domínio não encontrado.", 404);
            }

            using var oCnn = await _connectionService.GetConnectionByUriAsync(uri);
            if (oCnn == null)
            {
                _logger.Warn("ValidaUsername: Conexão nula");
                return ResultApi<ValidaUsernameResponse>.Fail("Erro de conexão com a base de dados.", 500);
            }

            var decodedUsername = model.Username.DecodeBase64();
            if (decodedUsername == null)
            {
                _logger.Warn("Decoded nulo");
                return ResultApi<ValidaUsernameResponse>.Fail("Nome de usuário inválido", 400);
            }

            var cWhere = $"{DBOperadorDicInfo.EMailNet} = @{DBOperadorDicInfo.EMailNet} {TSql.And} " +
                         $"{DBOperadorDicInfo.Situacao} = @{DBOperadorDicInfo.Situacao} {TSql.And} " +
                         $"{DBOperadorDicInfo.Excluido} = @{DBOperadorDicInfo.Excluido}";

            var parameters = new List<SqlParameter>
            {
                new($"@{DBOperadorDicInfo.EMailNet}", decodedUsername),
                new($"@{DBOperadorDicInfo.Situacao}", true),
                new($"@{DBOperadorDicInfo.Excluido}", false)
            };

            var result = _reader.Read(cWhere, parameters, oCnn);

            var response = result?.Id > 0
                ? new ValidaUsernameResponse
                {
                    Id = result.Id,
                    Username = model.Username,
                    Uri = uri
                }
                : new ValidaUsernameResponse
                {
                    Id = 0,
                    Username = "Usuário desconhecido",
                    Uri = ""
                };

            return ResultApi<ValidaUsernameResponse>.Ok(response);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "ValidaUsername: Erro ao validar username");
            return ResultApi<ValidaUsernameResponse>.Fail($"Erro ao validar usuário: {ex.Message}", 500);
        }
    }

    public async Task<ResultApi<AuthenticateResponse>> Authenticate3(AuthenticateRequest model, string uri)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(model);
            if (string.IsNullOrEmpty(uri))
                return ResultApi<AuthenticateResponse>.Fail("URI não pode ser vazia", 400);

            if (!(await Uris.ValidaUriAsync(uri, _entityService)))
            {
                _logger.Warn("Authenticate: URI não é valida {Uri}", uri);
                return ResultApi<AuthenticateResponse>.Fail("URI inválida", 400);
            }

            using var oCnn = await _connectionService.GetConnectionByUriAsync(uri);
            if (oCnn == null)
            {
                _logger.Warn("Authenticate: Conexão nula");
                return ResultApi<AuthenticateResponse>.Fail("Erro de conexão com a base de dados.", 500);
            }

            var user = await AuthenticateUserAsync(model, uri, oCnn);
            if (user == null)
                return ResultApi<AuthenticateResponse>.Fail("Credenciais inválidas", 401);

            try
            {
                var tipo = GetTipo(user);
                var token = await GenerateJwtToken(user);
                var token64 = Convert.ToBase64String(Encoding.ASCII.GetBytes(token));

                var response = new AuthenticateResponse(user, token64, tipo, uri);
                return ResultApi<AuthenticateResponse>.Ok(response);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Authenticate: Erro ao gerar token");
                return ResultApi<AuthenticateResponse>.Fail("Erro ao gerar token de autenticação", 500);
            }
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Authenticate: Erro geral");
            return ResultApi<AuthenticateResponse>.Fail($"Erro ao autenticar: {ex.Message}", 500);
        }
    }

    private async Task<OperadorResponse?> AuthenticateUserAsync(AuthenticateRequest model, string uri, MsiSqlConnection oCnn)
    {
        var decodedUsername = model.Username.DecodeBase64();
        var passwordHash = model.Password.DecodeBase64().GetHashCode2();

        var cWhere = $@"{DBOperadorDicInfo.EMailNet} = @{DBOperadorDicInfo.EMailNet} {TSql.And} 
                       {DBOperadorDicInfo.Situacao} = @{DBOperadorDicInfo.Situacao} {TSql.And}
                       {DBOperadorDicInfo.Excluido} = @{DBOperadorDicInfo.Excluido} {TSql.And} 
                       {DBOperadorDicInfo.Senha256} = @{DBOperadorDicInfo.Senha256}";

        var parameters = new List<SqlParameter>
        {
            new($"@{DBOperadorDicInfo.EMailNet}", decodedUsername),
            new($"@{DBOperadorDicInfo.Situacao}", true),
            new($"@{DBOperadorDicInfo.Excluido}", false),
            new($"@{DBOperadorDicInfo.Senha256}", passwordHash),
        };

        var result = await Task.Run(() => _reader.Read(cWhere, parameters, oCnn));

        if (result == null)
        {
            result = await TryResetPasswordLogin(model, oCnn, decodedUsername);
        }

        if (result != null)
        {
            await ClearResetTokenIfExists(result.Id, oCnn);
        }
        return result;
    }

    private async Task<OperadorResponse?> TryResetPasswordLogin(AuthenticateRequest model, MsiSqlConnection oCnn, string? decodedUsername)
    {
        var cWhereReset = $@"{DBOperadorDicInfo.EMailNet} = @{DBOperadorDicInfo.EMailNet} {TSql.And} 
                   {DBOperadorDicInfo.Situacao} = @{DBOperadorDicInfo.Situacao} {TSql.And}
                   {DBOperadorDicInfo.Excluido} = @{DBOperadorDicInfo.Excluido}";

        var parametersReset = new List<SqlParameter>
        {
            new($"@{DBOperadorDicInfo.EMailNet}", decodedUsername ?? ""),
            new($"@{DBOperadorDicInfo.Situacao}", true),
            new($"@{DBOperadorDicInfo.Excluido}", false),
        };

        var resultReset = _reader.Read(cWhereReset, parametersReset, oCnn);

        if (resultReset != null && resultReset.Id > 0)
        {
            var dbU = await _operadorFactory.CreateFromIdAsync(resultReset.Id, oCnn);
            if (dbU.ID > 0)
            {
                var guidReset = dbU.ReadCfgC(RESET_KEY, oCnn);
                if (guidReset.Length > 0)
                {
                    var decodedPassword = model.Password.DecodeBase64();
                    if (guidReset.Equals(decodedPassword))
                    {
                        dbU.WriteCfgC(RESET_KEY, "", oCnn);
                        dbU.WriteCfgC(RESET_KEY_ACTION, GetClientIpAddress().Encrypt(), oCnn);

                        var result = _reader.Read(cWhereReset, parametersReset, oCnn);
                        return result == null || result.Id == 0 ? null : result;
                    }
                }
                else
                {
                    dbU.WriteCfgC(RESET_KEY_ACTION, "", oCnn);
                }
            }
        }

        _logger.Warn("Authenticate: result == null!");
        return null;
    }

    private async Task ClearResetTokenIfExists(int userId, MsiSqlConnection oCnn)
    {
        var dbU = await _operadorFactory.CreateFromIdAsync(userId, oCnn);
        if (dbU.ID > 0)
        {
            var guidReset = dbU.ReadCfgC(RESET_KEY, oCnn);
            if (!string.IsNullOrEmpty(guidReset))
            {
                await Task.Run(() => dbU.WriteCfgC(RESET_KEY, "", oCnn));
            }
        }
    }

    public async Task<ResultApi<OperadorResponse>> GetById(int id, string uri)
    {
        try
        {
            if (string.IsNullOrEmpty(uri))
                return ResultApi<OperadorResponse>.Fail("URI não pode ser vazia", 400);

            if (!(await Uris.ValidaUriAsync(uri, _entityService)))
            {
                return ResultApi<OperadorResponse>.Fail("URI inválida", 400);
            }

            var cacheKey = $"{uri}-User-GetById-{id}";
            var entryOptions = new HybridCacheEntryOptions
            {
                Expiration = TimeSpan.FromSeconds(60),
                LocalCacheExpiration = TimeSpan.FromSeconds(60)
            };

            var result = await _cache.GetOrCreateAsync(
                cacheKey,
                async cancel => await GetDataByIdAsync(id, uri, cancel),
                entryOptions);

            if (result == null)
                return ResultApi<OperadorResponse>.NotFound("Usuário não encontrado");

            return ResultApi<OperadorResponse>.Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "GetById: Erro ao buscar usuário");
            return ResultApi<OperadorResponse>.Fail($"Erro ao buscar usuário: {ex.Message}", 500);
        }
    }

    private async Task<OperadorResponse?> GetDataByIdAsync(int id, string uri, CancellationToken token)
    {
        using var scope = _connectionService.CreateConnectionScope(uri);
        var oCnn = scope.Connection;
        return oCnn == null ? null :
            await Task.Run(() => _reader.ReadAsync(id, oCnn), token);
    }

    [Authorize]
    public async Task<ResultApi<string>> Reset(string uri)
    {
        try
        {
            if (string.IsNullOrEmpty(uri))
                return ResultApi<string>.Fail("URI não pode ser vazia", 400);

            if (!(await Uris.ValidaUriAsync(uri, _entityService)))
            {
                return ResultApi<string>.Fail("URI inválida", 400);
            }

            if (_httpContextAccessor?.HttpContext?.User != null)
            {
                var user = _httpContextAccessor.HttpContext?.User;
                if (user == null)
                    return ResultApi<string>.Fail("Usuário não autenticado", 401);

                var userId = UserTools.GetAuthenticatedUserId(_httpContextAccessor);
                using var oCnn = await _connectionService.GetConnectionByUriRwAsync(uri);
                var dbU = await _operadorFactory.CreateFromIdAsync(userId, oCnn);
                if (dbU.ID > 0)
                {
                    if (dbU.ReadCfgC(RESET_KEY_ACTION, oCnn) == GetClientIpAddress().Encrypt())
                    {
                        if (dbU.ReadCfgC($"{RESET_KEY_ACTION}-T", oCnn) == "")
                        {
                            dbU.WriteCfgC($"{RESET_KEY_ACTION}-T", "R", oCnn);
                            return ResultApi<string>.Ok(RESET_KEY);
                        }
                        dbU.WriteCfgC($"{RESET_KEY_ACTION}-T", "", oCnn);
                        dbU.WriteCfgC(RESET_KEY_ACTION, "", oCnn);
                        return ResultApi<string>.Ok(RESET_KEY);
                    }
                }
            }
            return ResultApi<string>.Fail("Operação não autorizada", 403);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Reset: Erro ao resetar configurações");
            return ResultApi<string>.Fail($"Erro ao resetar: {ex.Message}", 500);
        }
    }

    [Authorize]
    public async Task<ResultApi<bool>> SetPassword(int id, string password, string uri)
    {
        try
        {
            if (string.IsNullOrEmpty(uri))
                return ResultApi<bool>.Fail("URI não pode ser vazia", 400);

            if (string.IsNullOrEmpty(password))
                return ResultApi<bool>.Fail("Senha não pode ser vazia", 400);

            if (!(await Uris.ValidaUriAsync(uri, _entityService)))
            {
                return ResultApi<bool>.Fail("URI inválida", 400);
            }

            using var scope = _connectionService.CreateConnectionScopeRw(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
                return ResultApi<bool>.Fail("Erro de conexão com a base de dados.", 500);

            var dbRec = await _reader.ReadMAsync(id, oCnn);
            if (dbRec == null)
            {
                _logger.Warn("SetPassword: dbRec é nulo para o ID {Id}", id);
                return ResultApi<bool>.NotFound("Usuário não encontrado");
            }

            if (dbRec.Id <= 0 || !dbRec.Situacao || dbRec.Excluido)
                return ResultApi<bool>.Fail("Usuário inativo ou excluído", 400);

            dbRec.Senha256 = password.GetHashCode2();

            var result = await _operService.AddAndUpdate(dbRec, uri);

            if (result != null && result?.Data?.Id > 0)
                return ResultApi<bool>.Ok(true, "Senha alterada com sucesso");

            return ResultApi<bool>.Fail("Erro ao alterar senha", 500);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "SetPassword: Erro ao definir senha");
            return ResultApi<bool>.Fail($"Erro ao definir senha: {ex.Message}", 500);
        }
    }

    public async Task<ResultApi<AuthenticateResponse>> ResetPassword(AuthenticateRequest model, string uri)
    {
        try
        {
            if (model == null)
                return ResultApi<AuthenticateResponse>.Fail("Modelo não pode ser nulo", 400);

            if (string.IsNullOrEmpty(uri))
                return ResultApi<AuthenticateResponse>.Fail("URI não pode ser vazia", 400);

            if (!(await Uris.ValidaUriAsync(uri, _entityService)))
            {
                _logger.Warn("ResetPassword: URI não é valida {Uri}", uri);
                return ResultApi<AuthenticateResponse>.Fail("URI inválida", 400);
            }

            using var scope = _connectionService.CreateConnectionScopeRw(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                _logger.Warn("ResetPassword: Conexão nula");
                return ResultApi<AuthenticateResponse>.Fail("Erro de conexão com a base de dados.", 500);
            }

            var cWhereReset = $@"{DBOperadorDicInfo.EMailNet} = @{DBOperadorDicInfo.EMailNet} {TSql.And} 
                       {DBOperadorDicInfo.Situacao} = @{DBOperadorDicInfo.Situacao} {TSql.And}
                       {DBOperadorDicInfo.Excluido} = @{DBOperadorDicInfo.Excluido}";

            var parametersReset = new List<SqlParameter>
            {
                new($"@{DBOperadorDicInfo.EMailNet}", model.Username.DecodeBase64()),
                new($"@{DBOperadorDicInfo.Situacao}", true),
                new($"@{DBOperadorDicInfo.Excluido}", false),
            };

            var resultReset = await Task.Run(() => _reader.Read(cWhereReset, parametersReset, oCnn));

            if (resultReset?.Id > 0)
            {
                var dbU = await _operadorFactory.CreateFromIdAsync(resultReset.Id, oCnn);
                var guidReset = Guid.NewGuid().ToString().Replace("-", "");

                if (!string.IsNullOrEmpty(guidReset))
                {
                    dbU.WriteCfgC(RESET_KEY, guidReset, oCnn);
                    dbU.WriteCfgC(RESET_KEY_ACTION, "", oCnn);

                    var token = await GenerateJwtToken(resultReset);
                    var token64 = Convert.ToBase64String(Encoding.ASCII.GetBytes(token));

                    var send = new SendEmailApi(_httpClientFactory, _entityService, _logger);
                    _ = send.Send(new MenphisSI.Api.Models.SendEmail
                    {
                        EmailPara = dbU.FEMailNet!,
                        NomePara = dbU.FNome!,
                        Assunto = "RESET DE SENHA",
                        Mensagem = $@"<h1>Reset de Senha</h1>
                        <p style='color: #fff'>Sua senha foi resetada com sucesso. Use este código no lugar da senha ao fazer login:</p>
                        <div class=""code-box""><strong>{guidReset}</strong></div>
                        <p class=""alert"">Se não foi você que solicitou o reset, por favor, ignore este e-mail.</p>",
                        NomeDoMail = "MENPHIS - SISTEMAS INTELIGENTES",
                        Time2Live = 1,
                        Uri = uri,
                        EmailNet = dbU.FEMailNet!

                    });

                    var response = new AuthenticateResponse(resultReset, token64, RESET_KEY, uri);
                    return ResultApi<AuthenticateResponse>.Ok(response, "Senha resetada com sucesso. Verifique seu e-mail.");
                }
            }

            return ResultApi<AuthenticateResponse>.NotFound("Usuário não encontrado");
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "ResetPassword: Erro ao resetar senha");
            return ResultApi<AuthenticateResponse>.Fail($"Erro ao resetar senha: {ex.Message}", 500);
        }
    }

    public async Task<ResultApi<AuthenticateResponse>> ChangePassword(AuthenticateRequest model, string uri)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(model);
            if (string.IsNullOrEmpty(uri))
                return ResultApi<AuthenticateResponse>.Fail("URI não pode ser vazia", 400);

            if (!(await Uris.ValidaUriAsync(uri, _entityService)))
            {
                _logger.Warn("ChangePassword: URI não é valida {Uri}", uri);
                return ResultApi<AuthenticateResponse>.Fail("URI inválida", 400);
            }

            using var scope = _connectionService.CreateConnectionScopeRw(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                _logger.Warn("ChangePassword: Conexão nula");
                return ResultApi<AuthenticateResponse>.Fail("Erro de conexão com a base de dados.", 500);
            }

            var cWhereReset = $@"{DBOperadorDicInfo.EMailNet} = @{DBOperadorDicInfo.EMailNet} {TSql.And} 
                       {DBOperadorDicInfo.Situacao} = @{DBOperadorDicInfo.Situacao} {TSql.And}
                       {DBOperadorDicInfo.Excluido} = @{DBOperadorDicInfo.Excluido}";

            var parametersReset = new List<SqlParameter>
            {
                new($"@{DBOperadorDicInfo.EMailNet}", model.Username.DecodeBase64()),
                new($"@{DBOperadorDicInfo.Situacao}", true),
                new($"@{DBOperadorDicInfo.Excluido}", false),
            };

            var resultReset = _reader.Read(cWhereReset, parametersReset, oCnn);

            if (resultReset?.Id > 0)
            {
                var dbU = await _reader.ReadMAsync(resultReset.Id, oCnn);
                if (dbU == null)
                {
                    _logger.Warn("ChangePassword: dbU é nulo para o ID {Id}", resultReset.Id);
                    return ResultApi<AuthenticateResponse>.NotFound("Usuário não encontrado");
                }

                if (dbU.Id <= 0 || !dbU.Situacao || dbU.Excluido)
                    return ResultApi<AuthenticateResponse>.Fail("Usuário inativo ou excluído", 400);

                var parametersPwd = new List<SqlParameter>
                {
                    new($"@{DBOperadorDicInfo.CampoCodigo}", dbU.Id),
                };
                var senha256 = ConfiguracoesDBT.GetField(DBOperadorDicInfo.CampoCodigo.Sql(),
                    DBOperadorDicInfo.Senha256, DBOperador.PTabelaNome, parametersPwd, oCnn);

                var senhasIguais = senha256?.Equals(model.CurrentPassword.DecodeBase64().GetHashCode2()) ?? false;
                var senhaAntigaValida = !model.ValidCurrentPassword || senhasIguais;

                if (dbU.Senha256 != null && senhaAntigaValida)
                {
                    dbU.Senha256 = model.Password.DecodeBase64();

                    _ = await _operService.AddAndUpdate(dbU, uri);

                    var response = new AuthenticateResponse(resultReset, "", "", uri);
                    return ResultApi<AuthenticateResponse>.Ok(response, "Senha alterada com sucesso");
                }
                else
                {
                    _logger.Warn("ChangePassword: Senha atual não confere");
                    return ResultApi<AuthenticateResponse>.Fail("Senha atual incorreta", 400);
                }
            }

            return ResultApi<AuthenticateResponse>.NotFound("Usuário não encontrado");
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "ChangePassword: Erro ao alterar senha");
            return ResultApi<AuthenticateResponse>.Fail($"Erro ao alterar senha: {ex.Message}", 500);
        }
    }

    public Task<ResultApi<AuthenticateResponse>> SelfAuthenticate(AuthenticateRequest model)
    {
        // Try to obtain uri from the current HTTP context route values (controller route contains {uri})
        var httpContext = _httpContextAccessor?.HttpContext;
        string? uri = null;

        try
        {
            if (httpContext != null)
            {
                if (httpContext.Request.RouteValues.TryGetValue("uri", out var routeUri))
                {
                    uri = routeUri?.ToString();
                }
                // fallback to querystring if route value not present
                if (string.IsNullOrEmpty(uri) && httpContext.Request.Query.ContainsKey("uri"))
                {
                    uri = httpContext.Request.Query["uri"].FirstOrDefault();
                }
            }
        }
        catch
        {
            // ignore and use fallback
        }

        // Fallback to demo URI from settings if still null/empty
        if (string.IsNullOrEmpty(uri))
        {
            uri = _appSettings?.Value?.DemoURI ?? string.Empty;
        }

        return Authenticate3(model, uri);
    }

    #endregion

    #region IDisposable

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed) return;

        if (disposing)
        {
            _stopwatch?.Stop();
        }

        _disposed = true;
    }

    ~UserService()
    {
        Dispose(false);
    }

    #endregion
}
