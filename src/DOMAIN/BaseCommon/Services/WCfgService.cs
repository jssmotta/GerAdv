namespace MenphisSI.BaseCommon;

public class WCfgService : IWCfgService
{
    private readonly AppSettings _appSettings;
    private readonly string _uris;

    public WCfgService(IOptions<AppSettings> appSettings, IHttpContextAccessor httpContextAccessor)
    {
        _appSettings = appSettings.Value;
        _uris = _appSettings.ValidUris;
    }

    private void ValidateUri(string uri, string operation)
    {
        if (!Uris.ValidaUri(uri, _uris))
        {
            throw new Exception($"WCfg {operation}: URI inválida");
        }
    }

    public async Task<bool> DeleteCfq(string key, [FromRoute] string uri)
    {
        ValidateUri(uri, "Delete Cfg");
        return await Configuracoes.UseConnectionAsync(uri,
            conn => Task.FromResult(ConfigSys.DeleteKeyCfgSys(key, conn)),
            readOnly: false);
    }

    public async Task<bool> DeleteCfq(string key, int oper, [FromRoute] string uri)
    {
        ValidateUri(uri, "Delete Cfg");
        return await Configuracoes.UseConnectionAsync(uri,
            conn => Task.FromResult(ConfigSys.DeleteKeyCfgSys(key, oper, conn)),
            readOnly: false);
    }

    public async Task SetCfq(string key, int value, [FromRoute] string uri)
    {
        ValidateUri(uri, "SetCfq");
        await Configuracoes.UseConnectionAsync(uri,
            conn => Task.FromResult(ConfigSys.WriteCfgSys(key, value, conn)),
            readOnly: false);
    }

    public async Task SetCfqC(string key, string value, [FromRoute] string uri)
    {
        ValidateUri(uri, "SetCfqC");
        await Configuracoes.UseConnectionAsync(uri,
            conn => Task.FromResult(ConfigSys.WriteCfgSysC(key, value, conn)),
            readOnly: false);
    }

    public async Task SetCfqMemo(string key, string value, [FromRoute] string uri)
    {
        ValidateUri(uri, "SetCfqMemo");
        await Configuracoes.UseConnectionAsync(uri,
            conn => Task.FromResult(ConfigSys.WriteCfgSysMemo(key, value, conn)),
            readOnly: false);
    }



    public async Task SetCfqC(string key, int oper, string value, [FromRoute] string uri)
    {
        ValidateUri(uri, "SetCfqC");
        await Configuracoes.UseConnectionAsync(uri,
            conn => Task.FromResult(ConfigSys.WriteCfgSysC(key, oper, value, conn)),
            readOnly: false);
    }

    public async Task SetCfqMemo(string key, int oper, string value, [FromRoute] string uri)
    {
        ValidateUri(uri, "SetCfqMemo");
        await Configuracoes.UseConnectionAsync<bool>(uri,
            async conn => {
                ConfigSys.WriteCfgSysMemo(key, oper, value, conn);
                return true;
            },
            readOnly: false);
    }

    public async Task SetTCfq(int id, string key, int value, [FromRoute] string uri)
    {
        ValidateUri(uri, "SetTCfq");
        await Configuracoes.UseConnectionAsync<bool>(uri,
            async conn => {
                ConfigSys.WriteCfgSys(key, id, value, conn);
                return true;
            },
            readOnly: false);
    }

    public async Task SetTCfqMemo(int id, string key, string value, [FromRoute] string uri)
    {
        ValidateUri(uri, "SetTCfqMemo");
        await Configuracoes.UseConnectionAsync<bool>(uri,
            async conn => {
                ConfigSys.WriteCfgSysMemo(key, id, value, conn);
                return true;
            },
            readOnly: false);
    }

    public async Task SetCfq(string key, int oper, int value, [FromRoute] string uri)
    {
        ValidateUri(uri, "SetCfq");
        await Configuracoes.UseConnectionAsync<bool>(uri,
            async conn => { 
                ConfigSys.WriteCfgSys(key, oper, value, conn);
                return true;
            },
            readOnly: false);
    }

    public async Task SetTCfqC(int id, string key, string value, [FromRoute] string uri)
    {
        ValidateUri(uri, "SetTCfqC");
        await Configuracoes.UseConnectionAsync(uri,
            conn => Task.FromResult(ConfigSys.WriteCfgSysC(key, id, value, conn)),
            readOnly: false);
    }

    public async Task<int> GetCfq(string key, [FromRoute] string uri)
    {
        ValidateUri(uri, "GetCfq");
        return await Configuracoes.UseConnectionAsync(uri,
            conn => Task.FromResult(ConfigSys.ReadCfgSys(key, conn)));
    }

    public async Task<string> GetCfqC(string key, [FromRoute] string uri)
    {
        ValidateUri(uri, "GetCfqC");
        return await Configuracoes.UseConnectionAsync(uri,
            conn => Task.FromResult(ConfigSys.ReadCfgSysC(key, conn)));
    }

    public async Task<string> GetCfqMemo(string key, [FromRoute] string uri)
    {
        ValidateUri(uri, "GetCfqMemo");
        return await Configuracoes.UseConnectionAsync(uri,
            conn => Task.FromResult(ConfigSys.ReadCfgSysMemo(key, conn)));
    }

    public async Task<int> GetCfq(string key, int oper, [FromRoute] string uri)
    {
        ValidateUri(uri, "GetCfq");
        return await Configuracoes.UseConnectionAsync(uri,
            conn => Task.FromResult(ConfigSys.ReadCfgSys(key, oper, conn)));
    }

    public async Task<string> GetCfqC(string key, int oper, [FromRoute] string uri)
    {
        ValidateUri(uri, "GetCfqC");
        return await Configuracoes.UseConnectionAsync(uri,
            conn => Task.FromResult(ConfigSys.ReadCfgSysC(key, oper, conn)));
    }

    public async Task<string> GetCfqMemo(string key, int oper, [FromRoute] string uri)
    {
        ValidateUri(uri, "GetCfqMemo");
        return await Configuracoes.UseConnectionAsync(uri,
            conn => Task.FromResult(ConfigSys.ReadCfgSysMemo(key, oper, conn)));
    }

    public async Task<int> GetTCfq(int id, string key, [FromRoute] string uri)
    {
        ValidateUri(uri, "GetTCfq");
        return await Configuracoes.UseConnectionAsync(uri,
            conn => Task.FromResult(ConfigSys.ReadCfgSys(key, id, conn)));
    }

    public async Task<string> GetTCfqC(int id, string key, [FromRoute] string uri)
    {
        ValidateUri(uri, "GetTCfqC");
        return await Configuracoes.UseConnectionAsync(uri,
            conn => Task.FromResult(ConfigSys.ReadCfgSysC(key, id, conn)));
    }

    public async Task<string> GetTCfqMemo(int id, string key, [FromRoute] string uri)
    {
        ValidateUri(uri, "GetTCfqMemo");
        return await Configuracoes.UseConnectionAsync(uri,
            conn => Task.FromResult(ConfigSys.ReadCfgSysMemo(key, id, conn)));
    }
}