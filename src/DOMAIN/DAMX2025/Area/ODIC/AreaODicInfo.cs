#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBAreaODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBAreaDicInfo.TabelaNome;
    public string ICampoCodigo() => DBAreaDicInfo.CampoCodigo;
    public string IPrefixo() => DBAreaDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBAreaDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBAreaDicInfo.Descricao => DBAreaDicInfo.AreDescricao,
        DBAreaDicInfo.Top => DBAreaDicInfo.AreTop,
        DBAreaDicInfo.GUID => DBAreaDicInfo.AreGUID,
        DBAreaDicInfo.QuemCad => DBAreaDicInfo.AreQuemCad,
        DBAreaDicInfo.DtCad => DBAreaDicInfo.AreDtCad,
        DBAreaDicInfo.QuemAtu => DBAreaDicInfo.AreQuemAtu,
        DBAreaDicInfo.DtAtu => DBAreaDicInfo.AreDtAtu,
        DBAreaDicInfo.Visto => DBAreaDicInfo.AreVisto,
        _ => null
    };
    public static string TCampoCodigo => DBAreaDicInfo.CampoCodigo;
    public static string TCampoNome => DBAreaDicInfo.CampoNome;
    public static string TTabelaNome => DBAreaDicInfo.TabelaNome;
    public static string TTablePrefix => DBAreaDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBAreaDicInfo.AreDescricao, DBAreaDicInfo.AreTop, DBAreaDicInfo.AreGUID, DBAreaDicInfo.AreQuemCad, DBAreaDicInfo.AreDtCad, DBAreaDicInfo.AreQuemAtu, DBAreaDicInfo.AreDtAtu, DBAreaDicInfo.AreVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBAreaDicInfo.AreDescricao, DBAreaDicInfo.AreTop];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "areCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBAreaDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "areCodigo",
            "areDescricao"
        };
        var result = campos.Where(campo => !campo.Equals(DBAreaDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
