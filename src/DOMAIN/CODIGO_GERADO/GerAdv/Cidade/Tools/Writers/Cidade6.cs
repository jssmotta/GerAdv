#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ICidadeWriter
{
    Entity.DBCidade Write(Models.Cidade cidade, int auditorQuem, SqlConnection oCnn);
}

public class Cidade : ICidadeWriter
{
    public Entity.DBCidade Write(Models.Cidade cidade, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = cidade.Id.IsEmptyIDNumber() ? new Entity.DBCidade() : new Entity.DBCidade(cidade.Id, oCnn);
        dbRec.FDDD = cidade.DDD;
        dbRec.FTop = cidade.Top;
        dbRec.FComarca = cidade.Comarca;
        dbRec.FCapital = cidade.Capital;
        dbRec.FNome = cidade.Nome;
        dbRec.FUF = cidade.UF;
        dbRec.FSigla = cidade.Sigla;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}