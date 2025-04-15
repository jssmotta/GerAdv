namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAlarmSMS
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBAlarmSMSDicInfo.Descricao:
                FDescricao = $"{value}"; // rgo J3: string
                return;
            case DBAlarmSMSDicInfo.Hora:
                FHora = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAlarmSMSDicInfo.Minuto:
                FMinuto = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAlarmSMSDicInfo.D1:
                FD1 = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBAlarmSMSDicInfo.D2:
                FD2 = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBAlarmSMSDicInfo.D3:
                FD3 = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBAlarmSMSDicInfo.D4:
                FD4 = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBAlarmSMSDicInfo.D5:
                FD5 = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBAlarmSMSDicInfo.D6:
                FD6 = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBAlarmSMSDicInfo.D7:
                FD7 = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBAlarmSMSDicInfo.EMail:
                FEMail = $"{value}"; // rgo J3: string
                return;
            case DBAlarmSMSDicInfo.Desativar:
                FDesativar = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBAlarmSMSDicInfo.Today:
                FToday = $"{value}"; // rgo J3: DateTime
                return;
            case DBAlarmSMSDicInfo.ExcetoDiasFelizes:
                FExcetoDiasFelizes = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBAlarmSMSDicInfo.Desktop:
                FDesktop = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBAlarmSMSDicInfo.AlertarDataHora:
                FAlertarDataHora = $"{value}"; // rgo J3: DateTime
                return;
            case DBAlarmSMSDicInfo.Operador:
                FOperador = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAlarmSMSDicInfo.GuidExo:
                FGuidExo = $"{value}"; // rgo J3: string
                return;
            case DBAlarmSMSDicInfo.Agenda:
                FAgenda = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAlarmSMSDicInfo.Recado:
                FRecado = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAlarmSMSDicInfo.Emocao:
                FEmocao = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAlarmSMSDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBAlarmSMSDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAlarmSMSDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBAlarmSMSDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAlarmSMSDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBAlarmSMSDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBAlarmSMSDicInfo.Descricao => NFDescricao(),
        DBAlarmSMSDicInfo.Hora => NFHora(),
        DBAlarmSMSDicInfo.Minuto => NFMinuto(),
        DBAlarmSMSDicInfo.D1 => FD1.ToString(),
        DBAlarmSMSDicInfo.D2 => FD2.ToString(),
        DBAlarmSMSDicInfo.D3 => FD3.ToString(),
        DBAlarmSMSDicInfo.D4 => FD4.ToString(),
        DBAlarmSMSDicInfo.D5 => FD5.ToString(),
        DBAlarmSMSDicInfo.D6 => FD6.ToString(),
        DBAlarmSMSDicInfo.D7 => FD7.ToString(),
        DBAlarmSMSDicInfo.EMail => NFEMail(),
        DBAlarmSMSDicInfo.Desativar => FDesativar.ToString(),
        DBAlarmSMSDicInfo.Today => NFToday(),
        DBAlarmSMSDicInfo.ExcetoDiasFelizes => FExcetoDiasFelizes.ToString(),
        DBAlarmSMSDicInfo.Desktop => FDesktop.ToString(),
        DBAlarmSMSDicInfo.AlertarDataHora => NFAlertarDataHora(),
        DBAlarmSMSDicInfo.Operador => NFOperador(),
        DBAlarmSMSDicInfo.GuidExo => NFGuidExo(),
        DBAlarmSMSDicInfo.Agenda => NFAgenda(),
        DBAlarmSMSDicInfo.Recado => NFRecado(),
        DBAlarmSMSDicInfo.Emocao => NFEmocao(),
        DBAlarmSMSDicInfo.GUID => NFGUID(),
        DBAlarmSMSDicInfo.QuemCad => NFQuemCad(),
        DBAlarmSMSDicInfo.DtCad => MDtCad,
        DBAlarmSMSDicInfo.QuemAtu => NFQuemAtu(),
        DBAlarmSMSDicInfo.DtAtu => MDtAtu,
        DBAlarmSMSDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}