#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoEnderecoSistemaWriter
{
    Entity.DBTipoEnderecoSistema Write(Models.TipoEnderecoSistema tipoenderecosistema, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(TipoEnderecoSistemaResponse tipoenderecosistema, int operadorId, MsiSqlConnection oCnn);
}

public class TipoEnderecoSistema : ITipoEnderecoSistemaWriter
{
    public void Delete(TipoEnderecoSistemaResponse tipoenderecosistema, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[TipoEnderecoSistema] WHERE tesCodigo={tipoenderecosistema.Id};", oCnn);
    }

    public Entity.DBTipoEnderecoSistema Write(Models.TipoEnderecoSistema tipoenderecosistema, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = tipoenderecosistema.Id.IsEmptyIDNumber() ? new Entity.DBTipoEnderecoSistema() : new Entity.DBTipoEnderecoSistema(tipoenderecosistema.Id, oCnn);
        dbRec.FNome = tipoenderecosistema.Nome;
        dbRec.FGUID = tipoenderecosistema.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}