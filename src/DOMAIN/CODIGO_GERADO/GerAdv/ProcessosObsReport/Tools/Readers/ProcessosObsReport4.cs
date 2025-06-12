#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProcessosObsReportReader
{
    ProcessosObsReportResponse? Read(int id, MsiSqlConnection oCnn);
    ProcessosObsReportResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProcessosObsReportResponse? Read(Entity.DBProcessosObsReport dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProcessosObsReportResponse? Read(DBProcessosObsReport dbRec);
    ProcessosObsReportResponseAll? ReadAll(DBProcessosObsReport dbRec, DataRow dr);
}

public partial class ProcessosObsReport : IProcessosObsReportReader
{
    public ProcessosObsReportResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProcessosObsReport(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProcessosObsReportResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProcessosObsReport(sqlWhere: where, parameters: parameters, oCnn: oCnn);
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
        return processosobsreport;
    }

    public ProcessosObsReportResponseAll? ReadAll(DBProcessosObsReport dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var processosobsreport = new ProcessosObsReportResponseAll
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Observacao = dbRec.FObservacao ?? string.Empty,
            Historico = dbRec.FHistorico,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            processosobsreport.Data = dbRec.FData;
        processosobsreport.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return processosobsreport;
    }
}