namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBParceriaProc
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBParceriaProcDicInfo.Advogado:
                FAdvogado = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBParceriaProcDicInfo.Processo:
                FProcesso = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBParceriaProcDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBParceriaProcDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBParceriaProcDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBParceriaProcDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBParceriaProcDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBParceriaProcDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBParceriaProcDicInfo.Advogado => NFAdvogado(),
        DBParceriaProcDicInfo.Processo => NFProcesso(),
        DBParceriaProcDicInfo.GUID => NFGUID(),
        DBParceriaProcDicInfo.QuemCad => NFQuemCad(),
        DBParceriaProcDicInfo.DtCad => MDtCad,
        DBParceriaProcDicInfo.QuemAtu => NFQuemAtu(),
        DBParceriaProcDicInfo.DtAtu => MDtAtu,
        DBParceriaProcDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}