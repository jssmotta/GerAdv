using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public static partial class DBClientesSociosDicInfo
{
    public const string CampoCodigo = "cscCodigo";
    public const string CampoNome = "cscNome";
    public const string TablePrefix = "csc";
    public const string SomenteRepresentante = "cscSomenteRepresentante"; // LOCALIZACAO 170523
    public const string Idade = "cscIdade"; // LOCALIZACAO 170523
    public const string IsRepresentanteLegal = "cscIsRepresentanteLegal"; // LOCALIZACAO 170523
    public const string Qualificacao = "cscQualificacao"; // LOCALIZACAO 170523
    public const string Sexo = "cscSexo"; // LOCALIZACAO 170523
    public const string DtNasc = "cscDtNasc"; // LOCALIZACAO 170523
    public const string Nome = "cscNome"; // LOCALIZACAO 170523
    public const string Site = "cscSite"; // LOCALIZACAO 170523
    public const string RepresentanteLegal = "cscRepresentanteLegal"; // LOCALIZACAO 170523
    public const string Cliente = "cscCliente"; // LOCALIZACAO 170523
    public const string Endereco = "cscEndereco"; // LOCALIZACAO 170523
    public const string Bairro = "cscBairro"; // LOCALIZACAO 170523
    public const string CEP = "cscCEP"; // LOCALIZACAO 170523
    public const string Cidade = "cscCidade"; // LOCALIZACAO 170523
    public const string RG = "cscRG"; // LOCALIZACAO 170523
    public const string CPF = "cscCPF"; // LOCALIZACAO 170523
    public const string Fone = "cscFone"; // LOCALIZACAO 170523
    public const string Participacao = "cscParticipacao"; // LOCALIZACAO 170523
    public const string Cargo = "cscCargo"; // LOCALIZACAO 170523
    public const string EMail = "cscEMail"; // LOCALIZACAO 170523
    public const string Obs = "cscObs"; // LOCALIZACAO 170523
    public const string CNH = "cscCNH"; // LOCALIZACAO 170523
    public const string DataContrato = "cscDataContrato"; // LOCALIZACAO 170523
    public const string CNPJ = "cscCNPJ"; // LOCALIZACAO 170523
    public const string InscEst = "cscInscEst"; // LOCALIZACAO 170523
    public const string SocioEmpresaAdminNome = "cscSocioEmpresaAdminNome"; // LOCALIZACAO 170523
    public const string EnderecoSocio = "cscEnderecoSocio"; // LOCALIZACAO 170523
    public const string BairroSocio = "cscBairroSocio"; // LOCALIZACAO 170523
    public const string CEPSocio = "cscCEPSocio"; // LOCALIZACAO 170523
    public const string CidadeSocio = "cscCidadeSocio"; // LOCALIZACAO 170523
    public const string RGDataExp = "cscRGDataExp"; // LOCALIZACAO 170523
    public const string SocioEmpresaAdminSomente = "cscSocioEmpresaAdminSomente"; // LOCALIZACAO 170523
    public const string Tipo = "cscTipo"; // LOCALIZACAO 170523
    public const string Fax = "cscFax"; // LOCALIZACAO 170523
    public const string Class = "cscClass"; // LOCALIZACAO 170523
    public const string Etiqueta = "cscEtiqueta"; // LOCALIZACAO 170523
    public const string Ani = "cscAni"; // LOCALIZACAO 170523
    public const string Bold = "cscBold"; // LOCALIZACAO 170523
    public const string GUID = "cscGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "cscQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "cscDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "cscQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "cscDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "cscVisto"; // LOCALIZACAO 170523
    public static string CampoCodigoDiff(int id) => CampoCodigo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string CampoCodigoSql(int id) => CampoCodigo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string CampoCodigoIsNull => CampoCodigo.SqlCmdIsNull() ?? string.Empty;
    public static string CampoCodigoNotIsNull => CampoCodigo.SqlCmdNotIsNull() ?? string.Empty;

    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => SomenteRepresentante,
        2 => Idade,
        3 => IsRepresentanteLegal,
        4 => Qualificacao,
        5 => Sexo,
        6 => DtNasc,
        7 => Nome,
        8 => Site,
        9 => RepresentanteLegal,
        10 => Cliente,
        11 => Endereco,
        12 => Bairro,
        13 => CEP,
        14 => Cidade,
        15 => RG,
        16 => CPF,
        17 => Fone,
        18 => Participacao,
        19 => Cargo,
        20 => EMail,
        21 => Obs,
        22 => CNH,
        23 => DataContrato,
        24 => CNPJ,
        25 => InscEst,
        26 => SocioEmpresaAdminNome,
        27 => EnderecoSocio,
        28 => BairroSocio,
        29 => CEPSocio,
        30 => CidadeSocio,
        31 => RGDataExp,
        32 => SocioEmpresaAdminSomente,
        33 => Tipo,
        34 => Fax,
        35 => Class,
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

    public const string PTabelaNome = "ClientesSocios";
#region PropriedadesDaTabela
    public static DBInfoSystem CscSomenteRepresentante => new(0, PTabelaNome, CampoCodigo, SomenteRepresentante, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem CscIdade => new(0, PTabelaNome, CampoCodigo, Idade, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem CscIsRepresentanteLegal => new(0, PTabelaNome, CampoCodigo, IsRepresentanteLegal, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem CscQualificacao => new(0, PTabelaNome, CampoCodigo, Qualificacao, 100, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem CscSexo => new(0, PTabelaNome, CampoCodigo, Sexo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBooleanSexo);
    public static DBInfoSystem CscDtNasc => new(0, PTabelaNome, CampoCodigo, DtNasc, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDataNascimento);
    public static DBInfoSystem CscNome => new(0, PTabelaNome, CampoCodigo, Nome, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false);
    public static DBInfoSystem CscSite => new(0, PTabelaNome, CampoCodigo, Site, 150, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextWebsite, true, false, false);
    public static DBInfoSystem CscRepresentanteLegal => new(0, PTabelaNome, CampoCodigo, RepresentanteLegal, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem CscCliente => new(0, PTabelaNome, CampoCodigo, Cliente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBClientesDicInfo.CampoCodigo, DBClientesDicInfo.TabelaNome, new DBClientesODicInfo(), false); // DBI 11 
    public static DBInfoSystem CscEndereco => new(0, PTabelaNome, CampoCodigo, Endereco, 80, DevourerOne.PEndereco, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEndereco, true, false, false);
    public static DBInfoSystem CscBairro => new(0, PTabelaNome, CampoCodigo, Bairro, 50, DevourerOne.PBairro, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextBairro, true, false, false);
    public static DBInfoSystem CscCEP => new(0, PTabelaNome, CampoCodigo, CEP, 10, DevourerOne.PCep, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCep, true, false, false);
    public static DBInfoSystem CscCidade => new(0, PTabelaNome, CampoCodigo, Cidade, Captions.PCaption_Cidade, Captions.PCaption_CidadeUFPais, ETipoDadosSysteminfo.SysteminfoForeingkeyCidade, "cidCodigo", "Cidade", new DBCidadeODicInfo(), false);
    public static DBInfoSystem CscRG => new(0, PTabelaNome, CampoCodigo, RG, 30, DevourerOne.PRg, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextRG, true, false, false);
    public static DBInfoSystem CscCPF => new(0, PTabelaNome, CampoCodigo, CPF, 11, DevourerOne.PCpf, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCpf, true, false, false);
    public static DBInfoSystem CscFone => new(0, PTabelaNome, CampoCodigo, Fone, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFone, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFone, true, false, false);
    public static DBInfoSystem CscParticipacao => new(0, PTabelaNome, CampoCodigo, Participacao, 10, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem CscCargo => new(0, PTabelaNome, CampoCodigo, Cargo, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem CscEMail => new(0, PTabelaNome, CampoCodigo, EMail, 60, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEmail, true, false, false);
    public static DBInfoSystem CscObs => new(0, PTabelaNome, CampoCodigo, Obs, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemoObservacao, true, false, false);
    public static DBInfoSystem CscCNH => new(0, PTabelaNome, CampoCodigo, CNH, 100, DevourerOne.PCnh, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCnh, true, false, false);
    public static DBInfoSystem CscDataContrato => new(0, PTabelaNome, CampoCodigo, DataContrato, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem CscCNPJ => new(0, PTabelaNome, CampoCodigo, CNPJ, 14, DevourerOne.PCnpj, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCnpj, true, false, false);
    public static DBInfoSystem CscInscEst => new(0, PTabelaNome, CampoCodigo, InscEst, 15, DevourerOne.PInscricaoEstadual, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextInscricao, true, false, false);
    public static DBInfoSystem CscSocioEmpresaAdminNome => new(0, PTabelaNome, CampoCodigo, SocioEmpresaAdminNome, 80, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem CscEnderecoSocio => new(0, PTabelaNome, CampoCodigo, EnderecoSocio, 80, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem CscBairroSocio => new(0, PTabelaNome, CampoCodigo, BairroSocio, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem CscCEPSocio => new(0, PTabelaNome, CampoCodigo, CEPSocio, 10, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem CscCidadeSocio => new(0, PTabelaNome, CampoCodigo, CidadeSocio, Captions.PCaption_Cidade, Captions.PCaption_CidadeUFPais, ETipoDadosSysteminfo.SysteminfoForeingkeyCidade, "cidCodigo", "Cidade", new DBCidadeODicInfo(), false);
    public static DBInfoSystem CscRGDataExp => new(0, PTabelaNome, CampoCodigo, RGDataExp, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem CscSocioEmpresaAdminSomente => new(0, PTabelaNome, CampoCodigo, SocioEmpresaAdminSomente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem CscTipo => new(0, PTabelaNome, CampoCodigo, Tipo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBooleanTipoPessoa);
    public static DBInfoSystem CscFax => new(0, PTabelaNome, CampoCodigo, Fax, 2048, DevourerOne.PFax, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFax, true, false, false);
    public static DBInfoSystem CscClass => new(0, PTabelaNome, CampoCodigo, Class, 1, DevourerOne.PClassificacao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextClassificacaoStar, true, false, false);
    public static DBInfoSystem CscEtiqueta => new(0, PTabelaNome, CampoCodigo, Etiqueta, DevourerOne.PCriarEtiqueta, DevourerOne.PTooltipEtiqueta, ETipoDadosSysteminfo.SysteminfoBooleanEtiqueta);
    public static DBInfoSystem CscAni => new(0, PTabelaNome, CampoCodigo, Ani, DevourerOne.PCaptionFieldAniversario, DevourerOne.PTooltipAniversario, ETipoDadosSysteminfo.SysteminfoBooleanLembrarAniversario);
    public static DBInfoSystem CscBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold);
    public static DBInfoSystem CscGUID => new(0, PTabelaNome, CampoCodigo, GUID, 150, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false);
    public static DBInfoSystem CscQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem CscDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento);
    public static DBInfoSystem CscQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem CscDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao);
    public static DBInfoSystem CscVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto);

#endregion
    public static bool IsThisTable(string nomeTabela) => nomeTabela.ToUpper().Equals(TabelaNome.ToUpper());
#region SMART_SQLServices 
    public static string SomenteRepresentanteSql(bool valueCheck) => SomenteRepresentante.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string SomenteRepresentanteSqlSim => SomenteRepresentante.SqlCmdBoolSim() ?? string.Empty;
    public static string SomenteRepresentanteSqlNao => SomenteRepresentante.SqlCmdBoolNao() ?? string.Empty;

    public static string IdadeDiff(int id) => Idade.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string IdadeSql(int id) => Idade.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string IdadeIsNull => Idade.SqlCmdIsNull() ?? string.Empty;
    public static string IdadeNotIsNull => Idade.SqlCmdNotIsNull() ?? string.Empty;

    public static string IsRepresentanteLegalSql(bool valueCheck) => IsRepresentanteLegal.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string IsRepresentanteLegalSqlSim => IsRepresentanteLegal.SqlCmdBoolSim() ?? string.Empty;
    public static string IsRepresentanteLegalSqlNao => IsRepresentanteLegal.SqlCmdBoolNao() ?? string.Empty;

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

    public static string NomeSql(string text) => Nome.SqlCmdTextIgual(text, 50) ?? string.Empty;
    public static string NomeSqlNotIsNull => Nome.SqlCmdNotIsNull() ?? string.Empty;
    public static string NomeSqlIsNull => Nome.SqlCmdIsNull() ?? string.Empty;

    public static string NomeSqlDiff(string text) => Nome.SqlCmdTextDiff(text) ?? string.Empty;
    public static string NomeSqlLike(string text) => Nome.SqlCmdTextLike(text) ?? string.Empty;
    public static string NomeSqlLikeInit(string text) => Nome.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string NomeSqlLikeSpaces(string? text) => Nome.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string SiteSql(string text) => Site.SqlCmdTextIgual(text, 150) ?? string.Empty;
    public static string SiteSqlNotIsNull => Site.SqlCmdNotIsNull() ?? string.Empty;
    public static string SiteSqlIsNull => Site.SqlCmdIsNull() ?? string.Empty;

    public static string SiteSqlDiff(string text) => Site.SqlCmdTextDiff(text) ?? string.Empty;
    public static string SiteSqlLike(string text) => Site.SqlCmdTextLike(text) ?? string.Empty;
    public static string SiteSqlLikeInit(string text) => Site.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string SiteSqlLikeSpaces(string? text) => Site.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string RepresentanteLegalSql(string text) => RepresentanteLegal.SqlCmdTextIgual(text, 50) ?? string.Empty;
    public static string RepresentanteLegalSqlNotIsNull => RepresentanteLegal.SqlCmdNotIsNull() ?? string.Empty;
    public static string RepresentanteLegalSqlIsNull => RepresentanteLegal.SqlCmdIsNull() ?? string.Empty;

    public static string RepresentanteLegalSqlDiff(string text) => RepresentanteLegal.SqlCmdTextDiff(text) ?? string.Empty;
    public static string RepresentanteLegalSqlLike(string text) => RepresentanteLegal.SqlCmdTextLike(text) ?? string.Empty;
    public static string RepresentanteLegalSqlLikeInit(string text) => RepresentanteLegal.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string RepresentanteLegalSqlLikeSpaces(string? text) => RepresentanteLegal.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string ClienteDiff(int id) => Cliente.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string ClienteSql(int id) => Cliente.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string ClienteIsNull => Cliente.SqlCmdIsNull() ?? string.Empty;
    public static string ClienteNotIsNull => Cliente.SqlCmdNotIsNull() ?? string.Empty;

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
    public static string CEPSql(string text) => CEP.SqlCmdTextIgual(text, 10) ?? string.Empty;
    public static string CEPSqlNotIsNull => CEP.SqlCmdNotIsNull() ?? string.Empty;
    public static string CEPSqlIsNull => CEP.SqlCmdIsNull() ?? string.Empty;

    public static string CEPSqlDiff(string text) => CEP.SqlCmdTextDiff(text) ?? string.Empty;
    public static string CEPSqlLike(string text) => CEP.SqlCmdTextLike(text) ?? string.Empty;
    public static string CEPSqlLikeInit(string text) => CEP.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string CEPSqlLikeSpaces(string? text) => CEP.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string CidadeDiff(int id) => Cidade.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string CidadeSql(int id) => Cidade.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string CidadeIsNull => Cidade.SqlCmdIsNull() ?? string.Empty;
    public static string CidadeNotIsNull => Cidade.SqlCmdNotIsNull() ?? string.Empty;

    public static string RGSql(string text) => RG.SqlCmdTextIgual(text, 30) ?? string.Empty;
    public static string RGSqlNotIsNull => RG.SqlCmdNotIsNull() ?? string.Empty;
    public static string RGSqlIsNull => RG.SqlCmdIsNull() ?? string.Empty;

    public static string RGSqlDiff(string text) => RG.SqlCmdTextDiff(text) ?? string.Empty;
    public static string RGSqlLike(string text) => RG.SqlCmdTextLike(text) ?? string.Empty;
    public static string RGSqlLikeInit(string text) => RG.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string RGSqlLikeSpaces(string? text) => RG.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string CPFSql(string text) => CPF.SqlCmdTextIgual(text, 11) ?? string.Empty;
    public static string CPFSqlNotIsNull => CPF.SqlCmdNotIsNull() ?? string.Empty;
    public static string CPFSqlIsNull => CPF.SqlCmdIsNull() ?? string.Empty;

    public static string CPFSqlDiff(string text) => CPF.SqlCmdTextDiff(text) ?? string.Empty;
    public static string CPFSqlLike(string text) => CPF.SqlCmdTextLike(text) ?? string.Empty;
    public static string CPFSqlLikeInit(string text) => CPF.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string CPFSqlLikeSpaces(string? text) => CPF.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string FoneSql(string text) => Fone.SqlCmdTextIgual(text) ?? string.Empty;
    public static string FoneSqlNotIsNull => Fone.SqlCmdNotIsNull() ?? string.Empty;
    public static string FoneSqlIsNull => Fone.SqlCmdIsNull() ?? string.Empty;

    public static string FoneSqlDiff(string text) => Fone.SqlCmdTextDiff(text) ?? string.Empty;
    public static string FoneSqlLike(string text) => Fone.SqlCmdTextLike(text) ?? string.Empty;
    public static string FoneSqlLikeInit(string text) => Fone.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string FoneSqlLikeSpaces(string? text) => Fone.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string ParticipacaoSql(string text) => Participacao.SqlCmdTextIgual(text, 10) ?? string.Empty;
    public static string ParticipacaoSqlNotIsNull => Participacao.SqlCmdNotIsNull() ?? string.Empty;
    public static string ParticipacaoSqlIsNull => Participacao.SqlCmdIsNull() ?? string.Empty;

    public static string ParticipacaoSqlDiff(string text) => Participacao.SqlCmdTextDiff(text) ?? string.Empty;
    public static string ParticipacaoSqlLike(string text) => Participacao.SqlCmdTextLike(text) ?? string.Empty;
    public static string ParticipacaoSqlLikeInit(string text) => Participacao.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string ParticipacaoSqlLikeSpaces(string? text) => Participacao.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string CargoSql(string text) => Cargo.SqlCmdTextIgual(text, 50) ?? string.Empty;
    public static string CargoSqlNotIsNull => Cargo.SqlCmdNotIsNull() ?? string.Empty;
    public static string CargoSqlIsNull => Cargo.SqlCmdIsNull() ?? string.Empty;

    public static string CargoSqlDiff(string text) => Cargo.SqlCmdTextDiff(text) ?? string.Empty;
    public static string CargoSqlLike(string text) => Cargo.SqlCmdTextLike(text) ?? string.Empty;
    public static string CargoSqlLikeInit(string text) => Cargo.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string CargoSqlLikeSpaces(string? text) => Cargo.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string EMailSql(string text) => EMail.SqlCmdTextIgual(text, 60) ?? string.Empty;
    public static string EMailSqlNotIsNull => EMail.SqlCmdNotIsNull() ?? string.Empty;
    public static string EMailSqlIsNull => EMail.SqlCmdIsNull() ?? string.Empty;

    public static string EMailSqlDiff(string text) => EMail.SqlCmdTextDiff(text) ?? string.Empty;
    public static string EMailSqlLike(string text) => EMail.SqlCmdTextLike(text) ?? string.Empty;
    public static string EMailSqlLikeInit(string text) => EMail.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string EMailSqlLikeSpaces(string? text) => EMail.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string ObsSql(string text) => Obs.SqlCmdTextIgual(text) ?? string.Empty;
    public static string ObsSqlNotIsNull => Obs.SqlCmdNotIsNull() ?? string.Empty;
    public static string ObsSqlIsNull => Obs.SqlCmdIsNull() ?? string.Empty;

    public static string ObsSqlDiff(string text) => Obs.SqlCmdTextDiff(text) ?? string.Empty;
    public static string ObsSqlLike(string text) => Obs.SqlCmdTextLike(text) ?? string.Empty;
    public static string ObsSqlLikeInit(string text) => Obs.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string ObsSqlLikeSpaces(string? text) => Obs.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string CNHSql(string text) => CNH.SqlCmdTextIgual(text, 100) ?? string.Empty;
    public static string CNHSqlNotIsNull => CNH.SqlCmdNotIsNull() ?? string.Empty;
    public static string CNHSqlIsNull => CNH.SqlCmdIsNull() ?? string.Empty;

    public static string CNHSqlDiff(string text) => CNH.SqlCmdTextDiff(text) ?? string.Empty;
    public static string CNHSqlLike(string text) => CNH.SqlCmdTextLike(text) ?? string.Empty;
    public static string CNHSqlLikeInit(string text) => CNH.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string CNHSqlLikeSpaces(string? text) => CNH.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string DataContratoSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{DataContrato}]");
    public static string DataContratoSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{DataContrato}]");
    public static string DataContratoSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{DataContrato}]");
    public static string DataContratoSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{DataContrato}]");
    public static string DataContratoSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{DataContrato}]");
    public static string DataContratoSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{DataContrato}]");
    public static string DataContratoSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{DataContrato}]");
    public static string DataContratoSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{DataContrato}]");
    public static string DataContratoSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{DataContrato}]");
    public static string DataContratoSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{DataContrato}]");
    public static string DataContratoSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{DataContrato}]");
    public static string DataContratoSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{DataContrato}]");
    public static string DataContratoIsNull => DataContrato.SqlCmdIsNull() ?? string.Empty;
    public static string DataContratoNotIsNull => DataContrato.SqlCmdNotIsNull() ?? string.Empty;

    public static string CNPJSql(string text) => CNPJ.SqlCmdTextIgual(text, 14) ?? string.Empty;
    public static string CNPJSqlNotIsNull => CNPJ.SqlCmdNotIsNull() ?? string.Empty;
    public static string CNPJSqlIsNull => CNPJ.SqlCmdIsNull() ?? string.Empty;

    public static string CNPJSqlDiff(string text) => CNPJ.SqlCmdTextDiff(text) ?? string.Empty;
    public static string CNPJSqlLike(string text) => CNPJ.SqlCmdTextLike(text) ?? string.Empty;
    public static string CNPJSqlLikeInit(string text) => CNPJ.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string CNPJSqlLikeSpaces(string? text) => CNPJ.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string InscEstSql(string text) => InscEst.SqlCmdTextIgual(text, 15) ?? string.Empty;
    public static string InscEstSqlNotIsNull => InscEst.SqlCmdNotIsNull() ?? string.Empty;
    public static string InscEstSqlIsNull => InscEst.SqlCmdIsNull() ?? string.Empty;

    public static string InscEstSqlDiff(string text) => InscEst.SqlCmdTextDiff(text) ?? string.Empty;
    public static string InscEstSqlLike(string text) => InscEst.SqlCmdTextLike(text) ?? string.Empty;
    public static string InscEstSqlLikeInit(string text) => InscEst.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string InscEstSqlLikeSpaces(string? text) => InscEst.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string SocioEmpresaAdminNomeSql(string text) => SocioEmpresaAdminNome.SqlCmdTextIgual(text, 80) ?? string.Empty;
    public static string SocioEmpresaAdminNomeSqlNotIsNull => SocioEmpresaAdminNome.SqlCmdNotIsNull() ?? string.Empty;
    public static string SocioEmpresaAdminNomeSqlIsNull => SocioEmpresaAdminNome.SqlCmdIsNull() ?? string.Empty;

    public static string SocioEmpresaAdminNomeSqlDiff(string text) => SocioEmpresaAdminNome.SqlCmdTextDiff(text) ?? string.Empty;
    public static string SocioEmpresaAdminNomeSqlLike(string text) => SocioEmpresaAdminNome.SqlCmdTextLike(text) ?? string.Empty;
    public static string SocioEmpresaAdminNomeSqlLikeInit(string text) => SocioEmpresaAdminNome.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string SocioEmpresaAdminNomeSqlLikeSpaces(string? text) => SocioEmpresaAdminNome.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string EnderecoSocioSql(string text) => EnderecoSocio.SqlCmdTextIgual(text, 80) ?? string.Empty;
    public static string EnderecoSocioSqlNotIsNull => EnderecoSocio.SqlCmdNotIsNull() ?? string.Empty;
    public static string EnderecoSocioSqlIsNull => EnderecoSocio.SqlCmdIsNull() ?? string.Empty;

    public static string EnderecoSocioSqlDiff(string text) => EnderecoSocio.SqlCmdTextDiff(text) ?? string.Empty;
    public static string EnderecoSocioSqlLike(string text) => EnderecoSocio.SqlCmdTextLike(text) ?? string.Empty;
    public static string EnderecoSocioSqlLikeInit(string text) => EnderecoSocio.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string EnderecoSocioSqlLikeSpaces(string? text) => EnderecoSocio.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string BairroSocioSql(string text) => BairroSocio.SqlCmdTextIgual(text, 50) ?? string.Empty;
    public static string BairroSocioSqlNotIsNull => BairroSocio.SqlCmdNotIsNull() ?? string.Empty;
    public static string BairroSocioSqlIsNull => BairroSocio.SqlCmdIsNull() ?? string.Empty;

    public static string BairroSocioSqlDiff(string text) => BairroSocio.SqlCmdTextDiff(text) ?? string.Empty;
    public static string BairroSocioSqlLike(string text) => BairroSocio.SqlCmdTextLike(text) ?? string.Empty;
    public static string BairroSocioSqlLikeInit(string text) => BairroSocio.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string BairroSocioSqlLikeSpaces(string? text) => BairroSocio.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string CEPSocioSql(string text) => CEPSocio.SqlCmdTextIgual(text, 10) ?? string.Empty;
    public static string CEPSocioSqlNotIsNull => CEPSocio.SqlCmdNotIsNull() ?? string.Empty;
    public static string CEPSocioSqlIsNull => CEPSocio.SqlCmdIsNull() ?? string.Empty;

    public static string CEPSocioSqlDiff(string text) => CEPSocio.SqlCmdTextDiff(text) ?? string.Empty;
    public static string CEPSocioSqlLike(string text) => CEPSocio.SqlCmdTextLike(text) ?? string.Empty;
    public static string CEPSocioSqlLikeInit(string text) => CEPSocio.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string CEPSocioSqlLikeSpaces(string? text) => CEPSocio.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string CidadeSocioDiff(int id) => CidadeSocio.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string CidadeSocioSql(int id) => CidadeSocio.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string CidadeSocioIsNull => CidadeSocio.SqlCmdIsNull() ?? string.Empty;
    public static string CidadeSocioNotIsNull => CidadeSocio.SqlCmdNotIsNull() ?? string.Empty;

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

    public static string SocioEmpresaAdminSomenteSql(bool valueCheck) => SocioEmpresaAdminSomente.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string SocioEmpresaAdminSomenteSqlSim => SocioEmpresaAdminSomente.SqlCmdBoolSim() ?? string.Empty;
    public static string SocioEmpresaAdminSomenteSqlNao => SocioEmpresaAdminSomente.SqlCmdBoolNao() ?? string.Empty;

    public static string TipoSql(bool valueCheck) => Tipo.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string TipoSqlSim => Tipo.SqlCmdBoolSim() ?? string.Empty;
    public static string TipoSqlNao => Tipo.SqlCmdBoolNao() ?? string.Empty;

    public static string FaxSql(string text) => Fax.SqlCmdTextIgual(text, 2048) ?? string.Empty;
    public static string FaxSqlNotIsNull => Fax.SqlCmdNotIsNull() ?? string.Empty;
    public static string FaxSqlIsNull => Fax.SqlCmdIsNull() ?? string.Empty;

    public static string FaxSqlDiff(string text) => Fax.SqlCmdTextDiff(text) ?? string.Empty;
    public static string FaxSqlLike(string text) => Fax.SqlCmdTextLike(text) ?? string.Empty;
    public static string FaxSqlLikeInit(string text) => Fax.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string FaxSqlLikeSpaces(string? text) => Fax.SqlCmdTextLikeSpaces(text) ?? string.Empty;
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
        CscSomenteRepresentante = 1,
        CscIdade = 2,
        CscIsRepresentanteLegal = 3,
        CscQualificacao = 4,
        CscSexo = 5,
        CscDtNasc = 6,
        CscNome = 7,
        CscSite = 8,
        CscRepresentanteLegal = 9,
        CscCliente = 10,
        CscEndereco = 11,
        CscBairro = 12,
        CscCEP = 13,
        CscCidade = 14,
        CscRG = 15,
        CscCPF = 16,
        CscFone = 17,
        CscParticipacao = 18,
        CscCargo = 19,
        CscEMail = 20,
        CscObs = 21,
        CscCNH = 22,
        CscDataContrato = 23,
        CscCNPJ = 24,
        CscInscEst = 25,
        CscSocioEmpresaAdminNome = 26,
        CscEnderecoSocio = 27,
        CscBairroSocio = 28,
        CscCEPSocio = 29,
        CscCidadeSocio = 30,
        CscRGDataExp = 31,
        CscSocioEmpresaAdminSomente = 32,
        CscTipo = 33,
        CscFax = 34,
        CscClass = 35,
        CscEtiqueta = 36,
        CscAni = 37,
        CscBold = 38,
        CscGUID = 39,
        CscQuemCad = 40,
        CscDtCad = 41,
        CscQuemAtu = 42,
        CscDtAtu = 43,
        CscVisto = 44
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.CscSomenteRepresentante => CscSomenteRepresentante,
        NomesCamposTabela.CscIdade => CscIdade,
        NomesCamposTabela.CscIsRepresentanteLegal => CscIsRepresentanteLegal,
        NomesCamposTabela.CscQualificacao => CscQualificacao,
        NomesCamposTabela.CscSexo => CscSexo,
        NomesCamposTabela.CscDtNasc => CscDtNasc,
        NomesCamposTabela.CscNome => CscNome,
        NomesCamposTabela.CscSite => CscSite,
        NomesCamposTabela.CscRepresentanteLegal => CscRepresentanteLegal,
        NomesCamposTabela.CscCliente => CscCliente,
        NomesCamposTabela.CscEndereco => CscEndereco,
        NomesCamposTabela.CscBairro => CscBairro,
        NomesCamposTabela.CscCEP => CscCEP,
        NomesCamposTabela.CscCidade => CscCidade,
        NomesCamposTabela.CscRG => CscRG,
        NomesCamposTabela.CscCPF => CscCPF,
        NomesCamposTabela.CscFone => CscFone,
        NomesCamposTabela.CscParticipacao => CscParticipacao,
        NomesCamposTabela.CscCargo => CscCargo,
        NomesCamposTabela.CscEMail => CscEMail,
        NomesCamposTabela.CscObs => CscObs,
        NomesCamposTabela.CscCNH => CscCNH,
        NomesCamposTabela.CscDataContrato => CscDataContrato,
        NomesCamposTabela.CscCNPJ => CscCNPJ,
        NomesCamposTabela.CscInscEst => CscInscEst,
        NomesCamposTabela.CscSocioEmpresaAdminNome => CscSocioEmpresaAdminNome,
        NomesCamposTabela.CscEnderecoSocio => CscEnderecoSocio,
        NomesCamposTabela.CscBairroSocio => CscBairroSocio,
        NomesCamposTabela.CscCEPSocio => CscCEPSocio,
        NomesCamposTabela.CscCidadeSocio => CscCidadeSocio,
        NomesCamposTabela.CscRGDataExp => CscRGDataExp,
        NomesCamposTabela.CscSocioEmpresaAdminSomente => CscSocioEmpresaAdminSomente,
        NomesCamposTabela.CscTipo => CscTipo,
        NomesCamposTabela.CscFax => CscFax,
        NomesCamposTabela.CscClass => CscClass,
        NomesCamposTabela.CscEtiqueta => CscEtiqueta,
        NomesCamposTabela.CscAni => CscAni,
        NomesCamposTabela.CscBold => CscBold,
        NomesCamposTabela.CscGUID => CscGUID,
        NomesCamposTabela.CscQuemCad => CscQuemCad,
        NomesCamposTabela.CscDtCad => CscDtCad,
        NomesCamposTabela.CscQuemAtu => CscQuemAtu,
        NomesCamposTabela.CscDtAtu => CscDtAtu,
        NomesCamposTabela.CscVisto => CscVisto,
        _ => null
    };
}