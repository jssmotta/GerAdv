namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBPrecatoria
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBPrecatoriaDicInfo.DtDist:
                FDtDist = $"{value}"; // rgo J3: DateTime
                return;
            case DBPrecatoriaDicInfo.Processo:
                FProcesso = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBPrecatoriaDicInfo.Precatoria:
                FPrecatoria = $"{value}"; // rgo J3: string
                return;
            case DBPrecatoriaDicInfo.Deprecante:
                FDeprecante = $"{value}"; // rgo J3: string
                return;
            case DBPrecatoriaDicInfo.Deprecado:
                FDeprecado = $"{value}"; // rgo J3: string
                return;
            case DBPrecatoriaDicInfo.OBS:
                FOBS = $"{value}"; // rgo J3: string
                return;
            case DBPrecatoriaDicInfo.Bold:
                FBold = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBPrecatoriaDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBPrecatoriaDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBPrecatoriaDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBPrecatoriaDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBPrecatoriaDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBPrecatoriaDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBPrecatoriaDicInfo.DtDist => NFDtDist(),
        DBPrecatoriaDicInfo.Processo => NFProcesso(),
        DBPrecatoriaDicInfo.Precatoria => NFPrecatoria(),
        DBPrecatoriaDicInfo.Deprecante => NFDeprecante(),
        DBPrecatoriaDicInfo.Deprecado => NFDeprecado(),
        DBPrecatoriaDicInfo.OBS => NFOBS(),
        DBPrecatoriaDicInfo.Bold => FBold.ToString(),
        DBPrecatoriaDicInfo.GUID => NFGUID(),
        DBPrecatoriaDicInfo.QuemCad => NFQuemCad(),
        DBPrecatoriaDicInfo.DtCad => MDtCad,
        DBPrecatoriaDicInfo.QuemAtu => NFQuemAtu(),
        DBPrecatoriaDicInfo.DtAtu => MDtAtu,
        DBPrecatoriaDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}