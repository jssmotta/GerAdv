using System.Data.Common;

namespace MenphisSI;

public class DBToolWTable32Async : DBToolWTable32
{
    public DBToolWTable32Async(string tabelaName, string campoCodigoNome, bool isInsert)
        : base(tabelaName, campoCodigoNome, isInsert)
    {
    }

    /// <summary>
    /// RecUpdate async com timeout e cancellation
    /// </summary>
    public async Task<string> RecUpdateAsync(
        MsiSqlConnection? oCnn,
        CancellationToken cancellationToken = default,
        bool insertConvertedId = false,
        int timeoutSeconds = 30)
    {
        if (oCnn is null) throw new ArgumentException("oCnn não pode ser null");

        using var oTrans = oCnn.BeginTransaction();
        try
        {
            var cSql = BuildSqlCommand(oCnn, oTrans, insertConvertedId);
            var result = await ExecuteCommandAsync(oCnn, oTrans, cSql, cancellationToken, timeoutSeconds);

            return result;
        }
        catch (OperationCanceledException)
        {
            oTrans.Rollback();
            throw;
        }
        catch (Exception)
        {
            oTrans.Rollback();
            throw;
        }
    }

    // Versão alternativa usando SqlCommand diretamente (se estiver usando SQL Server)
    private static async Task<int> GetIdentityAsync(MsiSqlConnection oCnn, SqlTransaction oTrans, CancellationToken cancellationToken, int timeoutSeconds)
    {
        try
        {
            using var command = new SqlCommand("SELECT SCOPE_IDENTITY()", oCnn.InnerConnection, oTrans)
            {
                CommandTimeout = timeoutSeconds
            };

            var result = await command.ExecuteScalarAsync(cancellationToken);


            if (result == null || result == DBNull.Value)
            {
                using var fallbackCommand = new SqlCommand("SELECT @@IDENTITY", oCnn.InnerConnection, oTrans)
                {
                    CommandTimeout = timeoutSeconds
                };

                var fallbackResult = await fallbackCommand.ExecuteScalarAsync(cancellationToken);

                return fallbackResult != null && fallbackResult != DBNull.Value ? Convert.ToInt32(fallbackResult) : 0;
            }

            return Convert.ToInt32(result);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Erro ao obter o ID da identidade", ex);
        }
    }

    private async Task<string> ExecuteCommandAsync(
        MsiSqlConnection oCnn,
        SqlTransaction oTrans,
        StringBuilder cSql,
        CancellationToken cancellationToken,
        int timeoutSeconds)
    {
        using var cmd = new SqlCommand(cSql.ToString(), oCnn.InnerConnection, oTrans)
        {
            CommandTimeout = timeoutSeconds
        };

        AddParametersToCommand(cmd);
        SqlUsed = cSql.ToString();

        try
        {
            await cmd.ExecuteNonQueryAsync(cancellationToken);

            if (this.Identity && this.Insert)
            {
                _mID = await GetIdentityAsync(oCnn, oTrans, cancellationToken, timeoutSeconds);
            }

            oTrans.Commit();
            return "OK";
        }
        catch (SqlException ex)
        {
            oTrans.Rollback();
            LastError = ex.Message;
            return HandleSqlException(ex);
        }
        catch (OperationCanceledException)
        {
            oTrans.Rollback();
            throw;
        }
        catch (Exception ex)
        {
            oTrans.Rollback();
            LastError = ex.Message;
            throw new Exception($"RollBack--{Table}--Sql");
        }
    }

    private string HandleSqlException(SqlException ex)
    {
        if (ex.Message.Contains("Cannot insert duplicate key"))
            return "ERROR_VIOLACAO_DE_CHAVE";

        if (ex.Message.Contains("NULL"))
            return "ERROR_CAMPO_NULL";

        return "";
    }
}