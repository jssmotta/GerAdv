#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBTipoEMailODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBTipoEMailDicInfo.TabelaNome;
    public string ICampoCodigo() => DBTipoEMailDicInfo.CampoCodigo;
    public string IPrefixo() => DBTipoEMailDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => false;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBTipoEMailDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => false;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBTipoEMailDicInfo.Nome => DBTipoEMailDicInfo.TmlNome,
        _ => null
    };
    public static string TCampoCodigo => DBTipoEMailDicInfo.CampoCodigo;
    public static string TCampoNome => DBTipoEMailDicInfo.CampoNome;
    public static string TTabelaNome => DBTipoEMailDicInfo.TabelaNome;
    public static string TTablePrefix => DBTipoEMailDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBTipoEMailDicInfo.TmlNome];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBTipoEMailDicInfo.TmlNome];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "tmlNome"
        };
        var result = campos.Where(campo => !campo.Equals(DBTipoEMailDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "tmlCodigo",
            "tmlNome"
        };
        var result = campos.Where(campo => !campo.Equals(DBTipoEMailDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
