#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProcessosObsReportWriter
{
    Entity.DBProcessosObsReport Write(Models.ProcessosObsReport processosobsreport, int auditorQuem, SqlConnection oCnn);
}

public class ProcessosObsReport : IProcessosObsReportWriter
{
    public Entity.DBProcessosObsReport Write(Models.ProcessosObsReport processosobsreport, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = processosobsreport.Id.IsEmptyIDNumber() ? new Entity.DBProcessosObsReport() : new Entity.DBProcessosObsReport(processosobsreport.Id, oCnn);
        if (processosobsreport.Data != null)
            dbRec.FData = processosobsreport.Data.ToString();
        dbRec.FProcesso = processosobsreport.Processo;
        dbRec.FObservacao = processosobsreport.Observacao;
        dbRec.FHistorico = processosobsreport.Historico;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}