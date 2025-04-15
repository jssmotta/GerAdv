namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAgendaRepetirDias
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBAgendaRepetirDiasDicInfo.HoraFinal:
                FHoraFinal = $"{value}"; // rgo J3: DateTime
                return;
            case DBAgendaRepetirDiasDicInfo.Master:
                FMaster = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaRepetirDiasDicInfo.Dia:
                FDia = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaRepetirDiasDicInfo.Hora:
                FHora = $"{value}"; // rgo J3: DateTime
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBAgendaRepetirDiasDicInfo.HoraFinal => NFHoraFinal(),
        DBAgendaRepetirDiasDicInfo.Master => NFMaster(),
        DBAgendaRepetirDiasDicInfo.Dia => NFDia(),
        DBAgendaRepetirDiasDicInfo.Hora => NFHora(),
        _ => nameof(GetValueByNameField)};
}