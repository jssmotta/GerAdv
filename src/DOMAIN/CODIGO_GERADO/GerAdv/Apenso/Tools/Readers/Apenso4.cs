#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IApensoReader
{
    ApensoResponse? Read(int id, MsiSqlConnection oCnn);
    ApensoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ApensoResponse? Read(Entity.DBApenso dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ApensoResponse? Read(DBApenso dbRec);
    ApensoResponseAll? ReadAll(DBApenso dbRec, DataRow dr);
}

public partial class Apenso : IApensoReader
{
    public ApensoResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBApenso(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ApensoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBApenso(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ApensoResponse? Read(Entity.DBApenso dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var apenso = new ApensoResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            ApensoX = dbRec.FApenso ?? string.Empty,
            Acao = dbRec.FAcao ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            ValorCausa = dbRec.FValorCausa,
        };
        if (DateTime.TryParse(dbRec.FDtDist, out _))
            apenso.DtDist = dbRec.FDtDist;
        return apenso;
    }

    public ApensoResponse? Read(DBApenso dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var apenso = new ApensoResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            ApensoX = dbRec.FApenso ?? string.Empty,
            Acao = dbRec.FAcao ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            ValorCausa = dbRec.FValorCausa,
        };
        if (DateTime.TryParse(dbRec.FDtDist, out _))
            apenso.DtDist = dbRec.FDtDist;
        return apenso;
    }

    public ApensoResponseAll? ReadAll(DBApenso dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var apenso = new ApensoResponseAll
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            ApensoX = dbRec.FApenso ?? string.Empty,
            Acao = dbRec.FAcao ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            ValorCausa = dbRec.FValorCausa,
        };
        if (DateTime.TryParse(dbRec.FDtDist, out _))
            apenso.DtDist = dbRec.FDtDist;
        apenso.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return apenso;
    }
}