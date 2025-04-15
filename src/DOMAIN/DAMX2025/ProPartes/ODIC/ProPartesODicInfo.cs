#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBProPartesODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBProPartesDicInfo.TabelaNome;
    public string ICampoCodigo() => DBProPartesDicInfo.CampoCodigo;
    public string IPrefixo() => DBProPartesDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => false;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBProPartesDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => false;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBProPartesDicInfo.Parte => DBProPartesDicInfo.OppParte,
        DBProPartesDicInfo.Processo => DBProPartesDicInfo.OppProcesso,
        _ => null
    };
    public static string TCampoCodigo => DBProPartesDicInfo.CampoCodigo;
    public static string TCampoNome => DBProPartesDicInfo.CampoNome;
    public static string TTabelaNome => DBProPartesDicInfo.TabelaNome;
    public static string TTablePrefix => DBProPartesDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBProPartesDicInfo.OppParte, DBProPartesDicInfo.OppProcesso];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBProPartesDicInfo.OppParte, DBProPartesDicInfo.OppProcesso];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "oppCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBProPartesDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "oppCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBProPartesDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
