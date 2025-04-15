#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBBensMateriaisODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBBensMateriaisDicInfo.TabelaNome;
    public string ICampoCodigo() => DBBensMateriaisDicInfo.CampoCodigo;
    public string IPrefixo() => DBBensMateriaisDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBBensMateriaisDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBBensMateriaisDicInfo.Nome => DBBensMateriaisDicInfo.BmtNome,
        DBBensMateriaisDicInfo.BensClassificacao => DBBensMateriaisDicInfo.BmtBensClassificacao,
        DBBensMateriaisDicInfo.DataCompra => DBBensMateriaisDicInfo.BmtDataCompra,
        DBBensMateriaisDicInfo.DataFimDaGarantia => DBBensMateriaisDicInfo.BmtDataFimDaGarantia,
        DBBensMateriaisDicInfo.NFNRO => DBBensMateriaisDicInfo.BmtNFNRO,
        DBBensMateriaisDicInfo.Fornecedor => DBBensMateriaisDicInfo.BmtFornecedor,
        DBBensMateriaisDicInfo.ValorBem => DBBensMateriaisDicInfo.BmtValorBem,
        DBBensMateriaisDicInfo.NroSerieProduto => DBBensMateriaisDicInfo.BmtNroSerieProduto,
        DBBensMateriaisDicInfo.Comprador => DBBensMateriaisDicInfo.BmtComprador,
        DBBensMateriaisDicInfo.Cidade => DBBensMateriaisDicInfo.BmtCidade,
        DBBensMateriaisDicInfo.GarantiaLoja => DBBensMateriaisDicInfo.BmtGarantiaLoja,
        DBBensMateriaisDicInfo.DataTerminoDaGarantiaDaLoja => DBBensMateriaisDicInfo.BmtDataTerminoDaGarantiaDaLoja,
        DBBensMateriaisDicInfo.Observacoes => DBBensMateriaisDicInfo.BmtObservacoes,
        DBBensMateriaisDicInfo.NomeVendedor => DBBensMateriaisDicInfo.BmtNomeVendedor,
        DBBensMateriaisDicInfo.Bold => DBBensMateriaisDicInfo.BmtBold,
        DBBensMateriaisDicInfo.GUID => DBBensMateriaisDicInfo.BmtGUID,
        DBBensMateriaisDicInfo.QuemCad => DBBensMateriaisDicInfo.BmtQuemCad,
        DBBensMateriaisDicInfo.DtCad => DBBensMateriaisDicInfo.BmtDtCad,
        DBBensMateriaisDicInfo.QuemAtu => DBBensMateriaisDicInfo.BmtQuemAtu,
        DBBensMateriaisDicInfo.DtAtu => DBBensMateriaisDicInfo.BmtDtAtu,
        DBBensMateriaisDicInfo.Visto => DBBensMateriaisDicInfo.BmtVisto,
        _ => null
    };
    public static string TCampoCodigo => DBBensMateriaisDicInfo.CampoCodigo;
    public static string TCampoNome => DBBensMateriaisDicInfo.CampoNome;
    public static string TTabelaNome => DBBensMateriaisDicInfo.TabelaNome;
    public static string TTablePrefix => DBBensMateriaisDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBBensMateriaisDicInfo.BmtNome, DBBensMateriaisDicInfo.BmtBensClassificacao, DBBensMateriaisDicInfo.BmtDataCompra, DBBensMateriaisDicInfo.BmtDataFimDaGarantia, DBBensMateriaisDicInfo.BmtNFNRO, DBBensMateriaisDicInfo.BmtFornecedor, DBBensMateriaisDicInfo.BmtValorBem, DBBensMateriaisDicInfo.BmtNroSerieProduto, DBBensMateriaisDicInfo.BmtComprador, DBBensMateriaisDicInfo.BmtCidade, DBBensMateriaisDicInfo.BmtGarantiaLoja, DBBensMateriaisDicInfo.BmtDataTerminoDaGarantiaDaLoja, DBBensMateriaisDicInfo.BmtObservacoes, DBBensMateriaisDicInfo.BmtNomeVendedor, DBBensMateriaisDicInfo.BmtBold, DBBensMateriaisDicInfo.BmtGUID, DBBensMateriaisDicInfo.BmtQuemCad, DBBensMateriaisDicInfo.BmtDtCad, DBBensMateriaisDicInfo.BmtQuemAtu, DBBensMateriaisDicInfo.BmtDtAtu, DBBensMateriaisDicInfo.BmtVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBBensMateriaisDicInfo.BmtNome, DBBensMateriaisDicInfo.BmtBensClassificacao, DBBensMateriaisDicInfo.BmtDataCompra, DBBensMateriaisDicInfo.BmtDataFimDaGarantia, DBBensMateriaisDicInfo.BmtNFNRO, DBBensMateriaisDicInfo.BmtFornecedor, DBBensMateriaisDicInfo.BmtValorBem, DBBensMateriaisDicInfo.BmtNroSerieProduto, DBBensMateriaisDicInfo.BmtComprador, DBBensMateriaisDicInfo.BmtCidade, DBBensMateriaisDicInfo.BmtGarantiaLoja, DBBensMateriaisDicInfo.BmtDataTerminoDaGarantiaDaLoja, DBBensMateriaisDicInfo.BmtObservacoes, DBBensMateriaisDicInfo.BmtNomeVendedor, DBBensMateriaisDicInfo.BmtBold];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "bmtCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBBensMateriaisDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "bmtCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBBensMateriaisDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
