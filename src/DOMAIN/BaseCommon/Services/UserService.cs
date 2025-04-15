using MenphisSI.GerEntityTools.Entity;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
namespace MenphisSI.BaseCommon;

public partial class UserService : IUserService, IDisposable
{
    const string RESET_KEY = "reset";
    private readonly AppSettings _appSettings;
    private readonly string _uris;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private readonly HybridCache _cache;
    private readonly Stopwatch _stopwatch;
    private readonly IOperadorReader _reader;

    private bool _disposed;

    public UserService(IOptions<AppSettings> appSettings, IOperadorReader reader, IHttpContextAccessor httpContextAccessor, HybridCache cache)
    {
        _appSettings = appSettings.Value ?? throw new ArgumentNullException(nameof(appSettings));
        _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        _uris = _appSettings.ValidUris;
        _cache = cache;// ?? throw new ArgumentNullException(nameof(cache));
        _stopwatch = new Stopwatch();
        _reader = reader ?? throw new ArgumentNullException(nameof(reader));
    }

    private void LogPerformanceMetrics(string methodName, long elapsedMs, long memoryUsedBytes)
    {
        _logger.Info($"Performance - {methodName}: Time={elapsedMs}ms, Memory={memoryUsedBytes / 1024}KB");
    }

    private async Task<T?> ExecuteWithMetrics<T>(string methodName, Func<Task<T>> operation)
    {
        _stopwatch.Restart();
        var initialMemory = GC.GetTotalMemory(false);

        try
        {
            return await operation().ConfigureAwait(false);
        }
        finally
        {
            _stopwatch.Stop();
            var finalMemory = GC.GetTotalMemory(false);
            LogPerformanceMetrics(methodName, _stopwatch.ElapsedMilliseconds, finalMemory - initialMemory);
        }
    }

    public async Task<ValidaUsernameResponse?> ValidaUsername(ValidaUsernameRequest model, string uri)
    {
        return await ExecuteWithMetrics("ValidaUsername", async () =>
        {
            ArgumentNullException.ThrowIfNull(model);
            if (string.IsNullOrEmpty(uri)) throw new ArgumentNullException(nameof(uri));

            if (!Uris.ValidaUri(uri, _uris))
            {
                _logger.Warn("ValidaUsername: URI não é valida {Uri} - {ValidUris}", uri, _uris);
                throw new Exception("ValidaUsername: URI inválida");
            }

            using var scope = Configuracoes.CreateConnectionScope(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                _logger.Warn("ValidaUsername: Conexão nula");
                return null;
            }

            var decodedUsername = model.Username.DecodeBase64();
            if (decodedUsername == null)
            {
                _logger.Warn("Decoded nulo");
                return null;
            }

            var cWhere = $"{DBOperadorDicInfo.EMailNetSql(decodedUsername)} {TSql.And} " +
                        $"{DBOperadorDicInfo.SituacaoSqlSim} {TSql.And} " +
                        $"{DBOperadorDicInfo.ExcluidoSqlNao}";

            var result = await Task.Run(() => _reader.Read(cWhere, oCnn))
                .ConfigureAwait(false);

            return result?.Id > 0
                ? new ValidaUsernameResponse
                {
                    Id = result.Id,
                    Username = model.Username,
                    Uri = uri
                }
                : null;
        });
    }

   
    private async Task<OperadorResponse?> AuthenticateUserAsync(AuthenticateRequest model, SqlConnection oCnn)
    {
        var decodedUsername = model.Username.DecodeBase64();
        var passwordHash = model.Password.DecodeBase64().GetHashCode2();

        var cWhere = $"{DBOperadorDicInfo.EMailNetSql(decodedUsername)} {TSql.And} " +
                     $"{DBOperadorDicInfo.SituacaoSqlSim} {TSql.And} " +
                     $"{DBOperadorDicInfo.ExcluidoSqlNao} {TSql.And} " +
                     $"{DBOperadorDicInfo.Senha256Sql(passwordHash)}";

        var result = await Task.Run(() => _reader.Read(cWhere, oCnn))
            .ConfigureAwait(false);

        if (result == null)
        {

            var cWhereReset = DBOperadorDicInfo.EMailNetSql(model.Username.DecodeBase64()) + TSql.And +
                    DBOperadorDicInfo.SituacaoSqlSim + TSql.And +
                    DBOperadorDicInfo.ExcluidoSqlNao;

            var resultReset = _reader.Read(cWhereReset, oCnn);

            if (resultReset != null && resultReset.Id > 0)
            {
                var dbU = new DBOperador(resultReset.Id, oCnn);
                if (dbU.ID > 0)
                {
                    var guidReset = dbU.ReadCfgC(RESET_KEY, oCnn);
                    if (guidReset.Length > 0)
                    {
                        if (guidReset.Equals(model.Password.DecodeBase64()))
                        {
                            dbU.WriteCfgC(RESET_KEY, "", oCnn);
                            dbU.FStatusMessage = "Senha Resetada";
                            dbU.Update(oCnn);
                            result = _reader.Read(cWhereReset, oCnn);
                            return result == null || result.Id == 0 ? null : result;
                        }
                    }
                }
            }

            _logger.Warn("Authenticate: result == null!");
            
        }

        if (result != null)
        {
            await ClearResetTokenIfExists(result.Id, oCnn).ConfigureAwait(false);
        }
        return result;
    } 

