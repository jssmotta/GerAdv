#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBTipoProDespositoODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBTipoProDespositoDicInfo.TabelaNome;
    public string ICampoCodigo() => DBTipoProDespositoDicInfo.CampoCodigo;
    public string IPrefixo() => DBTipoProDespositoDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => false;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBTipoProDespositoDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => false;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBTipoProDespositoDicInfo.Nome => DBTipoProDespositoDicInfo.TpdNome,
        _ => null
    };
    public static string TCampoCodigo => DBTipoProDespositoDicInfo.CampoCodigo;
    public static string TCampoNome => DBTipoProDespositoDicInfo.CampoNome;
    public static string TTabelaNome => DBTipoProDespositoDicInfo.TabelaNome;
    public static string TTablePrefix => DBTipoProDespositoDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBTipoProDespositoDicInfo.TpdNome];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBTipoProDespositoDicInfo.TpdNome];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "tpdCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBTipoProDespositoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "tpdCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBTipoProDespositoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
