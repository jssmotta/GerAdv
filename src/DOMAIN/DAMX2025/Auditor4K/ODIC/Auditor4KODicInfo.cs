#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBAuditor4KODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBAuditor4KDicInfo.TabelaNome;
    public string ICampoCodigo() => DBAuditor4KDicInfo.CampoCodigo;
    public string IPrefixo() => DBAuditor4KDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBAuditor4KDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBAuditor4KDicInfo.Nome => DBAuditor4KDicInfo.AudNome,
        DBAuditor4KDicInfo.GUID => DBAuditor4KDicInfo.AudGUID,
        DBAuditor4KDicInfo.QuemCad => DBAuditor4KDicInfo.AudQuemCad,
        DBAuditor4KDicInfo.DtCad => DBAuditor4KDicInfo.AudDtCad,
        DBAuditor4KDicInfo.QuemAtu => DBAuditor4KDicInfo.AudQuemAtu,
        DBAuditor4KDicInfo.DtAtu => DBAuditor4KDicInfo.AudDtAtu,
        DBAuditor4KDicInfo.Visto => DBAuditor4KDicInfo.AudVisto,
        _ => null
    };
    public static string TCampoCodigo => DBAuditor4KDicInfo.CampoCodigo;
    public static string TCampoNome => DBAuditor4KDicInfo.CampoNome;
    public static string TTabelaNome => DBAuditor4KDicInfo.TabelaNome;
    public static string TTablePrefix => DBAuditor4KDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBAuditor4KDicInfo.AudNome, DBAuditor4KDicInfo.AudGUID, DBAuditor4KDicInfo.AudQuemCad, DBAuditor4KDicInfo.AudDtCad, DBAuditor4KDicInfo.AudQuemAtu, DBAuditor4KDicInfo.AudDtAtu, DBAuditor4KDicInfo.AudVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBAuditor4KDicInfo.AudNome, DBAuditor4KDicInfo.AudGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "audCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBAuditor4KDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "audCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBAuditor4KDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
