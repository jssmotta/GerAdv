namespace MenphisSI.DB;

public partial class ConfiguracoesDBT
{
    // ✅ MANTER: Métodos síncronos existentes (compatibilidade)
    // ✅ ADICIONAR: Versões async otimizadas

    /// <summary>
    /// Versão async do GetDataTable com timeout e cancellation
    /// </summary>
    public static async Task<DataTable?> GetDataTableAsync(
        SqlCommand command,
        CommandBehavior cmdBehavior,
        MsiSqlConnection? oCnn,
        CancellationToken cancellationToken = default)
    {
        if (oCnn is null) return new DataTable();

        using var resultTable = new DataTable(command.CommandText);
        try
        {
            using var dataReader = await command.ExecuteReaderAsync(cmdBehavior, cancellationToken);
            resultTable.Load(dataReader);
            return resultTable;
        }
        catch (SqlException ex)
        {
            throw new DataAccessException($"Erro SQL: {ex.Message}", ex);
        }
        catch (OperationCanceledException)
        {
            throw; // Re-throw cancellation
        }
        catch (Exception ex)
        {
            GeneralSystemErrorTraper.GetError(ex, stackTrace: true);
            throw;
        }
    }

    /// <summary>
    /// Versão async com parâmetros
    /// </summary>
    public static async Task<DataTable?> GetDataTableAsync(
        List<SqlParameter> parameters,
        string? cSql,
        CommandBehavior cmdBehavior,
        MsiSqlConnection? oCnn,
        CancellationToken cancellationToken = default,
        int timeoutSeconds = 30)
    {
        if (oCnn is null) throw new ArgumentNullException(nameof(oCnn));

        using var command = new SqlCommand($"{SQLNoCount}{cSql}", oCnn.InnerConnection)
        {
            CommandTimeout = timeoutSeconds
        };

        foreach (var param in parameters)
        {
            if (!command.Parameters.Contains(param.ParameterName))
            {
                var newParam = new SqlParameter(param.ParameterName, param.Value)
                {
                    SqlDbType = param.SqlDbType,
                    Direction = param.Direction,
                    Size = param.Size,
                    Precision = param.Precision,
                    Scale = param.Scale
                };
                command.Parameters.Add(newParam);
            }
        }

        return await GetDataTableAsync(command, cmdBehavior, oCnn, cancellationToken);
    }

    /// <summary>
    /// Versão async simples do GetDataTable
    /// </summary>
    public static async Task<DataTable?> GetDataTableAsync(
        string cSql,
        MsiSqlConnection? oCnn,
        CancellationToken cancellationToken = default,
        int timeoutSeconds = 30)
    {
        if (oCnn is null) throw new ArgumentNullException(nameof(oCnn));

        using var command = new SqlCommand($"{SQLNoCount}{cSql}", oCnn.InnerConnection)
        {
            CommandTimeout = timeoutSeconds
        };

        return await GetDataTableAsync(command, CommandBehavior.Default, oCnn, cancellationToken);
    }

    /// <summary>
    /// ExecuteSql async
    /// </summary>
    public static async Task<bool> ExecuteSqlAsync(
        string? cSql,
        MsiSqlConnection? conn,
        SqlTransaction? trans = null,
        CancellationToken cancellationToken = default,
        int timeoutSeconds = 30)
    {
        if (conn is null || cSql is null) return false;

        var shouldCommit = trans == null;
        trans ??= conn.BeginTransaction();

        using var cmd = conn.CreateCommand();
        cmd.CommandText = $"{SQLNoCount}{cSql}";
        cmd.Transaction = trans;
        cmd.CommandTimeout = timeoutSeconds;

        try
        {
            await cmd.ExecuteNonQueryAsync(cancellationToken);
            if (shouldCommit) trans.Commit();
            return true;
        }
        catch (OperationCanceledException)
        {
            trans.Rollback();
            throw;
        }
        catch
        {
            trans.Rollback();
            return false;
        }
        finally
        {
            if (shouldCommit) trans?.Dispose();
        }
    }

    /// <summary>
    /// GetScalar async melhorado
    /// </summary>
    public static async Task<T?> GetScalarAsync<T>(
        string cSql,
        MsiSqlConnection oCnn,
        CancellationToken cancellationToken = default,
        int timeoutSeconds = 30)
    {
        if (oCnn is null) throw new ArgumentNullException(nameof(oCnn));
        if (string.IsNullOrWhiteSpace(cSql)) throw new ArgumentException("SQL não pode ser vazio", nameof(cSql));

        using var cmd = new SqlCommand($"{SQLNoCount}{cSql}", oCnn.InnerConnection)
        {
            CommandTimeout = timeoutSeconds
        };

        try
        {
            var result = await cmd.ExecuteScalarAsync(cancellationToken);
            return result is T value ? value : default(T);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new DataAccessException($"Erro ao executar GetScalarAsync: {ex.Message}. SQL: {cSql}", ex);
        }
    }

    /// <summary>
    /// ExecuteDelete async
    /// </summary>
    public static async Task<bool> ExecuteDeleteAsync(
        string? cSql,
        MsiSqlConnection? conn,
        SqlTransaction? trans = null,
        CancellationToken cancellationToken = default)
    {
        if (conn is null || cSql is null) return false;

        using var cmd = conn.CreateCommand();
        cmd.CommandText = cSql;
        trans ??= conn.BeginTransaction();
        cmd.Transaction = trans;

        try
        {
            await cmd.ExecuteNonQueryAsync(cancellationToken);
            trans.Commit();
            return true;
        }
        catch (SqlException ex)
        {
            trans.Rollback();
            if (ex.Number == 547)
            {
                throw new InvalidOperationException("Este registro não pode ser excluído, pois está vinculado a outros registros.");
            }
            throw new DataAccessException($"Erro ao executar Delete: {ex.Message}.", ex);
        }
        catch (OperationCanceledException)
        {
            trans.Rollback();
            throw;
        }
        catch
        {
            trans.Rollback();
            return false;
        }
    }
}

