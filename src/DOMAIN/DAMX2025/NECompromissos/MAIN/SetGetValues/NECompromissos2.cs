namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBNECompromissos
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBNECompromissosDicInfo.PalavraChave:
                FPalavraChave = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBNECompromissosDicInfo.Provisionar:
                FProvisionar = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBNECompromissosDicInfo.TipoCompromisso:
                FTipoCompromisso = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBNECompromissosDicInfo.TextoCompromisso:
                FTextoCompromisso = $"{value}"; // rgo J3: string
                return;
            case DBNECompromissosDicInfo.Bold:
                FBold = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBNECompromissosDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBNECompromissosDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBNECompromissosDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBNECompromissosDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBNECompromissosDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBNECompromissosDicInfo.PalavraChave => NFPalavraChave(),
        DBNECompromissosDicInfo.Provisionar => FProvisionar.ToString(),
        DBNECompromissosDicInfo.TipoCompromisso => NFTipoCompromisso(),
        DBNECompromissosDicInfo.TextoCompromisso => NFTextoCompromisso(),
        DBNECompromissosDicInfo.Bold => FBold.ToString(),
        DBNECompromissosDicInfo.QuemCad => NFQuemCad(),
        DBNECompromissosDicInfo.DtCad => MDtCad,
        DBNECompromissosDicInfo.QuemAtu => NFQuemAtu(),
        DBNECompromissosDicInfo.DtAtu => MDtAtu,
        DBNECompromissosDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}