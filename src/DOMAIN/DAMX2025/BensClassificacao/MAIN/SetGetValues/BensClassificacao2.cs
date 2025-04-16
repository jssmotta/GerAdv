namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBBensClassificacao
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBBensClassificacaoDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBBensClassificacaoDicInfo.Bold:
                FBold = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBBensClassificacaoDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBBensClassificacaoDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBBensClassificacaoDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBBensClassificacaoDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBBensClassificacaoDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBBensClassificacaoDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBBensClassificacaoDicInfo.Nome => NFNome(),
        DBBensClassificacaoDicInfo.Bold => FBold.ToString(),
        DBBensClassificacaoDicInfo.GUID => NFGUID(),
        DBBensClassificacaoDicInfo.QuemCad => NFQuemCad(),
        DBBensClassificacaoDicInfo.DtCad => MDtCad,
        DBBensClassificacaoDicInfo.QuemAtu => NFQuemAtu(),
        DBBensClassificacaoDicInfo.DtAtu => MDtAtu,
        DBBensClassificacaoDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}