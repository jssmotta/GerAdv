#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBAreasJusticaODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBAreasJusticaDicInfo.TabelaNome;
    public string ICampoCodigo() => DBAreasJusticaDicInfo.CampoCodigo;
    public string IPrefixo() => DBAreasJusticaDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => false;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBAreasJusticaDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => false;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBAreasJusticaDicInfo.Area => DBAreasJusticaDicInfo.ArjArea,
        DBAreasJusticaDicInfo.Justica => DBAreasJusticaDicInfo.ArjJustica,
        _ => null
    };
    public static string TCampoCodigo => DBAreasJusticaDicInfo.CampoCodigo;
    public static string TCampoNome => DBAreasJusticaDicInfo.CampoNome;
    public static string TTabelaNome => DBAreasJusticaDicInfo.TabelaNome;
    public static string TTablePrefix => DBAreasJusticaDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBAreasJusticaDicInfo.ArjArea, DBAreasJusticaDicInfo.ArjJustica];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBAreasJusticaDicInfo.ArjArea, DBAreasJusticaDicInfo.ArjJustica];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "arjCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBAreasJusticaDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "arjArea",
            "arjCodigo",
            "arjJustica"
        };
        var result = campos.Where(campo => !campo.Equals(DBAreasJusticaDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
