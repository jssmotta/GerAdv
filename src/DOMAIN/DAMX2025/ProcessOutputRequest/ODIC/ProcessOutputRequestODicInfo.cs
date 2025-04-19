#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBProcessOutputRequestODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBProcessOutputRequestDicInfo.TabelaNome;
    public string ICampoCodigo() => DBProcessOutputRequestDicInfo.CampoCodigo;
    public string IPrefixo() => DBProcessOutputRequestDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBProcessOutputRequestDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBProcessOutputRequestDicInfo.ProcessOutputEngine => DBProcessOutputRequestDicInfo.PorProcessOutputEngine,
        DBProcessOutputRequestDicInfo.Operador => DBProcessOutputRequestDicInfo.PorOperador,
        DBProcessOutputRequestDicInfo.Processo => DBProcessOutputRequestDicInfo.PorProcesso,
        DBProcessOutputRequestDicInfo.UltimoIdTabelaExo => DBProcessOutputRequestDicInfo.PorUltimoIdTabelaExo,
        DBProcessOutputRequestDicInfo.GUID => DBProcessOutputRequestDicInfo.PorGUID,
        DBProcessOutputRequestDicInfo.QuemCad => DBProcessOutputRequestDicInfo.PorQuemCad,
        DBProcessOutputRequestDicInfo.DtCad => DBProcessOutputRequestDicInfo.PorDtCad,
        DBProcessOutputRequestDicInfo.QuemAtu => DBProcessOutputRequestDicInfo.PorQuemAtu,
        DBProcessOutputRequestDicInfo.DtAtu => DBProcessOutputRequestDicInfo.PorDtAtu,
        DBProcessOutputRequestDicInfo.Visto => DBProcessOutputRequestDicInfo.PorVisto,
        _ => null
    };
    public static string TCampoCodigo => DBProcessOutputRequestDicInfo.CampoCodigo;
    public static string TCampoNome => DBProcessOutputRequestDicInfo.CampoNome;
    public static string TTabelaNome => DBProcessOutputRequestDicInfo.TabelaNome;
    public static string TTablePrefix => DBProcessOutputRequestDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBProcessOutputRequestDicInfo.PorProcessOutputEngine, DBProcessOutputRequestDicInfo.PorOperador, DBProcessOutputRequestDicInfo.PorProcesso, DBProcessOutputRequestDicInfo.PorUltimoIdTabelaExo, DBProcessOutputRequestDicInfo.PorGUID, DBProcessOutputRequestDicInfo.PorQuemCad, DBProcessOutputRequestDicInfo.PorDtCad, DBProcessOutputRequestDicInfo.PorQuemAtu, DBProcessOutputRequestDicInfo.PorDtAtu, DBProcessOutputRequestDicInfo.PorVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBProcessOutputRequestDicInfo.PorProcessOutputEngine, DBProcessOutputRequestDicInfo.PorOperador, DBProcessOutputRequestDicInfo.PorProcesso, DBProcessOutputRequestDicInfo.PorUltimoIdTabelaExo, DBProcessOutputRequestDicInfo.PorGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "porOperador",
            "porProcesso",
            "porProcessOutputEngine"
        };
        var result = campos.Where(campo => !campo.Equals(DBProcessOutputRequestDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "porCodigo",
            "porOperador",
            "porProcesso",
            "porProcessOutputEngine"
        };
        var result = campos.Where(campo => !campo.Equals(DBProcessOutputRequestDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
