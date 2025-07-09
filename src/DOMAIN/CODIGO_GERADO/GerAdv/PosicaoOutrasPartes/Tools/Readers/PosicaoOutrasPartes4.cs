#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPosicaoOutrasPartesReader
{
    PosicaoOutrasPartesResponse? Read(int id, MsiSqlConnection oCnn);
    PosicaoOutrasPartesResponse? Read(Entity.DBPosicaoOutrasPartes dbRec, MsiSqlConnection oCnn);
    PosicaoOutrasPartesResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    PosicaoOutrasPartesResponse? Read(Entity.DBPosicaoOutrasPartes dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    PosicaoOutrasPartesResponse? Read(DBPosicaoOutrasPartes dbRec);
    PosicaoOutrasPartesResponseAll? ReadAll(DBPosicaoOutrasPartes dbRec, DataRow dr);
    PosicaoOutrasPartesResponseAll? ReadAll(DBPosicaoOutrasPartes dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<PosicaoOutrasPartesResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class PosicaoOutrasPartes : IPosicaoOutrasPartesReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{posCodigo, posDescricao}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<PosicaoOutrasPartesResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<PosicaoOutrasPartesResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<PosicaoOutrasPartesResponseAll>> ReadLocalAsync()
        {
            var result = new List<PosicaoOutrasPartesResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBPosicaoOutrasPartes(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"PosicaoOutrasPartes".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}posDescricao");
        }

        return query.ToString();
    }

    public PosicaoOutrasPartesResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPosicaoOutrasPartes(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public PosicaoOutrasPartesResponse? Read(Entity.DBPosicaoOutrasPartes dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public PosicaoOutrasPartesResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPosicaoOutrasPartes(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public PosicaoOutrasPartesResponse? Read(Entity.DBPosicaoOutrasPartes dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var posicaooutraspartes = new PosicaoOutrasPartesResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return posicaooutraspartes;
    }

    public PosicaoOutrasPartesResponse? Read(DBPosicaoOutrasPartes dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var posicaooutraspartes = new PosicaoOutrasPartesResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return posicaooutraspartes;
    }

    public PosicaoOutrasPartesResponseAll? ReadAll(DBPosicaoOutrasPartes dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var posicaooutraspartes = new PosicaoOutrasPartesResponseAll
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return posicaooutraspartes;
    }

    public PosicaoOutrasPartesResponseAll? ReadAll(DBPosicaoOutrasPartes dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var posicaooutraspartes = new PosicaoOutrasPartesResponseAll
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return posicaooutraspartes;
    }
}