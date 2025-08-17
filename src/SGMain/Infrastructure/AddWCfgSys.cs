namespace MenphisSI.DB.Update;

public class CreateWcfSys
{
    internal static string Procedure_WriteCfg(MsiSqlConnection? oCnn) =>
$"""
CREATE PROCEDURE {oCnn?.UseDbo ?? "dbo"}.MenphisSI_sp_WriteCfg(@chave as text, @value as text)
As

BEGIN

SET NOCOUNT ON;
if (EXISTS(Select TOP (1) '1' from [{oCnn?.UseDbo ?? "dbo"}].WCfgSys WITH (INDEX(search1)) where Chave like @chave))
BEGIN
	UPDATE TOP (1) [{oCnn?.UseDbo ?? "dbo"}].WCfgSys set Valor=@value where Chave like @chave
END
else
BEGIN
    insert into [{oCnn?.UseDbo ?? "dbo"}].WCfgSys (Chave, Valor) values (@chave, @value)
END

END;
""";

    internal static string Procedure_WriteCfgUser(MsiSqlConnection? oCnn) =>
$"""

CREATE PROCEDURE {oCnn?.UseDbo ?? "dbo"}.MenphisSI_sp_WriteCfgUser(@chave as text, @value as text, @userId as int)

As

BEGIN
SET NOCOUNT ON;
if (EXISTS(Select TOP (1) '1' from [{oCnn?.UseDbo ?? "dbo"}].WCfgSys WITH (INDEX(search3)) where Usuario=@userId AND Chave like @chave))
BEGIN
	UPDATE TOP (1) [{oCnn?.UseDbo ?? "dbo"}].WCfgSys set Valor=@value where Usuario=@userId AND Chave like @chave
END
else
BEGIN
    insert into [{oCnn?.UseDbo ?? "dbo"}].WCfgSys (Chave, Valor, Usuario) values (@chave, @value, @userId)
END

END;
""";

    internal static string Procedure_WriteCfgMemo(MsiSqlConnection? oCnn) =>
$@"CREATE PROCEDURE {oCnn?.UseDbo ?? "dbo"}.MenphisSI_sp_WriteCfgMemo(@chave as text, @value as text)

As

BEGIN

SET NOCOUNT ON;
if (EXISTS(Select TOP (1) '1' from [{oCnn?.UseDbo ?? "dbo"}].WCfgSys WITH (INDEX(search1)) where Chave like @chave))
BEGIN
	UPDATE TOP (1) [{oCnn?.UseDbo ?? "dbo"}].WCfgSys set cfgMemo=@value where Chave like @chave
END
else
BEGIN
    insert into [{oCnn?.UseDbo ?? "dbo"}].WCfgSys (Chave, cfgMemo) values (@chave, @value)
END

END;";

    internal static string Procedure_WriteCfgUserMemo(MsiSqlConnection? oCnn) =>
$@"CREATE PROCEDURE {oCnn?.UseDbo ?? "dbo"}.MenphisSI_sp_WriteCfgMemoUser(@chave as text, @value as text, @userId as int)

As

BEGIN
if (EXISTS(Select TOP (1) '1' from [{oCnn?.UseDbo ?? "dbo"}].WCfgSys WITH (INDEX(search3)) where Usuario=@userId AND Chave like @chave))
BEGIN
	UPDATE TOP (1) [{oCnn?.UseDbo ?? "dbo"}].WCfgSys set cfgMemo=@value where Usuario=@userId AND Chave like @chave
END
else
BEGIN
    insert into [{oCnn?.UseDbo ?? "dbo"}].WCfgSys (Chave, cfgMemo, Usuario) values (@chave, @value, @userId)
END

END;

""";


    public void Create(MsiSqlConnection oCnn)
    {
        ExecuteSql(
           $@"CREATE OR ALTER TABLE {"WCfgSys".dbo(oCnn)}
           (
               [Usuario][int] NULL,
               [Valor][nvarchar](2048) NULL,
	            [Chave] [nvarchar] (2048) NULL,
	            [cfgMemo] [nvarchar] (max) NULL,
                [cfgCodigo] [int] IDENTITY(1,1) NOT NULL
            ) ON[PRIMARY] TEXTIMAGE_ON[PRIMARY]
            "?.Replace(@"\r\n", ""), oCnn, null);

        ExecuteSql(Procedure_WriteCfgUserMemo(oCnn), oCnn, null);
        ExecuteSql(Procedure_WriteCfgUser(oCnn), oCnn, null);

        ExecuteSql(Procedure_WriteCfgMemo(oCnn), oCnn, null);
        ExecuteSql(Procedure_WriteCfg(oCnn), oCnn, null);
    }

    private bool ExecuteSql(string? cSql, MsiSqlConnection? conn, SqlTransaction? trans = null)
    {
        if (conn is null || cSql is null) return false;

        using var cmd = conn.CreateCommand();
        cmd.CommandText = cSql;
        if (trans == null) trans = conn.BeginTransaction();
        cmd.Transaction = trans;
        try
        {
            cmd.ExecuteNonQuery();
            trans.Commit();
            return true;
        }
        catch (Exception)
        {
            trans.Rollback();
            return false;
         }
    }
}


public static class ExtensionsDbo
{
    public static string dbo(this string TabelaNome, MsiSqlConnection? oCnn) => TabelaNome.Contains("_sp_") ?
        $"{oCnn?.UseDbo ?? "dbo"}.{TabelaNome}" :
        $" [{oCnn?.UseDbo ?? "dbo"}].[{TabelaNome}] ";
}