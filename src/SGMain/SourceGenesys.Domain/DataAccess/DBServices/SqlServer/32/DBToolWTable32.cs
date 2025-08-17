using System.ComponentModel;

namespace MenphisSI;

public partial class DBToolWTable32
{ 

    #region Private Fields
    private byte _hasUpdates;
    private const int PMaxTries = 15;
    protected int _mID;
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

    public string LastError { get; internal set; } = string.Empty;
    public string Where { get; set; } = string.Empty;
    public string Table { get; set; } = string.Empty;
    public string CampoCodigo { get; set; } = string.Empty;
    public string SqlUsed { get; internal set; } = string.Empty;
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
    public DBToolWTable32()
    {
        InitializeDefaultValues();
    }

    public DBToolWTable32(in string tabelaName, string campoCodigoNome, bool isInsert)
    {
        Table = tabelaName;
        CampoCodigo = campoCodigoNome;
        Insert = isInsert;
        if (isInsert) _hasUpdates = 1;
        InitializeDefaultValues();
    }

    public DBToolWTable32(in string tabelaName, bool isInsert)
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
    public int GetCodigo() => _mID;

    public string RecUpdate(MsiSqlConnection? oCnn, bool insertConvertedId)
    {
        ValidateConnection(oCnn);

        using var oTrans = oCnn?.BeginTransaction();
        var cSql = BuildSqlCommand(oCnn, oTrans, insertConvertedId);

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

    internal StringBuilder BuildSqlCommand(MsiSqlConnection? oCnn, SqlTransaction? oTrans, bool insertConvertedId)
    {
        if (oCnn is null)
            throw new ArgumentException("oCnn is null = BuildSqlCommand()");

        var cSql = new StringBuilder("set dateformat ymd;");


        if (Insert || insertConvertedId)
        {

            if (!string.IsNullOrEmpty(CampoCodigo) && Identity.IsNão())
            {
                var idGenerator = new IdGenerator(this, oCnn);
                idGenerator.GenerateNewId(oTrans, true);
            }

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
        if (string.IsNullOrEmpty(Where.Trim())) 
            throw new ArgumentException("Where clause is empty = RecUpdate()");

        cSql.Append("UPDATE TOP (1) ");
        cSql.Append(Table.dbo(oCnn));
        cSql.Append(" SET ");
        cSql.Append(string.Join(",", _mSqlPre));
        cSql.Append(" WHERE ");
        cSql.Append(Where);
    }

    private string ExecuteCommand(MsiSqlConnection? oCnn, SqlTransaction? oTrans, StringBuilder cSql)
    {
        if (oCnn is null || oCnn.InnerConnection is null)
            throw new ArgumentException("oCnn.InnerConnection is null = RecUpdate()");
        using var cmd = new SqlCommand(cSql.ToString(), oCnn?.InnerConnection, oTrans);
        AddParametersToCommand(cmd);
        SqlUsed = cSql.ToString();

        try
        {
            cmd.ExecuteNonQuery();
            oTrans?.Commit();
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

    internal void AddParametersToCommand(SqlCommand cmd)
    {
        for (var nv = 0; nv < _lstCampos.Count; nv++)
            cmd.Parameters.AddWithValue(_lstCampos[nv], _lstValue[nv]);
    }

    private string HandleSqlException(SqlException ex, SqlTransaction? oTrans)
    {
        oTrans?.Rollback();
        LastError = ex.Message;
        return "";
    }

    private string HandleGeneralException(Exception ex, SqlTransaction? oTrans, string sql)
    {
        LastError = ex.Message;
        oTrans?.Rollback();

        if (--MaxReportError > 0)
            throw new Exception($"RollBack--{Table}--Sql");

        return "";
    }

    private string ExecuteUpdate(MsiSqlConnection? oCnn)
    {
        var executor = new UpdateExecutor32(this, oCnn);
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
        if (conn is null)
            throw new ArgumentException("conn is null = ObtemUltimoIDInserido()");
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
    #endregion
}
