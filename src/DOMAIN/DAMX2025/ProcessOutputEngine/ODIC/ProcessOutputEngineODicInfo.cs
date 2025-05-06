#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBProcessOutputEngineODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBProcessOutputEngineDicInfo.TabelaNome;
    public string ICampoCodigo() => DBProcessOutputEngineDicInfo.CampoCodigo;
    public string IPrefixo() => DBProcessOutputEngineDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => false;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBProcessOutputEngineDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => false;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBProcessOutputEngineDicInfo.Nome => DBProcessOutputEngineDicInfo.PoeNome,
        DBProcessOutputEngineDicInfo.Database => DBProcessOutputEngineDicInfo.PoeDatabase,
        DBProcessOutputEngineDicInfo.Tabela => DBProcessOutputEngineDicInfo.PoeTabela,
        DBProcessOutputEngineDicInfo.Campo => DBProcessOutputEngineDicInfo.PoeCampo,
        DBProcessOutputEngineDicInfo.Valor => DBProcessOutputEngineDicInfo.PoeValor,
        DBProcessOutputEngineDicInfo.Output => DBProcessOutputEngineDicInfo.PoeOutput,
        DBProcessOutputEngineDicInfo.Administrador => DBProcessOutputEngineDicInfo.PoeAdministrador,
        DBProcessOutputEngineDicInfo.OutputSource => DBProcessOutputEngineDicInfo.PoeOutputSource,
        DBProcessOutputEngineDicInfo.DisabledItem => DBProcessOutputEngineDicInfo.PoeDisabledItem,
        DBProcessOutputEngineDicInfo.IDModulo => DBProcessOutputEngineDicInfo.PoeIDModulo,
        DBProcessOutputEngineDicInfo.IsOnlyProcesso => DBProcessOutputEngineDicInfo.PoeIsOnlyProcesso,
        DBProcessOutputEngineDicInfo.MyID => DBProcessOutputEngineDicInfo.PoeMyID,
        DBProcessOutputEngineDicInfo.GUID => DBProcessOutputEngineDicInfo.PoeGUID,
        _ => null
    };
    public static string TCampoCodigo => DBProcessOutputEngineDicInfo.CampoCodigo;
    public static string TCampoNome => DBProcessOutputEngineDicInfo.CampoNome;
    public static string TTabelaNome => DBProcessOutputEngineDicInfo.TabelaNome;
    public static string TTablePrefix => DBProcessOutputEngineDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBProcessOutputEngineDicInfo.PoeNome, DBProcessOutputEngineDicInfo.PoeDatabase, DBProcessOutputEngineDicInfo.PoeTabela, DBProcessOutputEngineDicInfo.PoeCampo, DBProcessOutputEngineDicInfo.PoeValor, DBProcessOutputEngineDicInfo.PoeOutput, DBProcessOutputEngineDicInfo.PoeAdministrador, DBProcessOutputEngineDicInfo.PoeOutputSource, DBProcessOutputEngineDicInfo.PoeDisabledItem, DBProcessOutputEngineDicInfo.PoeIDModulo, DBProcessOutputEngineDicInfo.PoeIsOnlyProcesso, DBProcessOutputEngineDicInfo.PoeMyID, DBProcessOutputEngineDicInfo.PoeGUID];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBProcessOutputEngineDicInfo.PoeNome, DBProcessOutputEngineDicInfo.PoeDatabase, DBProcessOutputEngineDicInfo.PoeTabela, DBProcessOutputEngineDicInfo.PoeCampo, DBProcessOutputEngineDicInfo.PoeValor, DBProcessOutputEngineDicInfo.PoeOutput, DBProcessOutputEngineDicInfo.PoeAdministrador, DBProcessOutputEngineDicInfo.PoeOutputSource, DBProcessOutputEngineDicInfo.PoeDisabledItem, DBProcessOutputEngineDicInfo.PoeIDModulo, DBProcessOutputEngineDicInfo.PoeIsOnlyProcesso, DBProcessOutputEngineDicInfo.PoeMyID, DBProcessOutputEngineDicInfo.PoeGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "poeCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBProcessOutputEngineDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "poeCampo",
            "poeCodigo",
            "poeDatabase",
            "poeTabela",
            "poeValor"
        };
        var result = campos.Where(campo => !campo.Equals(DBProcessOutputEngineDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
