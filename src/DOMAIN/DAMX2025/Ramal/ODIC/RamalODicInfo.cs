#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBRamalODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBRamalDicInfo.TabelaNome;
    public string ICampoCodigo() => DBRamalDicInfo.CampoCodigo;
    public string IPrefixo() => DBRamalDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBRamalDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBRamalDicInfo.Nome => DBRamalDicInfo.RamNome,
        DBRamalDicInfo.Obs => DBRamalDicInfo.RamObs,
        DBRamalDicInfo.QuemCad => DBRamalDicInfo.RamQuemCad,
        DBRamalDicInfo.DtCad => DBRamalDicInfo.RamDtCad,
        DBRamalDicInfo.QuemAtu => DBRamalDicInfo.RamQuemAtu,
        DBRamalDicInfo.DtAtu => DBRamalDicInfo.RamDtAtu,
        DBRamalDicInfo.Visto => DBRamalDicInfo.RamVisto,
        _ => null
    };
    public static string TCampoCodigo => DBRamalDicInfo.CampoCodigo;
    public static string TCampoNome => DBRamalDicInfo.CampoNome;
    public static string TTabelaNome => DBRamalDicInfo.TabelaNome;
    public static string TTablePrefix => DBRamalDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBRamalDicInfo.RamNome, DBRamalDicInfo.RamObs, DBRamalDicInfo.RamQuemCad, DBRamalDicInfo.RamDtCad, DBRamalDicInfo.RamQuemAtu, DBRamalDicInfo.RamDtAtu, DBRamalDicInfo.RamVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBRamalDicInfo.RamNome, DBRamalDicInfo.RamObs];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "ramCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBRamalDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "ramCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBRamalDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
