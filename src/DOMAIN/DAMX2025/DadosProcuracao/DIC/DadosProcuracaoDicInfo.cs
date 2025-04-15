using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public static partial class DBDadosProcuracaoDicInfo
{
    public const string CampoCodigo = "prcCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "prc";
    public const string Cliente = "prcCliente"; // LOCALIZACAO 170523
    public const string EstadoCivil = "prcEstadoCivil"; // LOCALIZACAO 170523
    public const string Nacionalidade = "prcNacionalidade"; // LOCALIZACAO 170523
    public const string Profissao = "prcProfissao"; // LOCALIZACAO 170523
    public const string CTPS = "prcCTPS"; // LOCALIZACAO 170523
    public const string PisPasep = "prcPisPasep"; // LOCALIZACAO 170523
    public const string Remuneracao = "prcRemuneracao"; // LOCALIZACAO 170523
    public const string Objeto = "prcObjeto"; // LOCALIZACAO 170523
    public const string GUID = "prcGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "prcQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "prcDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "prcQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "prcDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "prcVisto"; // LOCALIZACAO 170523
    public static string CampoCodigoDiff(int id) => CampoCodigo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string CampoCodigoSql(int id) => CampoCodigo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string CampoCodigoIsNull => CampoCodigo.SqlCmdIsNull() ?? string.Empty;
    public static string CampoCodigoNotIsNull => CampoCodigo.SqlCmdNotIsNull() ?? string.Empty;

    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Cliente,
        2 => EstadoCivil,
        3 => Nacionalidade,
        4 => Profissao,
        5 => CTPS,
        6 => PisPasep,
        7 => Remuneracao,
        8 => Objeto,
        9 => GUID,
        10 => QuemCad,
        11 => DtCad,
        12 => QuemAtu,
        13 => DtAtu,
        14 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "DadosProcuracao";
#region PropriedadesDaTabela
    public static DBInfoSystem PrcCliente => new(0, PTabelaNome, CampoCodigo, Cliente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBClientesDicInfo.CampoCodigo, DBClientesDicInfo.TabelaNome, new DBClientesODicInfo(), false); // DBI 11 
    public static DBInfoSystem PrcEstadoCivil => new(0, PTabelaNome, CampoCodigo, EstadoCivil, 100, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem PrcNacionalidade => new(0, PTabelaNome, CampoCodigo, Nacionalidade, 100, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem PrcProfissao => new(0, PTabelaNome, CampoCodigo, Profissao, 100, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem PrcCTPS => new(0, PTabelaNome, CampoCodigo, CTPS, 100, DevourerOne.PCarteiraTrabalhoNro, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCtps, true, false, false);
    public static DBInfoSystem PrcPisPasep => new(0, PTabelaNome, CampoCodigo, PisPasep, 100, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem PrcRemuneracao => new(0, PTabelaNome, CampoCodigo, Remuneracao, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false);
    public static DBInfoSystem PrcObjeto => new(0, PTabelaNome, CampoCodigo, Objeto, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false);
    public static DBInfoSystem PrcGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false);
    public static DBInfoSystem PrcQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem PrcDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento);
    public static DBInfoSystem PrcQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem PrcDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao);
    public static DBInfoSystem PrcVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto);

#endregion
    public static bool IsThisTable(string nomeTabela) => nomeTabela.ToUpper().Equals(TabelaNome.ToUpper());
#region SMART_SQLServices 
    public static string ClienteDiff(int id) => Cliente.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string ClienteSql(int id) => Cliente.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string ClienteIsNull => Cliente.SqlCmdIsNull() ?? string.Empty;
    public static string ClienteNotIsNull => Cliente.SqlCmdNotIsNull() ?? string.Empty;

    public static string EstadoCivilSql(string text) => EstadoCivil.SqlCmdTextIgual(text, 100) ?? string.Empty;
    public static string EstadoCivilSqlNotIsNull => EstadoCivil.SqlCmdNotIsNull() ?? string.Empty;
    public static string EstadoCivilSqlIsNull => EstadoCivil.SqlCmdIsNull() ?? string.Empty;

    public static string EstadoCivilSqlDiff(string text) => EstadoCivil.SqlCmdTextDiff(text) ?? string.Empty;
    public static string EstadoCivilSqlLike(string text) => EstadoCivil.SqlCmdTextLike(text) ?? string.Empty;
    public static string EstadoCivilSqlLikeInit(string text) => EstadoCivil.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string EstadoCivilSqlLikeSpaces(string? text) => EstadoCivil.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string NacionalidadeSql(string text) => Nacionalidade.SqlCmdTextIgual(text, 100) ?? string.Empty;
    public static string NacionalidadeSqlNotIsNull => Nacionalidade.SqlCmdNotIsNull() ?? string.Empty;
    public static string NacionalidadeSqlIsNull => Nacionalidade.SqlCmdIsNull() ?? string.Empty;

    public static string NacionalidadeSqlDiff(string text) => Nacionalidade.SqlCmdTextDiff(text) ?? string.Empty;
    public static string NacionalidadeSqlLike(string text) => Nacionalidade.SqlCmdTextLike(text) ?? string.Empty;
    public static string NacionalidadeSqlLikeInit(string text) => Nacionalidade.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string NacionalidadeSqlLikeSpaces(string? text) => Nacionalidade.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string ProfissaoSql(string text) => Profissao.SqlCmdTextIgual(text, 100) ?? string.Empty;
    public static string ProfissaoSqlNotIsNull => Profissao.SqlCmdNotIsNull() ?? string.Empty;
    public static string ProfissaoSqlIsNull => Profissao.SqlCmdIsNull() ?? string.Empty;

    public static string ProfissaoSqlDiff(string text) => Profissao.SqlCmdTextDiff(text) ?? string.Empty;
    public static string ProfissaoSqlLike(string text) => Profissao.SqlCmdTextLike(text) ?? string.Empty;
    public static string ProfissaoSqlLikeInit(string text) => Profissao.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string ProfissaoSqlLikeSpaces(string? text) => Profissao.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string CTPSSql(string text) => CTPS.SqlCmdTextIgual(text, 100) ?? string.Empty;
    public static string CTPSSqlNotIsNull => CTPS.SqlCmdNotIsNull() ?? string.Empty;
    public static string CTPSSqlIsNull => CTPS.SqlCmdIsNull() ?? string.Empty;

    public static string CTPSSqlDiff(string text) => CTPS.SqlCmdTextDiff(text) ?? string.Empty;
    public static string CTPSSqlLike(string text) => CTPS.SqlCmdTextLike(text) ?? string.Empty;
    public static string CTPSSqlLikeInit(string text) => CTPS.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string CTPSSqlLikeSpaces(string? text) => CTPS.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string PisPasepSql(string text) => PisPasep.SqlCmdTextIgual(text, 100) ?? string.Empty;
    public static string PisPasepSqlNotIsNull => PisPasep.SqlCmdNotIsNull() ?? string.Empty;
    public static string PisPasepSqlIsNull => PisPasep.SqlCmdIsNull() ?? string.Empty;

    public static string PisPasepSqlDiff(string text) => PisPasep.SqlCmdTextDiff(text) ?? string.Empty;
    public static string PisPasepSqlLike(string text) => PisPasep.SqlCmdTextLike(text) ?? string.Empty;
    public static string PisPasepSqlLikeInit(string text) => PisPasep.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string PisPasepSqlLikeSpaces(string? text) => PisPasep.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string RemuneracaoSql(string text) => Remuneracao.SqlCmdTextIgual(text) ?? string.Empty;
    public static string RemuneracaoSqlNotIsNull => Remuneracao.SqlCmdNotIsNull() ?? string.Empty;
    public static string RemuneracaoSqlIsNull => Remuneracao.SqlCmdIsNull() ?? string.Empty;

    public static string RemuneracaoSqlDiff(string text) => Remuneracao.SqlCmdTextDiff(text) ?? string.Empty;
    public static string RemuneracaoSqlLike(string text) => Remuneracao.SqlCmdTextLike(text) ?? string.Empty;
    public static string RemuneracaoSqlLikeInit(string text) => Remuneracao.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string RemuneracaoSqlLikeSpaces(string? text) => Remuneracao.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string ObjetoSql(string text) => Objeto.SqlCmdTextIgual(text) ?? string.Empty;
    public static string ObjetoSqlNotIsNull => Objeto.SqlCmdNotIsNull() ?? string.Empty;
    public static string ObjetoSqlIsNull => Objeto.SqlCmdIsNull() ?? string.Empty;

    public static string ObjetoSqlDiff(string text) => Objeto.SqlCmdTextDiff(text) ?? string.Empty;
    public static string ObjetoSqlLike(string text) => Objeto.SqlCmdTextLike(text) ?? string.Empty;
    public static string ObjetoSqlLikeInit(string text) => Objeto.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string ObjetoSqlLikeSpaces(string? text) => Objeto.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string GUIDSql(string text) => GUID.SqlCmdTextIgual(text, 100) ?? string.Empty;
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
        PrcCliente = 1,
        PrcEstadoCivil = 2,
        PrcNacionalidade = 3,
        PrcProfissao = 4,
        PrcCTPS = 5,
        PrcPisPasep = 6,
        PrcRemuneracao = 7,
        PrcObjeto = 8,
        PrcGUID = 9,
        PrcQuemCad = 10,
        PrcDtCad = 11,
        PrcQuemAtu = 12,
        PrcDtAtu = 13,
        PrcVisto = 14
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.PrcCliente => PrcCliente,
        NomesCamposTabela.PrcEstadoCivil => PrcEstadoCivil,
        NomesCamposTabela.PrcNacionalidade => PrcNacionalidade,
        NomesCamposTabela.PrcProfissao => PrcProfissao,
        NomesCamposTabela.PrcCTPS => PrcCTPS,
        NomesCamposTabela.PrcPisPasep => PrcPisPasep,
        NomesCamposTabela.PrcRemuneracao => PrcRemuneracao,
        NomesCamposTabela.PrcObjeto => PrcObjeto,
        NomesCamposTabela.PrcGUID => PrcGUID,
        NomesCamposTabela.PrcQuemCad => PrcQuemCad,
        NomesCamposTabela.PrcDtCad => PrcDtCad,
        NomesCamposTabela.PrcQuemAtu => PrcQuemAtu,
        NomesCamposTabela.PrcDtAtu => PrcDtAtu,
        NomesCamposTabela.PrcVisto => PrcVisto,
        _ => null
    };
}