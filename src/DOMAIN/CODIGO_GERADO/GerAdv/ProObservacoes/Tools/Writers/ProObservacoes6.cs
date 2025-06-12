#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProObservacoesWriter
{
    Entity.DBProObservacoes Write(Models.ProObservacoes proobservacoes, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(ProObservacoesResponse proobservacoes, int operadorId, MsiSqlConnection oCnn);
}

public class ProObservacoes : IProObservacoesWriter
{
    public void Delete(ProObservacoesResponse proobservacoes, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[ProObservacoes] WHERE pobCodigo={proobservacoes.Id};", oCnn);
    }

    public Entity.DBProObservacoes Write(Models.ProObservacoes proobservacoes, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = proobservacoes.Id.IsEmptyIDNumber() ? new Entity.DBProObservacoes() : new Entity.DBProObservacoes(proobservacoes.Id, oCnn);
        dbRec.FProcesso = proobservacoes.Processo;
        dbRec.FNome = proobservacoes.Nome;
        dbRec.FObservacoes = proobservacoes.Observacoes;
        if (proobservacoes.Data != null)
            dbRec.FData = proobservacoes.Data.ToString();
        dbRec.FGUID = proobservacoes.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}