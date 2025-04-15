using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public static partial class DBOperadoresDicInfo
{
    public const string CampoCodigo = "operCodigo";
    public const string CampoNome = "operNome";
    public const string TablePrefix = "oper";
    public const string Enviado = "operEnviado"; // LOCALIZACAO 170523
    public const string Casa = "operCasa"; // LOCALIZACAO 170523
    public const string CasaID = "operCasaID"; // LOCALIZACAO 170523
    public const string CasaCodigo = "operCasaCodigo"; // LOCALIZACAO 170523
    public const string IsNovo = "operIsNovo"; // LOCALIZACAO 170523
    public const string Cliente = "operCliente"; // LOCALIZACAO 170523
    public const string Grupo = "operGrupo"; // LOCALIZACAO 170523
    public const string Nome = "operNome"; // LOCALIZACAO 170523
    public const string EMail = "operEMail"; // LOCALIZACAO 170523
    public const string Senha = "operSenha"; // LOCALIZACAO 170523
    public const string Ativado = "operAtivado"; // LOCALIZACAO 170523
    public const string AtualizarSenha = "operAtualizarSenha"; // LOCALIZACAO 170523
    public const string Senha256 = "operSenha256"; // LOCALIZACAO 170523
    public const string SuporteSenha256 = "operSuporteSenha256"; // LOCALIZACAO 170523
    public const string SuporteMaxAge = "operSuporteMaxAge"; // LOCALIZACAO 170523
    public const string QuemCad = "operQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "operDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "operQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "operDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "operVisto"; // LOCALIZACAO 170523
    public static string CampoCodigoDiff(int id) => CampoCodigo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string CampoCodigoSql(int id) => CampoCodigo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string CampoCodigoIsNull => CampoCodigo.SqlCmdIsNull() ?? string.Empty;
    public static string CampoCodigoNotIsNull => CampoCodigo.SqlCmdNotIsNull() ?? string.Empty;

    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Enviado,
        2 => Casa,
        3 => CasaID,
        4 => CasaCodigo,
        5 => IsNovo,
        6 => Cliente,
        7 => Grupo,
        8 => Nome,
        9 => EMail,
        10 => Senha,
        11 => Ativado,
        12 => AtualizarSenha,
        13 => Senha256,
        14 => SuporteSenha256,
        15 => SuporteMaxAge,
        16 => QuemCad,
        17 => DtCad,
        18 => QuemAtu,
        19 => DtAtu,
        20 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "Operadores";
#region PropriedadesDaTabela
    public static DBInfoSystem OperEnviado => new(0, PTabelaNome, CampoCodigo, Enviado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem OperCasa => new(0, PTabelaNome, CampoCodigo, Casa, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem OperCasaID => new(0, PTabelaNome, CampoCodigo, CasaID, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem OperCasaCodigo => new(0, PTabelaNome, CampoCodigo, CasaCodigo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem OperIsNovo => new(0, PTabelaNome, CampoCodigo, IsNovo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem OperCliente => new(0, PTabelaNome, CampoCodigo, Cliente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBClientesDicInfo.CampoCodigo, DBClientesDicInfo.TabelaNome, new DBClientesODicInfo(), false); // DBI 11 
    public static DBInfoSystem OperGrupo => new(0, PTabelaNome, CampoCodigo, Grupo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem OperNome => new(0, PTabelaNome, CampoCodigo, Nome, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false);
    public static DBInfoSystem OperEMail => new(0, PTabelaNome, CampoCodigo, EMail, 150, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEmail, true, false, false);
    public static DBInfoSystem OperSenha => new(0, PTabelaNome, CampoCodigo, Senha, 10, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem OperAtivado => new(0, PTabelaNome, CampoCodigo, Ativado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem OperAtualizarSenha => new(0, PTabelaNome, CampoCodigo, AtualizarSenha, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem OperSenha256 => new(0, PTabelaNome, CampoCodigo, Senha256, 4000, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem OperSuporteSenha256 => new(0, PTabelaNome, CampoCodigo, SuporteSenha256, 4000, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem OperSuporteMaxAge => new(0, PTabelaNome, CampoCodigo, SuporteMaxAge, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem OperQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem OperDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento);
    public static DBInfoSystem OperQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem OperDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao);
    public static DBInfoSystem OperVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto);

#endregion
    public static bool IsThisTable(string nomeTabela) => nomeTabela.ToUpper().Equals(TabelaNome.ToUpper());
#region SMART_SQLServices 
    public static string EnviadoSql(bool valueCheck) => Enviado.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string EnviadoSqlSim => Enviado.SqlCmdBoolSim() ?? string.Empty;
    public static string EnviadoSqlNao => Enviado.SqlCmdBoolNao() ?? string.Empty;

    public static string CasaSql(bool valueCheck) => Casa.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string CasaSqlSim => Casa.SqlCmdBoolSim() ?? string.Empty;
    public static string CasaSqlNao => Casa.SqlCmdBoolNao() ?? string.Empty;

    public static string CasaIDDiff(int id) => CasaID.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string CasaIDSql(int id) => CasaID.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string CasaIDIsNull => CasaID.SqlCmdIsNull() ?? string.Empty;
    public static string CasaIDNotIsNull => CasaID.SqlCmdNotIsNull() ?? string.Empty;

    public static string CasaCodigoDiff(int id) => CasaCodigo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string CasaCodigoSql(int id) => CasaCodigo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string CasaCodigoIsNull => CasaCodigo.SqlCmdIsNull() ?? string.Empty;
    public static string CasaCodigoNotIsNull => CasaCodigo.SqlCmdNotIsNull() ?? string.Empty;

    public static string IsNovoSql(bool valueCheck) => IsNovo.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string IsNovoSqlSim => IsNovo.SqlCmdBoolSim() ?? string.Empty;
    public static string IsNovoSqlNao => IsNovo.SqlCmdBoolNao() ?? string.Empty;

    public static string ClienteDiff(int id) => Cliente.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string ClienteSql(int id) => Cliente.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string ClienteIsNull => Cliente.SqlCmdIsNull() ?? string.Empty;
    public static string ClienteNotIsNull => Cliente.SqlCmdNotIsNull() ?? string.Empty;

    public static string GrupoDiff(int id) => Grupo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string GrupoSql(int id) => Grupo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string GrupoIsNull => Grupo.SqlCmdIsNull() ?? string.Empty;
    public static string GrupoNotIsNull => Grupo.SqlCmdNotIsNull() ?? string.Empty;

    public static string NomeSql(string text) => Nome.SqlCmdTextIgual(text, 50) ?? string.Empty;
    public static string NomeSqlNotIsNull => Nome.SqlCmdNotIsNull() ?? string.Empty;
    public static string NomeSqlIsNull => Nome.SqlCmdIsNull() ?? string.Empty;

    public static string NomeSqlDiff(string text) => Nome.SqlCmdTextDiff(text) ?? string.Empty;
    public static string NomeSqlLike(string text) => Nome.SqlCmdTextLike(text) ?? string.Empty;
    public static string NomeSqlLikeInit(string text) => Nome.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string NomeSqlLikeSpaces(string? text) => Nome.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string EMailSql(string text) => EMail.SqlCmdTextIgual(text, 150) ?? string.Empty;
    public static string EMailSqlNotIsNull => EMail.SqlCmdNotIsNull() ?? string.Empty;
    public static string EMailSqlIsNull => EMail.SqlCmdIsNull() ?? string.Empty;

    public static string EMailSqlDiff(string text) => EMail.SqlCmdTextDiff(text) ?? string.Empty;
    public static string EMailSqlLike(string text) => EMail.SqlCmdTextLike(text) ?? string.Empty;
    public static string EMailSqlLikeInit(string text) => EMail.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string EMailSqlLikeSpaces(string? text) => EMail.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string SenhaSql(string text) => Senha.SqlCmdTextIgual(text, 10) ?? string.Empty;
    public static string SenhaSqlNotIsNull => Senha.SqlCmdNotIsNull() ?? string.Empty;
    public static string SenhaSqlIsNull => Senha.SqlCmdIsNull() ?? string.Empty;

    public static string SenhaSqlDiff(string text) => Senha.SqlCmdTextDiff(text) ?? string.Empty;
    public static string SenhaSqlLike(string text) => Senha.SqlCmdTextLike(text) ?? string.Empty;
    public static string SenhaSqlLikeInit(string text) => Senha.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string SenhaSqlLikeSpaces(string? text) => Senha.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string AtivadoSql(bool valueCheck) => Ativado.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string AtivadoSqlSim => Ativado.SqlCmdBoolSim() ?? string.Empty;
    public static string AtivadoSqlNao => Ativado.SqlCmdBoolNao() ?? string.Empty;

    public static string AtualizarSenhaSql(bool valueCheck) => AtualizarSenha.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string AtualizarSenhaSqlSim => AtualizarSenha.SqlCmdBoolSim() ?? string.Empty;
    public static string AtualizarSenhaSqlNao => AtualizarSenha.SqlCmdBoolNao() ?? string.Empty;

    public static string Senha256Sql(string text) => Senha256.SqlCmdTextIgual(text, 4000) ?? string.Empty;
    public static string Senha256SqlNotIsNull => Senha256.SqlCmdNotIsNull() ?? string.Empty;
    public static string Senha256SqlIsNull => Senha256.SqlCmdIsNull() ?? string.Empty;

    public static string Senha256SqlDiff(string text) => Senha256.SqlCmdTextDiff(text) ?? string.Empty;
    public static string Senha256SqlLike(string text) => Senha256.SqlCmdTextLike(text) ?? string.Empty;
    public static string Senha256SqlLikeInit(string text) => Senha256.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string Senha256SqlLikeSpaces(string? text) => Senha256.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string SuporteSenha256Sql(string text) => SuporteSenha256.SqlCmdTextIgual(text, 4000) ?? string.Empty;
    public static string SuporteSenha256SqlNotIsNull => SuporteSenha256.SqlCmdNotIsNull() ?? string.Empty;
    public static string SuporteSenha256SqlIsNull => SuporteSenha256.SqlCmdIsNull() ?? string.Empty;

    public static string SuporteSenha256SqlDiff(string text) => SuporteSenha256.SqlCmdTextDiff(text) ?? string.Empty;
    public static string SuporteSenha256SqlLike(string text) => SuporteSenha256.SqlCmdTextLike(text) ?? string.Empty;
    public static string SuporteSenha256SqlLikeInit(string text) => SuporteSenha256.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string SuporteSenha256SqlLikeSpaces(string? text) => SuporteSenha256.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string SuporteMaxAgeSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{SuporteMaxAge}]");
    public static string SuporteMaxAgeSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{SuporteMaxAge}]");
    public static string SuporteMaxAgeSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{SuporteMaxAge}]");
    public static string SuporteMaxAgeSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{SuporteMaxAge}]");
    public static string SuporteMaxAgeSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{SuporteMaxAge}]");
    public static string SuporteMaxAgeSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{SuporteMaxAge}]");
    public static string SuporteMaxAgeSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{SuporteMaxAge}]");
    public static string SuporteMaxAgeSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{SuporteMaxAge}]");
    public static string SuporteMaxAgeSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{SuporteMaxAge}]");
    public static string SuporteMaxAgeSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{SuporteMaxAge}]");
    public static string SuporteMaxAgeSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{SuporteMaxAge}]");
    public static string SuporteMaxAgeSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{SuporteMaxAge}]");
    public static string SuporteMaxAgeIsNull => SuporteMaxAge.SqlCmdIsNull() ?? string.Empty;
    public static string SuporteMaxAgeNotIsNull => SuporteMaxAge.SqlCmdNotIsNull() ?? string.Empty;

    public static string QuemCadDiff(int id) => QuemCad.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string QuemCadSql(int id) => QuemCad.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string QuemCadIsNull => QuemCad.SqlCmdIsNull() ?? string.Empty;
    public static string QuemCadNotIsNull => QuemCad.SqlCmdNotIsNull() ?? string.Empty;

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

    public static string QuemAtuDiff(int id) => QuemAtu.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string QuemAtuSql(int id) => QuemAtu.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string QuemAtuIsNull => QuemAtu.SqlCmdIsNull() ?? string.Empty;
    public static string QuemAtuNotIsNull => QuemAtu.SqlCmdNotIsNull() ?? string.Empty;

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

