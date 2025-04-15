#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBAndCompODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBAndCompDicInfo.TabelaNome;
    public string ICampoCodigo() => DBAndCompDicInfo.CampoCodigo;
    public string IPrefixo() => DBAndCompDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => false;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBAndCompDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => false;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBAndCompDicInfo.Andamento => DBAndCompDicInfo.AcpAndamento,
        DBAndCompDicInfo.Compromisso => DBAndCompDicInfo.AcpCompromisso,
        _ => null
    };
    public static string TCampoCodigo => DBAndCompDicInfo.CampoCodigo;
    public static string TCampoNome => DBAndCompDicInfo.CampoNome;
    public static string TTabelaNome => DBAndCompDicInfo.TabelaNome;
    public static string TTablePrefix => DBAndCompDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBAndCompDicInfo.AcpAndamento, DBAndCompDicInfo.AcpCompromisso];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBAndCompDicInfo.AcpAndamento, DBAndCompDicInfo.AcpCompromisso];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "acpCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBAndCompDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "acpCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBAndCompDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
