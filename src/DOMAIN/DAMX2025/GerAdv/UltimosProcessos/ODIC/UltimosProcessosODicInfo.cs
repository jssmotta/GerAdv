#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBUltimosProcessosODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBUltimosProcessosDicInfo.TabelaNome;
    public string ICampoCodigo() => DBUltimosProcessosDicInfo.CampoCodigo;
    public string IPrefixo() => DBUltimosProcessosDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => false;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBUltimosProcessosDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => false;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBUltimosProcessosDicInfo.Processo => DBUltimosProcessosDicInfo.UltProcesso,
        DBUltimosProcessosDicInfo.Quando => DBUltimosProcessosDicInfo.UltQuando,
        DBUltimosProcessosDicInfo.Quem => DBUltimosProcessosDicInfo.UltQuem,
        _ => null
    };
    public static string TCampoCodigo => DBUltimosProcessosDicInfo.CampoCodigo;
    public static string TCampoNome => DBUltimosProcessosDicInfo.CampoNome;
    public static string TTabelaNome => DBUltimosProcessosDicInfo.TabelaNome;
    public static string TTablePrefix => DBUltimosProcessosDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBUltimosProcessosDicInfo.UltProcesso, DBUltimosProcessosDicInfo.UltQuando, DBUltimosProcessosDicInfo.UltQuem];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBUltimosProcessosDicInfo.UltProcesso, DBUltimosProcessosDicInfo.UltQuando, DBUltimosProcessosDicInfo.UltQuem];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "ultCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBUltimosProcessosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "ultCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBUltimosProcessosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
