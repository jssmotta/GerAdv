#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAcaoWriter
{
    Entity.DBAcao Write(Models.Acao acao, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(AcaoResponse acao, int operadorId, MsiSqlConnection oCnn);
}

public class Acao : IAcaoWriter
{
    public void Delete(AcaoResponse acao, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[Acao] WHERE acaCodigo={acao.Id};", oCnn);
    }

    public Entity.DBAcao Write(Models.Acao acao, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = acao.Id.IsEmptyIDNumber() ? new Entity.DBAcao() : new Entity.DBAcao(acao.Id, oCnn);
        dbRec.FJustica = acao.Justica;
        dbRec.FArea = acao.Area;
        dbRec.FDescricao = acao.Descricao;
        dbRec.FGUID = acao.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}