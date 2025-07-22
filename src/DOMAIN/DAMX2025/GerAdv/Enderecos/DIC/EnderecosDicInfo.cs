using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBEnderecosDicInfo
{
    public const string CampoCodigo = "endCodigo";
    public const string CampoNome = "endDescricao";
    public const string TablePrefix = "end";
    public const string TopIndex = "endTopIndex"; // LOCALIZACAO 170523
    public const string Descricao = "endDescricao"; // LOCALIZACAO 170523
    public const string Contato = "endContato"; // LOCALIZACAO 170523
    public const string DtNasc = "endDtNasc"; // LOCALIZACAO 170523
    public const string Endereco = "endEndereco"; // LOCALIZACAO 170523
    public const string Bairro = "endBairro"; // LOCALIZACAO 170523
    public const string Privativo = "endPrivativo"; // LOCALIZACAO 170523
    public const string AddContato = "endAddContato"; // LOCALIZACAO 170523
    public const string CEP = "endCEP"; // LOCALIZACAO 170523
    public const string OAB = "endOAB"; // LOCALIZACAO 170523
    public const string OBS = "endOBS"; // LOCALIZACAO 170523
    public const string Fone = "endFone"; // LOCALIZACAO 170523
    public const string Fax = "endFax"; // LOCALIZACAO 170523
    public const string Tratamento = "endTratamento"; // LOCALIZACAO 170523
    public const string Cidade = "endCidade"; // LOCALIZACAO 170523
    public const string Site = "endSite"; // LOCALIZACAO 170523
    public const string EMail = "endEMail"; // LOCALIZACAO 170523
    public const string Quem = "endQuem"; // LOCALIZACAO 170523
    public const string QuemIndicou = "endQuemIndicou"; // LOCALIZACAO 170523
    public const string ReportECBOnly = "endReportECBOnly"; // LOCALIZACAO 170523
    public const string Etiqueta = "endEtiqueta"; // LOCALIZACAO 170523
    public const string Ani = "endAni"; // LOCALIZACAO 170523
    public const string Bold = "endBold"; // LOCALIZACAO 170523
    public const string GUID = "endGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "endQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "endDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "endQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "endDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "endVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => TopIndex,
        2 => Descricao,
        3 => Contato,
        4 => DtNasc,
        5 => Endereco,
        6 => Bairro,
        7 => Privativo,
        8 => AddContato,
        9 => CEP,
        10 => OAB,
        11 => OBS,
        12 => Fone,
        13 => Fax,
        14 => Tratamento,
        15 => Cidade,
        16 => Site,
        17 => EMail,
        18 => Quem,
        19 => QuemIndicou,
        20 => ReportECBOnly,
        21 => Etiqueta,
        22 => Ani,
        23 => Bold,
        24 => GUID,
        25 => QuemCad,
        26 => DtCad,
        27 => QuemAtu,
        28 => DtAtu,
        29 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "Enderecos";
#region PropriedadesDaTabela
    public static DBInfoSystem EndTopIndex => new(0, PTabelaNome, CampoCodigo, TopIndex, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "end"
    };
    public static DBInfoSystem EndDescricao => new(0, PTabelaNome, CampoCodigo, Descricao, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "end"
    };
    public static DBInfoSystem EndContato => new(0, PTabelaNome, CampoCodigo, Contato, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        Prefixo = "end"
    };
    public static DBInfoSystem EndDtNasc => new(0, PTabelaNome, CampoCodigo, DtNasc, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDataNascimento)
    {
        Prefixo = "end"
    };
    public static DBInfoSystem EndEndereco => new(0, PTabelaNome, CampoCodigo, Endereco, 50, DevourerOne.PEndereco, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEndereco, true, false, false)
    {
        Prefixo = "end"
    };
    public static DBInfoSystem EndBairro => new(0, PTabelaNome, CampoCodigo, Bairro, 30, DevourerOne.PBairro, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextBairro, true, false, false)
    {
        Prefixo = "end"
    };
    public static DBInfoSystem EndPrivativo => new(0, PTabelaNome, CampoCodigo, Privativo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "end"
    };
    public static DBInfoSystem EndAddContato => new(0, PTabelaNome, CampoCodigo, AddContato, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "end"
    };
    public static DBInfoSystem EndCEP => new(0, PTabelaNome, CampoCodigo, CEP, 10, DevourerOne.PCep, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCep, true, false, false)
    {
        Prefixo = "end"
    };
    public static DBInfoSystem EndOAB => new(0, PTabelaNome, CampoCodigo, OAB, 20, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "end"
    };
    public static DBInfoSystem EndOBS => new(0, PTabelaNome, CampoCodigo, OBS, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemoObservacao, true, false, false)
    {
        Prefixo = "end"
    };
    public static DBInfoSystem EndFone => new(0, PTabelaNome, CampoCodigo, Fone, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFone, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFone, true, false, false)
    {
        Prefixo = "end"
    };
    public static DBInfoSystem EndFax => new(0, PTabelaNome, CampoCodigo, Fax, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFax, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFax, true, false, false)
    {
        Prefixo = "end"
    };
    public static DBInfoSystem EndTratamento => new(0, PTabelaNome, CampoCodigo, Tratamento, 20, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "end"
    };
    public static DBInfoSystem EndCidade => new(0, PTabelaNome, CampoCodigo, Cidade, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBCidadeDicInfo.CampoCodigo, DBCidadeDicInfo.TabelaNome, new DBCidadeODicInfo(), false)
    {
        Prefixo = "end"
    }; // DBI 11 
    public static DBInfoSystem EndSite => new(0, PTabelaNome, CampoCodigo, Site, 200, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextWebsite, true, false, false)
    {
        Prefixo = "end"
    };
    public static DBInfoSystem EndEMail => new(0, PTabelaNome, CampoCodigo, EMail, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEmail, true, false, false)
    {
        Prefixo = "end"
    };
    public static DBInfoSystem EndQuem => new(0, PTabelaNome, CampoCodigo, Quem, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "end"
    };
    public static DBInfoSystem EndQuemIndicou => new(0, PTabelaNome, CampoCodigo, QuemIndicou, 150, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "end"
    };
    public static DBInfoSystem EndReportECBOnly => new(0, PTabelaNome, CampoCodigo, ReportECBOnly, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        Prefixo = "end"
    };
    public static DBInfoSystem EndEtiqueta => new(0, PTabelaNome, CampoCodigo, Etiqueta, DevourerOne.PCriarEtiqueta, DevourerOne.PTooltipEtiqueta, ETipoDadosSysteminfo.SysteminfoBooleanEtiqueta)
    {
        IsRequired = true,
        Prefixo = "end"
    };
    public static DBInfoSystem EndAni => new(0, PTabelaNome, CampoCodigo, Ani, DevourerOne.PCaptionFieldAniversario, DevourerOne.PTooltipAniversario, ETipoDadosSysteminfo.SysteminfoBooleanLembrarAniversario)
    {
        IsRequired = true,
        Prefixo = "end"
    };
    public static DBInfoSystem EndBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold)
    {
        IsRequired = true,
        Prefixo = "end"
    };
    public static DBInfoSystem EndGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "end"
    };
    public static DBInfoSystem EndQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "end"
    }; // DBI 11 
    public static DBInfoSystem EndDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "end"
    };
    public static DBInfoSystem EndQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "end"
    }; // DBI 11 
    public static DBInfoSystem EndDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "end"
    };
    public static DBInfoSystem EndVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "end"
    };

