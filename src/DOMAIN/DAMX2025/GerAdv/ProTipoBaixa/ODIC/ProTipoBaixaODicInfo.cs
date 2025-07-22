#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBProTipoBaixaODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBProTipoBaixaDicInfo.TabelaNome;
    public string ICampoCodigo() => DBProTipoBaixaDicInfo.CampoCodigo;
    public string IPrefixo() => DBProTipoBaixaDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBProTipoBaixaDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBProTipoBaixaDicInfo.Nome => DBProTipoBaixaDicInfo.PtxNome,
        DBProTipoBaixaDicInfo.Bold => DBProTipoBaixaDicInfo.PtxBold,
        DBProTipoBaixaDicInfo.GUID => DBProTipoBaixaDicInfo.PtxGUID,
        DBProTipoBaixaDicInfo.QuemCad => DBProTipoBaixaDicInfo.PtxQuemCad,
        DBProTipoBaixaDicInfo.DtCad => DBProTipoBaixaDicInfo.PtxDtCad,
        DBProTipoBaixaDicInfo.QuemAtu => DBProTipoBaixaDicInfo.PtxQuemAtu,
        DBProTipoBaixaDicInfo.DtAtu => DBProTipoBaixaDicInfo.PtxDtAtu,
        DBProTipoBaixaDicInfo.Visto => DBProTipoBaixaDicInfo.PtxVisto,
        _ => null
    };
    public static string TCampoCodigo => DBProTipoBaixaDicInfo.CampoCodigo;
    public static string TCampoNome => DBProTipoBaixaDicInfo.CampoNome;
    public static string TTabelaNome => DBProTipoBaixaDicInfo.TabelaNome;
    public static string TTablePrefix => DBProTipoBaixaDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBProTipoBaixaDicInfo.PtxNome, DBProTipoBaixaDicInfo.PtxBold, DBProTipoBaixaDicInfo.PtxGUID, DBProTipoBaixaDicInfo.PtxQuemCad, DBProTipoBaixaDicInfo.PtxDtCad, DBProTipoBaixaDicInfo.PtxQuemAtu, DBProTipoBaixaDicInfo.PtxDtAtu, DBProTipoBaixaDicInfo.PtxVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBProTipoBaixaDicInfo.PtxNome, DBProTipoBaixaDicInfo.PtxGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "ptxCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBProTipoBaixaDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "ptxCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBProTipoBaixaDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
