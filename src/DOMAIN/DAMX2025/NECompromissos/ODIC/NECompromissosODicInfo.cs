#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBNECompromissosODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBNECompromissosDicInfo.TabelaNome;
    public string ICampoCodigo() => DBNECompromissosDicInfo.CampoCodigo;
    public string IPrefixo() => DBNECompromissosDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBNECompromissosDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBNECompromissosDicInfo.PalavraChave => DBNECompromissosDicInfo.NcpPalavraChave,
        DBNECompromissosDicInfo.Provisionar => DBNECompromissosDicInfo.NcpProvisionar,
        DBNECompromissosDicInfo.TipoCompromisso => DBNECompromissosDicInfo.NcpTipoCompromisso,
        DBNECompromissosDicInfo.TextoCompromisso => DBNECompromissosDicInfo.NcpTextoCompromisso,
        DBNECompromissosDicInfo.Bold => DBNECompromissosDicInfo.NcpBold,
        DBNECompromissosDicInfo.QuemCad => DBNECompromissosDicInfo.NcpQuemCad,
        DBNECompromissosDicInfo.DtCad => DBNECompromissosDicInfo.NcpDtCad,
        DBNECompromissosDicInfo.QuemAtu => DBNECompromissosDicInfo.NcpQuemAtu,
        DBNECompromissosDicInfo.DtAtu => DBNECompromissosDicInfo.NcpDtAtu,
        DBNECompromissosDicInfo.Visto => DBNECompromissosDicInfo.NcpVisto,
        _ => null
    };
    public static string TCampoCodigo => DBNECompromissosDicInfo.CampoCodigo;
    public static string TCampoNome => DBNECompromissosDicInfo.CampoNome;
    public static string TTabelaNome => DBNECompromissosDicInfo.TabelaNome;
    public static string TTablePrefix => DBNECompromissosDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBNECompromissosDicInfo.NcpPalavraChave, DBNECompromissosDicInfo.NcpProvisionar, DBNECompromissosDicInfo.NcpTipoCompromisso, DBNECompromissosDicInfo.NcpTextoCompromisso, DBNECompromissosDicInfo.NcpBold, DBNECompromissosDicInfo.NcpQuemCad, DBNECompromissosDicInfo.NcpDtCad, DBNECompromissosDicInfo.NcpQuemAtu, DBNECompromissosDicInfo.NcpDtAtu, DBNECompromissosDicInfo.NcpVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBNECompromissosDicInfo.NcpPalavraChave, DBNECompromissosDicInfo.NcpProvisionar, DBNECompromissosDicInfo.NcpTipoCompromisso, DBNECompromissosDicInfo.NcpTextoCompromisso, DBNECompromissosDicInfo.NcpBold];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "ncpCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBNECompromissosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "ncpCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBNECompromissosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
