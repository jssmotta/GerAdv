using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBEnderecoSistemaDicInfo
{
    public const string CampoCodigo = "estCodigo";
    public const string CampoNome = "";
    public const string TablePrefix = "est";
    public const string Cadastro = "estCadastro"; // LOCALIZACAO 170523
    public const string CadastroExCod = "estCadastroExCod"; // LOCALIZACAO 170523
    public const string TipoEnderecoSistema = "estTipoEnderecoSistema"; // LOCALIZACAO 170523
    public const string Processo = "estProcesso"; // LOCALIZACAO 170523
    public const string Motivo = "estMotivo"; // LOCALIZACAO 170523
    public const string ContatoNoLocal = "estContatoNoLocal"; // LOCALIZACAO 170523
    public const string Cidade = "estCidade"; // LOCALIZACAO 170523
    public const string Endereco = "estEndereco"; // LOCALIZACAO 170523
    public const string Bairro = "estBairro"; // LOCALIZACAO 170523
    public const string CEP = "estCEP"; // LOCALIZACAO 170523
    public const string Fone = "estFone"; // LOCALIZACAO 170523
    public const string Fax = "estFax"; // LOCALIZACAO 170523
    public const string Observacao = "estObservacao"; // LOCALIZACAO 170523
    public const string GUID = "estGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "estQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "estDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "estQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "estDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "estVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Cadastro,
        2 => CadastroExCod,
        3 => TipoEnderecoSistema,
        4 => Processo,
        5 => Motivo,
        6 => ContatoNoLocal,
        7 => Cidade,
        8 => Endereco,
        9 => Bairro,
        10 => CEP,
        11 => Fone,
        12 => Fax,
        13 => Observacao,
        14 => GUID,
        15 => QuemCad,
        16 => DtCad,
        17 => QuemAtu,
        18 => DtAtu,
        19 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "EnderecoSistema";
#region PropriedadesDaTabela
    public static DBInfoSystem EstCadastro => new(0, PTabelaNome, CampoCodigo, Cadastro, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        IsRequired = true,
        Prefixo = "est"
    };
    public static DBInfoSystem EstCadastroExCod => new(0, PTabelaNome, CampoCodigo, CadastroExCod, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        IsRequired = true,
        Prefixo = "est"
    };
    public static DBInfoSystem EstTipoEnderecoSistema => new(0, PTabelaNome, CampoCodigo, TipoEnderecoSistema, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBTipoEnderecoSistemaDicInfo.CampoCodigo, DBTipoEnderecoSistemaDicInfo.TabelaNome, new DBTipoEnderecoSistemaODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "est"
    }; // DBI 11 
    public static DBInfoSystem EstProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false)
    {
        Prefixo = "est"
    }; // DBI 11 
    public static DBInfoSystem EstMotivo => new(0, PTabelaNome, CampoCodigo, Motivo, 200, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "est"
    };
    public static DBInfoSystem EstContatoNoLocal => new(0, PTabelaNome, CampoCodigo, ContatoNoLocal, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "est"
    };
    public static DBInfoSystem EstCidade => new(0, PTabelaNome, CampoCodigo, Cidade, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBCidadeDicInfo.CampoCodigo, DBCidadeDicInfo.TabelaNome, new DBCidadeODicInfo(), false)
    {
        Prefixo = "est"
    }; // DBI 11 
    public static DBInfoSystem EstEndereco => new(0, PTabelaNome, CampoCodigo, Endereco, 150, DevourerOne.PEndereco, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEndereco, true, false, false)
    {
        Prefixo = "est"
    };
    public static DBInfoSystem EstBairro => new(0, PTabelaNome, CampoCodigo, Bairro, 50, DevourerOne.PBairro, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextBairro, true, false, false)
    {
        Prefixo = "est"
    };
    public static DBInfoSystem EstCEP => new(0, PTabelaNome, CampoCodigo, CEP, 10, DevourerOne.PCep, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCep, true, false, false)
    {
        Prefixo = "est"
    };
    public static DBInfoSystem EstFone => new(0, PTabelaNome, CampoCodigo, Fone, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFone, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFone, true, false, false)
    {
        Prefixo = "est"
    };
    public static DBInfoSystem EstFax => new(0, PTabelaNome, CampoCodigo, Fax, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFax, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFax, true, false, false)
    {
        Prefixo = "est"
    };
    public static DBInfoSystem EstObservacao => new(0, PTabelaNome, CampoCodigo, Observacao, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemoObservacao, true, false, false)
    {
        Prefixo = "est"
    };
    public static DBInfoSystem EstGUID => new(0, PTabelaNome, CampoCodigo, GUID, 150, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        IsRequired = true,
        Prefixo = "est"
    };
    public static DBInfoSystem EstQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        IsRequired = true,
        Prefixo = "est"
    }; // DBI 11 
    public static DBInfoSystem EstDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        IsRequired = true,
        Prefixo = "est"
    };
    public static DBInfoSystem EstQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "est"
    }; // DBI 11 
    public static DBInfoSystem EstDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "est"
    };
    public static DBInfoSystem EstVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        Prefixo = "est"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        EstCadastro = 1,
        EstCadastroExCod = 2,
        EstTipoEnderecoSistema = 3,
        EstProcesso = 4,
        EstMotivo = 5,
        EstContatoNoLocal = 6,
        EstCidade = 7,
        EstEndereco = 8,
        EstBairro = 9,
        EstCEP = 10,
        EstFone = 11,
        EstFax = 12,
        EstObservacao = 13,
        EstGUID = 14,
        EstQuemCad = 15,
        EstDtCad = 16,
        EstQuemAtu = 17,
        EstDtAtu = 18,
        EstVisto = 19
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.EstCadastro => EstCadastro,
        NomesCamposTabela.EstCadastroExCod => EstCadastroExCod,
        NomesCamposTabela.EstTipoEnderecoSistema => EstTipoEnderecoSistema,
        NomesCamposTabela.EstProcesso => EstProcesso,
        NomesCamposTabela.EstMotivo => EstMotivo,
        NomesCamposTabela.EstContatoNoLocal => EstContatoNoLocal,
        NomesCamposTabela.EstCidade => EstCidade,
        NomesCamposTabela.EstEndereco => EstEndereco,
        NomesCamposTabela.EstBairro => EstBairro,
        NomesCamposTabela.EstCEP => EstCEP,
        NomesCamposTabela.EstFone => EstFone,
        NomesCamposTabela.EstFax => EstFax,
        NomesCamposTabela.EstObservacao => EstObservacao,
        NomesCamposTabela.EstGUID => EstGUID,
        NomesCamposTabela.EstQuemCad => EstQuemCad,
        NomesCamposTabela.EstDtCad => EstDtCad,
        NomesCamposTabela.EstQuemAtu => EstQuemAtu,
        NomesCamposTabela.EstDtAtu => EstDtAtu,
        NomesCamposTabela.EstVisto => EstVisto,
        _ => null
    };
}