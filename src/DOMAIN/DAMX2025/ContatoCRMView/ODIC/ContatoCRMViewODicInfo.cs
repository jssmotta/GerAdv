#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBContatoCRMViewODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBContatoCRMViewDicInfo.TabelaNome;
    public string ICampoCodigo() => DBContatoCRMViewDicInfo.CampoCodigo;
    public string IPrefixo() => DBContatoCRMViewDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => false;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBContatoCRMViewDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => false;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBContatoCRMViewDicInfo.CGUID => DBContatoCRMViewDicInfo.CcwCGUID,
        DBContatoCRMViewDicInfo.Data => DBContatoCRMViewDicInfo.CcwData,
        DBContatoCRMViewDicInfo.IP => DBContatoCRMViewDicInfo.CcwIP,
        _ => null
    };
    public static string TCampoCodigo => DBContatoCRMViewDicInfo.CampoCodigo;
    public static string TCampoNome => DBContatoCRMViewDicInfo.CampoNome;
    public static string TTabelaNome => DBContatoCRMViewDicInfo.TabelaNome;
    public static string TTablePrefix => DBContatoCRMViewDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBContatoCRMViewDicInfo.CcwCGUID, DBContatoCRMViewDicInfo.CcwData, DBContatoCRMViewDicInfo.CcwIP];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBContatoCRMViewDicInfo.CcwData, DBContatoCRMViewDicInfo.CcwIP];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "ccwCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBContatoCRMViewDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "ccwCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBContatoCRMViewDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
