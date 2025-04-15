#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBGUTPeriodicidadeODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBGUTPeriodicidadeDicInfo.TabelaNome;
    public string ICampoCodigo() => DBGUTPeriodicidadeDicInfo.CampoCodigo;
    public string IPrefixo() => DBGUTPeriodicidadeDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBGUTPeriodicidadeDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBGUTPeriodicidadeDicInfo.Nome => DBGUTPeriodicidadeDicInfo.PcgNome,
        DBGUTPeriodicidadeDicInfo.IntervaloDias => DBGUTPeriodicidadeDicInfo.PcgIntervaloDias,
        DBGUTPeriodicidadeDicInfo.GUID => DBGUTPeriodicidadeDicInfo.PcgGUID,
        DBGUTPeriodicidadeDicInfo.QuemCad => DBGUTPeriodicidadeDicInfo.PcgQuemCad,
        DBGUTPeriodicidadeDicInfo.DtCad => DBGUTPeriodicidadeDicInfo.PcgDtCad,
        DBGUTPeriodicidadeDicInfo.QuemAtu => DBGUTPeriodicidadeDicInfo.PcgQuemAtu,
        DBGUTPeriodicidadeDicInfo.DtAtu => DBGUTPeriodicidadeDicInfo.PcgDtAtu,
        DBGUTPeriodicidadeDicInfo.Visto => DBGUTPeriodicidadeDicInfo.PcgVisto,
        _ => null
    };
    public static string TCampoCodigo => DBGUTPeriodicidadeDicInfo.CampoCodigo;
    public static string TCampoNome => DBGUTPeriodicidadeDicInfo.CampoNome;
    public static string TTabelaNome => DBGUTPeriodicidadeDicInfo.TabelaNome;
    public static string TTablePrefix => DBGUTPeriodicidadeDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBGUTPeriodicidadeDicInfo.PcgNome, DBGUTPeriodicidadeDicInfo.PcgIntervaloDias, DBGUTPeriodicidadeDicInfo.PcgGUID, DBGUTPeriodicidadeDicInfo.PcgQuemCad, DBGUTPeriodicidadeDicInfo.PcgDtCad, DBGUTPeriodicidadeDicInfo.PcgQuemAtu, DBGUTPeriodicidadeDicInfo.PcgDtAtu, DBGUTPeriodicidadeDicInfo.PcgVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBGUTPeriodicidadeDicInfo.PcgNome, DBGUTPeriodicidadeDicInfo.PcgIntervaloDias];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "pcgCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBGUTPeriodicidadeDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "pcgCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBGUTPeriodicidadeDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
