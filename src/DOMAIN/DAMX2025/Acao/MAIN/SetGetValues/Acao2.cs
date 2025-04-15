namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAcao
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBAcaoDicInfo.Justica:
                FJustica = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAcaoDicInfo.Area:
                FArea = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAcaoDicInfo.Descricao:
                FDescricao = $"{value}"; // rgo J3: string
                return;
            case DBAcaoDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBAcaoDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAcaoDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBAcaoDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAcaoDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBAcaoDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBAcaoDicInfo.Justica => NFJustica(),
        DBAcaoDicInfo.Area => NFArea(),
        DBAcaoDicInfo.Descricao => NFDescricao(),
        DBAcaoDicInfo.GUID => NFGUID(),
        DBAcaoDicInfo.QuemCad => NFQuemCad(),
        DBAcaoDicInfo.DtCad => MDtCad,
        DBAcaoDicInfo.QuemAtu => NFQuemAtu(),
        DBAcaoDicInfo.DtAtu => MDtAtu,
        DBAcaoDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}