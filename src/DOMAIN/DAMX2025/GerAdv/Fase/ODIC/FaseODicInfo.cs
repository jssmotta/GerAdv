#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBFaseODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBFaseDicInfo.TabelaNome;
    public string ICampoCodigo() => DBFaseDicInfo.CampoCodigo;
    public string IPrefixo() => DBFaseDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBFaseDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBFaseDicInfo.Descricao => DBFaseDicInfo.FasDescricao,
        DBFaseDicInfo.Justica => DBFaseDicInfo.FasJustica,
        DBFaseDicInfo.Area => DBFaseDicInfo.FasArea,
        DBFaseDicInfo.GUID => DBFaseDicInfo.FasGUID,
        DBFaseDicInfo.QuemCad => DBFaseDicInfo.FasQuemCad,
        DBFaseDicInfo.DtCad => DBFaseDicInfo.FasDtCad,
        DBFaseDicInfo.QuemAtu => DBFaseDicInfo.FasQuemAtu,
        DBFaseDicInfo.DtAtu => DBFaseDicInfo.FasDtAtu,
        DBFaseDicInfo.Visto => DBFaseDicInfo.FasVisto,
        _ => null
    };
    public static string TCampoCodigo => DBFaseDicInfo.CampoCodigo;
    public static string TCampoNome => DBFaseDicInfo.CampoNome;
    public static string TTabelaNome => DBFaseDicInfo.TabelaNome;
    public static string TTablePrefix => DBFaseDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBFaseDicInfo.FasDescricao, DBFaseDicInfo.FasJustica, DBFaseDicInfo.FasArea, DBFaseDicInfo.FasGUID, DBFaseDicInfo.FasQuemCad, DBFaseDicInfo.FasDtCad, DBFaseDicInfo.FasQuemAtu, DBFaseDicInfo.FasDtAtu, DBFaseDicInfo.FasVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBFaseDicInfo.FasDescricao, DBFaseDicInfo.FasJustica, DBFaseDicInfo.FasArea, DBFaseDicInfo.FasGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "fasCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBFaseDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "fasCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBFaseDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
