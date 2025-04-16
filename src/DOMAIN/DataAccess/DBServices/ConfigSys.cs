
using System.Web;

namespace MenphisSI;

/// <summary>
/// -1 return com int.TryParse;
/// </summary>
public static partial class ConfigSys
{

    private static bool ExecuteSql(string cSql, SqlConnection? conn)
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
    public static bool DeleteKeyCfgSys(string cKey, int operador, SqlConnection? oCnn)
    =>
        ExecuteSql($"delete from [dbo].WCfgSys where Usuario={operador} AND Chave like '{cKey.Replace("'", "''")}'", oCnn);

    public static bool DeleteKeyCfgSys(string cKey, SqlConnection? oCnn)
=>
    ExecuteSql($"delete from [dbo].WCfgSys where Chave like '{cKey.Replace("'", "''")}'", oCnn);

    public static bool WriteCfgSys(string cKey, int nValue, SqlConnection? oCnnP)
        => iWrite(cKey, nValue.ToString(), oCnnP);

    public static bool WriteCfgSys64(string cKey, long nValue, SqlConnection? oCnnP)
        => iWrite(cKey, nValue.ToString(), oCnnP);

    public static void WriteCfgSys(string cKey, int operador, long nValue, SqlConnection? oCnnP)
        => iWrite(cKey, nValue.ToString(), oCnnP, operador);
    public static void WriteCfgSys64(string cKey, int operador, long nValue, SqlConnection? oCnnP)
    => iWrite(cKey, nValue.ToString(), oCnnP, operador);

    private static bool iWrite(string? cKey, string cValue, SqlConnection? oCnnP, int operador = -1000)
    {
        if (oCnnP is null ||
            string.IsNullOrEmpty(cKey.trim())) return false;
         

        using var trans = oCnnP.BeginTransaction();
        using var cmd =
            new SqlCommand
            {
                Transaction = trans,
                CommandType = CommandType.StoredProcedure,
                CommandText = operador == -1000 ? "dbo.MenphisSI_sp_WriteCfg" : "dbo.MenphisSI_sp_WriteCfgUser",
                Connection = oCnnP,
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

    private static bool iWriteMemo(string? cKey, string cValue, SqlConnection? oCnnP, int operador = -1000)
    {
        if (oCnnP is null || cKey is null) return false;

        using var trans = oCnnP.BeginTransaction();
        using var cmd =
            new SqlCommand
            {
                Transaction = trans,
                CommandType = CommandType.StoredProcedure,
                CommandText = operador == -1000 ? "dbo.MenphisSI_sp_WriteCfgMemo" : "dbo.MenphisSI_sp_WriteCfgMemoUser",
                Connection = oCnnP
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
    public static void WriteCfgSys(string cKey, int operador, int nValue, SqlConnection? oCnnP)
    => iWrite(cKey, nValue.ToString(), oCnnP, operador);
    /// <summary>
    /// Monitoramento pelo meu sistema - 02-07-2016
    /// </summary>
    /// <param name="keyValue"></param>
    /// <param name="oCnn"></param>
    /// <returns></returns>
    //public static string GetValueKey(string keyValue, SqlConnection? oCnn)
    //{
    //    var ckey = $"gkey-value-{keyValue}";
    //    var cRet = ReadCfgSysC(ckey);
    //    return cRet.Equals(string.Empty) ? keyValue : cRet;
    //}
    public static bool WriteCfgSysC(string cKey, string cValue, SqlConnection? oCnnP)
        => iWrite(cKey, cValue, oCnnP);
    //public static bool DeleteCfgSys(string cKey, SqlConnection? oCnnP)
    // =>
    //    ConfiguracoesDBT.ExecuteSql($"DELETE TOP (1) FROM WcfgSys where Chave='{cKey.Replace("'", "''")}';", oCnnP);
   
    /// <summary>
    /// Refactorado 17-06-2019 16:18
    /// </summary>
    /// <param name="cKey"></param>
    /// <param name="cValue"></param>
    /// <param name="oCnnP"></param>
    public static bool WriteCfgSysMemo(in string cKey, in string cValue, SqlConnection? oCnnP) => cKey.Equals(string.Empty) ? throw new(" cKey is EMPTY! 17-06-2019 16:09") : iWriteMemo(cKey, cValue, oCnnP);

    /// <summary>
    /// Refactorado 17-06-2019 15:57
    /// </summary>
    /// <param name="cKey"></param>
    /// <param name="operador"></param>
    /// <param name="cValue"></param>
    /// <param name="oCnn"></param>
    public static bool WriteCfgSysC(string? cKey, int operador, string cValue, SqlConnection? oCnn)
    => iWrite(cKey, cValue, oCnn, operador);
    public static void WriteCfgSysMemo(in string? cKey, in int operador, string cValue, in SqlConnection? oCnn)
    {
        if (cKey.IsEquals(string.Empty))
            throw new("cKey Is Empty()! 17-06-2019 16:06");

        if (cValue.IsEmpty()) cValue = string.Empty;
        iWriteMemo(cKey, cValue, oCnn, operador);
    }
    public static int ReadCfgSysX(string cKey, SqlConnection? oCnn)
    { 
        try
        {
            using var cmd =
               new SqlCommand
               {
                   // Transaction = trans,
                   CommandText = "dbo.MenphisSI_sp_WReadCfg",
                   CommandType = CommandType.StoredProcedure,
                   Connection = oCnn
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

    ///// <summary>
    ///// 08-09-2015
    ///// </summary>
    ///// <param name="cKey"></param>
    ///// <param name="operador"></param>
    ///// <param name="oCnn"></param>
    ///// <returns></returns>
    //public static void DeleteCfgSys(string cKey, int operador, SqlConnection? oCnn)
    //{
    //    if (oCnn is null) return;

    //    using var cmd = oCnn.CreateCommand();
    //    cmd.CommandText = $"Select TOP (1) Valor from [dbo].WCfgSys (NOLOCK) where Usuario={operador} and Chave like '{cKey}';";
    //    var trans = oCnn.BeginTransaction();
    //    cmd.Transaction = trans;
    //    try
    //    {
    //        cmd.ExecuteNonQuery();
    //        trans.Commit();
    //    }
    //    catch
    //    {
    //    }
    //}

    /// <summary>
    /// Otimizado em 07-06-2015
    /// </summary>
    /// <param name="cKey"></param>
    /// <param name="operador"></param>
    /// <param name="oCnn"></param>
    /// <returns></returns>
    public static int ReadCfgSys(string cKey, int operador, SqlConnection? oCnn)
    {

        if (oCnn == null)
            return -1;

        try
        {
            using var cmd =
                new SqlCommand
                {
                    CommandText = "dbo.MenphisSI_sp_WReadCfgUser",
                    Connection = oCnn,
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
    public static long ReadCfgSys64(string cKey, int operador, SqlConnection? oCnn)
    {
#if (DEBUG)
        if (oCnn == null)
            return -1;

#endif

        using var cmd =
            new SqlCommand
            {
                CommandText = "dbo.MenphisSI_sp_WReadCfgUser",
                Connection = oCnn,
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
    public static long ReadCfgSys64(string cKey, SqlConnection? oCnn)
    {
#if (DEBUG)
        if (oCnn == null)
            return -1;

#endif

        using var cmd =
            new SqlCommand
            {
                CommandText = "dbo.MenphisSI_sp_WReadCfg",
                Connection = oCnn,
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

    public static string ReadCfgSysCX(string cKey, SqlConnection? oCnn, string defValue = "")
    {
        using var cmd =
         new SqlCommand
         {
             CommandType = CommandType.StoredProcedure,
             CommandText = "dbo.MenphisSI_sp_WReadCfg",
             Connection = oCnn
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
    public static string ReadCfgSysMemo(string cKey, SqlConnection? oCnn)
    {
        if (oCnn == null) return "";

        using var cmd =
         new SqlCommand
         {
             CommandType = CommandType.StoredProcedure,
             CommandText = "dbo.MenphisSI_sp_WReadCfgMemo",
             Connection = oCnn
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
    public static string ReadCfgSysC(string? cKey, int operador, SqlConnection? oCnn, string defaultRet = "")
    {
        if (cKey == null) return defaultRet;

        using var cmd = new SqlCommand
        {
            CommandType = CommandType.StoredProcedure,
            CommandText = "dbo.MenphisSI_sp_WReadCfgUser",
            Connection = oCnn
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
        return (ret != null)
            ? ret?.ToString() ?? defaultRet : defaultRet;
    }
    /// <summary>
    /// 24-03-2019* 20:00
    /// </summary>
    /// <param name="cKey"></param>
    /// <param name="operador"></param>
    /// <param name="oCnn"></param>
    /// <param name="defaultRet"></param>
    /// <returns></returns>
    public static int ReadCfgSys(string cKey, int operador, SqlConnection? oCnn, int defaultRet = 0)
    {
        using var cmd = new SqlCommand
        {
            CommandType = CommandType.StoredProcedure,
            CommandText = "dbo.MenphisSI_sp_WReadCfgUser",
            Connection = oCnn
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
    public static string ReadCfgSysMemo(string? cKey, int operador, in SqlConnection? oCnn)
    {
        if (oCnn is null || cKey is null) return "";
        using var cmd = new SqlCommand
        {
            CommandType = CommandType.StoredProcedure,
            CommandText = "dbo.MenphisSI_sp_WReadCfgMemoUser",
            Connection = oCnn
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
    public static void WriteCfgSysS(in string cKey, in string cValue, int operador, SqlConnection? oCnnP)
        => iWrite(cKey, cValue, oCnnP, operador);
    public static void WriteCfgSysS(string cKey, in string cValue, SqlConnection? oCnnP)
    {
        if (cKey.Length > 2048) cKey = cKey[..2040];
        iWrite(cKey, cValue, oCnnP);
    }

    public static string ReadCfgSysS(string cKey, SqlConnection? oCnn)
    {
        if (cKey.Length > 2048) cKey = cKey[..2040];
        using var cmd = new SqlCommand
        {
            CommandType = CommandType.StoredProcedure,
            CommandText = "dbo.MenphisSI_sp_WReadCfgUser",
            Connection = oCnn
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

#if (forWeb)
    /// <summary>
    /// Identificação do titulo de Legislação
    /// </summary>
    /// <returns></returns>
    public static int IdTipoLegislacao()
    {
        try
        {
            //int isX = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["IdTipoLegislacao"].ToString());
            //return isX;
            var isX = ReadCfgSys("IdTipoLegislacao");// Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["IdWizData"].ToString());
            if (isX <= 0) isX = AddTitulo("Legisla\u00E7\u00E3o Federal", "IdTipoLegislacao");
            return isX;
        }
        catch
        {
            return 0;
        }
    }
    /// <summary>
    /// Identificação do titulo de Legislação Municipal
    /// </summary>
    /// <returns></returns>
    public static int IdTipoLegislacaoMunicipal()
    {
        try
        {
            //int isX = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["IdTipoLegislacaoMunicipal"].ToString());
            //return isX;
            var isX = ReadCfgSys("IdTipoLegislacaoMunicipal");// Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["IdWizData"].ToString());
            if (isX <= 0) isX = AddTitulo("Legisla\u00E7\u00E3o Municipal", "IdTipoLegislacaoMunicipal");
            return isX;
        }
        catch
        {
            return 0;
        }
    }
    /// <summary>
    /// Identificação do titulo de Jurisprudência
    /// </summary>
    /// <returns></returns>
    public static int IdTipoJurisprudencia()
    {
        try
        {
            var isX = ReadCfgSys("IdTipoJurisprudencia");// Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["IdWizData"].ToString());
            if (isX <= 0) isX = AddTitulo("Legisla\u00E7\u00E3o & Jurisprud\u00EAncia", "IdTipoJurisprudencia");
            return isX;
        }
        catch
        {
            return 0;
        }
    }
    /// <summary>
    /// Identificação do titulo de Legislação da Justiça do Trabalho
    /// </summary>
    /// <returns></returns>
    // ReSharper disable once InconsistentNaming
    public static int IdTipoLegislacaoJT()
    {
        try
        {
            var isX = ReadCfgSys("IdTipoLegislacaoJT");// Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["IdWizData"].ToString());
            if (isX <= 0) isX = AddTitulo("Legisla\u00E7\u00E3o Justi\u00E7a do Trabalho", "IdTipoLegislacaoJT");
            return isX;
        }
        catch
        {
            return 0;
        }
    }
    /// <summary>
    /// Identificação do titulo de Acordãos e Sentenças
    /// </summary>
    /// <returns></returns>
    public static int IdTipoAcordaosESetencas()
    {
        try
        {
            var isX = ReadCfgSys("IdTipoAdSt");// Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["IdWizData"].ToString());
            if (isX <= 0) isX = AddTitulo("Acord\u00E3os & Senten\u00E7as", "IdTipoAdSt");
            return isX;
        }
        catch
        {
            return 0;
        }
    }
    /// <summary>
    /// Identificação do titulo de Jurisprudência Tributária
    /// </summary>
    /// <returns></returns>
    public static int IdTipoLegislacaoJpt()
    {
        try
        {
            var isX = ReadCfgSys("IdTipoLegislacaoJPT");// Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["IdWizData"].ToString());
            if (isX <= 0) isX = AddTitulo("Jurisprud\u00EAncia Tribut\u00E1ria", "IdTipoLegislacaoJPT");
            return isX;
        }
        catch
        {
            return 0;
        }
    }
    /// <summary>
    /// Identificação do titulo de Legislação Estadual
    /// </summary>
    /// <returns></returns>
    public static int IdTipoLegislacaoEstadual()
    {
        try
        {
            //int isX = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["IdTipoLegislacaoEstadual"].ToString());
            //return isX;
            var isX = ReadCfgSys("IdTipoLegislacaoEstadual");// Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["IdWizData"].ToString());
            if (isX <= 0) isX = AddTitulo("Legisla\u00E7\u00E3o Estadual", "IdTipoLegislacaoEstadual");
            return isX;
        }
        catch
        {
            return 0;
        }
    }

    /// <summary>
    /// Indica se o registro na tabela de Titulos da agenda de endereços é da Menphis SI
    /// </summary>
    /// <returns></returns>
    public static int IdWizardData()
    {
        try
        {
            var isX = ReadCfgSys(cKey: "IdWizData");// Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["IdWizData"].ToString());
            if (isX <= 0) isX = AddTitulo("Dados do Assistente", "IdWizData");
            return isX;
        }
        catch
        {
            return 0;
        }
    }
    /// <summary>
    /// Identificação do titulo de Jurisprudência Tributária
    /// </summary>
    /// <returns></returns>
    // ReSharper disable once InconsistentNaming
    public static int IdTipoLegislacaoJPT()
    {
        try
        {
            var isX = ReadCfgSys("IdTipoLegislacaoJPT");// Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["IdWizData"].ToString());
            if (isX <= 0) isX = AddTitulo("Jurisprud\u00EAncia Tribut\u00E1ria", "IdTipoLegislacaoJPT");
            return isX;
        }
        catch
        {
            return 0;
        }
    }

    public static int AddTitulo(string assunto,
        string key)
    {
        var cNome = assunto.Trim();
        var cSql = new StringBuilder();
        if (cNome.ToUpper().IndexOf("%", StringComparison.Ordinal) == -1)
        {
            cSql.Append($"Select TOP (1) tipCodigo FROM dbo.TipoEndereco WHERE tipDescricao {DevourerOne.MsiCollate} = '");
            cSql.Append(cNome.Replace("'", "''"));
            cSql.Append("'");
        }
        else
        {
            cSql.Append($"select TOP (1) tipCodigo from dbo.TipoEndereco where tipDescricao {DevourerOne.MsiCollate} = '");
            cSql.Append(cNome.Replace("'", "''"));
            cSql.Append("'");
        }

        using var oCnn = Configuracoes.GetConnectionRw();
        var nId = DevourerSqlData.GetTotal(cSql.ToString(), oCnn);

        //using var ds = ConfiguracoesDBT.GetDataTable(cSql.ToString(), oCnn); if (ds !=null)            
        //nId = Convert.ToInt32(ds.Rows[0][0]);           

        if (nId <= 0)
        {
            var clsW = new MenphisSI.DBToolWTable32
            {
                Table = "TipoEndereco",
                Insert = true
            };
            clsW.Fields("tipDescricao", assunto, ETiposCampos.FString);
            clsW.Fields("tipQuemCad", 1, ETiposCampos.FNumberNull);
            clsW.Fields("tipDtCad", "now", ETiposCampos.FNow);
            clsW.Fields("tipVisto", false, ETiposCampos.FBoolean);
            clsW.Fields("tipGUID", Guid.NewGuid().ToString(), ETiposCampos.FString);
            clsW.RecUpdate(oCnn);
            nId = clsW.GetCodigo();

            if (nId <= 0)
                throw new("Tipo Endereco (" + assunto + ") retornou id == 0 ao gravar!");

        }

        WriteCfgSys(assunto, nId, oCnn);
        WriteCfgSys(key, nId, oCnn);
        return nId;
    }
#endif
}
