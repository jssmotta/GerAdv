using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public static partial class DBAgendaRelatorioDicInfo
{
    public const string CampoCodigo = "vqaCodigo";
    public const string CampoNome = "advNome";
    public const string TablePrefix = "xxx";
    public const string Data = "vqaData"; // LOCALIZACAO 170523
    public const string Processo = "vqaProcesso"; // LOCALIZACAO 170523
    public const string ParaNome = "xxxParaNome"; // LOCALIZACAO 170523
    public const string ParaPessoas = "xxxParaPessoas"; // LOCALIZACAO 170523
    public const string BoxAudiencia = "xxxBoxAudiencia"; // LOCALIZACAO 170523
    public const string BoxAudienciaMobile = "xxxBoxAudienciaMobile"; // LOCALIZACAO 170523
    public const string NomeAdvogado = "xxxNomeAdvogado"; // LOCALIZACAO 170523
    public const string NomeForo = "xxxNomeForo"; // LOCALIZACAO 170523
    public const string NomeJustica = "xxxNomeJustica"; // LOCALIZACAO 170523
    public const string NomeArea = "xxxNomeArea"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Data,
        2 => Processo,
        3 => ParaNome,
        4 => ParaPessoas,
        5 => BoxAudiencia,
        6 => BoxAudienciaMobile,
        7 => NomeAdvogado,
        8 => NomeForo,
        9 => NomeJustica,
        10 => NomeArea,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "AgendaRelatorio";
#region PropriedadesDaTabela
    public static DBInfoSystem VqaData => new(0, PTabelaNome, CampoCodigo, Data, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem VqaProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false); // DBI 11 
    public static DBInfoSystem XxxParaNome => new(0, PTabelaNome, CampoCodigo, ParaNome, 60, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem XxxParaPessoas => new(0, PTabelaNome, CampoCodigo, ParaPessoas, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false);
    public static DBInfoSystem XxxBoxAudiencia => new(0, PTabelaNome, CampoCodigo, BoxAudiencia, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false);
    public static DBInfoSystem XxxBoxAudienciaMobile => new(0, PTabelaNome, CampoCodigo, BoxAudienciaMobile, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false);
    public static DBInfoSystem XxxNomeAdvogado => new(0, PTabelaNome, CampoCodigo, NomeAdvogado, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem XxxNomeForo => new(0, PTabelaNome, CampoCodigo, NomeForo, 40, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem XxxNomeJustica => new(0, PTabelaNome, CampoCodigo, NomeJustica, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem XxxNomeArea => new(0, PTabelaNome, CampoCodigo, NomeArea, 40, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);

#endregion
#region SMART_SQLServices 
#endregion // 005 " : string.Empty)} 

    [Serializable]
    public enum NomesCamposTabela
    {
        VqaData = 1,
        VqaProcesso = 2,
        XxxParaNome = 3,
        XxxParaPessoas = 4,
        XxxBoxAudiencia = 5,
        XxxBoxAudienciaMobile = 6,
        XxxNomeAdvogado = 7,
        XxxNomeForo = 8,
        XxxNomeJustica = 9,
        XxxNomeArea = 10
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.VqaData => VqaData,
        NomesCamposTabela.VqaProcesso => VqaProcesso,
        NomesCamposTabela.XxxParaNome => XxxParaNome,
        NomesCamposTabela.XxxParaPessoas => XxxParaPessoas,
        NomesCamposTabela.XxxBoxAudiencia => XxxBoxAudiencia,
        NomesCamposTabela.XxxBoxAudienciaMobile => XxxBoxAudienciaMobile,
        NomesCamposTabela.XxxNomeAdvogado => XxxNomeAdvogado,
        NomesCamposTabela.XxxNomeForo => XxxNomeForo,
        NomesCamposTabela.XxxNomeJustica => XxxNomeJustica,
        NomesCamposTabela.XxxNomeArea => XxxNomeArea,
        _ => null
    };
}