#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBViaRecebimentoODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBViaRecebimentoDicInfo.TabelaNome;
    public string ICampoCodigo() => DBViaRecebimentoDicInfo.CampoCodigo;
    public string IPrefixo() => DBViaRecebimentoDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => false;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBViaRecebimentoDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => false;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBViaRecebimentoDicInfo.Nome => DBViaRecebimentoDicInfo.VrbNome,
        _ => null
    };
    public static string TCampoCodigo => DBViaRecebimentoDicInfo.CampoCodigo;
    public static string TCampoNome => DBViaRecebimentoDicInfo.CampoNome;
    public static string TTabelaNome => DBViaRecebimentoDicInfo.TabelaNome;
    public static string TTablePrefix => DBViaRecebimentoDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBViaRecebimentoDicInfo.VrbNome];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBViaRecebimentoDicInfo.VrbNome];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "vrbCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBViaRecebimentoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "vrbCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBViaRecebimentoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
