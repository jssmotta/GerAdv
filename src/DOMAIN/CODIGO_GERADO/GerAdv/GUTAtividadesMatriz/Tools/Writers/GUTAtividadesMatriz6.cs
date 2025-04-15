#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGUTAtividadesMatrizWriter
{
    Entity.DBGUTAtividadesMatriz Write(Models.GUTAtividadesMatriz gutatividadesmatriz, int auditorQuem, SqlConnection oCnn);
}

public class GUTAtividadesMatriz : IGUTAtividadesMatrizWriter
{
    public Entity.DBGUTAtividadesMatriz Write(Models.GUTAtividadesMatriz gutatividadesmatriz, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = gutatividadesmatriz.Id.IsEmptyIDNumber() ? new Entity.DBGUTAtividadesMatriz() : new Entity.DBGUTAtividadesMatriz(gutatividadesmatriz.Id, oCnn);
        dbRec.FGUTMatriz = gutatividadesmatriz.GUTMatriz;
        dbRec.FGUTAtividade = gutatividadesmatriz.GUTAtividade;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}