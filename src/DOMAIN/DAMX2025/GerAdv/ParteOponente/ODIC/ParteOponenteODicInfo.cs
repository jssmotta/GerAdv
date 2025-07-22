#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBParteOponenteODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBParteOponenteDicInfo.TabelaNome;
    public string ICampoCodigo() => DBParteOponenteDicInfo.CampoCodigo;
    public string IPrefixo() => DBParteOponenteDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => false;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBParteOponenteDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => false;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBParteOponenteDicInfo.Oponente => DBParteOponenteDicInfo.OpoOponente,
        DBParteOponenteDicInfo.Processo => DBParteOponenteDicInfo.OpoProcesso,
        _ => null
    };
    public static string TCampoCodigo => DBParteOponenteDicInfo.CampoCodigo;
    public static string TCampoNome => DBParteOponenteDicInfo.CampoNome;
    public static string TTabelaNome => DBParteOponenteDicInfo.TabelaNome;
    public static string TTablePrefix => DBParteOponenteDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBParteOponenteDicInfo.OpoOponente, DBParteOponenteDicInfo.OpoProcesso];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBParteOponenteDicInfo.OpoOponente, DBParteOponenteDicInfo.OpoProcesso];

    public static List<DBInfoSystem> ListPk() => [];
    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "opoOponente",
            "opoProcesso"
        };
        var result = campos.Where(campo => !campo.Equals(DBParteOponenteDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
