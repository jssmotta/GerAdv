#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAlarmSMSWriter
{
    Entity.DBAlarmSMS Write(Models.AlarmSMS alarmsms, int auditorQuem, SqlConnection oCnn);
}

public class AlarmSMS : IAlarmSMSWriter
{
    public Entity.DBAlarmSMS Write(Models.AlarmSMS alarmsms, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = alarmsms.Id.IsEmptyIDNumber() ? new Entity.DBAlarmSMS() : new Entity.DBAlarmSMS(alarmsms.Id, oCnn);
        dbRec.FDescricao = alarmsms.Descricao;
        dbRec.FHora = alarmsms.Hora;
        dbRec.FMinuto = alarmsms.Minuto;
        dbRec.FD1 = alarmsms.D1;
        dbRec.FD2 = alarmsms.D2;
        dbRec.FD3 = alarmsms.D3;
        dbRec.FD4 = alarmsms.D4;
        dbRec.FD5 = alarmsms.D5;
        dbRec.FD6 = alarmsms.D6;
        dbRec.FD7 = alarmsms.D7;
        dbRec.FEMail = alarmsms.EMail;
        dbRec.FDesativar = alarmsms.Desativar;
        if (alarmsms.Today != null)
            dbRec.FToday = alarmsms.Today.ToString();
        dbRec.FExcetoDiasFelizes = alarmsms.ExcetoDiasFelizes;
        dbRec.FDesktop = alarmsms.Desktop;
        if (alarmsms.AlertarDataHora != null)
            dbRec.FAlertarDataHora = alarmsms.AlertarDataHora.ToString();
        dbRec.FOperador = alarmsms.Operador;
        dbRec.FAgenda = alarmsms.Agenda;
        dbRec.FRecado = alarmsms.Recado;
        dbRec.FEmocao = alarmsms.Emocao;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}