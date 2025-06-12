#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ISMSAliceWriter
{
    Entity.DBSMSAlice Write(Models.SMSAlice smsalice, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(SMSAliceResponse smsalice, int operadorId, MsiSqlConnection oCnn);
}

public class SMSAlice : ISMSAliceWriter
{
    public void Delete(SMSAliceResponse smsalice, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[SMSAlice] WHERE smaCodigo={smsalice.Id};", oCnn);
    }

    public Entity.DBSMSAlice Write(Models.SMSAlice smsalice, int auditorQuem, MsiSqlConnection oCnn)
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