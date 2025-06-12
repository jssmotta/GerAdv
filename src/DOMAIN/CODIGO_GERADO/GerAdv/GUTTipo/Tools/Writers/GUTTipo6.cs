#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGUTTipoWriter
{
    Entity.DBGUTTipo Write(Models.GUTTipo guttipo, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(GUTTipoResponse guttipo, int operadorId, MsiSqlConnection oCnn);
}

public class GUTTipo : IGUTTipoWriter
{
    public void Delete(GUTTipoResponse guttipo, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[GUTTipo] WHERE gttCodigo={guttipo.Id};", oCnn);
    }

    public Entity.DBGUTTipo Write(Models.GUTTipo guttipo, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = guttipo.Id.IsEmptyIDNumber() ? new Entity.DBGUTTipo() : new Entity.DBGUTTipo(guttipo.Id, oCnn);
        dbRec.FNome = guttipo.Nome;
        dbRec.FOrdem = guttipo.Ordem;
        dbRec.FGUID = guttipo.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}