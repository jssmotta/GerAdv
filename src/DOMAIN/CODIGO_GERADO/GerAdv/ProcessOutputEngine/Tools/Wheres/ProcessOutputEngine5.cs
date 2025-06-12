#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProcessOutputEngineWhere
{
    ProcessOutputEngineResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class ProcessOutputEngine : IProcessOutputEngineWhere
{
    public ProcessOutputEngineResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProcessOutputEngine(sqlWhere: where, parameters: parameters, oCnn: oCnn);
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
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return processoutputengine;
    }
}