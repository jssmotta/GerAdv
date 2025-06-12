#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPaisesWriter
{
    Entity.DBPaises Write(Models.Paises paises, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(PaisesResponse paises, int operadorId, MsiSqlConnection oCnn);
}

public class Paises : IPaisesWriter
{
    public void Delete(PaisesResponse paises, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[Paises] WHERE paiCodigo={paises.Id};", oCnn);
    }

    public Entity.DBPaises Write(Models.Paises paises, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = paises.Id.IsEmptyIDNumber() ? new Entity.DBPaises() : new Entity.DBPaises(paises.Id, oCnn);
        dbRec.FNome = paises.Nome;
        dbRec.FGUID = paises.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}