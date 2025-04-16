#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBStatusBiuODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBStatusBiuDicInfo.TabelaNome;
    public string ICampoCodigo() => DBStatusBiuDicInfo.CampoCodigo;
    public string IPrefixo() => DBStatusBiuDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => false;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBStatusBiuDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => false;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBStatusBiuDicInfo.Nome => DBStatusBiuDicInfo.StbNome,
        DBStatusBiuDicInfo.TipoStatusBiu => DBStatusBiuDicInfo.StbTipoStatusBiu,
        DBStatusBiuDicInfo.Operador => DBStatusBiuDicInfo.StbOperador,
        DBStatusBiuDicInfo.Icone => DBStatusBiuDicInfo.StbIcone,
        _ => null
    };
    public static string TCampoCodigo => DBStatusBiuDicInfo.CampoCodigo;
    public static string TCampoNome => DBStatusBiuDicInfo.CampoNome;
    public static string TTabelaNome => DBStatusBiuDicInfo.TabelaNome;
    public static string TTablePrefix => DBStatusBiuDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBStatusBiuDicInfo.StbNome, DBStatusBiuDicInfo.StbTipoStatusBiu, DBStatusBiuDicInfo.StbOperador, DBStatusBiuDicInfo.StbIcone];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBStatusBiuDicInfo.StbNome, DBStatusBiuDicInfo.StbTipoStatusBiu, DBStatusBiuDicInfo.StbOperador, DBStatusBiuDicInfo.StbIcone];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "stbCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBStatusBiuDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "stbCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBStatusBiuDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
