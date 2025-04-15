namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBGUTTipo
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBGUTTipoDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBGUTTipoDicInfo.Ordem:
                FOrdem = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBGUTTipoDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBGUTTipoDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBGUTTipoDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBGUTTipoDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBGUTTipoDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBGUTTipoDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBGUTTipoDicInfo.Nome => NFNome(),
        DBGUTTipoDicInfo.Ordem => NFOrdem(),
        DBGUTTipoDicInfo.GUID => NFGUID(),
        DBGUTTipoDicInfo.QuemCad => NFQuemCad(),
        DBGUTTipoDicInfo.DtCad => MDtCad,
        DBGUTTipoDicInfo.QuemAtu => NFQuemAtu(),
        DBGUTTipoDicInfo.DtAtu => MDtAtu,
        DBGUTTipoDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}