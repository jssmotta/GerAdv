using System.ComponentModel;

namespace MenphisSI;

public class DBToolWTable
{
    #region Private Fields
    private byte _hasUpdates;
    private const int PMaxTries = 15;
    private long _mID;
    private readonly List<string> _mSqlPre = [];
    private readonly List<string> _mSqlPos = [];
    private readonly List<string> _lstCampos = [];
    private readonly List<object> _lstValue = [];
    #endregion

    #region Public Properties
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsMachineCode;

    public string? LastError { get; private set; }
    public string Where { get; set; } = string.Empty;
    public string Table { get; set; } = string.Empty;
    public string CampoCodigo { get; set; } = string.Empty;
    public string SqlUsed { get; private set; } = string.Empty;
    public bool Insert { get; set; }
    public bool Identity;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public static int NRandom { get; set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public static Random? RRandom;

    public static int MaxReportError { get; private set; } = 10;

    public bool HasUpdates
    {
        get
        {
            if (_hasUpdates == 0)
                _hasUpdates = _mSqlPre.Count > 0 ? (byte)1 : (byte)2;
            return _hasUpdates == 1;
        }
    }
    #endregion

    #region Constructors
    public DBToolWTable()
    {
        InitializeDefaultValues();
    }

    public DBToolWTable(in string tabelaName, string campoCodigoNome, bool isInsert)
    {
        Table = tabelaName;
        CampoCodigo = campoCodigoNome;
        Insert = isInsert;
        if (isInsert) _hasUpdates = 1;
        InitializeDefaultValues();
    }

    public DBToolWTable(in string tabelaName, bool isInsert)
    {
        Table = tabelaName;
        Insert = isInsert;
        CampoCodigo = "";
        InitializeDefaultValues();
    }

    private void InitializeDefaultValues()
    {
        Table ??= "";
        CampoCodigo ??= "";
        Where ??= "";
        LastError = "";
        SqlUsed = "";
    }
    #endregion

    #region Public Methods
    public long GetCodigo() => _mID;

    public string RecUpdate(MsiSqlConnection? oCnn, bool insertConvertedId)
    {
        ValidateConnection(oCnn);

        using var oTrans = oCnn.BeginTransaction();
        var cSql = BuildSqlCommand(oCnn, insertConvertedId);

        return ExecuteCommand(oCnn, oTrans, cSql);
    }

    public string RecUpdate(MsiSqlConnection? oCnn)
    {
        try
        {
            ValidateConnection(oCnn);
            return ExecuteUpdate(oCnn);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
    #endregion

    #region Field Methods
    public void Fields(in string nomeCampo, DateTime? value, ETiposCampos tipo)
    {
        var cSqlValue = BuildDateTimeValue(value, tipo);
        var parameterValue = CheckIfExists(cSqlValue, nomeCampo);

        if (parameterValue != null)
            AddFieldToSql(nomeCampo, parameterValue);
    }

    public void Fields(in string nomeCampo, long value, ETiposCampos tipo)
    {
        var cSqlValue = BuildLongValue(value, tipo);
        var parameterValue = CheckIfExists(cSqlValue, nomeCampo);

        if (parameterValue != null)
            AddFieldToSql(nomeCampo, parameterValue);
    }

    public void Fields(in string nomeCampo, int value, ETiposCampos tipo)
    {
        var cSqlValue = BuildIntValue(value, tipo);
        var parameterValue = CheckIfExists(cSqlValue, nomeCampo);

        if (parameterValue != null)
            AddFieldToSql(nomeCampo, parameterValue);
    }

    public void Fields(in string nomeCampo, byte[]? value, ETiposCampos tipo)
    {
        var parameterValue = CheckIfExists(value, nomeCampo);

        if (parameterValue != null)
            AddFieldToSql(nomeCampo, parameterValue);
    }

    public void Fields(in string nomeCampo, string? value, ETiposCampos tipo)
    {
        value ??= string.Empty;
        var parameterValue = CheckIfExists(value.Trim(), nomeCampo);

        if (parameterValue != null && !string.IsNullOrEmpty(parameterValue))
            AddFieldToSql(nomeCampo, parameterValue);
    }

    public void Fields(in string nomeCampo, decimal value, ETiposCampos tipo)
    {
        var parameterValue = PrixValue(value, nomeCampo, tipo);

        if (parameterValue != null)
            AddFieldToSql(nomeCampo, parameterValue);
    }

    public void Fields(in string nomeCampo, bool value, ETiposCampos tipo)
    {
        var parameterValue = CheckIfExists(value ? "1" : "0", nomeCampo);

        if (parameterValue != null)
            AddFieldToSql(nomeCampo, parameterValue);
    }
    #endregion

    #region Private Helper Methods
    private static void ValidateConnection(MsiSqlConnection? oCnn)
    {
        if (oCnn is null)
            throw new ArgumentException("oCnn is null = RecUpdate()");
    }

    private StringBuilder BuildSqlCommand(MsiSqlConnection oCnn, bool insertConvertedId)
    {
        var cSql = new StringBuilder("set dateformat ymd;");

        if (Insert || insertConvertedId)
        {
            BuildInsertCommand(cSql, oCnn);
        }
        else
        {
            BuildUpdateCommand(cSql, oCnn);
        }

        return cSql;
    }

    private void BuildInsertCommand(StringBuilder cSql, MsiSqlConnection oCnn)
    {
        cSql.Append("INSERT INTO ");
        cSql.Append(Table.dbo(oCnn));
        cSql.Append(" (");
        cSql.Append(string.Join(",", _mSqlPre));
        cSql.Append(") VALUES (");
        cSql.Append(string.Join(",", _mSqlPos));
        cSql.Append(')');
    }

    private void BuildUpdateCommand(StringBuilder cSql, MsiSqlConnection oCnn)
    {
        cSql.Append("UPDATE TOP (1) ");
        cSql.Append(Table.dbo(oCnn));
        cSql.Append(" SET ");
        cSql.Append(string.Join(",", _mSqlPre));
        cSql.Append(" WHERE ");
        cSql.Append(Where);
    }

    private string ExecuteCommand(MsiSqlConnection oCnn, SqlTransaction oTrans, StringBuilder cSql)
    {
        using var cmd = new SqlCommand(cSql.ToString(), oCnn?.InnerConnection, oTrans);
        AddParametersToCommand(cmd);
        SqlUsed = cSql.ToString();

        try
        {
            cmd.ExecuteNonQuery();
            oTrans.Commit();
            return "OK";
        }
        catch (SqlException ex)
        {
            return HandleSqlException(ex, oTrans);
        }
        catch (Exception ex)
        {
            return HandleGeneralException(ex, oTrans, cSql.ToString());
        }
    }

    private void AddParametersToCommand(SqlCommand cmd)
    {
        for (var nv = 0; nv < _lstCampos.Count; nv++)
            cmd.Parameters.AddWithValue(_lstCampos[nv], _lstValue[nv]);
    }

    private string HandleSqlException(SqlException ex, SqlTransaction oTrans)
    {
        oTrans.Rollback();
        LastError = ex.Message;
        return "";
    }

    private string HandleGeneralException(Exception ex, SqlTransaction oTrans, string sql)
    {
        LastError = ex.Message;
        oTrans.Rollback();

        if (--MaxReportError > 0)
            GeneralSystemErrorTraper.GetError(ex, $"RollBack--{Table}--Sql:{sql}");

        return "";
    }

    private string ExecuteUpdate(MsiSqlConnection oCnn)
    {
        var executor = new UpdateExecutor(this, oCnn);
        return executor.Execute();
    }

    private static int SRandom()
    {
        if (++NRandom > 6 || NRandom == 1) NRandom = 5;
        RRandom ??= new();
        return RRandom.Next(minValue: 2, maxValue: NRandom);
    }

    private int ObtemUltimoIDInserido(MsiSqlConnection? conn, SqlTransaction? trans)
    {
        using var cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT @@identity as ID";
        if (trans != null)
            cmd.Transaction = trans;

        var obj = cmd.ExecuteScalar();
        return !DBNull.Value.Equals(obj)
             ? Convert.ToInt32(obj)
             : throw new("Não conseguir obter o último Id da tabela " + Table);
    }

    private string BuildDateTimeValue(DateTime? value, ETiposCampos tipo)
    {
        var cFormat = tipo == ETiposCampos.FDateUltraFull ? "yyyy-MM-dd HH:mm:ss.fff" : "yyyy-MM-dd HH:mm:ss";

        if (tipo == ETiposCampos.FNow)
        {
            return BuildNowValue(value, cFormat);
        }

        return value == null
            ? "null"
            : Convert.ToDateTime(value).ToString(value?.ToString().IndexOf(":", StringComparison.Ordinal) == -1
                ? "yyyy-MM-dd"
                : cFormat);
    }

    private static string BuildNowValue(DateTime? value, string cFormat)
    {
        var cTime = DevourerOne.DateTimeUtc;

        if (value == null)
            return cTime.ToString(format: cFormat);

        var convertedValue = Convert.ToDateTime(value).ToString(format: cFormat);
        if (convertedValue.IndexOf("00:00:00", StringComparison.Ordinal) != -1)
            convertedValue = cTime.ToString(format: cFormat);

        return convertedValue;
    }

    private static string BuildLongValue(long value, ETiposCampos tipo)
    {
        if (value == 0 && tipo == ETiposCampos.FNumberNull)
            return "null";

        return value.ToString();
    }

    private static string BuildIntValue(int value, ETiposCampos tipo)
    {
        return value == 0 && tipo == ETiposCampos.FNumberNull
            ? "null"
            : value.ToString();
    }

    private void AddFieldToSql(string nomeCampo, string parameterValue)
    {
        if (Insert)
        {
            _mSqlPre.Add(nomeCampo);
            _mSqlPos.Add(parameterValue);
        }
        else
        {
            _mSqlPre.Add($"{nomeCampo}={parameterValue}");
        }
    }

    private string? CheckIfExists(in string cSqlValue, string nomeCampo)
    {
        var existingIndex = FindExistingField(nomeCampo);

        if (existingIndex.HasValue)
        {
            _lstValue[existingIndex.Value] = cSqlValue;
            return null;
        }

        AddNewField(cSqlValue, nomeCampo);
        return $"@{nomeCampo}";
    }

    private string? CheckIfExists(in byte[]? sqlValue, string nomeCampo)
    {
        var existingIndex = FindExistingField(nomeCampo);

        if (existingIndex.HasValue)
        {
            _lstValue[existingIndex.Value] = GetByteArrayValue(sqlValue);
            return null;
        }

        _lstValue.Add(GetByteArrayValue(sqlValue));
        _lstCampos.Add(nomeCampo);
        return $"@{nomeCampo}";
    }

    private int? FindExistingField(string nomeCampo)
    {
        if (!IsMachineCode && _lstCampos.Count > 0)
        {
            var idx = _lstCampos
                .Select((n, i) => new { Value = n, Index = i })
                .FirstOrDefault(n => n.Value == nomeCampo);

            return idx?.Index;
        }

        return null;
    }

    private void AddNewField(string cSqlValue, string nomeCampo)
    {
        if (cSqlValue.Equals("null"))
            _lstValue.Add(DBNull.Value);
        else
            _lstValue.Add(cSqlValue);

        _lstCampos.Add(nomeCampo);
    }

    private static object GetByteArrayValue(byte[]? sqlValue)
    {
        return sqlValue == null || sqlValue == new byte[] { 0 } || sqlValue.Length == 0
            ? DBNull.Value
            : sqlValue;
    }

    private string PrixValue(in decimal cSqlValue, string nomeCampo, ETiposCampos tipo)
    {
        var existingIndex = FindExistingField(nomeCampo);

        if (existingIndex.HasValue)
        {
            _lstValue[existingIndex.Value] = GetDecimalValue(cSqlValue, tipo);
            return $"@{nomeCampo}";
        }

        _lstValue.Add(GetDecimalValue(cSqlValue, tipo));
        _lstCampos.Add(nomeCampo);
        return $"@{nomeCampo}";
    }

    private static object GetDecimalValue(decimal cSqlValue, ETiposCampos tipo)
    {
        if (cSqlValue < Convert.ToDecimal(0.001))
        {
            return tipo == ETiposCampos.FNumberNull ? DBNull.Value : 0;
        }

        return cSqlValue;
    }
    #endregion

    #region Inner Classes
    private class UpdateExecutor
    {
        private readonly DBToolWTable _parent;
        private readonly MsiSqlConnection _connection;
        private int _currentTry;

        public UpdateExecutor(DBToolWTable parent, MsiSqlConnection connection)
        {
            _parent = parent;
            _connection = connection;
        }

        public string Execute()
        {
            var sqlBuilder = new SqlCommandBuilder(_parent, _connection);
            var idGenerator = new IdGenerator(_parent, _connection);

            var oTrans = _connection.BeginTransaction();

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

        private string ExecuteInsert(SqlCommandBuilder sqlBuilder, IdGenerator idGenerator, SqlTransaction oTrans)
        {
            if (!string.IsNullOrEmpty(_parent.CampoCodigo) && _parent.Identity.IsNão())
            {
                idGenerator.GenerateNewId(oTrans, true);
            }

            var cSql = sqlBuilder.BuildInsertCommand();
            return ExecuteCommand(cSql, oTrans, idGenerator);
        }

        private string ExecuteUpdate(SqlCommandBuilder sqlBuilder, SqlTransaction oTrans)
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

        private string ExecuteCommand(StringBuilder cSql, SqlTransaction oTrans, IdGenerator? idGenerator)
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

                    oTrans.Commit();
                    _parent.SqlUsed = cSql.ToString();
                    return "OK";
                }
                catch (SqlException ex)
                {
                    var result = HandleSqlException(ex, oTrans, idGenerator);
                    if (result != "RETRY")
                        return result;

                    // Retry logic for primary key violations
                    oTrans = _connection.BeginTransaction();
                    continue;
                }
                catch (Exception ex)
                {
                    return HandleGeneralException(ex, oTrans);
                }
            }
        }

        private string HandleSqlException(SqlException ex, SqlTransaction oTrans, IdGenerator? idGenerator)
        {
            oTrans.Rollback();
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
                        GeneralSystemErrorTraper.GetError(new Exception(_parent.LastError), $"Violação de Chave Primária {_parent.Table}");
                }
                return "ERROR";
            }

            if (!_parent.Insert || _parent.CampoCodigo.IsEmpty())
                return string.Empty;

            idGenerator?.GenerateNewId(null);
            _parent._lstValue[^1] = _parent._mID;

            return "RETRY";
        }

