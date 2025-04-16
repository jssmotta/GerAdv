#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoEnderecoWriter
{
    Entity.DBTipoEndereco Write(Models.TipoEndereco tipoendereco, int auditorQuem, SqlConnection oCnn);
}

public class TipoEndereco : ITipoEnderecoWriter
{
    public Entity.DBTipoEndereco Write(Models.TipoEndereco tipoendereco, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = tipoendereco.Id.IsEmptyIDNumber() ? new Entity.DBTipoEndereco() : new Entity.DBTipoEndereco(tipoendereco.Id, oCnn);
        dbRec.FDescricao = tipoendereco.Descricao;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}