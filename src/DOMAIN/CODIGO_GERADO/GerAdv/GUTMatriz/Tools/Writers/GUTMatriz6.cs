#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGUTMatrizWriter
{
    Entity.DBGUTMatriz Write(Models.GUTMatriz gutmatriz, MsiSqlConnection oCnn);
    void Delete(GUTMatrizResponse gutmatriz, int operadorId, MsiSqlConnection oCnn);
}

public class GUTMatriz : IGUTMatrizWriter
{
    public void Delete(GUTMatrizResponse gutmatriz, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[GUTMatriz] WHERE gutCodigo={gutmatriz.Id};", oCnn);
    }

    public Entity.DBGUTMatriz Write(Models.GUTMatriz gutmatriz, MsiSqlConnection oCnn)
    {
        var dbRec = gutmatriz.Id.IsEmptyIDNumber() ? new Entity.DBGUTMatriz() : new Entity.DBGUTMatriz(gutmatriz.Id, oCnn);
        dbRec.FDescricao = gutmatriz.Descricao;
        dbRec.FGUTTipo = gutmatriz.GUTTipo;
        dbRec.FValor = gutmatriz.Valor;
        dbRec.Update(oCnn);
        return dbRec;
    }
}