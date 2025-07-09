#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IBensMateriaisReader
{
    BensMateriaisResponse? Read(int id, MsiSqlConnection oCnn);
    BensMateriaisResponse? Read(Entity.DBBensMateriais dbRec, MsiSqlConnection oCnn);
    BensMateriaisResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    BensMateriaisResponse? Read(Entity.DBBensMateriais dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    BensMateriaisResponse? Read(DBBensMateriais dbRec);
    BensMateriaisResponseAll? ReadAll(DBBensMateriais dbRec, DataRow dr);
    BensMateriaisResponseAll? ReadAll(DBBensMateriais dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<BensMateriaisResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class BensMateriais : IBensMateriaisReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{bmtCodigo, bmtNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<BensMateriaisResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<BensMateriaisResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<BensMateriaisResponseAll>> ReadLocalAsync()
        {
            var result = new List<BensMateriaisResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBBensMateriais(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"BensMateriais".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}bmtNome");
        }

        return query.ToString();
    }

    public BensMateriaisResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBBensMateriais(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public BensMateriaisResponse? Read(Entity.DBBensMateriais dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public BensMateriaisResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBBensMateriais(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public BensMateriaisResponse? Read(Entity.DBBensMateriais dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var bensmateriais = new BensMateriaisResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            BensClassificacao = dbRec.FBensClassificacao,
            NFNRO = dbRec.FNFNRO ?? string.Empty,
            Fornecedor = dbRec.FFornecedor,
            ValorBem = dbRec.FValorBem,
            NroSerieProduto = dbRec.FNroSerieProduto ?? string.Empty,
            Comprador = dbRec.FComprador ?? string.Empty,
            Cidade = dbRec.FCidade,
            GarantiaLoja = dbRec.FGarantiaLoja,
            Observacoes = dbRec.FObservacoes ?? string.Empty,
            NomeVendedor = dbRec.FNomeVendedor ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataCompra, out _))
            bensmateriais.DataCompra = dbRec.FDataCompra;
        if (DateTime.TryParse(dbRec.FDataFimDaGarantia, out _))
            bensmateriais.DataFimDaGarantia = dbRec.FDataFimDaGarantia;
        if (DateTime.TryParse(dbRec.FDataTerminoDaGarantiaDaLoja, out _))
            bensmateriais.DataTerminoDaGarantiaDaLoja = dbRec.FDataTerminoDaGarantiaDaLoja;
        return bensmateriais;
    }

    public BensMateriaisResponse? Read(DBBensMateriais dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var bensmateriais = new BensMateriaisResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            BensClassificacao = dbRec.FBensClassificacao,
            NFNRO = dbRec.FNFNRO ?? string.Empty,
            Fornecedor = dbRec.FFornecedor,
            ValorBem = dbRec.FValorBem,
            NroSerieProduto = dbRec.FNroSerieProduto ?? string.Empty,
            Comprador = dbRec.FComprador ?? string.Empty,
            Cidade = dbRec.FCidade,
            GarantiaLoja = dbRec.FGarantiaLoja,
            Observacoes = dbRec.FObservacoes ?? string.Empty,
            NomeVendedor = dbRec.FNomeVendedor ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataCompra, out _))
            bensmateriais.DataCompra = dbRec.FDataCompra;
        if (DateTime.TryParse(dbRec.FDataFimDaGarantia, out _))
            bensmateriais.DataFimDaGarantia = dbRec.FDataFimDaGarantia;
        if (DateTime.TryParse(dbRec.FDataTerminoDaGarantiaDaLoja, out _))
            bensmateriais.DataTerminoDaGarantiaDaLoja = dbRec.FDataTerminoDaGarantiaDaLoja;
        return bensmateriais;
    }

    public BensMateriaisResponseAll? ReadAll(DBBensMateriais dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var bensmateriais = new BensMateriaisResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            BensClassificacao = dbRec.FBensClassificacao,
            NFNRO = dbRec.FNFNRO ?? string.Empty,
            Fornecedor = dbRec.FFornecedor,
            ValorBem = dbRec.FValorBem,
            NroSerieProduto = dbRec.FNroSerieProduto ?? string.Empty,
            Comprador = dbRec.FComprador ?? string.Empty,
            Cidade = dbRec.FCidade,
            GarantiaLoja = dbRec.FGarantiaLoja,
            Observacoes = dbRec.FObservacoes ?? string.Empty,
            NomeVendedor = dbRec.FNomeVendedor ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataCompra, out _))
            bensmateriais.DataCompra = dbRec.FDataCompra;
        if (DateTime.TryParse(dbRec.FDataFimDaGarantia, out _))
            bensmateriais.DataFimDaGarantia = dbRec.FDataFimDaGarantia;
        if (DateTime.TryParse(dbRec.FDataTerminoDaGarantiaDaLoja, out _))
            bensmateriais.DataTerminoDaGarantiaDaLoja = dbRec.FDataTerminoDaGarantiaDaLoja;
        bensmateriais.NomeBensClassificacao = dr["bcsNome"]?.ToString() ?? string.Empty;
        bensmateriais.NomeFornecedores = dr["forNome"]?.ToString() ?? string.Empty;
        bensmateriais.NomeCidade = dr["cidNome"]?.ToString() ?? string.Empty;
        return bensmateriais;
    }

    public BensMateriaisResponseAll? ReadAll(DBBensMateriais dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var bensmateriais = new BensMateriaisResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            BensClassificacao = dbRec.FBensClassificacao,
            NFNRO = dbRec.FNFNRO ?? string.Empty,
            Fornecedor = dbRec.FFornecedor,
            ValorBem = dbRec.FValorBem,
            NroSerieProduto = dbRec.FNroSerieProduto ?? string.Empty,
            Comprador = dbRec.FComprador ?? string.Empty,
            Cidade = dbRec.FCidade,
            GarantiaLoja = dbRec.FGarantiaLoja,
            Observacoes = dbRec.FObservacoes ?? string.Empty,
            NomeVendedor = dbRec.FNomeVendedor ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataCompra, out _))
            bensmateriais.DataCompra = dbRec.FDataCompra;
        if (DateTime.TryParse(dbRec.FDataFimDaGarantia, out _))
            bensmateriais.DataFimDaGarantia = dbRec.FDataFimDaGarantia;
        if (DateTime.TryParse(dbRec.FDataTerminoDaGarantiaDaLoja, out _))
            bensmateriais.DataTerminoDaGarantiaDaLoja = dbRec.FDataTerminoDaGarantiaDaLoja;
        bensmateriais.NomeBensClassificacao = dr["bcsNome"]?.ToString() ?? string.Empty;
        bensmateriais.NomeFornecedores = dr["forNome"]?.ToString() ?? string.Empty;
        bensmateriais.NomeCidade = dr["cidNome"]?.ToString() ?? string.Empty;
        return bensmateriais;
    }
}