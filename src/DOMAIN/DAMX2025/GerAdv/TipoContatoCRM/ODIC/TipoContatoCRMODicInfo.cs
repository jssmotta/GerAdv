#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBTipoContatoCRMODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBTipoContatoCRMDicInfo.TabelaNome;
    public string ICampoCodigo() => DBTipoContatoCRMDicInfo.CampoCodigo;
    public string IPrefixo() => DBTipoContatoCRMDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBTipoContatoCRMDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBTipoContatoCRMDicInfo.Nome => DBTipoContatoCRMDicInfo.TccNome,
        DBTipoContatoCRMDicInfo.Bold => DBTipoContatoCRMDicInfo.TccBold,
        DBTipoContatoCRMDicInfo.GUID => DBTipoContatoCRMDicInfo.TccGUID,
        DBTipoContatoCRMDicInfo.QuemCad => DBTipoContatoCRMDicInfo.TccQuemCad,
        DBTipoContatoCRMDicInfo.DtCad => DBTipoContatoCRMDicInfo.TccDtCad,
        DBTipoContatoCRMDicInfo.QuemAtu => DBTipoContatoCRMDicInfo.TccQuemAtu,
        DBTipoContatoCRMDicInfo.DtAtu => DBTipoContatoCRMDicInfo.TccDtAtu,
        DBTipoContatoCRMDicInfo.Visto => DBTipoContatoCRMDicInfo.TccVisto,
        _ => null
    };
    public static string TCampoCodigo => DBTipoContatoCRMDicInfo.CampoCodigo;
    public static string TCampoNome => DBTipoContatoCRMDicInfo.CampoNome;
    public static string TTabelaNome => DBTipoContatoCRMDicInfo.TabelaNome;
    public static string TTablePrefix => DBTipoContatoCRMDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBTipoContatoCRMDicInfo.TccNome, DBTipoContatoCRMDicInfo.TccBold, DBTipoContatoCRMDicInfo.TccGUID, DBTipoContatoCRMDicInfo.TccQuemCad, DBTipoContatoCRMDicInfo.TccDtCad, DBTipoContatoCRMDicInfo.TccQuemAtu, DBTipoContatoCRMDicInfo.TccDtAtu, DBTipoContatoCRMDicInfo.TccVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBTipoContatoCRMDicInfo.TccNome, DBTipoContatoCRMDicInfo.TccGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "tccCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBTipoContatoCRMDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "tccCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBTipoContatoCRMDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
