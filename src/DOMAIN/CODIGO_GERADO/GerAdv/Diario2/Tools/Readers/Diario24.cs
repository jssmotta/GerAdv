#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IDiario2Reader
{
    Diario2Response? Read(int id, MsiSqlConnection oCnn);
    Diario2Response? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    Diario2Response? Read(Entity.DBDiario2 dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    Diario2Response? Read(DBDiario2 dbRec);
    Diario2ResponseAll? ReadAll(DBDiario2 dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Diario2 : IDiario2Reader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) diaCodigo, diaNome FROM {"Diario2".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}diaNome");
        }

        return query.ToString();
    }

    public Diario2Response? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBDiario2(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public Diario2Response? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBDiario2(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public Diario2Response? Read(Entity.DBDiario2 dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var diario2 = new Diario2Response
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Nome = dbRec.FNome ?? string.Empty,
            Ocorrencia = dbRec.FOcorrencia ?? string.Empty,
            Cliente = dbRec.FCliente,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            diario2.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FHora, out _))
            diario2.Hora = dbRec.FHora;
        return diario2;
    }

    public Diario2Response? Read(DBDiario2 dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var diario2 = new Diario2Response
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Nome = dbRec.FNome ?? string.Empty,
            Ocorrencia = dbRec.FOcorrencia ?? string.Empty,
            Cliente = dbRec.FCliente,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            diario2.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FHora, out _))
            diario2.Hora = dbRec.FHora;
        return diario2;
    }

    public Diario2ResponseAll? ReadAll(DBDiario2 dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var diario2 = new Diario2ResponseAll
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Nome = dbRec.FNome ?? string.Empty,
            Ocorrencia = dbRec.FOcorrencia ?? string.Empty,
            Cliente = dbRec.FCliente,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            diario2.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FHora, out _))
            diario2.Hora = dbRec.FHora;
        diario2.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        diario2.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        return diario2;
    }
}