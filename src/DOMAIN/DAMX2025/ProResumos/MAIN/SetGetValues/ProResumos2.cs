namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProResumos
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBProResumosDicInfo.Processo:
                FProcesso = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProResumosDicInfo.Data:
                FData = $"{value}"; // rgo J3: DateTime
                return;
            case DBProResumosDicInfo.Resumo:
                FResumo = $"{value}"; // rgo J3: string
                return;
            case DBProResumosDicInfo.TipoResumo:
                FTipoResumo = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProResumosDicInfo.Bold:
                FBold = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBProResumosDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBProResumosDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProResumosDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBProResumosDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProResumosDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBProResumosDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBProResumosDicInfo.Processo => NFProcesso(),
        DBProResumosDicInfo.Data => NFData(),
        DBProResumosDicInfo.Resumo => NFResumo(),
        DBProResumosDicInfo.TipoResumo => NFTipoResumo(),
        DBProResumosDicInfo.Bold => FBold.ToString(),
        DBProResumosDicInfo.GUID => NFGUID(),
        DBProResumosDicInfo.QuemCad => NFQuemCad(),
        DBProResumosDicInfo.DtCad => MDtCad,
        DBProResumosDicInfo.QuemAtu => NFQuemAtu(),
        DBProResumosDicInfo.DtAtu => MDtAtu,
        DBProResumosDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}