using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public static partial class DBDivisaoTribunalDicInfo
{
    public const string CampoCodigo = "divCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "div";
    public const string NumCodigo = "divNumCodigo"; // LOCALIZACAO 170523
    public const string Justica = "divJustica"; // LOCALIZACAO 170523
    public const string NomeEspecial = "divNomeEspecial"; // LOCALIZACAO 170523
    public const string Area = "divArea"; // LOCALIZACAO 170523
    public const string Cidade = "divCidade"; // LOCALIZACAO 170523
    public const string Foro = "divForo"; // LOCALIZACAO 170523
    public const string Tribunal = "divTribunal"; // LOCALIZACAO 170523
    public const string CodigoDiv = "divCodigoDiv"; // LOCALIZACAO 170523
    public const string Endereco = "divEndereco"; // LOCALIZACAO 170523
    public const string Fone = "divFone"; // LOCALIZACAO 170523
    public const string Fax = "divFax"; // LOCALIZACAO 170523
    public const string CEP = "divCEP"; // LOCALIZACAO 170523
    public const string Obs = "divObs"; // LOCALIZACAO 170523
    public const string EMail = "divEMail"; // LOCALIZACAO 170523
    public const string Andar = "divAndar"; // LOCALIZACAO 170523
    public const string Etiqueta = "divEtiqueta"; // LOCALIZACAO 170523
    public const string Bold = "divBold"; // LOCALIZACAO 170523
    public const string GUID = "divGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "divQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "divDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "divQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "divDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "divVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => NumCodigo,
        2 => Justica,
        3 => NomeEspecial,
        4 => Area,
        5 => Cidade,
        6 => Foro,
        7 => Tribunal,
        8 => CodigoDiv,
        9 => Endereco,
        10 => Fone,
        11 => Fax,
        12 => CEP,
        13 => Obs,
        14 => EMail,
        15 => Andar,
        16 => Etiqueta,
        17 => Bold,
        18 => GUID,
        19 => QuemCad,
        20 => DtCad,
        21 => QuemAtu,
        22 => DtAtu,
        23 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "DivisaoTribunal";
#region PropriedadesDaTabela
    public static DBInfoSystem DivNumCodigo => new(0, PTabelaNome, CampoCodigo, NumCodigo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem DivJustica => new(0, PTabelaNome, CampoCodigo, Justica, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBJusticaDicInfo.CampoCodigo, DBJusticaDicInfo.TabelaNome, new DBJusticaODicInfo(), false); // DBI 11 
    public static DBInfoSystem DivNomeEspecial => new(0, PTabelaNome, CampoCodigo, NomeEspecial, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem DivArea => new(0, PTabelaNome, CampoCodigo, Area, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBAreaDicInfo.CampoCodigo, DBAreaDicInfo.TabelaNome, new DBAreaODicInfo(), false); // DBI 11 
    public static DBInfoSystem DivCidade => new(0, PTabelaNome, CampoCodigo, Cidade, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBCidadeDicInfo.CampoCodigo, DBCidadeDicInfo.TabelaNome, new DBCidadeODicInfo(), false); // DBI 11 
    public static DBInfoSystem DivForo => new(0, PTabelaNome, CampoCodigo, Foro, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBForoDicInfo.CampoCodigo, DBForoDicInfo.TabelaNome, new DBForoODicInfo(), false); // DBI 11 
    public static DBInfoSystem DivTribunal => new(0, PTabelaNome, CampoCodigo, Tribunal, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBTribunalDicInfo.CampoCodigo, DBTribunalDicInfo.TabelaNome, new DBTribunalODicInfo(), false); // DBI 11 
    public static DBInfoSystem DivCodigoDiv => new(0, PTabelaNome, CampoCodigo, CodigoDiv, 5, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem DivEndereco => new(0, PTabelaNome, CampoCodigo, Endereco, 40, DevourerOne.PEndereco, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEndereco, true, false, false);
    public static DBInfoSystem DivFone => new(0, PTabelaNome, CampoCodigo, Fone, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFone, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFone, true, false, false);
    public static DBInfoSystem DivFax => new(0, PTabelaNome, CampoCodigo, Fax, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFax, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFax, true, false, false);
    public static DBInfoSystem DivCEP => new(0, PTabelaNome, CampoCodigo, CEP, 10, DevourerOne.PCep, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCep, true, false, false);
    public static DBInfoSystem DivObs => new(0, PTabelaNome, CampoCodigo, Obs, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemoObservacao, true, false, false);
    public static DBInfoSystem DivEMail => new(0, PTabelaNome, CampoCodigo, EMail, 150, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEmail, true, false, false);
    public static DBInfoSystem DivAndar => new(0, PTabelaNome, CampoCodigo, Andar, 12, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem DivEtiqueta => new(0, PTabelaNome, CampoCodigo, Etiqueta, DevourerOne.PCriarEtiqueta, DevourerOne.PTooltipEtiqueta, ETipoDadosSysteminfo.SysteminfoBooleanEtiqueta);
    public static DBInfoSystem DivBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold);
    public static DBInfoSystem DivGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false);
    public static DBInfoSystem DivQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem DivDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento);
    public static DBInfoSystem DivQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem DivDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao);
    public static DBInfoSystem DivVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto);

