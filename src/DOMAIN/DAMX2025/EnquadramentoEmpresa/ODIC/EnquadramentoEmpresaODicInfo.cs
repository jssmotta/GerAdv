#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBEnquadramentoEmpresaODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBEnquadramentoEmpresaDicInfo.TabelaNome;
    public string ICampoCodigo() => DBEnquadramentoEmpresaDicInfo.CampoCodigo;
    public string IPrefixo() => DBEnquadramentoEmpresaDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBEnquadramentoEmpresaDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBEnquadramentoEmpresaDicInfo.Nome => DBEnquadramentoEmpresaDicInfo.EqeNome,
        DBEnquadramentoEmpresaDicInfo.GUID => DBEnquadramentoEmpresaDicInfo.EqeGUID,
        DBEnquadramentoEmpresaDicInfo.QuemCad => DBEnquadramentoEmpresaDicInfo.EqeQuemCad,
        DBEnquadramentoEmpresaDicInfo.DtCad => DBEnquadramentoEmpresaDicInfo.EqeDtCad,
        DBEnquadramentoEmpresaDicInfo.QuemAtu => DBEnquadramentoEmpresaDicInfo.EqeQuemAtu,
        DBEnquadramentoEmpresaDicInfo.DtAtu => DBEnquadramentoEmpresaDicInfo.EqeDtAtu,
        DBEnquadramentoEmpresaDicInfo.Visto => DBEnquadramentoEmpresaDicInfo.EqeVisto,
        _ => null
    };
    public static string TCampoCodigo => DBEnquadramentoEmpresaDicInfo.CampoCodigo;
    public static string TCampoNome => DBEnquadramentoEmpresaDicInfo.CampoNome;
    public static string TTabelaNome => DBEnquadramentoEmpresaDicInfo.TabelaNome;
    public static string TTablePrefix => DBEnquadramentoEmpresaDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBEnquadramentoEmpresaDicInfo.EqeNome, DBEnquadramentoEmpresaDicInfo.EqeGUID, DBEnquadramentoEmpresaDicInfo.EqeQuemCad, DBEnquadramentoEmpresaDicInfo.EqeDtCad, DBEnquadramentoEmpresaDicInfo.EqeQuemAtu, DBEnquadramentoEmpresaDicInfo.EqeDtAtu, DBEnquadramentoEmpresaDicInfo.EqeVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBEnquadramentoEmpresaDicInfo.EqeNome];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "eqeCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBEnquadramentoEmpresaDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "eqeCodigo",
            "eqeNome"
        };
        var result = campos.Where(campo => !campo.Equals(DBEnquadramentoEmpresaDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
