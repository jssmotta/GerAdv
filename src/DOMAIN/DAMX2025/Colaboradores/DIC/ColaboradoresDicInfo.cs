using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
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
    public static string CampoCodigoDiff(int id) => CampoCodigo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string CampoCodigoSql(int id) => CampoCodigo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string CampoCodigoIsNull => CampoCodigo.SqlCmdIsNull() ?? string.Empty;
    public static string CampoCodigoNotIsNull => CampoCodigo.SqlCmdNotIsNull() ?? string.Empty;

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
    public static DBInfoSystem ColCargo => new(0, PTabelaNome, CampoCodigo, Cargo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBCargosDicInfo.CampoCodigo, DBCargosDicInfo.TabelaNome, new DBCargosODicInfo(), false); // DBI 11 
    public static DBInfoSystem ColCliente => new(0, PTabelaNome, CampoCodigo, Cliente, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBClientesDicInfo.CampoCodigo, DBClientesDicInfo.TabelaNome, new DBClientesODicInfo(), false); // DBI 11 
    public static DBInfoSystem ColSexo => new(0, PTabelaNome, CampoCodigo, Sexo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoBooleanSexo);
    public static DBInfoSystem ColNome => new(0, PTabelaNome, CampoCodigo, Nome, 80, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextNome, true, true, false);
    public static DBInfoSystem ColCPF => new(0, PTabelaNome, CampoCodigo, CPF, 11, DevourerOne.PCpf, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCpf, true, false, false);
    public static DBInfoSystem ColRG => new(0, PTabelaNome, CampoCodigo, RG, 30, DevourerOne.PRg, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextRG, true, false, false);
    public static DBInfoSystem ColDtNasc => new(0, PTabelaNome, CampoCodigo, DtNasc, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoDataNascimento);
    public static DBInfoSystem ColIdade => new(0, PTabelaNome, CampoCodigo, Idade, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem ColEndereco => new(0, PTabelaNome, CampoCodigo, Endereco, 80, DevourerOne.PEndereco, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEndereco, true, false, false);
    public static DBInfoSystem ColBairro => new(0, PTabelaNome, CampoCodigo, Bairro, 50, DevourerOne.PBairro, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextBairro, true, false, false);
    public static DBInfoSystem ColCEP => new(0, PTabelaNome, CampoCodigo, CEP, 10, DevourerOne.PCep, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCep, true, false, false);
    public static DBInfoSystem ColCidade => new(0, PTabelaNome, CampoCodigo, Cidade, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBCidadeDicInfo.CampoCodigo, DBCidadeDicInfo.TabelaNome, new DBCidadeODicInfo(), false); // DBI 11 
    public static DBInfoSystem ColFone => new(0, PTabelaNome, CampoCodigo, Fone, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFone, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFone, true, false, false);
    public static DBInfoSystem ColObservacao => new(0, PTabelaNome, CampoCodigo, Observacao, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemoObservacao, true, false, false);
    public static DBInfoSystem ColEMail => new(0, PTabelaNome, CampoCodigo, EMail, 150, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEmail, true, false, false);
    public static DBInfoSystem ColCNH => new(0, PTabelaNome, CampoCodigo, CNH, 100, DevourerOne.PCnh, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCnh, true, false, false);
    public static DBInfoSystem ColClass => new(0, PTabelaNome, CampoCodigo, Class, 1, DevourerOne.PClassificacao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextClassificacaoStar, true, false, false);
    public static DBInfoSystem ColEtiqueta => new(0, PTabelaNome, CampoCodigo, Etiqueta, DevourerOne.PCriarEtiqueta, DevourerOne.PTooltipEtiqueta, ETipoDadosSysteminfo.SysteminfoBooleanEtiqueta);
    public static DBInfoSystem ColAni => new(0, PTabelaNome, CampoCodigo, Ani, DevourerOne.PCaptionFieldAniversario, DevourerOne.PTooltipAniversario, ETipoDadosSysteminfo.SysteminfoBooleanLembrarAniversario);
    public static DBInfoSystem ColBold => new(0, PTabelaNome, CampoCodigo, Bold, DevourerOne.PNegritar, DevourerOne.PTooltipNegrito, ETipoDadosSysteminfo.SysteminfoBooleanBold);
    public static DBInfoSystem ColQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem ColDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento);
    public static DBInfoSystem ColQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem ColDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao);
    public static DBInfoSystem ColVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto);

#endregion
    public static bool IsThisTable(string nomeTabela) => nomeTabela.ToUpper().Equals(TabelaNome.ToUpper());
