#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGUTPeriodicidadeStatusReader
{
    GUTPeriodicidadeStatusResponse? Read(int id, MsiSqlConnection oCnn);
    GUTPeriodicidadeStatusResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    GUTPeriodicidadeStatusResponse? Read(Entity.DBGUTPeriodicidadeStatus dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    GUTPeriodicidadeStatusResponse? Read(DBGUTPeriodicidadeStatus dbRec);
    GUTPeriodicidadeStatusResponseAll? ReadAll(DBGUTPeriodicidadeStatus dbRec, DataRow dr);
}

public partial class GUTPeriodicidadeStatus : IGUTPeriodicidadeStatusReader
{
    public GUTPeriodicidadeStatusResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGUTPeriodicidadeStatus(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public GUTPeriodicidadeStatusResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGUTPeriodicidadeStatus(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public GUTPeriodicidadeStatusResponse? Read(Entity.DBGUTPeriodicidadeStatus dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gutperiodicidadestatus = new GUTPeriodicidadeStatusResponse
        {
            Id = dbRec.ID,
            GUTAtividade = dbRec.FGUTAtividade,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataRealizado, out _))
            gutperiodicidadestatus.DataRealizado = dbRec.FDataRealizado;
        return gutperiodicidadestatus;
    }

    public GUTPeriodicidadeStatusResponse? Read(DBGUTPeriodicidadeStatus dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gutperiodicidadestatus = new GUTPeriodicidadeStatusResponse
        {
            Id = dbRec.ID,
            GUTAtividade = dbRec.FGUTAtividade,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataRealizado, out _))
            gutperiodicidadestatus.DataRealizado = dbRec.FDataRealizado;
        return gutperiodicidadestatus;
    }

    public GUTPeriodicidadeStatusResponseAll? ReadAll(DBGUTPeriodicidadeStatus dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gutperiodicidadestatus = new GUTPeriodicidadeStatusResponseAll
        {
            Id = dbRec.ID,
            GUTAtividade = dbRec.FGUTAtividade,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataRealizado, out _))
            gutperiodicidadestatus.DataRealizado = dbRec.FDataRealizado;
        gutperiodicidadestatus.NomeGUTAtividades = dr["agtNome"]?.ToString() ?? string.Empty;
        return gutperiodicidadestatus;
    }
}