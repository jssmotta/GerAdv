#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IFaseWriter
{
    Entity.DBFase Write(Models.Fase fase, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(FaseResponse fase, int operadorId, MsiSqlConnection oCnn);
}

public class Fase : IFaseWriter
{
    public void Delete(FaseResponse fase, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[Fase] WHERE fasCodigo={fase.Id};", oCnn);
    }

    public Entity.DBFase Write(Models.Fase fase, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = fase.Id.IsEmptyIDNumber() ? new Entity.DBFase() : new Entity.DBFase(fase.Id, oCnn);
        dbRec.FDescricao = fase.Descricao;
        dbRec.FJustica = fase.Justica;
        dbRec.FArea = fase.Area;
        dbRec.FGUID = fase.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}