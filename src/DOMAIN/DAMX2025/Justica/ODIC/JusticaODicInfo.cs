#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBJusticaODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBJusticaDicInfo.TabelaNome;
    public string ICampoCodigo() => DBJusticaDicInfo.CampoCodigo;
    public string IPrefixo() => DBJusticaDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBJusticaDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBJusticaDicInfo.Nome => DBJusticaDicInfo.JusNome,
        DBJusticaDicInfo.Bold => DBJusticaDicInfo.JusBold,
        DBJusticaDicInfo.GUID => DBJusticaDicInfo.JusGUID,
        DBJusticaDicInfo.QuemCad => DBJusticaDicInfo.JusQuemCad,
        DBJusticaDicInfo.DtCad => DBJusticaDicInfo.JusDtCad,
        DBJusticaDicInfo.QuemAtu => DBJusticaDicInfo.JusQuemAtu,
        DBJusticaDicInfo.DtAtu => DBJusticaDicInfo.JusDtAtu,
        DBJusticaDicInfo.Visto => DBJusticaDicInfo.JusVisto,
        _ => null
    };
    public static string TCampoCodigo => DBJusticaDicInfo.CampoCodigo;
    public static string TCampoNome => DBJusticaDicInfo.CampoNome;
    public static string TTabelaNome => DBJusticaDicInfo.TabelaNome;
    public static string TTablePrefix => DBJusticaDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBJusticaDicInfo.JusNome, DBJusticaDicInfo.JusBold, DBJusticaDicInfo.JusGUID, DBJusticaDicInfo.JusQuemCad, DBJusticaDicInfo.JusDtCad, DBJusticaDicInfo.JusQuemAtu, DBJusticaDicInfo.JusDtAtu, DBJusticaDicInfo.JusVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBJusticaDicInfo.JusNome, DBJusticaDicInfo.JusBold];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "jusCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBJusticaDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "jusCodigo",
            "jusNome"
        };
        var result = campos.Where(campo => !campo.Equals(DBJusticaDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
