#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ISMSAliceWhere
{
    SMSAliceResponse Read(string where, SqlConnection oCnn);
}

public partial class SMSAlice : ISMSAliceWhere
{
    public SMSAliceResponse Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBSMSAlice(sqlWhere: where, oCnn: oCnn);
        var smsalice = new SMSAliceResponse
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Nome = dbRec.FNome ?? string.Empty,
            TipoEMail = dbRec.FTipoEMail,
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