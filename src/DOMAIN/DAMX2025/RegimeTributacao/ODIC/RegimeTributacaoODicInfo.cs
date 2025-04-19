#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBRegimeTributacaoODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBRegimeTributacaoDicInfo.TabelaNome;
    public string ICampoCodigo() => DBRegimeTributacaoDicInfo.CampoCodigo;
    public string IPrefixo() => DBRegimeTributacaoDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBRegimeTributacaoDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBRegimeTributacaoDicInfo.Nome => DBRegimeTributacaoDicInfo.RdtNome,
        DBRegimeTributacaoDicInfo.GUID => DBRegimeTributacaoDicInfo.RdtGUID,
        DBRegimeTributacaoDicInfo.QuemCad => DBRegimeTributacaoDicInfo.RdtQuemCad,
        DBRegimeTributacaoDicInfo.DtCad => DBRegimeTributacaoDicInfo.RdtDtCad,
        DBRegimeTributacaoDicInfo.QuemAtu => DBRegimeTributacaoDicInfo.RdtQuemAtu,
        DBRegimeTributacaoDicInfo.DtAtu => DBRegimeTributacaoDicInfo.RdtDtAtu,
        DBRegimeTributacaoDicInfo.Visto => DBRegimeTributacaoDicInfo.RdtVisto,
        _ => null
    };
    public static string TCampoCodigo => DBRegimeTributacaoDicInfo.CampoCodigo;
    public static string TCampoNome => DBRegimeTributacaoDicInfo.CampoNome;
    public static string TTabelaNome => DBRegimeTributacaoDicInfo.TabelaNome;
    public static string TTablePrefix => DBRegimeTributacaoDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBRegimeTributacaoDicInfo.RdtNome, DBRegimeTributacaoDicInfo.RdtGUID, DBRegimeTributacaoDicInfo.RdtQuemCad, DBRegimeTributacaoDicInfo.RdtDtCad, DBRegimeTributacaoDicInfo.RdtQuemAtu, DBRegimeTributacaoDicInfo.RdtDtAtu, DBRegimeTributacaoDicInfo.RdtVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBRegimeTributacaoDicInfo.RdtNome, DBRegimeTributacaoDicInfo.RdtGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "rdtCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBRegimeTributacaoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "rdtCodigo",
            "rdtNome"
        };
        var result = campos.Where(campo => !campo.Equals(DBRegimeTributacaoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
