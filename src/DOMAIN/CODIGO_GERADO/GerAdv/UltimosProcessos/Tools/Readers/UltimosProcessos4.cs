#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IUltimosProcessosReader
{
    UltimosProcessosResponse? Read(int id, MsiSqlConnection oCnn);
    UltimosProcessosResponse? Read(Entity.DBUltimosProcessos dbRec, MsiSqlConnection oCnn);
    UltimosProcessosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    UltimosProcessosResponse? Read(Entity.DBUltimosProcessos dbRec);
    UltimosProcessosResponse? Read(DBUltimosProcessos dbRec);
    UltimosProcessosResponseAll? ReadAll(DBUltimosProcessos dbRec, DataRow dr);
    UltimosProcessosResponseAll? ReadAll(DBUltimosProcessos dbRec, SqlDataReader dr);
    IEnumerable<UltimosProcessosResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class UltimosProcessos : IUltimosProcessosReader
{
    public IEnumerable<UltimosProcessosResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<UltimosProcessosResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<UltimosProcessosResponseAll>> ReadLocalAsync()
        {
            var result = new List<UltimosProcessosResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBUltimosProcessos(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"UltimosProcessos".dbo(oCnn)} (NOLOCK) ");
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

    public UltimosProcessosResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBUltimosProcessos(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public UltimosProcessosResponse? Read(Entity.DBUltimosProcessos dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public UltimosProcessosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBUltimosProcessos(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public UltimosProcessosResponse? Read(Entity.DBUltimosProcessos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var ultimosprocessos = new UltimosProcessosResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Quem = dbRec.FQuem,
        };
        if (DateTime.TryParse(dbRec.FQuando, out _))
            ultimosprocessos.Quando = dbRec.FQuando;
        return ultimosprocessos;
    }

    public UltimosProcessosResponse? Read(DBUltimosProcessos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var ultimosprocessos = new UltimosProcessosResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Quem = dbRec.FQuem,
        };
        if (DateTime.TryParse(dbRec.FQuando, out _))
            ultimosprocessos.Quando = dbRec.FQuando;
        return ultimosprocessos;
    }

    public UltimosProcessosResponseAll? ReadAll(DBUltimosProcessos dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var ultimosprocessos = new UltimosProcessosResponseAll
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Quem = dbRec.FQuem,
        };
        if (DateTime.TryParse(dbRec.FQuando, out _))
            ultimosprocessos.Quando = dbRec.FQuando;
        ultimosprocessos.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return ultimosprocessos;
    }

    public UltimosProcessosResponseAll? ReadAll(DBUltimosProcessos dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var ultimosprocessos = new UltimosProcessosResponseAll
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Quem = dbRec.FQuem,
        };
        if (DateTime.TryParse(dbRec.FQuando, out _))
            ultimosprocessos.Quando = dbRec.FQuando;
        ultimosprocessos.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return ultimosprocessos;
    }
}