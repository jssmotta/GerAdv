#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITribunalReader
{
    TribunalResponse? Read(int id, MsiSqlConnection oCnn);
    TribunalResponse? Read(Entity.DBTribunal dbRec, MsiSqlConnection oCnn);
    TribunalResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    TribunalResponse? Read(Entity.DBTribunal dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    TribunalResponse? Read(DBTribunal dbRec);
    TribunalResponseAll? ReadAll(DBTribunal dbRec, DataRow dr);
    TribunalResponseAll? ReadAll(DBTribunal dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<TribunalResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Tribunal : ITribunalReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{triCodigo, triNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<TribunalResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<TribunalResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<TribunalResponseAll>> ReadLocalAsync()
        {
            var result = new List<TribunalResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBTribunal(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"Tribunal".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}triNome");
        }

        return query.ToString();
    }

    public TribunalResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTribunal(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TribunalResponse? Read(Entity.DBTribunal dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public TribunalResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTribunal(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TribunalResponse? Read(Entity.DBTribunal dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tribunal = new TribunalResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Area = dbRec.FArea,
            Justica = dbRec.FJustica,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Instancia = dbRec.FInstancia,
            Sigla = dbRec.FSigla ?? string.Empty,
            Web = dbRec.FWeb ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return tribunal;
    }

    public TribunalResponse? Read(DBTribunal dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tribunal = new TribunalResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Area = dbRec.FArea,
            Justica = dbRec.FJustica,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Instancia = dbRec.FInstancia,
            Sigla = dbRec.FSigla ?? string.Empty,
            Web = dbRec.FWeb ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return tribunal;
    }

    public TribunalResponseAll? ReadAll(DBTribunal dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tribunal = new TribunalResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Area = dbRec.FArea,
            Justica = dbRec.FJustica,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Instancia = dbRec.FInstancia,
            Sigla = dbRec.FSigla ?? string.Empty,
            Web = dbRec.FWeb ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        tribunal.DescricaoArea = dr["areDescricao"]?.ToString() ?? string.Empty;
        tribunal.NomeJustica = dr["jusNome"]?.ToString() ?? string.Empty;
        tribunal.NroProcessoInstancia = dr["insNroProcesso"]?.ToString() ?? string.Empty;
        return tribunal;
    }

    public TribunalResponseAll? ReadAll(DBTribunal dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tribunal = new TribunalResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Area = dbRec.FArea,
            Justica = dbRec.FJustica,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Instancia = dbRec.FInstancia,
            Sigla = dbRec.FSigla ?? string.Empty,
            Web = dbRec.FWeb ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        tribunal.DescricaoArea = dr["areDescricao"]?.ToString() ?? string.Empty;
        tribunal.NomeJustica = dr["jusNome"]?.ToString() ?? string.Empty;
        tribunal.NroProcessoInstancia = dr["insNroProcesso"]?.ToString() ?? string.Empty;
        return tribunal;
    }
}