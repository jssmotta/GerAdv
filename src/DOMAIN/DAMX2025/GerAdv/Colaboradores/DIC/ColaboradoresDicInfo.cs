using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBColaboradoresDicInfo
{
    public const string CampoCodigo = "colCodigo";
    public const string CampoNome = "colNome";
    public const string TablePrefix = "col";
    public const string Cargo = "colCargo"; // LOCALIZACAO 170523
    public const string Cliente = "colCliente"; // LOCALIZACAO 170523
    public const string Sexo = "colSexo"; // LOCALIZACAO 170523
    public const string Nome = "colNome"; // LOCALIZACAO 170523
    public const string CPF = "colCPF"; // LOCALIZACAO 170523
    public const string RG = "colRG"; // LOCALIZACAO 170523
    public const string DtNasc = "colDtNasc"; // LOCALIZACAO 170523
    public const string Idade = "colIdade"; // LOCALIZACAO 170523
    public const string Endereco = "colEndereco"; // LOCALIZACAO 170523
    public const string Bairro = "colBairro"; // LOCALIZACAO 170523
    public const string CEP = "colCEP"; // LOCALIZACAO 170523
    public const string Cidade = "colCidade"; // LOCALIZACAO 170523
    public const string Fone = "colFone"; // LOCALIZACAO 170523
    public const string Observacao = "colObservacao"; // LOCALIZACAO 170523
    public const string EMail = "colEMail"; // LOCALIZACAO 170523
    public const string CNH = "colCNH"; // LOCALIZACAO 170523
    public const string Class = "colClass"; // LOCALIZACAO 170523
    public const string Etiqueta = "colEtiqueta"; // LOCALIZACAO 170523
    public const string Ani = "colAni"; // LOCALIZACAO 170523
    public const string Bold = "colBold"; // LOCALIZACAO 170523
    public const string QuemCad = "colQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "colDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "colQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "colDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "colVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => Cargo,
        2 => Cliente,
        3 => Sexo,
        4 => Nome,
        5 => CPF,
        6 => RG,
        7 => DtNasc,
        8 => Idade,
        9 => Endereco,
        10 => Bairro,
        11 => CEP,
        12 => Cidade,
        13 => Fone,
        14 => Observacao,
        15 => EMail,
        16 => CNH,
        17 => Class,
        18 => Etiqueta,
        19 => Ani,
        20 => Bold,
        21 => QuemCad,
        22 => DtCad,
        23 => QuemAtu,
        24 => DtAtu,
        25 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "Colaboradores";
#region PropriedadesDaTabela
    public static DBInfoSystem ColCargo => new(0, PTabelaNome, CampoCodigo, Cargo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBCargosDicInfo.CampoCodigo, DBCargosDicInfo.TabelaNome, new DBCargosODicInfo(), false)
    {
        Prefixo = "col"
    }; // DBI 11 
    public static DBInfoSystem ColCliente => new(0, PTabelaNome, CampoCodigo, Cliente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBClientesDicInfo.CampoCodigo, DBClientesDicInfo.TabelaNome, new DBClientesODicInfo(), false)
    {
        Prefixo = "col"
    }; // DBI 11 
    public static DBInfoSystem ColSexo => new(0, PTabelaNome, CampoCodigo, Sexo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBooleanSexo)
    {
        IsRequired = true,
        Prefixo = "col"
    };
    public static DBInfoSystem ColNome => new(0, PTabelaNome, CampoCodigo, Nome, 80, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false)
    {
        Prefixo = "col"
    };
    public static DBInfoSystem ColCPF => new(0, PTabelaNome, CampoCodigo, CPF, 11, DevourerOne.PCpf, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCpf, true, false, false)
    {
        Prefixo = "col"
    };
    public static DBInfoSystem ColRG => new(0, PTabelaNome, CampoCodigo, RG, 30, DevourerOne.PRg, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextRG, true, false, false)
    {
        Prefixo = "col"
    };
    public static DBInfoSystem ColDtNasc => new(0, PTabelaNome, CampoCodigo, DtNasc, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDataNascimento)
    {
        Prefixo = "col"
    };
    public static DBInfoSystem ColIdade => new(0, PTabelaNome, CampoCodigo, Idade, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "col"
    };
    public static DBInfoSystem ColEndereco => new(0, PTabelaNome, CampoCodigo, Endereco, 80, DevourerOne.PEndereco, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEndereco, true, false, false)
    {
        Prefixo = "col"
    };
    public static DBInfoSystem ColBairro => new(0, PTabelaNome, CampoCodigo, Bairro, 50, DevourerOne.PBairro, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextBairro, true, false, false)
    {
        Prefixo = "col"
    };
    public static DBInfoSystem ColCEP => new(0, PTabelaNome, CampoCodigo, CEP, 10, DevourerOne.PCep, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCep, true, false, false)
    {
        Prefixo = "col"
    };
    public static DBInfoSystem ColCidade => new(0, PTabelaNome, CampoCodigo, Cidade, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBCidadeDicInfo.CampoCodigo, DBCidadeDicInfo.TabelaNome, new DBCidadeODicInfo(), false)
    {
        Prefixo = "col"
    }; // DBI 11 
    public static DBInfoSystem ColFone => new(0, PTabelaNome, CampoCodigo, Fone, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFone, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFone, true, false, false)
    {
        Prefixo = "col"
    };
    public static DBInfoSystem ColObservacao => new(0, PTabelaNome, CampoCodigo, Observacao, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemoObservacao, true, false, false)
    {
        Prefixo = "col"
    };
    public static DBInfoSystem ColEMail => new(0, PTabelaNome, CampoCodigo, EMail, 150, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEmail, true, false, false)
    {
        Prefixo = "col"
    };
    public static DBInfoSystem ColCNH => new(0, PTabelaNome, CampoCodigo, CNH, 100, DevourerOne.PCnh, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCnh, true, false, false)
    {
        Prefixo = "col"
    };
    public static DBInfoSystem ColClass => new(0, PTabelaNome, CampoCodigo, Class, 1, DevourerOne.PClassificacao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextClassificacaoStar, true, false, false)
    {
        Prefixo = "col"
    };
    public static DBInfoSystem ColEtiqueta => new(0, PTabelaNome, CampoCodigo, Etiqueta, DevourerOne.PCriarEtiqueta, DevourerOne.PTooltipEtiqueta, ETipoDadosSysteminfo.SysteminfoBooleanEtiqueta)
    {
        IsRequired = true,
        Prefixo = "col"
    };
    public static DBInfoSystem ColAni => new(0, PTabelaNome, CampoCodigo, Ani, DevourerOne.PCaptionFieldAniversario, DevourerOne.PTooltipAniversario, ETipoDadosSysteminfo.SysteminfoBooleanLembrarAniversario)
    {
        Prefixo = "col"
    };
    public static DBInfoSystem ColBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold)
    {
        IsRequired = true,
        Prefixo = "col"
    };
    public static DBInfoSystem ColQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "col"
    }; // DBI 11 
    public static DBInfoSystem ColDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "col"
    };
    public static DBInfoSystem ColQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "col"
    }; // DBI 11 
    public static DBInfoSystem ColDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "col"
    };
    public static DBInfoSystem ColVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "col"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        ColCargo = 1,
        ColCliente = 2,
        ColSexo = 3,
        ColNome = 4,
        ColCPF = 5,
        ColRG = 6,
        ColDtNasc = 7,
        ColIdade = 8,
        ColEndereco = 9,
        ColBairro = 10,
        ColCEP = 11,
        ColCidade = 12,
        ColFone = 13,
        ColObservacao = 14,
        ColEMail = 15,
        ColCNH = 16,
        ColClass = 17,
        ColEtiqueta = 18,
        ColAni = 19,
        ColBold = 20,
        ColQuemCad = 21,
        ColDtCad = 22,
        ColQuemAtu = 23,
        ColDtAtu = 24,
        ColVisto = 25
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.ColCargo => ColCargo,
        NomesCamposTabela.ColCliente => ColCliente,
        NomesCamposTabela.ColSexo => ColSexo,
        NomesCamposTabela.ColNome => ColNome,
        NomesCamposTabela.ColCPF => ColCPF,
        NomesCamposTabela.ColRG => ColRG,
        NomesCamposTabela.ColDtNasc => ColDtNasc,
        NomesCamposTabela.ColIdade => ColIdade,
        NomesCamposTabela.ColEndereco => ColEndereco,
        NomesCamposTabela.ColBairro => ColBairro,
        NomesCamposTabela.ColCEP => ColCEP,
        NomesCamposTabela.ColCidade => ColCidade,
        NomesCamposTabela.ColFone => ColFone,
        NomesCamposTabela.ColObservacao => ColObservacao,
        NomesCamposTabela.ColEMail => ColEMail,
        NomesCamposTabela.ColCNH => ColCNH,
        NomesCamposTabela.ColClass => ColClass,
        NomesCamposTabela.ColEtiqueta => ColEtiqueta,
        NomesCamposTabela.ColAni => ColAni,
        NomesCamposTabela.ColBold => ColBold,
        NomesCamposTabela.ColQuemCad => ColQuemCad,
        NomesCamposTabela.ColDtCad => ColDtCad,
        NomesCamposTabela.ColQuemAtu => ColQuemAtu,
        NomesCamposTabela.ColDtAtu => ColDtAtu,
        NomesCamposTabela.ColVisto => ColVisto,
        _ => null
    };
}