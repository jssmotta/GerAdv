namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBArea
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBAreaDicInfo.Descricao:
                FDescricao = $"{value}"; // rgo J3: string
                return;
            case DBAreaDicInfo.Top:
                FTop = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBAreaDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBAreaDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAreaDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBAreaDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAreaDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBAreaDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBAreaDicInfo.Descricao => NFDescricao(),
        DBAreaDicInfo.Top => FTop.ToString(),
        DBAreaDicInfo.GUID => NFGUID(),
        DBAreaDicInfo.QuemCad => NFQuemCad(),
        DBAreaDicInfo.DtCad => MDtCad,
        DBAreaDicInfo.QuemAtu => NFQuemAtu(),
        DBAreaDicInfo.DtAtu => MDtAtu,
        DBAreaDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}