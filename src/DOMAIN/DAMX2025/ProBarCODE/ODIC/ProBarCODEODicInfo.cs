#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBProBarCODEODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBProBarCODEDicInfo.TabelaNome;
    public string ICampoCodigo() => DBProBarCODEDicInfo.CampoCodigo;
    public string IPrefixo() => DBProBarCODEDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBProBarCODEDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBProBarCODEDicInfo.BarCODE => DBProBarCODEDicInfo.PbcBarCODE,
        DBProBarCODEDicInfo.Processo => DBProBarCODEDicInfo.PbcProcesso,
        DBProBarCODEDicInfo.QuemCad => DBProBarCODEDicInfo.PbcQuemCad,
        DBProBarCODEDicInfo.DtCad => DBProBarCODEDicInfo.PbcDtCad,
        DBProBarCODEDicInfo.QuemAtu => DBProBarCODEDicInfo.PbcQuemAtu,
        DBProBarCODEDicInfo.DtAtu => DBProBarCODEDicInfo.PbcDtAtu,
        DBProBarCODEDicInfo.Visto => DBProBarCODEDicInfo.PbcVisto,
        _ => null
    };
    public static string TCampoCodigo => DBProBarCODEDicInfo.CampoCodigo;
    public static string TCampoNome => DBProBarCODEDicInfo.CampoNome;
    public static string TTabelaNome => DBProBarCODEDicInfo.TabelaNome;
    public static string TTablePrefix => DBProBarCODEDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBProBarCODEDicInfo.PbcBarCODE, DBProBarCODEDicInfo.PbcProcesso, DBProBarCODEDicInfo.PbcQuemCad, DBProBarCODEDicInfo.PbcDtCad, DBProBarCODEDicInfo.PbcQuemAtu, DBProBarCODEDicInfo.PbcDtAtu, DBProBarCODEDicInfo.PbcVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBProBarCODEDicInfo.PbcBarCODE, DBProBarCODEDicInfo.PbcProcesso];

    public static List<DBInfoSystem> ListPk() => [];
    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "pbcBarCODE",
            "pbcProcesso"
        };
        var result = campos.Where(campo => !campo.Equals(DBProBarCODEDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
