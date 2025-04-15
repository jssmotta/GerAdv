#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBObjetosODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBObjetosDicInfo.TabelaNome;
    public string ICampoCodigo() => DBObjetosDicInfo.CampoCodigo;
    public string IPrefixo() => DBObjetosDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBObjetosDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBObjetosDicInfo.Justica => DBObjetosDicInfo.OjtJustica,
        DBObjetosDicInfo.Area => DBObjetosDicInfo.OjtArea,
        DBObjetosDicInfo.Nome => DBObjetosDicInfo.OjtNome,
        DBObjetosDicInfo.Bold => DBObjetosDicInfo.OjtBold,
        DBObjetosDicInfo.GUID => DBObjetosDicInfo.OjtGUID,
        DBObjetosDicInfo.QuemCad => DBObjetosDicInfo.OjtQuemCad,
        DBObjetosDicInfo.DtCad => DBObjetosDicInfo.OjtDtCad,
        DBObjetosDicInfo.QuemAtu => DBObjetosDicInfo.OjtQuemAtu,
        DBObjetosDicInfo.DtAtu => DBObjetosDicInfo.OjtDtAtu,
        DBObjetosDicInfo.Visto => DBObjetosDicInfo.OjtVisto,
        _ => null
    };
    public static string TCampoCodigo => DBObjetosDicInfo.CampoCodigo;
    public static string TCampoNome => DBObjetosDicInfo.CampoNome;
    public static string TTabelaNome => DBObjetosDicInfo.TabelaNome;
    public static string TTablePrefix => DBObjetosDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBObjetosDicInfo.OjtJustica, DBObjetosDicInfo.OjtArea, DBObjetosDicInfo.OjtNome, DBObjetosDicInfo.OjtBold, DBObjetosDicInfo.OjtGUID, DBObjetosDicInfo.OjtQuemCad, DBObjetosDicInfo.OjtDtCad, DBObjetosDicInfo.OjtQuemAtu, DBObjetosDicInfo.OjtDtAtu, DBObjetosDicInfo.OjtVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBObjetosDicInfo.OjtJustica, DBObjetosDicInfo.OjtArea, DBObjetosDicInfo.OjtNome, DBObjetosDicInfo.OjtBold];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "ojtCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBObjetosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "ojtArea",
            "ojtCodigo",
            "ojtJustica",
            "ojtNome"
        };
        var result = campos.Where(campo => !campo.Equals(DBObjetosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
