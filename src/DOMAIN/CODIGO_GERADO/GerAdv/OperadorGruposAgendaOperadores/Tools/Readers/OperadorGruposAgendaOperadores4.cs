#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOperadorGruposAgendaOperadoresReader
{
    OperadorGruposAgendaOperadoresResponse? Read(int id, MsiSqlConnection oCnn);
    OperadorGruposAgendaOperadoresResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    OperadorGruposAgendaOperadoresResponse? Read(Entity.DBOperadorGruposAgendaOperadores dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    OperadorGruposAgendaOperadoresResponse? Read(DBOperadorGruposAgendaOperadores dbRec);
    OperadorGruposAgendaOperadoresResponseAll? ReadAll(DBOperadorGruposAgendaOperadores dbRec, DataRow dr);
}

public partial class OperadorGruposAgendaOperadores : IOperadorGruposAgendaOperadoresReader
{
    public OperadorGruposAgendaOperadoresResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOperadorGruposAgendaOperadores(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public OperadorGruposAgendaOperadoresResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOperadorGruposAgendaOperadores(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public OperadorGruposAgendaOperadoresResponse? Read(Entity.DBOperadorGruposAgendaOperadores dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadorgruposagendaoperadores = new OperadorGruposAgendaOperadoresResponse
        {
            Id = dbRec.ID,
            OperadorGruposAgenda = dbRec.FOperadorGruposAgenda,
            Operador = dbRec.FOperador,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return operadorgruposagendaoperadores;
    }

    public OperadorGruposAgendaOperadoresResponse? Read(DBOperadorGruposAgendaOperadores dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadorgruposagendaoperadores = new OperadorGruposAgendaOperadoresResponse
        {
            Id = dbRec.ID,
            OperadorGruposAgenda = dbRec.FOperadorGruposAgenda,
            Operador = dbRec.FOperador,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return operadorgruposagendaoperadores;
    }

    public OperadorGruposAgendaOperadoresResponseAll? ReadAll(DBOperadorGruposAgendaOperadores dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadorgruposagendaoperadores = new OperadorGruposAgendaOperadoresResponseAll
        {
            Id = dbRec.ID,
            OperadorGruposAgenda = dbRec.FOperadorGruposAgenda,
            Operador = dbRec.FOperador,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        operadorgruposagendaoperadores.NomeOperadorGruposAgenda = dr["groNome"]?.ToString() ?? string.Empty;
        operadorgruposagendaoperadores.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        return operadorgruposagendaoperadores;
    }
}