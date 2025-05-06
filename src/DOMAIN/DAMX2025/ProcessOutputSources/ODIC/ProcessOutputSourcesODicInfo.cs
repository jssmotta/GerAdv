#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBProcessOutputSourcesODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBProcessOutputSourcesDicInfo.TabelaNome;
    public string ICampoCodigo() => DBProcessOutputSourcesDicInfo.CampoCodigo;
    public string IPrefixo() => DBProcessOutputSourcesDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => false;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBProcessOutputSourcesDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => false;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBProcessOutputSourcesDicInfo.Nome => DBProcessOutputSourcesDicInfo.PosNome,
        DBProcessOutputSourcesDicInfo.GUID => DBProcessOutputSourcesDicInfo.PosGUID,
        _ => null
    };
    public static string TCampoCodigo => DBProcessOutputSourcesDicInfo.CampoCodigo;
    public static string TCampoNome => DBProcessOutputSourcesDicInfo.CampoNome;
    public static string TTabelaNome => DBProcessOutputSourcesDicInfo.TabelaNome;
    public static string TTablePrefix => DBProcessOutputSourcesDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBProcessOutputSourcesDicInfo.PosNome, DBProcessOutputSourcesDicInfo.PosGUID];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBProcessOutputSourcesDicInfo.PosNome, DBProcessOutputSourcesDicInfo.PosGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "posCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBProcessOutputSourcesDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "posCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBProcessOutputSourcesDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
