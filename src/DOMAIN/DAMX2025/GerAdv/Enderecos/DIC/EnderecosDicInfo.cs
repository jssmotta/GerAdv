using MenphisSI.SG.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public static partial class DBEnderecosDicInfo
{
    public const string CampoCodigo = "endCodigo";
    public const string CampoNome = "endDescricao";
    public const string TablePrefix = "end";
    public const string TopIndex = "endTopIndex"; // LOCALIZACAO 170523
    public const string Descricao = "endDescricao"; // LOCALIZACAO 170523
    public const string Contato = "endContato"; // LOCALIZACAO 170523
    public const string DtNasc = "endDtNasc"; // LOCALIZACAO 170523
    public const string Endereco = "endEndereco"; // LOCALIZACAO 170523
    public const string Bairro = "endBairro"; // LOCALIZACAO 170523
    public const string Privativo = "endPrivativo"; // LOCALIZACAO 170523
    public const string AddContato = "endAddContato"; // LOCALIZACAO 170523
    public const string CEP = "endCEP"; // LOCALIZACAO 170523
    public const string OAB = "endOAB"; // LOCALIZACAO 170523
    public const string OBS = "endOBS"; // LOCALIZACAO 170523
    public const string Fone = "endFone"; // LOCALIZACAO 170523
    public const string Fax = "endFax"; // LOCALIZACAO 170523
    public const string Tratamento = "endTratamento"; // LOCALIZACAO 170523
    public const string Cidade = "endCidade"; // LOCALIZACAO 170523
    public const string Site = "endSite"; // LOCALIZACAO 170523
    public const string EMail = "endEMail"; // LOCALIZACAO 170523
    public const string Quem = "endQuem"; // LOCALIZACAO 170523
    public const string QuemIndicou = "endQuemIndicou"; // LOCALIZACAO 170523
    public const string ReportECBOnly = "endReportECBOnly"; // LOCALIZACAO 170523
    public const string Etiqueta = "endEtiqueta"; // LOCALIZACAO 170523
    public const string Ani = "endAni"; // LOCALIZACAO 170523
    public const string Bold = "endBold"; // LOCALIZACAO 170523
    public const string GUID = "endGUID"; // LOCALIZACAO 170523
    public const string QuemCad = "endQuemCad"; // LOCALIZACAO 170523
    public const string DtCad = "endDtCad"; // LOCALIZACAO 170523
    public const string QuemAtu = "endQuemAtu"; // LOCALIZACAO 170523
    public const string DtAtu = "endDtAtu"; // LOCALIZACAO 170523
    public const string Visto = "endVisto"; // LOCALIZACAO 170523
    public static string GetNameFieldByENum(NomesCamposTabela idField) => ((int)idField) switch
    {
        1 => TopIndex,
        2 => Descricao,
        3 => Contato,
        4 => DtNasc,
        5 => Endereco,
        6 => Bairro,
        7 => Privativo,
        8 => AddContato,
        9 => CEP,
        10 => OAB,
        11 => OBS,
        12 => Fone,
        13 => Fax,
        14 => Tratamento,
        15 => Cidade,
        16 => Site,
        17 => EMail,
        18 => Quem,
        19 => QuemIndicou,
        20 => ReportECBOnly,
        21 => Etiqueta,
        22 => Ani,
        23 => Bold,
        24 => GUID,
        25 => QuemCad,
        26 => DtCad,
        27 => QuemAtu,
        28 => DtAtu,
        29 => Visto,
        _ => string.Empty
    };
    public static string TabelaNome => PTabelaNome;

    public const string PTabelaNome = "Enderecos";
#region PropriedadesDaTabela
    public static DBInfoSystem EndTopIndex => new(0, PTabelaNome, CampoCodigo, TopIndex, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "end"
    };
    public static DBInfoSystem EndDescricao => new(0, PTabelaNome, CampoCodigo, Descricao, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "end"
    };
    public static DBInfoSystem EndContato => new(0, PTabelaNome, CampoCodigo, Contato, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false)
    {
        Prefixo = "end"
    };
    public static DBInfoSystem EndDtNasc => new(0, PTabelaNome, CampoCodigo, DtNasc, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDataNascimento)
    {
        Prefixo = "end"
    };
    public static DBInfoSystem EndEndereco => new(0, PTabelaNome, CampoCodigo, Endereco, 50, DevourerOne.PEndereco, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEndereco, true, false, false)
    {
        Prefixo = "end"
    };
    public static DBInfoSystem EndBairro => new(0, PTabelaNome, CampoCodigo, Bairro, 30, DevourerOne.PBairro, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextBairro, true, false, false)
    {
        Prefixo = "end"
    };
    public static DBInfoSystem EndPrivativo => new(0, PTabelaNome, CampoCodigo, Privativo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "end"
    };
    public static DBInfoSystem EndAddContato => new(0, PTabelaNome, CampoCodigo, AddContato, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        IsRequired = true,
        Prefixo = "end"
    };
    public static DBInfoSystem EndCEP => new(0, PTabelaNome, CampoCodigo, CEP, 10, DevourerOne.PCep, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCep, true, false, false)
    {
        Prefixo = "end"
    };
    public static DBInfoSystem EndOAB => new(0, PTabelaNome, CampoCodigo, OAB, 20, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "end"
    };
    public static DBInfoSystem EndOBS => new(0, PTabelaNome, CampoCodigo, OBS, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemoObservacao, true, false, false)
    {
        Prefixo = "end"
    };
    public static DBInfoSystem EndFone => new(0, PTabelaNome, CampoCodigo, Fone, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFone, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFone, true, false, false)
    {
        Prefixo = "end"
    };
    public static DBInfoSystem EndFax => new(0, PTabelaNome, CampoCodigo, Fax, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFax, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFax, true, false, false)
    {
        Prefixo = "end"
    };
    public static DBInfoSystem EndTratamento => new(0, PTabelaNome, CampoCodigo, Tratamento, 20, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "end"
    };
    public static DBInfoSystem EndCidade => new(0, PTabelaNome, CampoCodigo, Cidade, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBCidadeDicInfo.CampoCodigo, DBCidadeDicInfo.TabelaNome, new DBCidadeODicInfo(), false)
    {
        Prefixo = "end"
    }; // DBI 11 
    public static DBInfoSystem EndSite => new(0, PTabelaNome, CampoCodigo, Site, 200, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextWebsite, true, false, false)
    {
        Prefixo = "end"
    };
    public static DBInfoSystem EndEMail => new(0, PTabelaNome, CampoCodigo, EMail, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEmail, true, false, false)
    {
        Prefixo = "end"
    };
    public static DBInfoSystem EndQuem => new(0, PTabelaNome, CampoCodigo, Quem, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber)
    {
        Prefixo = "end"
    };
    public static DBInfoSystem EndQuemIndicou => new(0, PTabelaNome, CampoCodigo, QuemIndicou, 150, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false)
    {
        Prefixo = "end"
    };
    public static DBInfoSystem EndReportECBOnly => new(0, PTabelaNome, CampoCodigo, ReportECBOnly, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean)
    {
        Prefixo = "end"
    };
    public static DBInfoSystem EndEtiqueta => new(0, PTabelaNome, CampoCodigo, Etiqueta, DevourerOne.PCriarEtiqueta, DevourerOne.PTooltipEtiqueta, ETipoDadosSysteminfo.SysteminfoBooleanEtiqueta)
    {
        IsRequired = true,
        Prefixo = "end"
    };
    public static DBInfoSystem EndAni => new(0, PTabelaNome, CampoCodigo, Ani, DevourerOne.PCaptionFieldAniversario, DevourerOne.PTooltipAniversario, ETipoDadosSysteminfo.SysteminfoBooleanLembrarAniversario)
    {
        IsRequired = true,
        Prefixo = "end"
    };
    public static DBInfoSystem EndBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold)
    {
        IsRequired = true,
        Prefixo = "end"
    };
    public static DBInfoSystem EndGUID => new(0, PTabelaNome, CampoCodigo, GUID, 100, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false)
    {
        Prefixo = "end"
    };
    public static DBInfoSystem EndQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "end"
    }; // DBI 11 
    public static DBInfoSystem EndDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento)
    {
        Prefixo = "end"
    };
    public static DBInfoSystem EndQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false)
    {
        Prefixo = "end"
    }; // DBI 11 
    public static DBInfoSystem EndDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao)
    {
        Prefixo = "end"
    };
    public static DBInfoSystem EndVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto)
    {
        IsRequired = true,
        Prefixo = "end"
    };

