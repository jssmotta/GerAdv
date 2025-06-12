#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ISituacaoReader
{
    SituacaoResponse? Read(int id, MsiSqlConnection oCnn);
    SituacaoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    SituacaoResponse? Read(Entity.DBSituacao dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    SituacaoResponse? Read(DBSituacao dbRec);
    SituacaoResponseAll? ReadAll(DBSituacao dbRec, DataRow dr);
}

public partial class Situacao : ISituacaoReader
{
    public SituacaoResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBSituacao(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public SituacaoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBSituacao(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public SituacaoResponse? Read(Entity.DBSituacao dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var situacao = new SituacaoResponse
        {
            Id = dbRec.ID,
            Parte_Int = dbRec.FParte_Int ?? string.Empty,
            Parte_Opo = dbRec.FParte_Opo ?? string.Empty,
            Top = dbRec.FTop,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return situacao;
    }

    public SituacaoResponse? Read(DBSituacao dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var situacao = new SituacaoResponse
        {
            Id = dbRec.ID,
            Parte_Int = dbRec.FParte_Int ?? string.Empty,
            Parte_Opo = dbRec.FParte_Opo ?? string.Empty,
            Top = dbRec.FTop,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return situacao;
    }

    public SituacaoResponseAll? ReadAll(DBSituacao dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var situacao = new SituacaoResponseAll
        {
            Id = dbRec.ID,
            Parte_Int = dbRec.FParte_Int ?? string.Empty,
            Parte_Opo = dbRec.FParte_Opo ?? string.Empty,
            Top = dbRec.FTop,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return situacao;
    }
}