#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ISMSAliceReader
{
    SMSAliceResponse? Read(int id, SqlConnection oCnn);
    SMSAliceResponse? Read(string where, SqlConnection oCnn);
    SMSAliceResponse? Read(Entity.DBSMSAlice dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    SMSAliceResponse? Read(DBSMSAlice dbRec);
}

public partial class SMSAlice : ISMSAliceReader
{
    public SMSAliceResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBSMSAlice(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public SMSAliceResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBSMSAlice(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public SMSAliceResponse? Read(Entity.DBSMSAlice dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var smsalice = new SMSAliceResponse
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Nome = dbRec.FNome ?? string.Empty,
            TipoEMail = dbRec.FTipoEMail,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        var auditor = new Auditor
        {
            Visto = dbRec.FVisto,
            QuemCad = dbRec.FQuemCad
        };
        if (auditor.QuemAtu > 0)
            auditor.QuemAtu = dbRec.FQuemAtu;
        if (dbRec.FDtCad.NotIsEmpty())
            auditor.DtCad = Convert.ToDateTime(dbRec.FDtCad);
        if (!(dbRec.FDtAtu is { }))
            auditor.DtAtu = Convert.ToDateTime(dbRec.FDtAtu);
        smsalice.Auditor = auditor;
        return smsalice;
    }

    public SMSAliceResponse? Read(DBSMSAlice dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var smsalice = new SMSAliceResponse
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Nome = dbRec.FNome ?? string.Empty,
            TipoEMail = dbRec.FTipoEMail,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        var auditor = new Auditor
        {
            Visto = dbRec.FVisto,
            QuemCad = dbRec.FQuemCad
        };
        if (auditor.QuemAtu > 0)
            auditor.QuemAtu = dbRec.FQuemAtu;
        if (dbRec.FDtCad.NotIsEmpty())
            auditor.DtCad = Convert.ToDateTime(dbRec.FDtCad);
        if (!(dbRec.FDtAtu is { }))
            auditor.DtAtu = Convert.ToDateTime(dbRec.FDtAtu);
        smsalice.Auditor = auditor;
        return smsalice;
    }
}