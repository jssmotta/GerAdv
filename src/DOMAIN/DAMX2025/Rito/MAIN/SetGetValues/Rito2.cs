namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBRito
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBRitoDicInfo.Descricao:
                FDescricao = $"{value}"; // rgo J3: string
                return;
            case DBRitoDicInfo.Top:
                FTop = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBRitoDicInfo.Bold:
                FBold = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBRitoDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBRitoDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBRitoDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBRitoDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBRitoDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBRitoDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBRitoDicInfo.Descricao => NFDescricao(),
        DBRitoDicInfo.Top => FTop.ToString(),
        DBRitoDicInfo.Bold => FBold.ToString(),
        DBRitoDicInfo.GUID => NFGUID(),
        DBRitoDicInfo.QuemCad => NFQuemCad(),
        DBRitoDicInfo.DtCad => MDtCad,
        DBRitoDicInfo.QuemAtu => NFQuemAtu(),
        DBRitoDicInfo.DtAtu => MDtAtu,
        DBRitoDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}