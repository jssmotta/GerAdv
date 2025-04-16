#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGUTMatrizWriter
{
    Entity.DBGUTMatriz Write(Models.GUTMatriz gutmatriz, SqlConnection oCnn);
}

public class GUTMatriz : IGUTMatrizWriter
{
    public Entity.DBGUTMatriz Write(Models.GUTMatriz gutmatriz, SqlConnection oCnn)
    {
        var dbRec = gutmatriz.Id.IsEmptyIDNumber() ? new Entity.DBGUTMatriz() : new Entity.DBGUTMatriz(gutmatriz.Id, oCnn);
        dbRec.FDescricao = gutmatriz.Descricao;
        dbRec.FGUTTipo = gutmatriz.GUTTipo;
        dbRec.FValor = gutmatriz.Valor;
        dbRec.Update(oCnn);
        return dbRec;
    }
}