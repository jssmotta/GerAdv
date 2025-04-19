#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBGraphODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBGraphDicInfo.TabelaNome;
    public string ICampoCodigo() => DBGraphDicInfo.CampoCodigo;
    public string IPrefixo() => DBGraphDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBGraphDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBGraphDicInfo.Tabela => DBGraphDicInfo.GphTabela,
        DBGraphDicInfo.TabelaId => DBGraphDicInfo.GphTabelaId,
        DBGraphDicInfo.Imagem => DBGraphDicInfo.GphImagem,
        DBGraphDicInfo.GUID => DBGraphDicInfo.GphGUID,
        DBGraphDicInfo.QuemCad => DBGraphDicInfo.GphQuemCad,
        DBGraphDicInfo.DtCad => DBGraphDicInfo.GphDtCad,
        DBGraphDicInfo.QuemAtu => DBGraphDicInfo.GphQuemAtu,
        DBGraphDicInfo.DtAtu => DBGraphDicInfo.GphDtAtu,
        DBGraphDicInfo.Visto => DBGraphDicInfo.GphVisto,
        _ => null
    };
    public static string TCampoCodigo => DBGraphDicInfo.CampoCodigo;
    public static string TCampoNome => DBGraphDicInfo.CampoNome;
    public static string TTabelaNome => DBGraphDicInfo.TabelaNome;
    public static string TTablePrefix => DBGraphDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBGraphDicInfo.GphTabela, DBGraphDicInfo.GphTabelaId, DBGraphDicInfo.GphImagem, DBGraphDicInfo.GphGUID, DBGraphDicInfo.GphQuemCad, DBGraphDicInfo.GphDtCad, DBGraphDicInfo.GphQuemAtu, DBGraphDicInfo.GphDtAtu, DBGraphDicInfo.GphVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBGraphDicInfo.GphTabela, DBGraphDicInfo.GphTabelaId, DBGraphDicInfo.GphImagem, DBGraphDicInfo.GphGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "gphTabela",
            "gphTabelaId"
        };
        var result = campos.Where(campo => !campo.Equals(DBGraphDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "gphCodigo",
            "gphTabela",
            "gphTabelaId"
        };
        var result = campos.Where(campo => !campo.Equals(DBGraphDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
