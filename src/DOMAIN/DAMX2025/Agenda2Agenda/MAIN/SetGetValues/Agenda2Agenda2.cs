namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAgenda2Agenda
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBAgenda2AgendaDicInfo.Master:
                FMaster = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgenda2AgendaDicInfo.Agenda:
                FAgenda = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgenda2AgendaDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgenda2AgendaDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBAgenda2AgendaDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgenda2AgendaDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBAgenda2AgendaDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBAgenda2AgendaDicInfo.Master => NFMaster(),
        DBAgenda2AgendaDicInfo.Agenda => NFAgenda(),
        DBAgenda2AgendaDicInfo.QuemCad => NFQuemCad(),
        DBAgenda2AgendaDicInfo.DtCad => MDtCad,
        DBAgenda2AgendaDicInfo.QuemAtu => NFQuemAtu(),
        DBAgenda2AgendaDicInfo.DtAtu => MDtAtu,
        DBAgenda2AgendaDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}