#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IInstanciaReader
{
    InstanciaResponse? Read(int id, MsiSqlConnection oCnn);
    InstanciaResponse? Read(Entity.DBInstancia dbRec, MsiSqlConnection oCnn);
    InstanciaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    InstanciaResponse? Read(Entity.DBInstancia dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    InstanciaResponse? Read(DBInstancia dbRec);
    InstanciaResponseAll? ReadAll(DBInstancia dbRec, DataRow dr);
    InstanciaResponseAll? ReadAll(DBInstancia dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<InstanciaResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Instancia : IInstanciaReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{insCodigo, insNroProcesso}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<InstanciaResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<InstanciaResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<InstanciaResponseAll>> ReadLocalAsync()
        {
            var result = new List<InstanciaResponseAll>(max);
            await using var connection = Configuracoes.GetConnectionByUri(uri);
            await using var cmd = new SqlCommand(cmdText: ConfiguracoesDBT.CmdSql(sql), connection: connection?.InnerConnection)
            {
                CommandTimeout = 0
            };
            cmd.Parameters.AddRange([..parameters]);
            await using var reader = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult).ConfigureAwait(false);
            while (await reader.ReadAsync().ConfigureAwait(false))
            {
                if (await reader.IsDBNullAsync(1).ConfigureAwait(false))
                    continue;
                result.Add(ReadAll(new Entity.DBInstancia(reader), reader)!);
            }

            return result;
        }
    }

    static string BuildSqlQuery(string campos, string whereClause, string orderClause, int max, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"Instancia".dbo(oCnn)} (NOLOCK) ");
        if (!string.IsNullOrEmpty(whereClause))
        {
            query.Append(!whereClause.ToUpperInvariant().Contains(TSql.Where, StringComparison.OrdinalIgnoreCase) ? TSql.Where : string.Empty).Append(whereClause);
        }

        if (!string.IsNullOrEmpty(orderClause))
        {
            query.Append(!orderClause.ToUpperInvariant().Contains(TSql.OrderBy, StringComparison.OrdinalIgnoreCase) ? TSql.OrderBy : string.Empty).Append(orderClause);
        }
        else
        {
            query.Append($"{TSql.OrderBy}insNroProcesso");
        }

        return query.ToString();
    }

    public InstanciaResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBInstancia(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public InstanciaResponse? Read(Entity.DBInstancia dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public InstanciaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBInstancia(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public InstanciaResponse? Read(Entity.DBInstancia dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var instancia = new InstanciaResponse
        {
            Id = dbRec.ID,
            LiminarPedida = dbRec.FLiminarPedida ?? string.Empty,
            Objeto = dbRec.FObjeto ?? string.Empty,
            StatusResultado = dbRec.FStatusResultado,
            LiminarPendente = dbRec.FLiminarPendente,
            InterpusemosRecurso = dbRec.FInterpusemosRecurso,
            LiminarConcedida = dbRec.FLiminarConcedida,
            LiminarNegada = dbRec.FLiminarNegada,
            Processo = dbRec.FProcesso,
            LiminarParcial = dbRec.FLiminarParcial,
            LiminarResultado = dbRec.FLiminarResultado ?? string.Empty,
            NroProcesso = dbRec.FNroProcesso ?? string.Empty,
            Divisao = dbRec.FDivisao,
            LiminarCliente = dbRec.FLiminarCliente,
            Comarca = dbRec.FComarca,
            SubDivisao = dbRec.FSubDivisao,
            Principal = dbRec.FPrincipal,
            Acao = dbRec.FAcao,
            Foro = dbRec.FForo,
            TipoRecurso = dbRec.FTipoRecurso,
            ZKey = dbRec.FZKey ?? string.Empty,
            ZKeyQuem = dbRec.FZKeyQuem,
            NroAntigo = dbRec.FNroAntigo ?? string.Empty,
            AccessCode = dbRec.FAccessCode ?? string.Empty,
            Julgador = dbRec.FJulgador,
            ZKeyIA = dbRec.FZKeyIA ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            instancia.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FZKeyQuando, out _))
            instancia.ZKeyQuando = dbRec.FZKeyQuando;
        return instancia;
    }

    public InstanciaResponse? Read(DBInstancia dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var instancia = new InstanciaResponse
        {
            Id = dbRec.ID,
            LiminarPedida = dbRec.FLiminarPedida ?? string.Empty,
            Objeto = dbRec.FObjeto ?? string.Empty,
            StatusResultado = dbRec.FStatusResultado,
            LiminarPendente = dbRec.FLiminarPendente,
            InterpusemosRecurso = dbRec.FInterpusemosRecurso,
            LiminarConcedida = dbRec.FLiminarConcedida,
            LiminarNegada = dbRec.FLiminarNegada,
            Processo = dbRec.FProcesso,
            LiminarParcial = dbRec.FLiminarParcial,
            LiminarResultado = dbRec.FLiminarResultado ?? string.Empty,
            NroProcesso = dbRec.FNroProcesso ?? string.Empty,
            Divisao = dbRec.FDivisao,
            LiminarCliente = dbRec.FLiminarCliente,
            Comarca = dbRec.FComarca,
            SubDivisao = dbRec.FSubDivisao,
            Principal = dbRec.FPrincipal,
            Acao = dbRec.FAcao,
            Foro = dbRec.FForo,
            TipoRecurso = dbRec.FTipoRecurso,
            ZKey = dbRec.FZKey ?? string.Empty,
            ZKeyQuem = dbRec.FZKeyQuem,
            NroAntigo = dbRec.FNroAntigo ?? string.Empty,
            AccessCode = dbRec.FAccessCode ?? string.Empty,
            Julgador = dbRec.FJulgador,
            ZKeyIA = dbRec.FZKeyIA ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            instancia.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FZKeyQuando, out _))
            instancia.ZKeyQuando = dbRec.FZKeyQuando;
        return instancia;
    }

    public InstanciaResponseAll? ReadAll(DBInstancia dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var instancia = new InstanciaResponseAll
        {
            Id = dbRec.ID,
            LiminarPedida = dbRec.FLiminarPedida ?? string.Empty,
            Objeto = dbRec.FObjeto ?? string.Empty,
            StatusResultado = dbRec.FStatusResultado,
            LiminarPendente = dbRec.FLiminarPendente,
            InterpusemosRecurso = dbRec.FInterpusemosRecurso,
            LiminarConcedida = dbRec.FLiminarConcedida,
            LiminarNegada = dbRec.FLiminarNegada,
            Processo = dbRec.FProcesso,
            LiminarParcial = dbRec.FLiminarParcial,
            LiminarResultado = dbRec.FLiminarResultado ?? string.Empty,
            NroProcesso = dbRec.FNroProcesso ?? string.Empty,
            Divisao = dbRec.FDivisao,
            LiminarCliente = dbRec.FLiminarCliente,
            Comarca = dbRec.FComarca,
            SubDivisao = dbRec.FSubDivisao,
            Principal = dbRec.FPrincipal,
            Acao = dbRec.FAcao,
            Foro = dbRec.FForo,
            TipoRecurso = dbRec.FTipoRecurso,
            ZKey = dbRec.FZKey ?? string.Empty,
            ZKeyQuem = dbRec.FZKeyQuem,
            NroAntigo = dbRec.FNroAntigo ?? string.Empty,
            AccessCode = dbRec.FAccessCode ?? string.Empty,
            Julgador = dbRec.FJulgador,
            ZKeyIA = dbRec.FZKeyIA ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            instancia.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FZKeyQuando, out _))
            instancia.ZKeyQuando = dbRec.FZKeyQuando;
        instancia.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        instancia.DescricaoAcao = dr["acaDescricao"]?.ToString() ?? string.Empty;
        instancia.NomeForo = dr["forNome"]?.ToString() ?? string.Empty;
        instancia.DescricaoTipoRecurso = dr["trcDescricao"]?.ToString() ?? string.Empty;
        return instancia;
    }

    public InstanciaResponseAll? ReadAll(DBInstancia dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var instancia = new InstanciaResponseAll
        {
            Id = dbRec.ID,
            LiminarPedida = dbRec.FLiminarPedida ?? string.Empty,
            Objeto = dbRec.FObjeto ?? string.Empty,
            StatusResultado = dbRec.FStatusResultado,
            LiminarPendente = dbRec.FLiminarPendente,
            InterpusemosRecurso = dbRec.FInterpusemosRecurso,
            LiminarConcedida = dbRec.FLiminarConcedida,
            LiminarNegada = dbRec.FLiminarNegada,
            Processo = dbRec.FProcesso,
            LiminarParcial = dbRec.FLiminarParcial,
            LiminarResultado = dbRec.FLiminarResultado ?? string.Empty,
            NroProcesso = dbRec.FNroProcesso ?? string.Empty,
            Divisao = dbRec.FDivisao,
            LiminarCliente = dbRec.FLiminarCliente,
            Comarca = dbRec.FComarca,
            SubDivisao = dbRec.FSubDivisao,
            Principal = dbRec.FPrincipal,
            Acao = dbRec.FAcao,
            Foro = dbRec.FForo,
            TipoRecurso = dbRec.FTipoRecurso,
            ZKey = dbRec.FZKey ?? string.Empty,
            ZKeyQuem = dbRec.FZKeyQuem,
            NroAntigo = dbRec.FNroAntigo ?? string.Empty,
            AccessCode = dbRec.FAccessCode ?? string.Empty,
            Julgador = dbRec.FJulgador,
            ZKeyIA = dbRec.FZKeyIA ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            instancia.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FZKeyQuando, out _))
            instancia.ZKeyQuando = dbRec.FZKeyQuando;
        instancia.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        instancia.DescricaoAcao = dr["acaDescricao"]?.ToString() ?? string.Empty;
        instancia.NomeForo = dr["forNome"]?.ToString() ?? string.Empty;
        instancia.DescricaoTipoRecurso = dr["trcDescricao"]?.ToString() ?? string.Empty;
        return instancia;
    }
}