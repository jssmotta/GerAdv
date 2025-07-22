using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBEscritoriosDicInfo
{
    public const string CampoCodigo = "escCodigo";
    public const string CampoNome = "escNome";
    public const string TablePrefix = "esc";
    public const string CNPJ = "escCNPJ"; // LOCALIZACAO 170523
    public const string Casa = "escCasa"; // LOCALIZACAO 170523
    public const string Parceria = "escParceria"; // LOCALIZACAO 170523
    public const string Nome = "escNome"; // LOCALIZACAO 170523
    public const string OAB = "escOAB"; // LOCALIZACAO 170523
    public const string Endereco = "escEndereco"; // LOCALIZACAO 170523
    public const string Cidade = "escCidade"; // LOCALIZACAO 170523
    public const string Bairro = "escBairro"; // LOCALIZACAO 170523
    public const string CEP = "escCEP"; // LOCALIZACAO 170523
    public const string Fone = "escFone"; // LOCALIZACAO 170523
    public const string Fax = "escFax"; // LOCALIZACAO 170523
    public const string Site = "escSite"; // LOCALIZACAO 170523
    public const string EMail = "escEMail"; // LOCALIZACAO 170523
    public const string OBS = "escOBS"; // LOCALIZACAO 170523
    public const string AdvResponsavel = "escAdvResponsavel"; // LOCALIZACAO 170523
    public const string Secretaria = "escSecretaria"; // LOCALIZACAO 170523
    public const string InscEst = "escInscEst"; // LOCALIZACAO 170523
    public const string Correspondente = "escCorrespondente"; // LOCALIZACAO 170523
    public const string Top = "escTop"; // LOCALIZACAO 170523
    public const string Etiqueta = "escEtiqueta"; // LOCALIZACAO 170523
    public const string Bold = "escBold"; // LOCALIZACAO 170523
    public const string GUID = "escGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "escQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "escDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "escQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "escDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "escVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => CNPJ,
        2 => Casa,
        3 => Parceria,
        4 => Nome,
        5 => OAB,
        6 => Endereco,
        7 => Cidade,
        8 => Bairro,
        9 => CEP,
        10 => Fone,
        11 => Fax,
        12 => Site,
        13 => EMail,
        14 => OBS,
        15 => AdvResponsavel,
        16 => Secretaria,
        17 => InscEst,
        18 => Correspondente,
        19 => Top,
        20 => Etiqueta,
        21 => Bold,
        22 => GUID,
        23 => QuemCad,
        24 => DtCad,
        25 => QuemAtu,
        26 => DtAtu,
        27 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "Escritorios";
#region PropriedadesDaTabela
    public static DBInfoSystem EscCNPJ => new(0, PTabelaNome, CampoCodigo, CNPJ, 14, DevourerOne.PCnpj, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCnpj, true, false, false)
    {
        Prefixo = "esc"
    };
    public static DBInfoSystem EscCasa => new(0, PTabelaNome, CampoCodigo, Casa, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "esc"
    };
    public static DBInfoSystem EscParceria => new(0, PTabelaNome, CampoCodigo, Parceria, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "esc"
    };
    public static DBInfoSystem EscNome => new(0, PTabelaNome, CampoCodigo, Nome, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        Prefixo = "esc"
    };
    public static DBInfoSystem EscOAB => new(0, PTabelaNome, CampoCodigo, OAB, 15, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "esc"
    };
    public static DBInfoSystem EscEndereco => new(0, PTabelaNome, CampoCodigo, Endereco, 50, DevourerOne.PEndereco, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEndereco, true, false, false)
    {
        Prefixo = "esc"
    };
    public static DBInfoSystem EscCidade => new(0, PTabelaNome, CampoCodigo, Cidade, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBCidadeDicInfo.CampoCodigo, DBCidadeDicInfo.TabelaNome, new DBCidadeODicInfo(), false)
    {
        Prefixo = "esc"
    }; // DBI 11 
    public static DBInfoSystem EscBairro => new(0, PTabelaNome, CampoCodigo, Bairro, 30, DevourerOne.PBairro, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextBairro, true, false, false)
    {
        Prefixo = "esc"
    };
    public static DBInfoSystem EscCEP => new(0, PTabelaNome, CampoCodigo, CEP, 10, DevourerOne.PCep, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCep, true, false, false)
    {
        Prefixo = "esc"
    };
    public static DBInfoSystem EscFone => new(0, PTabelaNome, CampoCodigo, Fone, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFone, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFone, true, false, false)
    {
        Prefixo = "esc"
    };
    public static DBInfoSystem EscFax => new(0, PTabelaNome, CampoCodigo, Fax, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFax, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFax, true, false, false)
    {
        Prefixo = "esc"
    };
    public static DBInfoSystem EscSite => new(0, PTabelaNome, CampoCodigo, Site, 200, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextWebsite, true, false, false)
    {
        Prefixo = "esc"
    };
    public static DBInfoSystem EscEMail => new(0, PTabelaNome, CampoCodigo, EMail, 100, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEmail, true, false, false)
    {
        Prefixo = "esc"
    };
    public static DBInfoSystem EscOBS => new(0, PTabelaNome, CampoCodigo, OBS, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemoObservacao, true, false, false)
    {
        Prefixo = "esc"
    };
    public static DBInfoSystem EscAdvResponsavel => new(0, PTabelaNome, CampoCodigo, AdvResponsavel, 80, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "esc"
    };
    public static DBInfoSystem EscSecretaria => new(0, PTabelaNome, CampoCodigo, Secretaria, 80, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "esc"
    };
    public static DBInfoSystem EscInscEst => new(0, PTabelaNome, CampoCodigo, InscEst, 15, DevourerOne.PInscricaoEstadual, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextInscricao, true, false, false)
    {
        Prefixo = "esc"
    };
    public static DBInfoSystem EscCorrespondente => new(0, PTabelaNome, CampoCodigo, Correspondente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        Prefixo = "esc"
    };
    public static DBInfoSystem EscTop => new(0, PTabelaNome, CampoCodigo, Top, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        Prefixo = "esc"
    };
    public static DBInfoSystem EscEtiqueta => new(0, PTabelaNome, CampoCodigo, Etiqueta, DevourerOne.PCriarEtiqueta, DevourerOne.PTooltipEtiqueta, ETipoDadosSysteminfo.SysteminfoBooleanEtiqueta)
    {
        IsRequired = true,
        Prefixo = "esc"
    };
    public static DBInfoSystem EscBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold)
    {
        IsRequired = true,
        Prefixo = "esc"
    };
    public static DBInfoSystem EscGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "esc"
    };
    public static DBInfoSystem EscQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "esc"
    }; // DBI 11 
    public static DBInfoSystem EscDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "esc"
    };
    public static DBInfoSystem EscQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "esc"
    }; // DBI 11 
    public static DBInfoSystem EscDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "esc"
    };
    public static DBInfoSystem EscVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "esc"
    };

