#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBTipoModeloDocumentoODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBTipoModeloDocumentoDicInfo.TabelaNome;
    public string ICampoCodigo() => DBTipoModeloDocumentoDicInfo.CampoCodigo;
    public string IPrefixo() => DBTipoModeloDocumentoDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBTipoModeloDocumentoDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBTipoModeloDocumentoDicInfo.Nome => DBTipoModeloDocumentoDicInfo.TpdNome,
        DBTipoModeloDocumentoDicInfo.GUID => DBTipoModeloDocumentoDicInfo.TpdGUID,
        DBTipoModeloDocumentoDicInfo.QuemCad => DBTipoModeloDocumentoDicInfo.TpdQuemCad,
        DBTipoModeloDocumentoDicInfo.DtCad => DBTipoModeloDocumentoDicInfo.TpdDtCad,
        DBTipoModeloDocumentoDicInfo.QuemAtu => DBTipoModeloDocumentoDicInfo.TpdQuemAtu,
        DBTipoModeloDocumentoDicInfo.DtAtu => DBTipoModeloDocumentoDicInfo.TpdDtAtu,
        DBTipoModeloDocumentoDicInfo.Visto => DBTipoModeloDocumentoDicInfo.TpdVisto,
        _ => null
    };
    public static string TCampoCodigo => DBTipoModeloDocumentoDicInfo.CampoCodigo;
    public static string TCampoNome => DBTipoModeloDocumentoDicInfo.CampoNome;
    public static string TTabelaNome => DBTipoModeloDocumentoDicInfo.TabelaNome;
    public static string TTablePrefix => DBTipoModeloDocumentoDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBTipoModeloDocumentoDicInfo.TpdNome, DBTipoModeloDocumentoDicInfo.TpdGUID, DBTipoModeloDocumentoDicInfo.TpdQuemCad, DBTipoModeloDocumentoDicInfo.TpdDtCad, DBTipoModeloDocumentoDicInfo.TpdQuemAtu, DBTipoModeloDocumentoDicInfo.TpdDtAtu, DBTipoModeloDocumentoDicInfo.TpdVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBTipoModeloDocumentoDicInfo.TpdNome];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "tpdNome"
        };
        var result = campos.Where(campo => !campo.Equals(DBTipoModeloDocumentoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "tpdCodigo",
            "tpdNome"
        };
        var result = campos.Where(campo => !campo.Equals(DBTipoModeloDocumentoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
