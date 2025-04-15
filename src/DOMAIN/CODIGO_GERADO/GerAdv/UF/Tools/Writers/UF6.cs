#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IUFWriter
{
    Entity.DBUF Write(Models.UF uf, int auditorQuem, SqlConnection oCnn);
}

public class UF : IUFWriter
{
    public Entity.DBUF Write(Models.UF uf, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = uf.Id.IsEmptyIDNumber() ? new Entity.DBUF() : new Entity.DBUF(uf.Id, oCnn);
        dbRec.FDDD = uf.DDD;
        dbRec.FID = uf.IdUF;
        dbRec.FPais = uf.Pais;
        dbRec.FTop = uf.Top;
        dbRec.FDescricao = uf.Descricao;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}