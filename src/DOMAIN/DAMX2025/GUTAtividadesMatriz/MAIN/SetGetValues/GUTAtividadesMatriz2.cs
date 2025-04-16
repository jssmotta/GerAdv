namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBGUTAtividadesMatriz
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBGUTAtividadesMatrizDicInfo.GUTMatriz:
                FGUTMatriz = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBGUTAtividadesMatrizDicInfo.GUTAtividade:
                FGUTAtividade = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBGUTAtividadesMatrizDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBGUTAtividadesMatrizDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBGUTAtividadesMatrizDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBGUTAtividadesMatrizDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBGUTAtividadesMatrizDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBGUTAtividadesMatrizDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBGUTAtividadesMatrizDicInfo.GUTMatriz => NFGUTMatriz(),
        DBGUTAtividadesMatrizDicInfo.GUTAtividade => NFGUTAtividade(),
        DBGUTAtividadesMatrizDicInfo.GUID => NFGUID(),
        DBGUTAtividadesMatrizDicInfo.QuemCad => NFQuemCad(),
        DBGUTAtividadesMatrizDicInfo.DtCad => MDtCad,
        DBGUTAtividadesMatrizDicInfo.QuemAtu => NFQuemAtu(),
        DBGUTAtividadesMatrizDicInfo.DtAtu => MDtAtu,
        DBGUTAtividadesMatrizDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}