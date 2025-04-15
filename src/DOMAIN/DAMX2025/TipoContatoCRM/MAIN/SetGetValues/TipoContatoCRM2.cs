namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBTipoContatoCRM
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBTipoContatoCRMDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBTipoContatoCRMDicInfo.Bold:
                FBold = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBTipoContatoCRMDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBTipoContatoCRMDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBTipoContatoCRMDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBTipoContatoCRMDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBTipoContatoCRMDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBTipoContatoCRMDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBTipoContatoCRMDicInfo.Nome => NFNome(),
        DBTipoContatoCRMDicInfo.Bold => FBold.ToString(),
        DBTipoContatoCRMDicInfo.GUID => NFGUID(),
        DBTipoContatoCRMDicInfo.QuemCad => NFQuemCad(),
        DBTipoContatoCRMDicInfo.DtCad => MDtCad,
        DBTipoContatoCRMDicInfo.QuemAtu => NFQuemAtu(),
        DBTipoContatoCRMDicInfo.DtAtu => MDtAtu,
        DBTipoContatoCRMDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}