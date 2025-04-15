#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBParteClienteODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBParteClienteDicInfo.TabelaNome;
    public string ICampoCodigo() => DBParteClienteDicInfo.CampoCodigo;
    public string IPrefixo() => DBParteClienteDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => false;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBParteClienteDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => false;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBParteClienteDicInfo.Cliente => DBParteClienteDicInfo.CliCliente,
        DBParteClienteDicInfo.Processo => DBParteClienteDicInfo.CliProcesso,
        _ => null
    };
    public static string TCampoCodigo => DBParteClienteDicInfo.CampoCodigo;
    public static string TCampoNome => DBParteClienteDicInfo.CampoNome;
    public static string TTabelaNome => DBParteClienteDicInfo.TabelaNome;
    public static string TTablePrefix => DBParteClienteDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBParteClienteDicInfo.CliCliente, DBParteClienteDicInfo.CliProcesso];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBParteClienteDicInfo.CliCliente, DBParteClienteDicInfo.CliProcesso];

    public static List<DBInfoSystem> ListPk() => [];
    public static List<DBInfoSystem> ListPkIndices() => [];
}
#endif
