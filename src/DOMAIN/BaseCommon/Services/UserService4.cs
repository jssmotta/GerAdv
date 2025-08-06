using MenphisSI.GerEntityTools.Entity;
using System.Diagnostics;
namespace MenphisSI.BaseCommon;

public partial class UserService(IOptions<AppSettings> appSettings, HybridCache cache, IOperadorReader operReader, IOperadorService operService, IFOperadorFactory operadorFactory, IOperadorReader reader, IHttpContextAccessor httpContextAccessor) : IUserService, IDisposable
{
    private const string RESET_KEY2 = "reset";
    private const string RESET_KEY_ACTION = "action-reset";
    private readonly IOptions<AppSettings> _appSettings = appSettings;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private readonly HybridCache _cache = cache;
    private readonly Stopwatch _stopwatch = new();
    private readonly IOperadorReader _reader = reader;
    private readonly IFOperadorFactory _operadorFactory = operadorFactory;    
    private readonly IOperadorService _operService = operService;    
    private readonly IOperadorReader _operReader = operReader;

    private bool _disposed;

    private string GetClientIpAddress()
    {
        var httpContext = _httpContextAccessor?.HttpContext;
        if (httpContext == null) return string.Empty;

        // Verificar cabeçalhos de proxy primeiro
        var forwardedFor = httpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault();
        if (!string.IsNullOrEmpty(forwardedFor))
        {
            var ips = forwardedFor.Split(',', StringSplitOptions.RemoveEmptyEntries);
            if (ips.Length > 0)
            {
                return ips[0].Trim();
            }
        }

        var realIp = httpContext.Request.Headers["X-Real-IP"].FirstOrDefault();
        if (!string.IsNullOrEmpty(realIp))
        {
            return realIp.Trim();
        }

        return httpContext.Connection.RemoteIpAddress?.ToString() ?? string.Empty;
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

            if (!Uris.ValidaUri(uri, _appSettings))
            {
                _logger.Warn($"ValidaUsername: URI não é valida {uri}");
                throw new Exception("Domínio não encontrado."); // Vai para o Frontend
            }

            using var scope = Configuracoes.CreateConnectionScope(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                _logger.Warn("ValidaUsername: Conexão nula");
                throw new Exception("Erro de conexão com a base de dados.");
            }

            var decodedUsername = model.Username.DecodeBase64();
            if (decodedUsername == null)
            {
                _logger.Warn("Decoded nulo");
                return null;
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

            var result = await Task.Run(() => _reader.Read(cWhere, parameters, oCnn))
                .ConfigureAwait(false);

            return result?.Id > 0
                ? new ValidaUsernameResponse
                {
                    Id = result.Id,
                    Username = model.Username,
                    Uri = uri
                }
                : throw new Exception("Usuário desconhecido, inativado ou excluído.");
        });
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


        var result = await Task.Run(() => _reader.Read(cWhere, parameters, oCnn))
            .ConfigureAwait(false);

