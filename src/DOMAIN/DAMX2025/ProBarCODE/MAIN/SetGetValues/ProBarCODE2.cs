namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProBarCODE
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBProBarCODEDicInfo.BarCODE:
                FBarCODE = $"{value}"; // rgo J3: string
                return;
            case DBProBarCODEDicInfo.Processo:
                FProcesso = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProBarCODEDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProBarCODEDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBProBarCODEDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProBarCODEDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBProBarCODEDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBProBarCODEDicInfo.BarCODE => NFBarCODE(),
        DBProBarCODEDicInfo.Processo => NFProcesso(),
        DBProBarCODEDicInfo.QuemCad => NFQuemCad(),
        DBProBarCODEDicInfo.DtCad => MDtCad,
        DBProBarCODEDicInfo.QuemAtu => NFQuemAtu(),
        DBProBarCODEDicInfo.DtAtu => MDtAtu,
        DBProBarCODEDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}