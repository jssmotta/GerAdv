using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBProDespesasDicInfo
{
    public const string CampoCodigo = "desCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "des";
    public const string LigacaoID = "desLigacaoID"; // LOCALIZACAO 170523
    public const string Cliente = "desCliente"; // LOCALIZACAO 170523
    public const string Corrigido = "desCorrigido"; // LOCALIZACAO 170523
    public const string Data = "desData"; // LOCALIZACAO 170523
    public const string ValorOriginal = "desValorOriginal"; // LOCALIZACAO 170523
    public const string Processo = "desProcesso"; // LOCALIZACAO 170523
    public const string Quitado = "desQuitado"; // LOCALIZACAO 170523
    public const string DataCorrecao = "desDataCorrecao"; // LOCALIZACAO 170523
    public const string Valor = "desValor"; // LOCALIZACAO 170523
    public const string Tipo = "desTipo"; // LOCALIZACAO 170523
    public const string Historico = "desHistorico"; // LOCALIZACAO 170523
    public const string LivroCaixa = "desLivroCaixa"; // LOCALIZACAO 170523
    public const string GUID = "desGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "desQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "desDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "desQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "desDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "desVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => LigacaoID,
        2 => Cliente,
        3 => Corrigido,
        4 => Data,
        5 => ValorOriginal,
        6 => Processo,
        7 => Quitado,
        8 => DataCorrecao,
        9 => Valor,
        10 => Tipo,
        11 => Historico,
        12 => LivroCaixa,
        13 => GUID,
        14 => QuemCad,
        15 => DtCad,
        16 => QuemAtu,
        17 => DtAtu,
        18 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "ProDespesas";
#region PropriedadesDaTabela
    public static DBInfoSystem DesLigacaoID => new(0, PTabelaNome, CampoCodigo, LigacaoID, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "des"
    };
    public static DBInfoSystem DesCliente => new(0, PTabelaNome, CampoCodigo, Cliente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBClientesDicInfo.CampoCodigo, DBClientesDicInfo.TabelaNome, new DBClientesODicInfo(), false)
    {
        Prefixo = "des"
    }; // DBI 11 
    public static DBInfoSystem DesCorrigido => new(0, PTabelaNome, CampoCodigo, Corrigido, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "des"
    };
    public static DBInfoSystem DesData => new(0, PTabelaNome, CampoCodigo, Data, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "des"
    };
    public static DBInfoSystem DesValorOriginal => new(0, PTabelaNome, CampoCodigo, ValorOriginal, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble)
    {
        Prefixo = "des"
    };
    public static DBInfoSystem DesProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false)
    {
        Prefixo = "des"
    }; // DBI 11 
    public static DBInfoSystem DesQuitado => new(0, PTabelaNome, CampoCodigo, Quitado, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "des"
    };
    public static DBInfoSystem DesDataCorrecao => new(0, PTabelaNome, CampoCodigo, DataCorrecao, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "des"
    };
    public static DBInfoSystem DesValor => new(0, PTabelaNome, CampoCodigo, Valor, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDouble)
    {
        Prefixo = "des"
    };
    public static DBInfoSystem DesTipo => new(0, PTabelaNome, CampoCodigo, Tipo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBooleanTipoPessoa)
    {
        IsRequired = true,
        Prefixo = "des"
    };
    public static DBInfoSystem DesHistorico => new(0, PTabelaNome, CampoCodigo, Historico, 100, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "des"
    };
    public static DBInfoSystem DesLivroCaixa => new(0, PTabelaNome, CampoCodigo, LivroCaixa, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "des"
    };
    public static DBInfoSystem DesGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "des"
    };
    public static DBInfoSystem DesQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "des"
    }; // DBI 11 
    public static DBInfoSystem DesDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "des"
    };
    public static DBInfoSystem DesQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "des"
    }; // DBI 11 
    public static DBInfoSystem DesDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "des"
    };
    public static DBInfoSystem DesVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "des"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        DesLigacaoID = 1,
        DesCliente = 2,
        DesCorrigido = 3,
        DesData = 4,
        DesValorOriginal = 5,
        DesProcesso = 6,
        DesQuitado = 7,
        DesDataCorrecao = 8,
        DesValor = 9,
        DesTipo = 10,
        DesHistorico = 11,
        DesLivroCaixa = 12,
        DesGUID = 13,
        DesQuemCad = 14,
        DesDtCad = 15,
        DesQuemAtu = 16,
        DesDtAtu = 17,
        DesVisto = 18
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.DesLigacaoID => DesLigacaoID,
        NomesCamposTabela.DesCliente => DesCliente,
        NomesCamposTabela.DesCorrigido => DesCorrigido,
        NomesCamposTabela.DesData => DesData,
        NomesCamposTabela.DesValorOriginal => DesValorOriginal,
        NomesCamposTabela.DesProcesso => DesProcesso,
        NomesCamposTabela.DesQuitado => DesQuitado,
        NomesCamposTabela.DesDataCorrecao => DesDataCorrecao,
        NomesCamposTabela.DesValor => DesValor,
        NomesCamposTabela.DesTipo => DesTipo,
        NomesCamposTabela.DesHistorico => DesHistorico,
        NomesCamposTabela.DesLivroCaixa => DesLivroCaixa,
        NomesCamposTabela.DesGUID => DesGUID,
        NomesCamposTabela.DesQuemCad => DesQuemCad,
        NomesCamposTabela.DesDtCad => DesDtCad,
        NomesCamposTabela.DesQuemAtu => DesQuemAtu,
        NomesCamposTabela.DesDtAtu => DesDtAtu,
        NomesCamposTabela.DesVisto => DesVisto,
        _ => null
    };
}