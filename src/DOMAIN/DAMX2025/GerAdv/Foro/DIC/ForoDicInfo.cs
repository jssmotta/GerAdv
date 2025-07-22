using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBForoDicInfo
{
    public const string CampoCodigo = "forCodigo";
    public const string CampoNome = "forNome";
    public const string TablePrefix = "for";
    public const string EMail = "forEMail"; // LOCALIZACAO 170523
    public const string Nome = "forNome"; // LOCALIZACAO 170523
    public const string Unico = "forUnico"; // LOCALIZACAO 170523
    public const string Cidade = "forCidade"; // LOCALIZACAO 170523
    public const string Site = "forSite"; // LOCALIZACAO 170523
    public const string Endereco = "forEndereco"; // LOCALIZACAO 170523
    public const string Bairro = "forBairro"; // LOCALIZACAO 170523
    public const string Fone = "forFone"; // LOCALIZACAO 170523
    public const string Fax = "forFax"; // LOCALIZACAO 170523
    public const string CEP = "forCEP"; // LOCALIZACAO 170523
    public const string OBS = "forOBS"; // LOCALIZACAO 170523
    public const string UnicoConfirmado = "forUnicoConfirmado"; // LOCALIZACAO 170523
    public const string Web = "forWeb"; // LOCALIZACAO 170523
    public const string Etiqueta = "forEtiqueta"; // LOCALIZACAO 170523
    public const string Bold = "forBold"; // LOCALIZACAO 170523
    public const string QuemCad = "forQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "forDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "forQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "forDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "forVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => EMail,
        2 => Nome,
        3 => Unico,
        4 => Cidade,
        5 => Site,
        6 => Endereco,
        7 => Bairro,
        8 => Fone,
        9 => Fax,
        10 => CEP,
        11 => OBS,
        12 => UnicoConfirmado,
        13 => Web,
        14 => Etiqueta,
        15 => Bold,
        16 => QuemCad,
        17 => DtCad,
        18 => QuemAtu,
        19 => DtAtu,
        20 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "Foro";
#region PropriedadesDaTabela
    public static DBInfoSystem ForEMail => new(0, PTabelaNome, CampoCodigo, EMail, 150, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEmail, true, false, false)
    {
        Prefixo = "for"
    };
    public static DBInfoSystem ForNome => new(0, PTabelaNome, CampoCodigo, Nome, 40, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        Prefixo = "for"
    };
    public static DBInfoSystem ForUnico => new(0, PTabelaNome, CampoCodigo, Unico, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "for"
    };
    public static DBInfoSystem ForCidade => new(0, PTabelaNome, CampoCodigo, Cidade, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBCidadeDicInfo.CampoCodigo, DBCidadeDicInfo.TabelaNome, new DBCidadeODicInfo(), false)
    {
        Prefixo = "for"
    }; // DBI 11 
    public static DBInfoSystem ForSite => new(0, PTabelaNome, CampoCodigo, Site, 150, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextWebsite, true, false, false)
    {
        Prefixo = "for"
    };
    public static DBInfoSystem ForEndereco => new(0, PTabelaNome, CampoCodigo, Endereco, 50, DevourerOne.PEndereco, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEndereco, true, false, false)
    {
        Prefixo = "for"
    };
    public static DBInfoSystem ForBairro => new(0, PTabelaNome, CampoCodigo, Bairro, 255, DevourerOne.PBairro, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextBairro, true, false, false)
    {
        Prefixo = "for"
    };
    public static DBInfoSystem ForFone => new(0, PTabelaNome, CampoCodigo, Fone, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFone, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFone, true, false, false)
    {
        Prefixo = "for"
    };
    public static DBInfoSystem ForFax => new(0, PTabelaNome, CampoCodigo, Fax, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFax, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFax, true, false, false)
    {
        Prefixo = "for"
    };
    public static DBInfoSystem ForCEP => new(0, PTabelaNome, CampoCodigo, CEP, 10, DevourerOne.PCep, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCep, true, false, false)
    {
        Prefixo = "for"
    };
    public static DBInfoSystem ForOBS => new(0, PTabelaNome, CampoCodigo, OBS, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemoObservacao, true, false, false)
    {
        Prefixo = "for"
    };
    public static DBInfoSystem ForUnicoConfirmado => new(0, PTabelaNome, CampoCodigo, UnicoConfirmado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "for"
    };
    public static DBInfoSystem ForWeb => new(0, PTabelaNome, CampoCodigo, Web, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextWebsite, true, false, false)
    {
        Prefixo = "for"
    };
    public static DBInfoSystem ForEtiqueta => new(0, PTabelaNome, CampoCodigo, Etiqueta, DevourerOne.PCriarEtiqueta, DevourerOne.PTooltipEtiqueta, ETipoDadosSysteminfo.SysteminfoBooleanEtiqueta)
    {
        IsRequired = true,
        Prefixo = "for"
    };
    public static DBInfoSystem ForBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold)
    {
        IsRequired = true,
        Prefixo = "for"
    };
    public static DBInfoSystem ForQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "for"
    }; // DBI 11 
    public static DBInfoSystem ForDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "for"
    };
    public static DBInfoSystem ForQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "for"
    }; // DBI 11 
    public static DBInfoSystem ForDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "for"
    };
    public static DBInfoSystem ForVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "for"
    };

