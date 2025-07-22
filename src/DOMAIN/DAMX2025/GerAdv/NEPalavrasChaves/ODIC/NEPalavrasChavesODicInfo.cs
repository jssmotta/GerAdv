#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBNEPalavrasChavesODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBNEPalavrasChavesDicInfo.TabelaNome;
    public string ICampoCodigo() => DBNEPalavrasChavesDicInfo.CampoCodigo;
    public string IPrefixo() => DBNEPalavrasChavesDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBNEPalavrasChavesDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBNEPalavrasChavesDicInfo.Nome => DBNEPalavrasChavesDicInfo.NpcNome,
        DBNEPalavrasChavesDicInfo.Bold => DBNEPalavrasChavesDicInfo.NpcBold,
        DBNEPalavrasChavesDicInfo.QuemCad => DBNEPalavrasChavesDicInfo.NpcQuemCad,
        DBNEPalavrasChavesDicInfo.DtCad => DBNEPalavrasChavesDicInfo.NpcDtCad,
        DBNEPalavrasChavesDicInfo.QuemAtu => DBNEPalavrasChavesDicInfo.NpcQuemAtu,
        DBNEPalavrasChavesDicInfo.DtAtu => DBNEPalavrasChavesDicInfo.NpcDtAtu,
        DBNEPalavrasChavesDicInfo.Visto => DBNEPalavrasChavesDicInfo.NpcVisto,
        _ => null
    };
    public static string TCampoCodigo => DBNEPalavrasChavesDicInfo.CampoCodigo;
    public static string TCampoNome => DBNEPalavrasChavesDicInfo.CampoNome;
    public static string TTabelaNome => DBNEPalavrasChavesDicInfo.TabelaNome;
    public static string TTablePrefix => DBNEPalavrasChavesDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBNEPalavrasChavesDicInfo.NpcNome, DBNEPalavrasChavesDicInfo.NpcBold, DBNEPalavrasChavesDicInfo.NpcQuemCad, DBNEPalavrasChavesDicInfo.NpcDtCad, DBNEPalavrasChavesDicInfo.NpcQuemAtu, DBNEPalavrasChavesDicInfo.NpcDtAtu, DBNEPalavrasChavesDicInfo.NpcVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBNEPalavrasChavesDicInfo.NpcNome];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "npcCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBNEPalavrasChavesDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "npcCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBNEPalavrasChavesDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