#endregion
#region SMART_SQLServices 
    public static string CNPJSql(string text) => CNPJ.SqlCmdTextIgual(text, 14) ?? string.Empty;
    public static string CNPJSqlNotIsNull => CNPJ.SqlCmdNotIsNull() ?? string.Empty;
    public static string CNPJSqlIsNull => CNPJ.SqlCmdIsNull() ?? string.Empty;

    public static string CNPJSqlDiff(string text) => CNPJ.SqlCmdTextDiff(text) ?? string.Empty;
    public static string CNPJSqlLike(string text) => CNPJ.SqlCmdTextLike(text) ?? string.Empty;
    public static string CNPJSqlLikeInit(string text) => CNPJ.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string CNPJSqlLikeSpaces(string? text) => CNPJ.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string CasaSql(bool valueCheck) => Casa.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string CasaSqlSim => Casa.SqlCmdBoolSim() ?? string.Empty;
    public static string CasaSqlNao => Casa.SqlCmdBoolNao() ?? string.Empty;

    public static string ParceriaSql(bool valueCheck) => Parceria.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string ParceriaSqlSim => Parceria.SqlCmdBoolSim() ?? string.Empty;
    public static string ParceriaSqlNao => Parceria.SqlCmdBoolNao() ?? string.Empty;

    public static string NomeSql(string text) => Nome.SqlCmdTextIgual(text, 50) ?? string.Empty;
    public static string NomeSqlNotIsNull => Nome.SqlCmdNotIsNull() ?? string.Empty;
    public static string NomeSqlIsNull => Nome.SqlCmdIsNull() ?? string.Empty;

    public static string NomeSqlDiff(string text) => Nome.SqlCmdTextDiff(text) ?? string.Empty;
    public static string NomeSqlLike(string text) => Nome.SqlCmdTextLike(text) ?? string.Empty;
    public static string NomeSqlLikeInit(string text) => Nome.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string NomeSqlLikeSpaces(string? text) => Nome.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string OABSql(string text) => OAB.SqlCmdTextIgual(text, 15) ?? string.Empty;
    public static string OABSqlNotIsNull => OAB.SqlCmdNotIsNull() ?? string.Empty;
    public static string OABSqlIsNull => OAB.SqlCmdIsNull() ?? string.Empty;

    public static string OABSqlDiff(string text) => OAB.SqlCmdTextDiff(text) ?? string.Empty;
    public static string OABSqlLike(string text) => OAB.SqlCmdTextLike(text) ?? string.Empty;
    public static string OABSqlLikeInit(string text) => OAB.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string OABSqlLikeSpaces(string? text) => OAB.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string EnderecoSql(string text) => Endereco.SqlCmdTextIgual(text, 50) ?? string.Empty;
    public static string EnderecoSqlNotIsNull => Endereco.SqlCmdNotIsNull() ?? string.Empty;
    public static string EnderecoSqlIsNull => Endereco.SqlCmdIsNull() ?? string.Empty;

    public static string EnderecoSqlDiff(string text) => Endereco.SqlCmdTextDiff(text) ?? string.Empty;
    public static string EnderecoSqlLike(string text) => Endereco.SqlCmdTextLike(text) ?? string.Empty;
    public static string EnderecoSqlLikeInit(string text) => Endereco.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string EnderecoSqlLikeSpaces(string? text) => Endereco.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string BairroSql(string text) => Bairro.SqlCmdTextIgual(text, 30) ?? string.Empty;
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
    public static string SiteSql(string text) => Site.SqlCmdTextIgual(text, 200) ?? string.Empty;
    public static string SiteSqlNotIsNull => Site.SqlCmdNotIsNull() ?? string.Empty;
    public static string SiteSqlIsNull => Site.SqlCmdIsNull() ?? string.Empty;

    public static string SiteSqlDiff(string text) => Site.SqlCmdTextDiff(text) ?? string.Empty;
    public static string SiteSqlLike(string text) => Site.SqlCmdTextLike(text) ?? string.Empty;
    public static string SiteSqlLikeInit(string text) => Site.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string SiteSqlLikeSpaces(string? text) => Site.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string EMailSql(string text) => EMail.SqlCmdTextIgual(text, 100) ?? string.Empty;
    public static string EMailSqlNotIsNull => EMail.SqlCmdNotIsNull() ?? string.Empty;
    public static string EMailSqlIsNull => EMail.SqlCmdIsNull() ?? string.Empty;

    public static string EMailSqlDiff(string text) => EMail.SqlCmdTextDiff(text) ?? string.Empty;
    public static string EMailSqlLike(string text) => EMail.SqlCmdTextLike(text) ?? string.Empty;
    public static string EMailSqlLikeInit(string text) => EMail.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string EMailSqlLikeSpaces(string? text) => EMail.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string OBSSql(string text) => OBS.SqlCmdTextIgual(text) ?? string.Empty;
    public static string OBSSqlNotIsNull => OBS.SqlCmdNotIsNull() ?? string.Empty;
    public static string OBSSqlIsNull => OBS.SqlCmdIsNull() ?? string.Empty;

    public static string OBSSqlDiff(string text) => OBS.SqlCmdTextDiff(text) ?? string.Empty;
    public static string OBSSqlLike(string text) => OBS.SqlCmdTextLike(text) ?? string.Empty;
    public static string OBSSqlLikeInit(string text) => OBS.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string OBSSqlLikeSpaces(string? text) => OBS.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string AdvResponsavelSql(string text) => AdvResponsavel.SqlCmdTextIgual(text, 80) ?? string.Empty;
    public static string AdvResponsavelSqlNotIsNull => AdvResponsavel.SqlCmdNotIsNull() ?? string.Empty;
    public static string AdvResponsavelSqlIsNull => AdvResponsavel.SqlCmdIsNull() ?? string.Empty;

    public static string AdvResponsavelSqlDiff(string text) => AdvResponsavel.SqlCmdTextDiff(text) ?? string.Empty;
    public static string AdvResponsavelSqlLike(string text) => AdvResponsavel.SqlCmdTextLike(text) ?? string.Empty;
    public static string AdvResponsavelSqlLikeInit(string text) => AdvResponsavel.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string AdvResponsavelSqlLikeSpaces(string? text) => AdvResponsavel.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string SecretariaSql(string text) => Secretaria.SqlCmdTextIgual(text, 80) ?? string.Empty;
    public static string SecretariaSqlNotIsNull => Secretaria.SqlCmdNotIsNull() ?? string.Empty;
    public static string SecretariaSqlIsNull => Secretaria.SqlCmdIsNull() ?? string.Empty;

    public static string SecretariaSqlDiff(string text) => Secretaria.SqlCmdTextDiff(text) ?? string.Empty;
    public static string SecretariaSqlLike(string text) => Secretaria.SqlCmdTextLike(text) ?? string.Empty;
    public static string SecretariaSqlLikeInit(string text) => Secretaria.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string SecretariaSqlLikeSpaces(string? text) => Secretaria.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string InscEstSql(string text) => InscEst.SqlCmdTextIgual(text, 15) ?? string.Empty;
    public static string InscEstSqlNotIsNull => InscEst.SqlCmdNotIsNull() ?? string.Empty;
    public static string InscEstSqlIsNull => InscEst.SqlCmdIsNull() ?? string.Empty;

    public static string InscEstSqlDiff(string text) => InscEst.SqlCmdTextDiff(text) ?? string.Empty;
    public static string InscEstSqlLike(string text) => InscEst.SqlCmdTextLike(text) ?? string.Empty;
    public static string InscEstSqlLikeInit(string text) => InscEst.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string InscEstSqlLikeSpaces(string? text) => InscEst.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string CorrespondenteSql(bool valueCheck) => Correspondente.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string CorrespondenteSqlSim => Correspondente.SqlCmdBoolSim() ?? string.Empty;
    public static string CorrespondenteSqlNao => Correspondente.SqlCmdBoolNao() ?? string.Empty;

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
        EscCNPJ = 1,
        EscCasa = 2,
        EscParceria = 3,
        EscNome = 4,
        EscOAB = 5,
        EscEndereco = 6,
        EscCidade = 7,
        EscBairro = 8,
        EscCEP = 9,
        EscFone = 10,
        EscFax = 11,
        EscSite = 12,
        EscEMail = 13,
        EscOBS = 14,
        EscAdvResponsavel = 15,
        EscSecretaria = 16,
        EscInscEst = 17,
        EscCorrespondente = 18,
        EscTop = 19,
        EscEtiqueta = 20,
        EscBold = 21,
        EscGUID = 22,
        EscQuemCad = 23,
        EscDtCad = 24,
        EscQuemAtu = 25,
        EscDtAtu = 26,
        EscVisto = 27
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.EscCNPJ => EscCNPJ,
        NomesCamposTabela.EscCasa => EscCasa,
        NomesCamposTabela.EscParceria => EscParceria,
        NomesCamposTabela.EscNome => EscNome,
        NomesCamposTabela.EscOAB => EscOAB,
        NomesCamposTabela.EscEndereco => EscEndereco,
        NomesCamposTabela.EscCidade => EscCidade,
        NomesCamposTabela.EscBairro => EscBairro,
        NomesCamposTabela.EscCEP => EscCEP,
        NomesCamposTabela.EscFone => EscFone,
        NomesCamposTabela.EscFax => EscFax,
        NomesCamposTabela.EscSite => EscSite,
        NomesCamposTabela.EscEMail => EscEMail,
        NomesCamposTabela.EscOBS => EscOBS,
        NomesCamposTabela.EscAdvResponsavel => EscAdvResponsavel,
        NomesCamposTabela.EscSecretaria => EscSecretaria,
        NomesCamposTabela.EscInscEst => EscInscEst,
        NomesCamposTabela.EscCorrespondente => EscCorrespondente,
        NomesCamposTabela.EscTop => EscTop,
        NomesCamposTabela.EscEtiqueta => EscEtiqueta,
        NomesCamposTabela.EscBold => EscBold,
        NomesCamposTabela.EscGUID => EscGUID,
        NomesCamposTabela.EscQuemCad => EscQuemCad,
        NomesCamposTabela.EscDtCad => EscDtCad,
        NomesCamposTabela.EscQuemAtu => EscQuemAtu,
        NomesCamposTabela.EscDtAtu => EscDtAtu,
        NomesCamposTabela.EscVisto => EscVisto,
        _ => null
    };
}