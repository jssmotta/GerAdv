#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBStatusHTrabODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBStatusHTrabDicInfo.TabelaNome;
    public string ICampoCodigo() => DBStatusHTrabDicInfo.CampoCodigo;
    public string IPrefixo() => DBStatusHTrabDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => false;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBStatusHTrabDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => false;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBStatusHTrabDicInfo.Descricao => DBStatusHTrabDicInfo.ShtDescricao,
        DBStatusHTrabDicInfo.ResID => DBStatusHTrabDicInfo.ShtResID,
        _ => null
    };
    public static string TCampoCodigo => DBStatusHTrabDicInfo.CampoCodigo;
    public static string TCampoNome => DBStatusHTrabDicInfo.CampoNome;
    public static string TTabelaNome => DBStatusHTrabDicInfo.TabelaNome;
    public static string TTablePrefix => DBStatusHTrabDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBStatusHTrabDicInfo.ShtDescricao, DBStatusHTrabDicInfo.ShtResID];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBStatusHTrabDicInfo.ShtDescricao, DBStatusHTrabDicInfo.ShtResID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "shtCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBStatusHTrabDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "shtCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBStatusHTrabDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
