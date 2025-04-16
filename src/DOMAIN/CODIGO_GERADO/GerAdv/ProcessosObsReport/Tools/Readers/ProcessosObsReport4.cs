#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProcessosObsReportReader
{
    ProcessosObsReportResponse? Read(int id, SqlConnection oCnn);
    ProcessosObsReportResponse? Read(string where, SqlConnection oCnn);
    ProcessosObsReportResponse? Read(Entity.DBProcessosObsReport dbRec);
    ProcessosObsReportResponse? Read(DBProcessosObsReport dbRec);
}

public partial class ProcessosObsReport : IProcessosObsReportReader
{
    public ProcessosObsReportResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProcessosObsReport(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProcessosObsReportResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProcessosObsReport(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProcessosObsReportResponse? Read(Entity.DBProcessosObsReport dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var processosobsreport = new ProcessosObsReportResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Observacao = dbRec.FObservacao ?? string.Empty,
            Historico = dbRec.FHistorico,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            processosobsreport.Data = dbRec.FData;
        var auditor = new Auditor
        {
            Visto = dbRec.FVisto,
            QuemCad = dbRec.FQuemCad
        };
        if (auditor.QuemAtu > 0)
            auditor.QuemAtu = dbRec.FQuemAtu;
        if (dbRec.FDtCad.NotIsEmpty())
            auditor.DtCad = Convert.ToDateTime(dbRec.FDtCad);
        if (!(dbRec.FDtAtu is { }))
            auditor.DtAtu = Convert.ToDateTime(dbRec.FDtAtu);
        processosobsreport.Auditor = auditor;
        return processosobsreport;
    }

    public ProcessosObsReportResponse? Read(DBProcessosObsReport dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var processosobsreport = new ProcessosObsReportResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Observacao = dbRec.FObservacao ?? string.Empty,
            Historico = dbRec.FHistorico,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            processosobsreport.Data = dbRec.FData;
        var auditor = new Auditor
        {
            Visto = dbRec.FVisto,
            QuemCad = dbRec.FQuemCad
        };
        if (auditor.QuemAtu > 0)
            auditor.QuemAtu = dbRec.FQuemAtu;
        if (dbRec.FDtCad.NotIsEmpty())
            auditor.DtCad = Convert.ToDateTime(dbRec.FDtCad);
        if (!(dbRec.FDtAtu is { }))
            auditor.DtAtu = Convert.ToDateTime(dbRec.FDtAtu);
        processosobsreport.Auditor = auditor;
        return processosobsreport;
    }
}