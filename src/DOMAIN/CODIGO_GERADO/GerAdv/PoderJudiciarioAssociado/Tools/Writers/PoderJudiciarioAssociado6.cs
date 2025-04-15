#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPoderJudiciarioAssociadoWriter
{
    Entity.DBPoderJudiciarioAssociado Write(Models.PoderJudiciarioAssociado poderjudiciarioassociado, int auditorQuem, SqlConnection oCnn);
}

public class PoderJudiciarioAssociado : IPoderJudiciarioAssociadoWriter
{
    public Entity.DBPoderJudiciarioAssociado Write(Models.PoderJudiciarioAssociado poderjudiciarioassociado, int auditorQuem, SqlConnection oCnn)
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
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}