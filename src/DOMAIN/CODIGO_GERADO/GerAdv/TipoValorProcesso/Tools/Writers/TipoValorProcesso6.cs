#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoValorProcessoWriter
{
    Entity.DBTipoValorProcesso Write(Models.TipoValorProcesso tipovalorprocesso, SqlConnection oCnn);
}

public class TipoValorProcesso : ITipoValorProcessoWriter
{
    public Entity.DBTipoValorProcesso Write(Models.TipoValorProcesso tipovalorprocesso, SqlConnection oCnn)
    {
        var dbRec = tipovalorprocesso.Id.IsEmptyIDNumber() ? new Entity.DBTipoValorProcesso() : new Entity.DBTipoValorProcesso(tipovalorprocesso.Id, oCnn);
        dbRec.FDescricao = tipovalorprocesso.Descricao;
        dbRec.Update(oCnn);
        return dbRec;
    }
}