#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOperadorGruposAgendaReader
{
    OperadorGruposAgendaResponse? Read(int id, MsiSqlConnection oCnn);
    OperadorGruposAgendaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    OperadorGruposAgendaResponse? Read(Entity.DBOperadorGruposAgenda dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    OperadorGruposAgendaResponse? Read(DBOperadorGruposAgenda dbRec);
    OperadorGruposAgendaResponseAll? ReadAll(DBOperadorGruposAgenda dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class OperadorGruposAgenda : IOperadorGruposAgendaReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) groCodigo, groNome FROM {"OperadorGruposAgenda".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}groNome");
        }

        return query.ToString();
    }

    public OperadorGruposAgendaResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOperadorGruposAgenda(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public OperadorGruposAgendaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOperadorGruposAgenda(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public OperadorGruposAgendaResponse? Read(Entity.DBOperadorGruposAgenda dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadorgruposagenda = new OperadorGruposAgendaResponse
        {
            Id = dbRec.ID,
            SQLWhere = dbRec.FSQLWhere ?? string.Empty,
            Nome = dbRec.FNome ?? string.Empty,
            Operador = dbRec.FOperador,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return operadorgruposagenda;
    }

    public OperadorGruposAgendaResponse? Read(DBOperadorGruposAgenda dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadorgruposagenda = new OperadorGruposAgendaResponse
        {
            Id = dbRec.ID,
            SQLWhere = dbRec.FSQLWhere ?? string.Empty,
            Nome = dbRec.FNome ?? string.Empty,
            Operador = dbRec.FOperador,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return operadorgruposagenda;
    }

    public OperadorGruposAgendaResponseAll? ReadAll(DBOperadorGruposAgenda dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadorgruposagenda = new OperadorGruposAgendaResponseAll
        {
            Id = dbRec.ID,
            SQLWhere = dbRec.FSQLWhere ?? string.Empty,
            Nome = dbRec.FNome ?? string.Empty,
            Operador = dbRec.FOperador,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        operadorgruposagenda.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        return operadorgruposagenda;
    }
}