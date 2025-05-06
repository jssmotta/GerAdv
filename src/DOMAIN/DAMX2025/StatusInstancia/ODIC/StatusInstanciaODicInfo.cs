#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBStatusInstanciaODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBStatusInstanciaDicInfo.TabelaNome;
    public string ICampoCodigo() => DBStatusInstanciaDicInfo.CampoCodigo;
    public string IPrefixo() => DBStatusInstanciaDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBStatusInstanciaDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBStatusInstanciaDicInfo.Nome => DBStatusInstanciaDicInfo.IstNome,
        DBStatusInstanciaDicInfo.Bold => DBStatusInstanciaDicInfo.IstBold,
        DBStatusInstanciaDicInfo.GUID => DBStatusInstanciaDicInfo.IstGUID,
        DBStatusInstanciaDicInfo.QuemCad => DBStatusInstanciaDicInfo.IstQuemCad,
        DBStatusInstanciaDicInfo.DtCad => DBStatusInstanciaDicInfo.IstDtCad,
        DBStatusInstanciaDicInfo.QuemAtu => DBStatusInstanciaDicInfo.IstQuemAtu,
        DBStatusInstanciaDicInfo.DtAtu => DBStatusInstanciaDicInfo.IstDtAtu,
        DBStatusInstanciaDicInfo.Visto => DBStatusInstanciaDicInfo.IstVisto,
        _ => null
    };
    public static string TCampoCodigo => DBStatusInstanciaDicInfo.CampoCodigo;
    public static string TCampoNome => DBStatusInstanciaDicInfo.CampoNome;
    public static string TTabelaNome => DBStatusInstanciaDicInfo.TabelaNome;
    public static string TTablePrefix => DBStatusInstanciaDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBStatusInstanciaDicInfo.IstNome, DBStatusInstanciaDicInfo.IstBold, DBStatusInstanciaDicInfo.IstGUID, DBStatusInstanciaDicInfo.IstQuemCad, DBStatusInstanciaDicInfo.IstDtCad, DBStatusInstanciaDicInfo.IstQuemAtu, DBStatusInstanciaDicInfo.IstDtAtu, DBStatusInstanciaDicInfo.IstVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBStatusInstanciaDicInfo.IstNome, DBStatusInstanciaDicInfo.IstBold, DBStatusInstanciaDicInfo.IstGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "istCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBStatusInstanciaDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "istCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBStatusInstanciaDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
