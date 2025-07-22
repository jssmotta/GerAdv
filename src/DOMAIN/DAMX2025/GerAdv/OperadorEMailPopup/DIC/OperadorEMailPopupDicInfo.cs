using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBOperadorEMailPopupDicInfo
{
    public const string CampoCodigo = "oepCodigo";
    public const string CampoNome = "oepNome";
    public const string TablePrefix = "oep";
    public const string Operador = "oepOperador"; // LOCALIZACAO 170523
    public const string Nome = "oepNome"; // LOCALIZACAO 170523
    public const string Senha = "oepSenha"; // LOCALIZACAO 170523
    public const string SMTP = "oepSMTP"; // LOCALIZACAO 170523
    public const string POP3 = "oepPOP3"; // LOCALIZACAO 170523
    public const string Autenticacao = "oepAutenticacao"; // LOCALIZACAO 170523
    public const string Descricao = "oepDescricao"; // LOCALIZACAO 170523
    public const string Usuario = "oepUsuario"; // LOCALIZACAO 170523
    public const string PortaSmtp = "oepPortaSmtp"; // LOCALIZACAO 170523
    public const string PortaPop3 = "oepPortaPop3"; // LOCALIZACAO 170523
    public const string Assinatura = "oepAssinatura"; // LOCALIZACAO 170523
    public const string Senha256 = "oepSenha256"; // LOCALIZACAO 170523
    public const string GUID = "oepGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "oepQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "oepDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "oepQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "oepDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "oepVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Operador,
        2 => Nome,
        3 => Senha,
        4 => SMTP,
        5 => POP3,
        6 => Autenticacao,
        7 => Descricao,
        8 => Usuario,
        9 => PortaSmtp,
        10 => PortaPop3,
        11 => Assinatura,
        12 => Senha256,
        13 => GUID,
        14 => QuemCad,
        15 => DtCad,
        16 => QuemAtu,
        17 => DtAtu,
        18 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "OperadorEMailPopup";
#region PropriedadesDaTabela
    public static DBInfoSystem OepOperador => new(0, PTabelaNome, CampoCodigo, Operador, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "oep"
    }; // DBI 11 
    public static DBInfoSystem OepNome => new(0, PTabelaNome, CampoCodigo, Nome, 80, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        Prefixo = "oep"
    };
    public static DBInfoSystem OepSenha => new(0, PTabelaNome, CampoCodigo, Senha, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "oep"
    };
    public static DBInfoSystem OepSMTP => new(0, PTabelaNome, CampoCodigo, SMTP, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "oep"
    };
    public static DBInfoSystem OepPOP3 => new(0, PTabelaNome, CampoCodigo, POP3, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "oep"
    };
    public static DBInfoSystem OepAutenticacao => new(0, PTabelaNome, CampoCodigo, Autenticacao, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "oep"
    };
    public static DBInfoSystem OepDescricao => new(0, PTabelaNome, CampoCodigo, Descricao, 100, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "oep"
    };
    public static DBInfoSystem OepUsuario => new(0, PTabelaNome, CampoCodigo, Usuario, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "oep"
    };
    public static DBInfoSystem OepPortaSmtp => new(0, PTabelaNome, CampoCodigo, PortaSmtp, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "oep"
    };
    public static DBInfoSystem OepPortaPop3 => new(0, PTabelaNome, CampoCodigo, PortaPop3, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "oep"
    };
    public static DBInfoSystem OepAssinatura => new(0, PTabelaNome, CampoCodigo, Assinatura, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        Prefixo = "oep"
    };
    public static DBInfoSystem OepSenha256 => new(0, PTabelaNome, CampoCodigo, Senha256, 4000, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "oep"
    };
    public static DBInfoSystem OepGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "oep"
    };
    public static DBInfoSystem OepQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "oep"
    }; // DBI 11 
    public static DBInfoSystem OepDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "oep"
    };
    public static DBInfoSystem OepQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "oep"
    }; // DBI 11 
    public static DBInfoSystem OepDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "oep"
    };
    public static DBInfoSystem OepVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "oep"
    };

