#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IHonorariosDadosContratoReader
{
    HonorariosDadosContratoResponse? Read(int id, MsiSqlConnection oCnn);
    HonorariosDadosContratoResponse? Read(Entity.DBHonorariosDadosContrato dbRec, MsiSqlConnection oCnn);
    HonorariosDadosContratoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    HonorariosDadosContratoResponse? Read(Entity.DBHonorariosDadosContrato dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    HonorariosDadosContratoResponse? Read(DBHonorariosDadosContrato dbRec);
    HonorariosDadosContratoResponseAll? ReadAll(DBHonorariosDadosContrato dbRec, DataRow dr);
    HonorariosDadosContratoResponseAll? ReadAll(DBHonorariosDadosContrato dbRec, SqlDataReader dr);
    IEnumerable<HonorariosDadosContratoResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class HonorariosDadosContrato : IHonorariosDadosContratoReader
{
    public IEnumerable<HonorariosDadosContratoResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<HonorariosDadosContratoResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<HonorariosDadosContratoResponseAll>> ReadLocalAsync()
        {
            var result = new List<HonorariosDadosContratoResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBHonorariosDadosContrato(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"HonorariosDadosContrato".dbo(oCnn)} (NOLOCK) ");
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

    public HonorariosDadosContratoResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBHonorariosDadosContrato(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public HonorariosDadosContratoResponse? Read(Entity.DBHonorariosDadosContrato dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public HonorariosDadosContratoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBHonorariosDadosContrato(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public HonorariosDadosContratoResponse? Read(Entity.DBHonorariosDadosContrato dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var honorariosdadoscontrato = new HonorariosDadosContratoResponse
        {
            Id = dbRec.ID,
            Cliente = dbRec.FCliente,
            Fixo = dbRec.FFixo,
            Variavel = dbRec.FVariavel,
            PercSucesso = dbRec.FPercSucesso,
            Processo = dbRec.FProcesso,
            ArquivoContrato = dbRec.FArquivoContrato ?? string.Empty,
            TextoContrato = dbRec.FTextoContrato ?? string.Empty,
            ValorFixo = dbRec.FValorFixo,
            Observacao = dbRec.FObservacao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataContrato, out _))
            honorariosdadoscontrato.DataContrato = dbRec.FDataContrato;
        return honorariosdadoscontrato;
    }

    public HonorariosDadosContratoResponse? Read(DBHonorariosDadosContrato dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var honorariosdadoscontrato = new HonorariosDadosContratoResponse
        {
            Id = dbRec.ID,
            Cliente = dbRec.FCliente,
            Fixo = dbRec.FFixo,
            Variavel = dbRec.FVariavel,
            PercSucesso = dbRec.FPercSucesso,
            Processo = dbRec.FProcesso,
            ArquivoContrato = dbRec.FArquivoContrato ?? string.Empty,
            TextoContrato = dbRec.FTextoContrato ?? string.Empty,
            ValorFixo = dbRec.FValorFixo,
            Observacao = dbRec.FObservacao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataContrato, out _))
            honorariosdadoscontrato.DataContrato = dbRec.FDataContrato;
        return honorariosdadoscontrato;
    }

    public HonorariosDadosContratoResponseAll? ReadAll(DBHonorariosDadosContrato dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var honorariosdadoscontrato = new HonorariosDadosContratoResponseAll
        {
            Id = dbRec.ID,
            Cliente = dbRec.FCliente,
            Fixo = dbRec.FFixo,
            Variavel = dbRec.FVariavel,
            PercSucesso = dbRec.FPercSucesso,
            Processo = dbRec.FProcesso,
            ArquivoContrato = dbRec.FArquivoContrato ?? string.Empty,
            TextoContrato = dbRec.FTextoContrato ?? string.Empty,
            ValorFixo = dbRec.FValorFixo,
            Observacao = dbRec.FObservacao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataContrato, out _))
            honorariosdadoscontrato.DataContrato = dbRec.FDataContrato;
        honorariosdadoscontrato.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        honorariosdadoscontrato.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return honorariosdadoscontrato;
    }

    public HonorariosDadosContratoResponseAll? ReadAll(DBHonorariosDadosContrato dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var honorariosdadoscontrato = new HonorariosDadosContratoResponseAll
        {
            Id = dbRec.ID,
            Cliente = dbRec.FCliente,
            Fixo = dbRec.FFixo,
            Variavel = dbRec.FVariavel,
            PercSucesso = dbRec.FPercSucesso,
            Processo = dbRec.FProcesso,
            ArquivoContrato = dbRec.FArquivoContrato ?? string.Empty,
            TextoContrato = dbRec.FTextoContrato ?? string.Empty,
            ValorFixo = dbRec.FValorFixo,
            Observacao = dbRec.FObservacao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataContrato, out _))
            honorariosdadoscontrato.DataContrato = dbRec.FDataContrato;
        honorariosdadoscontrato.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        honorariosdadoscontrato.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return honorariosdadoscontrato;
    }
}