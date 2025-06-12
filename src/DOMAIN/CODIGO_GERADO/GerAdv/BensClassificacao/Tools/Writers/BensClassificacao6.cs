#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IBensClassificacaoWriter
{
    Entity.DBBensClassificacao Write(Models.BensClassificacao bensclassificacao, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(BensClassificacaoResponse bensclassificacao, int operadorId, MsiSqlConnection oCnn);
}

public class BensClassificacao : IBensClassificacaoWriter
{
    public void Delete(BensClassificacaoResponse bensclassificacao, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[BensClassificacao] WHERE bcsCodigo={bensclassificacao.Id};", oCnn);
    }

    public Entity.DBBensClassificacao Write(Models.BensClassificacao bensclassificacao, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = bensclassificacao.Id.IsEmptyIDNumber() ? new Entity.DBBensClassificacao() : new Entity.DBBensClassificacao(bensclassificacao.Id, oCnn);
        dbRec.FNome = bensclassificacao.Nome;
        dbRec.FBold = bensclassificacao.Bold;
        dbRec.FGUID = bensclassificacao.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}