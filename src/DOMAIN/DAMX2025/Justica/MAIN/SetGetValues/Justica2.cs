namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBJustica
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBJusticaDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBJusticaDicInfo.Bold:
                FBold = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBJusticaDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBJusticaDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBJusticaDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBJusticaDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBJusticaDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBJusticaDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBJusticaDicInfo.Nome => NFNome(),
        DBJusticaDicInfo.Bold => FBold.ToString(),
        DBJusticaDicInfo.GUID => NFGUID(),
        DBJusticaDicInfo.QuemCad => NFQuemCad(),
        DBJusticaDicInfo.DtCad => MDtCad,
        DBJusticaDicInfo.QuemAtu => NFQuemAtu(),
        DBJusticaDicInfo.DtAtu => MDtAtu,
        DBJusticaDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}