    private async Task ClearResetTokenIfExists(int userId, SqlConnection oCnn)
    {
        var dbU = new DBOperador(userId, oCnn);
        if (dbU.ID > 0)
        {
            var guidReset = dbU.ReadCfgC(RESET_KEY, oCnn);
            if (!string.IsNullOrEmpty(guidReset))
            {
                await Task.Run(() => dbU.WriteCfgC(RESET_KEY, "", oCnn))
                    .ConfigureAwait(false);
            }
        }
    }

    public async Task<OperadorResponse?> GetById(int id, string uri)
    {
        return await ExecuteWithMetrics("GetById", async () =>
        {
            if (string.IsNullOrEmpty(uri)) throw new ArgumentNullException(nameof(uri));
            if (!Uris.ValidaUri(uri, _uris))
            {
                throw new Exception("User: URI inválida");
            }

            var cacheKey = $"{uri}-User-GetById-{id}";
            var entryOptions = new HybridCacheEntryOptions
            {
                Expiration = TimeSpan.FromSeconds(60),
                LocalCacheExpiration = TimeSpan.FromSeconds(60)
            };

            return await _cache.GetOrCreateAsync(
                cacheKey,
                async cancel => await GetDataByIdAsync(id, uri, cancel),
                entryOptions).ConfigureAwait(false);
        });
    }

    private async Task<OperadorResponse?> GetDataByIdAsync(int id, string uri, CancellationToken token)
    {
        using var scope = Configuracoes.CreateConnectionScope(uri);
        var oCnn = scope.Connection;
        return oCnn == null ? null :
            await Task.Run(() => _reader.Read(id, oCnn), token)
                .ConfigureAwait(false);
    }

    [Authorize]
    public string Reset(string uri)
    {
        if (string.IsNullOrEmpty(uri)) throw new ArgumentNullException(nameof(uri));
        if (!Uris.ValidaUri(uri, _uris))
        {
            throw new Exception("User: URI inválida");
        }

        var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(RESET_KEY);
        var result = userIdClaim == null ? "" :
               !string.IsNullOrEmpty(userIdClaim.Value) ? RESET_KEY : "";

        if (result.Equals(RESET_KEY) && _httpContextAccessor?.HttpContext?.User != null)
        {
            var user = _httpContextAccessor.HttpContext?.User;
            if (user != null)
            {
                var claims = user.Claims.Where(c => c.Type != RESET_KEY).ToList();
                var identity = new ClaimsIdentity(claims, user.Identity?.AuthenticationType);
                _httpContextAccessor!.HttpContext!.User = new ClaimsPrincipal(identity);
            }

            var userId = UserTools.GetAuthenticatedUserId(_httpContextAccessor);
            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            var dbU = new DBOperador(userId, oCnn);
            if (dbU.ID > 0)
            {
                dbU.FStatusMessage = "";
                dbU.AuditorQuem = 1;
                dbU.Update(oCnn);
            }
        }
        return result;
    }

