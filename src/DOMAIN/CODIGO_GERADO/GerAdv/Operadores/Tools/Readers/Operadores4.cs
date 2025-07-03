#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOperadoresReader
{
    OperadoresResponse? Read(int id, MsiSqlConnection oCnn);
    OperadoresResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    OperadoresResponse? Read(Entity.DBOperadores dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    OperadoresResponse? Read(DBOperadores dbRec);
    OperadoresResponseAll? ReadAll(DBOperadores dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Operadores : IOperadoresReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) operCodigo, operNome FROM {"Operadores".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}operNome");
        }

        return query.ToString();
    }

    public OperadoresResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOperadores(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public OperadoresResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOperadores(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public OperadoresResponse? Read(Entity.DBOperadores dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadores = new OperadoresResponse
        {
            Id = dbRec.ID,
            Enviado = dbRec.FEnviado,
            Casa = dbRec.FCasa,
            CasaID = dbRec.FCasaID,
            CasaCodigo = dbRec.FCasaCodigo,
            IsNovo = dbRec.FIsNovo,
            Cliente = dbRec.FCliente,
            Grupo = dbRec.FGrupo,
            Nome = dbRec.FNome ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Ativado = dbRec.FAtivado,
        };
        if (DateTime.TryParse(dbRec.FSuporteMaxAge, out _))
            operadores.SuporteMaxAge = dbRec.FSuporteMaxAge;
        return operadores;
    }

    public OperadoresResponse? Read(DBOperadores dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadores = new OperadoresResponse
        {
            Id = dbRec.ID,
            Enviado = dbRec.FEnviado,
            Casa = dbRec.FCasa,
            CasaID = dbRec.FCasaID,
            CasaCodigo = dbRec.FCasaCodigo,
            IsNovo = dbRec.FIsNovo,
            Cliente = dbRec.FCliente,
            Grupo = dbRec.FGrupo,
            Nome = dbRec.FNome ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Ativado = dbRec.FAtivado,
        };
        if (DateTime.TryParse(dbRec.FSuporteMaxAge, out _))
            operadores.SuporteMaxAge = dbRec.FSuporteMaxAge;
        return operadores;
    }

    public OperadoresResponseAll? ReadAll(DBOperadores dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadores = new OperadoresResponseAll
        {
            Id = dbRec.ID,
            Enviado = dbRec.FEnviado,
            Casa = dbRec.FCasa,
            CasaID = dbRec.FCasaID,
            CasaCodigo = dbRec.FCasaCodigo,
            IsNovo = dbRec.FIsNovo,
            Cliente = dbRec.FCliente,
            Grupo = dbRec.FGrupo,
            Nome = dbRec.FNome ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Ativado = dbRec.FAtivado,
        };
        if (DateTime.TryParse(dbRec.FSuporteMaxAge, out _))
            operadores.SuporteMaxAge = dbRec.FSuporteMaxAge;
        operadores.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        return operadores;
    }
}