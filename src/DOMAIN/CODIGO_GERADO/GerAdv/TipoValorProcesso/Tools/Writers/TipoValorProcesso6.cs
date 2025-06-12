#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoValorProcessoWriter
{
    Entity.DBTipoValorProcesso Write(Models.TipoValorProcesso tipovalorprocesso, MsiSqlConnection oCnn);
    void Delete(TipoValorProcessoResponse tipovalorprocesso, int operadorId, MsiSqlConnection oCnn);
}

public class TipoValorProcesso : ITipoValorProcessoWriter
{
    public void Delete(TipoValorProcessoResponse tipovalorprocesso, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[TipoValorProcesso] WHERE ptvCodigo={tipovalorprocesso.Id};", oCnn);
    }

    public Entity.DBTipoValorProcesso Write(Models.TipoValorProcesso tipovalorprocesso, MsiSqlConnection oCnn)
    {
        var dbRec = tipovalorprocesso.Id.IsEmptyIDNumber() ? new Entity.DBTipoValorProcesso() : new Entity.DBTipoValorProcesso(tipovalorprocesso.Id, oCnn);
        dbRec.FDescricao = tipovalorprocesso.Descricao;
        dbRec.FGUID = tipovalorprocesso.GUID;
        dbRec.Update(oCnn);
        return dbRec;
    }
}