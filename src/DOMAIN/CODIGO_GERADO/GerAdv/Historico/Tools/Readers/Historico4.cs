#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IHistoricoReader
{
    HistoricoResponse? Read(int id, MsiSqlConnection oCnn);
    HistoricoResponse? Read(Entity.DBHistorico dbRec, MsiSqlConnection oCnn);
    HistoricoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    HistoricoResponse? Read(Entity.DBHistorico dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    HistoricoResponse? Read(DBHistorico dbRec);
    HistoricoResponseAll? ReadAll(DBHistorico dbRec, DataRow dr);
    HistoricoResponseAll? ReadAll(DBHistorico dbRec, SqlDataReader dr);
    IEnumerable<HistoricoResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Historico : IHistoricoReader
{
    public IEnumerable<HistoricoResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<HistoricoResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<HistoricoResponseAll>> ReadLocalAsync()
        {
            var result = new List<HistoricoResponseAll>(max);
            await using var connection = Configuracoes.GetConnectionByUri(uri);
            await using var cmd = new SqlCommand(cmdText: ConfiguracoesDBT.CmdSql(sql), connection: connection?.InnerConnection)
            {
                CommandTimeout = 0
            };
            cmd.Parameters.AddRange([..parameters]);
            await using var reader = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult).ConfigureAwait(false);
            while (await reader.ReadAsync().ConfigureAwait(false))
            {
                if (await reader.IsDBNullAsync(1).ConfigureAwait(false))
                    continue;
                result.Add(ReadAll(new Entity.DBHistorico(reader), reader)!);
            }

            return result;
        }
    }

    static string BuildSqlQuery(string campos, string whereClause, string orderClause, int max, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"Historico".dbo(oCnn)} (NOLOCK) ");
        if (!string.IsNullOrEmpty(whereClause))
        {
            query.Append(!whereClause.ToUpperInvariant().Contains(TSql.Where, StringComparison.OrdinalIgnoreCase) ? TSql.Where : string.Empty).Append(whereClause);
        }

        if (!string.IsNullOrEmpty(orderClause))
        {
            query.Append(!orderClause.ToUpperInvariant().Contains(TSql.OrderBy, StringComparison.OrdinalIgnoreCase) ? TSql.OrderBy : string.Empty).Append(orderClause);
        }
        else
        {
            query.Append($"{TSql.OrderBy}");
        }

        return query.ToString();
    }

    public HistoricoResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBHistorico(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public HistoricoResponse? Read(Entity.DBHistorico dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
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

    public HistoricoResponseAll? ReadAll(DBHistorico dbRec, SqlDataReader dr)
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