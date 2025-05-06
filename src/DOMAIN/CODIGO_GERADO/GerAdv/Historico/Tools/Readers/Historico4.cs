#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IHistoricoReader
{
    HistoricoResponse? Read(int id, SqlConnection oCnn);
    HistoricoResponse? Read(string where, SqlConnection oCnn);
    HistoricoResponse? Read(Entity.DBHistorico dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    HistoricoResponse? Read(DBHistorico dbRec);
}

public partial class Historico : IHistoricoReader
{
    public HistoricoResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBHistorico(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public HistoricoResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBHistorico(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public HistoricoResponse? Read(Entity.DBHistorico dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var historico = new HistoricoResponse
        {
            Id = dbRec.ID,
            ExtraID = dbRec.FExtraID,
            IDNE = dbRec.FIDNE, 
            LiminarOrigem = dbRec.FLiminarOrigem,
            NaoPublicavel = dbRec.FNaoPublicavel,
            Processo = dbRec.FProcesso,
            Precatoria = dbRec.FPrecatoria,
            Apenso = dbRec.FApenso,
            IDInstProcesso = dbRec.FIDInstProcesso,
            Fase = dbRec.FFase,
            Observacao = dbRec.FObservacao ?? string.Empty,
            Agendado = dbRec.FAgendado,
            Concluido = dbRec.FConcluido,
            MesmaAgenda = dbRec.FMesmaAgenda,
            SAD = dbRec.FSAD,
            Resumido = dbRec.FResumido,
            StatusAndamento = dbRec.FStatusAndamento,
            Top = dbRec.FTop,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            historico.Data = dbRec.FData;
        var auditor = new Auditor
        {
            Visto = dbRec.FVisto,
            QuemCad = dbRec.FQuemCad
        };
        if (auditor.QuemAtu > 0)
            auditor.QuemAtu = dbRec.FQuemAtu;
        if (dbRec.FDtCad.NotIsEmpty())
            auditor.DtCad = Convert.ToDateTime(dbRec.FDtCad);
        if (!(dbRec.FDtAtu is { }))
            auditor.DtAtu = Convert.ToDateTime(dbRec.FDtAtu);
        historico.Auditor = auditor;
        return historico;
    }

    public HistoricoResponse? Read(DBHistorico dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var historico = new HistoricoResponse
        {
            Id = dbRec.ID,
            ExtraID = dbRec.FExtraID,
            IDNE = dbRec.FIDNE,
            GUID = dbRec.FExtraGUID ?? string.Empty,
            LiminarOrigem = dbRec.FLiminarOrigem,
            NaoPublicavel = dbRec.FNaoPublicavel,
            Processo = dbRec.FProcesso,
            Precatoria = dbRec.FPrecatoria,
            Apenso = dbRec.FApenso,
            IDInstProcesso = dbRec.FIDInstProcesso,
            Fase = dbRec.FFase,
            Observacao = dbRec.FObservacao ?? string.Empty,
            Agendado = dbRec.FAgendado,
            Concluido = dbRec.FConcluido,
            MesmaAgenda = dbRec.FMesmaAgenda,
            SAD = dbRec.FSAD,
            Resumido = dbRec.FResumido,
            StatusAndamento = dbRec.FStatusAndamento,
            Top = dbRec.FTop
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            historico.Data = dbRec.FData;
        var auditor = new Auditor
        {
            Visto = dbRec.FVisto,
            QuemCad = dbRec.FQuemCad
        };
        if (auditor.QuemAtu > 0)
            auditor.QuemAtu = dbRec.FQuemAtu;
        if (dbRec.FDtCad.NotIsEmpty())
            auditor.DtCad = Convert.ToDateTime(dbRec.FDtCad);
        if (!(dbRec.FDtAtu is { }))
            auditor.DtAtu = Convert.ToDateTime(dbRec.FDtAtu);
        historico.Auditor = auditor;
        return historico;
    }
}