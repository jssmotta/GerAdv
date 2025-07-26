using System.ComponentModel;

namespace MenphisSI;

public class DBToolWTableGuid
{
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsMachineCode;

    private byte _hasUpdates;
    private const int PMaxTries = 15;
    private Guid? _mID;
    private readonly List<string> _mSqlPre = [];
    private readonly List<string> _mSqlPos = [];
    private readonly List<string> _lstCampos = [];
    private readonly List<object> _lstValue = [];

    public string LastError { get; private set; }
    public string Where { get; set; }
    public string Table { get; set; }
    public string CampoCodigo;
    public string SqlUsed { get; private set; }
    public bool Insert { get; set; }
    public static int MaxReportError { get; private set; } = 10;

    public DBToolWTableGuid()
    {
        Table = "";
        CampoCodigo = "";
        Where = "";
        LastError = "";
        SqlUsed = "";
    }

    public DBToolWTableGuid(in string tabelaName, string campoCodigoNome, bool isInsert)
    {
        Table = tabelaName;
        CampoCodigo = campoCodigoNome;
        Insert = isInsert;
        if (isInsert) _hasUpdates = 1;
        Where = "";
        LastError = "";
        SqlUsed = "";
    }

    public DBToolWTableGuid(in string tabelaName, bool isInsert)
    {
        Table = tabelaName;
        Insert = isInsert;
        CampoCodigo = "";
        Where = "";
        LastError = "";
        SqlUsed = "";
    }

    public Guid GetCodigo() => _mID ?? throw new Exception("Id == null");

    public bool HasUpdates
    {
        get
        {
            if (_hasUpdates == 0) _hasUpdates = _mSqlPre.Count > 0 ? (byte)1 : (byte)2;
            return _hasUpdates == 1;
        }
    }

    public string RecUpdate(MsiSqlConnection? oCnn)
    {
        if (oCnn is null) throw new ArgumentException("oCnn is null = RecUpdate()");
        using var oTrans = oCnn.BeginTransaction();
        var cSql = BuildSql(oCnn);
        using var cmd = new SqlCommand(cSql, oCnn.InnerConnection, oTrans);
        AddParameters(cmd);
        SqlUsed = cSql;
        try
        {
            if (Insert)
            {
                var result = cmd.ExecuteScalar();
                _mID = result != null ? (Guid)result : throw new Exception("Failed to retrieve inserted ID");
            }
            else
            {
                cmd.ExecuteNonQuery();
            }
            oTrans.Commit();
        }
        catch (SqlException ex)
        {
            oTrans.Rollback();
            LastError = ex.Message;
            if (LastError.Contains("Cannot insert duplicate key row"))
                return "ERROR_VIOLACAO_DE_CHAVE";
            return "";
        }
        catch (Exception ex)
        {
            LastError = ex.Message;
            oTrans.Rollback();
            if (--MaxReportError > 0)
                GeneralSystemErrorTraper.GetError(ex, $"RollBack--{Table}--Sql:{cSql}");
            return "";
        }
        return "OK";
    }

    public string RecUpdateX(MsiSqlConnection? oCnn)
    {
        if (oCnn is null) throw new ArgumentException("oCnn is null = RecUpdate()");
        return ExecuteUpdate(oCnn);
    }

    private string ExecuteUpdate(MsiSqlConnection oCnn)
    {
        int nCurrTrie = 0;
        var cPreSql = string.Join(",", _mSqlPre);
        using var oTrans = oCnn.BeginTransaction();
        var cSql = BuildSqlX(cPreSql, oCnn);
        using var cmd = new SqlCommand(cSql, oCnn.InnerConnection, oTrans);
        AddParameters(cmd);
        try
        {
            if (Insert)
            {
                var result = cmd.ExecuteScalar();
                _mID = result != null ? (Guid)result : throw new Exception("Failed to retrieve inserted ID");
            }
            else
            {
                cmd.ExecuteNonQuery();
            }
            oTrans.Commit();
            SqlUsed = cSql;
        }
        catch (SqlException ex)
        {
            oTrans.Rollback();
            LastError = ex.Message;
            if (LastError.ContemUpper("Não é possível inserir o valor NULL"))
                return "ERROR_CAMPO_NULL";
            if (LastError.ContemUpper("Cannot insert duplicate key row"))
                return "ERROR_VIOLACAO_DE_CHAVE";
            if (LastError.ContemUpper("PRIMARY KEY") || ex.ErrorCode == -2146232060)
            {
                nCurrTrie++;
                if (nCurrTrie == PMaxTries)
                {
                    if (LastError.ContemUpper("PRIMARY KEY"))
                    {
                        if (--MaxReportError > 0)
                            GeneralSystemErrorTraper.GetError(ex, $"Violação de Chave Primária {Table}");
                    }
                    return "ERROR";
                }
            }
            return string.Empty;
        }
        catch (Exception ex)
        {
            oTrans.Rollback();
            LastError = ex.Message;
            if (--MaxReportError > 0)
                GeneralSystemErrorTraper.GetError(ex, $"Violação de Chave {Table}");
            return string.Empty;
        }
        return "OK";
    }