        if (result == null)
        {
            var cWhereReset = $@"{DBOperadorDicInfo.EMailNet} = @{DBOperadorDicInfo.EMailNet} {TSql.And} 
                       {DBOperadorDicInfo.Situacao} = @{DBOperadorDicInfo.Situacao} {TSql.And}
                       {DBOperadorDicInfo.Excluido} = @{DBOperadorDicInfo.Excluido}";

            var parametersReset = new List<SqlParameter>
            {
                new($"@{DBOperadorDicInfo.EMailNet}", decodedUsername),
                new($"@{DBOperadorDicInfo.Situacao}", true),
                new($"@{DBOperadorDicInfo.Excluido}", false),
            };

            var resultReset = _reader.Read(cWhereReset, parametersReset, oCnn);

            if (resultReset != null && resultReset.Id > 0)
            {
                var dbU = await _operadorFactory.CreateFromIdAsync(resultReset.Id, oCnn);
                if (dbU.ID > 0)
                {
                    var guidReset = dbU.ReadCfgC(RESET_KEY2, oCnn);
                    if (guidReset.Length > 0)
                    {
                        if (guidReset.Equals(model.Password.DecodeBase64()))
                        {                            

                            // CÓDIGO TEMPORÁRIO VÁLIDO - PREPARAR PARA TROCA OBRIGATÓRIA
                            dbU.WriteCfgC(RESET_KEY2, "", oCnn);
                            dbU.WriteCfgC(RESET_KEY_ACTION, "1", oCnn);                            
                            
                            dbU.FSenha256 = GetClientIpAddress().Encrypt(); // ← ESTA É A CHAVE!
                            
                            var dbRegistro = await _operReader.ReadM(dbU.ID, oCnn);

                            if (dbRegistro == null)
                            {
                                _logger.Warn("Authenticate: dbRegistro é nulo!");
                                return null;
                            }

                            dbRegistro.Senha256 = dbU.FSenha256;                            

                            await _operService.AddAndUpdate(dbRegistro, uri);

                            result = _reader.Read(cWhereReset, parametersReset, oCnn);
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

        }

        if (result != null)
        {
            await ClearResetTokenIfExists(result.Id, oCnn).ConfigureAwait(false);
        }
        return result;
    }

    private async Task ClearResetTokenIfExists(int userId, MsiSqlConnection oCnn)
    {
        var dbU = await _operadorFactory.CreateFromIdAsync(userId, oCnn);
        if (dbU.ID > 0)
        {
            var guidReset = dbU.ReadCfgC(RESET_KEY2, oCnn);
            if (!string.IsNullOrEmpty(guidReset))
            {
                await Task.Run(() => dbU.WriteCfgC(RESET_KEY2, "", oCnn))
                    .ConfigureAwait(false);
            }
        }
    }

    public async Task<OperadorResponse?> GetById(int id, string uri)
    {
        return await ExecuteWithMetrics("GetById", async () =>
        {
            if (string.IsNullOrEmpty(uri)) throw new ArgumentNullException(nameof(uri));
            if (!Uris.ValidaUri(uri, _appSettings))
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
    public async Task<string> Reset(string uri)
    {
        if (string.IsNullOrEmpty(uri)) throw new ArgumentNullException(nameof(uri));
        if (!Uris.ValidaUri(uri, _appSettings))
        {
            throw new Exception("User: URI inválida");
        }

        if (_httpContextAccessor?.HttpContext?.User != null)
        {
            var user = _httpContextAccessor.HttpContext?.User;
            if (user == null) return string.Empty;

            var userId = UserTools.GetAuthenticatedUserId(_httpContextAccessor);
            using var oCnn = Configuracoes.GetConnectionByUriRw(uri);
            var dbU = await _operadorFactory.CreateFromIdAsync(userId, oCnn);
            if (dbU.ID > 0)
            {
                // Verificar se há ação de reset pendente
                if (dbU.ReadCfgC(RESET_KEY_ACTION, oCnn) == "1")
                {
                    dbU.WriteCfgC(RESET_KEY_ACTION, "", oCnn);
                    return RESET_KEY2; // ← Retorna que precisa trocar senha
                }

                // Verificar se tem senha de reset
                if (dbU.FSenha256 == GetClientIpAddress().Encrypt())
                {
                    return RESET_KEY2; // ← Retorna que precisa trocar senha
                }
            }
        }
        return string.Empty;
    }

    [Authorize]
    public async Task<bool> SetPassword(int id, string password, string uri)
    {
        return await ExecuteWithMetrics("SetPassword", async () =>
        {
            if (string.IsNullOrEmpty(uri)) throw new ArgumentNullException(nameof(uri));
            if (string.IsNullOrEmpty(password)) throw new ArgumentNullException(nameof(password));

            if (!Uris.ValidaUri(uri, _appSettings))
            {
                throw new Exception("User: URI inválida");
            }

            using var scope = Configuracoes.CreateConnectionScopeRw(uri);
            var oCnn = scope.Connection;
            if (oCnn == null) return false;


            var dbRec = await _reader.ReadM(id, oCnn);
            if (dbRec == null)
            {
                _logger.Warn("SetPassword: dbRec é nulo para o ID {Id}", id);
                return false;
            }

            if (dbRec.Id <= 0 || !dbRec.Situacao || dbRec.Excluido) return false;

            dbRec.Senha256 = password.GetHashCode2();

            var result = await _operService.AddAndUpdate(dbRec, uri);

            return result != null && result.Id > 0;

        });
    }
    public async Task<AuthenticateResponse?> ResetSenha(AuthenticateRequest model, [FromRoute] string uri)
    {
        return await ExecuteWithMetrics("ResetSenha", async () =>
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            if (string.IsNullOrEmpty(uri)) throw new ArgumentNullException(nameof(uri));

            if (!Uris.ValidaUri(uri, _appSettings))
            {
                _logger.Warn("ResetSenha: URI não é valida {Uri}", uri);
                throw new Exception("User: URI inválida");
            }

            using var scope = Configuracoes.CreateConnectionScopeRw(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                _logger.Warn("ResetSenha: Conexão nula");
                return null;
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

            var resultReset = await Task.Run(() => _reader.Read(cWhereReset, parametersReset, oCnn))
                .ConfigureAwait(false);

            if (resultReset?.Id > 0)
            {
                var dbU = await _operadorFactory.CreateFromIdAsync(resultReset.Id, oCnn);
                var guidReset = Guid.NewGuid().ToString().Replace("-", "");

                if (!string.IsNullOrEmpty(guidReset))
                {
                    dbU.WriteCfgC(RESET_KEY2, guidReset, oCnn);
                    dbU.WriteCfgC(RESET_KEY_ACTION, "", oCnn);
                    // dbU.FStatusMessage = "";
                    //dbU.Update(oCnn);

                    var token = await GenerateJwtToken(resultReset).ConfigureAwait(false);
                    var token64 = Convert.ToBase64String(Encoding.ASCII.GetBytes(token));

                    var send = new SendEmailApi();
                    _ = send.Send(new MenphisSI.Api.Models.SendEmail
                    {
                        ParaEmail = dbU.FEMailNet!,
                        ParaNome = dbU.FNome!,
                        Assunto = "RESET DE SENHA",
                        Mensagem = @$"<h1>Reset de Senha</h1>
            
            <p style='color: #fff'>Sua senha foi resetada com sucesso. Use este código no lugar da senha ao fazer login:</p>
            
            <div class=""code-box"">
                <strong>{guidReset}</strong>
            </div>
            
            <p class=""alert"">Se não foi você que solicitou o reset, por favor, ignore este e-mail.</p>",
                        NomeDoMail = "MENPHIS - SISTEMAS INTELIGENTES",
                        Time2Live = 1
                    });

                    return new AuthenticateResponse(resultReset, token64, RESET_KEY2, uri);
                }
            }

            return null;
        });
    }

    public async Task<AuthenticateResponse?> ChangePassword(AuthenticateRequest model, [FromRoute] string uri)
    {
        return await ExecuteWithMetrics<AuthenticateResponse?>("ChangePassword", async () =>
        {
            ArgumentNullException.ThrowIfNull(model);
            if (string.IsNullOrEmpty(uri)) throw new ArgumentNullException(nameof(uri));

            if (!Uris.ValidaUri(uri, _appSettings))
            {
                _logger.Warn("ChangePassword: URI não é valida {Uri}", uri);
                throw new Exception("User: URI inválida");
            }

            using var scope = Configuracoes.CreateConnectionScopeRw(uri);
            var oCnn = scope.Connection;
            if (oCnn == null)
            {
                _logger.Warn("ChangePassword: Conexão nula");
                return null;
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
                var dbU = await _reader.ReadM(resultReset.Id, oCnn);
                if (dbU == null)
                {                    
                    _logger.Warn("SetPassword: dbU é nulo para o ID {Id}", resultReset.Id);
                    return null;
                }

                if (dbU.Id <= 0 || !dbU.Situacao || dbU.Excluido) return null;

                if (dbU != null)
                {
                    var senhasIguais = dbU.Senha256?.Equals(model.CurrentPassword.DecodeBase64().GetHashCode2()) ?? false;
                    var senhaAntigaValida = !model.ValidCurrentPassword || senhasIguais;

                    if (dbU.Senha256 != null && senhaAntigaValida)
                    {
                        dbU.Senha256 = model.Password.DecodeBase64().GetHashCode2();

                        _ = await _operService.AddAndUpdate(dbU, uri);

                        return new AuthenticateResponse(resultReset, "", "", uri);
                    }
                    else
                    {
                        _logger.Warn("ChangePassword: Senha atual não confere");
                        return null;
                    }

                }
            }

            return null;
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

    ~UserService()
    {
        Dispose(false);
    }
}