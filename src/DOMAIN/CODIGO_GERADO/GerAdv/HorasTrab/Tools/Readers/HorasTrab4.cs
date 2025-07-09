#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IHorasTrabReader
{
    HorasTrabResponse? Read(int id, MsiSqlConnection oCnn);
    HorasTrabResponse? Read(Entity.DBHorasTrab dbRec, MsiSqlConnection oCnn);
    HorasTrabResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    HorasTrabResponse? Read(Entity.DBHorasTrab dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    HorasTrabResponse? Read(DBHorasTrab dbRec);
    HorasTrabResponseAll? ReadAll(DBHorasTrab dbRec, DataRow dr);
    HorasTrabResponseAll? ReadAll(DBHorasTrab dbRec, SqlDataReader dr);
    IEnumerable<HorasTrabResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class HorasTrab : IHorasTrabReader
{
    public IEnumerable<HorasTrabResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<HorasTrabResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<HorasTrabResponseAll>> ReadLocalAsync()
        {
            var result = new List<HorasTrabResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBHorasTrab(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"HorasTrab".dbo(oCnn)} (NOLOCK) ");
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

    public HorasTrabResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBHorasTrab(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public HorasTrabResponse? Read(Entity.DBHorasTrab dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public HorasTrabResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBHorasTrab(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public HorasTrabResponse? Read(Entity.DBHorasTrab dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var horastrab = new HorasTrabResponse
        {
            Id = dbRec.ID,
            IDContatoCRM = dbRec.FIDContatoCRM,
            Honorario = dbRec.FHonorario,
            IDAgenda = dbRec.FIDAgenda,
            Cliente = dbRec.FCliente,
            Status = dbRec.FStatus,
            Processo = dbRec.FProcesso,
            Advogado = dbRec.FAdvogado,
            Funcionario = dbRec.FFuncionario,
            HrIni = dbRec.FHrIni ?? string.Empty,
            HrFim = dbRec.FHrFim ?? string.Empty,
            Tempo = dbRec.FTempo,
            Valor = dbRec.FValor,
            OBS = dbRec.FOBS ?? string.Empty,
            Anexo = dbRec.FAnexo ?? string.Empty,
            AnexoComp = dbRec.FAnexoComp ?? string.Empty,
            AnexoUNC = dbRec.FAnexoUNC ?? string.Empty,
            Servico = dbRec.FServico,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            horastrab.Data = dbRec.FData;
        return horastrab;
    }

    public HorasTrabResponse? Read(DBHorasTrab dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var horastrab = new HorasTrabResponse
        {
            Id = dbRec.ID,
            IDContatoCRM = dbRec.FIDContatoCRM,
            Honorario = dbRec.FHonorario,
            IDAgenda = dbRec.FIDAgenda,
            Cliente = dbRec.FCliente,
            Status = dbRec.FStatus,
            Processo = dbRec.FProcesso,
            Advogado = dbRec.FAdvogado,
            Funcionario = dbRec.FFuncionario,
            HrIni = dbRec.FHrIni ?? string.Empty,
            HrFim = dbRec.FHrFim ?? string.Empty,
            Tempo = dbRec.FTempo,
            Valor = dbRec.FValor,
            OBS = dbRec.FOBS ?? string.Empty,
            Anexo = dbRec.FAnexo ?? string.Empty,
            AnexoComp = dbRec.FAnexoComp ?? string.Empty,
            AnexoUNC = dbRec.FAnexoUNC ?? string.Empty,
            Servico = dbRec.FServico,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            horastrab.Data = dbRec.FData;
        return horastrab;
    }

    public HorasTrabResponseAll? ReadAll(DBHorasTrab dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var horastrab = new HorasTrabResponseAll
        {
            Id = dbRec.ID,
            IDContatoCRM = dbRec.FIDContatoCRM,
            Honorario = dbRec.FHonorario,
            IDAgenda = dbRec.FIDAgenda,
            Cliente = dbRec.FCliente,
            Status = dbRec.FStatus,
            Processo = dbRec.FProcesso,
            Advogado = dbRec.FAdvogado,
            Funcionario = dbRec.FFuncionario,
            HrIni = dbRec.FHrIni ?? string.Empty,
            HrFim = dbRec.FHrFim ?? string.Empty,
            Tempo = dbRec.FTempo,
            Valor = dbRec.FValor,
            OBS = dbRec.FOBS ?? string.Empty,
            Anexo = dbRec.FAnexo ?? string.Empty,
            AnexoComp = dbRec.FAnexoComp ?? string.Empty,
            AnexoUNC = dbRec.FAnexoUNC ?? string.Empty,
            Servico = dbRec.FServico,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            horastrab.Data = dbRec.FData;
        horastrab.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        horastrab.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        horastrab.NomeAdvogados = dr["advNome"]?.ToString() ?? string.Empty;
        horastrab.NomeFuncionarios = dr["funNome"]?.ToString() ?? string.Empty;
        horastrab.DescricaoServicos = dr["serDescricao"]?.ToString() ?? string.Empty;
        return horastrab;
    }

    public HorasTrabResponseAll? ReadAll(DBHorasTrab dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var horastrab = new HorasTrabResponseAll
        {
            Id = dbRec.ID,
            IDContatoCRM = dbRec.FIDContatoCRM,
            Honorario = dbRec.FHonorario,
            IDAgenda = dbRec.FIDAgenda,
            Cliente = dbRec.FCliente,
            Status = dbRec.FStatus,
            Processo = dbRec.FProcesso,
            Advogado = dbRec.FAdvogado,
            Funcionario = dbRec.FFuncionario,
            HrIni = dbRec.FHrIni ?? string.Empty,
            HrFim = dbRec.FHrFim ?? string.Empty,
            Tempo = dbRec.FTempo,
            Valor = dbRec.FValor,
            OBS = dbRec.FOBS ?? string.Empty,
            Anexo = dbRec.FAnexo ?? string.Empty,
            AnexoComp = dbRec.FAnexoComp ?? string.Empty,
            AnexoUNC = dbRec.FAnexoUNC ?? string.Empty,
            Servico = dbRec.FServico,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            horastrab.Data = dbRec.FData;
        horastrab.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        horastrab.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        horastrab.NomeAdvogados = dr["advNome"]?.ToString() ?? string.Empty;
        horastrab.NomeFuncionarios = dr["funNome"]?.ToString() ?? string.Empty;
        horastrab.DescricaoServicos = dr["serDescricao"]?.ToString() ?? string.Empty;
        return horastrab;
    }
}