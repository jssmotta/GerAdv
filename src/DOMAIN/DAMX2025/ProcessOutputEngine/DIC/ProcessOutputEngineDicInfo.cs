using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public static partial class DBProcessOutputEngineDicInfo
{
    public const string CampoCodigo = "poeCodigo";
    public const string CampoNome = "poeNome";
    public const string TablePrefix = "poe";
    public const string Nome = "poeNome"; // LOCALIZACAO 170523
    public const string Database = "poeDatabase"; // LOCALIZACAO 170523
    public const string Tabela = "poeTabela"; // LOCALIZACAO 170523
    public const string Campo = "poeCampo"; // LOCALIZACAO 170523
    public const string Valor = "poeValor"; // LOCALIZACAO 170523
    public const string Output = "poeOutput"; // LOCALIZACAO 170523
    public const string Administrador = "poeAdministrador"; // LOCALIZACAO 170523
    public const string OutputSource = "poeOutputSource"; // LOCALIZACAO 170523
    public const string DisabledItem = "poeDisabledItem"; // LOCALIZACAO 170523
    public const string IDModulo = "poeIDModulo"; // LOCALIZACAO 170523
    public const string IsOnlyProcesso = "poeIsOnlyProcesso"; // LOCALIZACAO 170523
    public const string MyID = "poeMyID"; // LOCALIZACAO 170523
    public const string GUID = "poeGUID"; // LOCALIZACAO 170523
    public static string CampoCodigoDiff(int id) => CampoCodigo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string CampoCodigoSql(int id) => CampoCodigo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string CampoCodigoIsNull => CampoCodigo.SqlCmdIsNull() ?? string.Empty;
    public static string CampoCodigoNotIsNull => CampoCodigo.SqlCmdNotIsNull() ?? string.Empty;

    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Nome,
        2 => Database,
        3 => Tabela,
        4 => Campo,
        5 => Valor,
        6 => Output,
        7 => Administrador,
        8 => OutputSource,
        9 => DisabledItem,
        10 => IDModulo,
        11 => IsOnlyProcesso,
        12 => MyID,
        13 => GUID,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "ProcessOutputEngine";
#region PropriedadesDaTabela
    public static DBInfoSystem PoeNome => new(0, PTabelaNome, CampoCodigo, Nome, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false);
    public static DBInfoSystem PoeDatabase => new(0, PTabelaNome, CampoCodigo, Database, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem PoeTabela => new(0, PTabelaNome, CampoCodigo, Tabela, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem PoeCampo => new(0, PTabelaNome, CampoCodigo, Campo, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem PoeValor => new(0, PTabelaNome, CampoCodigo, Valor, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem PoeOutput => new(0, PTabelaNome, CampoCodigo, Output, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false);
    public static DBInfoSystem PoeAdministrador => new(0, PTabelaNome, CampoCodigo, Administrador, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem PoeOutputSource => new(0, PTabelaNome, CampoCodigo, OutputSource, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem PoeDisabledItem => new(0, PTabelaNome, CampoCodigo, DisabledItem, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem PoeIDModulo => new(0, PTabelaNome, CampoCodigo, IDModulo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem PoeIsOnlyProcesso => new(0, PTabelaNome, CampoCodigo, IsOnlyProcesso, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem PoeMyID => new(0, PTabelaNome, CampoCodigo, MyID, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem PoeGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false);

#endregion
    public static bool IsThisTable(string nomeTabela) => nomeTabela.ToUpper().Equals(TabelaNome.ToUpper());
#region SMART_SQLServices 
    public static string NomeSql(string text) => Nome.SqlCmdTextIgual(text, 255) ?? string.Empty;
    public static string NomeSqlNotIsNull => Nome.SqlCmdNotIsNull() ?? string.Empty;
    public static string NomeSqlIsNull => Nome.SqlCmdIsNull() ?? string.Empty;

    public static string NomeSqlDiff(string text) => Nome.SqlCmdTextDiff(text) ?? string.Empty;
    public static string NomeSqlLike(string text) => Nome.SqlCmdTextLike(text) ?? string.Empty;
    public static string NomeSqlLikeInit(string text) => Nome.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string NomeSqlLikeSpaces(string? text) => Nome.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string DatabaseSql(string text) => Database.SqlCmdTextIgual(text, 255) ?? string.Empty;
    public static string DatabaseSqlNotIsNull => Database.SqlCmdNotIsNull() ?? string.Empty;
    public static string DatabaseSqlIsNull => Database.SqlCmdIsNull() ?? string.Empty;

    public static string DatabaseSqlDiff(string text) => Database.SqlCmdTextDiff(text) ?? string.Empty;
    public static string DatabaseSqlLike(string text) => Database.SqlCmdTextLike(text) ?? string.Empty;
    public static string DatabaseSqlLikeInit(string text) => Database.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string DatabaseSqlLikeSpaces(string? text) => Database.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string TabelaSql(string text) => Tabela.SqlCmdTextIgual(text, 255) ?? string.Empty;
    public static string TabelaSqlNotIsNull => Tabela.SqlCmdNotIsNull() ?? string.Empty;
    public static string TabelaSqlIsNull => Tabela.SqlCmdIsNull() ?? string.Empty;

    public static string TabelaSqlDiff(string text) => Tabela.SqlCmdTextDiff(text) ?? string.Empty;
    public static string TabelaSqlLike(string text) => Tabela.SqlCmdTextLike(text) ?? string.Empty;
    public static string TabelaSqlLikeInit(string text) => Tabela.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string TabelaSqlLikeSpaces(string? text) => Tabela.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string CampoSql(string text) => Campo.SqlCmdTextIgual(text, 255) ?? string.Empty;
    public static string CampoSqlNotIsNull => Campo.SqlCmdNotIsNull() ?? string.Empty;
    public static string CampoSqlIsNull => Campo.SqlCmdIsNull() ?? string.Empty;

    public static string CampoSqlDiff(string text) => Campo.SqlCmdTextDiff(text) ?? string.Empty;
    public static string CampoSqlLike(string text) => Campo.SqlCmdTextLike(text) ?? string.Empty;
    public static string CampoSqlLikeInit(string text) => Campo.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string CampoSqlLikeSpaces(string? text) => Campo.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string ValorSql(string text) => Valor.SqlCmdTextIgual(text, 255) ?? string.Empty;
    public static string ValorSqlNotIsNull => Valor.SqlCmdNotIsNull() ?? string.Empty;
    public static string ValorSqlIsNull => Valor.SqlCmdIsNull() ?? string.Empty;

    public static string ValorSqlDiff(string text) => Valor.SqlCmdTextDiff(text) ?? string.Empty;
    public static string ValorSqlLike(string text) => Valor.SqlCmdTextLike(text) ?? string.Empty;
    public static string ValorSqlLikeInit(string text) => Valor.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string ValorSqlLikeSpaces(string? text) => Valor.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string OutputSql(string text) => Output.SqlCmdTextIgual(text) ?? string.Empty;
    public static string OutputSqlNotIsNull => Output.SqlCmdNotIsNull() ?? string.Empty;
    public static string OutputSqlIsNull => Output.SqlCmdIsNull() ?? string.Empty;

    public static string OutputSqlDiff(string text) => Output.SqlCmdTextDiff(text) ?? string.Empty;
    public static string OutputSqlLike(string text) => Output.SqlCmdTextLike(text) ?? string.Empty;
    public static string OutputSqlLikeInit(string text) => Output.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string OutputSqlLikeSpaces(string? text) => Output.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string AdministradorSql(bool valueCheck) => Administrador.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string AdministradorSqlSim => Administrador.SqlCmdBoolSim() ?? string.Empty;
    public static string AdministradorSqlNao => Administrador.SqlCmdBoolNao() ?? string.Empty;

    public static string OutputSourceDiff(int id) => OutputSource.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string OutputSourceSql(int id) => OutputSource.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string OutputSourceIsNull => OutputSource.SqlCmdIsNull() ?? string.Empty;
    public static string OutputSourceNotIsNull => OutputSource.SqlCmdNotIsNull() ?? string.Empty;

    public static string DisabledItemSql(bool valueCheck) => DisabledItem.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string DisabledItemSqlSim => DisabledItem.SqlCmdBoolSim() ?? string.Empty;
    public static string DisabledItemSqlNao => DisabledItem.SqlCmdBoolNao() ?? string.Empty;

    public static string IDModuloDiff(int id) => IDModulo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string IDModuloSql(int id) => IDModulo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string IDModuloIsNull => IDModulo.SqlCmdIsNull() ?? string.Empty;
    public static string IDModuloNotIsNull => IDModulo.SqlCmdNotIsNull() ?? string.Empty;

    public static string IsOnlyProcessoSql(bool valueCheck) => IsOnlyProcesso.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string IsOnlyProcessoSqlSim => IsOnlyProcesso.SqlCmdBoolSim() ?? string.Empty;
    public static string IsOnlyProcessoSqlNao => IsOnlyProcesso.SqlCmdBoolNao() ?? string.Empty;

    public static string MyIDDiff(int id) => MyID.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string MyIDSql(int id) => MyID.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string MyIDIsNull => MyID.SqlCmdIsNull() ?? string.Empty;
    public static string MyIDNotIsNull => MyID.SqlCmdNotIsNull() ?? string.Empty;

    public static string GUIDSql(string text) => GUID.SqlCmdTextIgual(text, 100) ?? string.Empty;
#endregion // 005             

    [Serializable]
    public enum NomesCamposTabela
    {
        PoeNome = 1,
        PoeDatabase = 2,
        PoeTabela = 3,
        PoeCampo = 4,
        PoeValor = 5,
        PoeOutput = 6,
        PoeAdministrador = 7,
        PoeOutputSource = 8,
        PoeDisabledItem = 9,
        PoeIDModulo = 10,
        PoeIsOnlyProcesso = 11,
        PoeMyID = 12,
        PoeGUID = 13
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.PoeNome => PoeNome,
        NomesCamposTabela.PoeDatabase => PoeDatabase,
        NomesCamposTabela.PoeTabela => PoeTabela,
        NomesCamposTabela.PoeCampo => PoeCampo,
        NomesCamposTabela.PoeValor => PoeValor,
        NomesCamposTabela.PoeOutput => PoeOutput,
        NomesCamposTabela.PoeAdministrador => PoeAdministrador,
        NomesCamposTabela.PoeOutputSource => PoeOutputSource,
        NomesCamposTabela.PoeDisabledItem => PoeDisabledItem,
        NomesCamposTabela.PoeIDModulo => PoeIDModulo,
        NomesCamposTabela.PoeIsOnlyProcesso => PoeIsOnlyProcesso,
        NomesCamposTabela.PoeMyID => PoeMyID,
        NomesCamposTabela.PoeGUID => PoeGUID,
        _ => null
    };
}