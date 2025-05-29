using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
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
    public static string CampoCodigoDiff(int id) => CampoCodigo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string CampoCodigoSql(int id) => CampoCodigo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string CampoCodigoIsNull => CampoCodigo.SqlCmdIsNull() ?? string.Empty;
    public static string CampoCodigoNotIsNull => CampoCodigo.SqlCmdNotIsNull() ?? string.Empty;

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
    public static DBInfoSystem FunEMailPro => new(0, PTabelaNome, CampoCodigo, EMailPro, 255, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEmailPro, true, false, false);
    public static DBInfoSystem FunCargo => new(0, PTabelaNome, CampoCodigo, Cargo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBCargosDicInfo.CampoCodigo, DBCargosDicInfo.TabelaNome, new DBCargosODicInfo(), false); // DBI 11 
    public static DBInfoSystem FunNome => new(0, PTabelaNome, CampoCodigo, Nome, 60, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false);
    public static DBInfoSystem FunFuncao => new(0, PTabelaNome, CampoCodigo, Funcao, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBFuncaoDicInfo.CampoCodigo, DBFuncaoDicInfo.TabelaNome, new DBFuncaoODicInfo(), false); // DBI 11 
    public static DBInfoSystem FunSexo => new(0, PTabelaNome, CampoCodigo, Sexo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBooleanSexo);
    public static DBInfoSystem FunRegistro => new(0, PTabelaNome, CampoCodigo, Registro, 20, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem FunCPF => new(0, PTabelaNome, CampoCodigo, CPF, 11, DevourerOne.PCpf, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCpf, true, false, false);
    public static DBInfoSystem FunRG => new(0, PTabelaNome, CampoCodigo, RG, 30, DevourerOne.PRg, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextRG, true, false, false);
    public static DBInfoSystem FunTipo => new(0, PTabelaNome, CampoCodigo, Tipo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBooleanTipoPessoa);
    public static DBInfoSystem FunObservacao => new(0, PTabelaNome, CampoCodigo, Observacao, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemoObservacao, true, false, false);
    public static DBInfoSystem FunEndereco => new(0, PTabelaNome, CampoCodigo, Endereco, 80, DevourerOne.PEndereco, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEndereco, true, false, false);
    public static DBInfoSystem FunBairro => new(0, PTabelaNome, CampoCodigo, Bairro, 50, DevourerOne.PBairro, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextBairro, true, false, false);
    public static DBInfoSystem FunCidade => new(0, PTabelaNome, CampoCodigo, Cidade, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBCidadeDicInfo.CampoCodigo, DBCidadeDicInfo.TabelaNome, new DBCidadeODicInfo(), false); // DBI 11 
    public static DBInfoSystem FunCEP => new(0, PTabelaNome, CampoCodigo, CEP, 10, DevourerOne.PCep, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCep, true, false, false);
    public static DBInfoSystem FunContato => new(0, PTabelaNome, CampoCodigo, Contato, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemo, true, false, false);
    public static DBInfoSystem FunFax => new(0, PTabelaNome, CampoCodigo, Fax, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFax, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFax, true, false, false);
    public static DBInfoSystem FunFone => new(0, PTabelaNome, CampoCodigo, Fone, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFone, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFone, true, false, false);
    public static DBInfoSystem FunEMail => new(0, PTabelaNome, CampoCodigo, EMail, 60, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEmail, true, false, false);
    public static DBInfoSystem FunPeriodo_Ini => new(0, PTabelaNome, CampoCodigo, Periodo_Ini, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDataInicio);
    public static DBInfoSystem FunPeriodo_Fim => new(0, PTabelaNome, CampoCodigo, Periodo_Fim, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDataTermino);
    public static DBInfoSystem FunCTPSNumero => new(0, PTabelaNome, CampoCodigo, CTPSNumero, 15, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem FunCTPSSerie => new(0, PTabelaNome, CampoCodigo, CTPSSerie, 10, DevourerOne.PNroSerieCtps, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCtpsserie, true, false, false);
    public static DBInfoSystem FunPIS => new(0, PTabelaNome, CampoCodigo, PIS, 20, DevourerOne.PNroPis, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextPis, true, false, false);
    public static DBInfoSystem FunSalario => new(0, PTabelaNome, CampoCodigo, Salario, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDoubleSalario);
    public static DBInfoSystem FunCTPSDtEmissao => new(0, PTabelaNome, CampoCodigo, CTPSDtEmissao, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem FunDtNasc => new(0, PTabelaNome, CampoCodigo, DtNasc, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDataNascimento);
    public static DBInfoSystem FunData => new(0, PTabelaNome, CampoCodigo, Data, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDatetime);
    public static DBInfoSystem FunLiberaAgenda => new(0, PTabelaNome, CampoCodigo, LiberaAgenda, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBoolean);
    public static DBInfoSystem FunPasta => new(0, PTabelaNome, CampoCodigo, Pasta, 200, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem FunClass => new(0, PTabelaNome, CampoCodigo, Class, 1, DevourerOne.PClassificacao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextClassificacaoStar, true, false, false);
    public static DBInfoSystem FunEtiqueta => new(0, PTabelaNome, CampoCodigo, Etiqueta, DevourerOne.PCriarEtiqueta, DevourerOne.PTooltipEtiqueta, ETipoDadosSysteminfo.SysteminfoBooleanEtiqueta);
    public static DBInfoSystem FunAni => new(0, PTabelaNome, CampoCodigo, Ani, DevourerOne.PCaptionFieldAniversario, DevourerOne.PTooltipAniversario, ETipoDadosSysteminfo.SysteminfoBooleanLembrarAniversario);
    public static DBInfoSystem FunBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold);
    public static DBInfoSystem FunGUID => new(0, PTabelaNome, CampoCodigo, GUID, 150, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false);
    public static DBInfoSystem FunQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem FunDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento);
    public static DBInfoSystem FunQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem FunDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao);
    public static DBInfoSystem FunVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto);

