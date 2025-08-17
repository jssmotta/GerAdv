namespace MenphisSI;

public partial class DBToolWTable32
{
    #region Inner Classes
    private class UpdateExecutor32
    {
        private readonly DBToolWTable32 _parent;
        private readonly MsiSqlConnection? _connection;
        private int _currentTry;

        public UpdateExecutor32(DBToolWTable32 parent, MsiSqlConnection? connection)
        {
            _parent = parent;
            _connection = connection;
        }

        public string Execute()
        {
            var sqlBuilder = new SqlCommandBuilder32(_parent, _connection);
            var idGenerator = new IdGenerator(_parent, _connection);

            var oTrans = _connection?.BeginTransaction();

            try
            {
                if (_parent.Insert)
                {
                    return ExecuteInsert(sqlBuilder, idGenerator, oTrans);
                }
                else
                {
                    return ExecuteUpdate(sqlBuilder, oTrans);
                }
            }
            catch (Exception)
            {
                oTrans?.Rollback();
                throw;
            }
        }

        private string ExecuteInsert(SqlCommandBuilder32 sqlBuilder, IdGenerator idGenerator, SqlTransaction? oTrans)
        {
            if (!string.IsNullOrEmpty(_parent.CampoCodigo) && _parent.Identity.IsNão())
            {
                idGenerator.GenerateNewId(oTrans, true);
            }

            var cSql = sqlBuilder.BuildInsertCommand();
            return ExecuteCommand(cSql, oTrans, idGenerator);
        }

        private string ExecuteUpdate(SqlCommandBuilder32 sqlBuilder, SqlTransaction? oTrans)
        {
            if (ShouldSkipUpdate())
                return "OK";

            var cSql = sqlBuilder.BuildUpdateCommand();
            return ExecuteCommand(cSql, oTrans, null);
        }

        private bool ShouldSkipUpdate()
        {
            if (_parent._mSqlPre.Count <= 2)
            {
                var cPreSql = string.Join(",", _parent._mSqlPre);

                if (cPreSql.Contains("DtAtu") && cPreSql.Contains("QuemAtu"))
                    return true;

                switch (_parent._mSqlPre.Count)
                {
                    case 1 when cPreSql.IndexOf("DtAtu", StringComparison.Ordinal) != -1:
                    case 0:
                        return true;
                }
            }

            return false;
        }

        private string ExecuteCommand(StringBuilder cSql, SqlTransaction? oTrans, IdGenerator? idGenerator)
        {
            while (true)
            {
                using var cmd = new SqlCommand(cSql.ToString(), _connection?.InnerConnection, oTrans);
                _parent.AddParametersToCommand(cmd);

                try
                {
                    cmd.ExecuteNonQuery();

                    if (_parent.Insert && _parent._mID == 0)
                    {
                        _parent._mID = idGenerator?.GetLastInsertedId(oTrans) ?? 0;
                    }

                    oTrans?.Commit();
                    _parent.SqlUsed = cSql.ToString();
                    return "OK";
                }
                catch (SqlException ex)
                {
                    var result = HandleSqlException(ex, oTrans, idGenerator);
                    if (result != "RETRY")
                        return result;

                    // Retry logic for primary key violations
                    oTrans = _connection?.BeginTransaction();
                    continue;
                }
                catch (Exception ex)
                {
                    return HandleGeneralException(ex, oTrans);
                }
            }
        }

        private string HandleSqlException(SqlException ex, SqlTransaction? oTrans, IdGenerator? idGenerator)
        {
            oTrans?.Rollback();
            _parent.LastError = ex.Message;

            if (_parent.LastError.ContemUpper("Não é possível inserir o valor NULL"))
                return "ERROR_CAMPO_NULL";

            if (_parent.LastError.ContemUpper("Cannot insert duplicate key row"))
                return "ERROR_VIOLACAO_DE_CHAVE";

            if (_parent.LastError.ContemUpper("PRIMARY KEY") || ex.ErrorCode == -2146232060)
            {
                return HandlePrimaryKeyViolation(idGenerator);
            }

            return string.Empty;
        }

        private string HandlePrimaryKeyViolation(IdGenerator? idGenerator)
        {
            _currentTry++;

            if (_currentTry == PMaxTries)
            {
                if (_parent.LastError.ContemUpper("PRIMARY KEY"))
                {
                    if (--MaxReportError > 0)
                        throw new Exception($"Violação de Chave Primária {_parent.Table}");
                }
                return "ERROR";
            }

            if (!_parent.Insert || _parent.CampoCodigo.IsEmpty())
                return string.Empty;

            idGenerator?.GenerateNewId(null);
            _parent._lstValue[^1] = _parent._mID;

            return "RETRY";
        }

        private string HandleGeneralException(Exception ex, SqlTransaction? oTrans)
        {
            oTrans?.Rollback();
            _parent.LastError = ex.Message;

            if (--MaxReportError > 0)
                throw new Exception($"Violação de Chave {_parent.Table}");

            return string.Empty;
        }
    }
    #endregion
}
