#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBLivroCaixaClientesODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBLivroCaixaClientesDicInfo.TabelaNome;
    public string ICampoCodigo() => DBLivroCaixaClientesDicInfo.CampoCodigo;
    public string IPrefixo() => DBLivroCaixaClientesDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBLivroCaixaClientesDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBLivroCaixaClientesDicInfo.LivroCaixa => DBLivroCaixaClientesDicInfo.LccLivroCaixa,
        DBLivroCaixaClientesDicInfo.Cliente => DBLivroCaixaClientesDicInfo.LccCliente,
        DBLivroCaixaClientesDicInfo.Lancado => DBLivroCaixaClientesDicInfo.LccLancado,
        DBLivroCaixaClientesDicInfo.QuemCad => DBLivroCaixaClientesDicInfo.LccQuemCad,
        DBLivroCaixaClientesDicInfo.DtCad => DBLivroCaixaClientesDicInfo.LccDtCad,
        DBLivroCaixaClientesDicInfo.QuemAtu => DBLivroCaixaClientesDicInfo.LccQuemAtu,
        DBLivroCaixaClientesDicInfo.DtAtu => DBLivroCaixaClientesDicInfo.LccDtAtu,
        DBLivroCaixaClientesDicInfo.Visto => DBLivroCaixaClientesDicInfo.LccVisto,
        _ => null
    };
    public static string TCampoCodigo => DBLivroCaixaClientesDicInfo.CampoCodigo;
    public static string TCampoNome => DBLivroCaixaClientesDicInfo.CampoNome;
    public static string TTabelaNome => DBLivroCaixaClientesDicInfo.TabelaNome;
    public static string TTablePrefix => DBLivroCaixaClientesDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBLivroCaixaClientesDicInfo.LccLivroCaixa, DBLivroCaixaClientesDicInfo.LccCliente, DBLivroCaixaClientesDicInfo.LccLancado, DBLivroCaixaClientesDicInfo.LccQuemCad, DBLivroCaixaClientesDicInfo.LccDtCad, DBLivroCaixaClientesDicInfo.LccQuemAtu, DBLivroCaixaClientesDicInfo.LccDtAtu, DBLivroCaixaClientesDicInfo.LccVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBLivroCaixaClientesDicInfo.LccLivroCaixa, DBLivroCaixaClientesDicInfo.LccCliente, DBLivroCaixaClientesDicInfo.LccLancado];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "lccCliente",
            "lccLivroCaixa"
        };
        var result = campos.Where(campo => !campo.Equals(DBLivroCaixaClientesDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "lccCliente",
            "lccCodigo",
            "lccLivroCaixa"
        };
        var result = campos.Where(campo => !campo.Equals(DBLivroCaixaClientesDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