#endregion
    public static bool IsThisTable(string nomeTabela) => nomeTabela.ToUpper().Equals(TabelaNome.ToUpper());
#region SMART_SQLServices 
    public static string EMailProSql(string text) => EMailPro.SqlCmdTextIgual(text, 255) ?? string.Empty;
    public static string EMailProSqlNotIsNull => EMailPro.SqlCmdNotIsNull() ?? string.Empty;
    public static string EMailProSqlIsNull => EMailPro.SqlCmdIsNull() ?? string.Empty;

    public static string EMailProSqlDiff(string text) => EMailPro.SqlCmdTextDiff(text) ?? string.Empty;
    public static string EMailProSqlLike(string text) => EMailPro.SqlCmdTextLike(text) ?? string.Empty;
    public static string EMailProSqlLikeInit(string text) => EMailPro.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string EMailProSqlLikeSpaces(string? text) => EMailPro.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string CargoDiff(int id) => Cargo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string CargoSql(int id) => Cargo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string CargoIsNull => Cargo.SqlCmdIsNull() ?? string.Empty;
    public static string CargoNotIsNull => Cargo.SqlCmdNotIsNull() ?? string.Empty;

    public static string NomeSql(string text) => Nome.SqlCmdTextIgual(text, 60) ?? string.Empty;
    public static string NomeSqlNotIsNull => Nome.SqlCmdNotIsNull() ?? string.Empty;
    public static string NomeSqlIsNull => Nome.SqlCmdIsNull() ?? string.Empty;

    public static string NomeSqlDiff(string text) => Nome.SqlCmdTextDiff(text) ?? string.Empty;
    public static string NomeSqlLike(string text) => Nome.SqlCmdTextLike(text) ?? string.Empty;
    public static string NomeSqlLikeInit(string text) => Nome.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string NomeSqlLikeSpaces(string? text) => Nome.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string FuncaoDiff(int id) => Funcao.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string FuncaoSql(int id) => Funcao.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string FuncaoIsNull => Funcao.SqlCmdIsNull() ?? string.Empty;
    public static string FuncaoNotIsNull => Funcao.SqlCmdNotIsNull() ?? string.Empty;

    public static string SexoSql(bool valueCheck) => Sexo.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string SexoSqlSim => Sexo.SqlCmdBoolSim() ?? string.Empty;
    public static string SexoSqlNao => Sexo.SqlCmdBoolNao() ?? string.Empty;

    public static string RegistroSql(string text) => Registro.SqlCmdTextIgual(text, 20) ?? string.Empty;
    public static string RegistroSqlNotIsNull => Registro.SqlCmdNotIsNull() ?? string.Empty;
    public static string RegistroSqlIsNull => Registro.SqlCmdIsNull() ?? string.Empty;

    public static string RegistroSqlDiff(string text) => Registro.SqlCmdTextDiff(text) ?? string.Empty;
    public static string RegistroSqlLike(string text) => Registro.SqlCmdTextLike(text) ?? string.Empty;
    public static string RegistroSqlLikeInit(string text) => Registro.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string RegistroSqlLikeSpaces(string? text) => Registro.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string CPFSql(string text) => CPF.SqlCmdTextIgual(text, 11) ?? string.Empty;
    public static string CPFSqlNotIsNull => CPF.SqlCmdNotIsNull() ?? string.Empty;
    public static string CPFSqlIsNull => CPF.SqlCmdIsNull() ?? string.Empty;

    public static string CPFSqlDiff(string text) => CPF.SqlCmdTextDiff(text) ?? string.Empty;
    public static string CPFSqlLike(string text) => CPF.SqlCmdTextLike(text) ?? string.Empty;
    public static string CPFSqlLikeInit(string text) => CPF.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string CPFSqlLikeSpaces(string? text) => CPF.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string RGSql(string text) => RG.SqlCmdTextIgual(text, 30) ?? string.Empty;
    public static string RGSqlNotIsNull => RG.SqlCmdNotIsNull() ?? string.Empty;
    public static string RGSqlIsNull => RG.SqlCmdIsNull() ?? string.Empty;

    public static string RGSqlDiff(string text) => RG.SqlCmdTextDiff(text) ?? string.Empty;
    public static string RGSqlLike(string text) => RG.SqlCmdTextLike(text) ?? string.Empty;
    public static string RGSqlLikeInit(string text) => RG.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string RGSqlLikeSpaces(string? text) => RG.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string TipoSql(bool valueCheck) => Tipo.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string TipoSqlSim => Tipo.SqlCmdBoolSim() ?? string.Empty;
    public static string TipoSqlNao => Tipo.SqlCmdBoolNao() ?? string.Empty;

    public static string ObservacaoSql(string text) => Observacao.SqlCmdTextIgual(text) ?? string.Empty;
    public static string ObservacaoSqlNotIsNull => Observacao.SqlCmdNotIsNull() ?? string.Empty;
    public static string ObservacaoSqlIsNull => Observacao.SqlCmdIsNull() ?? string.Empty;

    public static string ObservacaoSqlDiff(string text) => Observacao.SqlCmdTextDiff(text) ?? string.Empty;
    public static string ObservacaoSqlLike(string text) => Observacao.SqlCmdTextLike(text) ?? string.Empty;
    public static string ObservacaoSqlLikeInit(string text) => Observacao.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string ObservacaoSqlLikeSpaces(string? text) => Observacao.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string EnderecoSql(string text) => Endereco.SqlCmdTextIgual(text, 80) ?? string.Empty;
    public static string EnderecoSqlNotIsNull => Endereco.SqlCmdNotIsNull() ?? string.Empty;
    public static string EnderecoSqlIsNull => Endereco.SqlCmdIsNull() ?? string.Empty;

    public static string EnderecoSqlDiff(string text) => Endereco.SqlCmdTextDiff(text) ?? string.Empty;
    public static string EnderecoSqlLike(string text) => Endereco.SqlCmdTextLike(text) ?? string.Empty;
    public static string EnderecoSqlLikeInit(string text) => Endereco.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string EnderecoSqlLikeSpaces(string? text) => Endereco.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string BairroSql(string text) => Bairro.SqlCmdTextIgual(text, 50) ?? string.Empty;
    public static string BairroSqlNotIsNull => Bairro.SqlCmdNotIsNull() ?? string.Empty;
    public static string BairroSqlIsNull => Bairro.SqlCmdIsNull() ?? string.Empty;

    public static string BairroSqlDiff(string text) => Bairro.SqlCmdTextDiff(text) ?? string.Empty;
    public static string BairroSqlLike(string text) => Bairro.SqlCmdTextLike(text) ?? string.Empty;
    public static string BairroSqlLikeInit(string text) => Bairro.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string BairroSqlLikeSpaces(string? text) => Bairro.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string CidadeDiff(int id) => Cidade.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string CidadeSql(int id) => Cidade.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string CidadeIsNull => Cidade.SqlCmdIsNull() ?? string.Empty;
    public static string CidadeNotIsNull => Cidade.SqlCmdNotIsNull() ?? string.Empty;

    public static string CEPSql(string text) => CEP.SqlCmdTextIgual(text, 10) ?? string.Empty;
    public static string CEPSqlNotIsNull => CEP.SqlCmdNotIsNull() ?? string.Empty;
    public static string CEPSqlIsNull => CEP.SqlCmdIsNull() ?? string.Empty;

    public static string CEPSqlDiff(string text) => CEP.SqlCmdTextDiff(text) ?? string.Empty;
    public static string CEPSqlLike(string text) => CEP.SqlCmdTextLike(text) ?? string.Empty;
    public static string CEPSqlLikeInit(string text) => CEP.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string CEPSqlLikeSpaces(string? text) => CEP.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string ContatoSql(string text) => Contato.SqlCmdTextIgual(text) ?? string.Empty;
    public static string ContatoSqlNotIsNull => Contato.SqlCmdNotIsNull() ?? string.Empty;
    public static string ContatoSqlIsNull => Contato.SqlCmdIsNull() ?? string.Empty;

    public static string ContatoSqlDiff(string text) => Contato.SqlCmdTextDiff(text) ?? string.Empty;
    public static string ContatoSqlLike(string text) => Contato.SqlCmdTextLike(text) ?? string.Empty;
    public static string ContatoSqlLikeInit(string text) => Contato.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string ContatoSqlLikeSpaces(string? text) => Contato.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string FaxSql(string text) => Fax.SqlCmdTextIgual(text) ?? string.Empty;
    public static string FaxSqlNotIsNull => Fax.SqlCmdNotIsNull() ?? string.Empty;
    public static string FaxSqlIsNull => Fax.SqlCmdIsNull() ?? string.Empty;

    public static string FaxSqlDiff(string text) => Fax.SqlCmdTextDiff(text) ?? string.Empty;
    public static string FaxSqlLike(string text) => Fax.SqlCmdTextLike(text) ?? string.Empty;
    public static string FaxSqlLikeInit(string text) => Fax.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string FaxSqlLikeSpaces(string? text) => Fax.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string FoneSql(string text) => Fone.SqlCmdTextIgual(text) ?? string.Empty;
    public static string FoneSqlNotIsNull => Fone.SqlCmdNotIsNull() ?? string.Empty;
    public static string FoneSqlIsNull => Fone.SqlCmdIsNull() ?? string.Empty;

    public static string FoneSqlDiff(string text) => Fone.SqlCmdTextDiff(text) ?? string.Empty;
    public static string FoneSqlLike(string text) => Fone.SqlCmdTextLike(text) ?? string.Empty;
    public static string FoneSqlLikeInit(string text) => Fone.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string FoneSqlLikeSpaces(string? text) => Fone.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string EMailSql(string text) => EMail.SqlCmdTextIgual(text, 60) ?? string.Empty;
    public static string EMailSqlNotIsNull => EMail.SqlCmdNotIsNull() ?? string.Empty;
    public static string EMailSqlIsNull => EMail.SqlCmdIsNull() ?? string.Empty;

    public static string EMailSqlDiff(string text) => EMail.SqlCmdTextDiff(text) ?? string.Empty;
    public static string EMailSqlLike(string text) => EMail.SqlCmdTextLike(text) ?? string.Empty;
    public static string EMailSqlLikeInit(string text) => EMail.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string EMailSqlLikeSpaces(string? text) => EMail.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string Periodo_IniSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{Periodo_Ini}]");
    public static string Periodo_IniSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{Periodo_Ini}]");
    public static string Periodo_IniSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{Periodo_Ini}]");
    public static string Periodo_IniSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{Periodo_Ini}]");
    public static string Periodo_IniSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{Periodo_Ini}]");
    public static string Periodo_IniSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{Periodo_Ini}]");
    public static string Periodo_IniSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{Periodo_Ini}]");
    public static string Periodo_IniSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{Periodo_Ini}]");
    public static string Periodo_IniSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{Periodo_Ini}]");
    public static string Periodo_IniSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{Periodo_Ini}]");
    public static string Periodo_IniSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{Periodo_Ini}]");
    public static string Periodo_IniSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{Periodo_Ini}]");
    public static string Periodo_IniIsNull => Periodo_Ini.SqlCmdIsNull() ?? string.Empty;
    public static string Periodo_IniNotIsNull => Periodo_Ini.SqlCmdNotIsNull() ?? string.Empty;

    public static string Periodo_FimSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{Periodo_Fim}]");
    public static string Periodo_FimSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{Periodo_Fim}]");
    public static string Periodo_FimSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{Periodo_Fim}]");
    public static string Periodo_FimSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{Periodo_Fim}]");
    public static string Periodo_FimSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{Periodo_Fim}]");
    public static string Periodo_FimSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{Periodo_Fim}]");
    public static string Periodo_FimSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{Periodo_Fim}]");
    public static string Periodo_FimSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{Periodo_Fim}]");
    public static string Periodo_FimSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{Periodo_Fim}]");
    public static string Periodo_FimSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{Periodo_Fim}]");
    public static string Periodo_FimSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{Periodo_Fim}]");
    public static string Periodo_FimSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{Periodo_Fim}]");
    public static string Periodo_FimIsNull => Periodo_Fim.SqlCmdIsNull() ?? string.Empty;
    public static string Periodo_FimNotIsNull => Periodo_Fim.SqlCmdNotIsNull() ?? string.Empty;

    public static string CTPSNumeroSql(string text) => CTPSNumero.SqlCmdTextIgual(text, 15) ?? string.Empty;
    public static string CTPSNumeroSqlNotIsNull => CTPSNumero.SqlCmdNotIsNull() ?? string.Empty;
    public static string CTPSNumeroSqlIsNull => CTPSNumero.SqlCmdIsNull() ?? string.Empty;

    public static string CTPSNumeroSqlDiff(string text) => CTPSNumero.SqlCmdTextDiff(text) ?? string.Empty;
    public static string CTPSNumeroSqlLike(string text) => CTPSNumero.SqlCmdTextLike(text) ?? string.Empty;
    public static string CTPSNumeroSqlLikeInit(string text) => CTPSNumero.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string CTPSNumeroSqlLikeSpaces(string? text) => CTPSNumero.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string CTPSSerieSql(string text) => CTPSSerie.SqlCmdTextIgual(text, 10) ?? string.Empty;
    public static string CTPSSerieSqlNotIsNull => CTPSSerie.SqlCmdNotIsNull() ?? string.Empty;
    public static string CTPSSerieSqlIsNull => CTPSSerie.SqlCmdIsNull() ?? string.Empty;

    public static string CTPSSerieSqlDiff(string text) => CTPSSerie.SqlCmdTextDiff(text) ?? string.Empty;
    public static string CTPSSerieSqlLike(string text) => CTPSSerie.SqlCmdTextLike(text) ?? string.Empty;
    public static string CTPSSerieSqlLikeInit(string text) => CTPSSerie.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string CTPSSerieSqlLikeSpaces(string? text) => CTPSSerie.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string PISSql(string text) => PIS.SqlCmdTextIgual(text, 20) ?? string.Empty;
    public static string PISSqlNotIsNull => PIS.SqlCmdNotIsNull() ?? string.Empty;
    public static string PISSqlIsNull => PIS.SqlCmdIsNull() ?? string.Empty;

    public static string PISSqlDiff(string text) => PIS.SqlCmdTextDiff(text) ?? string.Empty;
    public static string PISSqlLike(string text) => PIS.SqlCmdTextLike(text) ?? string.Empty;
    public static string PISSqlLikeInit(string text) => PIS.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string PISSqlLikeSpaces(string? text) => PIS.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string CTPSDtEmissaoSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{CTPSDtEmissao}]");
    public static string CTPSDtEmissaoSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{CTPSDtEmissao}]");
    public static string CTPSDtEmissaoSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{CTPSDtEmissao}]");
    public static string CTPSDtEmissaoSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{CTPSDtEmissao}]");
    public static string CTPSDtEmissaoSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{CTPSDtEmissao}]");
    public static string CTPSDtEmissaoSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{CTPSDtEmissao}]");
    public static string CTPSDtEmissaoSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{CTPSDtEmissao}]");
    public static string CTPSDtEmissaoSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{CTPSDtEmissao}]");
    public static string CTPSDtEmissaoSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{CTPSDtEmissao}]");
    public static string CTPSDtEmissaoSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{CTPSDtEmissao}]");
    public static string CTPSDtEmissaoSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{CTPSDtEmissao}]");
    public static string CTPSDtEmissaoSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{CTPSDtEmissao}]");
    public static string CTPSDtEmissaoIsNull => CTPSDtEmissao.SqlCmdIsNull() ?? string.Empty;
    public static string CTPSDtEmissaoNotIsNull => CTPSDtEmissao.SqlCmdNotIsNull() ?? string.Empty;

    public static string DtNascSqlEntre(DateTime date1, DateTime date2) => DevourerOne.AppendDataSqlBetween20(date1, date2, $"[{DtNasc}]");
    public static string DtNascSqlIgual(DateTime dateT) => DevourerOne.AppendDataSqlDataIgual20(dateT, $"[{DtNasc}]");
    public static string DtNascSqlMaior(DateTime dateT) => DevourerOne.AppendDataSqlMaiorQue20(dateT, $"[{DtNasc}]");
    public static string DtNascSqlMaiorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMaiorOuIgual20(dateT, $"[{DtNasc}]");
    public static string DtNascSqlMenor(DateTime dateT) => DevourerOne.AppendDataSqlMenorQue20(dateT, $"[{DtNasc}]");
    public static string DtNascSqlMenorIgual(DateTime dateT) => DevourerOne.AppendDataSqlMenorOuIgual20(dateT, $"[{DtNasc}]");
    public static string DtNascSqlEntre(string dateStr1, string dateStr2) => DevourerOne.AppendDataSqlBetween20(dateStr1, dateStr2, $"[{DtNasc}]");
    public static string DtNascSqlIgual(string dateStr) => DevourerOne.AppendDataSqlDataIgual(dateStr, $"[{DtNasc}]");
    public static string DtNascSqlMaior(string dateStr) => DevourerOne.AppendDataSqlMaiorQue(dateStr, $"[{DtNasc}]");
    public static string DtNascSqlMaiorIgual(string dateStr) => DevourerOne.AppendDataSqlMaiorOuIgual(dateStr, $"[{DtNasc}]");
    public static string DtNascSqlMenor(string dateStr) => DevourerOne.AppendDataSqlMenorQue20(dateStr, $"[{DtNasc}]");
    public static string DtNascSqlMenorIgual(string dateStr) => DevourerOne.AppendDataSqlMenorOuIgual(dateStr, $"[{DtNasc}]");
    public static string DtNascIsNull => DtNasc.SqlCmdIsNull() ?? string.Empty;
    public static string DtNascNotIsNull => DtNasc.SqlCmdNotIsNull() ?? string.Empty;

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

    public static string LiberaAgendaSql(bool valueCheck) => LiberaAgenda.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string LiberaAgendaSqlSim => LiberaAgenda.SqlCmdBoolSim() ?? string.Empty;
    public static string LiberaAgendaSqlNao => LiberaAgenda.SqlCmdBoolNao() ?? string.Empty;

    public static string PastaSql(string text) => Pasta.SqlCmdTextIgual(text, 200) ?? string.Empty;
    public static string PastaSqlNotIsNull => Pasta.SqlCmdNotIsNull() ?? string.Empty;
    public static string PastaSqlIsNull => Pasta.SqlCmdIsNull() ?? string.Empty;

    public static string PastaSqlDiff(string text) => Pasta.SqlCmdTextDiff(text) ?? string.Empty;
    public static string PastaSqlLike(string text) => Pasta.SqlCmdTextLike(text) ?? string.Empty;
    public static string PastaSqlLikeInit(string text) => Pasta.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string PastaSqlLikeSpaces(string? text) => Pasta.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string ClassSql(string text) => Class.SqlCmdTextIgual(text, 1) ?? string.Empty;
    public static string ClassSqlNotIsNull => Class.SqlCmdNotIsNull() ?? string.Empty;
    public static string ClassSqlIsNull => Class.SqlCmdIsNull() ?? string.Empty;

    public static string ClassSqlDiff(string text) => Class.SqlCmdTextDiff(text) ?? string.Empty;
    public static string ClassSqlLike(string text) => Class.SqlCmdTextLike(text) ?? string.Empty;
    public static string ClassSqlLikeInit(string text) => Class.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string ClassSqlLikeSpaces(string? text) => Class.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string EtiquetaSql(bool valueCheck) => Etiqueta.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string EtiquetaSqlSim => Etiqueta.SqlCmdBoolSim() ?? string.Empty;
    public static string EtiquetaSqlNao => Etiqueta.SqlCmdBoolNao() ?? string.Empty;

    public static string AniSql(bool valueCheck) => Ani.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string AniSqlSim => Ani.SqlCmdBoolSim() ?? string.Empty;
    public static string AniSqlNao => Ani.SqlCmdBoolNao() ?? string.Empty;

    public static string BoldSql(bool valueCheck) => Bold.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string BoldSqlSim => Bold.SqlCmdBoolSim() ?? string.Empty;
    public static string BoldSqlNao => Bold.SqlCmdBoolNao() ?? string.Empty;

    public static string GUIDSql(string text) => GUID.SqlCmdTextIgual(text, 150) ?? string.Empty;
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