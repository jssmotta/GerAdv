#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ISMSAliceWriter
{
    Entity.DBSMSAlice Write(Models.SMSAlice smsalice, int auditorQuem, SqlConnection oCnn);
}

public class SMSAlice : ISMSAliceWriter
{
    public Entity.DBSMSAlice Write(Models.SMSAlice smsalice, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = smsalice.Id.IsEmptyIDNumber() ? new Entity.DBSMSAlice() : new Entity.DBSMSAlice(smsalice.Id, oCnn);
        dbRec.FOperador = smsalice.Operador;
        dbRec.FNome = smsalice.Nome;
        dbRec.FTipoEMail = smsalice.TipoEMail;
        dbRec.FGUID = smsalice.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}