namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBUF
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBUFDicInfo.DDD:
                FDDD = $"{value}"; // rgo J3: string
                return;
            case DBUFDicInfo.ID:
                FID = $"{value}"; // rgo J3: string
                return;
            case DBUFDicInfo.Pais:
                FPais = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBUFDicInfo.Top:
                FTop = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBUFDicInfo.Descricao:
                FDescricao = $"{value}"; // rgo J3: string
                return;
            case DBUFDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBUFDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBUFDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBUFDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBUFDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBUFDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBUFDicInfo.DDD => NFDDD(),
        DBUFDicInfo.ID => NFID(),
        DBUFDicInfo.Pais => NFPais(),
        DBUFDicInfo.Top => FTop.ToString(),
        DBUFDicInfo.Descricao => NFDescricao(),
        DBUFDicInfo.GUID => NFGUID(),
        DBUFDicInfo.QuemCad => NFQuemCad(),
        DBUFDicInfo.DtCad => MDtCad,
        DBUFDicInfo.QuemAtu => NFQuemAtu(),
        DBUFDicInfo.DtAtu => MDtAtu,
        DBUFDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}