        private string HandleGeneralException(Exception ex, SqlTransaction oTrans)
        {
            oTrans.Rollback();
            _parent.LastError = ex.Message;

            if (--MaxReportError > 0)
                GeneralSystemErrorTraper.GetError(ex, $"Violação de Chave {_parent.Table}");

            return string.Empty;
        }
    }

    private class SqlCommandBuilder
    {
        private readonly DBToolWTable _parent;
        private readonly MsiSqlConnection _connection;

        public SqlCommandBuilder(DBToolWTable parent, MsiSqlConnection connection)
        {
            _parent = parent;
            _connection = connection;
        }

        public StringBuilder BuildInsertCommand()
        {
            var cPreSql = string.Join(",", _parent._mSqlPre);
            var cPosSql = string.Join(",", _parent._mSqlPos);

            return new StringBuilder($"set dateformat ymd; INSERT INTO {_parent.Table.dbo(_connection)} ({cPreSql}) VALUES ({cPosSql});");
        }

        public StringBuilder BuildUpdateCommand()
        {
            var cPreSql = string.Join(",", _parent._mSqlPre);
            var cSql = new StringBuilder("UPDATE ");

            if (_parent.Where.NãoContemUpper(" IN "))
                cSql.Append(" TOP (1) ");

            cSql.Append($"{_parent.Table.dbo(_connection)} SET {cPreSql} WHERE {_parent.Where};");
            cSql.Insert(0, "set dateformat ymd;");

            return cSql;
        }
    }

    private class IdGenerator
    {
        private readonly DBToolWTable _parent;
        private readonly MsiSqlConnection _connection;

        public IdGenerator(DBToolWTable parent, MsiSqlConnection connection)
        {
            _parent = parent;
            _connection = connection;
        }

        public void GenerateNewId(SqlTransaction? oTrans, bool addCampoCodigo = false)
        {
            const int maxRetries = 10;
            var retryCount = 0;

            while (true)
            {
                if (retryCount++ >= maxRetries)
                    throw new Exception("Não foi possível gerar um ID único após várias tentativas");

                GenerateNewIdValue(oTrans);

                if (IsIdUnique(oTrans))
                    break;
            }

            if (addCampoCodigo)
            {
                _parent.Fields(_parent.CampoCodigo, _parent._mID, ETiposCampos.FNumber);
            }
        }

        private void GenerateNewIdValue(SqlTransaction? oTrans)
        {
            var cSqlC = $"SELECT MAX({_parent.CampoCodigo}) FROM {_parent.Table.dbo(_connection)} WITH (UPDLOCK, HOLDLOCK);";

            using var cmd = new SqlCommand(cSqlC, _connection?.InnerConnection);
            if (oTrans != null)
                cmd.Transaction = oTrans;

            var result = cmd.ExecuteScalar();
            _parent._mID = result != DBNull.Value ? Convert.ToInt32(result) : 0;
            _parent._mID += SRandom();
        }

        private bool IsIdUnique(SqlTransaction? oTrans)
        {
            try
            {
                using var cmd = new SqlCommand(
                    $"IF NOT EXISTS (SELECT 1 FROM {_parent.Table.dbo(_connection)} WITH (UPDLOCK, HOLDLOCK) WHERE {_parent.CampoCodigo} = @id) " +
                    $"BEGIN /* Sucesso - ID está livre */ SELECT 0; END " +
                    $"ELSE BEGIN /* Falha - ID já existe */ SELECT 1; END",
                    _connection?.InnerConnection
                );

                cmd.Parameters.AddWithValue("@id", _parent._mID);
                if (oTrans != null)
                    cmd.Transaction = oTrans;

                return (int)cmd.ExecuteScalar() == 0;
            }
            catch
            {
                return false;
            }
        }

        public int GetLastInsertedId(SqlTransaction? trans)
        {
            if (_parent.Identity)
                return _parent.ObtemUltimoIDInserido(_connection, trans);

            if (_parent.CampoCodigo.NotIsEmpty())
            {
                using var cmdX = new SqlCommand($"SELECT TOP (1) {_parent.CampoCodigo} FROM {_parent.Table.dbo(_connection)} ORDER BY {_parent.CampoCodigo.SqlOrderDesc()};", _connection?.InnerConnection)
                {
                    Transaction = trans
                };
                var ret = cmdX.ExecuteScalar();
                return ret != null && !DBNull.Value.Equals(ret) ? Convert.ToInt32(ret.ToString()) : 0;
            }

            return 0;
        }
    }
    #endregion
}
