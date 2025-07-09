#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAreasJusticaReader
{
    AreasJusticaResponse? Read(int id, MsiSqlConnection oCnn);
    AreasJusticaResponse? Read(Entity.DBAreasJustica dbRec, MsiSqlConnection oCnn);
    AreasJusticaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    AreasJusticaResponse? Read(Entity.DBAreasJustica dbRec);
    AreasJusticaResponse? Read(DBAreasJustica dbRec);
    AreasJusticaResponseAll? ReadAll(DBAreasJustica dbRec, DataRow dr);
    AreasJusticaResponseAll? ReadAll(DBAreasJustica dbRec, SqlDataReader dr);
    IEnumerable<AreasJusticaResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class AreasJustica : IAreasJusticaReader
{
    public IEnumerable<AreasJusticaResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<AreasJusticaResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<AreasJusticaResponseAll>> ReadLocalAsync()
        {
            var result = new List<AreasJusticaResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBAreasJustica(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"AreasJustica".dbo(oCnn)} (NOLOCK) ");
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

    public AreasJusticaResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAreasJustica(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AreasJusticaResponse? Read(Entity.DBAreasJustica dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public AreasJusticaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAreasJustica(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AreasJusticaResponse? Read(Entity.DBAreasJustica dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var areasjustica = new AreasJusticaResponse
        {
            Id = dbRec.ID,
            Area = dbRec.FArea,
            Justica = dbRec.FJustica,
        };
        return areasjustica;
    }

    public AreasJusticaResponse? Read(DBAreasJustica dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var areasjustica = new AreasJusticaResponse
        {
            Id = dbRec.ID,
            Area = dbRec.FArea,
            Justica = dbRec.FJustica,
        };
        return areasjustica;
    }

    public AreasJusticaResponseAll? ReadAll(DBAreasJustica dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var areasjustica = new AreasJusticaResponseAll
        {
            Id = dbRec.ID,
            Area = dbRec.FArea,
            Justica = dbRec.FJustica,
        };
        areasjustica.DescricaoArea = dr["areDescricao"]?.ToString() ?? string.Empty;
        areasjustica.NomeJustica = dr["jusNome"]?.ToString() ?? string.Empty;
        return areasjustica;
    }

    public AreasJusticaResponseAll? ReadAll(DBAreasJustica dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var areasjustica = new AreasJusticaResponseAll
        {
            Id = dbRec.ID,
            Area = dbRec.FArea,
            Justica = dbRec.FJustica,
        };
        areasjustica.DescricaoArea = dr["areDescricao"]?.ToString() ?? string.Empty;
        areasjustica.NomeJustica = dr["jusNome"]?.ToString() ?? string.Empty;
        return areasjustica;
    }
}