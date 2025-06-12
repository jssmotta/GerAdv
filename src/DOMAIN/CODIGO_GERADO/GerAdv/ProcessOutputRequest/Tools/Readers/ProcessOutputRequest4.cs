#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProcessOutputRequestReader
{
    ProcessOutputRequestResponse? Read(int id, MsiSqlConnection oCnn);
    ProcessOutputRequestResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProcessOutputRequestResponse? Read(Entity.DBProcessOutputRequest dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProcessOutputRequestResponse? Read(DBProcessOutputRequest dbRec);
    ProcessOutputRequestResponseAll? ReadAll(DBProcessOutputRequest dbRec, DataRow dr);
}

public partial class ProcessOutputRequest : IProcessOutputRequestReader
{
    public ProcessOutputRequestResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProcessOutputRequest(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProcessOutputRequestResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProcessOutputRequest(sqlWhere: where, parameters: parameters, oCnn: oCnn);
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
            GUID = dbRec.FGUID ?? string.Empty,
        };
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
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return processoutputrequest;
    }

    public ProcessOutputRequestResponseAll? ReadAll(DBProcessOutputRequest dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var processoutputrequest = new ProcessOutputRequestResponseAll
        {
            Id = dbRec.ID,
            ProcessOutputEngine = dbRec.FProcessOutputEngine,
            Operador = dbRec.FOperador,
            Processo = dbRec.FProcesso,
            UltimoIdTabelaExo = dbRec.FUltimoIdTabelaExo,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        processoutputrequest.NomeProcessOutputEngine = dr["poeNome"]?.ToString() ?? string.Empty;
        processoutputrequest.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        processoutputrequest.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return processoutputrequest;
    }
}