#endregion
#region SMART_SQLServices 
    public static string TopIndexSql(bool valueCheck) => TopIndex.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string TopIndexSqlSim => TopIndex.SqlCmdBoolSim() ?? string.Empty;
    public static string TopIndexSqlNao => TopIndex.SqlCmdBoolNao() ?? string.Empty;

    public static string DescricaoSql(string text) => Descricao.SqlCmdTextIgual(text, 50) ?? string.Empty;
    public static string DescricaoSqlNotIsNull => Descricao.SqlCmdNotIsNull() ?? string.Empty;
    public static string DescricaoSqlIsNull => Descricao.SqlCmdIsNull() ?? string.Empty;

    public static string DescricaoSqlDiff(string text) => Descricao.SqlCmdTextDiff(text) ?? string.Empty;
    public static string DescricaoSqlLike(string text) => Descricao.SqlCmdTextLike(text) ?? string.Empty;
    public static string DescricaoSqlLikeInit(string text) => Descricao.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string DescricaoSqlLikeSpaces(string? text) => Descricao.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string ContatoSql(string text) => Contato.SqlCmdTextIgual(text) ?? string.Empty;
    public static string ContatoSqlNotIsNull => Contato.SqlCmdNotIsNull() ?? string.Empty;
    public static string ContatoSqlIsNull => Contato.SqlCmdIsNull() ?? string.Empty;

    public static string ContatoSqlDiff(string text) => Contato.SqlCmdTextDiff(text) ?? string.Empty;
    public static string ContatoSqlLike(string text) => Contato.SqlCmdTextLike(text) ?? string.Empty;
    public static string ContatoSqlLikeInit(string text) => Contato.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string ContatoSqlLikeSpaces(string? text) => Contato.SqlCmdTextLikeSpaces(text) ?? string.Empty;
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
    public static string PrivativoSql(bool valueCheck) => Privativo.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string PrivativoSqlSim => Privativo.SqlCmdBoolSim() ?? string.Empty;
    public static string PrivativoSqlNao => Privativo.SqlCmdBoolNao() ?? string.Empty;

    public static string AddContatoSql(bool valueCheck) => AddContato.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string AddContatoSqlSim => AddContato.SqlCmdBoolSim() ?? string.Empty;
    public static string AddContatoSqlNao => AddContato.SqlCmdBoolNao() ?? string.Empty;

    public static string CEPSql(string text) => CEP.SqlCmdTextIgual(text, 10) ?? string.Empty;
    public static string CEPSqlNotIsNull => CEP.SqlCmdNotIsNull() ?? string.Empty;
    public static string CEPSqlIsNull => CEP.SqlCmdIsNull() ?? string.Empty;

    public static string CEPSqlDiff(string text) => CEP.SqlCmdTextDiff(text) ?? string.Empty;
    public static string CEPSqlLike(string text) => CEP.SqlCmdTextLike(text) ?? string.Empty;
    public static string CEPSqlLikeInit(string text) => CEP.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string CEPSqlLikeSpaces(string? text) => CEP.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string OABSql(string text) => OAB.SqlCmdTextIgual(text, 20) ?? string.Empty;
    public static string OABSqlNotIsNull => OAB.SqlCmdNotIsNull() ?? string.Empty;
    public static string OABSqlIsNull => OAB.SqlCmdIsNull() ?? string.Empty;

    public static string OABSqlDiff(string text) => OAB.SqlCmdTextDiff(text) ?? string.Empty;
    public static string OABSqlLike(string text) => OAB.SqlCmdTextLike(text) ?? string.Empty;
    public static string OABSqlLikeInit(string text) => OAB.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string OABSqlLikeSpaces(string? text) => OAB.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string OBSSql(string text) => OBS.SqlCmdTextIgual(text) ?? string.Empty;
    public static string OBSSqlNotIsNull => OBS.SqlCmdNotIsNull() ?? string.Empty;
    public static string OBSSqlIsNull => OBS.SqlCmdIsNull() ?? string.Empty;

    public static string OBSSqlDiff(string text) => OBS.SqlCmdTextDiff(text) ?? string.Empty;
    public static string OBSSqlLike(string text) => OBS.SqlCmdTextLike(text) ?? string.Empty;
    public static string OBSSqlLikeInit(string text) => OBS.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string OBSSqlLikeSpaces(string? text) => OBS.SqlCmdTextLikeSpaces(text) ?? string.Empty;
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
    public static string TratamentoSql(string text) => Tratamento.SqlCmdTextIgual(text, 20) ?? string.Empty;
    public static string TratamentoSqlNotIsNull => Tratamento.SqlCmdNotIsNull() ?? string.Empty;
    public static string TratamentoSqlIsNull => Tratamento.SqlCmdIsNull() ?? string.Empty;

    public static string TratamentoSqlDiff(string text) => Tratamento.SqlCmdTextDiff(text) ?? string.Empty;
    public static string TratamentoSqlLike(string text) => Tratamento.SqlCmdTextLike(text) ?? string.Empty;
    public static string TratamentoSqlLikeInit(string text) => Tratamento.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string TratamentoSqlLikeSpaces(string? text) => Tratamento.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string SiteSql(string text) => Site.SqlCmdTextIgual(text, 200) ?? string.Empty;
    public static string SiteSqlNotIsNull => Site.SqlCmdNotIsNull() ?? string.Empty;
    public static string SiteSqlIsNull => Site.SqlCmdIsNull() ?? string.Empty;

    public static string SiteSqlDiff(string text) => Site.SqlCmdTextDiff(text) ?? string.Empty;
    public static string SiteSqlLike(string text) => Site.SqlCmdTextLike(text) ?? string.Empty;
    public static string SiteSqlLikeInit(string text) => Site.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string SiteSqlLikeSpaces(string? text) => Site.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string EMailSql(string text) => EMail.SqlCmdTextIgual(text, 255) ?? string.Empty;
    public static string EMailSqlNotIsNull => EMail.SqlCmdNotIsNull() ?? string.Empty;
    public static string EMailSqlIsNull => EMail.SqlCmdIsNull() ?? string.Empty;

    public static string EMailSqlDiff(string text) => EMail.SqlCmdTextDiff(text) ?? string.Empty;
    public static string EMailSqlLike(string text) => EMail.SqlCmdTextLike(text) ?? string.Empty;
    public static string EMailSqlLikeInit(string text) => EMail.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string EMailSqlLikeSpaces(string? text) => EMail.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string QuemIndicouSql(string text) => QuemIndicou.SqlCmdTextIgual(text, 150) ?? string.Empty;
    public static string QuemIndicouSqlNotIsNull => QuemIndicou.SqlCmdNotIsNull() ?? string.Empty;
    public static string QuemIndicouSqlIsNull => QuemIndicou.SqlCmdIsNull() ?? string.Empty;

    public static string QuemIndicouSqlDiff(string text) => QuemIndicou.SqlCmdTextDiff(text) ?? string.Empty;
    public static string QuemIndicouSqlLike(string text) => QuemIndicou.SqlCmdTextLike(text) ?? string.Empty;
    public static string QuemIndicouSqlLikeInit(string text) => QuemIndicou.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string QuemIndicouSqlLikeSpaces(string? text) => QuemIndicou.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string ReportECBOnlySql(bool valueCheck) => ReportECBOnly.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string ReportECBOnlySqlSim => ReportECBOnly.SqlCmdBoolSim() ?? string.Empty;
    public static string ReportECBOnlySqlNao => ReportECBOnly.SqlCmdBoolNao() ?? string.Empty;

    public static string EtiquetaSql(bool valueCheck) => Etiqueta.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string EtiquetaSqlSim => Etiqueta.SqlCmdBoolSim() ?? string.Empty;
    public static string EtiquetaSqlNao => Etiqueta.SqlCmdBoolNao() ?? string.Empty;

    public static string AniSql(bool valueCheck) => Ani.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string AniSqlSim => Ani.SqlCmdBoolSim() ?? string.Empty;
    public static string AniSqlNao => Ani.SqlCmdBoolNao() ?? string.Empty;

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
        EndTopIndex = 1,
        EndDescricao = 2,
        EndContato = 3,
        EndDtNasc = 4,
        EndEndereco = 5,
        EndBairro = 6,
        EndPrivativo = 7,
        EndAddContato = 8,
        EndCEP = 9,
        EndOAB = 10,
        EndOBS = 11,
        EndFone = 12,
        EndFax = 13,
        EndTratamento = 14,
        EndCidade = 15,
        EndSite = 16,
        EndEMail = 17,
        EndQuem = 18,
        EndQuemIndicou = 19,
        EndReportECBOnly = 20,
        EndEtiqueta = 21,
        EndAni = 22,
        EndBold = 23,
        EndGUID = 24,
        EndQuemCad = 25,
        EndDtCad = 26,
        EndQuemAtu = 27,
        EndDtAtu = 28,
        EndVisto = 29
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.EndTopIndex => EndTopIndex,
        NomesCamposTabela.EndDescricao => EndDescricao,
        NomesCamposTabela.EndContato => EndContato,
        NomesCamposTabela.EndDtNasc => EndDtNasc,
        NomesCamposTabela.EndEndereco => EndEndereco,
        NomesCamposTabela.EndBairro => EndBairro,
        NomesCamposTabela.EndPrivativo => EndPrivativo,
        NomesCamposTabela.EndAddContato => EndAddContato,
        NomesCamposTabela.EndCEP => EndCEP,
        NomesCamposTabela.EndOAB => EndOAB,
        NomesCamposTabela.EndOBS => EndOBS,
        NomesCamposTabela.EndFone => EndFone,
        NomesCamposTabela.EndFax => EndFax,
        NomesCamposTabela.EndTratamento => EndTratamento,
        NomesCamposTabela.EndCidade => EndCidade,
        NomesCamposTabela.EndSite => EndSite,
        NomesCamposTabela.EndEMail => EndEMail,
        NomesCamposTabela.EndQuem => EndQuem,
        NomesCamposTabela.EndQuemIndicou => EndQuemIndicou,
        NomesCamposTabela.EndReportECBOnly => EndReportECBOnly,
        NomesCamposTabela.EndEtiqueta => EndEtiqueta,
        NomesCamposTabela.EndAni => EndAni,
        NomesCamposTabela.EndBold => EndBold,
        NomesCamposTabela.EndGUID => EndGUID,
        NomesCamposTabela.EndQuemCad => EndQuemCad,
        NomesCamposTabela.EndDtCad => EndDtCad,
        NomesCamposTabela.EndQuemAtu => EndQuemAtu,
        NomesCamposTabela.EndDtAtu => EndDtAtu,
        NomesCamposTabela.EndVisto => EndVisto,
        _ => null
    };
}