#endregion
#region SMART_SQLServices 
    public static string NomeEspecialSql(string text) => NomeEspecial.SqlCmdTextIgual(text, 255) ?? string.Empty;
    public static string NomeEspecialSqlNotIsNull => NomeEspecial.SqlCmdNotIsNull() ?? string.Empty;
    public static string NomeEspecialSqlIsNull => NomeEspecial.SqlCmdIsNull() ?? string.Empty;

    public static string NomeEspecialSqlDiff(string text) => NomeEspecial.SqlCmdTextDiff(text) ?? string.Empty;
    public static string NomeEspecialSqlLike(string text) => NomeEspecial.SqlCmdTextLike(text) ?? string.Empty;
    public static string NomeEspecialSqlLikeInit(string text) => NomeEspecial.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string NomeEspecialSqlLikeSpaces(string? text) => NomeEspecial.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string CodigoDivSql(string text) => CodigoDiv.SqlCmdTextIgual(text, 5) ?? string.Empty;
    public static string CodigoDivSqlNotIsNull => CodigoDiv.SqlCmdNotIsNull() ?? string.Empty;
    public static string CodigoDivSqlIsNull => CodigoDiv.SqlCmdIsNull() ?? string.Empty;

    public static string CodigoDivSqlDiff(string text) => CodigoDiv.SqlCmdTextDiff(text) ?? string.Empty;
    public static string CodigoDivSqlLike(string text) => CodigoDiv.SqlCmdTextLike(text) ?? string.Empty;
    public static string CodigoDivSqlLikeInit(string text) => CodigoDiv.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string CodigoDivSqlLikeSpaces(string? text) => CodigoDiv.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string EnderecoSql(string text) => Endereco.SqlCmdTextIgual(text, 40) ?? string.Empty;
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
    public static string CEPSql(string text) => CEP.SqlCmdTextIgual(text, 10) ?? string.Empty;
    public static string CEPSqlNotIsNull => CEP.SqlCmdNotIsNull() ?? string.Empty;
    public static string CEPSqlIsNull => CEP.SqlCmdIsNull() ?? string.Empty;

    public static string CEPSqlDiff(string text) => CEP.SqlCmdTextDiff(text) ?? string.Empty;
    public static string CEPSqlLike(string text) => CEP.SqlCmdTextLike(text) ?? string.Empty;
    public static string CEPSqlLikeInit(string text) => CEP.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string CEPSqlLikeSpaces(string? text) => CEP.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string ObsSql(string text) => Obs.SqlCmdTextIgual(text) ?? string.Empty;
    public static string ObsSqlNotIsNull => Obs.SqlCmdNotIsNull() ?? string.Empty;
    public static string ObsSqlIsNull => Obs.SqlCmdIsNull() ?? string.Empty;

    public static string ObsSqlDiff(string text) => Obs.SqlCmdTextDiff(text) ?? string.Empty;
    public static string ObsSqlLike(string text) => Obs.SqlCmdTextLike(text) ?? string.Empty;
    public static string ObsSqlLikeInit(string text) => Obs.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string ObsSqlLikeSpaces(string? text) => Obs.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string EMailSql(string text) => EMail.SqlCmdTextIgual(text, 150) ?? string.Empty;
    public static string EMailSqlNotIsNull => EMail.SqlCmdNotIsNull() ?? string.Empty;
    public static string EMailSqlIsNull => EMail.SqlCmdIsNull() ?? string.Empty;

    public static string EMailSqlDiff(string text) => EMail.SqlCmdTextDiff(text) ?? string.Empty;
    public static string EMailSqlLike(string text) => EMail.SqlCmdTextLike(text) ?? string.Empty;
    public static string EMailSqlLikeInit(string text) => EMail.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string EMailSqlLikeSpaces(string? text) => EMail.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string AndarSql(string text) => Andar.SqlCmdTextIgual(text, 12) ?? string.Empty;
    public static string AndarSqlNotIsNull => Andar.SqlCmdNotIsNull() ?? string.Empty;
    public static string AndarSqlIsNull => Andar.SqlCmdIsNull() ?? string.Empty;

    public static string AndarSqlDiff(string text) => Andar.SqlCmdTextDiff(text) ?? string.Empty;
    public static string AndarSqlLike(string text) => Andar.SqlCmdTextLike(text) ?? string.Empty;
    public static string AndarSqlLikeInit(string text) => Andar.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string AndarSqlLikeSpaces(string? text) => Andar.SqlCmdTextLikeSpaces(text) ?? string.Empty;
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
        DivNumCodigo = 1,
        DivJustica = 2,
        DivNomeEspecial = 3,
        DivArea = 4,
        DivCidade = 5,
        DivForo = 6,
        DivTribunal = 7,
        DivCodigoDiv = 8,
        DivEndereco = 9,
        DivFone = 10,
        DivFax = 11,
        DivCEP = 12,
        DivObs = 13,
        DivEMail = 14,
        DivAndar = 15,
        DivEtiqueta = 16,
        DivBold = 17,
        DivGUID = 18,
        DivQuemCad = 19,
        DivDtCad = 20,
        DivQuemAtu = 21,
        DivDtAtu = 22,
        DivVisto = 23
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.DivNumCodigo => DivNumCodigo,
        NomesCamposTabela.DivJustica => DivJustica,
        NomesCamposTabela.DivNomeEspecial => DivNomeEspecial,
        NomesCamposTabela.DivArea => DivArea,
        NomesCamposTabela.DivCidade => DivCidade,
        NomesCamposTabela.DivForo => DivForo,
        NomesCamposTabela.DivTribunal => DivTribunal,
        NomesCamposTabela.DivCodigoDiv => DivCodigoDiv,
        NomesCamposTabela.DivEndereco => DivEndereco,
        NomesCamposTabela.DivFone => DivFone,
        NomesCamposTabela.DivFax => DivFax,
        NomesCamposTabela.DivCEP => DivCEP,
        NomesCamposTabela.DivObs => DivObs,
        NomesCamposTabela.DivEMail => DivEMail,
        NomesCamposTabela.DivAndar => DivAndar,
        NomesCamposTabela.DivEtiqueta => DivEtiqueta,
        NomesCamposTabela.DivBold => DivBold,
        NomesCamposTabela.DivGUID => DivGUID,
        NomesCamposTabela.DivQuemCad => DivQuemCad,
        NomesCamposTabela.DivDtCad => DivDtCad,
        NomesCamposTabela.DivQuemAtu => DivQuemAtu,
        NomesCamposTabela.DivDtAtu => DivDtAtu,
        NomesCamposTabela.DivVisto => DivVisto,
        _ => null
    };
}