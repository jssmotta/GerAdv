#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProObservacoesWriter
{
    Entity.DBProObservacoes Write(Models.ProObservacoes proobservacoes, int auditorQuem, SqlConnection oCnn);
}

public class ProObservacoes : IProObservacoesWriter
{
    public Entity.DBProObservacoes Write(Models.ProObservacoes proobservacoes, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = proobservacoes.Id.IsEmptyIDNumber() ? new Entity.DBProObservacoes() : new Entity.DBProObservacoes(proobservacoes.Id, oCnn);
        dbRec.FProcesso = proobservacoes.Processo;
        dbRec.FNome = proobservacoes.Nome;
        dbRec.FObservacoes = proobservacoes.Observacoes;
        if (proobservacoes.Data != null)
            dbRec.FData = proobservacoes.Data.ToString();
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}