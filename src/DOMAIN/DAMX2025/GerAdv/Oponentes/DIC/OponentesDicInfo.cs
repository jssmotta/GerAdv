using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBOponentesDicInfo
{
    public const string CampoCodigo = "opoCodigo";
    public const string CampoNome = "opoNome";
    public const string TablePrefix = "opo";
    public const string EMPFuncao = "opoEMPFuncao"; // LOCALIZACAO 170523
    public const string CTPSNumero = "opoCTPSNumero"; // LOCALIZACAO 170523
    public const string Site = "opoSite"; // LOCALIZACAO 170523
    public const string CTPSSerie = "opoCTPSSerie"; // LOCALIZACAO 170523
    public const string Nome = "opoNome"; // LOCALIZACAO 170523
    public const string Adv = "opoAdv"; // LOCALIZACAO 170523
    public const string EMPCliente = "opoEMPCliente"; // LOCALIZACAO 170523
    public const string IDRep = "opoIDRep"; // LOCALIZACAO 170523
    public const string PIS = "opoPIS"; // LOCALIZACAO 170523
    public const string Contato = "opoContato"; // LOCALIZACAO 170523
    public const string CNPJ = "opoCNPJ"; // LOCALIZACAO 170523
    public const string RG = "opoRG"; // LOCALIZACAO 170523
    public const string Juridica = "opoJuridica"; // LOCALIZACAO 170523
    public const string Tipo = "opoTipo"; // LOCALIZACAO 170523
    public const string Sexo = "opoSexo"; // LOCALIZACAO 170523
    public const string CPF = "opoCPF"; // LOCALIZACAO 170523
    public const string Endereco = "opoEndereco"; // LOCALIZACAO 170523
    public const string Fone = "opoFone"; // LOCALIZACAO 170523
    public const string Fax = "opoFax"; // LOCALIZACAO 170523
    public const string Cidade = "opoCidade"; // LOCALIZACAO 170523
    public const string Bairro = "opoBairro"; // LOCALIZACAO 170523
    public const string CEP = "opoCEP"; // LOCALIZACAO 170523
    public const string InscEst = "opoInscEst"; // LOCALIZACAO 170523
    public const string Observacao = "opoObservacao"; // LOCALIZACAO 170523
    public const string EMail = "opoEMail"; // LOCALIZACAO 170523
    public const string Class = "opoClass"; // LOCALIZACAO 170523
    public const string Top = "opoTop"; // LOCALIZACAO 170523
    public const string Etiqueta = "opoEtiqueta"; // LOCALIZACAO 170523
    public const string Bold = "opoBold"; // LOCALIZACAO 170523
    public const string GUID = "opoGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "opoQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "opoDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "opoQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "opoDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "opoVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => EMPFuncao,
        2 => CTPSNumero,
        3 => Site,
        4 => CTPSSerie,
        5 => Nome,
        6 => Adv,
        7 => EMPCliente,
        8 => IDRep,
        9 => PIS,
        10 => Contato,
        11 => CNPJ,
        12 => RG,
        13 => Juridica,
        14 => Tipo,
        15 => Sexo,
        16 => CPF,
        17 => Endereco,
        18 => Fone,
        19 => Fax,
        20 => Cidade,
        21 => Bairro,
        22 => CEP,
        23 => InscEst,
        24 => Observacao,
        25 => EMail,
        26 => Class,
        27 => Top,
        28 => Etiqueta,
        29 => Bold,
        30 => GUID,
        31 => QuemCad,
        32 => DtCad,
        33 => QuemAtu,
        34 => DtAtu,
        35 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "Oponentes";
#region PropriedadesDaTabela
    public static DBInfoSystem OpoEMPFuncao => new(0, PTabelaNome, CampoCodigo, EMPFuncao, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoCTPSNumero => new(0, PTabelaNome, CampoCodigo, CTPSNumero, 15, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoSite => new(0, PTabelaNome, CampoCodigo, Site, 150, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextWebsite, true, false, false)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoCTPSSerie => new(0, PTabelaNome, CampoCodigo, CTPSSerie, 10, DevourerOne.PNroSerieCtps, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCtpsserie, true, false, false)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoNome => new(0, PTabelaNome, CampoCodigo, Nome, 80, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoAdv => new(0, PTabelaNome, CampoCodigo, Adv, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoEMPCliente => new(0, PTabelaNome, CampoCodigo, EMPCliente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoIDRep => new(0, PTabelaNome, CampoCodigo, IDRep, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoPIS => new(0, PTabelaNome, CampoCodigo, PIS, 20, DevourerOne.PNroPis, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextPis, true, false, false)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoContato => new(0, PTabelaNome, CampoCodigo, Contato, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoCNPJ => new(0, PTabelaNome, CampoCodigo, CNPJ, 14, DevourerOne.PCnpj, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCnpj, true, false, false)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoRG => new(0, PTabelaNome, CampoCodigo, RG, 12, DevourerOne.PRg, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextRG, true, false, false)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoJuridica => new(0, PTabelaNome, CampoCodigo, Juridica, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoTipo => new(0, PTabelaNome, CampoCodigo, Tipo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBooleanTipoPessoa)
    {
        IsRequired = true,
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoSexo => new(0, PTabelaNome, CampoCodigo, Sexo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBooleanSexo)
    {
        IsRequired = true,
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoCPF => new(0, PTabelaNome, CampoCodigo, CPF, 11, DevourerOne.PCpf, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCpf, true, false, false)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoEndereco => new(0, PTabelaNome, CampoCodigo, Endereco, 80, DevourerOne.PEndereco, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEndereco, true, false, false)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoFone => new(0, PTabelaNome, CampoCodigo, Fone, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFone, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFone, true, false, false)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoFax => new(0, PTabelaNome, CampoCodigo, Fax, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFax, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFax, true, false, false)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoCidade => new(0, PTabelaNome, CampoCodigo, Cidade, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBCidadeDicInfo.CampoCodigo, DBCidadeDicInfo.TabelaNome, new DBCidadeODicInfo(), false)
    {
        Prefixo = "opo"
    }; // DBI 11 
    public static DBInfoSystem OpoBairro => new(0, PTabelaNome, CampoCodigo, Bairro, 50, DevourerOne.PBairro, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextBairro, true, false, false)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoCEP => new(0, PTabelaNome, CampoCodigo, CEP, 10, DevourerOne.PCep, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCep, true, false, false)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoInscEst => new(0, PTabelaNome, CampoCodigo, InscEst, 15, DevourerOne.PInscricaoEstadual, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextInscricao, true, false, false)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoObservacao => new(0, PTabelaNome, CampoCodigo, Observacao, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemoObservacao, true, false, false)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoEMail => new(0, PTabelaNome, CampoCodigo, EMail, 100, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEmail, true, false, false)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoClass => new(0, PTabelaNome, CampoCodigo, Class, 1, DevourerOne.PClassificacao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextClassificacaoStar, true, false, false)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoTop => new(0, PTabelaNome, CampoCodigo, Top, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoEtiqueta => new(0, PTabelaNome, CampoCodigo, Etiqueta, DevourerOne.PCriarEtiqueta, DevourerOne.PTooltipEtiqueta, ETipoDadosSysteminfo.SysteminfoBooleanEtiqueta)
    {
        IsRequired = true,
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold)
    {
        IsRequired = true,
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "opo"
    }; // DBI 11 
    public static DBInfoSystem OpoDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "opo"
    }; // DBI 11 
    public static DBInfoSystem OpoDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "opo"
    };
    public static DBInfoSystem OpoVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "opo"
    };

#endregion
#region SMART_SQLServices 
    public static string CTPSNumeroSql(string text) => CTPSNumero.SqlCmdTextIgual(text, 15) ?? string.Empty;
    public static string CTPSNumeroSqlNotIsNull => CTPSNumero.SqlCmdNotIsNull() ?? string.Empty;
    public static string CTPSNumeroSqlIsNull => CTPSNumero.SqlCmdIsNull() ?? string.Empty;

    public static string CTPSNumeroSqlDiff(string text) => CTPSNumero.SqlCmdTextDiff(text) ?? string.Empty;
    public static string CTPSNumeroSqlLike(string text) => CTPSNumero.SqlCmdTextLike(text) ?? string.Empty;
    public static string CTPSNumeroSqlLikeInit(string text) => CTPSNumero.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string CTPSNumeroSqlLikeSpaces(string? text) => CTPSNumero.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string SiteSql(string text) => Site.SqlCmdTextIgual(text, 150) ?? string.Empty;
    public static string SiteSqlNotIsNull => Site.SqlCmdNotIsNull() ?? string.Empty;
    public static string SiteSqlIsNull => Site.SqlCmdIsNull() ?? string.Empty;

    public static string SiteSqlDiff(string text) => Site.SqlCmdTextDiff(text) ?? string.Empty;
    public static string SiteSqlLike(string text) => Site.SqlCmdTextLike(text) ?? string.Empty;
    public static string SiteSqlLikeInit(string text) => Site.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string SiteSqlLikeSpaces(string? text) => Site.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string CTPSSerieSql(string text) => CTPSSerie.SqlCmdTextIgual(text, 10) ?? string.Empty;
    public static string CTPSSerieSqlNotIsNull => CTPSSerie.SqlCmdNotIsNull() ?? string.Empty;
    public static string CTPSSerieSqlIsNull => CTPSSerie.SqlCmdIsNull() ?? string.Empty;

    public static string CTPSSerieSqlDiff(string text) => CTPSSerie.SqlCmdTextDiff(text) ?? string.Empty;
    public static string CTPSSerieSqlLike(string text) => CTPSSerie.SqlCmdTextLike(text) ?? string.Empty;
    public static string CTPSSerieSqlLikeInit(string text) => CTPSSerie.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string CTPSSerieSqlLikeSpaces(string? text) => CTPSSerie.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string NomeSql(string text) => Nome.SqlCmdTextIgual(text, 80) ?? string.Empty;
    public static string NomeSqlNotIsNull => Nome.SqlCmdNotIsNull() ?? string.Empty;
    public static string NomeSqlIsNull => Nome.SqlCmdIsNull() ?? string.Empty;

    public static string NomeSqlDiff(string text) => Nome.SqlCmdTextDiff(text) ?? string.Empty;
    public static string NomeSqlLike(string text) => Nome.SqlCmdTextLike(text) ?? string.Empty;
    public static string NomeSqlLikeInit(string text) => Nome.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string NomeSqlLikeSpaces(string? text) => Nome.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string PISSql(string text) => PIS.SqlCmdTextIgual(text, 20) ?? string.Empty;
    public static string PISSqlNotIsNull => PIS.SqlCmdNotIsNull() ?? string.Empty;
    public static string PISSqlIsNull => PIS.SqlCmdIsNull() ?? string.Empty;

    public static string PISSqlDiff(string text) => PIS.SqlCmdTextDiff(text) ?? string.Empty;
    public static string PISSqlLike(string text) => PIS.SqlCmdTextLike(text) ?? string.Empty;
    public static string PISSqlLikeInit(string text) => PIS.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string PISSqlLikeSpaces(string? text) => PIS.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string ContatoSql(string text) => Contato.SqlCmdTextIgual(text) ?? string.Empty;
    public static string ContatoSqlNotIsNull => Contato.SqlCmdNotIsNull() ?? string.Empty;
    public static string ContatoSqlIsNull => Contato.SqlCmdIsNull() ?? string.Empty;

    public static string ContatoSqlDiff(string text) => Contato.SqlCmdTextDiff(text) ?? string.Empty;
    public static string ContatoSqlLike(string text) => Contato.SqlCmdTextLike(text) ?? string.Empty;
    public static string ContatoSqlLikeInit(string text) => Contato.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string ContatoSqlLikeSpaces(string? text) => Contato.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string CNPJSql(string text) => CNPJ.SqlCmdTextIgual(text, 14) ?? string.Empty;
    public static string CNPJSqlNotIsNull => CNPJ.SqlCmdNotIsNull() ?? string.Empty;
    public static string CNPJSqlIsNull => CNPJ.SqlCmdIsNull() ?? string.Empty;

    public static string CNPJSqlDiff(string text) => CNPJ.SqlCmdTextDiff(text) ?? string.Empty;
    public static string CNPJSqlLike(string text) => CNPJ.SqlCmdTextLike(text) ?? string.Empty;
    public static string CNPJSqlLikeInit(string text) => CNPJ.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string CNPJSqlLikeSpaces(string? text) => CNPJ.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string RGSql(string text) => RG.SqlCmdTextIgual(text, 12) ?? string.Empty;
    public static string RGSqlNotIsNull => RG.SqlCmdNotIsNull() ?? string.Empty;
    public static string RGSqlIsNull => RG.SqlCmdIsNull() ?? string.Empty;

    public static string RGSqlDiff(string text) => RG.SqlCmdTextDiff(text) ?? string.Empty;
    public static string RGSqlLike(string text) => RG.SqlCmdTextLike(text) ?? string.Empty;
    public static string RGSqlLikeInit(string text) => RG.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string RGSqlLikeSpaces(string? text) => RG.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string JuridicaSql(bool valueCheck) => Juridica.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string JuridicaSqlSim => Juridica.SqlCmdBoolSim() ?? string.Empty;
    public static string JuridicaSqlNao => Juridica.SqlCmdBoolNao() ?? string.Empty;

    public static string TipoSql(bool valueCheck) => Tipo.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string TipoSqlSim => Tipo.SqlCmdBoolSim() ?? string.Empty;
    public static string TipoSqlNao => Tipo.SqlCmdBoolNao() ?? string.Empty;

    public static string SexoSql(bool valueCheck) => Sexo.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string SexoSqlSim => Sexo.SqlCmdBoolSim() ?? string.Empty;
    public static string SexoSqlNao => Sexo.SqlCmdBoolNao() ?? string.Empty;

    public static string CPFSql(string text) => CPF.SqlCmdTextIgual(text, 11) ?? string.Empty;
    public static string CPFSqlNotIsNull => CPF.SqlCmdNotIsNull() ?? string.Empty;
    public static string CPFSqlIsNull => CPF.SqlCmdIsNull() ?? string.Empty;

    public static string CPFSqlDiff(string text) => CPF.SqlCmdTextDiff(text) ?? string.Empty;
    public static string CPFSqlLike(string text) => CPF.SqlCmdTextLike(text) ?? string.Empty;
    public static string CPFSqlLikeInit(string text) => CPF.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string CPFSqlLikeSpaces(string? text) => CPF.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string EnderecoSql(string text) => Endereco.SqlCmdTextIgual(text, 80) ?? string.Empty;
    public static string EnderecoSqlNotIsNull => Endereco.SqlCmdNotIsNull() ?? string.Empty;
    public static string EnderecoSqlIsNull => Endereco.SqlCmdIsNull() ?? string.Empty;

    public static string EnderecoSqlDiff(string text) => Endereco.SqlCmdTextDiff(text) ?? string.Empty;
    public static string EnderecoSqlLike(string text) => Endereco.SqlCmdTextLike(text) ?? string.Empty;
    public static string EnderecoSqlLikeInit(string text) => Endereco.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string EnderecoSqlLikeSpaces(string? text) => Endereco.SqlCmdTextLikeSpaces(text) ?? string.Empty;
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
    public static string InscEstSql(string text) => InscEst.SqlCmdTextIgual(text, 15) ?? string.Empty;
    public static string InscEstSqlNotIsNull => InscEst.SqlCmdNotIsNull() ?? string.Empty;
    public static string InscEstSqlIsNull => InscEst.SqlCmdIsNull() ?? string.Empty;

    public static string InscEstSqlDiff(string text) => InscEst.SqlCmdTextDiff(text) ?? string.Empty;
    public static string InscEstSqlLike(string text) => InscEst.SqlCmdTextLike(text) ?? string.Empty;
    public static string InscEstSqlLikeInit(string text) => InscEst.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string InscEstSqlLikeSpaces(string? text) => InscEst.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string ObservacaoSql(string text) => Observacao.SqlCmdTextIgual(text) ?? string.Empty;
    public static string ObservacaoSqlNotIsNull => Observacao.SqlCmdNotIsNull() ?? string.Empty;
    public static string ObservacaoSqlIsNull => Observacao.SqlCmdIsNull() ?? string.Empty;

    public static string ObservacaoSqlDiff(string text) => Observacao.SqlCmdTextDiff(text) ?? string.Empty;
    public static string ObservacaoSqlLike(string text) => Observacao.SqlCmdTextLike(text) ?? string.Empty;
    public static string ObservacaoSqlLikeInit(string text) => Observacao.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string ObservacaoSqlLikeSpaces(string? text) => Observacao.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string EMailSql(string text) => EMail.SqlCmdTextIgual(text, 100) ?? string.Empty;
    public static string EMailSqlNotIsNull => EMail.SqlCmdNotIsNull() ?? string.Empty;
    public static string EMailSqlIsNull => EMail.SqlCmdIsNull() ?? string.Empty;

    public static string EMailSqlDiff(string text) => EMail.SqlCmdTextDiff(text) ?? string.Empty;
    public static string EMailSqlLike(string text) => EMail.SqlCmdTextLike(text) ?? string.Empty;
    public static string EMailSqlLikeInit(string text) => EMail.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string EMailSqlLikeSpaces(string? text) => EMail.SqlCmdTextLikeSpaces(text) ?? string.Empty;
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

    public static string BoldSql(bool valueCheck) => Bold.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string BoldSqlSim => Bold.SqlCmdBoolSim() ?? string.Empty;
    public static string BoldSqlNao => Bold.SqlCmdBoolNao() ?? string.Empty;

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
        OpoEMPFuncao = 1,
        OpoCTPSNumero = 2,
        OpoSite = 3,
        OpoCTPSSerie = 4,
        OpoNome = 5,
        OpoAdv = 6,
        OpoEMPCliente = 7,
        OpoIDRep = 8,
        OpoPIS = 9,
        OpoContato = 10,
        OpoCNPJ = 11,
        OpoRG = 12,
        OpoJuridica = 13,
        OpoTipo = 14,
        OpoSexo = 15,
        OpoCPF = 16,
        OpoEndereco = 17,
        OpoFone = 18,
        OpoFax = 19,
        OpoCidade = 20,
        OpoBairro = 21,
        OpoCEP = 22,
        OpoInscEst = 23,
        OpoObservacao = 24,
        OpoEMail = 25,
        OpoClass = 26,
        OpoTop = 27,
        OpoEtiqueta = 28,
        OpoBold = 29,
        OpoGUID = 30,
        OpoQuemCad = 31,
        OpoDtCad = 32,
        OpoQuemAtu = 33,
        OpoDtAtu = 34,
        OpoVisto = 35
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.OpoEMPFuncao => OpoEMPFuncao,
        NomesCamposTabela.OpoCTPSNumero => OpoCTPSNumero,
        NomesCamposTabela.OpoSite => OpoSite,
        NomesCamposTabela.OpoCTPSSerie => OpoCTPSSerie,
        NomesCamposTabela.OpoNome => OpoNome,
        NomesCamposTabela.OpoAdv => OpoAdv,
        NomesCamposTabela.OpoEMPCliente => OpoEMPCliente,
        NomesCamposTabela.OpoIDRep => OpoIDRep,
        NomesCamposTabela.OpoPIS => OpoPIS,
        NomesCamposTabela.OpoContato => OpoContato,
        NomesCamposTabela.OpoCNPJ => OpoCNPJ,
        NomesCamposTabela.OpoRG => OpoRG,
        NomesCamposTabela.OpoJuridica => OpoJuridica,
        NomesCamposTabela.OpoTipo => OpoTipo,
        NomesCamposTabela.OpoSexo => OpoSexo,
        NomesCamposTabela.OpoCPF => OpoCPF,
        NomesCamposTabela.OpoEndereco => OpoEndereco,
        NomesCamposTabela.OpoFone => OpoFone,
        NomesCamposTabela.OpoFax => OpoFax,
        NomesCamposTabela.OpoCidade => OpoCidade,
        NomesCamposTabela.OpoBairro => OpoBairro,
        NomesCamposTabela.OpoCEP => OpoCEP,
        NomesCamposTabela.OpoInscEst => OpoInscEst,
        NomesCamposTabela.OpoObservacao => OpoObservacao,
        NomesCamposTabela.OpoEMail => OpoEMail,
        NomesCamposTabela.OpoClass => OpoClass,
        NomesCamposTabela.OpoTop => OpoTop,
        NomesCamposTabela.OpoEtiqueta => OpoEtiqueta,
        NomesCamposTabela.OpoBold => OpoBold,
        NomesCamposTabela.OpoGUID => OpoGUID,
        NomesCamposTabela.OpoQuemCad => OpoQuemCad,
        NomesCamposTabela.OpoDtCad => OpoDtCad,
        NomesCamposTabela.OpoQuemAtu => OpoQuemAtu,
        NomesCamposTabela.OpoDtAtu => OpoDtAtu,
        NomesCamposTabela.OpoVisto => OpoVisto,
        _ => null
    };
}