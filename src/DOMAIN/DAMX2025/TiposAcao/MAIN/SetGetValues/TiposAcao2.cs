namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBTiposAcao
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBTiposAcaoDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBTiposAcaoDicInfo.Inativo:
                FInativo = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBTiposAcaoDicInfo.Bold:
                FBold = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBTiposAcaoDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBTiposAcaoDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBTiposAcaoDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBTiposAcaoDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBTiposAcaoDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBTiposAcaoDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBTiposAcaoDicInfo.Nome => NFNome(),
        DBTiposAcaoDicInfo.Inativo => FInativo.ToString(),
        DBTiposAcaoDicInfo.Bold => FBold.ToString(),
        DBTiposAcaoDicInfo.GUID => NFGUID(),
        DBTiposAcaoDicInfo.QuemCad => NFQuemCad(),
        DBTiposAcaoDicInfo.DtCad => MDtCad,
        DBTiposAcaoDicInfo.QuemAtu => NFQuemAtu(),
        DBTiposAcaoDicInfo.DtAtu => MDtAtu,
        DBTiposAcaoDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}