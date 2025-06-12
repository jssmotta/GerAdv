#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IHistoricoReader
{
    HistoricoResponse? Read(int id, MsiSqlConnection oCnn);
    HistoricoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    HistoricoResponse? Read(Entity.DBHistorico dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    HistoricoResponse? Read(DBHistorico dbRec);
    HistoricoResponseAll? ReadAll(DBHistorico dbRec, DataRow dr);
}

public partial class Historico : IHistoricoReader
{
    public HistoricoResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBHistorico(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public HistoricoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBHistorico(sqlWhere: where, parameters: parameters, oCnn: oCnn);
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
            ExtraGUID = dbRec.FExtraGUID ?? string.Empty,
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
            ExtraGUID = dbRec.FExtraGUID ?? string.Empty,
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
        return historico;
    }

    public HistoricoResponseAll? ReadAll(DBHistorico dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var historico = new HistoricoResponseAll
        {
            Id = dbRec.ID,
            ExtraID = dbRec.FExtraID,
            IDNE = dbRec.FIDNE,
            ExtraGUID = dbRec.FExtraGUID ?? string.Empty,
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
        historico.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        historico.DescricaoFase = dr["fasDescricao"]?.ToString() ?? string.Empty;
        historico.NomeStatusAndamento = dr["sanNome"]?.ToString() ?? string.Empty;
        return historico;
    }
}