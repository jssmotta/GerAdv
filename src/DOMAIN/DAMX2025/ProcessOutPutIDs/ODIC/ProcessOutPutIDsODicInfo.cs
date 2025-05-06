#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBProcessOutPutIDsODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBProcessOutPutIDsDicInfo.TabelaNome;
    public string ICampoCodigo() => DBProcessOutPutIDsDicInfo.CampoCodigo;
    public string IPrefixo() => DBProcessOutPutIDsDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => false;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBProcessOutPutIDsDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => false;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBProcessOutPutIDsDicInfo.Nome => DBProcessOutPutIDsDicInfo.PoiNome,
        DBProcessOutPutIDsDicInfo.GUID => DBProcessOutPutIDsDicInfo.PoiGUID,
        _ => null
    };
    public static string TCampoCodigo => DBProcessOutPutIDsDicInfo.CampoCodigo;
    public static string TCampoNome => DBProcessOutPutIDsDicInfo.CampoNome;
    public static string TTabelaNome => DBProcessOutPutIDsDicInfo.TabelaNome;
    public static string TTablePrefix => DBProcessOutPutIDsDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBProcessOutPutIDsDicInfo.PoiNome, DBProcessOutPutIDsDicInfo.PoiGUID];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBProcessOutPutIDsDicInfo.PoiNome, DBProcessOutPutIDsDicInfo.PoiGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "poiCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBProcessOutPutIDsDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "poiCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBProcessOutPutIDsDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