#endregion
#region SMART_SQLServices 
    public static string NomeSql(string text) => Nome.SqlCmdTextIgual(text, 80) ?? string.Empty;
    public static string NomeSqlNotIsNull => Nome.SqlCmdNotIsNull() ?? string.Empty;
    public static string NomeSqlIsNull => Nome.SqlCmdIsNull() ?? string.Empty;

    public static string NomeSqlDiff(string text) => Nome.SqlCmdTextDiff(text) ?? string.Empty;
    public static string NomeSqlLike(string text) => Nome.SqlCmdTextLike(text) ?? string.Empty;
    public static string NomeSqlLikeInit(string text) => Nome.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string NomeSqlLikeSpaces(string? text) => Nome.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string SenhaSql(string text) => Senha.SqlCmdTextIgual(text, 50) ?? string.Empty;
    public static string SenhaSqlNotIsNull => Senha.SqlCmdNotIsNull() ?? string.Empty;
    public static string SenhaSqlIsNull => Senha.SqlCmdIsNull() ?? string.Empty;

    public static string SenhaSqlDiff(string text) => Senha.SqlCmdTextDiff(text) ?? string.Empty;
    public static string SenhaSqlLike(string text) => Senha.SqlCmdTextLike(text) ?? string.Empty;
    public static string SenhaSqlLikeInit(string text) => Senha.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string SenhaSqlLikeSpaces(string? text) => Senha.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string SMTPSql(string text) => SMTP.SqlCmdTextIgual(text, 255) ?? string.Empty;
    public static string SMTPSqlNotIsNull => SMTP.SqlCmdNotIsNull() ?? string.Empty;
    public static string SMTPSqlIsNull => SMTP.SqlCmdIsNull() ?? string.Empty;

    public static string SMTPSqlDiff(string text) => SMTP.SqlCmdTextDiff(text) ?? string.Empty;
    public static string SMTPSqlLike(string text) => SMTP.SqlCmdTextLike(text) ?? string.Empty;
    public static string SMTPSqlLikeInit(string text) => SMTP.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string SMTPSqlLikeSpaces(string? text) => SMTP.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string POP3Sql(string text) => POP3.SqlCmdTextIgual(text, 255) ?? string.Empty;
    public static string POP3SqlNotIsNull => POP3.SqlCmdNotIsNull() ?? string.Empty;
    public static string POP3SqlIsNull => POP3.SqlCmdIsNull() ?? string.Empty;

    public static string POP3SqlDiff(string text) => POP3.SqlCmdTextDiff(text) ?? string.Empty;
    public static string POP3SqlLike(string text) => POP3.SqlCmdTextLike(text) ?? string.Empty;
    public static string POP3SqlLikeInit(string text) => POP3.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string POP3SqlLikeSpaces(string? text) => POP3.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string AutenticacaoSql(bool valueCheck) => Autenticacao.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string AutenticacaoSqlSim => Autenticacao.SqlCmdBoolSim() ?? string.Empty;
    public static string AutenticacaoSqlNao => Autenticacao.SqlCmdBoolNao() ?? string.Empty;

    public static string DescricaoSql(string text) => Descricao.SqlCmdTextIgual(text, 100) ?? string.Empty;
    public static string DescricaoSqlNotIsNull => Descricao.SqlCmdNotIsNull() ?? string.Empty;
    public static string DescricaoSqlIsNull => Descricao.SqlCmdIsNull() ?? string.Empty;

    public static string DescricaoSqlDiff(string text) => Descricao.SqlCmdTextDiff(text) ?? string.Empty;
    public static string DescricaoSqlLike(string text) => Descricao.SqlCmdTextLike(text) ?? string.Empty;
    public static string DescricaoSqlLikeInit(string text) => Descricao.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string DescricaoSqlLikeSpaces(string? text) => Descricao.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string UsuarioSql(string text) => Usuario.SqlCmdTextIgual(text, 50) ?? string.Empty;
    public static string UsuarioSqlNotIsNull => Usuario.SqlCmdNotIsNull() ?? string.Empty;
    public static string UsuarioSqlIsNull => Usuario.SqlCmdIsNull() ?? string.Empty;

    public static string UsuarioSqlDiff(string text) => Usuario.SqlCmdTextDiff(text) ?? string.Empty;
    public static string UsuarioSqlLike(string text) => Usuario.SqlCmdTextLike(text) ?? string.Empty;
    public static string UsuarioSqlLikeInit(string text) => Usuario.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string UsuarioSqlLikeSpaces(string? text) => Usuario.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string AssinaturaSql(string text) => Assinatura.SqlCmdTextIgual(text) ?? string.Empty;
    public static string AssinaturaSqlNotIsNull => Assinatura.SqlCmdNotIsNull() ?? string.Empty;
    public static string AssinaturaSqlIsNull => Assinatura.SqlCmdIsNull() ?? string.Empty;

    public static string AssinaturaSqlDiff(string text) => Assinatura.SqlCmdTextDiff(text) ?? string.Empty;
    public static string AssinaturaSqlLike(string text) => Assinatura.SqlCmdTextLike(text) ?? string.Empty;
    public static string AssinaturaSqlLikeInit(string text) => Assinatura.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string AssinaturaSqlLikeSpaces(string? text) => Assinatura.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string Senha256Sql(string text) => Senha256.SqlCmdTextIgual(text, 4000) ?? string.Empty;
    public static string Senha256SqlNotIsNull => Senha256.SqlCmdNotIsNull() ?? string.Empty;
    public static string Senha256SqlIsNull => Senha256.SqlCmdIsNull() ?? string.Empty;

    public static string Senha256SqlDiff(string text) => Senha256.SqlCmdTextDiff(text) ?? string.Empty;
    public static string Senha256SqlLike(string text) => Senha256.SqlCmdTextLike(text) ?? string.Empty;
    public static string Senha256SqlLikeInit(string text) => Senha256.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string Senha256SqlLikeSpaces(string? text) => Senha256.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string GUIDSql(string text) => GUID.SqlCmdTextIgual(text, 100) ?? string.Empty;
    public static string DtCadSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{DtCad}]");
    public static string DtCadSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{DtCad}]");
    public static string DtCadSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{DtCad}]");
    public static string DtCadSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{DtCad}]");
    public static string DtCadSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{DtCad}]");
    public static string DtCadSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{DtCad}]");
    public static string DtCadSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{DtCad}]");
    public static string DtCadSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{DtCad}]");
    public static string DtCadSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{DtCad}]");
    public static string DtCadSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{DtCad}]");
    public static string DtCadSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{DtCad}]");
    public static string DtCadSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{DtCad}]");
    public static string DtCadIsNull => DtCad.SqlCmdIsNull() ?? string.Empty;
    public static string DtCadNotIsNull => DtCad.SqlCmdNotIsNull() ?? string.Empty;

    public static string DtAtuSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{DtAtu}]");
    public static string DtAtuSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{DtAtu}]");
    public static string DtAtuSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{DtAtu}]");
    public static string DtAtuSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{DtAtu}]");
    public static string DtAtuSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{DtAtu}]");
    public static string DtAtuSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{DtAtu}]");
    public static string DtAtuSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{DtAtu}]");
    public static string DtAtuSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{DtAtu}]");
    public static string DtAtuSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{DtAtu}]");
    public static string DtAtuSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{DtAtu}]");
    public static string DtAtuSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{DtAtu}]");
    public static string DtAtuSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{DtAtu}]");
    public static string DtAtuIsNull => DtAtu.SqlCmdIsNull() ?? string.Empty;
    public static string DtAtuNotIsNull => DtAtu.SqlCmdNotIsNull() ?? string.Empty;

