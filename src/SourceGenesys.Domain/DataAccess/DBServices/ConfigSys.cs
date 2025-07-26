
using System.Web;

namespace MenphisSI;

/// <summary>
/// -1 return com int.TryParse;
/// </summary>
public static partial class ConfigSys
{

    private static bool ExecuteSql(string cSql, MsiSqlConnection? conn)
    {
        if (conn is null) return false;
        using var cmd = conn.CreateCommand();
        cmd.CommandText = cSql;
        var trans = conn.BeginTransaction();
        cmd.Transaction = trans;
        try
        {
            cmd.ExecuteNonQuery();
            trans.Commit();
            return true;
        }
        catch
        {
            trans.Rollback();
            return false;
        }
    }
    /// <summary>
    /// 05-02-2015
    /// </summary>
    /// <param name="cKey"></param>
    /// <param name="operador"></param>
    /// <param name="oCnn"></param>
    public static bool DeleteKeyCfgSys(string cKey, int operador, MsiSqlConnection? oCnn)
    =>
        ExecuteSql($"delete from {"WCfgSys".dbo(oCnn)} where Usuario={operador} AND Chave like '{cKey.Replace("'", "''")}'", oCnn);

    public static bool DeleteKeyCfgSys(string cKey, MsiSqlConnection? oCnn)
=>
    ExecuteSql($"delete from {"WCfgSys".dbo(oCnn)} where Chave like '{cKey.Replace("'", "''")}'", oCnn);

    public static bool WriteCfgSys(string cKey, int nValue, MsiSqlConnection? oCnnP)
        => iWrite(cKey, nValue.ToString(), oCnnP);

    public static bool WriteCfgSys64(string cKey, long nValue, MsiSqlConnection? oCnnP)
        => iWrite(cKey, nValue.ToString(), oCnnP);

    public static void WriteCfgSys(string cKey, int operador, long nValue, MsiSqlConnection? oCnnP)
        => iWrite(cKey, nValue.ToString(), oCnnP, operador);
    public static void WriteCfgSys64(string cKey, int operador, long nValue, MsiSqlConnection? oCnnP)
    => iWrite(cKey, nValue.ToString(), oCnnP, operador);

    private static bool iWrite(string? cKey, string cValue, MsiSqlConnection? oCnnP, int operador = -1000)
    {
        if (oCnnP is null ||
            string.IsNullOrEmpty(cKey.trim())) return false;


        using var trans = oCnnP.BeginTransaction();
        using var cmd =
            new SqlCommand
            {
                Transaction = trans,
                CommandType = CommandType.StoredProcedure,
                CommandText = operador == -1000 ? "MenphisSI_sp_WriteCfg".dbo(oCnnP) : "MenphisSI_sp_WriteCfgUser".dbo(oCnnP),
                Connection = oCnnP?.InnerConnection,
                CommandTimeout = 40
            };
        {
            if (operador != -1000)
                cmd.Parameters.Add(new()
                {
                    SqlDbType = SqlDbType.Int,
                    ParameterName = "@userId",
                    Value = operador,
                    Direction = ParameterDirection.Input
                });

            cmd.Parameters.Add(new()
            {
                SqlDbType = SqlDbType.Text,
                ParameterName = "@chave",
                Value = cKey,
                Direction = ParameterDirection.Input
            });

            cmd.Parameters.Add(new()
            {
                SqlDbType = SqlDbType.Text,
                ParameterName = "@value",
                Value = cValue,
                Direction = ParameterDirection.Input
            });
            //using var oTrans = oCnnP.BeginTransaction();
            //cmd.Transaction = oTrans;
            try
            {
                cmd.ExecuteNonQuery();
                trans.Commit();
                return true;
            }
            catch (SqlException ex)
            {
                trans.Rollback();
                var err = ex.Message;
                // GeneralSystemErrorTraper.GetError(ex, cmd.CommandText, oCnnP.ConnectionString);
            }
            catch (Exception ex)
            {
                trans.Rollback();
                GeneralSystemErrorTraper.GetError(ex, cmd.CommandText);
            }
        }
        return false;
    }

    private static bool iWriteMemo(string? cKey, string cValue, MsiSqlConnection? oCnnP, int operador = -1000)
    {
        if (oCnnP is null || cKey is null) return false;

        using var trans = oCnnP.BeginTransaction();
        using var cmd =
            new SqlCommand
            {
                Transaction = trans,
                CommandType = CommandType.StoredProcedure,
                CommandText = operador == -1000 ? "MenphisSI_sp_WriteCfgMemo".dbo(oCnnP) : "MenphisSI_sp_WriteCfgMemoUser".dbo(oCnnP),
                Connection = oCnnP?.InnerConnection
            };
        {
            if (operador != -1000)
                cmd.Parameters.Add(new()
                {
                    SqlDbType = SqlDbType.Int,
                    ParameterName = "@userId",
                    Value = operador,
                    Direction = ParameterDirection.Input
                });

            cmd.Parameters.Add(new()
            {
                SqlDbType = SqlDbType.Text,
                ParameterName = "@chave",
                Value = cKey,
                Direction = ParameterDirection.Input
            });

            cmd.Parameters.Add(new()
            {
                SqlDbType = SqlDbType.Text,
                ParameterName = "@value",
                Value = cValue,
                Direction = ParameterDirection.Input
            });

            try
            {
                cmd.ExecuteNonQuery();
                trans.Commit();
                return true;
            }
            catch (SqlException ex)
            {
                trans.Rollback();
                GeneralSystemErrorTraper.GetError(ex, cmd.CommandText, oCnnP.ConnectionString);
            }
            catch (Exception ex)
            {
                GeneralSystemErrorTraper.GetError(ex, cmd.CommandText);
            }
        }
        return false;
    }

    //public static bool ReadCfgSys(object keyAlterCloseVMWareMachinesSelf) => throw new NotImplementedException();
    /// <summary>
    /// Otimizado 07-06-2015
    /// </summary>
    /// <param name="cKey"></param>
    /// <param name="operador"></param>
    /// <param name="nValue"></param>
    /// <param name="oCnn"></param>
    public static void WriteCfgSys(string cKey, int operador, int nValue, MsiSqlConnection? oCnnP)
    => iWrite(cKey, nValue.ToString(), oCnnP, operador);

    public static bool WriteCfgSysC(string cKey, string cValue, MsiSqlConnection? oCnnP)
        => iWrite(cKey, cValue, oCnnP);


    /// <summary>
    /// Refactorado 17-06-2019 16:18
    /// </summary>
    /// <param name="cKey"></param>
    /// <param name="cValue"></param>
    /// <param name="oCnnP"></param>
    public static bool WriteCfgSysMemo(in string cKey, in string cValue, MsiSqlConnection? oCnnP) => cKey.Equals(string.Empty) ? throw new(" cKey is EMPTY! 17-06-2019 16:09") : iWriteMemo(cKey, cValue, oCnnP);

    /// <summary>
    /// Refactorado 17-06-2019 15:57
    /// </summary>
    /// <param name="cKey"></param>
    /// <param name="operador"></param>
    /// <param name="cValue"></param>
    /// <param name="oCnn"></param>
    public static bool WriteCfgSysC(string? cKey, int operador, string cValue, MsiSqlConnection? oCnn)
    => iWrite(cKey, cValue, oCnn, operador);
    public static void WriteCfgSysMemo(in string? cKey, in int operador, string cValue, in MsiSqlConnection? oCnn)
    {
        if (cKey.IsEquals(string.Empty))
            throw new("cKey Is Empty()! 17-06-2019 16:06");

        if (cValue.IsEmpty()) cValue = string.Empty;
        iWriteMemo(cKey, cValue, oCnn, operador);
    }
    public static int ReadCfgSysX(string cKey, MsiSqlConnection? oCnn)
    {
        try
        {
            using var cmd =
               new SqlCommand
               {
                   // Transaction = trans,
                   CommandText = "MenphisSI_sp_WReadCfg".dbo(oCnn),
                   CommandType = CommandType.StoredProcedure,
                   Connection = oCnn?.InnerConnection
               };
            cmd.Parameters.Add(new()
            {
                SqlDbType = SqlDbType.Text,
                ParameterName = "@Chave",
                Value = cKey,
                Direction = ParameterDirection.Input
            });
            var ret = cmd.ExecuteScalar(); // 27-01-2017
                                           //trans.Commit();
            return ret != null && int.TryParse(ret.ToString(), out var nRet) ? nRet : -1;
        }
        catch (SqlException ex)
        {
            ///trans.Rollback();
            GeneralSystemErrorTraper.GetError(ex, ConnectionString: oCnn?.ConnectionString ?? "");

#if (DEVOURER_NS)
                    var err = ex.Message;
                    DevourerWCfg.UpdateWCfgSP(oCnn);
#endif
            return -1;
        }
    }


    /// <summary>
    /// Otimizado em 07-06-2015
    /// </summary>
    /// <param name="cKey"></param>
    /// <param name="operador"></param>
    /// <param name="oCnn"></param>
    /// <returns></returns>
    public static int ReadCfgSys(string cKey, int operador, MsiSqlConnection? oCnn)
    {

        if (oCnn == null)
            return -1;

        try
        {
            using var cmd =
                new SqlCommand
                {
                    CommandText = "MenphisSI_sp_WReadCfgUser".dbo(oCnn),
                    Connection = oCnn?.InnerConnection,
                    CommandTimeout = 10,
                    CommandType = CommandType.StoredProcedure

                };
            cmd.Parameters.Add(new()
            {
                SqlDbType = SqlDbType.Int,
                ParameterName = "@UserId",
                Value = operador,
                Direction = ParameterDirection.Input
            });

            cmd.Parameters.Add(new()
            {
                SqlDbType = SqlDbType.Text,
                ParameterName = "@Chave",
                Value = cKey,
                Direction = ParameterDirection.Input
            });
            var ret = cmd.ExecuteScalar(); // 27-01-2017
            return ret != null && int.TryParse(ret.ToString(), out var nRet) ? nRet : -1;
        }
        catch (SqlException ex)
        {
            //GeneralSystemErrorTraper.GetError(ex, cKey, ConnectionString: Configuracoes.ConnectionString);
            return -1;
        }

    }
    public static long ReadCfgSys64(string cKey, int operador, MsiSqlConnection? oCnn)
    {
#if (DEBUG)
        if (oCnn == null)
            return -1;

#endif

        using var cmd =
            new SqlCommand
            {
                CommandText = "MenphisSI_sp_WReadCfgUser".dbo(oCnn),
                Connection = oCnn?.InnerConnection,
                CommandType = CommandType.StoredProcedure
            };
        cmd.Parameters.Add(new()
        {
            SqlDbType = SqlDbType.Int,
            ParameterName = "@UserId",
            Value = operador,
            Direction = ParameterDirection.Input
        });

        cmd.Parameters.Add(new()
        {
            SqlDbType = SqlDbType.Text,
            ParameterName = "@Chave",
            Value = cKey,
            Direction = ParameterDirection.Input
        });

        var ret = cmd.ExecuteScalar(); // 27-01-2017
        return ret != null && long.TryParse(ret.ToString(), out var nRet) ? nRet : -1;
    }

    /// <summary>
    /// 04-05-2019 19:08
    /// </summary>
    /// <param name="cKey"></param>
    /// <param name="oCnn"></param>
    /// <returns></returns>
    public static long ReadCfgSys64(string cKey, MsiSqlConnection? oCnn)
    {
#if (DEBUG)
        if (oCnn == null)
            return -1;

#endif

        using var cmd =
            new SqlCommand
            {
                CommandText = "MenphisSI_sp_WReadCfg".dbo(oCnn),
                Connection = oCnn?.InnerConnection,
                CommandType = CommandType.StoredProcedure
            };
        cmd.Parameters.Add(new()
        {
            SqlDbType = SqlDbType.Text,
            ParameterName = "@Chave",
            Value = cKey,
            Direction = ParameterDirection.Input
        });
        var ret = cmd.ExecuteScalar(); // 27-01-2017
        return ret != null && long.TryParse(ret.ToString(), out var nRet) ? nRet : -1;
    }

    public static string ReadCfgSysCX(string cKey, MsiSqlConnection? oCnn, string defValue = "")
    {
        using var cmd =
         new SqlCommand
         {
             CommandType = CommandType.StoredProcedure,
             CommandText = "MenphisSI_sp_WReadCfg".dbo(oCnn),
             Connection = oCnn?.InnerConnection
         };
        cmd.Parameters.Add(new()
        {
            SqlDbType = SqlDbType.Text,
            ParameterName = "@Chave",
            Value = cKey,
            Direction = ParameterDirection.Input
        });
        var ret = cmd.ExecuteScalar(); // 27-01-2017
        return ret?.ToString() ?? defValue;
    }
    public static string ReadCfgSysMemo(string cKey, MsiSqlConnection? oCnn)
    {
        if (oCnn == null) return "";

        using var cmd =
         new SqlCommand
         {
             CommandType = CommandType.StoredProcedure,
             CommandText = "MenphisSI_sp_WReadCfgMemo".dbo(oCnn),
             Connection = oCnn?.InnerConnection
         };
        cmd.Parameters.Add(new()
        {
            SqlDbType = SqlDbType.Text,
            ParameterName = "@Chave",
            Value = cKey,
            Direction = ParameterDirection.Input
        });

        var ret = cmd.ExecuteScalar(); // 27-01-2017
        return ret != null ? ret?.ToString() ?? string.Empty : string.Empty;
    }

    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

    public static string ReadCfgSysC(string? cKey, int operador, MsiSqlConnection? oCnn, string defaultRet = "")
    {
        if (cKey == null) return defaultRet;

        using var cmd = new SqlCommand
        {
            CommandType = CommandType.StoredProcedure,
            CommandText = "MenphisSI_sp_WReadCfgUser".dbo(oCnn),
            Connection = oCnn?.InnerConnection
        };

        try
        {
            cmd.Parameters.Add(new()
            {
                SqlDbType = SqlDbType.Int,
                ParameterName = "@UserId",
                Value = operador,
                Direction = ParameterDirection.Input
            });
            cmd.Parameters.Add(new()
            {
                SqlDbType = SqlDbType.Text,
                ParameterName = "@Chave",
                Value = cKey,
                Direction = ParameterDirection.Input
            });
            var ret = cmd.ExecuteScalar(); // 27-01-2017
            return (ret != null)
                ? ret?.ToString() ?? defaultRet : defaultRet;
        }
        catch (SqlException ex)
        {
            Logger.Error(ex, "Erro de SqlException ao executar o comando SQL. Contexto: {CommandText}, ConnectionString: {ConnectionString}",
            cmd.CommandText,
            oCnn?.ConnectionString ?? "Conexão nula");

            return defaultRet; 
        }
        catch (Exception ex)
        {
            Logger.Error(ex, "Erro ao executar o comando SQL. Contexto: {CommandText}, ConnectionString: {ConnectionString}",
            cmd.CommandText,
              oCnn?.ConnectionString ?? "Conexão nula");
            return defaultRet; 
        }
    }
    /// <summary>
    /// 24-03-2019* 20:00
    /// </summary>
    /// <param name="cKey"></param>
    /// <param name="operador"></param>
    /// <param name="oCnn"></param>
    /// <param name="defaultRet"></param>
    /// <returns></returns>
    public static int ReadCfgSys(string cKey, int operador, MsiSqlConnection? oCnn, int defaultRet = 0)
    {
        using var cmd = new SqlCommand
        {
            CommandType = CommandType.StoredProcedure,
            CommandText = "MenphisSI_sp_WReadCfgUser".dbo(oCnn),
            Connection = oCnn?.InnerConnection
        };
        cmd.Parameters.Add(new()
        {
            SqlDbType = SqlDbType.Int,
            ParameterName = "@UserId",
            Value = operador,
            Direction = ParameterDirection.Input
        });

        cmd.Parameters.Add(new()
        {
            SqlDbType = SqlDbType.Text,
            ParameterName = "@Chave",
            Value = cKey,
            Direction = ParameterDirection.Input
        });
        var ret = cmd.ExecuteScalar(); // 27-01-2017
        return ret == null ? defaultRet : int.TryParse(ret.ToString(), out var nRet) ? nRet : defaultRet;
    }
    /// <summary>
    /// Otimizado com dataReader on 07-06-2015
    /// </summary>
    /// <param name="cKey"></param>
    /// <param name="operador"></param>
    /// <param name="oCnn"></param>
    /// <returns></returns>
    public static string ReadCfgSysMemo(string? cKey, int operador, in MsiSqlConnection? oCnn)
    {
        if (oCnn is null || cKey is null) return "";
        using var cmd = new SqlCommand
        {
            CommandType = CommandType.StoredProcedure,
            CommandText = "MenphisSI_sp_WReadCfgMemoUser".dbo(oCnn),
            Connection = oCnn?.InnerConnection
        };
        cmd.Parameters.Add(new()
        {
            SqlDbType = SqlDbType.Int,
            ParameterName = "@UserId",
            Value = operador,
            Direction = ParameterDirection.Input
        });

        cmd.Parameters.Add(new()
        {
            SqlDbType = SqlDbType.Text,
            ParameterName = "@Chave",
            Value = cKey,
            Direction = ParameterDirection.Input
        });
        var ret = cmd.ExecuteScalar(); // 27-01-2017
        return ret != null ? ret?.ToString() ?? string.Empty : string.Empty;
    }
    public static void WriteCfgSysS(in string cKey, in string cValue, int operador, MsiSqlConnection? oCnnP)
        => iWrite(cKey, cValue, oCnnP, operador);
    public static void WriteCfgSysS(string cKey, in string cValue, MsiSqlConnection? oCnnP)
    {
        if (cKey.Length > 2048) cKey = cKey[..2040];
        iWrite(cKey, cValue, oCnnP);
    }

    public static string ReadCfgSysS(string cKey, MsiSqlConnection? oCnn)
    {
        if (cKey.Length > 2048) cKey = cKey[..2040];
        using var cmd = new SqlCommand
        {
            CommandType = CommandType.StoredProcedure,
            CommandText = "MenphisSI_sp_WReadCfgUser".dbo(oCnn),
            Connection = oCnn?.InnerConnection
        };
        cmd.Parameters.Add(new()
        {
            SqlDbType = SqlDbType.Text,
            ParameterName = "@Chave",
            Value = cKey,
            Direction = ParameterDirection.Input
        });
        var ret = cmd.ExecuteScalar(); // 27-01-2017
        return (ret != null)
            ? ret?.ToString() ?? string.Empty : string.Empty;
    }


}
