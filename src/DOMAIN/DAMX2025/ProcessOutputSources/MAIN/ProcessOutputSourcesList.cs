// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBProcessOutputSources
{
    // CodeNomeOnly 
    public static DBNomeID ListarN(in int codigo, SqlConnection? oCnn)
    {
        using var cmd = new SqlCommand($"SELECT TOP 1 [{CampoNome}], [{CampoCodigo}] FROM dbo.[{PTabelaNome}]  (NOLOCK)  WHERE [{CampoCodigo}]=@CampoCodigo", oCnn);
        cmd.Parameters.AddWithValue("@CampoCodigo", codigo);
        using var ds = ConfiguracoesDBT.GetDataTable(cmd, CommandBehavior.SingleRow, oCnn);
        return ds is null ? new DBNomeID() : new DBNomeID(ds.Rows.Count.IsEmptyIDNumber() ? 0 : Convert.ToInt32(ds.Rows[0][1]), ds.Rows.Count.IsEmptyIDNumber() ? "" : $"{ds.Rows[0][0]}");
    }

    public static DBNomeID ListarN(in string cNome, SqlConnection? oCnn)
    {
        using var cmd = new SqlCommand($"SELECT TOP 1 [{CampoNome}], [{CampoCodigo}] FROM dbo.[{PTabelaNome}]  (NOLOCK)  WHERE [{CampoNome}] {DevourerConsts.MsiCollate} like @CampoNome", oCnn);
        cmd.Parameters.AddWithValue("@CampoNome", cNome.trim());
        using var ds = ConfiguracoesDBT.GetDataTable(cmd, CommandBehavior.SingleRow, oCnn);
        return ds is null ? new DBNomeID() : new DBNomeID(ds.Rows.Count.IsEmptyIDNumber() ? 0 : Convert.ToInt32(ds.Rows[0][1]), ds.Rows.Count.IsEmptyIDNumber() ? "" : $"{ds.Rows[0][0]}");
    }

    public static List<DBNomeID> ListarN(string cWhere, string cOrder, string? cCnn, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        return ReadLocalAsync().Result;
        async Task<List<DBNomeID>> ReadLocalAsync()
        {
            var sql = BuildSqlQuery(cWhere, cOrder, max);
            var result = new List<DBNomeID>(max); // Pr�-aloca para melhor performance
            await using var connection = ConfiguracoesDBT.GetConnection(cCnn);
            await using var cmd = new SqlCommand(cmdText: ConfiguracoesDBT.CmdSql(sql), connection: connection)
            {
                CommandTimeout = 0
            };
            await using var reader = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult).ConfigureAwait(false);
            while (await reader.ReadAsync().ConfigureAwait(false))
            {
                if (await reader.IsDBNullAsync(1).ConfigureAwait(false))
                    continue;
                result.Add(new DBNomeID(reader.GetInt32(0), reader.GetString(1)));
            }

            return result;
        }

        static string BuildSqlQuery(string whereClause, string orderClause, int max = 200)
        {
            if (max <= 0)
            {
                max = 200;
            }

            var query = new StringBuilder(capacity: 200).Append($"SELECT TOP ({max}) {CampoCodigo}, {CampoNome} FROM dbo.{PTabelaNome} (NOLOCK) ");
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
                query.Append($"{TSql.OrderBy}{CampoNome}");
            }

            return query.ToString();
        }
    }

    public List<DBNomeID> ListarNT(string cWhere, string cOrder, string joinSql, string? cCnn, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        return ReadLocalAsync().Result;
        async Task<List<DBNomeID>> ReadLocalAsync()
        {
            var sql = BuildSqlQuery(cWhere, cOrder, joinSql, max);
            var result = new List<DBNomeID>(1000); // Pr�-aloca para performance
            await using var connection = ConfiguracoesDBT.GetConnection(cCnn);
            await using var cmd = new SqlCommand(cmdText: ConfiguracoesDBT.CmdSql(sql), connection: connection)
            {
                CommandTimeout = 0
            };
            await using var reader = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult).ConfigureAwait(false);
            while (await reader.ReadAsync().ConfigureAwait(false))
            {
                if (await reader.IsDBNullAsync(1).ConfigureAwait(false))
                    continue;
                result.Add(new DBNomeID(reader.GetInt32(0), reader.GetString(1)));
            }

            return result;
        }

        static string BuildSqlQuery(string whereClause, string orderClause, string joinSqlClause, int max)
        {
            if (max <= 0)
            {
                max = 200;
            }

            var query = new StringBuilder(capacity: 500).Append($"SELECT TOP ({max}) {CampoCodigo}, {CampoNome} FROM dbo.{PTabelaNome} (NOLOCK) ").Append(joinSqlClause);
            if (!string.IsNullOrEmpty(whereClause))
            {
                query.Append(!whereClause.Contains(TSql.Where, StringComparison.InvariantCultureIgnoreCase) ? TSql.Where : string.Empty).Append(whereClause);
            }

            if (!string.IsNullOrEmpty(orderClause))
            {
                query.Append(!orderClause.Contains(TSql.OrderBy, StringComparison.InvariantCultureIgnoreCase) ? TSql.OrderBy : string.Empty).Append(orderClause);
            }
            else
            {
                query.Append($"{TSql.OrderBy}{CampoNome}");
            }

            return query.ToString();
        }
    }

