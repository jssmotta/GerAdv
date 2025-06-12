#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITribunalWriter
{
    Entity.DBTribunal Write(Models.Tribunal tribunal, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(TribunalResponse tribunal, int operadorId, MsiSqlConnection oCnn);
}

public class Tribunal : ITribunalWriter
{
    public void Delete(TribunalResponse tribunal, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[Tribunal] WHERE triCodigo={tribunal.Id};", oCnn);
    }

    public Entity.DBTribunal Write(Models.Tribunal tribunal, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = tribunal.Id.IsEmptyIDNumber() ? new Entity.DBTribunal() : new Entity.DBTribunal(tribunal.Id, oCnn);
        dbRec.FNome = tribunal.Nome;
        dbRec.FArea = tribunal.Area;
        dbRec.FJustica = tribunal.Justica;
        dbRec.FDescricao = tribunal.Descricao;
        dbRec.FInstancia = tribunal.Instancia;
        dbRec.FSigla = tribunal.Sigla;
        dbRec.FWeb = tribunal.Web;
        dbRec.FEtiqueta = tribunal.Etiqueta;
        dbRec.FBold = tribunal.Bold;
        dbRec.FGUID = tribunal.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}