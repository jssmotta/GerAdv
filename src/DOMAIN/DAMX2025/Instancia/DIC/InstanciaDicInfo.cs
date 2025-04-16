using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public static partial class DBInstanciaDicInfo
{
    public const string CampoCodigo = "insCodigo";
    public const string CampoNome = "insNroProcesso";
    public const string TablePrefix = "ins";
    public const string LiminarPedida = "insLiminarPedida"; // LOCALIZACAO 170523
    public const string Objeto = "insObjeto"; // LOCALIZACAO 170523
    public const string StatusResultado = "insStatusResultado"; // LOCALIZACAO 170523
    public const string LiminarPendente = "insLiminarPendente"; // LOCALIZACAO 170523
    public const string InterpusemosRecurso = "insInterpusemosRecurso"; // LOCALIZACAO 170523
    public const string LiminarConcedida = "insLiminarConcedida"; // LOCALIZACAO 170523
    public const string LiminarNegada = "insLiminarNegada"; // LOCALIZACAO 170523
    public const string Processo = "insProcesso"; // LOCALIZACAO 170523
    public const string Data = "insData"; // LOCALIZACAO 170523
    public const string LiminarParcial = "insLiminarParcial"; // LOCALIZACAO 170523
    public const string LiminarResultado = "insLiminarResultado"; // LOCALIZACAO 170523
    public const string NroProcesso = "insNroProcesso"; // LOCALIZACAO 170523
    public const string Divisao = "insDivisao"; // LOCALIZACAO 170523
    public const string LiminarCliente = "insLiminarCliente"; // LOCALIZACAO 170523
    public const string Comarca = "insComarca"; // LOCALIZACAO 170523
    public const string SubDivisao = "insSubDivisao"; // LOCALIZACAO 170523
    public const string Principal = "insPrincipal"; // LOCALIZACAO 170523
    public const string Acao = "insAcao"; // LOCALIZACAO 170523
    public const string Foro = "insForo"; // LOCALIZACAO 170523
    public const string TipoRecurso = "insTipoRecurso"; // LOCALIZACAO 170523
    public const string ZKey = "insZKey"; // LOCALIZACAO 170523
    public const string ZKeyQuem = "insZKeyQuem"; // LOCALIZACAO 170523
    public const string ZKeyQuando = "insZKeyQuando"; // LOCALIZACAO 170523
    public const string NroAntigo = "insNroAntigo"; // LOCALIZACAO 170523
    public const string AccessCode = "insAccessCode"; // LOCALIZACAO 170523
    public const string Julgador = "insJulgador"; // LOCALIZACAO 170523
    public const string ZKeyIA = "insZKeyIA"; // LOCALIZACAO 170523
    public const string GUID = "insGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "insQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "insDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "insQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "insDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "insVisto"; // LOCALIZACAO 170523
    public static string CampoCodigoDiff(int id) => CampoCodigo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string CampoCodigoSql(int id) => CampoCodigo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string CampoCodigoIsNull => CampoCodigo.SqlCmdIsNull() ?? string.Empty;
    public static string CampoCodigoNotIsNull => CampoCodigo.SqlCmdNotIsNull() ?? string.Empty;

    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => LiminarPedida,
        2 => Objeto,
        3 => StatusResultado,
        4 => LiminarPendente,
        5 => InterpusemosRecurso,
        6 => LiminarConcedida,
        7 => LiminarNegada,
        8 => Processo,
        9 => Data,
        10 => LiminarParcial,
        11 => LiminarResultado,
        12 => NroProcesso,
        13 => Divisao,
        14 => LiminarCliente,
        15 => Comarca,
        16 => SubDivisao,
        17 => Principal,
        18 => Acao,
        19 => Foro,
        20 => TipoRecurso,
        21 => ZKey,
        22 => ZKeyQuem,
        23 => ZKeyQuando,
        24 => NroAntigo,
        25 => AccessCode,
        26 => Julgador,
        27 => ZKeyIA,
        28 => GUID,
        29 => QuemCad,
        30 => DtCad,
        31 => QuemAtu,
        32 => DtAtu,
        33 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "Instancia";
#region PropriedadesDaTabela
    public static DBInfoSystem InsLiminarPedida => new(0, PTabelaNome, CampoCodigo, LiminarPedida, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false);
    public static DBInfoSystem InsObjeto => new(0, PTabelaNome, CampoCodigo, Objeto, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem InsStatusResultado => new(0, PTabelaNome, CampoCodigo, StatusResultado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem InsLiminarPendente => new(0, PTabelaNome, CampoCodigo, LiminarPendente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem InsInterpusemosRecurso => new(0, PTabelaNome, CampoCodigo, InterpusemosRecurso, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem InsLiminarConcedida => new(0, PTabelaNome, CampoCodigo, LiminarConcedida, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem InsLiminarNegada => new(0, PTabelaNome, CampoCodigo, LiminarNegada, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem InsProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false); // DBI 11 
    public static DBInfoSystem InsData => new(0, PTabelaNome, CampoCodigo, Data, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem InsLiminarParcial => new(0, PTabelaNome, CampoCodigo, LiminarParcial, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem InsLiminarResultado => new(0, PTabelaNome, CampoCodigo, LiminarResultado, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false);
    public static DBInfoSystem InsNroProcesso => new(0, PTabelaNome, CampoCodigo, NroProcesso, 25, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem InsDivisao => new(0, PTabelaNome, CampoCodigo, Divisao, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem InsLiminarCliente => new(0, PTabelaNome, CampoCodigo, LiminarCliente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem InsComarca => new(0, PTabelaNome, CampoCodigo, Comarca, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem InsSubDivisao => new(0, PTabelaNome, CampoCodigo, SubDivisao, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem InsPrincipal => new(0, PTabelaNome, CampoCodigo, Principal, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem InsAcao => new(0, PTabelaNome, CampoCodigo, Acao, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBAcaoDicInfo.CampoCodigo, DBAcaoDicInfo.TabelaNome, new DBAcaoODicInfo(), false); // DBI 11 
    public static DBInfoSystem InsForo => new(0, PTabelaNome, CampoCodigo, Foro, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBForoDicInfo.CampoCodigo, DBForoDicInfo.TabelaNome, new DBForoODicInfo(), false); // DBI 11 
    public static DBInfoSystem InsTipoRecurso => new(0, PTabelaNome, CampoCodigo, TipoRecurso, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBTipoRecursoDicInfo.CampoCodigo, DBTipoRecursoDicInfo.TabelaNome, new DBTipoRecursoODicInfo(), false); // DBI 11 
    public static DBInfoSystem InsZKey => new(0, PTabelaNome, CampoCodigo, ZKey, 25, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem InsZKeyQuem => new(0, PTabelaNome, CampoCodigo, ZKeyQuem, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem InsZKeyQuando => new(0, PTabelaNome, CampoCodigo, ZKeyQuando, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem InsNroAntigo => new(0, PTabelaNome, CampoCodigo, NroAntigo, 25, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem InsAccessCode => new(0, PTabelaNome, CampoCodigo, AccessCode, 100, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem InsJulgador => new(0, PTabelaNome, CampoCodigo, Julgador, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem InsZKeyIA => new(0, PTabelaNome, CampoCodigo, ZKeyIA, 25, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem InsGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false);
    public static DBInfoSystem InsQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem InsDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento);
    public static DBInfoSystem InsQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem InsDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao);
    public static DBInfoSystem InsVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto);

#endregion
    public static bool IsThisTable(string nomeTabela) => nomeTabela.ToUpper().Equals(TabelaNome.ToUpper());
#region SMART_SQLServices 
    public static string LiminarPedidaSql(string text) => LiminarPedida.SqlCmdTextIgual(text) ?? string.Empty;
    public static string LiminarPedidaSqlNotIsNull => LiminarPedida.SqlCmdNotIsNull() ?? string.Empty;
    public static string LiminarPedidaSqlIsNull => LiminarPedida.SqlCmdIsNull() ?? string.Empty;

    public static string LiminarPedidaSqlDiff(string text) => LiminarPedida.SqlCmdTextDiff(text) ?? string.Empty;
    public static string LiminarPedidaSqlLike(string text) => LiminarPedida.SqlCmdTextLike(text) ?? string.Empty;
    public static string LiminarPedidaSqlLikeInit(string text) => LiminarPedida.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string LiminarPedidaSqlLikeSpaces(string? text) => LiminarPedida.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string ObjetoSql(string text) => Objeto.SqlCmdTextIgual(text, 255) ?? string.Empty;
    public static string ObjetoSqlNotIsNull => Objeto.SqlCmdNotIsNull() ?? string.Empty;
    public static string ObjetoSqlIsNull => Objeto.SqlCmdIsNull() ?? string.Empty;

    public static string ObjetoSqlDiff(string text) => Objeto.SqlCmdTextDiff(text) ?? string.Empty;
    public static string ObjetoSqlLike(string text) => Objeto.SqlCmdTextLike(text) ?? string.Empty;
    public static string ObjetoSqlLikeInit(string text) => Objeto.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string ObjetoSqlLikeSpaces(string? text) => Objeto.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string StatusResultadoDiff(int id) => StatusResultado.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string StatusResultadoSql(int id) => StatusResultado.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string StatusResultadoIsNull => StatusResultado.SqlCmdIsNull() ?? string.Empty;
    public static string StatusResultadoNotIsNull => StatusResultado.SqlCmdNotIsNull() ?? string.Empty;

    public static string LiminarPendenteSql(bool valueCheck) => LiminarPendente.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string LiminarPendenteSqlSim => LiminarPendente.SqlCmdBoolSim() ?? string.Empty;
    public static string LiminarPendenteSqlNao => LiminarPendente.SqlCmdBoolNao() ?? string.Empty;

    public static string InterpusemosRecursoSql(bool valueCheck) => InterpusemosRecurso.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string InterpusemosRecursoSqlSim => InterpusemosRecurso.SqlCmdBoolSim() ?? string.Empty;
    public static string InterpusemosRecursoSqlNao => InterpusemosRecurso.SqlCmdBoolNao() ?? string.Empty;

    public static string LiminarConcedidaSql(bool valueCheck) => LiminarConcedida.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string LiminarConcedidaSqlSim => LiminarConcedida.SqlCmdBoolSim() ?? string.Empty;
    public static string LiminarConcedidaSqlNao => LiminarConcedida.SqlCmdBoolNao() ?? string.Empty;

    public static string LiminarNegadaSql(bool valueCheck) => LiminarNegada.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string LiminarNegadaSqlSim => LiminarNegada.SqlCmdBoolSim() ?? string.Empty;
    public static string LiminarNegadaSqlNao => LiminarNegada.SqlCmdBoolNao() ?? string.Empty;

    public static string ProcessoDiff(int id) => Processo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string ProcessoSql(int id) => Processo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string ProcessoIsNull => Processo.SqlCmdIsNull() ?? string.Empty;
    public static string ProcessoNotIsNull => Processo.SqlCmdNotIsNull() ?? string.Empty;

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

    public static string LiminarParcialSql(bool valueCheck) => LiminarParcial.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string LiminarParcialSqlSim => LiminarParcial.SqlCmdBoolSim() ?? string.Empty;
    public static string LiminarParcialSqlNao => LiminarParcial.SqlCmdBoolNao() ?? string.Empty;

    public static string LiminarResultadoSql(string text) => LiminarResultado.SqlCmdTextIgual(text) ?? string.Empty;
    public static string LiminarResultadoSqlNotIsNull => LiminarResultado.SqlCmdNotIsNull() ?? string.Empty;
    public static string LiminarResultadoSqlIsNull => LiminarResultado.SqlCmdIsNull() ?? string.Empty;

    public static string LiminarResultadoSqlDiff(string text) => LiminarResultado.SqlCmdTextDiff(text) ?? string.Empty;
    public static string LiminarResultadoSqlLike(string text) => LiminarResultado.SqlCmdTextLike(text) ?? string.Empty;
    public static string LiminarResultadoSqlLikeInit(string text) => LiminarResultado.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string LiminarResultadoSqlLikeSpaces(string? text) => LiminarResultado.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string NroProcessoSql(string text) => NroProcesso.SqlCmdTextIgual(text, 25) ?? string.Empty;
    public static string NroProcessoSqlNotIsNull => NroProcesso.SqlCmdNotIsNull() ?? string.Empty;
    public static string NroProcessoSqlIsNull => NroProcesso.SqlCmdIsNull() ?? string.Empty;

    public static string NroProcessoSqlDiff(string text) => NroProcesso.SqlCmdTextDiff(text) ?? string.Empty;
    public static string NroProcessoSqlLike(string text) => NroProcesso.SqlCmdTextLike(text) ?? string.Empty;
    public static string NroProcessoSqlLikeInit(string text) => NroProcesso.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string NroProcessoSqlLikeSpaces(string? text) => NroProcesso.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string DivisaoDiff(int id) => Divisao.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string DivisaoSql(int id) => Divisao.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string DivisaoIsNull => Divisao.SqlCmdIsNull() ?? string.Empty;
    public static string DivisaoNotIsNull => Divisao.SqlCmdNotIsNull() ?? string.Empty;

    public static string LiminarClienteSql(bool valueCheck) => LiminarCliente.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string LiminarClienteSqlSim => LiminarCliente.SqlCmdBoolSim() ?? string.Empty;
    public static string LiminarClienteSqlNao => LiminarCliente.SqlCmdBoolNao() ?? string.Empty;

    public static string ComarcaDiff(int id) => Comarca.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string ComarcaSql(int id) => Comarca.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string ComarcaIsNull => Comarca.SqlCmdIsNull() ?? string.Empty;
    public static string ComarcaNotIsNull => Comarca.SqlCmdNotIsNull() ?? string.Empty;

    public static string SubDivisaoDiff(int id) => SubDivisao.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string SubDivisaoSql(int id) => SubDivisao.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string SubDivisaoIsNull => SubDivisao.SqlCmdIsNull() ?? string.Empty;
    public static string SubDivisaoNotIsNull => SubDivisao.SqlCmdNotIsNull() ?? string.Empty;

    public static string PrincipalSql(bool valueCheck) => Principal.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string PrincipalSqlSim => Principal.SqlCmdBoolSim() ?? string.Empty;
    public static string PrincipalSqlNao => Principal.SqlCmdBoolNao() ?? string.Empty;

    public static string AcaoDiff(int id) => Acao.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string AcaoSql(int id) => Acao.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string AcaoIsNull => Acao.SqlCmdIsNull() ?? string.Empty;
    public static string AcaoNotIsNull => Acao.SqlCmdNotIsNull() ?? string.Empty;

    public static string ForoDiff(int id) => Foro.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string ForoSql(int id) => Foro.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string ForoIsNull => Foro.SqlCmdIsNull() ?? string.Empty;
    public static string ForoNotIsNull => Foro.SqlCmdNotIsNull() ?? string.Empty;

    public static string TipoRecursoDiff(int id) => TipoRecurso.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string TipoRecursoSql(int id) => TipoRecurso.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string TipoRecursoIsNull => TipoRecurso.SqlCmdIsNull() ?? string.Empty;
    public static string TipoRecursoNotIsNull => TipoRecurso.SqlCmdNotIsNull() ?? string.Empty;

    public static string ZKeySql(string text) => ZKey.SqlCmdTextIgual(text, 25) ?? string.Empty;
    public static string ZKeySqlNotIsNull => ZKey.SqlCmdNotIsNull() ?? string.Empty;
    public static string ZKeySqlIsNull => ZKey.SqlCmdIsNull() ?? string.Empty;

    public static string ZKeySqlDiff(string text) => ZKey.SqlCmdTextDiff(text) ?? string.Empty;
    public static string ZKeySqlLike(string text) => ZKey.SqlCmdTextLike(text) ?? string.Empty;
    public static string ZKeySqlLikeInit(string text) => ZKey.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string ZKeySqlLikeSpaces(string? text) => ZKey.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string ZKeyQuemDiff(int id) => ZKeyQuem.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string ZKeyQuemSql(int id) => ZKeyQuem.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string ZKeyQuemIsNull => ZKeyQuem.SqlCmdIsNull() ?? string.Empty;
    public static string ZKeyQuemNotIsNull => ZKeyQuem.SqlCmdNotIsNull() ?? string.Empty;

    public static string ZKeyQuandoSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{ZKeyQuando}]");
    public static string ZKeyQuandoSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{ZKeyQuando}]");
    public static string ZKeyQuandoSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{ZKeyQuando}]");
    public static string ZKeyQuandoSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{ZKeyQuando}]");
    public static string ZKeyQuandoSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{ZKeyQuando}]");
    public static string ZKeyQuandoSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{ZKeyQuando}]");
    public static string ZKeyQuandoSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{ZKeyQuando}]");
    public static string ZKeyQuandoSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{ZKeyQuando}]");
    public static string ZKeyQuandoSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{ZKeyQuando}]");
    public static string ZKeyQuandoSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{ZKeyQuando}]");
    public static string ZKeyQuandoSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{ZKeyQuando}]");
    public static string ZKeyQuandoSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{ZKeyQuando}]");
    public static string ZKeyQuandoIsNull => ZKeyQuando.SqlCmdIsNull() ?? string.Empty;
    public static string ZKeyQuandoNotIsNull => ZKeyQuando.SqlCmdNotIsNull() ?? string.Empty;

    public static string NroAntigoSql(string text) => NroAntigo.SqlCmdTextIgual(text, 25) ?? string.Empty;
    public static string NroAntigoSqlNotIsNull => NroAntigo.SqlCmdNotIsNull() ?? string.Empty;
    public static string NroAntigoSqlIsNull => NroAntigo.SqlCmdIsNull() ?? string.Empty;

    public static string NroAntigoSqlDiff(string text) => NroAntigo.SqlCmdTextDiff(text) ?? string.Empty;
    public static string NroAntigoSqlLike(string text) => NroAntigo.SqlCmdTextLike(text) ?? string.Empty;
    public static string NroAntigoSqlLikeInit(string text) => NroAntigo.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string NroAntigoSqlLikeSpaces(string? text) => NroAntigo.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string AccessCodeSql(string text) => AccessCode.SqlCmdTextIgual(text, 100) ?? string.Empty;
    public static string AccessCodeSqlNotIsNull => AccessCode.SqlCmdNotIsNull() ?? string.Empty;
    public static string AccessCodeSqlIsNull => AccessCode.SqlCmdIsNull() ?? string.Empty;

    public static string AccessCodeSqlDiff(string text) => AccessCode.SqlCmdTextDiff(text) ?? string.Empty;
    public static string AccessCodeSqlLike(string text) => AccessCode.SqlCmdTextLike(text) ?? string.Empty;
    public static string AccessCodeSqlLikeInit(string text) => AccessCode.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string AccessCodeSqlLikeSpaces(string? text) => AccessCode.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string JulgadorDiff(int id) => Julgador.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string JulgadorSql(int id) => Julgador.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string JulgadorIsNull => Julgador.SqlCmdIsNull() ?? string.Empty;
    public static string JulgadorNotIsNull => Julgador.SqlCmdNotIsNull() ?? string.Empty;

    public static string ZKeyIASql(string text) => ZKeyIA.SqlCmdTextIgual(text, 25) ?? string.Empty;
    public static string ZKeyIASqlNotIsNull => ZKeyIA.SqlCmdNotIsNull() ?? string.Empty;
    public static string ZKeyIASqlIsNull => ZKeyIA.SqlCmdIsNull() ?? string.Empty;

    public static string ZKeyIASqlDiff(string text) => ZKeyIA.SqlCmdTextDiff(text) ?? string.Empty;
    public static string ZKeyIASqlLike(string text) => ZKeyIA.SqlCmdTextLike(text) ?? string.Empty;
    public static string ZKeyIASqlLikeInit(string text) => ZKeyIA.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string ZKeyIASqlLikeSpaces(string? text) => ZKeyIA.SqlCmdTextLikeSpaces(text) ?? string.Empty;
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
        InsLiminarPedida = 1,
        InsObjeto = 2,
        InsStatusResultado = 3,
        InsLiminarPendente = 4,
        InsInterpusemosRecurso = 5,
        InsLiminarConcedida = 6,
        InsLiminarNegada = 7,
        InsProcesso = 8,
        InsData = 9,
        InsLiminarParcial = 10,
        InsLiminarResultado = 11,
        InsNroProcesso = 12,
        InsDivisao = 13,
        InsLiminarCliente = 14,
        InsComarca = 15,
        InsSubDivisao = 16,
        InsPrincipal = 17,
        InsAcao = 18,
        InsForo = 19,
        InsTipoRecurso = 20,
        InsZKey = 21,
        InsZKeyQuem = 22,
        InsZKeyQuando = 23,
        InsNroAntigo = 24,
        InsAccessCode = 25,
        InsJulgador = 26,
        InsZKeyIA = 27,
        InsGUID = 28,
        InsQuemCad = 29,
        InsDtCad = 30,
        InsQuemAtu = 31,
        InsDtAtu = 32,
        InsVisto = 33
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.InsLiminarPedida => InsLiminarPedida,
        NomesCamposTabela.InsObjeto => InsObjeto,
        NomesCamposTabela.InsStatusResultado => InsStatusResultado,
        NomesCamposTabela.InsLiminarPendente => InsLiminarPendente,
        NomesCamposTabela.InsInterpusemosRecurso => InsInterpusemosRecurso,
        NomesCamposTabela.InsLiminarConcedida => InsLiminarConcedida,
        NomesCamposTabela.InsLiminarNegada => InsLiminarNegada,
        NomesCamposTabela.InsProcesso => InsProcesso,
        NomesCamposTabela.InsData => InsData,
        NomesCamposTabela.InsLiminarParcial => InsLiminarParcial,
        NomesCamposTabela.InsLiminarResultado => InsLiminarResultado,
        NomesCamposTabela.InsNroProcesso => InsNroProcesso,
        NomesCamposTabela.InsDivisao => InsDivisao,
        NomesCamposTabela.InsLiminarCliente => InsLiminarCliente,
        NomesCamposTabela.InsComarca => InsComarca,
        NomesCamposTabela.InsSubDivisao => InsSubDivisao,
        NomesCamposTabela.InsPrincipal => InsPrincipal,
        NomesCamposTabela.InsAcao => InsAcao,
        NomesCamposTabela.InsForo => InsForo,
        NomesCamposTabela.InsTipoRecurso => InsTipoRecurso,
        NomesCamposTabela.InsZKey => InsZKey,
        NomesCamposTabela.InsZKeyQuem => InsZKeyQuem,
        NomesCamposTabela.InsZKeyQuando => InsZKeyQuando,
        NomesCamposTabela.InsNroAntigo => InsNroAntigo,
        NomesCamposTabela.InsAccessCode => InsAccessCode,
        NomesCamposTabela.InsJulgador => InsJulgador,
        NomesCamposTabela.InsZKeyIA => InsZKeyIA,
        NomesCamposTabela.InsGUID => InsGUID,
        NomesCamposTabela.InsQuemCad => InsQuemCad,
        NomesCamposTabela.InsDtCad => InsDtCad,
        NomesCamposTabela.InsQuemAtu => InsQuemAtu,
        NomesCamposTabela.InsDtAtu => InsDtAtu,
        NomesCamposTabela.InsVisto => InsVisto,
        _ => null
    };
}