#endregion // 005 " : string.Empty)} 

    [Serializable]
    public enum NomesCamposTabela
    {
        OepOperador = 1,
        OepNome = 2,
        OepSenha = 3,
        OepSMTP = 4,
        OepPOP3 = 5,
        OepAutenticacao = 6,
        OepDescricao = 7,
        OepUsuario = 8,
        OepPortaSmtp = 9,
        OepPortaPop3 = 10,
        OepAssinatura = 11,
        OepSenha256 = 12,
        OepGUID = 13,
        OepQuemCad = 14,
        OepDtCad = 15,
        OepQuemAtu = 16,
        OepDtAtu = 17,
        OepVisto = 18
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.OepOperador => OepOperador,
        NomesCamposTabela.OepNome => OepNome,
        NomesCamposTabela.OepSenha => OepSenha,
        NomesCamposTabela.OepSMTP => OepSMTP,
        NomesCamposTabela.OepPOP3 => OepPOP3,
        NomesCamposTabela.OepAutenticacao => OepAutenticacao,
        NomesCamposTabela.OepDescricao => OepDescricao,
        NomesCamposTabela.OepUsuario => OepUsuario,
        NomesCamposTabela.OepPortaSmtp => OepPortaSmtp,
        NomesCamposTabela.OepPortaPop3 => OepPortaPop3,
        NomesCamposTabela.OepAssinatura => OepAssinatura,
        NomesCamposTabela.OepSenha256 => OepSenha256,
        NomesCamposTabela.OepGUID => OepGUID,
        NomesCamposTabela.OepQuemCad => OepQuemCad,
        NomesCamposTabela.OepDtCad => OepDtCad,
        NomesCamposTabela.OepQuemAtu => OepQuemAtu,
        NomesCamposTabela.OepDtAtu => OepDtAtu,
        NomesCamposTabela.OepVisto => OepVisto,
        _ => null
    };
}