    private string BuildSql(MsiSqlConnection oCnn)
    {
        var sb = new StringBuilder("set dateformat ymd;");
        if (Insert)
        {
            sb.Append("INSERT INTO ");
            sb.Append(Table.dbo(oCnn));
            sb.Append(" (");
            sb.Append(string.Join(",", _mSqlPre));
            sb.Append(") OUTPUT INSERTED.");
            sb.Append(CampoCodigo);
            sb.Append(" VALUES (");
            sb.Append(string.Join(",", _mSqlPos));
            sb.Append(')');
        }
        else
        {
            sb.Append("UPDATE TOP (1) ");
            sb.Append(Table.dbo(oCnn));
            sb.Append(" SET ");
            sb.Append(string.Join(",", _mSqlPre));
            sb.Append(" WHERE ");
            sb.Append(Where);
        }
        return sb.ToString();
    }

    private string BuildSqlX(string cPreSql, MsiSqlConnection oCnn)
    {
        var sb = new StringBuilder();
        if (Insert)
        {
            sb.Append("set dateformat ymd; INSERT INTO ");
            sb.Append(Table.dbo(oCnn));
            sb.Append(" (");
            sb.Append(string.Join(",", _mSqlPre));
            sb.Append(") OUTPUT INSERTED.");
            sb.Append(CampoCodigo);
            sb.Append(" VALUES (");
            sb.Append(string.Join(",", _mSqlPos));
            sb.Append(')');
        }
        else
        {
            if (_mSqlPre.Count <= 2)
            {
                if (cPreSql.Contains("DtAtu") && cPreSql.Contains("QuemAtu"))
                    return "OK";
                switch (_mSqlPre.Count)
                {
                    case 1 when cPreSql.IndexOf("DtAtu", StringComparison.Ordinal) != -1:
                    case 0:
                        return "OK";
                }
            }
            sb.Append("set dateformat ymd; UPDATE ");
            if (Where.NãoContemUpper(" IN ")) sb.Append(" TOP (1) ");
            sb.Append($"{Table.dbo(oCnn)} SET {cPreSql} WHERE {Where};");
        }
        return sb.ToString();
    }

