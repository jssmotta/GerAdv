#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPoderJudiciarioAssociadoReader
{
    PoderJudiciarioAssociadoResponse? Read(int id, MsiSqlConnection oCnn);
    PoderJudiciarioAssociadoResponse? Read(Entity.DBPoderJudiciarioAssociado dbRec, MsiSqlConnection oCnn);
    PoderJudiciarioAssociadoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    PoderJudiciarioAssociadoResponse? Read(Entity.DBPoderJudiciarioAssociado dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    PoderJudiciarioAssociadoResponse? Read(DBPoderJudiciarioAssociado dbRec);
    PoderJudiciarioAssociadoResponseAll? ReadAll(DBPoderJudiciarioAssociado dbRec, DataRow dr);
    PoderJudiciarioAssociadoResponseAll? ReadAll(DBPoderJudiciarioAssociado dbRec, SqlDataReader dr);
    IEnumerable<PoderJudiciarioAssociadoResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class PoderJudiciarioAssociado : IPoderJudiciarioAssociadoReader
{
    public IEnumerable<PoderJudiciarioAssociadoResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<PoderJudiciarioAssociadoResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<PoderJudiciarioAssociadoResponseAll>> ReadLocalAsync()
        {
            var result = new List<PoderJudiciarioAssociadoResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBPoderJudiciarioAssociado(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"PoderJudiciarioAssociado".dbo(oCnn)} (NOLOCK) ");
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

    public PoderJudiciarioAssociadoResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPoderJudiciarioAssociado(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public PoderJudiciarioAssociadoResponse? Read(Entity.DBPoderJudiciarioAssociado dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public PoderJudiciarioAssociadoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPoderJudiciarioAssociado(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public PoderJudiciarioAssociadoResponse? Read(Entity.DBPoderJudiciarioAssociado dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var poderjudiciarioassociado = new PoderJudiciarioAssociadoResponse
        {
            Id = dbRec.ID,
            Justica = dbRec.FJustica,
            JusticaNome = dbRec.FJusticaNome ?? string.Empty,
            Area = dbRec.FArea,
            AreaNome = dbRec.FAreaNome ?? string.Empty,
            Tribunal = dbRec.FTribunal,
            TribunalNome = dbRec.FTribunalNome ?? string.Empty,
            Foro = dbRec.FForo,
            ForoNome = dbRec.FForoNome ?? string.Empty,
            Cidade = dbRec.FCidade,
            SubDivisaoNome = dbRec.FSubDivisaoNome ?? string.Empty,
            CidadeNome = dbRec.FCidadeNome ?? string.Empty,
            SubDivisao = dbRec.FSubDivisao,
            Tipo = dbRec.FTipo,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return poderjudiciarioassociado;
    }

    public PoderJudiciarioAssociadoResponse? Read(DBPoderJudiciarioAssociado dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var poderjudiciarioassociado = new PoderJudiciarioAssociadoResponse
        {
            Id = dbRec.ID,
            Justica = dbRec.FJustica,
            JusticaNome = dbRec.FJusticaNome ?? string.Empty,
            Area = dbRec.FArea,
            AreaNome = dbRec.FAreaNome ?? string.Empty,
            Tribunal = dbRec.FTribunal,
            TribunalNome = dbRec.FTribunalNome ?? string.Empty,
            Foro = dbRec.FForo,
            ForoNome = dbRec.FForoNome ?? string.Empty,
            Cidade = dbRec.FCidade,
            SubDivisaoNome = dbRec.FSubDivisaoNome ?? string.Empty,
            CidadeNome = dbRec.FCidadeNome ?? string.Empty,
            SubDivisao = dbRec.FSubDivisao,
            Tipo = dbRec.FTipo,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return poderjudiciarioassociado;
    }

    public PoderJudiciarioAssociadoResponseAll? ReadAll(DBPoderJudiciarioAssociado dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var poderjudiciarioassociado = new PoderJudiciarioAssociadoResponseAll
        {
            Id = dbRec.ID,
            Justica = dbRec.FJustica,
            JusticaNome = dbRec.FJusticaNome ?? string.Empty,
            Area = dbRec.FArea,
            AreaNome = dbRec.FAreaNome ?? string.Empty,
            Tribunal = dbRec.FTribunal,
            TribunalNome = dbRec.FTribunalNome ?? string.Empty,
            Foro = dbRec.FForo,
            ForoNome = dbRec.FForoNome ?? string.Empty,
            Cidade = dbRec.FCidade,
            SubDivisaoNome = dbRec.FSubDivisaoNome ?? string.Empty,
            CidadeNome = dbRec.FCidadeNome ?? string.Empty,
            SubDivisao = dbRec.FSubDivisao,
            Tipo = dbRec.FTipo,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        poderjudiciarioassociado.NomeJustica = dr["jusNome"]?.ToString() ?? string.Empty;
        poderjudiciarioassociado.DescricaoArea = dr["areDescricao"]?.ToString() ?? string.Empty;
        poderjudiciarioassociado.NomeTribunal = dr["triNome"]?.ToString() ?? string.Empty;
        poderjudiciarioassociado.NomeForo = dr["forNome"]?.ToString() ?? string.Empty;
        poderjudiciarioassociado.NomeCidade = dr["cidNome"]?.ToString() ?? string.Empty;
        return poderjudiciarioassociado;
    }

    public PoderJudiciarioAssociadoResponseAll? ReadAll(DBPoderJudiciarioAssociado dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var poderjudiciarioassociado = new PoderJudiciarioAssociadoResponseAll
        {
            Id = dbRec.ID,
            Justica = dbRec.FJustica,
            JusticaNome = dbRec.FJusticaNome ?? string.Empty,
            Area = dbRec.FArea,
            AreaNome = dbRec.FAreaNome ?? string.Empty,
            Tribunal = dbRec.FTribunal,
            TribunalNome = dbRec.FTribunalNome ?? string.Empty,
            Foro = dbRec.FForo,
            ForoNome = dbRec.FForoNome ?? string.Empty,
            Cidade = dbRec.FCidade,
            SubDivisaoNome = dbRec.FSubDivisaoNome ?? string.Empty,
            CidadeNome = dbRec.FCidadeNome ?? string.Empty,
            SubDivisao = dbRec.FSubDivisao,
            Tipo = dbRec.FTipo,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        poderjudiciarioassociado.NomeJustica = dr["jusNome"]?.ToString() ?? string.Empty;
        poderjudiciarioassociado.DescricaoArea = dr["areDescricao"]?.ToString() ?? string.Empty;
        poderjudiciarioassociado.NomeTribunal = dr["triNome"]?.ToString() ?? string.Empty;
        poderjudiciarioassociado.NomeForo = dr["forNome"]?.ToString() ?? string.Empty;
        poderjudiciarioassociado.NomeCidade = dr["cidNome"]?.ToString() ?? string.Empty;
        return poderjudiciarioassociado;
    }
}