#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOperadorGruposAgendaOperadoresWriter
{
    Entity.DBOperadorGruposAgendaOperadores Write(Models.OperadorGruposAgendaOperadores operadorgruposagendaoperadores, int auditorQuem, SqlConnection oCnn);
}

public class OperadorGruposAgendaOperadores : IOperadorGruposAgendaOperadoresWriter
{
    public Entity.DBOperadorGruposAgendaOperadores Write(Models.OperadorGruposAgendaOperadores operadorgruposagendaoperadores, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = operadorgruposagendaoperadores.Id.IsEmptyIDNumber() ? new Entity.DBOperadorGruposAgendaOperadores() : new Entity.DBOperadorGruposAgendaOperadores(operadorgruposagendaoperadores.Id, oCnn);
        dbRec.FOperadorGruposAgenda = operadorgruposagendaoperadores.OperadorGruposAgenda;
        dbRec.FOperador = operadorgruposagendaoperadores.Operador;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}