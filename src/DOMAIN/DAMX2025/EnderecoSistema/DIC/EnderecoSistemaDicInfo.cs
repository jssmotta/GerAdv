using MenphisSI.GerAdv.DicInfo;

// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
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
    public static string CampoCodigoDiff(int id) => CampoCodigo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string CampoCodigoSql(int id) => CampoCodigo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string CampoCodigoIsNull => CampoCodigo.SqlCmdIsNull() ?? string.Empty;
    public static string CampoCodigoNotIsNull => CampoCodigo.SqlCmdNotIsNull() ?? string.Empty;

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
    public static DBInfoSystem EstCadastro => new(0, PTabelaNome, CampoCodigo, Cadastro, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem EstCadastroExCod => new(0, PTabelaNome, CampoCodigo, CadastroExCod, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoNumber);
    public static DBInfoSystem EstTipoEnderecoSistema => new(0, PTabelaNome, CampoCodigo, TipoEnderecoSistema, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBTipoEnderecoSistemaDicInfo.CampoCodigo, DBTipoEnderecoSistemaDicInfo.TabelaNome, new DBTipoEnderecoSistemaODicInfo(), false); // DBI 11 
    public static DBInfoSystem EstProcesso => new(0, PTabelaNome, CampoCodigo, Processo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBProcessosDicInfo.CampoCodigo, DBProcessosDicInfo.TabelaNome, new DBProcessosODicInfo(), false); // DBI 11 
    public static DBInfoSystem EstMotivo => new(0, PTabelaNome, CampoCodigo, Motivo, 200, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem EstContatoNoLocal => new(0, PTabelaNome, CampoCodigo, ContatoNoLocal, 50, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoText, true, false, false);
    public static DBInfoSystem EstCidade => new(0, PTabelaNome, CampoCodigo, Cidade, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoForeingkey, DBCidadeDicInfo.CampoCodigo, DBCidadeDicInfo.TabelaNome, new DBCidadeODicInfo(), false); // DBI 11 
    public static DBInfoSystem EstEndereco => new(0, PTabelaNome, CampoCodigo, Endereco, 150, DevourerOne.PEndereco, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextEndereco, true, false, false);
    public static DBInfoSystem EstBairro => new(0, PTabelaNome, CampoCodigo, Bairro, 50, DevourerOne.PBairro, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextBairro, true, false, false);
    public static DBInfoSystem EstCEP => new(0, PTabelaNome, CampoCodigo, CEP, 10, DevourerOne.PCep, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextCep, true, false, false);
    public static DBInfoSystem EstFone => new(0, PTabelaNome, CampoCodigo, Fone, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFone, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFone, true, false, false);
    public static DBInfoSystem EstFax => new(0, PTabelaNome, CampoCodigo, Fax, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PFax, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoTextFax, true, false, false);
    public static DBInfoSystem EstObservacao => new(0, PTabelaNome, CampoCodigo, Observacao, DevourerOne.PMaxSizeCampoMemo, DevourerOne.PSemDescricao, Captions.PCaption_Semdica, ETipoDadosSysteminfo.SysteminfoMemoObservacao, true, false, false);
    public static DBInfoSystem EstGUID => new(0, PTabelaNome, CampoCodigo, GUID, 150, DevourerOne.PGuid, DevourerOne.PTooltipGuid, ETipoDadosSysteminfo.SysteminfoTextGuid, true, false, false);
    public static DBInfoSystem EstQuemCad => new(0, PTabelaNome, CampoCodigo, QuemCad, DevourerOne.PCaptionFieldQuemCad, DevourerOne.PTooltipQuemCad, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemCad, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem EstDtCad => new(0, PTabelaNome, CampoCodigo, DtCad, DevourerOne.PCaptionFieldDtCad, DevourerOne.PTooltipDtCad, ETipoDadosSysteminfo.SysteminfoDataCadastramento);
    public static DBInfoSystem EstQuemAtu => new(0, PTabelaNome, CampoCodigo, QuemAtu, DevourerOne.PCaptionFieldQuemAtu, DevourerOne.PTooltipQuemAtu, ETipoDadosSysteminfo.SysteminfoForeingkeyQuemAtu, DBOperadorDicInfo.CampoCodigo, DBOperadorDicInfo.TabelaNome, new DBOperadorODicInfo(), false); // DBI 11 
    public static DBInfoSystem EstDtAtu => new(0, PTabelaNome, CampoCodigo, DtAtu, DevourerOne.PCaptionFieldDtAtu, DevourerOne.PTooltipDtAtu, ETipoDadosSysteminfo.SysteminfoDataModificacao);
    public static DBInfoSystem EstVisto => new(0, PTabelaNome, CampoCodigo, Visto, DevourerOne.PCaptionFieldAuditorVisto, DevourerOne.PTooltipAuditorVisto, ETipoDadosSysteminfo.SysteminfoBooleanVisto);

#endregion
    public static bool IsThisTable(string nomeTabela) => nomeTabela.ToUpper().Equals(TabelaNome.ToUpper());
#region SMART_SQLServices 
    public static string CadastroDiff(int id) => Cadastro.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string CadastroSql(int id) => Cadastro.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string CadastroIsNull => Cadastro.SqlCmdIsNull() ?? string.Empty;
    public static string CadastroNotIsNull => Cadastro.SqlCmdNotIsNull() ?? string.Empty;

    public static string CadastroExCodDiff(int id) => CadastroExCod.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string CadastroExCodSql(int id) => CadastroExCod.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string CadastroExCodIsNull => CadastroExCod.SqlCmdIsNull() ?? string.Empty;
    public static string CadastroExCodNotIsNull => CadastroExCod.SqlCmdNotIsNull() ?? string.Empty;

    public static string TipoEnderecoSistemaDiff(int id) => TipoEnderecoSistema.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string TipoEnderecoSistemaSql(int id) => TipoEnderecoSistema.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string TipoEnderecoSistemaIsNull => TipoEnderecoSistema.SqlCmdIsNull() ?? string.Empty;
    public static string TipoEnderecoSistemaNotIsNull => TipoEnderecoSistema.SqlCmdNotIsNull() ?? string.Empty;

    public static string ProcessoDiff(int id) => Processo.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string ProcessoSql(int id) => Processo.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string ProcessoIsNull => Processo.SqlCmdIsNull() ?? string.Empty;
    public static string ProcessoNotIsNull => Processo.SqlCmdNotIsNull() ?? string.Empty;

    public static string MotivoSql(string text) => Motivo.SqlCmdTextIgual(text, 200) ?? string.Empty;
    public static string MotivoSqlNotIsNull => Motivo.SqlCmdNotIsNull() ?? string.Empty;
    public static string MotivoSqlIsNull => Motivo.SqlCmdIsNull() ?? string.Empty;

    public static string MotivoSqlDiff(string text) => Motivo.SqlCmdTextDiff(text) ?? string.Empty;
    public static string MotivoSqlLike(string text) => Motivo.SqlCmdTextLike(text) ?? string.Empty;
    public static string MotivoSqlLikeInit(string text) => Motivo.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string MotivoSqlLikeSpaces(string? text) => Motivo.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string ContatoNoLocalSql(string text) => ContatoNoLocal.SqlCmdTextIgual(text, 50) ?? string.Empty;
    public static string ContatoNoLocalSqlNotIsNull => ContatoNoLocal.SqlCmdNotIsNull() ?? string.Empty;
    public static string ContatoNoLocalSqlIsNull => ContatoNoLocal.SqlCmdIsNull() ?? string.Empty;

    public static string ContatoNoLocalSqlDiff(string text) => ContatoNoLocal.SqlCmdTextDiff(text) ?? string.Empty;
    public static string ContatoNoLocalSqlLike(string text) => ContatoNoLocal.SqlCmdTextLike(text) ?? string.Empty;
    public static string ContatoNoLocalSqlLikeInit(string text) => ContatoNoLocal.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string ContatoNoLocalSqlLikeSpaces(string? text) => ContatoNoLocal.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string CidadeDiff(int id) => Cidade.SqlCmdNumberDiff(id) ?? string.Empty;
    public static string CidadeSql(int id) => Cidade.SqlCmdNumberIgual(id) ?? string.Empty;
    public static string CidadeIsNull => Cidade.SqlCmdIsNull() ?? string.Empty;
    public static string CidadeNotIsNull => Cidade.SqlCmdNotIsNull() ?? string.Empty;

    public static string EnderecoSql(string text) => Endereco.SqlCmdTextIgual(text, 150) ?? string.Empty;
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
    public static string FoneSql(string text) => Fone.SqlCmdTextIgual(text) ?? string.Empty;
    public static string FoneSqlNotIsNull => Fone.SqlCmdNotIsNull() ?? string.Empty;
    public static string FoneSqlIsNull => Fone.SqlCmdIsNull() ?? string.Empty;

    public static string FoneSqlDiff(string text) => Fone.SqlCmdTextDiff(text) ?? string.Empty;
    public static string FoneSqlLike(string text) => Fone.SqlCmdTextLike(text) ?? string.Empty;
    public static string FoneSqlLikeInit(string text) => Fone.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string FoneSqlLikeSpaces(string? text) => Fone.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string FaxSql(string text) => Fax.SqlCmdTextIgual(text) ?? string.Empty;
    public static string FaxSqlNotIsNull => Fax.SqlCmdNotIsNull() ?? string.Empty;
    public static string FaxSqlIsNull => Fax.SqlCmdIsNull() ?? string.Empty;

    public static string FaxSqlDiff(string text) => Fax.SqlCmdTextDiff(text) ?? string.Empty;
    public static string FaxSqlLike(string text) => Fax.SqlCmdTextLike(text) ?? string.Empty;
    public static string FaxSqlLikeInit(string text) => Fax.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string FaxSqlLikeSpaces(string? text) => Fax.SqlCmdTextLikeSpaces(text) ?? string.Empty;
    public static string ObservacaoSql(string text) => Observacao.SqlCmdTextIgual(text) ?? string.Empty;
    public static string ObservacaoSqlNotIsNull => Observacao.SqlCmdNotIsNull() ?? string.Empty;
    public static string ObservacaoSqlIsNull => Observacao.SqlCmdIsNull() ?? string.Empty;

    public static string ObservacaoSqlDiff(string text) => Observacao.SqlCmdTextDiff(text) ?? string.Empty;
    public static string ObservacaoSqlLike(string text) => Observacao.SqlCmdTextLike(text) ?? string.Empty;
    public static string ObservacaoSqlLikeInit(string text) => Observacao.SqlCmdTextLikeInit(text) ?? string.Empty;
    public static string ObservacaoSqlLikeSpaces(string? text) => Observacao.SqlCmdTextLikeSpaces(text) ?? string.Empty;
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