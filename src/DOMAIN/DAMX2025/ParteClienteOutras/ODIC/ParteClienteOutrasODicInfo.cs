#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBParteClienteOutrasODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBParteClienteOutrasDicInfo.TabelaNome;
    public string ICampoCodigo() => DBParteClienteOutrasDicInfo.CampoCodigo;
    public string IPrefixo() => DBParteClienteOutrasDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBParteClienteOutrasDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBParteClienteOutrasDicInfo.Cliente => DBParteClienteOutrasDicInfo.PcoCliente,
        DBParteClienteOutrasDicInfo.Processo => DBParteClienteOutrasDicInfo.PcoProcesso,
        DBParteClienteOutrasDicInfo.PrimeiraReclamada => DBParteClienteOutrasDicInfo.PcoPrimeiraReclamada,
        DBParteClienteOutrasDicInfo.QuemCad => DBParteClienteOutrasDicInfo.PcoQuemCad,
        DBParteClienteOutrasDicInfo.DtCad => DBParteClienteOutrasDicInfo.PcoDtCad,
        DBParteClienteOutrasDicInfo.QuemAtu => DBParteClienteOutrasDicInfo.PcoQuemAtu,
        DBParteClienteOutrasDicInfo.DtAtu => DBParteClienteOutrasDicInfo.PcoDtAtu,
        DBParteClienteOutrasDicInfo.Visto => DBParteClienteOutrasDicInfo.PcoVisto,
        _ => null
    };
    public static string TCampoCodigo => DBParteClienteOutrasDicInfo.CampoCodigo;
    public static string TCampoNome => DBParteClienteOutrasDicInfo.CampoNome;
    public static string TTabelaNome => DBParteClienteOutrasDicInfo.TabelaNome;
    public static string TTablePrefix => DBParteClienteOutrasDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBParteClienteOutrasDicInfo.PcoCliente, DBParteClienteOutrasDicInfo.PcoProcesso, DBParteClienteOutrasDicInfo.PcoPrimeiraReclamada, DBParteClienteOutrasDicInfo.PcoQuemCad, DBParteClienteOutrasDicInfo.PcoDtCad, DBParteClienteOutrasDicInfo.PcoQuemAtu, DBParteClienteOutrasDicInfo.PcoDtAtu, DBParteClienteOutrasDicInfo.PcoVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBParteClienteOutrasDicInfo.PcoCliente, DBParteClienteOutrasDicInfo.PcoProcesso, DBParteClienteOutrasDicInfo.PcoPrimeiraReclamada];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "pcoCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBParteClienteOutrasDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "pcoCliente",
            "pcoCodigo",
            "pcoProcesso"
        };
        var result = campos.Where(campo => !campo.Equals(DBParteClienteOutrasDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
