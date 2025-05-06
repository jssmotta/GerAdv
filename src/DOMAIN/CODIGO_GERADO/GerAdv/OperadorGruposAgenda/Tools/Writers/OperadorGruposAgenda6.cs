#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOperadorGruposAgendaWriter
{
    Entity.DBOperadorGruposAgenda Write(Models.OperadorGruposAgenda operadorgruposagenda, int auditorQuem, SqlConnection oCnn);
}

public class OperadorGruposAgenda : IOperadorGruposAgendaWriter
{
    public Entity.DBOperadorGruposAgenda Write(Models.OperadorGruposAgenda operadorgruposagenda, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = operadorgruposagenda.Id.IsEmptyIDNumber() ? new Entity.DBOperadorGruposAgenda() : new Entity.DBOperadorGruposAgenda(operadorgruposagenda.Id, oCnn);
        dbRec.FSQLWhere = operadorgruposagenda.SQLWhere;
        dbRec.FNome = operadorgruposagenda.Nome;
        dbRec.FOperador = operadorgruposagenda.Operador;
        dbRec.FGUID = operadorgruposagenda.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}