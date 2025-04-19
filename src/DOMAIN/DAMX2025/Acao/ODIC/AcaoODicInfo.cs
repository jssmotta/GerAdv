#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBAcaoODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBAcaoDicInfo.TabelaNome;
    public string ICampoCodigo() => DBAcaoDicInfo.CampoCodigo;
    public string IPrefixo() => DBAcaoDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBAcaoDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBAcaoDicInfo.Justica => DBAcaoDicInfo.AcaJustica,
        DBAcaoDicInfo.Area => DBAcaoDicInfo.AcaArea,
        DBAcaoDicInfo.Descricao => DBAcaoDicInfo.AcaDescricao,
        DBAcaoDicInfo.GUID => DBAcaoDicInfo.AcaGUID,
        DBAcaoDicInfo.QuemCad => DBAcaoDicInfo.AcaQuemCad,
        DBAcaoDicInfo.DtCad => DBAcaoDicInfo.AcaDtCad,
        DBAcaoDicInfo.QuemAtu => DBAcaoDicInfo.AcaQuemAtu,
        DBAcaoDicInfo.DtAtu => DBAcaoDicInfo.AcaDtAtu,
        DBAcaoDicInfo.Visto => DBAcaoDicInfo.AcaVisto,
        _ => null
    };
    public static string TCampoCodigo => DBAcaoDicInfo.CampoCodigo;
    public static string TCampoNome => DBAcaoDicInfo.CampoNome;
    public static string TTabelaNome => DBAcaoDicInfo.TabelaNome;
    public static string TTablePrefix => DBAcaoDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBAcaoDicInfo.AcaJustica, DBAcaoDicInfo.AcaArea, DBAcaoDicInfo.AcaDescricao, DBAcaoDicInfo.AcaGUID, DBAcaoDicInfo.AcaQuemCad, DBAcaoDicInfo.AcaDtCad, DBAcaoDicInfo.AcaQuemAtu, DBAcaoDicInfo.AcaDtAtu, DBAcaoDicInfo.AcaVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBAcaoDicInfo.AcaJustica, DBAcaoDicInfo.AcaArea, DBAcaoDicInfo.AcaDescricao, DBAcaoDicInfo.AcaGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "acaCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBAcaoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "acaArea",
            "acaCodigo",
            "acaDescricao",
            "acaJustica"
        };
        var result = campos.Where(campo => !campo.Equals(DBAcaoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
