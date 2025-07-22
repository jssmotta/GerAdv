#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBGUTMatrizODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBGUTMatrizDicInfo.TabelaNome;
    public string ICampoCodigo() => DBGUTMatrizDicInfo.CampoCodigo;
    public string IPrefixo() => DBGUTMatrizDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => false;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBGUTMatrizDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => false;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBGUTMatrizDicInfo.Descricao => DBGUTMatrizDicInfo.GutDescricao,
        DBGUTMatrizDicInfo.GUTTipo => DBGUTMatrizDicInfo.GutGUTTipo,
        DBGUTMatrizDicInfo.Valor => DBGUTMatrizDicInfo.GutValor,
        _ => null
    };
    public static string TCampoCodigo => DBGUTMatrizDicInfo.CampoCodigo;
    public static string TCampoNome => DBGUTMatrizDicInfo.CampoNome;
    public static string TTabelaNome => DBGUTMatrizDicInfo.TabelaNome;
    public static string TTablePrefix => DBGUTMatrizDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBGUTMatrizDicInfo.GutDescricao, DBGUTMatrizDicInfo.GutGUTTipo, DBGUTMatrizDicInfo.GutValor];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBGUTMatrizDicInfo.GutDescricao, DBGUTMatrizDicInfo.GutGUTTipo, DBGUTMatrizDicInfo.GutValor];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "gutCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBGUTMatrizDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "gutCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBGUTMatrizDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
