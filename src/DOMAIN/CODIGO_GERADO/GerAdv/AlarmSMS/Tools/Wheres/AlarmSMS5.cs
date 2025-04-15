#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAlarmSMSWhere
{
    AlarmSMSResponse Read(string where, SqlConnection oCnn);
}

public partial class AlarmSMS : IAlarmSMSWhere
{
    public AlarmSMSResponse Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAlarmSMS(sqlWhere: where, oCnn: oCnn);
        var alarmsms = new AlarmSMSResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Hora = dbRec.FHora,
            Minuto = dbRec.FMinuto,
            D1 = dbRec.FD1,
            D2 = dbRec.FD2,
            D3 = dbRec.FD3,
            D4 = dbRec.FD4,
            D5 = dbRec.FD5,
            D6 = dbRec.FD6,
            D7 = dbRec.FD7,
            EMail = dbRec.FEMail ?? string.Empty,
            Desativar = dbRec.FDesativar,
            ExcetoDiasFelizes = dbRec.FExcetoDiasFelizes,
            Desktop = dbRec.FDesktop,
            Operador = dbRec.FOperador,
            Agenda = dbRec.FAgenda,
            Recado = dbRec.FRecado,
            Emocao = dbRec.FEmocao,
        };
        if (DateTime.TryParse(dbRec.FToday, out _))
            alarmsms.Today = dbRec.FToday;
        if (DateTime.TryParse(dbRec.FAlertarDataHora, out _))
            alarmsms.AlertarDataHora = dbRec.FAlertarDataHora;
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
        alarmsms.Auditor = auditor;
        return alarmsms;
    }
}