#region SMART_SQLServices 
    public static string CargoDiff(int id) => Cargo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string CargoSql(int id) => Cargo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string CargoIsNull => Cargo.SqlCmdIsNull() ?? string.Empty;
    public static string CargoNotIsNull => Cargo.SqlCmdNotIsNull() ?? string.Empty;

    public static string ClienteDiff(int id) => Cliente.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string ClienteSql(int id) => Cliente.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string ClienteIsNull => Cliente.SqlCmdIsNull() ?? string.Empty;
    public static string ClienteNotIsNull => Cliente.SqlCmdNotIsNull() ?? string.Empty;

    public static string SexoSql(bool valueCheck) => Sexo.SqlCmdBoolCheck(valueCheck) ?? string.Empty;
    public static string SexoSqlSim => Sexo.SqlCmdBoolSim() ?? string.Empty;
    public static string SexoSqlNao => Sexo.SqlCmdBoolNao() ?? string.Empty;

    public static string NomeSql(string text) => Nome.SqlCmdTextIgual(text, 80) ?? string.Empty;
    public static string NomeSqlNotIsNull => Nome.SqlCmdNotIsNull() ?? string.Empty;
    public static string NomeSqlIsNull => Nome.SqlCmdIsNull() ?? string.Empty;

    public static string NomeSqlDiff(string text) => Nome.SqlCmdTextDiff(text) ?? string.Empty;
    public static string NomeSqlLike(string text) => Nome.SqlCmdTextLike(text) ?? string.Empty;
    public static string NomeSqlLikeInit(string text) => Nome.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string NomeSqlLikeSpaces(string? text) => Nome.SqlCmdTextLikeSpaces(text) ?? string.Empty;
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

    public static string IdadeDiff(int id) => Idade.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string IdadeSql(int id) => Idade.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string IdadeIsNull => Idade.SqlCmdIsNull() ?? string.Empty;
    public static string IdadeNotIsNull => Idade.SqlCmdNotIsNull() ?? string.Empty;

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
    public static string CEPSql(string text) => CEP.SqlCmdTextIgual(text, 10) ?? string.Empty;
    public static string CEPSqlNotIsNull => CEP.SqlCmdNotIsNull() ?? string.Empty;
    public static string CEPSqlIsNull => CEP.SqlCmdIsNull() ?? string.Empty;

    public static string CEPSqlDiff(string text) => CEP.SqlCmdTextDiff(text) ?? string.Empty;
    public static string CEPSqlLike(string text) => CEP.SqlCmdTextLike(text) ?? string.Empty;
    public static string CEPSqlLikeInit(string text) => CEP.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string CEPSqlLikeSpaces(string? text) => CEP.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string CidadeDiff(int id) => Cidade.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string CidadeSql(int id) => Cidade.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string CidadeIsNull => Cidade.SqlCmdIsNull() ?? string.Empty;
    public static string CidadeNotIsNull => Cidade.SqlCmdNotIsNull() ?? string.Empty;

    public static string FoneSql(string text) => Fone.SqlCmdTextIgual(text) ?? string.Empty;
    public static string FoneSqlNotIsNull => Fone.SqlCmdNotIsNull() ?? string.Empty;
    public static string FoneSqlIsNull => Fone.SqlCmdIsNull() ?? string.Empty;

    public static string FoneSqlDiff(string text) => Fone.SqlCmdTextDiff(text) ?? string.Empty;
    public static string FoneSqlLike(string text) => Fone.SqlCmdTextLike(text) ?? string.Empty;
    public static string FoneSqlLikeInit(string text) => Fone.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string FoneSqlLikeSpaces(string? text) => Fone.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string ObservacaoSql(string text) => Observacao.SqlCmdTextIgual(text) ?? string.Empty;
    public static string ObservacaoSqlNotIsNull => Observacao.SqlCmdNotIsNull() ?? string.Empty;
    public static string ObservacaoSqlIsNull => Observacao.SqlCmdIsNull() ?? string.Empty;

    public static string ObservacaoSqlDiff(string text) => Observacao.SqlCmdTextDiff(text) ?? string.Empty;
    public static string ObservacaoSqlLike(string text) => Observacao.SqlCmdTextLike(text) ?? string.Empty;
    public static string ObservacaoSqlLikeInit(string text) => Observacao.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string ObservacaoSqlLikeSpaces(string? text) => Observacao.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string EMailSql(string text) => EMail.SqlCmdTextIgual(text, 150) ?? string.Empty;
    public static string EMailSqlNotIsNull => EMail.SqlCmdNotIsNull() ?? string.Empty;
    public static string EMailSqlIsNull => EMail.SqlCmdIsNull() ?? string.Empty;

    public static string EMailSqlDiff(string text) => EMail.SqlCmdTextDiff(text) ?? string.Empty;
    public static string EMailSqlLike(string text) => EMail.SqlCmdTextLike(text) ?? string.Empty;
    public static string EMailSqlLikeInit(string text) => EMail.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string EMailSqlLikeSpaces(string? text) => EMail.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string CNHSql(string text) => CNH.SqlCmdTextIgual(text, 100) ?? string.Empty;
    public static string CNHSqlNotIsNull => CNH.SqlCmdNotIsNull() ?? string.Empty;
    public static string CNHSqlIsNull => CNH.SqlCmdIsNull() ?? string.Empty;

    public static string CNHSqlDiff(string text) => CNH.SqlCmdTextDiff(text) ?? string.Empty;
    public static string CNHSqlLike(string text) => CNH.SqlCmdTextLike(text) ?? string.Empty;
    public static string CNHSqlLikeInit(string text) => CNH.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string CNHSqlLikeSpaces(string? text) => CNH.SqlCmdTextLikeSpaces(text) ?? string.Empty;
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