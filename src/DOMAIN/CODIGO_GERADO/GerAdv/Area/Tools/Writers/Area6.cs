#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAreaWriter
{
    Entity.DBArea Write(Models.Area area, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(AreaResponse area, int operadorId, MsiSqlConnection oCnn);
}

public class Area : IAreaWriter
{
    public void Delete(AreaResponse area, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[Area] WHERE areCodigo={area.Id};", oCnn);
    }

    public Entity.DBArea Write(Models.Area area, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = area.Id.IsEmptyIDNumber() ? new Entity.DBArea() : new Entity.DBArea(area.Id, oCnn);
        dbRec.FDescricao = area.Descricao;
        dbRec.FTop = area.Top;
        dbRec.FGUID = area.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}