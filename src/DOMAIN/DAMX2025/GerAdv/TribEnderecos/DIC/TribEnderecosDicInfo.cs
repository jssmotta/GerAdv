using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBTribEnderecosDicInfo
{
    public const string CampoCodigo = "treCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "tre";
    public const string Tribunal = "treTribunal"; // LOCALIZACAO 170523
    public const string Cidade = "treCidade"; // LOCALIZACAO 170523
    public const string Endereco = "treEndereco"; // LOCALIZACAO 170523
    public const string CEP = "treCEP"; // LOCALIZACAO 170523
    public const string Fone = "treFone"; // LOCALIZACAO 170523
    public const string Fax = "treFax"; // LOCALIZACAO 170523
    public const string OBS = "treOBS"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Tribunal,
        2 => Cidade,
        3 => Endereco,
        4 => CEP,
        5 => Fone,
        6 => Fax,
        7 => OBS,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "TribEnderecos";
#region PropriedadesDaTabela
    public static DBInfoSystem TreTribunal => new(0, PTabelaNome, CampoCodigo, Tribunal, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBTribunalDicInfo.CampoCodigo, DBTribunalDicInfo.TabelaNome, new DBTribunalODicInfo(), false)
    {
        Prefixo = "tre"
    }; // DBI 11 
    public static DBInfoSystem TreCidade => new(0, PTabelaNome, CampoCodigo, Cidade, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBCidadeDicInfo.CampoCodigo, DBCidadeDicInfo.TabelaNome, new DBCidadeODicInfo(), false)
    {
        Prefixo = "tre"
    }; // DBI 11 
    public static DBInfoSystem TreEndereco => new(0, PTabelaNome, CampoCodigo, Endereco, 80, DevourerOne.PEndereco, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEndereco, true, false, false)
    {
        Prefixo = "tre"
    };
    public static DBInfoSystem TreCEP => new(0, PTabelaNome, CampoCodigo, CEP, 10, DevourerOne.PCep, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCep, true, false, false)
    {
        Prefixo = "tre"
    };
    public static DBInfoSystem TreFone => new(0, PTabelaNome, CampoCodigo, Fone, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFone, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFone, true, false, false)
    {
        Prefixo = "tre"
    };
    public static DBInfoSystem TreFax => new(0, PTabelaNome, CampoCodigo, Fax, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFax, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFax, true, false, false)
    {
        Prefixo = "tre"
    };
    public static DBInfoSystem TreOBS => new(0, PTabelaNome, CampoCodigo, OBS, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemoObservacao, true, false, false)
    {
        Prefixo = "tre"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        TreTribunal = 1,
        TreCidade = 2,
        TreEndereco = 3,
        TreCEP = 4,
        TreFone = 5,
        TreFax = 6,
        TreOBS = 7
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.TreTribunal => TreTribunal,
        NomesCamposTabela.TreCidade => TreCidade,
        NomesCamposTabela.TreEndereco => TreEndereco,
        NomesCamposTabela.TreCEP => TreCEP,
        NomesCamposTabela.TreFone => TreFone,
        NomesCamposTabela.TreFax => TreFax,
        NomesCamposTabela.TreOBS => TreOBS,
        _ => null
    };
}