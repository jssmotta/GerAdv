using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public static partial class DBAdvogadosDicInfo
{
    public const string CampoCodigo = "advCodigo";
    public const string CampoNome = "advNome";
    public const string TablePrefix = "adv";
    public const string Cargo = "advCargo"; // LOCALIZACAO 170523
    public const string EMailPro = "advEMailPro"; // LOCALIZACAO 170523
    public const string CPF = "advCPF"; // LOCALIZACAO 170523
    public const string Nome = "advNome"; // LOCALIZACAO 170523
    public const string RG = "advRG"; // LOCALIZACAO 170523
    public const string Casa = "advCasa"; // LOCALIZACAO 170523
    public const string NomeMae = "advNomeMae"; // LOCALIZACAO 170523
    public const string Escritorio = "advEscritorio"; // LOCALIZACAO 170523
    public const string Estagiario = "advEstagiario"; // LOCALIZACAO 170523
    public const string OAB = "advOAB"; // LOCALIZACAO 170523
    public const string NomeCompleto = "advNomeCompleto"; // LOCALIZACAO 170523
    public const string Endereco = "advEndereco"; // LOCALIZACAO 170523
    public const string Cidade = "advCidade"; // LOCALIZACAO 170523
    public const string CEP = "advCEP"; // LOCALIZACAO 170523
    public const string Sexo = "advSexo"; // LOCALIZACAO 170523
    public const string Bairro = "advBairro"; // LOCALIZACAO 170523
    public const string CTPSSerie = "advCTPSSerie"; // LOCALIZACAO 170523
    public const string CTPS = "advCTPS"; // LOCALIZACAO 170523
    public const string Fone = "advFone"; // LOCALIZACAO 170523
    public const string Fax = "advFax"; // LOCALIZACAO 170523
    public const string Comissao = "advComissao"; // LOCALIZACAO 170523
    public const string DtInicio = "advDtInicio"; // LOCALIZACAO 170523
    public const string DtFim = "advDtFim"; // LOCALIZACAO 170523
    public const string DtNasc = "advDtNasc"; // LOCALIZACAO 170523
    public const string Salario = "advSalario"; // LOCALIZACAO 170523
    public const string Secretaria = "advSecretaria"; // LOCALIZACAO 170523
    public const string TextoProcuracao = "advTextoProcuracao"; // LOCALIZACAO 170523
    public const string EMail = "advEMail"; // LOCALIZACAO 170523
    public const string Especializacao = "advEspecializacao"; // LOCALIZACAO 170523
    public const string Pasta = "advPasta"; // LOCALIZACAO 170523
    public const string Observacao = "advObservacao"; // LOCALIZACAO 170523
    public const string ContaBancaria = "advContaBancaria"; // LOCALIZACAO 170523
    public const string ParcTop = "advParcTop"; // LOCALIZACAO 170523
    public const string Class = "advClass"; // LOCALIZACAO 170523
    public const string Top = "advTop"; // LOCALIZACAO 170523
    public const string Etiqueta = "advEtiqueta"; // LOCALIZACAO 170523
    public const string Ani = "advAni"; // LOCALIZACAO 170523
    public const string Bold = "advBold"; // LOCALIZACAO 170523
    public const string GUID = "advGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "advQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "advDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "advQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "advDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "advVisto"; // LOCALIZACAO 170523
    public static string CampoCodigoDiff(int id) => CampoCodigo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string CampoCodigoSql(int id) => CampoCodigo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string CampoCodigoIsNull => CampoCodigo.SqlCmdIsNull() ?? string.Empty;
    public static string CampoCodigoNotIsNull => CampoCodigo.SqlCmdNotIsNull() ?? string.Empty;

    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Cargo,
        2 => EMailPro,
        3 => CPF,
        4 => Nome,
        5 => RG,
        6 => Casa,
        7 => NomeMae,
        8 => Escritorio,
        9 => Estagiario,
        10 => OAB,
        11 => NomeCompleto,
        12 => Endereco,
        13 => Cidade,
        14 => CEP,
        15 => Sexo,
        16 => Bairro,
        17 => CTPSSerie,
        18 => CTPS,
        19 => Fone,
        20 => Fax,
        21 => Comissao,
        22 => DtInicio,
        23 => DtFim,
        24 => DtNasc,
        25 => Salario,
        26 => Secretaria,
        27 => TextoProcuracao,
        28 => EMail,
        29 => Especializacao,
        30 => Pasta,
        31 => Observacao,
        32 => ContaBancaria,
        33 => ParcTop,
        34 => Class,
        35 => Top,
        36 => Etiqueta,
        37 => Ani,
        38 => Bold,
        39 => GUID,
        40 => QuemCad,
        41 => DtCad,
        42 => QuemAtu,
        43 => DtAtu,
        44 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "Advogados";
#region PropriedadesDaTabela
    public static DBInfoSystem AdvCargo => new(0, PTabelaNome, CampoCodigo, Cargo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBCargosDicInfo.CampoCodigo, DBCargosDicInfo.TabelaNome, new DBCargosODicInfo(), false); // DBI 11 
    public static DBInfoSystem AdvEMailPro => new(0, PTabelaNome, CampoCodigo, EMailPro, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEmailPro, true, false, false);
    public static DBInfoSystem AdvCPF => new(0, PTabelaNome, CampoCodigo, CPF, 11, DevourerOne.PCpf, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCpf, true, false, false);
    public static DBInfoSystem AdvNome => new(0, PTabelaNome, CampoCodigo, Nome, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false);
    public static DBInfoSystem AdvRG => new(0, PTabelaNome, CampoCodigo, RG, 30, DevourerOne.PRg, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextRG, true, false, false);
    public static DBInfoSystem AdvCasa => new(0, PTabelaNome, CampoCodigo, Casa, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem AdvNomeMae => new(0, PTabelaNome, CampoCodigo, NomeMae, 80, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem AdvEscritorio => new(0, PTabelaNome, CampoCodigo, Escritorio, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBEscritoriosDicInfo.CampoCodigo, DBEscritoriosDicInfo.TabelaNome, new DBEscritoriosODicInfo(), false); // DBI 11 
    public static DBInfoSystem AdvEstagiario => new(0, PTabelaNome, CampoCodigo, Estagiario, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem AdvOAB => new(0, PTabelaNome, CampoCodigo, OAB, 12, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem AdvNomeCompleto => new(0, PTabelaNome, CampoCodigo, NomeCompleto, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem AdvEndereco => new(0, PTabelaNome, CampoCodigo, Endereco, 80, DevourerOne.PEndereco, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEndereco, true, false, false);
    public static DBInfoSystem AdvCidade => new(0, PTabelaNome, CampoCodigo, Cidade, Captions.PCaption_Cidade, Captions.PCaption_CidadeUFPais, ETipoDadosSysteminfo.SysteminfoForeingkeyCidade, "cidCodigo", "Cidade", new DBCidadeODicInfo(), false);
    public static DBInfoSystem AdvCEP => new(0, PTabelaNome, CampoCodigo, CEP, 10, DevourerOne.PCep, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCep, true, false, false);
    public static DBInfoSystem AdvSexo => new(0, PTabelaNome, CampoCodigo, Sexo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBooleanSexo);
    public static DBInfoSystem AdvBairro => new(0, PTabelaNome, CampoCodigo, Bairro, 50, DevourerOne.PBairro, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextBairro, true, false, false);
    public static DBInfoSystem AdvCTPSSerie => new(0, PTabelaNome, CampoCodigo, CTPSSerie, 10, DevourerOne.PNroSerieCtps, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCtpsserie, true, false, false);
    public static DBInfoSystem AdvCTPS => new(0, PTabelaNome, CampoCodigo, CTPS, 15, DevourerOne.PCarteiraTrabalhoNro, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCtps, true, false, false);
    public static DBInfoSystem AdvFone => new(0, PTabelaNome, CampoCodigo, Fone, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFone, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFone, true, false, false);
    public static DBInfoSystem AdvFax => new(0, PTabelaNome, CampoCodigo, Fax, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFax, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFax, true, false, false);
    public static DBInfoSystem AdvComissao => new(0, PTabelaNome, CampoCodigo, Comissao, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem AdvDtInicio => new(0, PTabelaNome, CampoCodigo, DtInicio, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDataInicio);
    public static DBInfoSystem AdvDtFim => new(0, PTabelaNome, CampoCodigo, DtFim, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDataTermino);
    public static DBInfoSystem AdvDtNasc => new(0, PTabelaNome, CampoCodigo, DtNasc, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDataNascimento);
    public static DBInfoSystem AdvSalario => new(0, PTabelaNome, CampoCodigo, Salario, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDoubleSalario);
    public static DBInfoSystem AdvSecretaria => new(0, PTabelaNome, CampoCodigo, Secretaria, 20, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem AdvTextoProcuracao => new(0, PTabelaNome, CampoCodigo, TextoProcuracao, 200, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem AdvEMail => new(0, PTabelaNome, CampoCodigo, EMail, 100, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEmail, true, false, false);
    public static DBInfoSystem AdvEspecializacao => new(0, PTabelaNome, CampoCodigo, Especializacao, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false);
    public static DBInfoSystem AdvPasta => new(0, PTabelaNome, CampoCodigo, Pasta, 200, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem AdvObservacao => new(0, PTabelaNome, CampoCodigo, Observacao, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemoObservacao, true, false, false);
    public static DBInfoSystem AdvContaBancaria => new(0, PTabelaNome, CampoCodigo, ContaBancaria, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false);
    public static DBInfoSystem AdvParcTop => new(0, PTabelaNome, CampoCodigo, ParcTop, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem AdvClass => new(0, PTabelaNome, CampoCodigo, Class, 1, DevourerOne.PClassificacao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextClassificacaoStar, true, false, false);
    public static DBInfoSystem AdvTop => new(0, PTabelaNome, CampoCodigo, Top, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem AdvEtiqueta => new(0, PTabelaNome, CampoCodigo, Etiqueta, DevourerOne.PCriarEtiqueta, DevourerOne.PTooltipEtiqueta, ETipoDadosSysteminfo.SysteminfoBooleanEtiqueta);
    public static DBInfoSystem AdvAni => new(0, PTabelaNome, CampoCodigo, Ani, DevourerOne.PCaptionFieldAniversario, DevourerOne.PTooltipAniversario, ETipoDadosSysteminfo.SysteminfoBooleanLembrarAniversario);
    public static DBInfoSystem AdvBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold);
    public static DBInfoSystem AdvGUID => new(0, PTabelaNome, CampoCodigo, GUID, 150, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false);
    public static DBInfoSystem AdvQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem AdvDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento);
    public static DBInfoSystem AdvQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem AdvDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao);
    public static DBInfoSystem AdvVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto);

#endregion
    public static bool IsThisTable(string nomeTabela) => nomeTabela.ToUpper().Equals(TabelaNome.ToUpper());
#region SMART_SQLServices 
    public static string CargoDiff(int id) => Cargo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string CargoSql(int id) => Cargo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string CargoIsNull => Cargo.SqlCmdIsNull() ?? string.Empty;
    public static string CargoNotIsNull => Cargo.SqlCmdNotIsNull() ?? string.Empty;

    public static string EMailProSql(string text) => EMailPro.SqlCmdTextIgual(text, 255) ?? string.Empty;
    public static string EMailProSqlNotIsNull => EMailPro.SqlCmdNotIsNull() ?? string.Empty;
    public static string EMailProSqlIsNull => EMailPro.SqlCmdIsNull() ?? string.Empty;

    public static string EMailProSqlDiff(string text) => EMailPro.SqlCmdTextDiff(text) ?? string.Empty;
    public static string EMailProSqlLike(string text) => EMailPro.SqlCmdTextLike(text) ?? string.Empty;
    public static string EMailProSqlLikeInit(string text) => EMailPro.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string EMailProSqlLikeSpaces(string? text) => EMailPro.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string CPFSql(string text) => CPF.SqlCmdTextIgual(text, 11) ?? string.Empty;
    public static string CPFSqlNotIsNull => CPF.SqlCmdNotIsNull() ?? string.Empty;
    public static string CPFSqlIsNull => CPF.SqlCmdIsNull() ?? string.Empty;

    public static string CPFSqlDiff(string text) => CPF.SqlCmdTextDiff(text) ?? string.Empty;
    public static string CPFSqlLike(string text) => CPF.SqlCmdTextLike(text) ?? string.Empty;
    public static string CPFSqlLikeInit(string text) => CPF.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string CPFSqlLikeSpaces(string? text) => CPF.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string NomeSql(string text) => Nome.SqlCmdTextIgual(text, 50) ?? string.Empty;
    public static string NomeSqlNotIsNull => Nome.SqlCmdNotIsNull() ?? string.Empty;
    public static string NomeSqlIsNull => Nome.SqlCmdIsNull() ?? string.Empty;

    public static string NomeSqlDiff(string text) => Nome.SqlCmdTextDiff(text) ?? string.Empty;
    public static string NomeSqlLike(string text) => Nome.SqlCmdTextLike(text) ?? string.Empty;
    public static string NomeSqlLikeInit(string text) => Nome.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string NomeSqlLikeSpaces(string? text) => Nome.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string RGSql(string text) => RG.SqlCmdTextIgual(text, 30) ?? string.Empty;
    public static string RGSqlNotIsNull => RG.SqlCmdNotIsNull() ?? string.Empty;
    public static string RGSqlIsNull => RG.SqlCmdIsNull() ?? string.Empty;

    public static string RGSqlDiff(string text) => RG.SqlCmdTextDiff(text) ?? string.Empty;
    public static string RGSqlLike(string text) => RG.SqlCmdTextLike(text) ?? string.Empty;
    public static string RGSqlLikeInit(string text) => RG.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string RGSqlLikeSpaces(string? text) => RG.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string CasaSql(bool valueCheck) => Casa.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string CasaSqlSim => Casa.SqlCmdBoolSim() ?? string.Empty;
    public static string CasaSqlNao => Casa.SqlCmdBoolNao() ?? string.Empty;

    public static string NomeMaeSql(string text) => NomeMae.SqlCmdTextIgual(text, 80) ?? string.Empty;
    public static string NomeMaeSqlNotIsNull => NomeMae.SqlCmdNotIsNull() ?? string.Empty;
    public static string NomeMaeSqlIsNull => NomeMae.SqlCmdIsNull() ?? string.Empty;

    public static string NomeMaeSqlDiff(string text) => NomeMae.SqlCmdTextDiff(text) ?? string.Empty;
    public static string NomeMaeSqlLike(string text) => NomeMae.SqlCmdTextLike(text) ?? string.Empty;
    public static string NomeMaeSqlLikeInit(string text) => NomeMae.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string NomeMaeSqlLikeSpaces(string? text) => NomeMae.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string EscritorioDiff(int id) => Escritorio.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string EscritorioSql(int id) => Escritorio.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string EscritorioIsNull => Escritorio.SqlCmdIsNull() ?? string.Empty;
    public static string EscritorioNotIsNull => Escritorio.SqlCmdNotIsNull() ?? string.Empty;

    public static string EstagiarioSql(bool valueCheck) => Estagiario.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string EstagiarioSqlSim => Estagiario.SqlCmdBoolSim() ?? string.Empty;
    public static string EstagiarioSqlNao => Estagiario.SqlCmdBoolNao() ?? string.Empty;

    public static string OABSql(string text) => OAB.SqlCmdTextIgual(text, 12) ?? string.Empty;
    public static string OABSqlNotIsNull => OAB.SqlCmdNotIsNull() ?? string.Empty;
    public static string OABSqlIsNull => OAB.SqlCmdIsNull() ?? string.Empty;

    public static string OABSqlDiff(string text) => OAB.SqlCmdTextDiff(text) ?? string.Empty;
    public static string OABSqlLike(string text) => OAB.SqlCmdTextLike(text) ?? string.Empty;
    public static string OABSqlLikeInit(string text) => OAB.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string OABSqlLikeSpaces(string? text) => OAB.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string NomeCompletoSql(string text) => NomeCompleto.SqlCmdTextIgual(text, 50) ?? string.Empty;
    public static string NomeCompletoSqlNotIsNull => NomeCompleto.SqlCmdNotIsNull() ?? string.Empty;
    public static string NomeCompletoSqlIsNull => NomeCompleto.SqlCmdIsNull() ?? string.Empty;

    public static string NomeCompletoSqlDiff(string text) => NomeCompleto.SqlCmdTextDiff(text) ?? string.Empty;
    public static string NomeCompletoSqlLike(string text) => NomeCompleto.SqlCmdTextLike(text) ?? string.Empty;
    public static string NomeCompletoSqlLikeInit(string text) => NomeCompleto.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string NomeCompletoSqlLikeSpaces(string? text) => NomeCompleto.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string EnderecoSql(string text) => Endereco.SqlCmdTextIgual(text, 80) ?? string.Empty;
    public static string EnderecoSqlNotIsNull => Endereco.SqlCmdNotIsNull() ?? string.Empty;
    public static string EnderecoSqlIsNull => Endereco.SqlCmdIsNull() ?? string.Empty;

    public static string EnderecoSqlDiff(string text) => Endereco.SqlCmdTextDiff(text) ?? string.Empty;
    public static string EnderecoSqlLike(string text) => Endereco.SqlCmdTextLike(text) ?? string.Empty;
    public static string EnderecoSqlLikeInit(string text) => Endereco.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string EnderecoSqlLikeSpaces(string? text) => Endereco.SqlCmdTextLikeSpaces(text) ?? string.Empty;
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
    public static string SexoSql(bool valueCheck) => Sexo.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string SexoSqlSim => Sexo.SqlCmdBoolSim() ?? string.Empty;
    public static string SexoSqlNao => Sexo.SqlCmdBoolNao() ?? string.Empty;

    public static string BairroSql(string text) => Bairro.SqlCmdTextIgual(text, 50) ?? string.Empty;
    public static string BairroSqlNotIsNull => Bairro.SqlCmdNotIsNull() ?? string.Empty;
    public static string BairroSqlIsNull => Bairro.SqlCmdIsNull() ?? string.Empty;

    public static string BairroSqlDiff(string text) => Bairro.SqlCmdTextDiff(text) ?? string.Empty;
    public static string BairroSqlLike(string text) => Bairro.SqlCmdTextLike(text) ?? string.Empty;
    public static string BairroSqlLikeInit(string text) => Bairro.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string BairroSqlLikeSpaces(string? text) => Bairro.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string CTPSSerieSql(string text) => CTPSSerie.SqlCmdTextIgual(text, 10) ?? string.Empty;
    public static string CTPSSerieSqlNotIsNull => CTPSSerie.SqlCmdNotIsNull() ?? string.Empty;
    public static string CTPSSerieSqlIsNull => CTPSSerie.SqlCmdIsNull() ?? string.Empty;

    public static string CTPSSerieSqlDiff(string text) => CTPSSerie.SqlCmdTextDiff(text) ?? string.Empty;
    public static string CTPSSerieSqlLike(string text) => CTPSSerie.SqlCmdTextLike(text) ?? string.Empty;
    public static string CTPSSerieSqlLikeInit(string text) => CTPSSerie.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string CTPSSerieSqlLikeSpaces(string? text) => CTPSSerie.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string CTPSSql(string text) => CTPS.SqlCmdTextIgual(text, 15) ?? string.Empty;
    public static string CTPSSqlNotIsNull => CTPS.SqlCmdNotIsNull() ?? string.Empty;
    public static string CTPSSqlIsNull => CTPS.SqlCmdIsNull() ?? string.Empty;

    public static string CTPSSqlDiff(string text) => CTPS.SqlCmdTextDiff(text) ?? string.Empty;
    public static string CTPSSqlLike(string text) => CTPS.SqlCmdTextLike(text) ?? string.Empty;
    public static string CTPSSqlLikeInit(string text) => CTPS.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string CTPSSqlLikeSpaces(string? text) => CTPS.SqlCmdTextLikeSpaces(text) ?? string.Empty;
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
    public static string ComissaoDiff(int id) => Comissao.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string ComissaoSql(int id) => Comissao.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string ComissaoIsNull => Comissao.SqlCmdIsNull() ?? string.Empty;
    public static string ComissaoNotIsNull => Comissao.SqlCmdNotIsNull() ?? string.Empty;

    public static string DtInicioSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{DtInicio}]");
    public static string DtInicioSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{DtInicio}]");
    public static string DtInicioSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{DtInicio}]");
    public static string DtInicioSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{DtInicio}]");
    public static string DtInicioSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{DtInicio}]");
    public static string DtInicioSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{DtInicio}]");
    public static string DtInicioSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{DtInicio}]");
    public static string DtInicioSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{DtInicio}]");
    public static string DtInicioSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{DtInicio}]");
    public static string DtInicioSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{DtInicio}]");
    public static string DtInicioSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{DtInicio}]");
    public static string DtInicioSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{DtInicio}]");
    public static string DtInicioIsNull => DtInicio.SqlCmdIsNull() ?? string.Empty;
    public static string DtInicioNotIsNull => DtInicio.SqlCmdNotIsNull() ?? string.Empty;

    public static string DtFimSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{DtFim}]");
    public static string DtFimSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{DtFim}]");
    public static string DtFimSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{DtFim}]");
    public static string DtFimSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{DtFim}]");
    public static string DtFimSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{DtFim}]");
    public static string DtFimSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{DtFim}]");
    public static string DtFimSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{DtFim}]");
    public static string DtFimSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{DtFim}]");
    public static string DtFimSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{DtFim}]");
    public static string DtFimSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{DtFim}]");
    public static string DtFimSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{DtFim}]");
    public static string DtFimSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{DtFim}]");
    public static string DtFimIsNull => DtFim.SqlCmdIsNull() ?? string.Empty;
    public static string DtFimNotIsNull => DtFim.SqlCmdNotIsNull() ?? string.Empty;

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

    public static string SecretariaSql(string text) => Secretaria.SqlCmdTextIgual(text, 20) ?? string.Empty;
    public static string SecretariaSqlNotIsNull => Secretaria.SqlCmdNotIsNull() ?? string.Empty;
    public static string SecretariaSqlIsNull => Secretaria.SqlCmdIsNull() ?? string.Empty;

    public static string SecretariaSqlDiff(string text) => Secretaria.SqlCmdTextDiff(text) ?? string.Empty;
    public static string SecretariaSqlLike(string text) => Secretaria.SqlCmdTextLike(text) ?? string.Empty;
    public static string SecretariaSqlLikeInit(string text) => Secretaria.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string SecretariaSqlLikeSpaces(string? text) => Secretaria.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string TextoProcuracaoSql(string text) => TextoProcuracao.SqlCmdTextIgual(text, 200) ?? string.Empty;
    public static string TextoProcuracaoSqlNotIsNull => TextoProcuracao.SqlCmdNotIsNull() ?? string.Empty;
    public static string TextoProcuracaoSqlIsNull => TextoProcuracao.SqlCmdIsNull() ?? string.Empty;

    public static string TextoProcuracaoSqlDiff(string text) => TextoProcuracao.SqlCmdTextDiff(text) ?? string.Empty;
    public static string TextoProcuracaoSqlLike(string text) => TextoProcuracao.SqlCmdTextLike(text) ?? string.Empty;
    public static string TextoProcuracaoSqlLikeInit(string text) => TextoProcuracao.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string TextoProcuracaoSqlLikeSpaces(string? text) => TextoProcuracao.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string EMailSql(string text) => EMail.SqlCmdTextIgual(text, 100) ?? string.Empty;
    public static string EMailSqlNotIsNull => EMail.SqlCmdNotIsNull() ?? string.Empty;
    public static string EMailSqlIsNull => EMail.SqlCmdIsNull() ?? string.Empty;

    public static string EMailSqlDiff(string text) => EMail.SqlCmdTextDiff(text) ?? string.Empty;
    public static string EMailSqlLike(string text) => EMail.SqlCmdTextLike(text) ?? string.Empty;
    public static string EMailSqlLikeInit(string text) => EMail.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string EMailSqlLikeSpaces(string? text) => EMail.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string EspecializacaoSql(string text) => Especializacao.SqlCmdTextIgual(text) ?? string.Empty;
    public static string EspecializacaoSqlNotIsNull => Especializacao.SqlCmdNotIsNull() ?? string.Empty;
    public static string EspecializacaoSqlIsNull => Especializacao.SqlCmdIsNull() ?? string.Empty;

    public static string EspecializacaoSqlDiff(string text) => Especializacao.SqlCmdTextDiff(text) ?? string.Empty;
    public static string EspecializacaoSqlLike(string text) => Especializacao.SqlCmdTextLike(text) ?? string.Empty;
    public static string EspecializacaoSqlLikeInit(string text) => Especializacao.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string EspecializacaoSqlLikeSpaces(string? text) => Especializacao.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string PastaSql(string text) => Pasta.SqlCmdTextIgual(text, 200) ?? string.Empty;
    public static string PastaSqlNotIsNull => Pasta.SqlCmdNotIsNull() ?? string.Empty;
    public static string PastaSqlIsNull => Pasta.SqlCmdIsNull() ?? string.Empty;

    public static string PastaSqlDiff(string text) => Pasta.SqlCmdTextDiff(text) ?? string.Empty;
    public static string PastaSqlLike(string text) => Pasta.SqlCmdTextLike(text) ?? string.Empty;
    public static string PastaSqlLikeInit(string text) => Pasta.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string PastaSqlLikeSpaces(string? text) => Pasta.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string ObservacaoSql(string text) => Observacao.SqlCmdTextIgual(text) ?? string.Empty;
    public static string ObservacaoSqlNotIsNull => Observacao.SqlCmdNotIsNull() ?? string.Empty;
    public static string ObservacaoSqlIsNull => Observacao.SqlCmdIsNull() ?? string.Empty;

    public static string ObservacaoSqlDiff(string text) => Observacao.SqlCmdTextDiff(text) ?? string.Empty;
    public static string ObservacaoSqlLike(string text) => Observacao.SqlCmdTextLike(text) ?? string.Empty;
    public static string ObservacaoSqlLikeInit(string text) => Observacao.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string ObservacaoSqlLikeSpaces(string? text) => Observacao.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string ContaBancariaSql(string text) => ContaBancaria.SqlCmdTextIgual(text) ?? string.Empty;
    public static string ContaBancariaSqlNotIsNull => ContaBancaria.SqlCmdNotIsNull() ?? string.Empty;
    public static string ContaBancariaSqlIsNull => ContaBancaria.SqlCmdIsNull() ?? string.Empty;

    public static string ContaBancariaSqlDiff(string text) => ContaBancaria.SqlCmdTextDiff(text) ?? string.Empty;
    public static string ContaBancariaSqlLike(string text) => ContaBancaria.SqlCmdTextLike(text) ?? string.Empty;
    public static string ContaBancariaSqlLikeInit(string text) => ContaBancaria.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string ContaBancariaSqlLikeSpaces(string? text) => ContaBancaria.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string ParcTopSql(bool valueCheck) => ParcTop.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string ParcTopSqlSim => ParcTop.SqlCmdBoolSim() ?? string.Empty;
    public static string ParcTopSqlNao => ParcTop.SqlCmdBoolNao() ?? string.Empty;

    public static string ClassSql(string text) => Class.SqlCmdTextIgual(text, 1) ?? string.Empty;
    public static string ClassSqlNotIsNull => Class.SqlCmdNotIsNull() ?? string.Empty;
    public static string ClassSqlIsNull => Class.SqlCmdIsNull() ?? string.Empty;

    public static string ClassSqlDiff(string text) => Class.SqlCmdTextDiff(text) ?? string.Empty;
    public static string ClassSqlLike(string text) => Class.SqlCmdTextLike(text) ?? string.Empty;
    public static string ClassSqlLikeInit(string text) => Class.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string ClassSqlLikeSpaces(string? text) => Class.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string TopSql(bool valueCheck) => Top.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string TopSqlSim => Top.SqlCmdBoolSim() ?? string.Empty;
    public static string TopSqlNao => Top.SqlCmdBoolNao() ?? string.Empty;

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
        AdvCargo = 1,
        AdvEMailPro = 2,
        AdvCPF = 3,
        AdvNome = 4,
        AdvRG = 5,
        AdvCasa = 6,
        AdvNomeMae = 7,
        AdvEscritorio = 8,
        AdvEstagiario = 9,
        AdvOAB = 10,
        AdvNomeCompleto = 11,
        AdvEndereco = 12,
        AdvCidade = 13,
        AdvCEP = 14,
        AdvSexo = 15,
        AdvBairro = 16,
        AdvCTPSSerie = 17,
        AdvCTPS = 18,
        AdvFone = 19,
        AdvFax = 20,
        AdvComissao = 21,
        AdvDtInicio = 22,
        AdvDtFim = 23,
        AdvDtNasc = 24,
        AdvSalario = 25,
        AdvSecretaria = 26,
        AdvTextoProcuracao = 27,
        AdvEMail = 28,
        AdvEspecializacao = 29,
        AdvPasta = 30,
        AdvObservacao = 31,
        AdvContaBancaria = 32,
        AdvParcTop = 33,
        AdvClass = 34,
        AdvTop = 35,
        AdvEtiqueta = 36,
        AdvAni = 37,
        AdvBold = 38,
        AdvGUID = 39,
        AdvQuemCad = 40,
        AdvDtCad = 41,
        AdvQuemAtu = 42,
        AdvDtAtu = 43,
        AdvVisto = 44
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.AdvCargo => AdvCargo,
        NomesCamposTabela.AdvEMailPro => AdvEMailPro,
        NomesCamposTabela.AdvCPF => AdvCPF,
        NomesCamposTabela.AdvNome => AdvNome,
        NomesCamposTabela.AdvRG => AdvRG,
        NomesCamposTabela.AdvCasa => AdvCasa,
        NomesCamposTabela.AdvNomeMae => AdvNomeMae,
        NomesCamposTabela.AdvEscritorio => AdvEscritorio,
        NomesCamposTabela.AdvEstagiario => AdvEstagiario,
        NomesCamposTabela.AdvOAB => AdvOAB,
        NomesCamposTabela.AdvNomeCompleto => AdvNomeCompleto,
        NomesCamposTabela.AdvEndereco => AdvEndereco,
        NomesCamposTabela.AdvCidade => AdvCidade,
        NomesCamposTabela.AdvCEP => AdvCEP,
        NomesCamposTabela.AdvSexo => AdvSexo,
        NomesCamposTabela.AdvBairro => AdvBairro,
        NomesCamposTabela.AdvCTPSSerie => AdvCTPSSerie,
        NomesCamposTabela.AdvCTPS => AdvCTPS,
        NomesCamposTabela.AdvFone => AdvFone,
        NomesCamposTabela.AdvFax => AdvFax,
        NomesCamposTabela.AdvComissao => AdvComissao,
        NomesCamposTabela.AdvDtInicio => AdvDtInicio,
        NomesCamposTabela.AdvDtFim => AdvDtFim,
        NomesCamposTabela.AdvDtNasc => AdvDtNasc,
        NomesCamposTabela.AdvSalario => AdvSalario,
        NomesCamposTabela.AdvSecretaria => AdvSecretaria,
        NomesCamposTabela.AdvTextoProcuracao => AdvTextoProcuracao,
        NomesCamposTabela.AdvEMail => AdvEMail,
        NomesCamposTabela.AdvEspecializacao => AdvEspecializacao,
        NomesCamposTabela.AdvPasta => AdvPasta,
        NomesCamposTabela.AdvObservacao => AdvObservacao,
        NomesCamposTabela.AdvContaBancaria => AdvContaBancaria,
        NomesCamposTabela.AdvParcTop => AdvParcTop,
        NomesCamposTabela.AdvClass => AdvClass,
        NomesCamposTabela.AdvTop => AdvTop,
        NomesCamposTabela.AdvEtiqueta => AdvEtiqueta,
        NomesCamposTabela.AdvAni => AdvAni,
        NomesCamposTabela.AdvBold => AdvBold,
        NomesCamposTabela.AdvGUID => AdvGUID,
        NomesCamposTabela.AdvQuemCad => AdvQuemCad,
        NomesCamposTabela.AdvDtCad => AdvDtCad,
        NomesCamposTabela.AdvQuemAtu => AdvQuemAtu,
        NomesCamposTabela.AdvDtAtu => AdvDtAtu,
        NomesCamposTabela.AdvVisto => AdvVisto,
        _ => null
    };
}