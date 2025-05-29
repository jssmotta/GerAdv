using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public static partial class DBPrepostosDicInfo
{
    public const string CampoCodigo = "preCodigo";
    public const string CampoNome = "preNome";
    public const string TablePrefix = "pre";
    public const string Nome = "preNome"; // LOCALIZACAO 170523
    public const string Funcao = "preFuncao"; // LOCALIZACAO 170523
    public const string Setor = "preSetor"; // LOCALIZACAO 170523
    public const string DtNasc = "preDtNasc"; // LOCALIZACAO 170523
    public const string Qualificacao = "preQualificacao"; // LOCALIZACAO 170523
    public const string Sexo = "preSexo"; // LOCALIZACAO 170523
    public const string Idade = "preIdade"; // LOCALIZACAO 170523
    public const string CPF = "preCPF"; // LOCALIZACAO 170523
    public const string RG = "preRG"; // LOCALIZACAO 170523
    public const string Periodo_Ini = "prePeriodo_Ini"; // LOCALIZACAO 170523
    public const string Periodo_Fim = "prePeriodo_Fim"; // LOCALIZACAO 170523
    public const string Registro = "preRegistro"; // LOCALIZACAO 170523
    public const string CTPSNumero = "preCTPSNumero"; // LOCALIZACAO 170523
    public const string CTPSSerie = "preCTPSSerie"; // LOCALIZACAO 170523
    public const string CTPSDtEmissao = "preCTPSDtEmissao"; // LOCALIZACAO 170523
    public const string PIS = "prePIS"; // LOCALIZACAO 170523
    public const string Salario = "preSalario"; // LOCALIZACAO 170523
    public const string LiberaAgenda = "preLiberaAgenda"; // LOCALIZACAO 170523
    public const string Observacao = "preObservacao"; // LOCALIZACAO 170523
    public const string Endereco = "preEndereco"; // LOCALIZACAO 170523
    public const string Bairro = "preBairro"; // LOCALIZACAO 170523
    public const string Cidade = "preCidade"; // LOCALIZACAO 170523
    public const string CEP = "preCEP"; // LOCALIZACAO 170523
    public const string Fone = "preFone"; // LOCALIZACAO 170523
    public const string Fax = "preFax"; // LOCALIZACAO 170523
    public const string EMail = "preEMail"; // LOCALIZACAO 170523
    public const string Pai = "prePai"; // LOCALIZACAO 170523
    public const string Mae = "preMae"; // LOCALIZACAO 170523
    public const string Class = "preClass"; // LOCALIZACAO 170523
    public const string Etiqueta = "preEtiqueta"; // LOCALIZACAO 170523
    public const string Ani = "preAni"; // LOCALIZACAO 170523
    public const string Bold = "preBold"; // LOCALIZACAO 170523
    public const string GUID = "preGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "preQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "preDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "preQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "preDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "preVisto"; // LOCALIZACAO 170523
    public static string CampoCodigoDiff(int id) => CampoCodigo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string CampoCodigoSql(int id) => CampoCodigo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string CampoCodigoIsNull => CampoCodigo.SqlCmdIsNull() ?? string.Empty;
    public static string CampoCodigoNotIsNull => CampoCodigo.SqlCmdNotIsNull() ?? string.Empty;

    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Nome,
        2 => Funcao,
        3 => Setor,
        4 => DtNasc,
        5 => Qualificacao,
        6 => Sexo,
        7 => Idade,
        8 => CPF,
        9 => RG,
        10 => Periodo_Ini,
        11 => Periodo_Fim,
        12 => Registro,
        13 => CTPSNumero,
        14 => CTPSSerie,
        15 => CTPSDtEmissao,
        16 => PIS,
        17 => Salario,
        18 => LiberaAgenda,
        19 => Observacao,
        20 => Endereco,
        21 => Bairro,
        22 => Cidade,
        23 => CEP,
        24 => Fone,
        25 => Fax,
        26 => EMail,
        27 => Pai,
        28 => Mae,
        29 => Class,
        30 => Etiqueta,
        31 => Ani,
        32 => Bold,
        33 => GUID,
        34 => QuemCad,
        35 => DtCad,
        36 => QuemAtu,
        37 => DtAtu,
        38 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "Prepostos";
#region PropriedadesDaTabela
    public static DBInfoSystem PreNome => new(0, PTabelaNome, CampoCodigo, Nome, 80, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false);
    public static DBInfoSystem PreFuncao => new(0, PTabelaNome, CampoCodigo, Funcao, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBFuncaoDicInfo.CampoCodigo, DBFuncaoDicInfo.TabelaNome, new DBFuncaoODicInfo(), false); // DBI 11 
    public static DBInfoSystem PreSetor => new(0, PTabelaNome, CampoCodigo, Setor, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBSetorDicInfo.CampoCodigo, DBSetorDicInfo.TabelaNome, new DBSetorODicInfo(), false); // DBI 11 
    public static DBInfoSystem PreDtNasc => new(0, PTabelaNome, CampoCodigo, DtNasc, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDataNascimento);
    public static DBInfoSystem PreQualificacao => new(0, PTabelaNome, CampoCodigo, Qualificacao, 100, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem PreSexo => new(0, PTabelaNome, CampoCodigo, Sexo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBooleanSexo);
    public static DBInfoSystem PreIdade => new(0, PTabelaNome, CampoCodigo, Idade, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem PreCPF => new(0, PTabelaNome, CampoCodigo, CPF, 11, DevourerOne.PCpf, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCpf, true, false, false);
    public static DBInfoSystem PreRG => new(0, PTabelaNome, CampoCodigo, RG, 30, DevourerOne.PRg, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextRG, true, false, false);
    public static DBInfoSystem PrePeriodo_Ini => new(0, PTabelaNome, CampoCodigo, Periodo_Ini, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDataInicio);
    public static DBInfoSystem PrePeriodo_Fim => new(0, PTabelaNome, CampoCodigo, Periodo_Fim, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDataTermino);
    public static DBInfoSystem PreRegistro => new(0, PTabelaNome, CampoCodigo, Registro, 30, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem PreCTPSNumero => new(0, PTabelaNome, CampoCodigo, CTPSNumero, 15, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem PreCTPSSerie => new(0, PTabelaNome, CampoCodigo, CTPSSerie, 10, DevourerOne.PNroSerieCtps, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCtpsserie, true, false, false);
    public static DBInfoSystem PreCTPSDtEmissao => new(0, PTabelaNome, CampoCodigo, CTPSDtEmissao, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem PrePIS => new(0, PTabelaNome, CampoCodigo, PIS, 20, DevourerOne.PNroPis, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextPis, true, false, false);
    public static DBInfoSystem PreSalario => new(0, PTabelaNome, CampoCodigo, Salario, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDoubleSalario);
    public static DBInfoSystem PreLiberaAgenda => new(0, PTabelaNome, CampoCodigo, LiberaAgenda, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem PreObservacao => new(0, PTabelaNome, CampoCodigo, Observacao, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemoObservacao, true, false, false);
    public static DBInfoSystem PreEndereco => new(0, PTabelaNome, CampoCodigo, Endereco, 80, DevourerOne.PEndereco, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEndereco, true, false, false);
    public static DBInfoSystem PreBairro => new(0, PTabelaNome, CampoCodigo, Bairro, 50, DevourerOne.PBairro, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextBairro, true, false, false);
    public static DBInfoSystem PreCidade => new(0, PTabelaNome, CampoCodigo, Cidade, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBCidadeDicInfo.CampoCodigo, DBCidadeDicInfo.TabelaNome, new DBCidadeODicInfo(), false); // DBI 11 
    public static DBInfoSystem PreCEP => new(0, PTabelaNome, CampoCodigo, CEP, 10, DevourerOne.PCep, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCep, true, false, false);
    public static DBInfoSystem PreFone => new(0, PTabelaNome, CampoCodigo, Fone, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFone, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFone, true, false, false);
    public static DBInfoSystem PreFax => new(0, PTabelaNome, CampoCodigo, Fax, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFax, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFax, true, false, false);
    public static DBInfoSystem PreEMail => new(0, PTabelaNome, CampoCodigo, EMail, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEmail, true, false, false);
    public static DBInfoSystem PrePai => new(0, PTabelaNome, CampoCodigo, Pai, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem PreMae => new(0, PTabelaNome, CampoCodigo, Mae, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem PreClass => new(0, PTabelaNome, CampoCodigo, Class, 1, DevourerOne.PClassificacao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextClassificacaoStar, true, false, false);
    public static DBInfoSystem PreEtiqueta => new(0, PTabelaNome, CampoCodigo, Etiqueta, DevourerOne.PCriarEtiqueta, DevourerOne.PTooltipEtiqueta, ETipoDadosSysteminfo.SysteminfoBooleanEtiqueta);
    public static DBInfoSystem PreAni => new(0, PTabelaNome, CampoCodigo, Ani, DevourerOne.PCaptionFieldAniversario, DevourerOne.PTooltipAniversario, ETipoDadosSysteminfo.SysteminfoBooleanLembrarAniversario);
    public static DBInfoSystem PreBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold);
    public static DBInfoSystem PreGUID => new(0, PTabelaNome, CampoCodigo, GUID, 150, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false);
    public static DBInfoSystem PreQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem PreDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento);
    public static DBInfoSystem PreQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem PreDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao);
    public static DBInfoSystem PreVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto);

#endregion
    public static bool IsThisTable(string nomeTabela) => nomeTabela.ToUpper().Equals(TabelaNome.ToUpper());
#region SMART_SQLServices 
    public static string NomeSql(string text) => Nome.SqlCmdTextIgual(text, 80) ?? string.Empty;
    public static string NomeSqlNotIsNull => Nome.SqlCmdNotIsNull() ?? string.Empty;
    public static string NomeSqlIsNull => Nome.SqlCmdIsNull() ?? string.Empty;

    public static string NomeSqlDiff(string text) => Nome.SqlCmdTextDiff(text) ?? string.Empty;
    public static string NomeSqlLike(string text) => Nome.SqlCmdTextLike(text) ?? string.Empty;
    public static string NomeSqlLikeInit(string text) => Nome.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string NomeSqlLikeSpaces(string? text) => Nome.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string FuncaoDiff(int id) => Funcao.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string FuncaoSql(int id) => Funcao.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string FuncaoIsNull => Funcao.SqlCmdIsNull() ?? string.Empty;
    public static string FuncaoNotIsNull => Funcao.SqlCmdNotIsNull() ?? string.Empty;

    public static string SetorDiff(int id) => Setor.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string SetorSql(int id) => Setor.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string SetorIsNull => Setor.SqlCmdIsNull() ?? string.Empty;
    public static string SetorNotIsNull => Setor.SqlCmdNotIsNull() ?? string.Empty;

    public static string DtNascSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{DtNasc}]");
    public static string DtNascSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{DtNasc}]");
    public static string DtNascSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{DtNasc}]");
    public static string DtNascSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{DtNasc}]");
    public static string DtNascSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{DtNasc}]");
    public static string DtNascSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{DtNasc}]");
    public static string DtNascSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{DtNasc}]");
    public static string DtNascSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{DtNasc}]");
    public static string DtNascSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{DtNasc}]");
    public static string DtNascSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{DtNasc}]");
    public static string DtNascSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{DtNasc}]");
    public static string DtNascSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{DtNasc}]");
    public static string DtNascIsNull => DtNasc.SqlCmdIsNull() ?? string.Empty;
    public static string DtNascNotIsNull => DtNasc.SqlCmdNotIsNull() ?? string.Empty;

    public static string QualificacaoSql(string text) => Qualificacao.SqlCmdTextIgual(text, 100) ?? string.Empty;
    public static string QualificacaoSqlNotIsNull => Qualificacao.SqlCmdNotIsNull() ?? string.Empty;
    public static string QualificacaoSqlIsNull => Qualificacao.SqlCmdIsNull() ?? string.Empty;

    public static string QualificacaoSqlDiff(string text) => Qualificacao.SqlCmdTextDiff(text) ?? string.Empty;
    public static string QualificacaoSqlLike(string text) => Qualificacao.SqlCmdTextLike(text) ?? string.Empty;
    public static string QualificacaoSqlLikeInit(string text) => Qualificacao.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string QualificacaoSqlLikeSpaces(string? text) => Qualificacao.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string SexoSql(bool valueCheck) => Sexo.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string SexoSqlSim => Sexo.SqlCmdBoolSim() ?? string.Empty;
    public static string SexoSqlNao => Sexo.SqlCmdBoolNao() ?? string.Empty;

    public static string IdadeDiff(int id) => Idade.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string IdadeSql(int id) => Idade.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string IdadeIsNull => Idade.SqlCmdIsNull() ?? string.Empty;
    public static string IdadeNotIsNull => Idade.SqlCmdNotIsNull() ?? string.Empty;

    public static string CPFSql(string text) => CPF.SqlCmdTextIgual(text, 11) ?? string.Empty;
    public static string CPFSqlNotIsNull => CPF.SqlCmdNotIsNull() ?? string.Empty;
    public static string CPFSqlIsNull => CPF.SqlCmdIsNull() ?? string.Empty;

    public static string CPFSqlDiff(string text) => CPF.SqlCmdTextDiff(text) ?? string.Empty;
    public static string CPFSqlLike(string text) => CPF.SqlCmdTextLike(text) ?? string.Empty;
    public static string CPFSqlLikeInit(string text) => CPF.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string CPFSqlLikeSpaces(string? text) => CPF.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string RGSql(string text) => RG.SqlCmdTextIgual(text, 30) ?? string.Empty;
    public static string RGSqlNotIsNull => RG.SqlCmdNotIsNull() ?? string.Empty;
    public static string RGSqlIsNull => RG.SqlCmdIsNull() ?? string.Empty;

    public static string RGSqlDiff(string text) => RG.SqlCmdTextDiff(text) ?? string.Empty;
    public static string RGSqlLike(string text) => RG.SqlCmdTextLike(text) ?? string.Empty;
    public static string RGSqlLikeInit(string text) => RG.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string RGSqlLikeSpaces(string? text) => RG.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string Periodo_IniSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{Periodo_Ini}]");
    public static string Periodo_IniSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{Periodo_Ini}]");
    public static string Periodo_IniSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{Periodo_Ini}]");
    public static string Periodo_IniSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{Periodo_Ini}]");
    public static string Periodo_IniSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{Periodo_Ini}]");
    public static string Periodo_IniSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{Periodo_Ini}]");
    public static string Periodo_IniSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{Periodo_Ini}]");
    public static string Periodo_IniSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{Periodo_Ini}]");
    public static string Periodo_IniSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{Periodo_Ini}]");
    public static string Periodo_IniSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{Periodo_Ini}]");
    public static string Periodo_IniSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{Periodo_Ini}]");
    public static string Periodo_IniSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{Periodo_Ini}]");
    public static string Periodo_IniIsNull => Periodo_Ini.SqlCmdIsNull() ?? string.Empty;
    public static string Periodo_IniNotIsNull => Periodo_Ini.SqlCmdNotIsNull() ?? string.Empty;

    public static string Periodo_FimSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{Periodo_Fim}]");
    public static string Periodo_FimSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{Periodo_Fim}]");
    public static string Periodo_FimSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{Periodo_Fim}]");
    public static string Periodo_FimSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{Periodo_Fim}]");
    public static string Periodo_FimSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{Periodo_Fim}]");
    public static string Periodo_FimSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{Periodo_Fim}]");
    public static string Periodo_FimSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{Periodo_Fim}]");
    public static string Periodo_FimSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{Periodo_Fim}]");
    public static string Periodo_FimSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{Periodo_Fim}]");
    public static string Periodo_FimSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{Periodo_Fim}]");
    public static string Periodo_FimSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{Periodo_Fim}]");
    public static string Periodo_FimSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{Periodo_Fim}]");
    public static string Periodo_FimIsNull => Periodo_Fim.SqlCmdIsNull() ?? string.Empty;
    public static string Periodo_FimNotIsNull => Periodo_Fim.SqlCmdNotIsNull() ?? string.Empty;

    public static string RegistroSql(string text) => Registro.SqlCmdTextIgual(text, 30) ?? string.Empty;
    public static string RegistroSqlNotIsNull => Registro.SqlCmdNotIsNull() ?? string.Empty;
    public static string RegistroSqlIsNull => Registro.SqlCmdIsNull() ?? string.Empty;

    public static string RegistroSqlDiff(string text) => Registro.SqlCmdTextDiff(text) ?? string.Empty;
    public static string RegistroSqlLike(string text) => Registro.SqlCmdTextLike(text) ?? string.Empty;
    public static string RegistroSqlLikeInit(string text) => Registro.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string RegistroSqlLikeSpaces(string? text) => Registro.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string CTPSNumeroSql(string text) => CTPSNumero.SqlCmdTextIgual(text, 15) ?? string.Empty;
    public static string CTPSNumeroSqlNotIsNull => CTPSNumero.SqlCmdNotIsNull() ?? string.Empty;
    public static string CTPSNumeroSqlIsNull => CTPSNumero.SqlCmdIsNull() ?? string.Empty;

    public static string CTPSNumeroSqlDiff(string text) => CTPSNumero.SqlCmdTextDiff(text) ?? string.Empty;
    public static string CTPSNumeroSqlLike(string text) => CTPSNumero.SqlCmdTextLike(text) ?? string.Empty;
    public static string CTPSNumeroSqlLikeInit(string text) => CTPSNumero.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string CTPSNumeroSqlLikeSpaces(string? text) => CTPSNumero.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string CTPSSerieSql(string text) => CTPSSerie.SqlCmdTextIgual(text, 10) ?? string.Empty;
    public static string CTPSSerieSqlNotIsNull => CTPSSerie.SqlCmdNotIsNull() ?? string.Empty;
    public static string CTPSSerieSqlIsNull => CTPSSerie.SqlCmdIsNull() ?? string.Empty;

    public static string CTPSSerieSqlDiff(string text) => CTPSSerie.SqlCmdTextDiff(text) ?? string.Empty;
    public static string CTPSSerieSqlLike(string text) => CTPSSerie.SqlCmdTextLike(text) ?? string.Empty;
    public static string CTPSSerieSqlLikeInit(string text) => CTPSSerie.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string CTPSSerieSqlLikeSpaces(string? text) => CTPSSerie.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string CTPSDtEmissaoSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{CTPSDtEmissao}]");
    public static string CTPSDtEmissaoSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{CTPSDtEmissao}]");
    public static string CTPSDtEmissaoSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{CTPSDtEmissao}]");
    public static string CTPSDtEmissaoSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{CTPSDtEmissao}]");
    public static string CTPSDtEmissaoSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{CTPSDtEmissao}]");
    public static string CTPSDtEmissaoSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{CTPSDtEmissao}]");
    public static string CTPSDtEmissaoSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{CTPSDtEmissao}]");
    public static string CTPSDtEmissaoSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{CTPSDtEmissao}]");
    public static string CTPSDtEmissaoSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{CTPSDtEmissao}]");
    public static string CTPSDtEmissaoSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{CTPSDtEmissao}]");
    public static string CTPSDtEmissaoSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{CTPSDtEmissao}]");
    public static string CTPSDtEmissaoSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{CTPSDtEmissao}]");
    public static string CTPSDtEmissaoIsNull => CTPSDtEmissao.SqlCmdIsNull() ?? string.Empty;
    public static string CTPSDtEmissaoNotIsNull => CTPSDtEmissao.SqlCmdNotIsNull() ?? string.Empty;

    public static string PISSql(string text) => PIS.SqlCmdTextIgual(text, 20) ?? string.Empty;
    public static string PISSqlNotIsNull => PIS.SqlCmdNotIsNull() ?? string.Empty;
    public static string PISSqlIsNull => PIS.SqlCmdIsNull() ?? string.Empty;

    public static string PISSqlDiff(string text) => PIS.SqlCmdTextDiff(text) ?? string.Empty;
    public static string PISSqlLike(string text) => PIS.SqlCmdTextLike(text) ?? string.Empty;
    public static string PISSqlLikeInit(string text) => PIS.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string PISSqlLikeSpaces(string? text) => PIS.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string LiberaAgendaSql(bool valueCheck) => LiberaAgenda.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string LiberaAgendaSqlSim => LiberaAgenda.SqlCmdBoolSim() ?? string.Empty;
    public static string LiberaAgendaSqlNao => LiberaAgenda.SqlCmdBoolNao() ?? string.Empty;

    public static string ObservacaoSql(string text) => Observacao.SqlCmdTextIgual(text) ?? string.Empty;
    public static string ObservacaoSqlNotIsNull => Observacao.SqlCmdNotIsNull() ?? string.Empty;
    public static string ObservacaoSqlIsNull => Observacao.SqlCmdIsNull() ?? string.Empty;

    public static string ObservacaoSqlDiff(string text) => Observacao.SqlCmdTextDiff(text) ?? string.Empty;
    public static string ObservacaoSqlLike(string text) => Observacao.SqlCmdTextLike(text) ?? string.Empty;
    public static string ObservacaoSqlLikeInit(string text) => Observacao.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string ObservacaoSqlLikeSpaces(string? text) => Observacao.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string EnderecoSql(string text) => Endereco.SqlCmdTextIgual(text, 80) ?? string.Empty;
    public static string EnderecoSqlNotIsNull => Endereco.SqlCmdNotIsNull() ?? string.Empty;
    public static string EnderecoSqlIsNull => Endereco.SqlCmdIsNull() ?? string.Empty;

    public static string EnderecoSqlDiff(string text) => Endereco.SqlCmdTextDiff(text) ?? string.Empty;
    public static string EnderecoSqlLike(string text) => Endereco.SqlCmdTextLike(text) ?? string.Empty;
    public static string EnderecoSqlLikeInit(string text) => Endereco.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string EnderecoSqlLikeSpaces(string? text) => Endereco.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string BairroSql(string text) => Bairro.SqlCmdTextIgual(text, 50) ?? string.Empty;
    public static string BairroSqlNotIsNull => Bairro.SqlCmdNotIsNull() ?? string.Empty;
    public static string BairroSqlIsNull => Bairro.SqlCmdIsNull() ?? string.Empty;

    public static string BairroSqlDiff(string text) => Bairro.SqlCmdTextDiff(text) ?? string.Empty;
    public static string BairroSqlLike(string text) => Bairro.SqlCmdTextLike(text) ?? string.Empty;
    public static string BairroSqlLikeInit(string text) => Bairro.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string BairroSqlLikeSpaces(string? text) => Bairro.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string CidadeDiff(int id) => Cidade.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string CidadeSql(int id) => Cidade.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string CidadeIsNull => Cidade.SqlCmdIsNull() ?? string.Empty;
    public static string CidadeNotIsNull => Cidade.SqlCmdNotIsNull() ?? string.Empty;

    public static string CEPSql(string text) => CEP.SqlCmdTextIgual(text, 10) ?? string.Empty;
    public static string CEPSqlNotIsNull => CEP.SqlCmdNotIsNull() ?? string.Empty;
    public static string CEPSqlIsNull => CEP.SqlCmdIsNull() ?? string.Empty;

    public static string CEPSqlDiff(string text) => CEP.SqlCmdTextDiff(text) ?? string.Empty;
    public static string CEPSqlLike(string text) => CEP.SqlCmdTextLike(text) ?? string.Empty;
    public static string CEPSqlLikeInit(string text) => CEP.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string CEPSqlLikeSpaces(string? text) => CEP.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string FoneSql(string text) => Fone.SqlCmdTextIgual(text) ?? string.Empty;
    public static string FoneSqlNotIsNull => Fone.SqlCmdNotIsNull() ?? string.Empty;
    public static string FoneSqlIsNull => Fone.SqlCmdIsNull() ?? string.Empty;

    public static string FoneSqlDiff(string text) => Fone.SqlCmdTextDiff(text) ?? string.Empty;
    public static string FoneSqlLike(string text) => Fone.SqlCmdTextLike(text) ?? string.Empty;
    public static string FoneSqlLikeInit(string text) => Fone.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string FoneSqlLikeSpaces(string? text) => Fone.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string FaxSql(string text) => Fax.SqlCmdTextIgual(text) ?? string.Empty;
    public static string FaxSqlNotIsNull => Fax.SqlCmdNotIsNull() ?? string.Empty;
    public static string FaxSqlIsNull => Fax.SqlCmdIsNull() ?? string.Empty;

    public static string FaxSqlDiff(string text) => Fax.SqlCmdTextDiff(text) ?? string.Empty;
    public static string FaxSqlLike(string text) => Fax.SqlCmdTextLike(text) ?? string.Empty;
    public static string FaxSqlLikeInit(string text) => Fax.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string FaxSqlLikeSpaces(string? text) => Fax.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string EMailSql(string text) => EMail.SqlCmdTextIgual(text, 255) ?? string.Empty;
    public static string EMailSqlNotIsNull => EMail.SqlCmdNotIsNull() ?? string.Empty;
    public static string EMailSqlIsNull => EMail.SqlCmdIsNull() ?? string.Empty;

    public static string EMailSqlDiff(string text) => EMail.SqlCmdTextDiff(text) ?? string.Empty;
    public static string EMailSqlLike(string text) => EMail.SqlCmdTextLike(text) ?? string.Empty;
    public static string EMailSqlLikeInit(string text) => EMail.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string EMailSqlLikeSpaces(string? text) => EMail.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string PaiSql(string text) => Pai.SqlCmdTextIgual(text, 50) ?? string.Empty;
    public static string PaiSqlNotIsNull => Pai.SqlCmdNotIsNull() ?? string.Empty;
    public static string PaiSqlIsNull => Pai.SqlCmdIsNull() ?? string.Empty;

    public static string PaiSqlDiff(string text) => Pai.SqlCmdTextDiff(text) ?? string.Empty;
    public static string PaiSqlLike(string text) => Pai.SqlCmdTextLike(text) ?? string.Empty;
    public static string PaiSqlLikeInit(string text) => Pai.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string PaiSqlLikeSpaces(string? text) => Pai.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string MaeSql(string text) => Mae.SqlCmdTextIgual(text, 50) ?? string.Empty;
    public static string MaeSqlNotIsNull => Mae.SqlCmdNotIsNull() ?? string.Empty;
    public static string MaeSqlIsNull => Mae.SqlCmdIsNull() ?? string.Empty;

    public static string MaeSqlDiff(string text) => Mae.SqlCmdTextDiff(text) ?? string.Empty;
    public static string MaeSqlLike(string text) => Mae.SqlCmdTextLike(text) ?? string.Empty;
    public static string MaeSqlLikeInit(string text) => Mae.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string MaeSqlLikeSpaces(string? text) => Mae.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string ClassSql(string text) => Class.SqlCmdTextIgual(text, 1) ?? string.Empty;
    public static string ClassSqlNotIsNull => Class.SqlCmdNotIsNull() ?? string.Empty;
    public static string ClassSqlIsNull => Class.SqlCmdIsNull() ?? string.Empty;

    public static string ClassSqlDiff(string text) => Class.SqlCmdTextDiff(text) ?? string.Empty;
    public static string ClassSqlLike(string text) => Class.SqlCmdTextLike(text) ?? string.Empty;
    public static string ClassSqlLikeInit(string text) => Class.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string ClassSqlLikeSpaces(string? text) => Class.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string EtiquetaSql(bool valueCheck) => Etiqueta.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string EtiquetaSqlSim => Etiqueta.SqlCmdBoolSim() ?? string.Empty;
    public static string EtiquetaSqlNao => Etiqueta.SqlCmdBoolNao() ?? string.Empty;

    public static string AniSql(bool valueCheck) => Ani.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string AniSqlSim => Ani.SqlCmdBoolSim() ?? string.Empty;
    public static string AniSqlNao => Ani.SqlCmdBoolNao() ?? string.Empty;

    public static string BoldSql(bool valueCheck) => Bold.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string BoldSqlSim => Bold.SqlCmdBoolSim() ?? string.Empty;
    public static string BoldSqlNao => Bold.SqlCmdBoolNao() ?? string.Empty;

    public static string GUIDSql(string text) => GUID.SqlCmdTextIgual(text, 150) ?? string.Empty;
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
        PreNome = 1,
        PreFuncao = 2,
        PreSetor = 3,
        PreDtNasc = 4,
        PreQualificacao = 5,
        PreSexo = 6,
        PreIdade = 7,
        PreCPF = 8,
        PreRG = 9,
        PrePeriodo_Ini = 10,
        PrePeriodo_Fim = 11,
        PreRegistro = 12,
        PreCTPSNumero = 13,
        PreCTPSSerie = 14,
        PreCTPSDtEmissao = 15,
        PrePIS = 16,
        PreSalario = 17,
        PreLiberaAgenda = 18,
        PreObservacao = 19,
        PreEndereco = 20,
        PreBairro = 21,
        PreCidade = 22,
        PreCEP = 23,
        PreFone = 24,
        PreFax = 25,
        PreEMail = 26,
        PrePai = 27,
        PreMae = 28,
        PreClass = 29,
        PreEtiqueta = 30,
        PreAni = 31,
        PreBold = 32,
        PreGUID = 33,
        PreQuemCad = 34,
        PreDtCad = 35,
        PreQuemAtu = 36,
        PreDtAtu = 37,
        PreVisto = 38
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.PreNome => PreNome,
        NomesCamposTabela.PreFuncao => PreFuncao,
        NomesCamposTabela.PreSetor => PreSetor,
        NomesCamposTabela.PreDtNasc => PreDtNasc,
        NomesCamposTabela.PreQualificacao => PreQualificacao,
        NomesCamposTabela.PreSexo => PreSexo,
        NomesCamposTabela.PreIdade => PreIdade,
        NomesCamposTabela.PreCPF => PreCPF,
        NomesCamposTabela.PreRG => PreRG,
        NomesCamposTabela.PrePeriodo_Ini => PrePeriodo_Ini,
        NomesCamposTabela.PrePeriodo_Fim => PrePeriodo_Fim,
        NomesCamposTabela.PreRegistro => PreRegistro,
        NomesCamposTabela.PreCTPSNumero => PreCTPSNumero,
        NomesCamposTabela.PreCTPSSerie => PreCTPSSerie,
        NomesCamposTabela.PreCTPSDtEmissao => PreCTPSDtEmissao,
        NomesCamposTabela.PrePIS => PrePIS,
        NomesCamposTabela.PreSalario => PreSalario,
        NomesCamposTabela.PreLiberaAgenda => PreLiberaAgenda,
        NomesCamposTabela.PreObservacao => PreObservacao,
        NomesCamposTabela.PreEndereco => PreEndereco,
        NomesCamposTabela.PreBairro => PreBairro,
        NomesCamposTabela.PreCidade => PreCidade,
        NomesCamposTabela.PreCEP => PreCEP,
        NomesCamposTabela.PreFone => PreFone,
        NomesCamposTabela.PreFax => PreFax,
        NomesCamposTabela.PreEMail => PreEMail,
        NomesCamposTabela.PrePai => PrePai,
        NomesCamposTabela.PreMae => PreMae,
        NomesCamposTabela.PreClass => PreClass,
        NomesCamposTabela.PreEtiqueta => PreEtiqueta,
        NomesCamposTabela.PreAni => PreAni,
        NomesCamposTabela.PreBold => PreBold,
        NomesCamposTabela.PreGUID => PreGUID,
        NomesCamposTabela.PreQuemCad => PreQuemCad,
        NomesCamposTabela.PreDtCad => PreDtCad,
        NomesCamposTabela.PreQuemAtu => PreQuemAtu,
        NomesCamposTabela.PreDtAtu => PreDtAtu,
        NomesCamposTabela.PreVisto => PreVisto,
        _ => null
    };
}