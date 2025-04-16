namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBEMPClassRiscos
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBEMPClassRiscosDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBEMPClassRiscosDicInfo.Bold:
                FBold = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBEMPClassRiscosDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBEMPClassRiscosDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBEMPClassRiscosDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBEMPClassRiscosDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBEMPClassRiscosDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBEMPClassRiscosDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBEMPClassRiscosDicInfo.Nome => NFNome(),
        DBEMPClassRiscosDicInfo.Bold => FBold.ToString(),
        DBEMPClassRiscosDicInfo.GUID => NFGUID(),
        DBEMPClassRiscosDicInfo.QuemCad => NFQuemCad(),
        DBEMPClassRiscosDicInfo.DtCad => MDtCad,
        DBEMPClassRiscosDicInfo.QuemAtu => NFQuemAtu(),
        DBEMPClassRiscosDicInfo.DtAtu => MDtAtu,
        DBEMPClassRiscosDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}