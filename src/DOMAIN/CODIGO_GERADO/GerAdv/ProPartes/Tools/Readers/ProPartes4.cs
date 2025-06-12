#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProPartesReader
{
    ProPartesResponse? Read(int id, MsiSqlConnection oCnn);
    ProPartesResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProPartesResponse? Read(Entity.DBProPartes dbRec);
    ProPartesResponse? Read(DBProPartes dbRec);
    ProPartesResponseAll? ReadAll(DBProPartes dbRec, DataRow dr);
}

public partial class ProPartes : IProPartesReader
{
    public ProPartesResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProPartes(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProPartesResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProPartes(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProPartesResponse? Read(Entity.DBProPartes dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var propartes = new ProPartesResponse
        {
            Id = dbRec.ID,
            Parte = dbRec.FParte,
            Processo = dbRec.FProcesso,
        };
        return propartes;
    }

    public ProPartesResponse? Read(DBProPartes dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var propartes = new ProPartesResponse
        {
            Id = dbRec.ID,
            Parte = dbRec.FParte,
            Processo = dbRec.FProcesso,
        };
        return propartes;
    }

    public ProPartesResponseAll? ReadAll(DBProPartes dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var propartes = new ProPartesResponseAll
        {
            Id = dbRec.ID,
            Parte = dbRec.FParte,
            Processo = dbRec.FProcesso,
        };
        propartes.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return propartes;
    }
}