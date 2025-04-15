#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBTribunalODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBTribunalDicInfo.TabelaNome;
    public string ICampoCodigo() => DBTribunalDicInfo.CampoCodigo;
    public string IPrefixo() => DBTribunalDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBTribunalDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBTribunalDicInfo.Nome => DBTribunalDicInfo.TriNome,
        DBTribunalDicInfo.Area => DBTribunalDicInfo.TriArea,
        DBTribunalDicInfo.Justica => DBTribunalDicInfo.TriJustica,
        DBTribunalDicInfo.Descricao => DBTribunalDicInfo.TriDescricao,
        DBTribunalDicInfo.Instancia => DBTribunalDicInfo.TriInstancia,
        DBTribunalDicInfo.Sigla => DBTribunalDicInfo.TriSigla,
        DBTribunalDicInfo.Web => DBTribunalDicInfo.TriWeb,
        DBTribunalDicInfo.Etiqueta => DBTribunalDicInfo.TriEtiqueta,
        DBTribunalDicInfo.Bold => DBTribunalDicInfo.TriBold,
        DBTribunalDicInfo.GUID => DBTribunalDicInfo.TriGUID,
        DBTribunalDicInfo.QuemCad => DBTribunalDicInfo.TriQuemCad,
        DBTribunalDicInfo.DtCad => DBTribunalDicInfo.TriDtCad,
        DBTribunalDicInfo.QuemAtu => DBTribunalDicInfo.TriQuemAtu,
        DBTribunalDicInfo.DtAtu => DBTribunalDicInfo.TriDtAtu,
        DBTribunalDicInfo.Visto => DBTribunalDicInfo.TriVisto,
        _ => null
    };
    public static string TCampoCodigo => DBTribunalDicInfo.CampoCodigo;
    public static string TCampoNome => DBTribunalDicInfo.CampoNome;
    public static string TTabelaNome => DBTribunalDicInfo.TabelaNome;
    public static string TTablePrefix => DBTribunalDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBTribunalDicInfo.TriNome, DBTribunalDicInfo.TriArea, DBTribunalDicInfo.TriJustica, DBTribunalDicInfo.TriDescricao, DBTribunalDicInfo.TriInstancia, DBTribunalDicInfo.TriSigla, DBTribunalDicInfo.TriWeb, DBTribunalDicInfo.TriEtiqueta, DBTribunalDicInfo.TriBold, DBTribunalDicInfo.TriGUID, DBTribunalDicInfo.TriQuemCad, DBTribunalDicInfo.TriDtCad, DBTribunalDicInfo.TriQuemAtu, DBTribunalDicInfo.TriDtAtu, DBTribunalDicInfo.TriVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBTribunalDicInfo.TriNome, DBTribunalDicInfo.TriArea, DBTribunalDicInfo.TriJustica, DBTribunalDicInfo.TriDescricao, DBTribunalDicInfo.TriInstancia, DBTribunalDicInfo.TriSigla, DBTribunalDicInfo.TriWeb, DBTribunalDicInfo.TriEtiqueta, DBTribunalDicInfo.TriBold];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "triCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBTribunalDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "triCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBTribunalDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
