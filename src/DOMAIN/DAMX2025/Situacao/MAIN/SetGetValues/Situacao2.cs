namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBSituacao
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBSituacaoDicInfo.Parte_Int:
                FParte_Int = $"{value}"; // rgo J3: string
                return;
            case DBSituacaoDicInfo.Parte_Opo:
                FParte_Opo = $"{value}"; // rgo J3: string
                return;
            case DBSituacaoDicInfo.Top:
                FTop = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBSituacaoDicInfo.Bold:
                FBold = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBSituacaoDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBSituacaoDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBSituacaoDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBSituacaoDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBSituacaoDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBSituacaoDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBSituacaoDicInfo.Parte_Int => NFParte_Int(),
        DBSituacaoDicInfo.Parte_Opo => NFParte_Opo(),
        DBSituacaoDicInfo.Top => FTop.ToString(),
        DBSituacaoDicInfo.Bold => FBold.ToString(),
        DBSituacaoDicInfo.GUID => NFGUID(),
        DBSituacaoDicInfo.QuemCad => NFQuemCad(),
        DBSituacaoDicInfo.DtCad => MDtCad,
        DBSituacaoDicInfo.QuemAtu => NFQuemAtu(),
        DBSituacaoDicInfo.DtAtu => MDtAtu,
        DBSituacaoDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}