#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOperadorGruposAgendaOperadoresWriter
{
    Entity.DBOperadorGruposAgendaOperadores Write(Models.OperadorGruposAgendaOperadores operadorgruposagendaoperadores, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(OperadorGruposAgendaOperadoresResponse operadorgruposagendaoperadores, int operadorId, MsiSqlConnection oCnn);
}

public class OperadorGruposAgendaOperadores : IOperadorGruposAgendaOperadoresWriter
{
    public void Delete(OperadorGruposAgendaOperadoresResponse operadorgruposagendaoperadores, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[OperadorGruposAgendaOperadores] WHERE ogpCodigo={operadorgruposagendaoperadores.Id};", oCnn);
    }

    public Entity.DBOperadorGruposAgendaOperadores Write(Models.OperadorGruposAgendaOperadores operadorgruposagendaoperadores, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = operadorgruposagendaoperadores.Id.IsEmptyIDNumber() ? new Entity.DBOperadorGruposAgendaOperadores() : new Entity.DBOperadorGruposAgendaOperadores(operadorgruposagendaoperadores.Id, oCnn);
        dbRec.FOperadorGruposAgenda = operadorgruposagendaoperadores.OperadorGruposAgenda;
        dbRec.FOperador = operadorgruposagendaoperadores.Operador;
        dbRec.FGUID = operadorgruposagendaoperadores.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}