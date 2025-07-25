using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBFuncionariosDicInfo
{
    public const string CampoCodigo = "funCodigo";
    public const string CampoNome = "funNome";
    public const string TablePrefix = "fun";
    public const string EMailPro = "funEMailPro"; // LOCALIZACAO 170523
    public const string Cargo = "funCargo"; // LOCALIZACAO 170523
    public const string Nome = "funNome"; // LOCALIZACAO 170523
    public const string Funcao = "funFuncao"; // LOCALIZACAO 170523
    public const string Sexo = "funSexo"; // LOCALIZACAO 170523
    public const string Registro = "funRegistro"; // LOCALIZACAO 170523
    public const string CPF = "funCPF"; // LOCALIZACAO 170523
    public const string RG = "funRG"; // LOCALIZACAO 170523
    public const string Tipo = "funTipo"; // LOCALIZACAO 170523
    public const string Observacao = "funObservacao"; // LOCALIZACAO 170523
    public const string Endereco = "funEndereco"; // LOCALIZACAO 170523
    public const string Bairro = "funBairro"; // LOCALIZACAO 170523
    public const string Cidade = "funCidade"; // LOCALIZACAO 170523
    public const string CEP = "funCEP"; // LOCALIZACAO 170523
    public const string Contato = "funContato"; // LOCALIZACAO 170523
    public const string Fax = "funFax"; // LOCALIZACAO 170523
    public const string Fone = "funFone"; // LOCALIZACAO 170523
    public const string EMail = "funEMail"; // LOCALIZACAO 170523
    public const string Periodo_Ini = "funPeriodo_Ini"; // LOCALIZACAO 170523
    public const string Periodo_Fim = "funPeriodo_Fim"; // LOCALIZACAO 170523
    public const string CTPSNumero = "funCTPSNumero"; // LOCALIZACAO 170523
    public const string CTPSSerie = "funCTPSSerie"; // LOCALIZACAO 170523
    public const string PIS = "funPIS"; // LOCALIZACAO 170523
    public const string Salario = "funSalario"; // LOCALIZACAO 170523
    public const string CTPSDtEmissao = "funCTPSDtEmissao"; // LOCALIZACAO 170523
    public const string DtNasc = "funDtNasc"; // LOCALIZACAO 170523
    public const string Data = "funData"; // LOCALIZACAO 170523
    public const string LiberaAgenda = "funLiberaAgenda"; // LOCALIZACAO 170523
    public const string Pasta = "funPasta"; // LOCALIZACAO 170523
    public const string Class = "funClass"; // LOCALIZACAO 170523
    public const string Etiqueta = "funEtiqueta"; // LOCALIZACAO 170523
    public const string Ani = "funAni"; // LOCALIZACAO 170523
    public const string Bold = "funBold"; // LOCALIZACAO 170523
    public const string GUID = "funGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "funQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "funDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "funQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "funDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "funVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => EMailPro,
        2 => Cargo,
        3 => Nome,
        4 => Funcao,
        5 => Sexo,
        6 => Registro,
        7 => CPF,
        8 => RG,
        9 => Tipo,
        10 => Observacao,
        11 => Endereco,
        12 => Bairro,
        13 => Cidade,
        14 => CEP,
        15 => Contato,
        16 => Fax,
        17 => Fone,
        18 => EMail,
        19 => Periodo_Ini,
        20 => Periodo_Fim,
        21 => CTPSNumero,
        22 => CTPSSerie,
        23 => PIS,
        24 => Salario,
        25 => CTPSDtEmissao,
        26 => DtNasc,
        27 => Data,
        28 => LiberaAgenda,
        29 => Pasta,
        30 => Class,
        31 => Etiqueta,
        32 => Ani,
        33 => Bold,
        34 => GUID,
        35 => QuemCad,
        36 => DtCad,
        37 => QuemAtu,
        38 => DtAtu,
        39 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "Funcionarios";
#region PropriedadesDaTabela
    public static DBInfoSystem FunEMailPro => new(0, PTabelaNome, CampoCodigo, EMailPro, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEmailPro, true, false, false)
    {
        Prefixo = "fun"
    };
    public static DBInfoSystem FunCargo => new(0, PTabelaNome, CampoCodigo, Cargo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBCargosDicInfo.CampoCodigo, DBCargosDicInfo.TabelaNome, new DBCargosODicInfo(), false)
    {
        Prefixo = "fun"
    }; // DBI 11 
    public static DBInfoSystem FunNome => new(0, PTabelaNome, CampoCodigo, Nome, 60, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        Prefixo = "fun"
    };
    public static DBInfoSystem FunFuncao => new(0, PTabelaNome, CampoCodigo, Funcao, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBFuncaoDicInfo.CampoCodigo, DBFuncaoDicInfo.TabelaNome, new DBFuncaoODicInfo(), false)
    {
        Prefixo = "fun"
    }; // DBI 11 
    public static DBInfoSystem FunSexo => new(0, PTabelaNome, CampoCodigo, Sexo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBooleanSexo)
    {
        IsRequired = true,
        Prefixo = "fun"
    };
    public static DBInfoSystem FunRegistro => new(0, PTabelaNome, CampoCodigo, Registro, 20, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "fun"
    };
    public static DBInfoSystem FunCPF => new(0, PTabelaNome, CampoCodigo, CPF, 11, DevourerOne.PCpf, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCpf, true, false, false)
    {
        Prefixo = "fun"
    };
    public static DBInfoSystem FunRG => new(0, PTabelaNome, CampoCodigo, RG, 30, DevourerOne.PRg, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextRG, true, false, false)
    {
        Prefixo = "fun"
    };
    public static DBInfoSystem FunTipo => new(0, PTabelaNome, CampoCodigo, Tipo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBooleanTipoPessoa)
    {
        IsRequired = true,
        Prefixo = "fun"
    };
    public static DBInfoSystem FunObservacao => new(0, PTabelaNome, CampoCodigo, Observacao, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemoObservacao, true, false, false)
    {
        Prefixo = "fun"
    };
    public static DBInfoSystem FunEndereco => new(0, PTabelaNome, CampoCodigo, Endereco, 80, DevourerOne.PEndereco, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEndereco, true, false, false)
    {
        Prefixo = "fun"
    };
    public static DBInfoSystem FunBairro => new(0, PTabelaNome, CampoCodigo, Bairro, 50, DevourerOne.PBairro, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextBairro, true, false, false)
    {
        Prefixo = "fun"
    };
    public static DBInfoSystem FunCidade => new(0, PTabelaNome, CampoCodigo, Cidade, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBCidadeDicInfo.CampoCodigo, DBCidadeDicInfo.TabelaNome, new DBCidadeODicInfo(), false)
    {
        Prefixo = "fun"
    }; // DBI 11 
    public static DBInfoSystem FunCEP => new(0, PTabelaNome, CampoCodigo, CEP, 10, DevourerOne.PCep, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCep, true, false, false)
    {
        Prefixo = "fun"
    };
    public static DBInfoSystem FunContato => new(0, PTabelaNome, CampoCodigo, Contato, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        Prefixo = "fun"
    };
    public static DBInfoSystem FunFax => new(0, PTabelaNome, CampoCodigo, Fax, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFax, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFax, true, false, false)
    {
        Prefixo = "fun"
    };
    public static DBInfoSystem FunFone => new(0, PTabelaNome, CampoCodigo, Fone, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFone, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFone, true, false, false)
    {
        Prefixo = "fun"
    };
    public static DBInfoSystem FunEMail => new(0, PTabelaNome, CampoCodigo, EMail, 60, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEmail, true, false, false)
    {
        Prefixo = "fun"
    };
    public static DBInfoSystem FunPeriodo_Ini => new(0, PTabelaNome, CampoCodigo, Periodo_Ini, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDataInicio)
    {
        Prefixo = "fun"
    };
    public static DBInfoSystem FunPeriodo_Fim => new(0, PTabelaNome, CampoCodigo, Periodo_Fim, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDataTermino)
    {
        Prefixo = "fun"
    };
    public static DBInfoSystem FunCTPSNumero => new(0, PTabelaNome, CampoCodigo, CTPSNumero, 15, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "fun"
    };
    public static DBInfoSystem FunCTPSSerie => new(0, PTabelaNome, CampoCodigo, CTPSSerie, 10, DevourerOne.PNroSerieCtps, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCtpsserie, true, false, false)
    {
        Prefixo = "fun"
    };
    public static DBInfoSystem FunPIS => new(0, PTabelaNome, CampoCodigo, PIS, 20, DevourerOne.PNroPis, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextPis, true, false, false)
    {
        Prefixo = "fun"
    };
    public static DBInfoSystem FunSalario => new(0, PTabelaNome, CampoCodigo, Salario, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDoubleSalario)
    {
        Prefixo = "fun"
    };
    public static DBInfoSystem FunCTPSDtEmissao => new(0, PTabelaNome, CampoCodigo, CTPSDtEmissao, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "fun"
    };
    public static DBInfoSystem FunDtNasc => new(0, PTabelaNome, CampoCodigo, DtNasc, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDataNascimento)
    {
        Prefixo = "fun"
    };
    public static DBInfoSystem FunData => new(0, PTabelaNome, CampoCodigo, Data, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime)
    {
        Prefixo = "fun"
    };
    public static DBInfoSystem FunLiberaAgenda => new(0, PTabelaNome, CampoCodigo, LiberaAgenda, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "fun"
    };
    public static DBInfoSystem FunPasta => new(0, PTabelaNome, CampoCodigo, Pasta, 200, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "fun"
    };
    public static DBInfoSystem FunClass => new(0, PTabelaNome, CampoCodigo, Class, 1, DevourerOne.PClassificacao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextClassificacaoStar, true, false, false)
    {
        Prefixo = "fun"
    };
    public static DBInfoSystem FunEtiqueta => new(0, PTabelaNome, CampoCodigo, Etiqueta, DevourerOne.PCriarEtiqueta, DevourerOne.PTooltipEtiqueta, ETipoDadosSysteminfo.SysteminfoBooleanEtiqueta)
    {
        IsRequired = true,
        Prefixo = "fun"
    };
    public static DBInfoSystem FunAni => new(0, PTabelaNome, CampoCodigo, Ani, DevourerOne.PCaptionFieldAniversario, DevourerOne.PTooltipAniversario, ETipoDadosSysteminfo.SysteminfoBooleanLembrarAniversario)
    {
        IsRequired = true,
        Prefixo = "fun"
    };
    public static DBInfoSystem FunBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold)
    {
        IsRequired = true,
        Prefixo = "fun"
    };
    public static DBInfoSystem FunGUID => new(0, PTabelaNome, CampoCodigo, GUID, 150, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "fun"
    };
    public static DBInfoSystem FunQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "fun"
    }; // DBI 11 
    public static DBInfoSystem FunDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "fun"
    };
    public static DBInfoSystem FunQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "fun"
    }; // DBI 11 
    public static DBInfoSystem FunDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "fun"
    };
    public static DBInfoSystem FunVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "fun"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        FunEMailPro = 1,
        FunCargo = 2,
        FunNome = 3,
        FunFuncao = 4,
        FunSexo = 5,
        FunRegistro = 6,
        FunCPF = 7,
        FunRG = 8,
        FunTipo = 9,
        FunObservacao = 10,
        FunEndereco = 11,
        FunBairro = 12,
        FunCidade = 13,
        FunCEP = 14,
        FunContato = 15,
        FunFax = 16,
        FunFone = 17,
        FunEMail = 18,
        FunPeriodo_Ini = 19,
        FunPeriodo_Fim = 20,
        FunCTPSNumero = 21,
        FunCTPSSerie = 22,
        FunPIS = 23,
        FunSalario = 24,
        FunCTPSDtEmissao = 25,
        FunDtNasc = 26,
        FunData = 27,
        FunLiberaAgenda = 28,
        FunPasta = 29,
        FunClass = 30,
        FunEtiqueta = 31,
        FunAni = 32,
        FunBold = 33,
        FunGUID = 34,
        FunQuemCad = 35,
        FunDtCad = 36,
        FunQuemAtu = 37,
        FunDtAtu = 38,
        FunVisto = 39
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.FunEMailPro => FunEMailPro,
        NomesCamposTabela.FunCargo => FunCargo,
        NomesCamposTabela.FunNome => FunNome,
        NomesCamposTabela.FunFuncao => FunFuncao,
        NomesCamposTabela.FunSexo => FunSexo,
        NomesCamposTabela.FunRegistro => FunRegistro,
        NomesCamposTabela.FunCPF => FunCPF,
        NomesCamposTabela.FunRG => FunRG,
        NomesCamposTabela.FunTipo => FunTipo,
        NomesCamposTabela.FunObservacao => FunObservacao,
        NomesCamposTabela.FunEndereco => FunEndereco,
        NomesCamposTabela.FunBairro => FunBairro,
        NomesCamposTabela.FunCidade => FunCidade,
        NomesCamposTabela.FunCEP => FunCEP,
        NomesCamposTabela.FunContato => FunContato,
        NomesCamposTabela.FunFax => FunFax,
        NomesCamposTabela.FunFone => FunFone,
        NomesCamposTabela.FunEMail => FunEMail,
        NomesCamposTabela.FunPeriodo_Ini => FunPeriodo_Ini,
        NomesCamposTabela.FunPeriodo_Fim => FunPeriodo_Fim,
        NomesCamposTabela.FunCTPSNumero => FunCTPSNumero,
        NomesCamposTabela.FunCTPSSerie => FunCTPSSerie,
        NomesCamposTabela.FunPIS => FunPIS,
        NomesCamposTabela.FunSalario => FunSalario,
        NomesCamposTabela.FunCTPSDtEmissao => FunCTPSDtEmissao,
        NomesCamposTabela.FunDtNasc => FunDtNasc,
        NomesCamposTabela.FunData => FunData,
        NomesCamposTabela.FunLiberaAgenda => FunLiberaAgenda,
        NomesCamposTabela.FunPasta => FunPasta,
        NomesCamposTabela.FunClass => FunClass,
        NomesCamposTabela.FunEtiqueta => FunEtiqueta,
        NomesCamposTabela.FunAni => FunAni,
        NomesCamposTabela.FunBold => FunBold,
        NomesCamposTabela.FunGUID => FunGUID,
        NomesCamposTabela.FunQuemCad => FunQuemCad,
        NomesCamposTabela.FunDtCad => FunDtCad,
        NomesCamposTabela.FunQuemAtu => FunQuemAtu,
        NomesCamposTabela.FunDtAtu => FunDtAtu,
        NomesCamposTabela.FunVisto => FunVisto,
        _ => null
    };
}