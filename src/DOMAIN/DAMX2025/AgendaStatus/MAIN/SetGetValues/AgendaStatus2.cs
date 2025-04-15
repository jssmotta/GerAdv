namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAgendaStatus
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBAgendaStatusDicInfo.Agenda:
                FAgenda = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaStatusDicInfo.Completed:
                FCompleted = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaStatusDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaStatusDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBAgendaStatusDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaStatusDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBAgendaStatusDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBAgendaStatusDicInfo.Agenda => NFAgenda(),
        DBAgendaStatusDicInfo.Completed => NFCompleted(),
        DBAgendaStatusDicInfo.QuemCad => NFQuemCad(),
        DBAgendaStatusDicInfo.DtCad => MDtCad,
        DBAgendaStatusDicInfo.QuemAtu => NFQuemAtu(),
        DBAgendaStatusDicInfo.DtAtu => MDtAtu,
        DBAgendaStatusDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}