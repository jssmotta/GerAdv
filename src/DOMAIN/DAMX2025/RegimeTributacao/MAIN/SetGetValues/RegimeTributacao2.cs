namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBRegimeTributacao
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBRegimeTributacaoDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBRegimeTributacaoDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBRegimeTributacaoDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBRegimeTributacaoDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBRegimeTributacaoDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBRegimeTributacaoDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBRegimeTributacaoDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBRegimeTributacaoDicInfo.Nome => NFNome(),
        DBRegimeTributacaoDicInfo.GUID => NFGUID(),
        DBRegimeTributacaoDicInfo.QuemCad => NFQuemCad(),
        DBRegimeTributacaoDicInfo.DtCad => MDtCad,
        DBRegimeTributacaoDicInfo.QuemAtu => NFQuemAtu(),
        DBRegimeTributacaoDicInfo.DtAtu => MDtAtu,
        DBRegimeTributacaoDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}