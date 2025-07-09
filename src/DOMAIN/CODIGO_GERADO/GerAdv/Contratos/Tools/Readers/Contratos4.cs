#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IContratosReader
{
    ContratosResponse? Read(int id, MsiSqlConnection oCnn);
    ContratosResponse? Read(Entity.DBContratos dbRec, MsiSqlConnection oCnn);
    ContratosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ContratosResponse? Read(Entity.DBContratos dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ContratosResponse? Read(DBContratos dbRec);
    ContratosResponseAll? ReadAll(DBContratos dbRec, DataRow dr);
    ContratosResponseAll? ReadAll(DBContratos dbRec, SqlDataReader dr);
    IEnumerable<ContratosResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Contratos : IContratosReader
{
    public IEnumerable<ContratosResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<ContratosResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<ContratosResponseAll>> ReadLocalAsync()
        {
            var result = new List<ContratosResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBContratos(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"Contratos".dbo(oCnn)} (NOLOCK) ");
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

    public ContratosResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBContratos(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ContratosResponse? Read(Entity.DBContratos dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public ContratosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBContratos(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ContratosResponse? Read(Entity.DBContratos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var contratos = new ContratosResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Cliente = dbRec.FCliente,
            Advogado = dbRec.FAdvogado,
            Dia = dbRec.FDia,
            Valor = dbRec.FValor,
            OcultarRelatorio = dbRec.FOcultarRelatorio,
            PercEscritorio = dbRec.FPercEscritorio,
            ValorConsultoria = dbRec.FValorConsultoria,
            TipoCobranca = dbRec.FTipoCobranca,
            Protestar = dbRec.FProtestar ?? string.Empty,
            Juros = dbRec.FJuros ?? string.Empty,
            ValorRealizavel = dbRec.FValorRealizavel,
            DOCUMENTO = dbRec.FDOCUMENTO ?? string.Empty,
            EMail1 = dbRec.FEMail1 ?? string.Empty,
            EMail2 = dbRec.FEMail2 ?? string.Empty,
            EMail3 = dbRec.FEMail3 ?? string.Empty,
            Pessoa1 = dbRec.FPessoa1 ?? string.Empty,
            Pessoa2 = dbRec.FPessoa2 ?? string.Empty,
            Pessoa3 = dbRec.FPessoa3 ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            ClienteContrato = dbRec.FClienteContrato,
            IdExtrangeiro = dbRec.FIdExtrangeiro,
            ChaveContrato = dbRec.FChaveContrato ?? string.Empty,
            Avulso = dbRec.FAvulso,
            Suspenso = dbRec.FSuspenso,
            Multa = dbRec.FMulta ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataInicio, out _))
            contratos.DataInicio = dbRec.FDataInicio;
        if (DateTime.TryParse(dbRec.FDataTermino, out _))
            contratos.DataTermino = dbRec.FDataTermino;
        return contratos;
    }

    public ContratosResponse? Read(DBContratos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var contratos = new ContratosResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Cliente = dbRec.FCliente,
            Advogado = dbRec.FAdvogado,
            Dia = dbRec.FDia,
            Valor = dbRec.FValor,
            OcultarRelatorio = dbRec.FOcultarRelatorio,
            PercEscritorio = dbRec.FPercEscritorio,
            ValorConsultoria = dbRec.FValorConsultoria,
            TipoCobranca = dbRec.FTipoCobranca,
            Protestar = dbRec.FProtestar ?? string.Empty,
            Juros = dbRec.FJuros ?? string.Empty,
            ValorRealizavel = dbRec.FValorRealizavel,
            DOCUMENTO = dbRec.FDOCUMENTO ?? string.Empty,
            EMail1 = dbRec.FEMail1 ?? string.Empty,
            EMail2 = dbRec.FEMail2 ?? string.Empty,
            EMail3 = dbRec.FEMail3 ?? string.Empty,
            Pessoa1 = dbRec.FPessoa1 ?? string.Empty,
            Pessoa2 = dbRec.FPessoa2 ?? string.Empty,
            Pessoa3 = dbRec.FPessoa3 ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            ClienteContrato = dbRec.FClienteContrato,
            IdExtrangeiro = dbRec.FIdExtrangeiro,
            ChaveContrato = dbRec.FChaveContrato ?? string.Empty,
            Avulso = dbRec.FAvulso,
            Suspenso = dbRec.FSuspenso,
            Multa = dbRec.FMulta ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataInicio, out _))
            contratos.DataInicio = dbRec.FDataInicio;
        if (DateTime.TryParse(dbRec.FDataTermino, out _))
            contratos.DataTermino = dbRec.FDataTermino;
        return contratos;
    }

    public ContratosResponseAll? ReadAll(DBContratos dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var contratos = new ContratosResponseAll
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Cliente = dbRec.FCliente,
            Advogado = dbRec.FAdvogado,
            Dia = dbRec.FDia,
            Valor = dbRec.FValor,
            OcultarRelatorio = dbRec.FOcultarRelatorio,
            PercEscritorio = dbRec.FPercEscritorio,
            ValorConsultoria = dbRec.FValorConsultoria,
            TipoCobranca = dbRec.FTipoCobranca,
            Protestar = dbRec.FProtestar ?? string.Empty,
            Juros = dbRec.FJuros ?? string.Empty,
            ValorRealizavel = dbRec.FValorRealizavel,
            DOCUMENTO = dbRec.FDOCUMENTO ?? string.Empty,
            EMail1 = dbRec.FEMail1 ?? string.Empty,
            EMail2 = dbRec.FEMail2 ?? string.Empty,
            EMail3 = dbRec.FEMail3 ?? string.Empty,
            Pessoa1 = dbRec.FPessoa1 ?? string.Empty,
            Pessoa2 = dbRec.FPessoa2 ?? string.Empty,
            Pessoa3 = dbRec.FPessoa3 ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            ClienteContrato = dbRec.FClienteContrato,
            IdExtrangeiro = dbRec.FIdExtrangeiro,
            ChaveContrato = dbRec.FChaveContrato ?? string.Empty,
            Avulso = dbRec.FAvulso,
            Suspenso = dbRec.FSuspenso,
            Multa = dbRec.FMulta ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataInicio, out _))
            contratos.DataInicio = dbRec.FDataInicio;
        if (DateTime.TryParse(dbRec.FDataTermino, out _))
            contratos.DataTermino = dbRec.FDataTermino;
        contratos.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        contratos.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        contratos.NomeAdvogados = dr["advNome"]?.ToString() ?? string.Empty;
        return contratos;
    }

    public ContratosResponseAll? ReadAll(DBContratos dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var contratos = new ContratosResponseAll
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Cliente = dbRec.FCliente,
            Advogado = dbRec.FAdvogado,
            Dia = dbRec.FDia,
            Valor = dbRec.FValor,
            OcultarRelatorio = dbRec.FOcultarRelatorio,
            PercEscritorio = dbRec.FPercEscritorio,
            ValorConsultoria = dbRec.FValorConsultoria,
            TipoCobranca = dbRec.FTipoCobranca,
            Protestar = dbRec.FProtestar ?? string.Empty,
            Juros = dbRec.FJuros ?? string.Empty,
            ValorRealizavel = dbRec.FValorRealizavel,
            DOCUMENTO = dbRec.FDOCUMENTO ?? string.Empty,
            EMail1 = dbRec.FEMail1 ?? string.Empty,
            EMail2 = dbRec.FEMail2 ?? string.Empty,
            EMail3 = dbRec.FEMail3 ?? string.Empty,
            Pessoa1 = dbRec.FPessoa1 ?? string.Empty,
            Pessoa2 = dbRec.FPessoa2 ?? string.Empty,
            Pessoa3 = dbRec.FPessoa3 ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            ClienteContrato = dbRec.FClienteContrato,
            IdExtrangeiro = dbRec.FIdExtrangeiro,
            ChaveContrato = dbRec.FChaveContrato ?? string.Empty,
            Avulso = dbRec.FAvulso,
            Suspenso = dbRec.FSuspenso,
            Multa = dbRec.FMulta ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataInicio, out _))
            contratos.DataInicio = dbRec.FDataInicio;
        if (DateTime.TryParse(dbRec.FDataTermino, out _))
            contratos.DataTermino = dbRec.FDataTermino;
        contratos.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        contratos.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        contratos.NomeAdvogados = dr["advNome"]?.ToString() ?? string.Empty;
        return contratos;
    }
}