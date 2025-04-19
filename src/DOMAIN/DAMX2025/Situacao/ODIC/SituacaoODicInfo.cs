#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBSituacaoODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBSituacaoDicInfo.TabelaNome;
    public string ICampoCodigo() => DBSituacaoDicInfo.CampoCodigo;
    public string IPrefixo() => DBSituacaoDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBSituacaoDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBSituacaoDicInfo.Parte_Int => DBSituacaoDicInfo.SitParte_Int,
        DBSituacaoDicInfo.Parte_Opo => DBSituacaoDicInfo.SitParte_Opo,
        DBSituacaoDicInfo.Top => DBSituacaoDicInfo.SitTop,
        DBSituacaoDicInfo.Bold => DBSituacaoDicInfo.SitBold,
        DBSituacaoDicInfo.GUID => DBSituacaoDicInfo.SitGUID,
        DBSituacaoDicInfo.QuemCad => DBSituacaoDicInfo.SitQuemCad,
        DBSituacaoDicInfo.DtCad => DBSituacaoDicInfo.SitDtCad,
        DBSituacaoDicInfo.QuemAtu => DBSituacaoDicInfo.SitQuemAtu,
        DBSituacaoDicInfo.DtAtu => DBSituacaoDicInfo.SitDtAtu,
        DBSituacaoDicInfo.Visto => DBSituacaoDicInfo.SitVisto,
        _ => null
    };
    public static string TCampoCodigo => DBSituacaoDicInfo.CampoCodigo;
    public static string TCampoNome => DBSituacaoDicInfo.CampoNome;
    public static string TTabelaNome => DBSituacaoDicInfo.TabelaNome;
    public static string TTablePrefix => DBSituacaoDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBSituacaoDicInfo.SitParte_Int, DBSituacaoDicInfo.SitParte_Opo, DBSituacaoDicInfo.SitTop, DBSituacaoDicInfo.SitBold, DBSituacaoDicInfo.SitGUID, DBSituacaoDicInfo.SitQuemCad, DBSituacaoDicInfo.SitDtCad, DBSituacaoDicInfo.SitQuemAtu, DBSituacaoDicInfo.SitDtAtu, DBSituacaoDicInfo.SitVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBSituacaoDicInfo.SitParte_Int, DBSituacaoDicInfo.SitParte_Opo, DBSituacaoDicInfo.SitTop, DBSituacaoDicInfo.SitBold, DBSituacaoDicInfo.SitGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "sitCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBSituacaoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "sitCodigo",
            "sitParte_Int",
            "sitParte_Opo"
        };
        var result = campos.Where(campo => !campo.Equals(DBSituacaoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
