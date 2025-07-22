#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBApenso2ODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBApenso2DicInfo.TabelaNome;
    public string ICampoCodigo() => DBApenso2DicInfo.CampoCodigo;
    public string IPrefixo() => DBApenso2DicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBApenso2DicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBApenso2DicInfo.Processo => DBApenso2DicInfo.Ap2Processo,
        DBApenso2DicInfo.Apensado => DBApenso2DicInfo.Ap2Apensado,
        DBApenso2DicInfo.QuemCad => DBApenso2DicInfo.Ap2QuemCad,
        DBApenso2DicInfo.DtCad => DBApenso2DicInfo.Ap2DtCad,
        DBApenso2DicInfo.QuemAtu => DBApenso2DicInfo.Ap2QuemAtu,
        DBApenso2DicInfo.DtAtu => DBApenso2DicInfo.Ap2DtAtu,
        DBApenso2DicInfo.Visto => DBApenso2DicInfo.Ap2Visto,
        _ => null
    };
    public static string TCampoCodigo => DBApenso2DicInfo.CampoCodigo;
    public static string TCampoNome => DBApenso2DicInfo.CampoNome;
    public static string TTabelaNome => DBApenso2DicInfo.TabelaNome;
    public static string TTablePrefix => DBApenso2DicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBApenso2DicInfo.Ap2Processo, DBApenso2DicInfo.Ap2Apensado, DBApenso2DicInfo.Ap2QuemCad, DBApenso2DicInfo.Ap2DtCad, DBApenso2DicInfo.Ap2QuemAtu, DBApenso2DicInfo.Ap2DtAtu, DBApenso2DicInfo.Ap2Visto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBApenso2DicInfo.Ap2Processo, DBApenso2DicInfo.Ap2Apensado];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "ap2Codigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBApenso2DicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "ap2Apensado",
            "ap2Codigo",
            "ap2Processo"
        };
        var result = campos.Where(campo => !campo.Equals(DBApenso2DicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
