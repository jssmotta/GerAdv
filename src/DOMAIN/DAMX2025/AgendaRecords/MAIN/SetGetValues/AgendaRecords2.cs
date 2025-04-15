namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAgendaRecords
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBAgendaRecordsDicInfo.Agenda:
                FAgenda = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaRecordsDicInfo.Julgador:
                FJulgador = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaRecordsDicInfo.ClientesSocios:
                FClientesSocios = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaRecordsDicInfo.Perito:
                FPerito = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaRecordsDicInfo.Colaborador:
                FColaborador = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaRecordsDicInfo.Foro:
                FForo = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaRecordsDicInfo.Aviso1:
                FAviso1 = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBAgendaRecordsDicInfo.Aviso2:
                FAviso2 = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBAgendaRecordsDicInfo.Aviso3:
                FAviso3 = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBAgendaRecordsDicInfo.CrmAviso1:
                FCrmAviso1 = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaRecordsDicInfo.CrmAviso2:
                FCrmAviso2 = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaRecordsDicInfo.CrmAviso3:
                FCrmAviso3 = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaRecordsDicInfo.DataAviso1:
                FDataAviso1 = $"{value}"; // rgo J3: DateTime
                return;
            case DBAgendaRecordsDicInfo.DataAviso2:
                FDataAviso2 = $"{value}"; // rgo J3: DateTime
                return;
            case DBAgendaRecordsDicInfo.DataAviso3:
                FDataAviso3 = $"{value}"; // rgo J3: DateTime
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBAgendaRecordsDicInfo.Agenda => NFAgenda(),
        DBAgendaRecordsDicInfo.Julgador => NFJulgador(),
        DBAgendaRecordsDicInfo.ClientesSocios => NFClientesSocios(),
        DBAgendaRecordsDicInfo.Perito => NFPerito(),
        DBAgendaRecordsDicInfo.Colaborador => NFColaborador(),
        DBAgendaRecordsDicInfo.Foro => NFForo(),
        DBAgendaRecordsDicInfo.Aviso1 => FAviso1.ToString(),
        DBAgendaRecordsDicInfo.Aviso2 => FAviso2.ToString(),
        DBAgendaRecordsDicInfo.Aviso3 => FAviso3.ToString(),
        DBAgendaRecordsDicInfo.CrmAviso1 => NFCrmAviso1(),
        DBAgendaRecordsDicInfo.CrmAviso2 => NFCrmAviso2(),
        DBAgendaRecordsDicInfo.CrmAviso3 => NFCrmAviso3(),
        DBAgendaRecordsDicInfo.DataAviso1 => NFDataAviso1(),
        DBAgendaRecordsDicInfo.DataAviso2 => NFDataAviso2(),
        DBAgendaRecordsDicInfo.DataAviso3 => NFDataAviso3(),
        _ => nameof(GetValueByNameField)};
}