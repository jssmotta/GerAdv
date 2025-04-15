namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBEventoPrazoAgenda
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBEventoPrazoAgendaDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBEventoPrazoAgendaDicInfo.Bold:
                FBold = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBEventoPrazoAgendaDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBEventoPrazoAgendaDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBEventoPrazoAgendaDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBEventoPrazoAgendaDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBEventoPrazoAgendaDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBEventoPrazoAgendaDicInfo.Nome => NFNome(),
        DBEventoPrazoAgendaDicInfo.Bold => FBold.ToString(),
        DBEventoPrazoAgendaDicInfo.QuemCad => NFQuemCad(),
        DBEventoPrazoAgendaDicInfo.DtCad => MDtCad,
        DBEventoPrazoAgendaDicInfo.QuemAtu => NFQuemAtu(),
        DBEventoPrazoAgendaDicInfo.DtAtu => MDtAtu,
        DBEventoPrazoAgendaDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}