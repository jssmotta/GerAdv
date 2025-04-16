namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBApenso
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBApensoDicInfo.Processo:
                FProcesso = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBApensoDicInfo.Apenso:
                FApenso = $"{value}"; // rgo J3: string
                return;
            case DBApensoDicInfo.Acao:
                FAcao = $"{value}"; // rgo J3: string
                return;
            case DBApensoDicInfo.DtDist:
                FDtDist = $"{value}"; // rgo J3: DateTime
                return;
            case DBApensoDicInfo.OBS:
                FOBS = $"{value}"; // rgo J3: string
                return;
            case DBApensoDicInfo.ValorCausa:
                FValorCausa = Convert.ToDecimal(value); // rgo J3: decimal
                return;
            case DBApensoDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBApensoDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBApensoDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBApensoDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBApensoDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBApensoDicInfo.Processo => NFProcesso(),
        DBApensoDicInfo.Apenso => NFApenso(),
        DBApensoDicInfo.Acao => NFAcao(),
        DBApensoDicInfo.DtDist => NFDtDist(),
        DBApensoDicInfo.OBS => NFOBS(),
        DBApensoDicInfo.ValorCausa => NFValorCausa(),
        DBApensoDicInfo.QuemCad => NFQuemCad(),
        DBApensoDicInfo.DtCad => MDtCad,
        DBApensoDicInfo.QuemAtu => NFQuemAtu(),
        DBApensoDicInfo.DtAtu => MDtAtu,
        DBApensoDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}