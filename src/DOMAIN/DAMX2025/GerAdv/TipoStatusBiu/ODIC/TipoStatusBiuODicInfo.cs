#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBTipoStatusBiuODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBTipoStatusBiuDicInfo.TabelaNome;
    public string ICampoCodigo() => DBTipoStatusBiuDicInfo.CampoCodigo;
    public string IPrefixo() => DBTipoStatusBiuDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => false;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBTipoStatusBiuDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => false;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBTipoStatusBiuDicInfo.Nome => DBTipoStatusBiuDicInfo.TsbNome,
        _ => null
    };
    public static string TCampoCodigo => DBTipoStatusBiuDicInfo.CampoCodigo;
    public static string TCampoNome => DBTipoStatusBiuDicInfo.CampoNome;
    public static string TTabelaNome => DBTipoStatusBiuDicInfo.TabelaNome;
    public static string TTablePrefix => DBTipoStatusBiuDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBTipoStatusBiuDicInfo.TsbNome];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBTipoStatusBiuDicInfo.TsbNome];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "tsbNome"
        };
        var result = campos.Where(campo => !campo.Equals(DBTipoStatusBiuDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "tsbCodigo",
            "tsbNome"
        };
        var result = campos.Where(campo => !campo.Equals(DBTipoStatusBiuDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
