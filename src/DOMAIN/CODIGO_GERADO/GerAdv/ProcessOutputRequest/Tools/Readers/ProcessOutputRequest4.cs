#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProcessOutputRequestReader
{
    ProcessOutputRequestResponse? Read(int id, SqlConnection oCnn);
    ProcessOutputRequestResponse? Read(string where, SqlConnection oCnn);
    ProcessOutputRequestResponse? Read(Entity.DBProcessOutputRequest dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    ProcessOutputRequestResponse? Read(DBProcessOutputRequest dbRec);
}

public partial class ProcessOutputRequest : IProcessOutputRequestReader
{
    public ProcessOutputRequestResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProcessOutputRequest(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProcessOutputRequestResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProcessOutputRequest(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProcessOutputRequestResponse? Read(Entity.DBProcessOutputRequest dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var processoutputrequest = new ProcessOutputRequestResponse
        {
            Id = dbRec.ID,
            ProcessOutputEngine = dbRec.FProcessOutputEngine,
            Operador = dbRec.FOperador,
            Processo = dbRec.FProcesso,
            UltimoIdTabelaExo = dbRec.FUltimoIdTabelaExo,
            Guid = dbRec.FGUID ?? string.Empty,
        };
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
        processoutputrequest.Auditor = auditor;
        return processoutputrequest;
    }

    public ProcessOutputRequestResponse? Read(DBProcessOutputRequest dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var processoutputrequest = new ProcessOutputRequestResponse
        {
            Id = dbRec.ID,
            ProcessOutputEngine = dbRec.FProcessOutputEngine,
            Operador = dbRec.FOperador,
            Processo = dbRec.FProcesso,
            UltimoIdTabelaExo = dbRec.FUltimoIdTabelaExo,
            Guid = dbRec.FGUID ?? string.Empty,
        };
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
        processoutputrequest.Auditor = auditor;
        return processoutputrequest;
    }
}