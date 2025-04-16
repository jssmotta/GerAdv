#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBCidadeODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBCidadeDicInfo.TabelaNome;
    public string ICampoCodigo() => DBCidadeDicInfo.CampoCodigo;
    public string IPrefixo() => DBCidadeDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBCidadeDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBCidadeDicInfo.DDD => DBCidadeDicInfo.CidDDD,
        DBCidadeDicInfo.Top => DBCidadeDicInfo.CidTop,
        DBCidadeDicInfo.Comarca => DBCidadeDicInfo.CidComarca,
        DBCidadeDicInfo.Capital => DBCidadeDicInfo.CidCapital,
        DBCidadeDicInfo.Nome => DBCidadeDicInfo.CidNome,
        DBCidadeDicInfo.UF => DBCidadeDicInfo.CidUF,
        DBCidadeDicInfo.Sigla => DBCidadeDicInfo.CidSigla,
        DBCidadeDicInfo.GUID => DBCidadeDicInfo.CidGUID,
        DBCidadeDicInfo.QuemCad => DBCidadeDicInfo.CidQuemCad,
        DBCidadeDicInfo.DtCad => DBCidadeDicInfo.CidDtCad,
        DBCidadeDicInfo.QuemAtu => DBCidadeDicInfo.CidQuemAtu,
        DBCidadeDicInfo.DtAtu => DBCidadeDicInfo.CidDtAtu,
        DBCidadeDicInfo.Visto => DBCidadeDicInfo.CidVisto,
        _ => null
    };
    public static string TCampoCodigo => DBCidadeDicInfo.CampoCodigo;
    public static string TCampoNome => DBCidadeDicInfo.CampoNome;
    public static string TTabelaNome => DBCidadeDicInfo.TabelaNome;
    public static string TTablePrefix => DBCidadeDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBCidadeDicInfo.CidDDD, DBCidadeDicInfo.CidTop, DBCidadeDicInfo.CidComarca, DBCidadeDicInfo.CidCapital, DBCidadeDicInfo.CidNome, DBCidadeDicInfo.CidUF, DBCidadeDicInfo.CidSigla, DBCidadeDicInfo.CidGUID, DBCidadeDicInfo.CidQuemCad, DBCidadeDicInfo.CidDtCad, DBCidadeDicInfo.CidQuemAtu, DBCidadeDicInfo.CidDtAtu, DBCidadeDicInfo.CidVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBCidadeDicInfo.CidDDD, DBCidadeDicInfo.CidTop, DBCidadeDicInfo.CidComarca, DBCidadeDicInfo.CidCapital, DBCidadeDicInfo.CidNome, DBCidadeDicInfo.CidUF, DBCidadeDicInfo.CidSigla];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "cidCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBCidadeDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "cidCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBCidadeDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
