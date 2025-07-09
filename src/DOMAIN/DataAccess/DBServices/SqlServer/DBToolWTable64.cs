
#if (!forIDBConn)
#if (!forAccess)


using System.ComponentModel;



namespace MenphisSI;

public class DBToolWTable
{

    [Browsable(false)]

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IsMachineCode;

    private byte _hasUpdates;
    private const int PMaxTries = 15;
    private long _mID;
    private readonly List<string> _mSqlPre = [];
    private readonly List<string> _mSqlPos = [];
    private readonly List<string> _lstCampos = [];
    private readonly List<object> _lstValue = [];

    public DBToolWTable()
    {
        Table = "";
        CampoCodigo = "";
        Where = "";
        LastError = "";
        SqlUsed = "";
    }

    public string LastError { get; private set; }
    public string Where { get; set; }
    public string Table { get; set; }
    public string CampoCodigo;
    public string SqlUsed { get; private set; }

    public bool Insert { get; set; }
    public long GetCodigo() => _mID;

    public DBToolWTable(in string tabelaName, string campoCodigoNome, bool isInsert)
    {
        Table = tabelaName;
        CampoCodigo = campoCodigoNome;
        Insert = isInsert;
        if (isInsert) _hasUpdates = 1;
        Where = "";
        LastError = "";
        SqlUsed = "";
    }

    public DBToolWTable(in string tabelaName, bool isInsert)
    {
        Table = tabelaName;
        Insert = isInsert;
        CampoCodigo = "";
        Where = "";
        LastError = "";
        SqlUsed = "";
    }

