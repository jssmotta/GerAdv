namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBStatusInstancia
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBStatusInstanciaDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBStatusInstanciaDicInfo.Bold:
                FBold = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBStatusInstanciaDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBStatusInstanciaDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBStatusInstanciaDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBStatusInstanciaDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBStatusInstanciaDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBStatusInstanciaDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBStatusInstanciaDicInfo.Nome => NFNome(),
        DBStatusInstanciaDicInfo.Bold => FBold.ToString(),
        DBStatusInstanciaDicInfo.GUID => NFGUID(),
        DBStatusInstanciaDicInfo.QuemCad => NFQuemCad(),
        DBStatusInstanciaDicInfo.DtCad => MDtCad,
        DBStatusInstanciaDicInfo.QuemAtu => NFQuemAtu(),
        DBStatusInstanciaDicInfo.DtAtu => MDtAtu,
        DBStatusInstanciaDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}