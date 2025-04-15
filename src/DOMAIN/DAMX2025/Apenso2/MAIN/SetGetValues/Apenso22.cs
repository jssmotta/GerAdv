namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBApenso2
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBApenso2DicInfo.Processo:
                FProcesso = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBApenso2DicInfo.Apensado:
                FApensado = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBApenso2DicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBApenso2DicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBApenso2DicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBApenso2DicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBApenso2DicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBApenso2DicInfo.Processo => NFProcesso(),
        DBApenso2DicInfo.Apensado => NFApensado(),
        DBApenso2DicInfo.QuemCad => NFQuemCad(),
        DBApenso2DicInfo.DtCad => MDtCad,
        DBApenso2DicInfo.QuemAtu => NFQuemAtu(),
        DBApenso2DicInfo.DtAtu => MDtAtu,
        DBApenso2DicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}