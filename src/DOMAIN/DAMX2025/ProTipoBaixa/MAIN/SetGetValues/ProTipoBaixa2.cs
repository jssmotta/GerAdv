namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProTipoBaixa
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBProTipoBaixaDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBProTipoBaixaDicInfo.Bold:
                FBold = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBProTipoBaixaDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBProTipoBaixaDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProTipoBaixaDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBProTipoBaixaDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProTipoBaixaDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBProTipoBaixaDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBProTipoBaixaDicInfo.Nome => NFNome(),
        DBProTipoBaixaDicInfo.Bold => FBold.ToString(),
        DBProTipoBaixaDicInfo.GUID => NFGUID(),
        DBProTipoBaixaDicInfo.QuemCad => NFQuemCad(),
        DBProTipoBaixaDicInfo.DtCad => MDtCad,
        DBProTipoBaixaDicInfo.QuemAtu => NFQuemAtu(),
        DBProTipoBaixaDicInfo.DtAtu => MDtAtu,
        DBProTipoBaixaDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}