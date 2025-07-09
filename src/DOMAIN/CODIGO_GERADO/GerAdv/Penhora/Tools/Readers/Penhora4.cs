#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPenhoraReader
{
    PenhoraResponse? Read(int id, MsiSqlConnection oCnn);
    PenhoraResponse? Read(Entity.DBPenhora dbRec, MsiSqlConnection oCnn);
    PenhoraResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    PenhoraResponse? Read(Entity.DBPenhora dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    PenhoraResponse? Read(DBPenhora dbRec);
    PenhoraResponseAll? ReadAll(DBPenhora dbRec, DataRow dr);
    PenhoraResponseAll? ReadAll(DBPenhora dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<PenhoraResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Penhora : IPenhoraReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{phrCodigo, phrNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<PenhoraResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<PenhoraResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<PenhoraResponseAll>> ReadLocalAsync()
        {
            var result = new List<PenhoraResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBPenhora(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"Penhora".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}phrNome");
        }

        return query.ToString();
    }

    public PenhoraResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPenhora(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public PenhoraResponse? Read(Entity.DBPenhora dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public PenhoraResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPenhora(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public PenhoraResponse? Read(Entity.DBPenhora dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var penhora = new PenhoraResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Nome = dbRec.FNome ?? string.Empty,
            Descricao = dbRec.FDescricao ?? string.Empty,
            PenhoraStatus = dbRec.FPenhoraStatus,
            Master = dbRec.FMaster,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataPenhora, out _))
            penhora.DataPenhora = dbRec.FDataPenhora;
        return penhora;
    }

    public PenhoraResponse? Read(DBPenhora dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var penhora = new PenhoraResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Nome = dbRec.FNome ?? string.Empty,
            Descricao = dbRec.FDescricao ?? string.Empty,
            PenhoraStatus = dbRec.FPenhoraStatus,
            Master = dbRec.FMaster,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataPenhora, out _))
            penhora.DataPenhora = dbRec.FDataPenhora;
        return penhora;
    }

    public PenhoraResponseAll? ReadAll(DBPenhora dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var penhora = new PenhoraResponseAll
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Nome = dbRec.FNome ?? string.Empty,
            Descricao = dbRec.FDescricao ?? string.Empty,
            PenhoraStatus = dbRec.FPenhoraStatus,
            Master = dbRec.FMaster,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataPenhora, out _))
            penhora.DataPenhora = dbRec.FDataPenhora;
        penhora.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        penhora.NomePenhoraStatus = dr["phsNome"]?.ToString() ?? string.Empty;
        return penhora;
    }

    public PenhoraResponseAll? ReadAll(DBPenhora dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var penhora = new PenhoraResponseAll
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Nome = dbRec.FNome ?? string.Empty,
            Descricao = dbRec.FDescricao ?? string.Empty,
            PenhoraStatus = dbRec.FPenhoraStatus,
            Master = dbRec.FMaster,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataPenhora, out _))
            penhora.DataPenhora = dbRec.FDataPenhora;
        penhora.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        penhora.NomePenhoraStatus = dr["phsNome"]?.ToString() ?? string.Empty;
        return penhora;
    }
}