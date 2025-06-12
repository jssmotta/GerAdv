#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IStatusTarefasWhere
{
    StatusTarefasResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class StatusTarefas : IStatusTarefasWhere
{
    public StatusTarefasResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBStatusTarefas(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var statustarefas = new StatusTarefasResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return statustarefas;
    }
}