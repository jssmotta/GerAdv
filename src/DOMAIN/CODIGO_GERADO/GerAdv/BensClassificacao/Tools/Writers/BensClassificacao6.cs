#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IBensClassificacaoWriter
{
    Entity.DBBensClassificacao Write(Models.BensClassificacao bensclassificacao, int auditorQuem, SqlConnection oCnn);
}

public class BensClassificacao : IBensClassificacaoWriter
{
    public Entity.DBBensClassificacao Write(Models.BensClassificacao bensclassificacao, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = bensclassificacao.Id.IsEmptyIDNumber() ? new Entity.DBBensClassificacao() : new Entity.DBBensClassificacao(bensclassificacao.Id, oCnn);
        dbRec.FNome = bensclassificacao.Nome;
        dbRec.FBold = bensclassificacao.Bold;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}