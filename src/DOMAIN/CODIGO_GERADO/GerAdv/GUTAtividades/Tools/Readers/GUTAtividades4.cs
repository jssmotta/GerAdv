#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGUTAtividadesReader
{
    GUTAtividadesResponse? Read(int id, MsiSqlConnection oCnn);
    GUTAtividadesResponse? Read(Entity.DBGUTAtividades dbRec, MsiSqlConnection oCnn);
    GUTAtividadesResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    GUTAtividadesResponse? Read(Entity.DBGUTAtividades dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    GUTAtividadesResponse? Read(DBGUTAtividades dbRec);
    GUTAtividadesResponseAll? ReadAll(DBGUTAtividades dbRec, DataRow dr);
    GUTAtividadesResponseAll? ReadAll(DBGUTAtividades dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<GUTAtividadesResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class GUTAtividades : IGUTAtividadesReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{agtCodigo, agtNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<GUTAtividadesResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<GUTAtividadesResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<GUTAtividadesResponseAll>> ReadLocalAsync()
        {
            var result = new List<GUTAtividadesResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBGUTAtividades(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"GUTAtividades".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}agtNome");
        }

        return query.ToString();
    }

    public GUTAtividadesResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGUTAtividades(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public GUTAtividadesResponse? Read(Entity.DBGUTAtividades dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public GUTAtividadesResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGUTAtividades(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public GUTAtividadesResponse? Read(Entity.DBGUTAtividades dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gutatividades = new GUTAtividadesResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Observacao = dbRec.FObservacao ?? string.Empty,
            GUTGrupo = dbRec.FGUTGrupo,
            GUTPeriodicidade = dbRec.FGUTPeriodicidade,
            Operador = dbRec.FOperador,
            Concluido = dbRec.FConcluido,
            DiasParaIniciar = dbRec.FDiasParaIniciar,
            MinutosParaRealizar = dbRec.FMinutosParaRealizar,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataConcluido, out _))
            gutatividades.DataConcluido = dbRec.FDataConcluido;
        return gutatividades;
    }

    public GUTAtividadesResponse? Read(DBGUTAtividades dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gutatividades = new GUTAtividadesResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Observacao = dbRec.FObservacao ?? string.Empty,
            GUTGrupo = dbRec.FGUTGrupo,
            GUTPeriodicidade = dbRec.FGUTPeriodicidade,
            Operador = dbRec.FOperador,
            Concluido = dbRec.FConcluido,
            DiasParaIniciar = dbRec.FDiasParaIniciar,
            MinutosParaRealizar = dbRec.FMinutosParaRealizar,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataConcluido, out _))
            gutatividades.DataConcluido = dbRec.FDataConcluido;
        return gutatividades;
    }

    public GUTAtividadesResponseAll? ReadAll(DBGUTAtividades dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gutatividades = new GUTAtividadesResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Observacao = dbRec.FObservacao ?? string.Empty,
            GUTGrupo = dbRec.FGUTGrupo,
            GUTPeriodicidade = dbRec.FGUTPeriodicidade,
            Operador = dbRec.FOperador,
            Concluido = dbRec.FConcluido,
            DiasParaIniciar = dbRec.FDiasParaIniciar,
            MinutosParaRealizar = dbRec.FMinutosParaRealizar,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataConcluido, out _))
            gutatividades.DataConcluido = dbRec.FDataConcluido;
        gutatividades.NomeGUTPeriodicidade = dr["pcgNome"]?.ToString() ?? string.Empty;
        gutatividades.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        return gutatividades;
    }

    public GUTAtividadesResponseAll? ReadAll(DBGUTAtividades dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gutatividades = new GUTAtividadesResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Observacao = dbRec.FObservacao ?? string.Empty,
            GUTGrupo = dbRec.FGUTGrupo,
            GUTPeriodicidade = dbRec.FGUTPeriodicidade,
            Operador = dbRec.FOperador,
            Concluido = dbRec.FConcluido,
            DiasParaIniciar = dbRec.FDiasParaIniciar,
            MinutosParaRealizar = dbRec.FMinutosParaRealizar,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataConcluido, out _))
            gutatividades.DataConcluido = dbRec.FDataConcluido;
        gutatividades.NomeGUTPeriodicidade = dr["pcgNome"]?.ToString() ?? string.Empty;
        gutatividades.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        return gutatividades;
    }
}