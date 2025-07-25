using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBTerceirosDicInfo
{
    public const string CampoCodigo = "terCodigo";
    public const string CampoNome = "terNome";
    public const string TablePrefix = "ter";
    public const string Processo = "terProcesso"; // LOCALIZACAO 170523
    public const string Nome = "terNome"; // LOCALIZACAO 170523
    public const string Situacao = "terSituacao"; // LOCALIZACAO 170523
    public const string Cidade = "terCidade"; // LOCALIZACAO 170523
    public const string Endereco = "terEndereco"; // LOCALIZACAO 170523
    public const string Bairro = "terBairro"; // LOCALIZACAO 170523
    public const string CEP = "terCEP"; // LOCALIZACAO 170523
    public const string Fone = "terFone"; // LOCALIZACAO 170523
    public const string Fax = "terFax"; // LOCALIZACAO 170523
    public const string OBS = "terOBS"; // LOCALIZACAO 170523
    public const string EMail = "terEMail"; // LOCALIZACAO 170523
    public const string Class = "terClass"; // LOCALIZACAO 170523
    public const string VaraForoComarca = "terVaraForoComarca"; // LOCALIZACAO 170523
    public const string Sexo = "terSexo"; // LOCALIZACAO 170523
    public const string Bold = "terBold"; // LOCALIZACAO 170523
    public const string GUID = "terGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "terQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "terDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "terQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "terDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "terVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Processo,
        2 => Nome,
        3 => Situacao,
        4 => Cidade,
        5 => Endereco,
        6 => Bairro,
        7 => CEP,
        8 => Fone,
        9 => Fax,
        10 => OBS,
        11 => EMail,
        12 => Class,
        13 => VaraForoComarca,
        14 => Sexo,
        15 => Bold,
        16 => GUID,
        17 => QuemCad,
        18 => DtCad,
        19 => QuemAtu,
        20 => DtAtu,
        21 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "Terceiros";
#region PropriedadesDaTabela
    public static DBInfoSystem TerProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false)
    {
        Prefixo = "ter"
    }; // DBI 11 
    public static DBInfoSystem TerNome => new(0, PTabelaNome, CampoCodigo, Nome, 80, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        Prefixo = "ter"
    };
    public static DBInfoSystem TerSituacao => new(0, PTabelaNome, CampoCodigo, Situacao, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBPosicaoOutrasPartesDicInfo.CampoCodigo, DBPosicaoOutrasPartesDicInfo.TabelaNome, new DBPosicaoOutrasPartesODicInfo(), false)
    {
        Prefixo = "ter"
    }; // DBI 11 
    public static DBInfoSystem TerCidade => new(0, PTabelaNome, CampoCodigo, Cidade, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBCidadeDicInfo.CampoCodigo, DBCidadeDicInfo.TabelaNome, new DBCidadeODicInfo(), false)
    {
        Prefixo = "ter"
    }; // DBI 11 
    public static DBInfoSystem TerEndereco => new(0, PTabelaNome, CampoCodigo, Endereco, 80, DevourerOne.PEndereco, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEndereco, true, false, false)
    {
        Prefixo = "ter"
    };
    public static DBInfoSystem TerBairro => new(0, PTabelaNome, CampoCodigo, Bairro, 50, DevourerOne.PBairro, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextBairro, true, false, false)
    {
        Prefixo = "ter"
    };
    public static DBInfoSystem TerCEP => new(0, PTabelaNome, CampoCodigo, CEP, 10, DevourerOne.PCep, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCep, true, false, false)
    {
        Prefixo = "ter"
    };
    public static DBInfoSystem TerFone => new(0, PTabelaNome, CampoCodigo, Fone, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFone, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFone, true, false, false)
    {
        Prefixo = "ter"
    };
    public static DBInfoSystem TerFax => new(0, PTabelaNome, CampoCodigo, Fax, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFax, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFax, true, false, false)
    {
        Prefixo = "ter"
    };
    public static DBInfoSystem TerOBS => new(0, PTabelaNome, CampoCodigo, OBS, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemoObservacao, true, false, false)
    {
        Prefixo = "ter"
    };
    public static DBInfoSystem TerEMail => new(0, PTabelaNome, CampoCodigo, EMail, 150, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEmail, true, false, false)
    {
        Prefixo = "ter"
    };
    public static DBInfoSystem TerClass => new(0, PTabelaNome, CampoCodigo, Class, 1, DevourerOne.PClassificacao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextClassificacaoStar, true, false, false)
    {
        Prefixo = "ter"
    };
    public static DBInfoSystem TerVaraForoComarca => new(0, PTabelaNome, CampoCodigo, VaraForoComarca, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "ter"
    };
    public static DBInfoSystem TerSexo => new(0, PTabelaNome, CampoCodigo, Sexo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBooleanSexo)
    {
        Prefixo = "ter"
    };
    public static DBInfoSystem TerBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold)
    {
        IsRequired = true,
        Prefixo = "ter"
    };
    public static DBInfoSystem TerGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "ter"
    };
    public static DBInfoSystem TerQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "ter"
    }; // DBI 11 
    public static DBInfoSystem TerDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "ter"
    };
    public static DBInfoSystem TerQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "ter"
    }; // DBI 11 
    public static DBInfoSystem TerDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "ter"
    };
    public static DBInfoSystem TerVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "ter"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        TerProcesso = 1,
        TerNome = 2,
        TerSituacao = 3,
        TerCidade = 4,
        TerEndereco = 5,
        TerBairro = 6,
        TerCEP = 7,
        TerFone = 8,
        TerFax = 9,
        TerOBS = 10,
        TerEMail = 11,
        TerClass = 12,
        TerVaraForoComarca = 13,
        TerSexo = 14,
        TerBold = 15,
        TerGUID = 16,
        TerQuemCad = 17,
        TerDtCad = 18,
        TerQuemAtu = 19,
        TerDtAtu = 20,
        TerVisto = 21
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.TerProcesso => TerProcesso,
        NomesCamposTabela.TerNome => TerNome,
        NomesCamposTabela.TerSituacao => TerSituacao,
        NomesCamposTabela.TerCidade => TerCidade,
        NomesCamposTabela.TerEndereco => TerEndereco,
        NomesCamposTabela.TerBairro => TerBairro,
        NomesCamposTabela.TerCEP => TerCEP,
        NomesCamposTabela.TerFone => TerFone,
        NomesCamposTabela.TerFax => TerFax,
        NomesCamposTabela.TerOBS => TerOBS,
        NomesCamposTabela.TerEMail => TerEMail,
        NomesCamposTabela.TerClass => TerClass,
        NomesCamposTabela.TerVaraForoComarca => TerVaraForoComarca,
        NomesCamposTabela.TerSexo => TerSexo,
        NomesCamposTabela.TerBold => TerBold,
        NomesCamposTabela.TerGUID => TerGUID,
        NomesCamposTabela.TerQuemCad => TerQuemCad,
        NomesCamposTabela.TerDtCad => TerDtCad,
        NomesCamposTabela.TerQuemAtu => TerQuemAtu,
        NomesCamposTabela.TerDtAtu => TerDtAtu,
        NomesCamposTabela.TerVisto => TerVisto,
        _ => null
    };
}