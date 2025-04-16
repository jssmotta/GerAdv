#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBEndTitODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBEndTitDicInfo.TabelaNome;
    public string ICampoCodigo() => DBEndTitDicInfo.CampoCodigo;
    public string IPrefixo() => DBEndTitDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => false;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBEndTitDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => false;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBEndTitDicInfo.Endereco => DBEndTitDicInfo.EttEndereco,
        DBEndTitDicInfo.Titulo => DBEndTitDicInfo.EttTitulo,
        _ => null
    };
    public static string TCampoCodigo => DBEndTitDicInfo.CampoCodigo;
    public static string TCampoNome => DBEndTitDicInfo.CampoNome;
    public static string TTabelaNome => DBEndTitDicInfo.TabelaNome;
    public static string TTablePrefix => DBEndTitDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBEndTitDicInfo.EttEndereco, DBEndTitDicInfo.EttTitulo];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBEndTitDicInfo.EttEndereco, DBEndTitDicInfo.EttTitulo];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "ettCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBEndTitDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "ettCodigo",
            "ettEndereco",
            "ettTitulo"
        };
        var result = campos.Where(campo => !campo.Equals(DBEndTitDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