#endregion // 005             

    [Serializable]
    public enum NomesCamposTabela
    {
        OperEnviado = 1,
        OperCasa = 2,
        OperCasaID = 3,
        OperCasaCodigo = 4,
        OperIsNovo = 5,
        OperCliente = 6,
        OperGrupo = 7,
        OperNome = 8,
        OperEMail = 9,
        OperSenha = 10,
        OperAtivado = 11,
        OperAtualizarSenha = 12,
        OperSenha256 = 13,
        OperSuporteSenha256 = 14,
        OperSuporteMaxAge = 15,
        OperQuemCad = 16,
        OperDtCad = 17,
        OperQuemAtu = 18,
        OperDtAtu = 19,
        OperVisto = 20
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.OperEnviado => OperEnviado,
        NomesCamposTabela.OperCasa => OperCasa,
        NomesCamposTabela.OperCasaID => OperCasaID,
        NomesCamposTabela.OperCasaCodigo => OperCasaCodigo,
        NomesCamposTabela.OperIsNovo => OperIsNovo,
        NomesCamposTabela.OperCliente => OperCliente,
        NomesCamposTabela.OperGrupo => OperGrupo,
        NomesCamposTabela.OperNome => OperNome,
        NomesCamposTabela.OperEMail => OperEMail,
        NomesCamposTabela.OperSenha => OperSenha,
        NomesCamposTabela.OperAtivado => OperAtivado,
        NomesCamposTabela.OperAtualizarSenha => OperAtualizarSenha,
        NomesCamposTabela.OperSenha256 => OperSenha256,
        NomesCamposTabela.OperSuporteSenha256 => OperSuporteSenha256,
        NomesCamposTabela.OperSuporteMaxAge => OperSuporteMaxAge,
        NomesCamposTabela.OperQuemCad => OperQuemCad,
        NomesCamposTabela.OperDtCad => OperDtCad,
        NomesCamposTabela.OperQuemAtu => OperQuemAtu,
        NomesCamposTabela.OperDtAtu => OperDtAtu,
        NomesCamposTabela.OperVisto => OperVisto,
        _ => null
    };
}