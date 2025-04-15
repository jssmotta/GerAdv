#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProcessOutputEngineReader
{
    ProcessOutputEngineResponse? Read(int id, SqlConnection oCnn);
    ProcessOutputEngineResponse? Read(string where, SqlConnection oCnn);
    ProcessOutputEngineResponse? Read(Entity.DBProcessOutputEngine dbRec);
    ProcessOutputEngineResponse? Read(DBProcessOutputEngine dbRec);
}

public partial class ProcessOutputEngine : IProcessOutputEngineReader
{
    public ProcessOutputEngineResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProcessOutputEngine(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProcessOutputEngineResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProcessOutputEngine(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProcessOutputEngineResponse? Read(Entity.DBProcessOutputEngine dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var processoutputengine = new ProcessOutputEngineResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Database = dbRec.FDatabase ?? string.Empty,
            Tabela = dbRec.FTabela ?? string.Empty,
            Campo = dbRec.FCampo ?? string.Empty,
            Valor = dbRec.FValor ?? string.Empty,
            Output = dbRec.FOutput ?? string.Empty,
            Administrador = dbRec.FAdministrador,
            OutputSource = dbRec.FOutputSource,
            DisabledItem = dbRec.FDisabledItem,
            IDModulo = dbRec.FIDModulo,
            IsOnlyProcesso = dbRec.FIsOnlyProcesso,
            MyID = dbRec.FMyID,
            Guid = dbRec.FGUID ?? string.Empty,
        };
        return processoutputengine;
    }

    public ProcessOutputEngineResponse? Read(DBProcessOutputEngine dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var processoutputengine = new ProcessOutputEngineResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Database = dbRec.FDatabase ?? string.Empty,
            Tabela = dbRec.FTabela ?? string.Empty,
            Campo = dbRec.FCampo ?? string.Empty,
            Valor = dbRec.FValor ?? string.Empty,
            Output = dbRec.FOutput ?? string.Empty,
            Administrador = dbRec.FAdministrador,
            OutputSource = dbRec.FOutputSource,
            DisabledItem = dbRec.FDisabledItem,
            IDModulo = dbRec.FIDModulo,
            IsOnlyProcesso = dbRec.FIsOnlyProcesso,
            MyID = dbRec.FMyID,
            Guid = dbRec.FGUID ?? string.Empty,
        };
        return processoutputengine;
    }
}