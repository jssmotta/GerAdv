#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPoderJudiciarioAssociadoWriter
{
    Entity.DBPoderJudiciarioAssociado Write(Models.PoderJudiciarioAssociado poderjudiciarioassociado, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(PoderJudiciarioAssociadoResponse poderjudiciarioassociado, int operadorId, MsiSqlConnection oCnn);
}

public class PoderJudiciarioAssociado : IPoderJudiciarioAssociadoWriter
{
    public void Delete(PoderJudiciarioAssociadoResponse poderjudiciarioassociado, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[PoderJudiciarioAssociado] WHERE pjaCodigo={poderjudiciarioassociado.Id};", oCnn);
    }

    public Entity.DBPoderJudiciarioAssociado Write(Models.PoderJudiciarioAssociado poderjudiciarioassociado, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = poderjudiciarioassociado.Id.IsEmptyIDNumber() ? new Entity.DBPoderJudiciarioAssociado() : new Entity.DBPoderJudiciarioAssociado(poderjudiciarioassociado.Id, oCnn);
        dbRec.FJustica = poderjudiciarioassociado.Justica;
        dbRec.FJusticaNome = poderjudiciarioassociado.JusticaNome;
        dbRec.FArea = poderjudiciarioassociado.Area;
        dbRec.FAreaNome = poderjudiciarioassociado.AreaNome;
        dbRec.FTribunal = poderjudiciarioassociado.Tribunal;
        dbRec.FTribunalNome = poderjudiciarioassociado.TribunalNome;
        dbRec.FForo = poderjudiciarioassociado.Foro;
        dbRec.FForoNome = poderjudiciarioassociado.ForoNome;
        dbRec.FCidade = poderjudiciarioassociado.Cidade;
        dbRec.FSubDivisaoNome = poderjudiciarioassociado.SubDivisaoNome;
        dbRec.FCidadeNome = poderjudiciarioassociado.CidadeNome;
        dbRec.FSubDivisao = poderjudiciarioassociado.SubDivisao;
        dbRec.FTipo = poderjudiciarioassociado.Tipo;
        dbRec.FGUID = poderjudiciarioassociado.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}