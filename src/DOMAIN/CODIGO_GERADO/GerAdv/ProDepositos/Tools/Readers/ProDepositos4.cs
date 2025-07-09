#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProDepositosReader
{
    ProDepositosResponse? Read(int id, MsiSqlConnection oCnn);
    ProDepositosResponse? Read(Entity.DBProDepositos dbRec, MsiSqlConnection oCnn);
    ProDepositosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProDepositosResponse? Read(Entity.DBProDepositos dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProDepositosResponse? Read(DBProDepositos dbRec);
    ProDepositosResponseAll? ReadAll(DBProDepositos dbRec, DataRow dr);
    ProDepositosResponseAll? ReadAll(DBProDepositos dbRec, SqlDataReader dr);
    IEnumerable<ProDepositosResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class ProDepositos : IProDepositosReader
{
    public IEnumerable<ProDepositosResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<ProDepositosResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<ProDepositosResponseAll>> ReadLocalAsync()
        {
            var result = new List<ProDepositosResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBProDepositos(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"ProDepositos".dbo(oCnn)} (NOLOCK) ");
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

    public ProDepositosResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProDepositos(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProDepositosResponse? Read(Entity.DBProDepositos dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public ProDepositosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProDepositos(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProDepositosResponse? Read(Entity.DBProDepositos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var prodepositos = new ProDepositosResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Fase = dbRec.FFase,
            Valor = dbRec.FValor,
            TipoProDesposito = dbRec.FTipoProDesposito,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            prodepositos.Data = dbRec.FData;
        return prodepositos;
    }

    public ProDepositosResponse? Read(DBProDepositos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var prodepositos = new ProDepositosResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Fase = dbRec.FFase,
            Valor = dbRec.FValor,
            TipoProDesposito = dbRec.FTipoProDesposito,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            prodepositos.Data = dbRec.FData;
        return prodepositos;
    }

    public ProDepositosResponseAll? ReadAll(DBProDepositos dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var prodepositos = new ProDepositosResponseAll
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Fase = dbRec.FFase,
            Valor = dbRec.FValor,
            TipoProDesposito = dbRec.FTipoProDesposito,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            prodepositos.Data = dbRec.FData;
        prodepositos.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        prodepositos.DescricaoFase = dr["fasDescricao"]?.ToString() ?? string.Empty;
        prodepositos.NomeTipoProDesposito = dr["tpdNome"]?.ToString() ?? string.Empty;
        return prodepositos;
    }

    public ProDepositosResponseAll? ReadAll(DBProDepositos dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var prodepositos = new ProDepositosResponseAll
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Fase = dbRec.FFase,
            Valor = dbRec.FValor,
            TipoProDesposito = dbRec.FTipoProDesposito,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            prodepositos.Data = dbRec.FData;
        prodepositos.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        prodepositos.DescricaoFase = dr["fasDescricao"]?.ToString() ?? string.Empty;
        prodepositos.NomeTipoProDesposito = dr["tpdNome"]?.ToString() ?? string.Empty;
        return prodepositos;
    }
}