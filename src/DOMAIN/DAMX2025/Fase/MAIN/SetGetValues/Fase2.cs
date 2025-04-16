namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBFase
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBFaseDicInfo.Descricao:
                FDescricao = $"{value}"; // rgo J3: string
                return;
            case DBFaseDicInfo.Justica:
                FJustica = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBFaseDicInfo.Area:
                FArea = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBFaseDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBFaseDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBFaseDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBFaseDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBFaseDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBFaseDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBFaseDicInfo.Descricao => NFDescricao(),
        DBFaseDicInfo.Justica => NFJustica(),
        DBFaseDicInfo.Area => NFArea(),
        DBFaseDicInfo.GUID => NFGUID(),
        DBFaseDicInfo.QuemCad => NFQuemCad(),
        DBFaseDicInfo.DtCad => MDtCad,
        DBFaseDicInfo.QuemAtu => NFQuemAtu(),
        DBFaseDicInfo.DtAtu => MDtAtu,
        DBFaseDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}