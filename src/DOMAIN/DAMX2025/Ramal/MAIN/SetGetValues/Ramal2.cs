namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBRamal
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBRamalDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBRamalDicInfo.Obs:
                FObs = $"{value}"; // rgo J3: string
                return;
            case DBRamalDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBRamalDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBRamalDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBRamalDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBRamalDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBRamalDicInfo.Nome => NFNome(),
        DBRamalDicInfo.Obs => NFObs(),
        DBRamalDicInfo.QuemCad => NFQuemCad(),
        DBRamalDicInfo.DtCad => MDtCad,
        DBRamalDicInfo.QuemAtu => NFQuemAtu(),
        DBRamalDicInfo.DtAtu => MDtAtu,
        DBRamalDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}