#endregion
    [Serializable]
    public enum NomesCamposTabela
    {
        EndTopIndex = 1,
        EndDescricao = 2,
        EndContato = 3,
        EndDtNasc = 4,
        EndEndereco = 5,
        EndBairro = 6,
        EndPrivativo = 7,
        EndAddContato = 8,
        EndCEP = 9,
        EndOAB = 10,
        EndOBS = 11,
        EndFone = 12,
        EndFax = 13,
        EndTratamento = 14,
        EndCidade = 15,
        EndSite = 16,
        EndEMail = 17,
        EndQuem = 18,
        EndQuemIndicou = 19,
        EndReportECBOnly = 20,
        EndEtiqueta = 21,
        EndAni = 22,
        EndBold = 23,
        EndGUID = 24,
        EndQuemCad = 25,
        EndDtCad = 26,
        EndQuemAtu = 27,
        EndDtAtu = 28,
        EndVisto = 29
    }

    public static DBInfoSystem? GetInfoSystemByEnum(NomesCamposTabela idTable) => idTable switch
    {
        NomesCamposTabela.EndTopIndex => EndTopIndex,
        NomesCamposTabela.EndDescricao => EndDescricao,
        NomesCamposTabela.EndContato => EndContato,
        NomesCamposTabela.EndDtNasc => EndDtNasc,
        NomesCamposTabela.EndEndereco => EndEndereco,
        NomesCamposTabela.EndBairro => EndBairro,
        NomesCamposTabela.EndPrivativo => EndPrivativo,
        NomesCamposTabela.EndAddContato => EndAddContato,
        NomesCamposTabela.EndCEP => EndCEP,
        NomesCamposTabela.EndOAB => EndOAB,
        NomesCamposTabela.EndOBS => EndOBS,
        NomesCamposTabela.EndFone => EndFone,
        NomesCamposTabela.EndFax => EndFax,
        NomesCamposTabela.EndTratamento => EndTratamento,
        NomesCamposTabela.EndCidade => EndCidade,
        NomesCamposTabela.EndSite => EndSite,
        NomesCamposTabela.EndEMail => EndEMail,
        NomesCamposTabela.EndQuem => EndQuem,
        NomesCamposTabela.EndQuemIndicou => EndQuemIndicou,
        NomesCamposTabela.EndReportECBOnly => EndReportECBOnly,
        NomesCamposTabela.EndEtiqueta => EndEtiqueta,
        NomesCamposTabela.EndAni => EndAni,
        NomesCamposTabela.EndBold => EndBold,
        NomesCamposTabela.EndGUID => EndGUID,
        NomesCamposTabela.EndQuemCad => EndQuemCad,
        NomesCamposTabela.EndDtCad => EndDtCad,
        NomesCamposTabela.EndQuemAtu => EndQuemAtu,
        NomesCamposTabela.EndDtAtu => EndDtAtu,
        NomesCamposTabela.EndVisto => EndVisto,
        _ => null
    };
}