    public string RecUpdate(MsiSqlConnection? oCnn, bool insertConvertedId)
    {
        if (oCnn is null) throw new ArgumentException("oCnn is null = RecUpdate()");
        using var oTrans = oCnn.BeginTransaction();

        var cSql = new StringBuilder("set dateformat ymd;");
        if (Insert || insertConvertedId)
        {
            cSql.Append("INSERT INTO ");
            cSql.Append(Table.dbo(oCnn));
            cSql.Append(" (");
            cSql.Append(string.Join(",", _mSqlPre));
            cSql.Append(") VALUES (");
            cSql.Append(string.Join(",", _mSqlPos));
            cSql.Append(')');
        }
        else
        {
            cSql.Append("UPDATE TOP (1) ");
            cSql.Append(Table.dbo(oCnn));
            cSql.Append(" SET ");
            cSql.Append(string.Join(",", _mSqlPre));
            cSql.Append(" WHERE ");
            cSql.Append(Where);
        }

        using var cmd = new SqlCommand(cSql.ToString(), oCnn?.InnerConnection, oTrans);
        for (var nv = 0; nv < _lstCampos.Count; nv++)
            cmd.Parameters.AddWithValue(_lstCampos[nv], _lstValue[nv]);

        SqlUsed = cSql.ToString();
        try
        {
            cmd.ExecuteNonQuery();
            oTrans.Commit();
        }
        catch (SqlException ex)
        {
            oTrans.Rollback();
            LastError = ex.Message;

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


    public string RecUpdate(MsiSqlConnection? oCnn) //Grava os dados
    {
        try
        {
            if (oCnn is null) throw new ArgumentException("oCnn is null = RecUpdate()");

            var ret = ExecuteUpdate();
            return ret;

            string ExecuteUpdate()
            {


                var nCurrTrie = 0;

                var cSql = new StringBuilder();
                var cPreSql = string.Join(",", _mSqlPre);

                var oTrans = oCnn.BeginTransaction();

                void ReadNewId(bool addCampoCodigo = false)
                {
                    int maxRetries = 10;
                    int retryCount = 0;

                    while (true)
                    {
                        if (retryCount++ >= maxRetries)
                            throw new Exception("Não foi possível gerar um ID único após várias tentativas");


                        var cSqlC = $"SELECT MAX({CampoCodigo}) FROM {Table.dbo(oCnn)} WITH (UPDLOCK, HOLDLOCK);";

                        {
                            using var cmd = new SqlCommand(cSqlC, oCnn?.InnerConnection);
                            cmd.Transaction = oTrans;
                            var result = cmd.ExecuteScalar();
                            _mID = result != DBNull.Value ? Convert.ToInt64(result) : 0;
                        }

                        _mID += SRandom();


                        try
                        {
                            using var cmd = new SqlCommand(
                                $"IF NOT EXISTS (SELECT 1 FROM {Table.dbo(oCnn)} WITH (UPDLOCK, HOLDLOCK) WHERE {CampoCodigo} = @id) " +
                                $"BEGIN /* Sucesso - ID está livre */ SELECT 0; END " +
                                $"ELSE BEGIN /* Falha - ID já existe */ SELECT 1; END",
                                oCnn?.InnerConnection
                            );

                            cmd.Parameters.AddWithValue("@id", _mID);
                            cmd.Transaction = oTrans;

                            if ((int)cmd.ExecuteScalar() == 0)
                                break;

                        }
                        catch (Exception)
                        {
                            if (retryCount >= maxRetries)
                                throw;
                        }
                    }

                    if (!addCampoCodigo)
                        return;

                    Fields(CampoCodigo, _mID, ETiposCampos.FNumber);
                    cPreSql = string.Join(",", _mSqlPre);
                }

                if (Insert)
                {

                    if (!string.IsNullOrEmpty(CampoCodigo))
                    {

                        if (Identity.IsNão())
                            ReadNewId(true);

                    }
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

                    cSql = new("UPDATE ");

                    if (Where.NãoContemUpper(" IN ")) cSql.Append(" TOP (1) ");

                    cSql.Append($"{Table.dbo(oCnn)} SET {cPreSql} WHERE {Where};");
                    cSql.Insert(0, "set dateformat ymd;");
                }

                var started = Insert;

                while (true)
                {

                    if (started)
                    {
                        started = false;

                        cSql = new($"set dateformat ymd; INSERT INTO {Table.dbo(oCnn)} ({cPreSql}) VALUES ({(string.Join(",", _mSqlPos))});");
                    }
                    using var cmd = new SqlCommand(cSql.ToString(), oCnn?.InnerConnection, oTrans);
                    for (var nv = 0; nv < _lstCampos.Count; nv++)
                        cmd.Parameters.AddWithValue(_lstCampos[nv], _lstValue[nv]);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        if (Insert && _mID == 0)
                        {
                            if (Identity)
                                _mID = ObtemUltimoIDInserido(oCnn, oTrans);
                            else
                            {
                                if (CampoCodigo.NotIsEmpty())
                                {
                                    int GetID()
                                    {
                                        using var cmdX = new SqlCommand($"SELECT TOP (1) {CampoCodigo} FROM {Table.dbo(oCnn)} ORDER BY {CampoCodigo.SqlOrderDesc()};", oCnn?.InnerConnection)
                                        {
                                            Transaction = oTrans
                                        };
                                        var ret = cmdX.ExecuteScalar();
                                        return ret != null
                                            ? DBNull.Value.Equals(ret) ? 0 : Convert.ToInt32(ret.ToString())
                                            : 0;
                                    }

                                    _mID = GetID();
                                }
                            }
                        }

                        oTrans.Commit();
                        SqlUsed = cSql.ToString();
                    }

                    catch (SqlException ex)
                    {
                        oTrans.Rollback();
                        LastError = ex.Message;
                        if (LastError.ContemUpper("Não é possível inserir o valor NULL"))
                            return "ERROR_CAMPO_NULL";

                        if (LastError.ContemUpper("Cannot insert duplicate key row"))
                        {

                            return "ERROR_VIOLACAO_DE_CHAVE";
                        }

                        if (LastError.ContemUpper("PRIMARY KEY") ||
                            ex.ErrorCode == -2146232060)
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
                            if (!Insert || CampoCodigo.IsEmpty()) return string.Empty;
                            oTrans = oCnn.BeginTransaction();
                            ReadNewId();

                            _lstValue[^1] = _mID;

                            continue;

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

                    oTrans.Dispose();
                    return "OK";
                }
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
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
        return RRandom.Next(minValue: 2, maxValue: NRandom); //08-07-2015 (2,5) | 03-12-2013
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
             : throw new("N\u00E3o consegiur obter o \u00FAltimo Id da tabela " + Table);

    }

    public bool Identity;

    public bool HasUpdates
    {
        get
        {
            if (_hasUpdates == 0) _hasUpdates = _mSqlPre.Count > 0 ? (byte)1 : (byte)2;
            return _hasUpdates == 1;
        }
    }

    public void Fields(in string nomeCampo, DateTime? value, ETiposCampos tipo)
    {
        string cSqlValue;
        var cFormat = tipo == ETiposCampos.FDateUltraFull ? "yyyy-MM-dd HH:mm:ss.fff" : "yyyy-MM-dd HH:mm:ss";

        if (tipo == ETiposCampos.FNow)
        {
            var cTime = DevourerOne.DateTimeUtc; // DevourerOne.DateTimeUtc;
            if (value == null)
                cSqlValue = cTime.ToString(format: cFormat);
            else
            {
                cSqlValue = Convert.ToDateTime(value).ToString(format: cFormat);
                if (cSqlValue.IndexOf("00:00:00", StringComparison.Ordinal) != -1)
                    cSqlValue = cTime.ToString(format: cFormat);

            }
        }
        else
            cSqlValue = value == null
                ? "null"
                : Convert.ToDateTime(value).ToString(value?.ToString().IndexOf(":", StringComparison.Ordinal) == -1
                    ? "yyyy-MM-dd"
                    : cFormat);
        if (!(CheckIfExists(cSqlValue, nomeCampo) is string valData && valData != null)) return;
        if (Insert)
        {
            _mSqlPre.Add(nomeCampo);
            _mSqlPos.Add(valData);
        }
        else
            _mSqlPre.Add($"{nomeCampo}={valData}");
    }

    private string? CheckIfExists(in string cSqlValue, string nomeCampo)
    {
        if (!IsMachineCode && _lstCampos.Count > 0)
            if (_lstCampos
               .Select((n, i) => new { Value = n, Index = i })
               .FirstOrDefault(n => n.Value == nomeCampo) is var idx && idx != null)
            {
                _lstValue[idx.Index] = cSqlValue;
                return null;
            }

        if (cSqlValue.Equals("null"))
            _lstValue.Add(DBNull.Value);
        else
            _lstValue.Add(cSqlValue);

        _lstCampos.Add(nomeCampo);
        return $"@{nomeCampo}";
    }
    private string? CheckIfExists(in byte[]? sqlValue, string nomeCampo)
    {
        if (!IsMachineCode && _lstCampos.Count > 0)
            if (_lstCampos
               .Select((n, i) => new { Value = n, Index = i })
               .FirstOrDefault(n => n.Value == nomeCampo) is var idx && idx != null)
            {
                _lstValue[idx.Index] = sqlValue == null || sqlValue == new byte[] { 0 } ? DBNull.Value : sqlValue;
                return null;
            }

        if (sqlValue == null || sqlValue == new byte[] { 0 } || sqlValue.Length == 0)
            _lstValue.Add(DBNull.Value);
        else
            _lstValue.Add(sqlValue);

        _lstCampos.Add(nomeCampo);
        return $"@{nomeCampo}";
    }

    private string PrixValue(in decimal cSqlValue, string nomeCampo, ETiposCampos tipo)
    {
        if (_lstCampos
              .Select((n, i) => new { Value = n, Index = i })
              .FirstOrDefault(n => n.Value == nomeCampo) is var idx && idx != null)
        {
            _lstValue[idx.Index] = cSqlValue < Convert.ToDecimal(0.001)
                ? tipo == ETiposCampos.FNumberNull ? DBNull.Value : 0
                : cSqlValue;
        }

        if (cSqlValue < Convert.ToDecimal(0.001))
        {
            if (tipo == ETiposCampos.FNumberNull)
            {
                _lstValue.Add(DBNull.Value);
            }
            else
            {
                _lstValue.Add(item: 0);
            }
        }
        else
        {
            _lstValue.Add(cSqlValue);
        }
        _lstCampos.Add(nomeCampo);
        return $"@{nomeCampo}";
    }

    public void Fields(in string nomeCampo, long value, ETiposCampos tipo)
    {

        var cSqlValue = string.Empty;

        if (value == 0)
        {
            if (tipo == ETiposCampos.FNumberNull)
                cSqlValue = "null";
        }
        else
        {
            cSqlValue = value.ToString();
        }
        cSqlValue = CheckIfExists(cSqlValue, nomeCampo);
        if (cSqlValue == null)
            return;

        if (Insert)
        {
            _mSqlPre.Add(nomeCampo);
            _mSqlPos.Add(cSqlValue);
        }
        else
        {
            _mSqlPre.Add($"{nomeCampo}={cSqlValue}");
        }
    }

    public void Fields(in string nomeCampo, int value, ETiposCampos tipo)
    {
        if (CheckIfExists(value == 0 &&
                            tipo == ETiposCampos.FNumberNull
                ? "null"
                : value.ToString(),
            nomeCampo) is not
            { } cSqlValue) return;
        if (Insert)
        {
            _mSqlPre.Add(nomeCampo);
            _mSqlPos.Add(cSqlValue);
        }
        else
            _mSqlPre.Add($"{nomeCampo}={cSqlValue}");
    }


    public void Fields(in string nomeCampo, byte[]? value, ETiposCampos tipo)
    {

        if (CheckIfExists(value, nomeCampo) is not { } cSqlValue) return;

        if (Insert)
        {
            _mSqlPre.Add(nomeCampo);
            _mSqlPos.Add(cSqlValue);
        }
        else
            _mSqlPre.Add($"{nomeCampo}={cSqlValue}");
    }
    public void Fields(
        in string nomeCampo,
        string? value,
        ETiposCampos tipo)
    {
        value ??= string.Empty;

        var cSqlValue = CheckIfExists(value.Trim(), nomeCampo);
        if ((cSqlValue == null || string.IsNullOrEmpty(cSqlValue))) return;
        if (Insert)
        {
            _mSqlPre.Add(nomeCampo);
            _mSqlPos.Add(cSqlValue);
        }
        else
            _mSqlPre.Add($"{nomeCampo}={cSqlValue}");
    }


    public static int MaxReportError { get; private set; } = 10;

    public void Fields(in string nomeCampo, decimal value, ETiposCampos tipo)
    {
        var cSqlValue = PrixValue(value, nomeCampo, tipo);
        if (cSqlValue == null)
            return;

        if (Insert)
        {
            _mSqlPre.Add(nomeCampo);
            _mSqlPos.Add(cSqlValue);
        }
        else
            _mSqlPre.Add($"{nomeCampo}={cSqlValue}");
    }

    public void Fields(in string nomeCampo, bool value, ETiposCampos tipo)
    {

        var cSqlValue = CheckIfExists(value ? "1" : "0", nomeCampo);
        if (cSqlValue == null)
            return;
        if (Insert)
        {
            _mSqlPre.Add(nomeCampo);
            _mSqlPos.Add(cSqlValue);
        }
        else
            _mSqlPre.Add($"{nomeCampo}={cSqlValue}");
    }
}

#endif
#endif