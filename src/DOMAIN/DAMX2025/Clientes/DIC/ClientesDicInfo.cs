using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public static partial class DBClientesDicInfo
{
    public const string CampoCodigo = "cliCodigo";
    public const string CampoNome = "cliNome";
    public const string TablePrefix = "cli";
    public const string Empresa = "cliEmpresa"; // LOCALIZACAO 170523
    public const string Icone = "cliIcone"; // LOCALIZACAO 170523
    public const string NomeMae = "cliNomeMae"; // LOCALIZACAO 170523
    public const string RGDataExp = "cliRGDataExp"; // LOCALIZACAO 170523
    public const string Inativo = "cliInativo"; // LOCALIZACAO 170523
    public const string QuemIndicou = "cliQuemIndicou"; // LOCALIZACAO 170523
    public const string SendEMail = "cliSendEMail"; // LOCALIZACAO 170523
    public const string Nome = "cliNome"; // LOCALIZACAO 170523
    public const string Adv = "cliAdv"; // LOCALIZACAO 170523
    public const string IDRep = "cliIDRep"; // LOCALIZACAO 170523
    public const string Juridica = "cliJuridica"; // LOCALIZACAO 170523
    public const string NomeFantasia = "cliNomeFantasia"; // LOCALIZACAO 170523
    public const string Class = "cliClass"; // LOCALIZACAO 170523
    public const string Tipo = "cliTipo"; // LOCALIZACAO 170523
    public const string DtNasc = "cliDtNasc"; // LOCALIZACAO 170523
    public const string InscEst = "cliInscEst"; // LOCALIZACAO 170523
    public const string Qualificacao = "cliQualificacao"; // LOCALIZACAO 170523
    public const string Sexo = "cliSexo"; // LOCALIZACAO 170523
    public const string Idade = "cliIdade"; // LOCALIZACAO 170523
    public const string CNPJ = "cliCNPJ"; // LOCALIZACAO 170523
    public const string CPF = "cliCPF"; // LOCALIZACAO 170523
    public const string RG = "cliRG"; // LOCALIZACAO 170523
    public const string TipoCaptacao = "cliTipoCaptacao"; // LOCALIZACAO 170523
    public const string Observacao = "cliObservacao"; // LOCALIZACAO 170523
    public const string Endereco = "cliEndereco"; // LOCALIZACAO 170523
    public const string Bairro = "cliBairro"; // LOCALIZACAO 170523
    public const string Cidade = "cliCidade"; // LOCALIZACAO 170523
    public const string CEP = "cliCEP"; // LOCALIZACAO 170523
    public const string Fax = "cliFax"; // LOCALIZACAO 170523
    public const string Fone = "cliFone"; // LOCALIZACAO 170523
    public const string Data = "cliData"; // LOCALIZACAO 170523
    public const string HomePage = "cliHomePage"; // LOCALIZACAO 170523
    public const string EMail = "cliEMail"; // LOCALIZACAO 170523
    public const string Obito = "cliObito"; // LOCALIZACAO 170523
    public const string NomePai = "cliNomePai"; // LOCALIZACAO 170523
    public const string RGOExpeditor = "cliRGOExpeditor"; // LOCALIZACAO 170523
    public const string RegimeTributacao = "cliRegimeTributacao"; // LOCALIZACAO 170523
    public const string EnquadramentoEmpresa = "cliEnquadramentoEmpresa"; // LOCALIZACAO 170523
    public const string ReportECBOnly = "cliReportECBOnly"; // LOCALIZACAO 170523
    public const string ProBono = "cliProBono"; // LOCALIZACAO 170523
    public const string CNH = "cliCNH"; // LOCALIZACAO 170523
    public const string PessoaContato = "cliPessoaContato"; // LOCALIZACAO 170523
    public const string Etiqueta = "cliEtiqueta"; // LOCALIZACAO 170523
    public const string Ani = "cliAni"; // LOCALIZACAO 170523
    public const string Bold = "cliBold"; // LOCALIZACAO 170523
    public const string GUID = "cliGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "cliQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "cliDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "cliQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "cliDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "cliVisto"; // LOCALIZACAO 170523
    public static string CampoCodigoDiff(int id) => CampoCodigo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string CampoCodigoSql(int id) => CampoCodigo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string CampoCodigoIsNull => CampoCodigo.SqlCmdIsNull() ?? string.Empty;
    public static string CampoCodigoNotIsNull => CampoCodigo.SqlCmdNotIsNull() ?? string.Empty;

    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Empresa,
        2 => Icone,
        3 => NomeMae,
        4 => RGDataExp,
        5 => Inativo,
        6 => QuemIndicou,
        7 => SendEMail,
        8 => Nome,
        9 => Adv,
        10 => IDRep,
        11 => Juridica,
        12 => NomeFantasia,
        13 => Class,
        14 => Tipo,
        15 => DtNasc,
        16 => InscEst,
        17 => Qualificacao,
        18 => Sexo,
        19 => Idade,
        20 => CNPJ,
        21 => CPF,
        22 => RG,
        23 => TipoCaptacao,
        24 => Observacao,
        25 => Endereco,
        26 => Bairro,
        27 => Cidade,
        28 => CEP,
        29 => Fax,
        30 => Fone,
        31 => Data,
        32 => HomePage,
        33 => EMail,
        34 => Obito,
        35 => NomePai,
        36 => RGOExpeditor,
        37 => RegimeTributacao,
        38 => EnquadramentoEmpresa,
        39 => ReportECBOnly,
        40 => ProBono,
        41 => CNH,
        42 => PessoaContato,
        43 => Etiqueta,
        44 => Ani,
        45 => Bold,
        46 => GUID,
        47 => QuemCad,
        48 => DtCad,
        49 => QuemAtu,
        50 => DtAtu,
        51 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "Clientes";
#region PropriedadesDaTabela
    public static DBInfoSystem CliEmpresa => new(0, PTabelaNome, CampoCodigo, Empresa, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem CliIcone => new(0, PTabelaNome, CampoCodigo, Icone, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem CliNomeMae => new(0, PTabelaNome, CampoCodigo, NomeMae, 80, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem CliRGDataExp => new(0, PTabelaNome, CampoCodigo, RGDataExp, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem CliInativo => new(0, PTabelaNome, CampoCodigo, Inativo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem CliQuemIndicou => new(0, PTabelaNome, CampoCodigo, QuemIndicou, 80, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem CliSendEMail => new(0, PTabelaNome, CampoCodigo, SendEMail, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem CliNome => new(0, PTabelaNome, CampoCodigo, Nome, 80, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false);
    public static DBInfoSystem CliAdv => new(0, PTabelaNome, CampoCodigo, Adv, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem CliIDRep => new(0, PTabelaNome, CampoCodigo, IDRep, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem CliJuridica => new(0, PTabelaNome, CampoCodigo, Juridica, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem CliNomeFantasia => new(0, PTabelaNome, CampoCodigo, NomeFantasia, 80, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem CliClass => new(0, PTabelaNome, CampoCodigo, Class, 1, DevourerOne.PClassificacao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextClassificacaoStar, true, false, false);
    public static DBInfoSystem CliTipo => new(0, PTabelaNome, CampoCodigo, Tipo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBooleanTipoPessoa);
    public static DBInfoSystem CliDtNasc => new(0, PTabelaNome, CampoCodigo, DtNasc, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDataNascimento);
    public static DBInfoSystem CliInscEst => new(0, PTabelaNome, CampoCodigo, InscEst, 15, DevourerOne.PInscricaoEstadual, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextInscricao, true, false, false);
    public static DBInfoSystem CliQualificacao => new(0, PTabelaNome, CampoCodigo, Qualificacao, 100, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem CliSexo => new(0, PTabelaNome, CampoCodigo, Sexo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBooleanSexo);
    public static DBInfoSystem CliIdade => new(0, PTabelaNome, CampoCodigo, Idade, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem CliCNPJ => new(0, PTabelaNome, CampoCodigo, CNPJ, 14, DevourerOne.PCnpj, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCnpj, true, false, false);
    public static DBInfoSystem CliCPF => new(0, PTabelaNome, CampoCodigo, CPF, 11, DevourerOne.PCpf, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCpf, true, false, false);
    public static DBInfoSystem CliRG => new(0, PTabelaNome, CampoCodigo, RG, 50, DevourerOne.PRg, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextRG, true, false, false);
    public static DBInfoSystem CliTipoCaptacao => new(0, PTabelaNome, CampoCodigo, TipoCaptacao, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem CliObservacao => new(0, PTabelaNome, CampoCodigo, Observacao, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemoObservacao, true, false, false);
    public static DBInfoSystem CliEndereco => new(0, PTabelaNome, CampoCodigo, Endereco, 80, DevourerOne.PEndereco, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEndereco, true, false, false);
    public static DBInfoSystem CliBairro => new(0, PTabelaNome, CampoCodigo, Bairro, 50, DevourerOne.PBairro, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextBairro, true, false, false);
    public static DBInfoSystem CliCidade => new(0, PTabelaNome, CampoCodigo, Cidade, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBCidadeDicInfo.CampoCodigo, DBCidadeDicInfo.TabelaNome, new DBCidadeODicInfo(), false); // DBI 11 
    public static DBInfoSystem CliCEP => new(0, PTabelaNome, CampoCodigo, CEP, 10, DevourerOne.PCep, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCep, true, false, false);
    public static DBInfoSystem CliFax => new(0, PTabelaNome, CampoCodigo, Fax, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFax, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFax, true, false, false);
    public static DBInfoSystem CliFone => new(0, PTabelaNome, CampoCodigo, Fone, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFone, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFone, true, false, false);
    public static DBInfoSystem CliData => new(0, PTabelaNome, CampoCodigo, Data, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem CliHomePage => new(0, PTabelaNome, CampoCodigo, HomePage, 60, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextWebsite, true, false, false);
    public static DBInfoSystem CliEMail => new(0, PTabelaNome, CampoCodigo, EMail, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEmail, true, false, false);
    public static DBInfoSystem CliObito => new(0, PTabelaNome, CampoCodigo, Obito, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem CliNomePai => new(0, PTabelaNome, CampoCodigo, NomePai, 80, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem CliRGOExpeditor => new(0, PTabelaNome, CampoCodigo, RGOExpeditor, 30, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem CliRegimeTributacao => new(0, PTabelaNome, CampoCodigo, RegimeTributacao, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBRegimeTributacaoDicInfo.CampoCodigo, DBRegimeTributacaoDicInfo.TabelaNome, new DBRegimeTributacaoODicInfo(), false); // DBI 11 
    public static DBInfoSystem CliEnquadramentoEmpresa => new(0, PTabelaNome, CampoCodigo, EnquadramentoEmpresa, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBEnquadramentoEmpresaDicInfo.CampoCodigo, DBEnquadramentoEmpresaDicInfo.TabelaNome, new DBEnquadramentoEmpresaODicInfo(), false); // DBI 11 
    public static DBInfoSystem CliReportECBOnly => new(0, PTabelaNome, CampoCodigo, ReportECBOnly, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem CliProBono => new(0, PTabelaNome, CampoCodigo, ProBono, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem CliCNH => new(0, PTabelaNome, CampoCodigo, CNH, 100, DevourerOne.PCnh, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCnh, true, false, false);
    public static DBInfoSystem CliPessoaContato => new(0, PTabelaNome, CampoCodigo, PessoaContato, 120, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem CliEtiqueta => new(0, PTabelaNome, CampoCodigo, Etiqueta, DevourerOne.PCriarEtiqueta, DevourerOne.PTooltipEtiqueta, ETipoDadosSysteminfo.SysteminfoBooleanEtiqueta);
    public static DBInfoSystem CliAni => new(0, PTabelaNome, CampoCodigo, Ani, DevourerOne.PCaptionFieldAniversario, DevourerOne.PTooltipAniversario, ETipoDadosSysteminfo.SysteminfoBooleanLembrarAniversario);
    public static DBInfoSystem CliBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold);
    public static DBInfoSystem CliGUID => new(0, PTabelaNome, CampoCodigo, GUID, 150, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false);
    public static DBInfoSystem CliQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem CliDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento);
    public static DBInfoSystem CliQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem CliDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao);
    public static DBInfoSystem CliVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto);

#endregion
    public static bool IsThisTable(string nomeTabela) => nomeTabela.ToUpper().Equals(TabelaNome.ToUpper());
#region SMART_SQLServices 
    public static string EmpresaDiff(int id) => Empresa.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string EmpresaSql(int id) => Empresa.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string EmpresaIsNull => Empresa.SqlCmdIsNull() ?? string.Empty;
    public static string EmpresaNotIsNull => Empresa.SqlCmdNotIsNull() ?? string.Empty;

    public static string IconeSql(string text) => Icone.SqlCmdTextIgual(text, 255) ?? string.Empty;
    public static string IconeSqlNotIsNull => Icone.SqlCmdNotIsNull() ?? string.Empty;
    public static string IconeSqlIsNull => Icone.SqlCmdIsNull() ?? string.Empty;

    public static string IconeSqlDiff(string text) => Icone.SqlCmdTextDiff(text) ?? string.Empty;
    public static string IconeSqlLike(string text) => Icone.SqlCmdTextLike(text) ?? string.Empty;
    public static string IconeSqlLikeInit(string text) => Icone.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string IconeSqlLikeSpaces(string? text) => Icone.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string NomeMaeSql(string text) => NomeMae.SqlCmdTextIgual(text, 80) ?? string.Empty;
    public static string NomeMaeSqlNotIsNull => NomeMae.SqlCmdNotIsNull() ?? string.Empty;
    public static string NomeMaeSqlIsNull => NomeMae.SqlCmdIsNull() ?? string.Empty;

    public static string NomeMaeSqlDiff(string text) => NomeMae.SqlCmdTextDiff(text) ?? string.Empty;
    public static string NomeMaeSqlLike(string text) => NomeMae.SqlCmdTextLike(text) ?? string.Empty;
    public static string NomeMaeSqlLikeInit(string text) => NomeMae.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string NomeMaeSqlLikeSpaces(string? text) => NomeMae.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string RGDataExpSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{RGDataExp}]");
    public static string RGDataExpSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{RGDataExp}]");
    public static string RGDataExpSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{RGDataExp}]");
    public static string RGDataExpSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{RGDataExp}]");
    public static string RGDataExpSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{RGDataExp}]");
    public static string RGDataExpSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{RGDataExp}]");
    public static string RGDataExpSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{RGDataExp}]");
    public static string RGDataExpSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{RGDataExp}]");
    public static string RGDataExpSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{RGDataExp}]");
    public static string RGDataExpSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{RGDataExp}]");
    public static string RGDataExpSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{RGDataExp}]");
    public static string RGDataExpSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{RGDataExp}]");
    public static string RGDataExpIsNull => RGDataExp.SqlCmdIsNull() ?? string.Empty;
    public static string RGDataExpNotIsNull => RGDataExp.SqlCmdNotIsNull() ?? string.Empty;

    public static string InativoSql(bool valueCheck) => Inativo.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string InativoSqlSim => Inativo.SqlCmdBoolSim() ?? string.Empty;
    public static string InativoSqlNao => Inativo.SqlCmdBoolNao() ?? string.Empty;

    public static string QuemIndicouSql(string text) => QuemIndicou.SqlCmdTextIgual(text, 80) ?? string.Empty;
    public static string QuemIndicouSqlNotIsNull => QuemIndicou.SqlCmdNotIsNull() ?? string.Empty;
    public static string QuemIndicouSqlIsNull => QuemIndicou.SqlCmdIsNull() ?? string.Empty;

    public static string QuemIndicouSqlDiff(string text) => QuemIndicou.SqlCmdTextDiff(text) ?? string.Empty;
    public static string QuemIndicouSqlLike(string text) => QuemIndicou.SqlCmdTextLike(text) ?? string.Empty;
    public static string QuemIndicouSqlLikeInit(string text) => QuemIndicou.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string QuemIndicouSqlLikeSpaces(string? text) => QuemIndicou.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string SendEMailSql(bool valueCheck) => SendEMail.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string SendEMailSqlSim => SendEMail.SqlCmdBoolSim() ?? string.Empty;
    public static string SendEMailSqlNao => SendEMail.SqlCmdBoolNao() ?? string.Empty;

    public static string NomeSql(string text) => Nome.SqlCmdTextIgual(text, 80) ?? string.Empty;
    public static string NomeSqlNotIsNull => Nome.SqlCmdNotIsNull() ?? string.Empty;
    public static string NomeSqlIsNull => Nome.SqlCmdIsNull() ?? string.Empty;

    public static string NomeSqlDiff(string text) => Nome.SqlCmdTextDiff(text) ?? string.Empty;
    public static string NomeSqlLike(string text) => Nome.SqlCmdTextLike(text) ?? string.Empty;
    public static string NomeSqlLikeInit(string text) => Nome.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string NomeSqlLikeSpaces(string? text) => Nome.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string AdvDiff(int id) => Adv.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string AdvSql(int id) => Adv.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string AdvIsNull => Adv.SqlCmdIsNull() ?? string.Empty;
    public static string AdvNotIsNull => Adv.SqlCmdNotIsNull() ?? string.Empty;

    public static string IDRepDiff(int id) => IDRep.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string IDRepSql(int id) => IDRep.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string IDRepIsNull => IDRep.SqlCmdIsNull() ?? string.Empty;
    public static string IDRepNotIsNull => IDRep.SqlCmdNotIsNull() ?? string.Empty;

    public static string JuridicaSql(bool valueCheck) => Juridica.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string JuridicaSqlSim => Juridica.SqlCmdBoolSim() ?? string.Empty;
    public static string JuridicaSqlNao => Juridica.SqlCmdBoolNao() ?? string.Empty;

    public static string NomeFantasiaSql(string text) => NomeFantasia.SqlCmdTextIgual(text, 80) ?? string.Empty;
    public static string NomeFantasiaSqlNotIsNull => NomeFantasia.SqlCmdNotIsNull() ?? string.Empty;
    public static string NomeFantasiaSqlIsNull => NomeFantasia.SqlCmdIsNull() ?? string.Empty;

    public static string NomeFantasiaSqlDiff(string text) => NomeFantasia.SqlCmdTextDiff(text) ?? string.Empty;
    public static string NomeFantasiaSqlLike(string text) => NomeFantasia.SqlCmdTextLike(text) ?? string.Empty;
    public static string NomeFantasiaSqlLikeInit(string text) => NomeFantasia.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string NomeFantasiaSqlLikeSpaces(string? text) => NomeFantasia.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string ClassSql(string text) => Class.SqlCmdTextIgual(text, 1) ?? string.Empty;
    public static string ClassSqlNotIsNull => Class.SqlCmdNotIsNull() ?? string.Empty;
    public static string ClassSqlIsNull => Class.SqlCmdIsNull() ?? string.Empty;

    public static string ClassSqlDiff(string text) => Class.SqlCmdTextDiff(text) ?? string.Empty;
    public static string ClassSqlLike(string text) => Class.SqlCmdTextLike(text) ?? string.Empty;
    public static string ClassSqlLikeInit(string text) => Class.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string ClassSqlLikeSpaces(string? text) => Class.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string TipoSql(bool valueCheck) => Tipo.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string TipoSqlSim => Tipo.SqlCmdBoolSim() ?? string.Empty;
    public static string TipoSqlNao => Tipo.SqlCmdBoolNao() ?? string.Empty;

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

    public static string InscEstSql(string text) => InscEst.SqlCmdTextIgual(text, 15) ?? string.Empty;
    public static string InscEstSqlNotIsNull => InscEst.SqlCmdNotIsNull() ?? string.Empty;
    public static string InscEstSqlIsNull => InscEst.SqlCmdIsNull() ?? string.Empty;

    public static string InscEstSqlDiff(string text) => InscEst.SqlCmdTextDiff(text) ?? string.Empty;
    public static string InscEstSqlLike(string text) => InscEst.SqlCmdTextLike(text) ?? string.Empty;
    public static string InscEstSqlLikeInit(string text) => InscEst.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string InscEstSqlLikeSpaces(string? text) => InscEst.SqlCmdTextLikeSpaces(text) ?? string.Empty;
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

    public static string CNPJSql(string text) => CNPJ.SqlCmdTextIgual(text, 14) ?? string.Empty;
    public static string CNPJSqlNotIsNull => CNPJ.SqlCmdNotIsNull() ?? string.Empty;
    public static string CNPJSqlIsNull => CNPJ.SqlCmdIsNull() ?? string.Empty;

    public static string CNPJSqlDiff(string text) => CNPJ.SqlCmdTextDiff(text) ?? string.Empty;
    public static string CNPJSqlLike(string text) => CNPJ.SqlCmdTextLike(text) ?? string.Empty;
    public static string CNPJSqlLikeInit(string text) => CNPJ.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string CNPJSqlLikeSpaces(string? text) => CNPJ.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string CPFSql(string text) => CPF.SqlCmdTextIgual(text, 11) ?? string.Empty;
    public static string CPFSqlNotIsNull => CPF.SqlCmdNotIsNull() ?? string.Empty;
    public static string CPFSqlIsNull => CPF.SqlCmdIsNull() ?? string.Empty;

    public static string CPFSqlDiff(string text) => CPF.SqlCmdTextDiff(text) ?? string.Empty;
    public static string CPFSqlLike(string text) => CPF.SqlCmdTextLike(text) ?? string.Empty;
    public static string CPFSqlLikeInit(string text) => CPF.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string CPFSqlLikeSpaces(string? text) => CPF.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string RGSql(string text) => RG.SqlCmdTextIgual(text, 50) ?? string.Empty;
    public static string RGSqlNotIsNull => RG.SqlCmdNotIsNull() ?? string.Empty;
    public static string RGSqlIsNull => RG.SqlCmdIsNull() ?? string.Empty;

    public static string RGSqlDiff(string text) => RG.SqlCmdTextDiff(text) ?? string.Empty;
    public static string RGSqlLike(string text) => RG.SqlCmdTextLike(text) ?? string.Empty;
    public static string RGSqlLikeInit(string text) => RG.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string RGSqlLikeSpaces(string? text) => RG.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string TipoCaptacaoSql(bool valueCheck) => TipoCaptacao.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string TipoCaptacaoSqlSim => TipoCaptacao.SqlCmdBoolSim() ?? string.Empty;
    public static string TipoCaptacaoSqlNao => TipoCaptacao.SqlCmdBoolNao() ?? string.Empty;

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
    public static string FaxSql(string text) => Fax.SqlCmdTextIgual(text) ?? string.Empty;
    public static string FaxSqlNotIsNull => Fax.SqlCmdNotIsNull() ?? string.Empty;
    public static string FaxSqlIsNull => Fax.SqlCmdIsNull() ?? string.Empty;

    public static string FaxSqlDiff(string text) => Fax.SqlCmdTextDiff(text) ?? string.Empty;
    public static string FaxSqlLike(string text) => Fax.SqlCmdTextLike(text) ?? string.Empty;
    public static string FaxSqlLikeInit(string text) => Fax.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string FaxSqlLikeSpaces(string? text) => Fax.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string FoneSql(string text) => Fone.SqlCmdTextIgual(text) ?? string.Empty;
    public static string FoneSqlNotIsNull => Fone.SqlCmdNotIsNull() ?? string.Empty;
    public static string FoneSqlIsNull => Fone.SqlCmdIsNull() ?? string.Empty;

    public static string FoneSqlDiff(string text) => Fone.SqlCmdTextDiff(text) ?? string.Empty;
    public static string FoneSqlLike(string text) => Fone.SqlCmdTextLike(text) ?? string.Empty;
    public static string FoneSqlLikeInit(string text) => Fone.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string FoneSqlLikeSpaces(string? text) => Fone.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string DataSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{Data}]");
    public static string DataSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{Data}]");
    public static string DataSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{Data}]");
    public static string DataSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{Data}]");
    public static string DataSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{Data}]");
    public static string DataSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{Data}]");
    public static string DataSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{Data}]");
    public static string DataSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{Data}]");
    public static string DataSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{Data}]");
    public static string DataSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{Data}]");
    public static string DataSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{Data}]");
    public static string DataSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{Data}]");
    public static string DataIsNull => Data.SqlCmdIsNull() ?? string.Empty;
    public static string DataNotIsNull => Data.SqlCmdNotIsNull() ?? string.Empty;

    public static string HomePageSql(string text) => HomePage.SqlCmdTextIgual(text, 60) ?? string.Empty;
    public static string HomePageSqlNotIsNull => HomePage.SqlCmdNotIsNull() ?? string.Empty;
    public static string HomePageSqlIsNull => HomePage.SqlCmdIsNull() ?? string.Empty;

    public static string HomePageSqlDiff(string text) => HomePage.SqlCmdTextDiff(text) ?? string.Empty;
    public static string HomePageSqlLike(string text) => HomePage.SqlCmdTextLike(text) ?? string.Empty;
    public static string HomePageSqlLikeInit(string text) => HomePage.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string HomePageSqlLikeSpaces(string? text) => HomePage.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string EMailSql(string text) => EMail.SqlCmdTextIgual(text, 255) ?? string.Empty;
    public static string EMailSqlNotIsNull => EMail.SqlCmdNotIsNull() ?? string.Empty;
    public static string EMailSqlIsNull => EMail.SqlCmdIsNull() ?? string.Empty;

    public static string EMailSqlDiff(string text) => EMail.SqlCmdTextDiff(text) ?? string.Empty;
    public static string EMailSqlLike(string text) => EMail.SqlCmdTextLike(text) ?? string.Empty;
    public static string EMailSqlLikeInit(string text) => EMail.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string EMailSqlLikeSpaces(string? text) => EMail.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string ObitoSql(bool valueCheck) => Obito.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string ObitoSqlSim => Obito.SqlCmdBoolSim() ?? string.Empty;
    public static string ObitoSqlNao => Obito.SqlCmdBoolNao() ?? string.Empty;

    public static string NomePaiSql(string text) => NomePai.SqlCmdTextIgual(text, 80) ?? string.Empty;
    public static string NomePaiSqlNotIsNull => NomePai.SqlCmdNotIsNull() ?? string.Empty;
    public static string NomePaiSqlIsNull => NomePai.SqlCmdIsNull() ?? string.Empty;

    public static string NomePaiSqlDiff(string text) => NomePai.SqlCmdTextDiff(text) ?? string.Empty;
    public static string NomePaiSqlLike(string text) => NomePai.SqlCmdTextLike(text) ?? string.Empty;
    public static string NomePaiSqlLikeInit(string text) => NomePai.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string NomePaiSqlLikeSpaces(string? text) => NomePai.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string RGOExpeditorSql(string text) => RGOExpeditor.SqlCmdTextIgual(text, 30) ?? string.Empty;
    public static string RGOExpeditorSqlNotIsNull => RGOExpeditor.SqlCmdNotIsNull() ?? string.Empty;
    public static string RGOExpeditorSqlIsNull => RGOExpeditor.SqlCmdIsNull() ?? string.Empty;

    public static string RGOExpeditorSqlDiff(string text) => RGOExpeditor.SqlCmdTextDiff(text) ?? string.Empty;
    public static string RGOExpeditorSqlLike(string text) => RGOExpeditor.SqlCmdTextLike(text) ?? string.Empty;
    public static string RGOExpeditorSqlLikeInit(string text) => RGOExpeditor.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string RGOExpeditorSqlLikeSpaces(string? text) => RGOExpeditor.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string RegimeTributacaoDiff(int id) => RegimeTributacao.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string RegimeTributacaoSql(int id) => RegimeTributacao.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string RegimeTributacaoIsNull => RegimeTributacao.SqlCmdIsNull() ?? string.Empty;
    public static string RegimeTributacaoNotIsNull => RegimeTributacao.SqlCmdNotIsNull() ?? string.Empty;

    public static string EnquadramentoEmpresaDiff(int id) => EnquadramentoEmpresa.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string EnquadramentoEmpresaSql(int id) => EnquadramentoEmpresa.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string EnquadramentoEmpresaIsNull => EnquadramentoEmpresa.SqlCmdIsNull() ?? string.Empty;
    public static string EnquadramentoEmpresaNotIsNull => EnquadramentoEmpresa.SqlCmdNotIsNull() ?? string.Empty;

    public static string ReportECBOnlySql(bool valueCheck) => ReportECBOnly.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string ReportECBOnlySqlSim => ReportECBOnly.SqlCmdBoolSim() ?? string.Empty;
    public static string ReportECBOnlySqlNao => ReportECBOnly.SqlCmdBoolNao() ?? string.Empty;

    public static string ProBonoSql(bool valueCheck) => ProBono.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string ProBonoSqlSim => ProBono.SqlCmdBoolSim() ?? string.Empty;
    public static string ProBonoSqlNao => ProBono.SqlCmdBoolNao() ?? string.Empty;

    public static string CNHSql(string text) => CNH.SqlCmdTextIgual(text, 100) ?? string.Empty;
    public static string CNHSqlNotIsNull => CNH.SqlCmdNotIsNull() ?? string.Empty;
    public static string CNHSqlIsNull => CNH.SqlCmdIsNull() ?? string.Empty;

    public static string CNHSqlDiff(string text) => CNH.SqlCmdTextDiff(text) ?? string.Empty;
    public static string CNHSqlLike(string text) => CNH.SqlCmdTextLike(text) ?? string.Empty;
    public static string CNHSqlLikeInit(string text) => CNH.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string CNHSqlLikeSpaces(string? text) => CNH.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string PessoaContatoSql(string text) => PessoaContato.SqlCmdTextIgual(text, 120) ?? string.Empty;
    public static string PessoaContatoSqlNotIsNull => PessoaContato.SqlCmdNotIsNull() ?? string.Empty;
    public static string PessoaContatoSqlIsNull => PessoaContato.SqlCmdIsNull() ?? string.Empty;

    public static string PessoaContatoSqlDiff(string text) => PessoaContato.SqlCmdTextDiff(text) ?? string.Empty;
    public static string PessoaContatoSqlLike(string text) => PessoaContato.SqlCmdTextLike(text) ?? string.Empty;
    public static string PessoaContatoSqlLikeInit(string text) => PessoaContato.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string PessoaContatoSqlLikeSpaces(string? text) => PessoaContato.SqlCmdTextLikeSpaces(text) ?? string.Empty;
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
        CliEmpresa = 1,
        CliIcone = 2,
        CliNomeMae = 3,
        CliRGDataExp = 4,
        CliInativo = 5,
        CliQuemIndicou = 6,
        CliSendEMail = 7,
        CliNome = 8,
        CliAdv = 9,
        CliIDRep = 10,
        CliJuridica = 11,
        CliNomeFantasia = 12,
        CliClass = 13,
        CliTipo = 14,
        CliDtNasc = 15,
        CliInscEst = 16,
        CliQualificacao = 17,
        CliSexo = 18,
        CliIdade = 19,
        CliCNPJ = 20,
        CliCPF = 21,
        CliRG = 22,
        CliTipoCaptacao = 23,
        CliObservacao = 24,
        CliEndereco = 25,
        CliBairro = 26,
        CliCidade = 27,
        CliCEP = 28,
        CliFax = 29,
        CliFone = 30,
        CliData = 31,
        CliHomePage = 32,
        CliEMail = 33,
        CliObito = 34,
        CliNomePai = 35,
        CliRGOExpeditor = 36,
        CliRegimeTributacao = 37,
        CliEnquadramentoEmpresa = 38,
        CliReportECBOnly = 39,
        CliProBono = 40,
        CliCNH = 41,
        CliPessoaContato = 42,
        CliEtiqueta = 43,
        CliAni = 44,
        CliBold = 45,
        CliGUID = 46,
        CliQuemCad = 47,
        CliDtCad = 48,
        CliQuemAtu = 49,
        CliDtAtu = 50,
        CliVisto = 51
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.CliEmpresa => CliEmpresa,
        NomesCamposTabela.CliIcone => CliIcone,
        NomesCamposTabela.CliNomeMae => CliNomeMae,
        NomesCamposTabela.CliRGDataExp => CliRGDataExp,
        NomesCamposTabela.CliInativo => CliInativo,
        NomesCamposTabela.CliQuemIndicou => CliQuemIndicou,
        NomesCamposTabela.CliSendEMail => CliSendEMail,
        NomesCamposTabela.CliNome => CliNome,
        NomesCamposTabela.CliAdv => CliAdv,
        NomesCamposTabela.CliIDRep => CliIDRep,
        NomesCamposTabela.CliJuridica => CliJuridica,
        NomesCamposTabela.CliNomeFantasia => CliNomeFantasia,
        NomesCamposTabela.CliClass => CliClass,
        NomesCamposTabela.CliTipo => CliTipo,
        NomesCamposTabela.CliDtNasc => CliDtNasc,
        NomesCamposTabela.CliInscEst => CliInscEst,
        NomesCamposTabela.CliQualificacao => CliQualificacao,
        NomesCamposTabela.CliSexo => CliSexo,
        NomesCamposTabela.CliIdade => CliIdade,
        NomesCamposTabela.CliCNPJ => CliCNPJ,
        NomesCamposTabela.CliCPF => CliCPF,
        NomesCamposTabela.CliRG => CliRG,
        NomesCamposTabela.CliTipoCaptacao => CliTipoCaptacao,
        NomesCamposTabela.CliObservacao => CliObservacao,
        NomesCamposTabela.CliEndereco => CliEndereco,
        NomesCamposTabela.CliBairro => CliBairro,
        NomesCamposTabela.CliCidade => CliCidade,
        NomesCamposTabela.CliCEP => CliCEP,
        NomesCamposTabela.CliFax => CliFax,
        NomesCamposTabela.CliFone => CliFone,
        NomesCamposTabela.CliData => CliData,
        NomesCamposTabela.CliHomePage => CliHomePage,
        NomesCamposTabela.CliEMail => CliEMail,
        NomesCamposTabela.CliObito => CliObito,
        NomesCamposTabela.CliNomePai => CliNomePai,
        NomesCamposTabela.CliRGOExpeditor => CliRGOExpeditor,
        NomesCamposTabela.CliRegimeTributacao => CliRegimeTributacao,
        NomesCamposTabela.CliEnquadramentoEmpresa => CliEnquadramentoEmpresa,
        NomesCamposTabela.CliReportECBOnly => CliReportECBOnly,
        NomesCamposTabela.CliProBono => CliProBono,
        NomesCamposTabela.CliCNH => CliCNH,
        NomesCamposTabela.CliPessoaContato => CliPessoaContato,
        NomesCamposTabela.CliEtiqueta => CliEtiqueta,
        NomesCamposTabela.CliAni => CliAni,
        NomesCamposTabela.CliBold => CliBold,
        NomesCamposTabela.CliGUID => CliGUID,
        NomesCamposTabela.CliQuemCad => CliQuemCad,
        NomesCamposTabela.CliDtCad => CliDtCad,
        NomesCamposTabela.CliQuemAtu => CliQuemAtu,
        NomesCamposTabela.CliDtAtu => CliDtAtu,
        NomesCamposTabela.CliVisto => CliVisto,
        _ => null
    };
}