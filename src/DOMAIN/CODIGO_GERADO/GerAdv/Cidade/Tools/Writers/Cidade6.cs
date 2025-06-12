#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ICidadeWriter
{
    Entity.DBCidade Write(Models.Cidade cidade, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(CidadeResponse cidade, int operadorId, MsiSqlConnection oCnn);
}

public class Cidade : ICidadeWriter
{
    public void Delete(CidadeResponse cidade, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[Cidade] WHERE cidCodigo={cidade.Id};", oCnn);
    }

    public Entity.DBCidade Write(Models.Cidade cidade, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = cidade.Id.IsEmptyIDNumber() ? new Entity.DBCidade() : new Entity.DBCidade(cidade.Id, oCnn);
        dbRec.FDDD = cidade.DDD;
        dbRec.FTop = cidade.Top;
        dbRec.FComarca = cidade.Comarca;
        dbRec.FCapital = cidade.Capital;
        dbRec.FNome = cidade.Nome;
        dbRec.FUF = cidade.UF;
        dbRec.FSigla = cidade.Sigla;
        dbRec.FGUID = cidade.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}