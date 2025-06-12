#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IRegimeTributacaoWriter
{
    Entity.DBRegimeTributacao Write(Models.RegimeTributacao regimetributacao, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(RegimeTributacaoResponse regimetributacao, int operadorId, MsiSqlConnection oCnn);
}

public class RegimeTributacao : IRegimeTributacaoWriter
{
    public void Delete(RegimeTributacaoResponse regimetributacao, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[RegimeTributacao] WHERE rdtCodigo={regimetributacao.Id};", oCnn);
    }

    public Entity.DBRegimeTributacao Write(Models.RegimeTributacao regimetributacao, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = regimetributacao.Id.IsEmptyIDNumber() ? new Entity.DBRegimeTributacao() : new Entity.DBRegimeTributacao(regimetributacao.Id, oCnn);
        dbRec.FNome = regimetributacao.Nome;
        dbRec.FGUID = regimetributacao.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}