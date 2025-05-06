#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoEnderecoSistemaWriter
{
    Entity.DBTipoEnderecoSistema Write(Models.TipoEnderecoSistema tipoenderecosistema, int auditorQuem, SqlConnection oCnn);
}

public class TipoEnderecoSistema : ITipoEnderecoSistemaWriter
{
    public Entity.DBTipoEnderecoSistema Write(Models.TipoEnderecoSistema tipoenderecosistema, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = tipoenderecosistema.Id.IsEmptyIDNumber() ? new Entity.DBTipoEnderecoSistema() : new Entity.DBTipoEnderecoSistema(tipoenderecosistema.Id, oCnn);
        dbRec.FNome = tipoenderecosistema.Nome;
        dbRec.FGUID = tipoenderecosistema.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}