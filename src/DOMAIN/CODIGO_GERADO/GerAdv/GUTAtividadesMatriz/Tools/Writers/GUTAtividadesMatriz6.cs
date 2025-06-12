#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGUTAtividadesMatrizWriter
{
    Entity.DBGUTAtividadesMatriz Write(Models.GUTAtividadesMatriz gutatividadesmatriz, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(GUTAtividadesMatrizResponse gutatividadesmatriz, int operadorId, MsiSqlConnection oCnn);
}

public class GUTAtividadesMatriz : IGUTAtividadesMatrizWriter
{
    public void Delete(GUTAtividadesMatrizResponse gutatividadesmatriz, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[GUTAtividadesMatriz] WHERE amgCodigo={gutatividadesmatriz.Id};", oCnn);
    }

    public Entity.DBGUTAtividadesMatriz Write(Models.GUTAtividadesMatriz gutatividadesmatriz, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = gutatividadesmatriz.Id.IsEmptyIDNumber() ? new Entity.DBGUTAtividadesMatriz() : new Entity.DBGUTAtividadesMatriz(gutatividadesmatriz.Id, oCnn);
        dbRec.FGUTMatriz = gutatividadesmatriz.GUTMatriz;
        dbRec.FGUTAtividade = gutatividadesmatriz.GUTAtividade;
        dbRec.FGUID = gutatividadesmatriz.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}