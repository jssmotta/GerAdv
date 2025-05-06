#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IHistoricoWriter
{
    Entity.DBHistorico Write(Models.Historico historico, int auditorQuem, SqlConnection oCnn);
}

public class Historico : IHistoricoWriter
{
    public Entity.DBHistorico Write(Models.Historico historico, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = historico.Id.IsEmptyIDNumber() ? new Entity.DBHistorico() : new Entity.DBHistorico(historico.Id, oCnn);
        dbRec.FExtraID = historico.ExtraID;
        dbRec.FIDNE = historico.IDNE;
        dbRec.FGUID = historico.GUID;
        dbRec.FLiminarOrigem = historico.LiminarOrigem;
        dbRec.FNaoPublicavel = historico.NaoPublicavel;
        dbRec.FProcesso = historico.Processo;
        dbRec.FPrecatoria = historico.Precatoria;
        dbRec.FApenso = historico.Apenso;
        dbRec.FIDInstProcesso = historico.IDInstProcesso;
        dbRec.FFase = historico.Fase;
        if (historico.Data != null)
            dbRec.FData = historico.Data.ToString();
        dbRec.FObservacao = historico.Observacao;
        dbRec.FAgendado = historico.Agendado;
        dbRec.FConcluido = historico.Concluido;
        dbRec.FMesmaAgenda = historico.MesmaAgenda;
        dbRec.FSAD = historico.SAD;
        dbRec.FResumido = historico.Resumido;
        dbRec.FStatusAndamento = historico.StatusAndamento;
        dbRec.FTop = historico.Top;
        dbRec.FGUID = historico.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}