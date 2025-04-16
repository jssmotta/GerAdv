namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBSetor
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBSetorDicInfo.Descricao:
                FDescricao = $"{value}"; // rgo J3: string
                return;
            case DBSetorDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBSetorDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBSetorDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBSetorDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBSetorDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBSetorDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBSetorDicInfo.Descricao => NFDescricao(),
        DBSetorDicInfo.GUID => NFGUID(),
        DBSetorDicInfo.QuemCad => NFQuemCad(),
        DBSetorDicInfo.DtCad => MDtCad,
        DBSetorDicInfo.QuemAtu => NFQuemAtu(),
        DBSetorDicInfo.DtAtu => MDtAtu,
        DBSetorDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}