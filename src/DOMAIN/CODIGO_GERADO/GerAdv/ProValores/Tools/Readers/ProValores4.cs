#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProValoresReader
{
    ProValoresResponse? Read(int id, MsiSqlConnection oCnn);
    ProValoresResponse? Read(Entity.DBProValores dbRec, MsiSqlConnection oCnn);
    ProValoresResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProValoresResponse? Read(Entity.DBProValores dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProValoresResponse? Read(DBProValores dbRec);
    ProValoresResponseAll? ReadAll(DBProValores dbRec, DataRow dr);
    ProValoresResponseAll? ReadAll(DBProValores dbRec, SqlDataReader dr);
    IEnumerable<ProValoresResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class ProValores : IProValoresReader
{
    public IEnumerable<ProValoresResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<ProValoresResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<ProValoresResponseAll>> ReadLocalAsync()
        {
            var result = new List<ProValoresResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBProValores(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"ProValores".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}");
        }

        return query.ToString();
    }

    public ProValoresResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProValores(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProValoresResponse? Read(Entity.DBProValores dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public ProValoresResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProValores(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProValoresResponse? Read(Entity.DBProValores dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var provalores = new ProValoresResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            TipoValorProcesso = dbRec.FTipoValorProcesso,
            Indice = dbRec.FIndice ?? string.Empty,
            Ignorar = dbRec.FIgnorar,
            ValorOriginal = dbRec.FValorOriginal,
            PercMulta = dbRec.FPercMulta,
            ValorMulta = dbRec.FValorMulta,
            PercJuros = dbRec.FPercJuros,
            ValorOriginalCorrigidoIndice = dbRec.FValorOriginalCorrigidoIndice,
            ValorMultaCorrigido = dbRec.FValorMultaCorrigido,
            ValorJurosCorrigido = dbRec.FValorJurosCorrigido,
            ValorFinal = dbRec.FValorFinal,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            provalores.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FDataUltimaCorrecao, out _))
            provalores.DataUltimaCorrecao = dbRec.FDataUltimaCorrecao;
        return provalores;
    }

    public ProValoresResponse? Read(DBProValores dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var provalores = new ProValoresResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            TipoValorProcesso = dbRec.FTipoValorProcesso,
            Indice = dbRec.FIndice ?? string.Empty,
            Ignorar = dbRec.FIgnorar,
            ValorOriginal = dbRec.FValorOriginal,
            PercMulta = dbRec.FPercMulta,
            ValorMulta = dbRec.FValorMulta,
            PercJuros = dbRec.FPercJuros,
            ValorOriginalCorrigidoIndice = dbRec.FValorOriginalCorrigidoIndice,
            ValorMultaCorrigido = dbRec.FValorMultaCorrigido,
            ValorJurosCorrigido = dbRec.FValorJurosCorrigido,
            ValorFinal = dbRec.FValorFinal,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            provalores.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FDataUltimaCorrecao, out _))
            provalores.DataUltimaCorrecao = dbRec.FDataUltimaCorrecao;
        return provalores;
    }

    public ProValoresResponseAll? ReadAll(DBProValores dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var provalores = new ProValoresResponseAll
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            TipoValorProcesso = dbRec.FTipoValorProcesso,
            Indice = dbRec.FIndice ?? string.Empty,
            Ignorar = dbRec.FIgnorar,
            ValorOriginal = dbRec.FValorOriginal,
            PercMulta = dbRec.FPercMulta,
            ValorMulta = dbRec.FValorMulta,
            PercJuros = dbRec.FPercJuros,
            ValorOriginalCorrigidoIndice = dbRec.FValorOriginalCorrigidoIndice,
            ValorMultaCorrigido = dbRec.FValorMultaCorrigido,
            ValorJurosCorrigido = dbRec.FValorJurosCorrigido,
            ValorFinal = dbRec.FValorFinal,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            provalores.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FDataUltimaCorrecao, out _))
            provalores.DataUltimaCorrecao = dbRec.FDataUltimaCorrecao;
        provalores.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        provalores.DescricaoTipoValorProcesso = dr["ptvDescricao"]?.ToString() ?? string.Empty;
        return provalores;
    }

    public ProValoresResponseAll? ReadAll(DBProValores dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var provalores = new ProValoresResponseAll
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            TipoValorProcesso = dbRec.FTipoValorProcesso,
            Indice = dbRec.FIndice ?? string.Empty,
            Ignorar = dbRec.FIgnorar,
            ValorOriginal = dbRec.FValorOriginal,
            PercMulta = dbRec.FPercMulta,
            ValorMulta = dbRec.FValorMulta,
            PercJuros = dbRec.FPercJuros,
            ValorOriginalCorrigidoIndice = dbRec.FValorOriginalCorrigidoIndice,
            ValorMultaCorrigido = dbRec.FValorMultaCorrigido,
            ValorJurosCorrigido = dbRec.FValorJurosCorrigido,
            ValorFinal = dbRec.FValorFinal,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            provalores.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FDataUltimaCorrecao, out _))
            provalores.DataUltimaCorrecao = dbRec.FDataUltimaCorrecao;
        provalores.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        provalores.DescricaoTipoValorProcesso = dr["ptvDescricao"]?.ToString() ?? string.Empty;
        return provalores;
    }
}