    [Authorize]
    public async Task<bool> SetPassword(int id, string password, string uri)
    {
        return await ExecuteWithMetrics("SetPassword", async () =>
        {
            if (string.IsNullOrEmpty(uri)) throw new ArgumentNullException(nameof(uri));
            if (string.IsNullOrEmpty(password)) throw new ArgumentNullException(nameof(password));

            if (!Uris.ValidaUri(uri, _uris))
            {
                throw new Exception("User: URI inválida");
            }

            using var scope = Configuracoes.CreateConnectionScopeRw(uri);
            var oCnn = scope.Connection;
            if (oCnn == null) return false;

            return await Task.Run(() =>
            {
                var dbRec = new DBOperador(id, oCnn);
                if (dbRec.ID <= 0 || !dbRec.FSituacao || dbRec.FExcluido) return false;

                dbRec.FSenha256 = password.GetHashCode2();
                dbRec.FStatusMessage = "";
                dbRec.AuditorQuem = id;
                return dbRec.Update(oCnn) == 0;
            }).ConfigureAwait(false);
        });
    }



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

    public async Task<AuthenticateResponse?> ResetSenha(AuthenticateRequest model, [FromRoute] string uri)
    {
        return await ExecuteWithMetrics("ResetSenha", async () =>
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            if (string.IsNullOrEmpty(uri)) throw new ArgumentNullException(nameof(uri));

            if (!Uris.ValidaUri(uri, _uris))
            {
                _logger.Warn("ResetSenha: URI não é valida {Uri} - {ValidUris}", uri, _uris);
                throw new Exception("User: URI inválida");
            }

            using var scope = Configuracoes.CreateConnectionScopeRw(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                _logger.Warn("ResetSenha: Conexão nula");
                return null;
            }

            var cWhereReset = $"{DBOperadorDicInfo.EMailNetSql(model.Username.DecodeBase64())} {TSql.And} " +
                              $"{DBOperadorDicInfo.SituacaoSqlSim} {TSql.And} " +
                              $"{DBOperadorDicInfo.ExcluidoSqlNao}";

            var resultReset = await Task.Run(() => _reader.Read(cWhereReset, oCnn))
                .ConfigureAwait(false);

            if (resultReset?.Id > 0)
            {
                var dbU = new DBOperador(resultReset.Id, oCnn);
                var guidReset = Guid.NewGuid().ToString();

                if (!string.IsNullOrEmpty(guidReset))
                {
                    dbU.WriteCfgC(RESET_KEY, guidReset, oCnn);
                    dbU.FStatusMessage = "";
                    dbU.Update(oCnn);

                    var token = await GenerateJwtToken(resultReset).ConfigureAwait(false);
                    var token64 = Convert.ToBase64String(Encoding.ASCII.GetBytes(token));

                    var send = new SendEmailApi();
                    _ = send.Send(new MenphisSI.Api.Models.SendEmail
                    {
                        ParaEmail = dbU.FEMailNet!,
                        ParaNome = dbU.FNome!,
                        Assunto = "RESET DE SENHA",
                        Mensagem = @$"<h1>Reset de Senha</h1>
            
            <p>Sua senha foi resetada com sucesso. Use este código no lugar da senha ao fazer login:</p>
            
            <div class=""code-box"">
                <strong>{guidReset}</strong>
            </div>
            
            <p class=""alert"">Se não foi você que solicitou o reset, por favor, ignore este e-mail.</p>",
                        NomeDoMail = "MENPHIS - SISTEMAS INTELIGENTES",
                        Time2Live = 1
                    });

                    return new AuthenticateResponse(resultReset, token64, RESET_KEY, uri);
                }
            }

            return null;
        });
    }


    ~UserService()
    {
        Dispose(false);
    }
}