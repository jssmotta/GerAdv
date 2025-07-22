#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBTipoOrigemSucumbenciaODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBTipoOrigemSucumbenciaDicInfo.TabelaNome;
    public string ICampoCodigo() => DBTipoOrigemSucumbenciaDicInfo.CampoCodigo;
    public string IPrefixo() => DBTipoOrigemSucumbenciaDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => false;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBTipoOrigemSucumbenciaDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => false;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBTipoOrigemSucumbenciaDicInfo.Nome => DBTipoOrigemSucumbenciaDicInfo.TosNome,
        _ => null
    };
    public static string TCampoCodigo => DBTipoOrigemSucumbenciaDicInfo.CampoCodigo;
    public static string TCampoNome => DBTipoOrigemSucumbenciaDicInfo.CampoNome;
    public static string TTabelaNome => DBTipoOrigemSucumbenciaDicInfo.TabelaNome;
    public static string TTablePrefix => DBTipoOrigemSucumbenciaDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBTipoOrigemSucumbenciaDicInfo.TosNome];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBTipoOrigemSucumbenciaDicInfo.TosNome];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "tosNome"
        };
        var result = campos.Where(campo => !campo.Equals(DBTipoOrigemSucumbenciaDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "tosCodigo",
            "tosNome"
        };
        var result = campos.Where(campo => !campo.Equals(DBTipoOrigemSucumbenciaDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
