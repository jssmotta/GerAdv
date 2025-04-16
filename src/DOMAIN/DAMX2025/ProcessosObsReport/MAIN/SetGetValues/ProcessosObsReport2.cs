namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProcessosObsReport
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBProcessosObsReportDicInfo.Data:
                FData = $"{value}"; // rgo J3: DateTime
                return;
            case DBProcessosObsReportDicInfo.Processo:
                FProcesso = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProcessosObsReportDicInfo.Observacao:
                FObservacao = $"{value}"; // rgo J3: string
                return;
            case DBProcessosObsReportDicInfo.Historico:
                FHistorico = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProcessosObsReportDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProcessosObsReportDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBProcessosObsReportDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProcessosObsReportDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBProcessosObsReportDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBProcessosObsReportDicInfo.Data => NFData(),
        DBProcessosObsReportDicInfo.Processo => NFProcesso(),
        DBProcessosObsReportDicInfo.Observacao => NFObservacao(),
        DBProcessosObsReportDicInfo.Historico => NFHistorico(),
        DBProcessosObsReportDicInfo.QuemCad => NFQuemCad(),
        DBProcessosObsReportDicInfo.DtCad => MDtCad,
        DBProcessosObsReportDicInfo.QuemAtu => NFQuemAtu(),
        DBProcessosObsReportDicInfo.DtAtu => MDtAtu,
        DBProcessosObsReportDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}