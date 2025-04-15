#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBEventoPrazoAgendaODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBEventoPrazoAgendaDicInfo.TabelaNome;
    public string ICampoCodigo() => DBEventoPrazoAgendaDicInfo.CampoCodigo;
    public string IPrefixo() => DBEventoPrazoAgendaDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBEventoPrazoAgendaDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBEventoPrazoAgendaDicInfo.Nome => DBEventoPrazoAgendaDicInfo.EpaNome,
        DBEventoPrazoAgendaDicInfo.Bold => DBEventoPrazoAgendaDicInfo.EpaBold,
        DBEventoPrazoAgendaDicInfo.QuemCad => DBEventoPrazoAgendaDicInfo.EpaQuemCad,
        DBEventoPrazoAgendaDicInfo.DtCad => DBEventoPrazoAgendaDicInfo.EpaDtCad,
        DBEventoPrazoAgendaDicInfo.QuemAtu => DBEventoPrazoAgendaDicInfo.EpaQuemAtu,
        DBEventoPrazoAgendaDicInfo.DtAtu => DBEventoPrazoAgendaDicInfo.EpaDtAtu,
        DBEventoPrazoAgendaDicInfo.Visto => DBEventoPrazoAgendaDicInfo.EpaVisto,
        _ => null
    };
    public static string TCampoCodigo => DBEventoPrazoAgendaDicInfo.CampoCodigo;
    public static string TCampoNome => DBEventoPrazoAgendaDicInfo.CampoNome;
    public static string TTabelaNome => DBEventoPrazoAgendaDicInfo.TabelaNome;
    public static string TTablePrefix => DBEventoPrazoAgendaDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBEventoPrazoAgendaDicInfo.EpaNome, DBEventoPrazoAgendaDicInfo.EpaBold, DBEventoPrazoAgendaDicInfo.EpaQuemCad, DBEventoPrazoAgendaDicInfo.EpaDtCad, DBEventoPrazoAgendaDicInfo.EpaQuemAtu, DBEventoPrazoAgendaDicInfo.EpaDtAtu, DBEventoPrazoAgendaDicInfo.EpaVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBEventoPrazoAgendaDicInfo.EpaNome, DBEventoPrazoAgendaDicInfo.EpaBold];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "epaCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBEventoPrazoAgendaDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "epaCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBEventoPrazoAgendaDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
