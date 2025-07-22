#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBGUTPeriodicidadeStatusODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBGUTPeriodicidadeStatusDicInfo.TabelaNome;
    public string ICampoCodigo() => DBGUTPeriodicidadeStatusDicInfo.CampoCodigo;
    public string IPrefixo() => DBGUTPeriodicidadeStatusDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBGUTPeriodicidadeStatusDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBGUTPeriodicidadeStatusDicInfo.GUTAtividade => DBGUTPeriodicidadeStatusDicInfo.PgsGUTAtividade,
        DBGUTPeriodicidadeStatusDicInfo.DataRealizado => DBGUTPeriodicidadeStatusDicInfo.PgsDataRealizado,
        DBGUTPeriodicidadeStatusDicInfo.GUID => DBGUTPeriodicidadeStatusDicInfo.PgsGUID,
        DBGUTPeriodicidadeStatusDicInfo.QuemCad => DBGUTPeriodicidadeStatusDicInfo.PgsQuemCad,
        DBGUTPeriodicidadeStatusDicInfo.DtCad => DBGUTPeriodicidadeStatusDicInfo.PgsDtCad,
        DBGUTPeriodicidadeStatusDicInfo.QuemAtu => DBGUTPeriodicidadeStatusDicInfo.PgsQuemAtu,
        DBGUTPeriodicidadeStatusDicInfo.DtAtu => DBGUTPeriodicidadeStatusDicInfo.PgsDtAtu,
        DBGUTPeriodicidadeStatusDicInfo.Visto => DBGUTPeriodicidadeStatusDicInfo.PgsVisto,
        _ => null
    };
    public static string TCampoCodigo => DBGUTPeriodicidadeStatusDicInfo.CampoCodigo;
    public static string TCampoNome => DBGUTPeriodicidadeStatusDicInfo.CampoNome;
    public static string TTabelaNome => DBGUTPeriodicidadeStatusDicInfo.TabelaNome;
    public static string TTablePrefix => DBGUTPeriodicidadeStatusDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBGUTPeriodicidadeStatusDicInfo.PgsGUTAtividade, DBGUTPeriodicidadeStatusDicInfo.PgsDataRealizado, DBGUTPeriodicidadeStatusDicInfo.PgsGUID, DBGUTPeriodicidadeStatusDicInfo.PgsQuemCad, DBGUTPeriodicidadeStatusDicInfo.PgsDtCad, DBGUTPeriodicidadeStatusDicInfo.PgsQuemAtu, DBGUTPeriodicidadeStatusDicInfo.PgsDtAtu, DBGUTPeriodicidadeStatusDicInfo.PgsVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBGUTPeriodicidadeStatusDicInfo.PgsGUTAtividade, DBGUTPeriodicidadeStatusDicInfo.PgsDataRealizado, DBGUTPeriodicidadeStatusDicInfo.PgsGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "pgsCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBGUTPeriodicidadeStatusDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "pgsCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBGUTPeriodicidadeStatusDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
