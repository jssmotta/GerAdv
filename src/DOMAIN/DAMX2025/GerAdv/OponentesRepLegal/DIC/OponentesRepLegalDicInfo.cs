using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBOponentesRepLegalDicInfo
{
    public const string CampoCodigo = "oprCodigo";
    public const string CampoNome = "oprNome";
    public const string TablePrefix = "opr";
    public const string Nome = "oprNome"; // LOCALIZACAO 170523
    public const string Fone = "oprFone"; // LOCALIZACAO 170523
    public const string Oponente = "oprOponente"; // LOCALIZACAO 170523
    public const string Sexo = "oprSexo"; // LOCALIZACAO 170523
    public const string CPF = "oprCPF"; // LOCALIZACAO 170523
    public const string RG = "oprRG"; // LOCALIZACAO 170523
    public const string Endereco = "oprEndereco"; // LOCALIZACAO 170523
    public const string Bairro = "oprBairro"; // LOCALIZACAO 170523
    public const string CEP = "oprCEP"; // LOCALIZACAO 170523
    public const string Cidade = "oprCidade"; // LOCALIZACAO 170523
    public const string Fax = "oprFax"; // LOCALIZACAO 170523
    public const string EMail = "oprEMail"; // LOCALIZACAO 170523
    public const string Site = "oprSite"; // LOCALIZACAO 170523
    public const string Observacao = "oprObservacao"; // LOCALIZACAO 170523
    public const string Bold = "oprBold"; // LOCALIZACAO 170523
    public const string QuemCad = "oprQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "oprDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "oprQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "oprDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "oprVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Nome,
        2 => Fone,
        3 => Oponente,
        4 => Sexo,
        5 => CPF,
        6 => RG,
        7 => Endereco,
        8 => Bairro,
        9 => CEP,
        10 => Cidade,
        11 => Fax,
        12 => EMail,
        13 => Site,
        14 => Observacao,
        15 => Bold,
        16 => QuemCad,
        17 => DtCad,
        18 => QuemAtu,
        19 => DtAtu,
        20 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "OponentesRepLegal";
#region PropriedadesDaTabela
    public static DBInfoSystem OprNome => new(0, PTabelaNome, CampoCodigo, Nome, 80, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        Prefixo = "opr"
    };
    public static DBInfoSystem OprFone => new(0, PTabelaNome, CampoCodigo, Fone, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFone, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFone, true, false, false)
    {
        Prefixo = "opr"
    };
    public static DBInfoSystem OprOponente => new(0, PTabelaNome, CampoCodigo, Oponente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBOponentesDicInfo.CampoCodigo, DBOponentesDicInfo.TabelaNome, new DBOponentesODicInfo(), false)
    {
        Prefixo = "opr"
    }; // DBI 11 
    public static DBInfoSystem OprSexo => new(0, PTabelaNome, CampoCodigo, Sexo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBooleanSexo)
    {
        IsRequired = true,
        Prefixo = "opr"
    };
    public static DBInfoSystem OprCPF => new(0, PTabelaNome, CampoCodigo, CPF, 11, DevourerOne.PCpf, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCpf, true, false, false)
    {
        Prefixo = "opr"
    };
    public static DBInfoSystem OprRG => new(0, PTabelaNome, CampoCodigo, RG, 30, DevourerOne.PRg, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextRG, true, false, false)
    {
        Prefixo = "opr"
    };
    public static DBInfoSystem OprEndereco => new(0, PTabelaNome, CampoCodigo, Endereco, 80, DevourerOne.PEndereco, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEndereco, true, false, false)
    {
        Prefixo = "opr"
    };
    public static DBInfoSystem OprBairro => new(0, PTabelaNome, CampoCodigo, Bairro, 50, DevourerOne.PBairro, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextBairro, true, false, false)
    {
        Prefixo = "opr"
    };
    public static DBInfoSystem OprCEP => new(0, PTabelaNome, CampoCodigo, CEP, 10, DevourerOne.PCep, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCep, true, false, false)
    {
        Prefixo = "opr"
    };
    public static DBInfoSystem OprCidade => new(0, PTabelaNome, CampoCodigo, Cidade, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBCidadeDicInfo.CampoCodigo, DBCidadeDicInfo.TabelaNome, new DBCidadeODicInfo(), false)
    {
        Prefixo = "opr"
    }; // DBI 11 
    public static DBInfoSystem OprFax => new(0, PTabelaNome, CampoCodigo, Fax, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFax, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFax, true, false, false)
    {
        Prefixo = "opr"
    };
    public static DBInfoSystem OprEMail => new(0, PTabelaNome, CampoCodigo, EMail, 150, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEmail, true, false, false)
    {
        Prefixo = "opr"
    };
    public static DBInfoSystem OprSite => new(0, PTabelaNome, CampoCodigo, Site, 150, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextWebsite, true, false, false)
    {
        Prefixo = "opr"
    };
    public static DBInfoSystem OprObservacao => new(0, PTabelaNome, CampoCodigo, Observacao, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemoObservacao, true, false, false)
    {
        Prefixo = "opr"
    };
    public static DBInfoSystem OprBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold)
    {
        IsRequired = true,
        Prefixo = "opr"
    };
    public static DBInfoSystem OprQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "opr"
    }; // DBI 11 
    public static DBInfoSystem OprDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "opr"
    };
    public static DBInfoSystem OprQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "opr"
    }; // DBI 11 
    public static DBInfoSystem OprDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "opr"
    };
    public static DBInfoSystem OprVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "opr"
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
    public static string FoneSql(string text) => Fone.SqlCmdTextIgual(text) ?? string.Empty;
    public static string FoneSqlNotIsNull => Fone.SqlCmdNotIsNull() ?? string.Empty;
    public static string FoneSqlIsNull => Fone.SqlCmdIsNull() ?? string.Empty;

    public static string FoneSqlDiff(string text) => Fone.SqlCmdTextDiff(text) ?? string.Empty;
    public static string FoneSqlLike(string text) => Fone.SqlCmdTextLike(text) ?? string.Empty;
    public static string FoneSqlLikeInit(string text) => Fone.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string FoneSqlLikeSpaces(string? text) => Fone.SqlCmdTextLikeSpaces(text) ?? string.Empty;
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
    public static string RGSql(string text) => RG.SqlCmdTextIgual(text, 30) ?? string.Empty;
    public static string RGSqlNotIsNull => RG.SqlCmdNotIsNull() ?? string.Empty;
    public static string RGSqlIsNull => RG.SqlCmdIsNull() ?? string.Empty;

    public static string RGSqlDiff(string text) => RG.SqlCmdTextDiff(text) ?? string.Empty;
    public static string RGSqlLike(string text) => RG.SqlCmdTextLike(text) ?? string.Empty;
    public static string RGSqlLikeInit(string text) => RG.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string RGSqlLikeSpaces(string? text) => RG.SqlCmdTextLikeSpaces(text) ?? string.Empty;
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
    public static string FaxSql(string text) => Fax.SqlCmdTextIgual(text) ?? string.Empty;
    public static string FaxSqlNotIsNull => Fax.SqlCmdNotIsNull() ?? string.Empty;
    public static string FaxSqlIsNull => Fax.SqlCmdIsNull() ?? string.Empty;

    public static string FaxSqlDiff(string text) => Fax.SqlCmdTextDiff(text) ?? string.Empty;
    public static string FaxSqlLike(string text) => Fax.SqlCmdTextLike(text) ?? string.Empty;
    public static string FaxSqlLikeInit(string text) => Fax.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string FaxSqlLikeSpaces(string? text) => Fax.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string EMailSql(string text) => EMail.SqlCmdTextIgual(text, 150) ?? string.Empty;
    public static string EMailSqlNotIsNull => EMail.SqlCmdNotIsNull() ?? string.Empty;
    public static string EMailSqlIsNull => EMail.SqlCmdIsNull() ?? string.Empty;

    public static string EMailSqlDiff(string text) => EMail.SqlCmdTextDiff(text) ?? string.Empty;
    public static string EMailSqlLike(string text) => EMail.SqlCmdTextLike(text) ?? string.Empty;
    public static string EMailSqlLikeInit(string text) => EMail.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string EMailSqlLikeSpaces(string? text) => EMail.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string SiteSql(string text) => Site.SqlCmdTextIgual(text, 150) ?? string.Empty;
    public static string SiteSqlNotIsNull => Site.SqlCmdNotIsNull() ?? string.Empty;
    public static string SiteSqlIsNull => Site.SqlCmdIsNull() ?? string.Empty;

    public static string SiteSqlDiff(string text) => Site.SqlCmdTextDiff(text) ?? string.Empty;
    public static string SiteSqlLike(string text) => Site.SqlCmdTextLike(text) ?? string.Empty;
    public static string SiteSqlLikeInit(string text) => Site.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string SiteSqlLikeSpaces(string? text) => Site.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string ObservacaoSql(string text) => Observacao.SqlCmdTextIgual(text) ?? string.Empty;
    public static string ObservacaoSqlNotIsNull => Observacao.SqlCmdNotIsNull() ?? string.Empty;
    public static string ObservacaoSqlIsNull => Observacao.SqlCmdIsNull() ?? string.Empty;

    public static string ObservacaoSqlDiff(string text) => Observacao.SqlCmdTextDiff(text) ?? string.Empty;
    public static string ObservacaoSqlLike(string text) => Observacao.SqlCmdTextLike(text) ?? string.Empty;
    public static string ObservacaoSqlLikeInit(string text) => Observacao.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string ObservacaoSqlLikeSpaces(string? text) => Observacao.SqlCmdTextLikeSpaces(text) ?? string.Empty;
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
        OprNome = 1,
        OprFone = 2,
        OprOponente = 3,
        OprSexo = 4,
        OprCPF = 5,
        OprRG = 6,
        OprEndereco = 7,
        OprBairro = 8,
        OprCEP = 9,
        OprCidade = 10,
        OprFax = 11,
        OprEMail = 12,
        OprSite = 13,
        OprObservacao = 14,
        OprBold = 15,
        OprQuemCad = 16,
        OprDtCad = 17,
        OprQuemAtu = 18,
        OprDtAtu = 19,
        OprVisto = 20
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.OprNome => OprNome,
        NomesCamposTabela.OprFone => OprFone,
        NomesCamposTabela.OprOponente => OprOponente,
        NomesCamposTabela.OprSexo => OprSexo,
        NomesCamposTabela.OprCPF => OprCPF,
        NomesCamposTabela.OprRG => OprRG,
        NomesCamposTabela.OprEndereco => OprEndereco,
        NomesCamposTabela.OprBairro => OprBairro,
        NomesCamposTabela.OprCEP => OprCEP,
        NomesCamposTabela.OprCidade => OprCidade,
        NomesCamposTabela.OprFax => OprFax,
        NomesCamposTabela.OprEMail => OprEMail,
        NomesCamposTabela.OprSite => OprSite,
        NomesCamposTabela.OprObservacao => OprObservacao,
        NomesCamposTabela.OprBold => OprBold,
        NomesCamposTabela.OprQuemCad => OprQuemCad,
        NomesCamposTabela.OprDtCad => OprDtCad,
        NomesCamposTabela.OprQuemAtu => OprQuemAtu,
        NomesCamposTabela.OprDtAtu => OprDtAtu,
        NomesCamposTabela.OprVisto => OprVisto,
        _ => null
    };
}