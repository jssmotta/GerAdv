#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOperadorGruposAgendaWriter
{
    Entity.DBOperadorGruposAgenda Write(Models.OperadorGruposAgenda operadorgruposagenda, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(OperadorGruposAgendaResponse operadorgruposagenda, int operadorId, MsiSqlConnection oCnn);
}

public class OperadorGruposAgenda : IOperadorGruposAgendaWriter
{
    public void Delete(OperadorGruposAgendaResponse operadorgruposagenda, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[OperadorGruposAgenda] WHERE groCodigo={operadorgruposagenda.Id};", oCnn);
    }

    public Entity.DBOperadorGruposAgenda Write(Models.OperadorGruposAgenda operadorgruposagenda, int auditorQuem, MsiSqlConnection oCnn)
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