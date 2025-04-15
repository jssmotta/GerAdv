namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBTipoEndereco
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBTipoEnderecoDicInfo.Descricao:
                FDescricao = $"{value}"; // rgo J3: string
                return;
            case DBTipoEnderecoDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBTipoEnderecoDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBTipoEnderecoDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBTipoEnderecoDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBTipoEnderecoDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBTipoEnderecoDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBTipoEnderecoDicInfo.Descricao => NFDescricao(),
        DBTipoEnderecoDicInfo.GUID => NFGUID(),
        DBTipoEnderecoDicInfo.QuemCad => NFQuemCad(),
        DBTipoEnderecoDicInfo.DtCad => MDtCad,
        DBTipoEnderecoDicInfo.QuemAtu => NFQuemAtu(),
        DBTipoEnderecoDicInfo.DtAtu => MDtAtu,
        DBTipoEnderecoDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}