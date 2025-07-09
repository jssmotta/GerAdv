#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ILivroCaixaReader
{
    LivroCaixaResponse? Read(int id, MsiSqlConnection oCnn);
    LivroCaixaResponse? Read(Entity.DBLivroCaixa dbRec, MsiSqlConnection oCnn);
    LivroCaixaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    LivroCaixaResponse? Read(Entity.DBLivroCaixa dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    LivroCaixaResponse? Read(DBLivroCaixa dbRec);
    LivroCaixaResponseAll? ReadAll(DBLivroCaixa dbRec, DataRow dr);
    LivroCaixaResponseAll? ReadAll(DBLivroCaixa dbRec, SqlDataReader dr);
    IEnumerable<LivroCaixaResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class LivroCaixa : ILivroCaixaReader
{
    public IEnumerable<LivroCaixaResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<LivroCaixaResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<LivroCaixaResponseAll>> ReadLocalAsync()
        {
            var result = new List<LivroCaixaResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBLivroCaixa(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"LivroCaixa".dbo(oCnn)} (NOLOCK) ");
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

    public LivroCaixaResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBLivroCaixa(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public LivroCaixaResponse? Read(Entity.DBLivroCaixa dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public LivroCaixaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBLivroCaixa(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public LivroCaixaResponse? Read(Entity.DBLivroCaixa dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var livrocaixa = new LivroCaixaResponse
        {
            Id = dbRec.ID,
            IDDes = dbRec.FIDDes,
            Pessoal = dbRec.FPessoal,
            Ajuste = dbRec.FAjuste,
            IDHon = dbRec.FIDHon,
            IDHonParc = dbRec.FIDHonParc,
            IDHonSuc = dbRec.FIDHonSuc,
            Processo = dbRec.FProcesso,
            Valor = dbRec.FValor,
            Tipo = dbRec.FTipo,
            Historico = dbRec.FHistorico ?? string.Empty,
            Grupo = dbRec.FGrupo,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            livrocaixa.Data = dbRec.FData;
        return livrocaixa;
    }

    public LivroCaixaResponse? Read(DBLivroCaixa dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var livrocaixa = new LivroCaixaResponse
        {
            Id = dbRec.ID,
            IDDes = dbRec.FIDDes,
            Pessoal = dbRec.FPessoal,
            Ajuste = dbRec.FAjuste,
            IDHon = dbRec.FIDHon,
            IDHonParc = dbRec.FIDHonParc,
            IDHonSuc = dbRec.FIDHonSuc,
            Processo = dbRec.FProcesso,
            Valor = dbRec.FValor,
            Tipo = dbRec.FTipo,
            Historico = dbRec.FHistorico ?? string.Empty,
            Grupo = dbRec.FGrupo,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            livrocaixa.Data = dbRec.FData;
        return livrocaixa;
    }

    public LivroCaixaResponseAll? ReadAll(DBLivroCaixa dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var livrocaixa = new LivroCaixaResponseAll
        {
            Id = dbRec.ID,
            IDDes = dbRec.FIDDes,
            Pessoal = dbRec.FPessoal,
            Ajuste = dbRec.FAjuste,
            IDHon = dbRec.FIDHon,
            IDHonParc = dbRec.FIDHonParc,
            IDHonSuc = dbRec.FIDHonSuc,
            Processo = dbRec.FProcesso,
            Valor = dbRec.FValor,
            Tipo = dbRec.FTipo,
            Historico = dbRec.FHistorico ?? string.Empty,
            Grupo = dbRec.FGrupo,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            livrocaixa.Data = dbRec.FData;
        livrocaixa.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return livrocaixa;
    }

    public LivroCaixaResponseAll? ReadAll(DBLivroCaixa dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var livrocaixa = new LivroCaixaResponseAll
        {
            Id = dbRec.ID,
            IDDes = dbRec.FIDDes,
            Pessoal = dbRec.FPessoal,
            Ajuste = dbRec.FAjuste,
            IDHon = dbRec.FIDHon,
            IDHonParc = dbRec.FIDHonParc,
            IDHonSuc = dbRec.FIDHonSuc,
            Processo = dbRec.FProcesso,
            Valor = dbRec.FValor,
            Tipo = dbRec.FTipo,
            Historico = dbRec.FHistorico ?? string.Empty,
            Grupo = dbRec.FGrupo,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            livrocaixa.Data = dbRec.FData;
        livrocaixa.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return livrocaixa;
    }
}