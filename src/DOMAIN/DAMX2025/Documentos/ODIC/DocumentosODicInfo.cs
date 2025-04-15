#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBDocumentosODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBDocumentosDicInfo.TabelaNome;
    public string ICampoCodigo() => DBDocumentosDicInfo.CampoCodigo;
    public string IPrefixo() => DBDocumentosDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBDocumentosDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBDocumentosDicInfo.Processo => DBDocumentosDicInfo.DocProcesso,
        DBDocumentosDicInfo.Data => DBDocumentosDicInfo.DocData,
        DBDocumentosDicInfo.Observacao => DBDocumentosDicInfo.DocObservacao,
        DBDocumentosDicInfo.GUID => DBDocumentosDicInfo.DocGUID,
        DBDocumentosDicInfo.QuemCad => DBDocumentosDicInfo.DocQuemCad,
        DBDocumentosDicInfo.DtCad => DBDocumentosDicInfo.DocDtCad,
        DBDocumentosDicInfo.QuemAtu => DBDocumentosDicInfo.DocQuemAtu,
        DBDocumentosDicInfo.DtAtu => DBDocumentosDicInfo.DocDtAtu,
        DBDocumentosDicInfo.Visto => DBDocumentosDicInfo.DocVisto,
        _ => null
    };
    public static string TCampoCodigo => DBDocumentosDicInfo.CampoCodigo;
    public static string TCampoNome => DBDocumentosDicInfo.CampoNome;
    public static string TTabelaNome => DBDocumentosDicInfo.TabelaNome;
    public static string TTablePrefix => DBDocumentosDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBDocumentosDicInfo.DocProcesso, DBDocumentosDicInfo.DocData, DBDocumentosDicInfo.DocObservacao, DBDocumentosDicInfo.DocGUID, DBDocumentosDicInfo.DocQuemCad, DBDocumentosDicInfo.DocDtCad, DBDocumentosDicInfo.DocQuemAtu, DBDocumentosDicInfo.DocDtAtu, DBDocumentosDicInfo.DocVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBDocumentosDicInfo.DocProcesso, DBDocumentosDicInfo.DocData, DBDocumentosDicInfo.DocObservacao];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "docCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBDocumentosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "docCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBDocumentosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
