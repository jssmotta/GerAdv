#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOperadorGruposAgendaWhere
{
    OperadorGruposAgendaResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class OperadorGruposAgenda : IOperadorGruposAgendaWhere
{
    public OperadorGruposAgendaResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOperadorGruposAgenda(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var operadorgruposagenda = new OperadorGruposAgendaResponse
        {
            Id = dbRec.ID,
            SQLWhere = dbRec.FSQLWhere ?? string.Empty,
            Nome = dbRec.FNome ?? string.Empty,
            Operador = dbRec.FOperador,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return operadorgruposagenda;
    }
}