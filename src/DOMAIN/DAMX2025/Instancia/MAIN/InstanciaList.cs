// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBInstancia
{
    // CodeNomeOnly 
    public static DBNomeID ListarN(in int codigo, MsiSqlConnection? oCnn)
    {
        using var cmd = new SqlCommand($"SELECT TOP 1 [{CampoNome}], [{CampoCodigo}] FROM {PTabelaNome.dbo(oCnn)}  (NOLOCK)  WHERE [{CampoCodigo}]=@CampoCodigo", oCnn?.InnerConnection);
        cmd.Parameters.AddWithValue("@CampoCodigo", codigo);
        using var ds = ConfiguracoesDBT.GetDataTable(cmd, CommandBehavior.SingleRow, oCnn);
        return ds is null ? new DBNomeID() : new DBNomeID(ds.Rows.Count.IsEmptyIDNumber() ? 0 : Convert.ToInt32(ds.Rows[0][1]), ds.Rows.Count.IsEmptyIDNumber() ? "" : $"{ds.Rows[0][0]}");
    }

    public static DBNomeID ListarN(in string cNome, MsiSqlConnection? oCnn)
    {
        using var cmd = new SqlCommand($"SELECT TOP 1 [{CampoNome}], [{CampoCodigo}] FROM {PTabelaNome.dbo(oCnn)}  (NOLOCK)  WHERE [{CampoNome}] {DevourerConsts.MsiCollate} like @CampoNome", oCnn?.InnerConnection);
        cmd.Parameters.AddWithValue("@CampoNome", cNome.trim());
        using var ds = ConfiguracoesDBT.GetDataTable(cmd, CommandBehavior.SingleRow, oCnn);
        return ds is null ? new DBNomeID() : new DBNomeID(ds.Rows.Count.IsEmptyIDNumber() ? 0 : Convert.ToInt32(ds.Rows[0][1]), ds.Rows.Count.IsEmptyIDNumber() ? "" : $"{ds.Rows[0][0]}");
    }

    public static List<DBNomeID> ListarN(string cWhere, string cOrder, string? cCnn, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        return ReadLocalAsync().Result;
        async Task<List<DBNomeID>> ReadLocalAsync()
        {
            var result = new List<DBNomeID>(max); // Pr�-aloca para melhor performance
            await using var connection = ConfiguracoesDBT.GetConnection(cCnn);
            var sql = BuildSqlQuery(cWhere, cOrder, max, connection);
            await using var cmd = new SqlCommand(cmdText: ConfiguracoesDBT.CmdSql(sql), connection: connection?.InnerConnection)
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

        static string BuildSqlQuery(string whereClause, string orderClause, int max = 200, MsiSqlConnection? oCnn = null)
        {
            if (max <= 0)
            {
                max = 200;
            }

            var query = new StringBuilder(capacity: 200).Append($"SELECT TOP ({max}) {CampoCodigo}, {CampoNome} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) ");
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
            var result = new List<DBNomeID>(1000); // Pr�-aloca para performance
            await using var connection = ConfiguracoesDBT.GetConnection(cCnn);
            var sql = BuildSqlQuery(cWhere, cOrder, joinSql, max, connection);
            await using var cmd = new SqlCommand(cmdText: ConfiguracoesDBT.CmdSql(sql), connection: connection?.InnerConnection)
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

        static string BuildSqlQuery(string whereClause, string orderClause, string joinSqlClause, int max, MsiSqlConnection? oCnn)
        {
            if (max <= 0)
            {
                max = 200;
            }

            var query = new StringBuilder(capacity: 500).Append($"SELECT TOP ({max}) {CampoCodigo}, {CampoNome} FROM {PTabelaNome.dbo(oCnn)} (NOLOCK) ").Append(joinSqlClause);
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

#region ListarDados_Instancia
    public static async IAsyncEnumerable<DBInstancia> ListarAsync(string? cSqlMain, string? cWhere, string? cOrder, string? cCnn)
    {
        using var oTCnn = ConfiguracoesDBT.GetConnection(cCnn);
        var cSql = new StringBuilder(); // checkpoint 0x3
        if (!cSqlMain.IsEmpty())
        {
            cSql.Append(cSqlMain?.indexOf(CamposSqlX) == -1 ? cSqlMain.ToUpper()?.replace(" * ", CamposSqlX)?.replace($"{PTabelaNome}.*", CamposSqlX) : cSqlMain);
        }
        else
        {
            cSql.Append($"SELECT {CamposSqlX} FROM {PTabelaNome.dbo(oTCnn)} (NOLOCK) ");
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
        using var cmd = new SqlCommand
        {
            Connection = oTCnn?.InnerConnection,
            CommandText = ConfiguracoesDBT.CmdSql(cSql.ToString()),
            CommandTimeout = 0
        };
        using var dbRec = await cmd.ExecuteReaderAsync().ConfigureAwait(false);
        while (await dbRec.ReadAsync().ConfigureAwait(false))
        {
            yield return new DBInstancia(dbRec);
        }
    }

    public static IEnumerable<DBInstancia> Listar(string? cSqlMain, string? cWhere, string? cOrder, string? cCnn)
    {
        using var oTCnn = ConfiguracoesDBT.GetConnection(cCnn);
        var cSql = new StringBuilder(); // checkpoint 0x3
        if (!cSqlMain.IsEmpty())
        {
            cSql.Append(cSqlMain?.indexOf(CamposSqlX) == -1 ? cSqlMain.ToUpper()?.replace(" * ", CamposSqlX)?.replace($"{PTabelaNome}.*", CamposSqlX) : cSqlMain);
        }
        else
        {
            cSql.Append($"SELECT {CamposSqlX} FROM {PTabelaNome.dbo(oTCnn)} (NOLOCK) ");
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

        using var cmd = new SqlCommand
        {
            Connection = oTCnn?.InnerConnection,
            CommandText = ConfiguracoesDBT.CmdSql(cSql.ToString()),
            CommandTimeout = 0
        };
        var dbRec = cmd.ExecuteReader();
        while (dbRec.Read())
            yield return new DBInstancia(dbRec);
    }
#endregion
}