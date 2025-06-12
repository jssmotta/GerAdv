#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoEnderecoWriter
{
    Entity.DBTipoEndereco Write(Models.TipoEndereco tipoendereco, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(TipoEnderecoResponse tipoendereco, int operadorId, MsiSqlConnection oCnn);
}

public class TipoEndereco : ITipoEnderecoWriter
{
    public void Delete(TipoEnderecoResponse tipoendereco, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[TipoEndereco] WHERE tipCodigo={tipoendereco.Id};", oCnn);
    }

    public Entity.DBTipoEndereco Write(Models.TipoEndereco tipoendereco, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = tipoendereco.Id.IsEmptyIDNumber() ? new Entity.DBTipoEndereco() : new Entity.DBTipoEndereco(tipoendereco.Id, oCnn);
        dbRec.FDescricao = tipoendereco.Descricao;
        dbRec.FGUID = tipoendereco.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}