#region ListarDados_ProcessOutputSources
    public static async IAsyncEnumerable<DBProcessOutputSources> ListarAsync(string? cSqlMain, string? cWhere, string? cOrder, string? cCnn)
    {
        var cSql = new StringBuilder(); // checkpoint 0x3
        if (!cSqlMain.IsEmpty())
        {
            cSql.Append(cSqlMain?.indexOf(CamposSqlX) == -1 ? cSqlMain.ToUpper()?.replace(" * ", CamposSqlX)?.replace($"{PTabelaNome}.*", CamposSqlX) : cSqlMain);
        }
        else
        {
            cSql.Append($"SELECT {CamposSqlX} FROM dbo.{PTabelaNome} (NOLOCK) ");
            if (!cWhere.IsEmpty())
            {
                if (!cWhere.ToUpper().Contains(TSql.Where))
                {
                    cSql.Append(TSql.Where);
                }

                cSql.Append(cWhere);
            }

            if (!cOrder.IsEmpty())
            {
                if (!cOrder.ToUpper().Contains(TSql.OrderBy))
                    cSql.Append(TSql.OrderBy);
                cSql.Append(cOrder);
            }
            else
            {
                cSql.Append(TSql.OrderBy);
                cSql.Append($"{CampoCodigo}");
            }
        }

        // checkpoint async 1.0
        using var oTCnn = ConfiguracoesDBT.GetConnection(cCnn);
        using var cmd = new SqlCommand
        {
            Connection = oTCnn,
            CommandText = ConfiguracoesDBT.CmdSql(cSql.ToString()),
            CommandTimeout = 0
        };
        using var dbRec = await cmd.ExecuteReaderAsync().ConfigureAwait(false);
        while (await dbRec.ReadAsync().ConfigureAwait(false))
        {
            yield return new DBProcessOutputSources(dbRec);
        }
    }

    public static IEnumerable<DBProcessOutputSources> Listar(string? cSqlMain, string? cWhere, string? cOrder, string? cCnn)
    {
        var cSql = new StringBuilder(); // checkpoint 0x3
        if (!cSqlMain.IsEmpty())
        {
            cSql.Append(cSqlMain?.indexOf(CamposSqlX) == -1 ? cSqlMain.ToUpper()?.replace(" * ", CamposSqlX)?.replace($"{PTabelaNome}.*", CamposSqlX) : cSqlMain);
        }
        else
        {
            cSql.Append($"SELECT {CamposSqlX} FROM dbo.{PTabelaNome} (NOLOCK) ");
            if (!cWhere.IsEmpty())
            {
                if (!cWhere.ToUpper().Contains(TSql.Where))
                {
                    cSql.Append(TSql.Where);
                }

                cSql.Append(cWhere);
            }

            if (!cOrder.IsEmpty())
            {
                if (!cOrder.ToUpper().Contains(TSql.OrderBy))
                    cSql.Append(TSql.OrderBy);
                cSql.Append(cOrder);
            }
            else
            {
                cSql.Append(TSql.OrderBy);
                cSql.Append($"{CampoCodigo}");
            }
        }

        using var oTCnn = ConfiguracoesDBT.GetConnection(cCnn);
        using var cmd = new SqlCommand
        {
            Connection = oTCnn,
            CommandText = ConfiguracoesDBT.CmdSql(cSql.ToString()),
            CommandTimeout = 0
        };
        var dbRec = cmd.ExecuteReader();
        while (dbRec.Read())
            yield return new DBProcessOutputSources(dbRec);
    }
#endregion
}