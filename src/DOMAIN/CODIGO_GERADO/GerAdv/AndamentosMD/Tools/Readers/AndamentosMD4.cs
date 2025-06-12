#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAndamentosMDReader
{
    AndamentosMDResponse? Read(int id, MsiSqlConnection oCnn);
    AndamentosMDResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    AndamentosMDResponse? Read(Entity.DBAndamentosMD dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    AndamentosMDResponse? Read(DBAndamentosMD dbRec);
    AndamentosMDResponseAll? ReadAll(DBAndamentosMD dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class AndamentosMD : IAndamentosMDReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max = 200, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) amdCodigo, amdNome FROM {"AndamentosMD".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}amdNome");
        }

        return query.ToString();
    }

    public AndamentosMDResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAndamentosMD(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AndamentosMDResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAndamentosMD(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AndamentosMDResponse? Read(Entity.DBAndamentosMD dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var andamentosmd = new AndamentosMDResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Processo = dbRec.FProcesso,
            Andamento = dbRec.FAndamento,
            PathFull = dbRec.FPathFull ?? string.Empty,
            UNC = dbRec.FUNC ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return andamentosmd;
    }

    public AndamentosMDResponse? Read(DBAndamentosMD dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var andamentosmd = new AndamentosMDResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Processo = dbRec.FProcesso,
            Andamento = dbRec.FAndamento,
            PathFull = dbRec.FPathFull ?? string.Empty,
            UNC = dbRec.FUNC ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return andamentosmd;
    }

    public AndamentosMDResponseAll? ReadAll(DBAndamentosMD dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var andamentosmd = new AndamentosMDResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Processo = dbRec.FProcesso,
            Andamento = dbRec.FAndamento,
            PathFull = dbRec.FPathFull ?? string.Empty,
            UNC = dbRec.FUNC ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        andamentosmd.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return andamentosmd;
    }
}