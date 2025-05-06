#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBServicosODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBServicosDicInfo.TabelaNome;
    public string ICampoCodigo() => DBServicosDicInfo.CampoCodigo;
    public string IPrefixo() => DBServicosDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBServicosDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBServicosDicInfo.Cobrar => DBServicosDicInfo.SerCobrar,
        DBServicosDicInfo.Descricao => DBServicosDicInfo.SerDescricao,
        DBServicosDicInfo.Basico => DBServicosDicInfo.SerBasico,
        DBServicosDicInfo.GUID => DBServicosDicInfo.SerGUID,
        DBServicosDicInfo.QuemCad => DBServicosDicInfo.SerQuemCad,
        DBServicosDicInfo.DtCad => DBServicosDicInfo.SerDtCad,
        DBServicosDicInfo.QuemAtu => DBServicosDicInfo.SerQuemAtu,
        DBServicosDicInfo.DtAtu => DBServicosDicInfo.SerDtAtu,
        DBServicosDicInfo.Visto => DBServicosDicInfo.SerVisto,
        _ => null
    };
    public static string TCampoCodigo => DBServicosDicInfo.CampoCodigo;
    public static string TCampoNome => DBServicosDicInfo.CampoNome;
    public static string TTabelaNome => DBServicosDicInfo.TabelaNome;
    public static string TTablePrefix => DBServicosDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBServicosDicInfo.SerCobrar, DBServicosDicInfo.SerDescricao, DBServicosDicInfo.SerBasico, DBServicosDicInfo.SerGUID, DBServicosDicInfo.SerQuemCad, DBServicosDicInfo.SerDtCad, DBServicosDicInfo.SerQuemAtu, DBServicosDicInfo.SerDtAtu, DBServicosDicInfo.SerVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBServicosDicInfo.SerCobrar, DBServicosDicInfo.SerDescricao, DBServicosDicInfo.SerBasico, DBServicosDicInfo.SerGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "serCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBServicosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "serCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBServicosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
