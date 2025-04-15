namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProCDA
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBProCDADicInfo.Processo:
                FProcesso = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProCDADicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBProCDADicInfo.NroInterno:
                FNroInterno = $"{value}"; // rgo J3: string
                return;
            case DBProCDADicInfo.Bold:
                FBold = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBProCDADicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBProCDADicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProCDADicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBProCDADicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProCDADicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBProCDADicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBProCDADicInfo.Processo => NFProcesso(),
        DBProCDADicInfo.Nome => NFNome(),
        DBProCDADicInfo.NroInterno => NFNroInterno(),
        DBProCDADicInfo.Bold => FBold.ToString(),
        DBProCDADicInfo.GUID => NFGUID(),
        DBProCDADicInfo.QuemCad => NFQuemCad(),
        DBProCDADicInfo.DtCad => MDtCad,
        DBProCDADicInfo.QuemAtu => NFQuemAtu(),
        DBProCDADicInfo.DtAtu => MDtAtu,
        DBProCDADicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}