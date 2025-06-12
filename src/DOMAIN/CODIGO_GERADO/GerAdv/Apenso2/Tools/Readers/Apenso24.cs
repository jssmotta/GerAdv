#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IApenso2Reader
{
    Apenso2Response? Read(int id, MsiSqlConnection oCnn);
    Apenso2Response? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    Apenso2Response? Read(Entity.DBApenso2 dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    Apenso2Response? Read(DBApenso2 dbRec);
    Apenso2ResponseAll? ReadAll(DBApenso2 dbRec, DataRow dr);
}

public partial class Apenso2 : IApenso2Reader
{
    public Apenso2Response? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBApenso2(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public Apenso2Response? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBApenso2(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public Apenso2Response? Read(Entity.DBApenso2 dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var apenso2 = new Apenso2Response
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Apensado = dbRec.FApensado,
        };
        return apenso2;
    }

    public Apenso2Response? Read(DBApenso2 dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var apenso2 = new Apenso2Response
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Apensado = dbRec.FApensado,
        };
        return apenso2;
    }

    public Apenso2ResponseAll? ReadAll(DBApenso2 dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var apenso2 = new Apenso2ResponseAll
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Apensado = dbRec.FApensado,
        };
        apenso2.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return apenso2;
    }
}