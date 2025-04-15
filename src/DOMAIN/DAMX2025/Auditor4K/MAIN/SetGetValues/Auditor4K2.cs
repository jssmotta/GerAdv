namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAuditor4K
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBAuditor4KDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBAuditor4KDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBAuditor4KDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAuditor4KDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBAuditor4KDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAuditor4KDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBAuditor4KDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBAuditor4KDicInfo.Nome => NFNome(),
        DBAuditor4KDicInfo.GUID => NFGUID(),
        DBAuditor4KDicInfo.QuemCad => NFQuemCad(),
        DBAuditor4KDicInfo.DtCad => MDtCad,
        DBAuditor4KDicInfo.QuemAtu => NFQuemAtu(),
        DBAuditor4KDicInfo.DtAtu => MDtAtu,
        DBAuditor4KDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}