    private void AddParameters(SqlCommand cmd)
    {
        for (var i = 0; i < _lstCampos.Count; i++)
        {
            var paramValue = _lstValue[i];
            if (paramValue is string strValue && Guid.TryParse(strValue, out var guidValue))
                cmd.Parameters.AddWithValue(_lstCampos[i], guidValue);
            else
                cmd.Parameters.AddWithValue(_lstCampos[i], paramValue);
        }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public static int NRandom { get; set; }
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public static Random? RRandom;
    private static int SRandom()
    {
        if (++NRandom > 6 || NRandom == 1) NRandom = 5;
        RRandom ??= new();
        return RRandom.Next(minValue: 2, maxValue: NRandom);
    }

    public void Fields(in string nomeCampo, DateTime? value, ETiposCampos tipo)
    {
        string cSqlValue;
        var cFormat = tipo == ETiposCampos.FDateUltraFull ? "yyyy-MM-dd HH:mm:ss.fff" : "yyyy-MM-dd HH:mm:ss";
        if (tipo == ETiposCampos.FNow)
        {
            var cTime = DevourerOne.DateTimeUtc;
            cSqlValue = value == null ? cTime.ToString(cFormat) : Convert.ToDateTime(value).ToString(cFormat);
            if (cSqlValue.Contains("00:00:00"))
                cSqlValue = cTime.ToString(cFormat);
        }
        else
        {
            cSqlValue = value == null ? "null" : Convert.ToDateTime(value).ToString(value?.ToString().Contains(":") == false ? "yyyy-MM-dd" : cFormat);
        }
        var valData = CheckIfExists(cSqlValue, nomeCampo);
        if (valData == null) return;
        if (Insert)
        {
            _mSqlPre.Add(nomeCampo);
            _mSqlPos.Add(valData);
        }
        else
        {
            _mSqlPre.Add($"{nomeCampo}={valData}");
        }
    }

    private string? CheckIfExists(in string cSqlValue, string nomeCampo)
    {
        if (!IsMachineCode && _lstCampos.Count > 0)
        {
            var idx = _lstCampos.Select((n, i) => new { Value = n, Index = i }).FirstOrDefault(n => n.Value == nomeCampo);
            if (idx != null)
            {
                _lstValue[idx.Index] = cSqlValue;
                return null;
            }
        }
        _lstValue.Add(cSqlValue.Equals("null") ? DBNull.Value : cSqlValue);
        _lstCampos.Add(nomeCampo);
        return $"@{nomeCampo}";
    }

    private string? CheckIfExists(in byte[]? sqlValue, string nomeCampo)
    {
        if (!IsMachineCode && _lstCampos.Count > 0)
        {
            var idx = _lstCampos.Select((n, i) => new { Value = n, Index = i }).FirstOrDefault(n => n.Value == nomeCampo);
            if (idx != null)
            {
                _lstValue[idx.Index] = sqlValue == null || sqlValue == new byte[] { 0 } ? DBNull.Value : sqlValue;
                return null;
            }
        }
        _lstValue.Add(sqlValue == null || sqlValue == new byte[] { 0 } || sqlValue.Length == 0 ? DBNull.Value : sqlValue);
        _lstCampos.Add(nomeCampo);
        return $"@{nomeCampo}";
    }

    private string PrixValue(in decimal cSqlValue, string nomeCampo, ETiposCampos tipo)
    {
        var idx = _lstCampos.Select((n, i) => new { Value = n, Index = i }).FirstOrDefault(n => n.Value == nomeCampo);
        if (idx != null)
        {
            _lstValue[idx.Index] = cSqlValue < 0.001m ? (tipo == ETiposCampos.FNumberNull ? DBNull.Value : 0) : cSqlValue;
        }
        _lstValue.Add(cSqlValue < 0.001m ? (tipo == ETiposCampos.FNumberNull ? DBNull.Value : 0) : cSqlValue);
        _lstCampos.Add(nomeCampo);
        return $"@{nomeCampo}";
    }

    public void Fields(in string nomeCampo, long value, ETiposCampos tipo)
    {
        var cSqlValue = value == 0 && tipo == ETiposCampos.FNumberNull ? "null" : value.ToString();
        var sqlParam = CheckIfExists(cSqlValue, nomeCampo);
        if (sqlParam == null) return;
        if (Insert)
        {
            _mSqlPre.Add(nomeCampo);
            _mSqlPos.Add(sqlParam);
        }
        else
        {
            _mSqlPre.Add($"{nomeCampo}={sqlParam}");
        }
    }

    public void Fields(in string nomeCampo, int value, ETiposCampos tipo)
    {
        var cSqlValue = value == 0 && tipo == ETiposCampos.FNumberNull ? "null" : value.ToString();
        var sqlParam = CheckIfExists(cSqlValue, nomeCampo);
        if (sqlParam == null) return;
        if (Insert)
        {
            _mSqlPre.Add(nomeCampo);
            _mSqlPos.Add(sqlParam);
        }
        else
        {
            _mSqlPre.Add($"{nomeCampo}={sqlParam}");
        }
    }

    public void Fields(in string nomeCampo, byte[]? value, ETiposCampos tipo)
    {
        var sqlParam = CheckIfExists(value, nomeCampo);
        if (sqlParam == null) return;
        if (Insert)
        {
            _mSqlPre.Add(nomeCampo);
            _mSqlPos.Add(sqlParam);
        }
        else
        {
            _mSqlPre.Add($"{nomeCampo}={sqlParam}");
        }
    }

    public void Fields(in string nomeCampo, string? value, ETiposCampos tipo)
    {
        value ??= string.Empty;
        var sqlParam = CheckIfExists(value.Trim(), nomeCampo);
        if (string.IsNullOrEmpty(sqlParam)) return;
        if (Insert)
        {
            _mSqlPre.Add(nomeCampo);
            _mSqlPos.Add(sqlParam);
        }
        else
        {
            _mSqlPre.Add($"{nomeCampo}={sqlParam}");
        }
    }

    public void Fields(in string nomeCampo, decimal value, ETiposCampos tipo)
    {
        var sqlParam = PrixValue(value, nomeCampo, tipo);
        if (sqlParam == null) return;
        if (Insert)
        {
            _mSqlPre.Add(nomeCampo);
            _mSqlPos.Add(sqlParam);
        }
        else
        {
            _mSqlPre.Add($"{nomeCampo}={sqlParam}");
        }
    }

    public void Fields(in string nomeCampo, bool value, ETiposCampos tipo)
    {
        var sqlParam = CheckIfExists(value ? "1" : "0", nomeCampo);
        if (sqlParam == null) return;
        if (Insert)
        {
            _mSqlPre.Add(nomeCampo);
            _mSqlPos.Add(sqlParam);
        }
        else
        {
            _mSqlPre.Add($"{nomeCampo}={sqlParam}");
        }
    }
}