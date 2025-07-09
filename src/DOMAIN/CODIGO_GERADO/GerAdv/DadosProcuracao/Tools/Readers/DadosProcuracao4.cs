#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IDadosProcuracaoReader
{
    DadosProcuracaoResponse? Read(int id, MsiSqlConnection oCnn);
    DadosProcuracaoResponse? Read(Entity.DBDadosProcuracao dbRec, MsiSqlConnection oCnn);
    DadosProcuracaoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    DadosProcuracaoResponse? Read(Entity.DBDadosProcuracao dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    DadosProcuracaoResponse? Read(DBDadosProcuracao dbRec);
    DadosProcuracaoResponseAll? ReadAll(DBDadosProcuracao dbRec, DataRow dr);
    DadosProcuracaoResponseAll? ReadAll(DBDadosProcuracao dbRec, SqlDataReader dr);
    IEnumerable<DadosProcuracaoResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class DadosProcuracao : IDadosProcuracaoReader
{
    public IEnumerable<DadosProcuracaoResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<DadosProcuracaoResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<DadosProcuracaoResponseAll>> ReadLocalAsync()
        {
            var result = new List<DadosProcuracaoResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBDadosProcuracao(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"DadosProcuracao".dbo(oCnn)} (NOLOCK) ");
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

    public DadosProcuracaoResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBDadosProcuracao(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public DadosProcuracaoResponse? Read(Entity.DBDadosProcuracao dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public DadosProcuracaoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBDadosProcuracao(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public DadosProcuracaoResponse? Read(Entity.DBDadosProcuracao dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var dadosprocuracao = new DadosProcuracaoResponse
        {
            Id = dbRec.ID,
            Cliente = dbRec.FCliente,
            EstadoCivil = dbRec.FEstadoCivil ?? string.Empty,
            Nacionalidade = dbRec.FNacionalidade ?? string.Empty,
            Profissao = dbRec.FProfissao ?? string.Empty,
            CTPS = dbRec.FCTPS ?? string.Empty,
            PisPasep = dbRec.FPisPasep ?? string.Empty,
            Remuneracao = dbRec.FRemuneracao ?? string.Empty,
            Objeto = dbRec.FObjeto ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return dadosprocuracao;
    }

    public DadosProcuracaoResponse? Read(DBDadosProcuracao dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var dadosprocuracao = new DadosProcuracaoResponse
        {
            Id = dbRec.ID,
            Cliente = dbRec.FCliente,
            EstadoCivil = dbRec.FEstadoCivil ?? string.Empty,
            Nacionalidade = dbRec.FNacionalidade ?? string.Empty,
            Profissao = dbRec.FProfissao ?? string.Empty,
            CTPS = dbRec.FCTPS ?? string.Empty,
            PisPasep = dbRec.FPisPasep ?? string.Empty,
            Remuneracao = dbRec.FRemuneracao ?? string.Empty,
            Objeto = dbRec.FObjeto ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return dadosprocuracao;
    }

    public DadosProcuracaoResponseAll? ReadAll(DBDadosProcuracao dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var dadosprocuracao = new DadosProcuracaoResponseAll
        {
            Id = dbRec.ID,
            Cliente = dbRec.FCliente,
            EstadoCivil = dbRec.FEstadoCivil ?? string.Empty,
            Nacionalidade = dbRec.FNacionalidade ?? string.Empty,
            Profissao = dbRec.FProfissao ?? string.Empty,
            CTPS = dbRec.FCTPS ?? string.Empty,
            PisPasep = dbRec.FPisPasep ?? string.Empty,
            Remuneracao = dbRec.FRemuneracao ?? string.Empty,
            Objeto = dbRec.FObjeto ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        dadosprocuracao.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        return dadosprocuracao;
    }

    public DadosProcuracaoResponseAll? ReadAll(DBDadosProcuracao dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var dadosprocuracao = new DadosProcuracaoResponseAll
        {
            Id = dbRec.ID,
            Cliente = dbRec.FCliente,
            EstadoCivil = dbRec.FEstadoCivil ?? string.Empty,
            Nacionalidade = dbRec.FNacionalidade ?? string.Empty,
            Profissao = dbRec.FProfissao ?? string.Empty,
            CTPS = dbRec.FCTPS ?? string.Empty,
            PisPasep = dbRec.FPisPasep ?? string.Empty,
            Remuneracao = dbRec.FRemuneracao ?? string.Empty,
            Objeto = dbRec.FObjeto ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        dadosprocuracao.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        return dadosprocuracao;
    }
}