#endregion
#region SMART_SQLServices 
    public static string EMailSql(string text) => EMail.SqlCmdTextIgual(text, 150) ?? string.Empty;
    public static string EMailSqlNotIsNull => EMail.SqlCmdNotIsNull() ?? string.Empty;
    public static string EMailSqlIsNull => EMail.SqlCmdIsNull() ?? string.Empty;

    public static string EMailSqlDiff(string text) => EMail.SqlCmdTextDiff(text) ?? string.Empty;
    public static string EMailSqlLike(string text) => EMail.SqlCmdTextLike(text) ?? string.Empty;
    public static string EMailSqlLikeInit(string text) => EMail.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string EMailSqlLikeSpaces(string? text) => EMail.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string NomeSql(string text) => Nome.SqlCmdTextIgual(text, 40) ?? string.Empty;
    public static string NomeSqlNotIsNull => Nome.SqlCmdNotIsNull() ?? string.Empty;
    public static string NomeSqlIsNull => Nome.SqlCmdIsNull() ?? string.Empty;

    public static string NomeSqlDiff(string text) => Nome.SqlCmdTextDiff(text) ?? string.Empty;
    public static string NomeSqlLike(string text) => Nome.SqlCmdTextLike(text) ?? string.Empty;
    public static string NomeSqlLikeInit(string text) => Nome.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string NomeSqlLikeSpaces(string? text) => Nome.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string UnicoSql(bool valueCheck) => Unico.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string UnicoSqlSim => Unico.SqlCmdBoolSim() ?? string.Empty;
    public static string UnicoSqlNao => Unico.SqlCmdBoolNao() ?? string.Empty;

    public static string SiteSql(string text) => Site.SqlCmdTextIgual(text, 150) ?? string.Empty;
    public static string SiteSqlNotIsNull => Site.SqlCmdNotIsNull() ?? string.Empty;
    public static string SiteSqlIsNull => Site.SqlCmdIsNull() ?? string.Empty;

    public static string SiteSqlDiff(string text) => Site.SqlCmdTextDiff(text) ?? string.Empty;
    public static string SiteSqlLike(string text) => Site.SqlCmdTextLike(text) ?? string.Empty;
    public static string SiteSqlLikeInit(string text) => Site.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string SiteSqlLikeSpaces(string? text) => Site.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string EnderecoSql(string text) => Endereco.SqlCmdTextIgual(text, 50) ?? string.Empty;
    public static string EnderecoSqlNotIsNull => Endereco.SqlCmdNotIsNull() ?? string.Empty;
    public static string EnderecoSqlIsNull => Endereco.SqlCmdIsNull() ?? string.Empty;

    public static string EnderecoSqlDiff(string text) => Endereco.SqlCmdTextDiff(text) ?? string.Empty;
    public static string EnderecoSqlLike(string text) => Endereco.SqlCmdTextLike(text) ?? string.Empty;
    public static string EnderecoSqlLikeInit(string text) => Endereco.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string EnderecoSqlLikeSpaces(string? text) => Endereco.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string BairroSql(string text) => Bairro.SqlCmdTextIgual(text, 255) ?? string.Empty;
    public static string BairroSqlNotIsNull => Bairro.SqlCmdNotIsNull() ?? string.Empty;
    public static string BairroSqlIsNull => Bairro.SqlCmdIsNull() ?? string.Empty;

    public static string BairroSqlDiff(string text) => Bairro.SqlCmdTextDiff(text) ?? string.Empty;
    public static string BairroSqlLike(string text) => Bairro.SqlCmdTextLike(text) ?? string.Empty;
    public static string BairroSqlLikeInit(string text) => Bairro.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string BairroSqlLikeSpaces(string? text) => Bairro.SqlCmdTextLikeSpaces(text) ?? string.Empty;
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
    public static string CEPSql(string text) => CEP.SqlCmdTextIgual(text, 10) ?? string.Empty;
    public static string CEPSqlNotIsNull => CEP.SqlCmdNotIsNull() ?? string.Empty;
    public static string CEPSqlIsNull => CEP.SqlCmdIsNull() ?? string.Empty;

    public static string CEPSqlDiff(string text) => CEP.SqlCmdTextDiff(text) ?? string.Empty;
    public static string CEPSqlLike(string text) => CEP.SqlCmdTextLike(text) ?? string.Empty;
    public static string CEPSqlLikeInit(string text) => CEP.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string CEPSqlLikeSpaces(string? text) => CEP.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string OBSSql(string text) => OBS.SqlCmdTextIgual(text) ?? string.Empty;
    public static string OBSSqlNotIsNull => OBS.SqlCmdNotIsNull() ?? string.Empty;
    public static string OBSSqlIsNull => OBS.SqlCmdIsNull() ?? string.Empty;

    public static string OBSSqlDiff(string text) => OBS.SqlCmdTextDiff(text) ?? string.Empty;
    public static string OBSSqlLike(string text) => OBS.SqlCmdTextLike(text) ?? string.Empty;
    public static string OBSSqlLikeInit(string text) => OBS.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string OBSSqlLikeSpaces(string? text) => OBS.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string UnicoConfirmadoSql(bool valueCheck) => UnicoConfirmado.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string UnicoConfirmadoSqlSim => UnicoConfirmado.SqlCmdBoolSim() ?? string.Empty;
    public static string UnicoConfirmadoSqlNao => UnicoConfirmado.SqlCmdBoolNao() ?? string.Empty;

    public static string WebSql(string text) => Web.SqlCmdTextIgual(text, 255) ?? string.Empty;
    public static string WebSqlNotIsNull => Web.SqlCmdNotIsNull() ?? string.Empty;
    public static string WebSqlIsNull => Web.SqlCmdIsNull() ?? string.Empty;

    public static string WebSqlDiff(string text) => Web.SqlCmdTextDiff(text) ?? string.Empty;
    public static string WebSqlLike(string text) => Web.SqlCmdTextLike(text) ?? string.Empty;
    public static string WebSqlLikeInit(string text) => Web.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string WebSqlLikeSpaces(string? text) => Web.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string EtiquetaSql(bool valueCheck) => Etiqueta.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string EtiquetaSqlSim => Etiqueta.SqlCmdBoolSim() ?? string.Empty;
    public static string EtiquetaSqlNao => Etiqueta.SqlCmdBoolNao() ?? string.Empty;

    public static string BoldSql(bool valueCheck) => Bold.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string BoldSqlSim => Bold.SqlCmdBoolSim() ?? string.Empty;
    public static string BoldSqlNao => Bold.SqlCmdBoolNao() ?? string.Empty;

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
        ForEMail = 1,
        ForNome = 2,
        ForUnico = 3,
        ForCidade = 4,
        ForSite = 5,
        ForEndereco = 6,
        ForBairro = 7,
        ForFone = 8,
        ForFax = 9,
        ForCEP = 10,
        ForOBS = 11,
        ForUnicoConfirmado = 12,
        ForWeb = 13,
        ForEtiqueta = 14,
        ForBold = 15,
        ForQuemCad = 16,
        ForDtCad = 17,
        ForQuemAtu = 18,
        ForDtAtu = 19,
        ForVisto = 20
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.ForEMail => ForEMail,
        NomesCamposTabela.ForNome => ForNome,
        NomesCamposTabela.ForUnico => ForUnico,
        NomesCamposTabela.ForCidade => ForCidade,
        NomesCamposTabela.ForSite => ForSite,
        NomesCamposTabela.ForEndereco => ForEndereco,
        NomesCamposTabela.ForBairro => ForBairro,
        NomesCamposTabela.ForFone => ForFone,
        NomesCamposTabela.ForFax => ForFax,
        NomesCamposTabela.ForCEP => ForCEP,
        NomesCamposTabela.ForOBS => ForOBS,
        NomesCamposTabela.ForUnicoConfirmado => ForUnicoConfirmado,
        NomesCamposTabela.ForWeb => ForWeb,
        NomesCamposTabela.ForEtiqueta => ForEtiqueta,
        NomesCamposTabela.ForBold => ForBold,
        NomesCamposTabela.ForQuemCad => ForQuemCad,
        NomesCamposTabela.ForDtCad => ForDtCad,
        NomesCamposTabela.ForQuemAtu => ForQuemAtu,
        NomesCamposTabela.ForDtAtu => ForDtAtu,
        NomesCamposTabela.ForVisto => ForVisto,
        _ => null
    };
}