#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBModelosDocumentosODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBModelosDocumentosDicInfo.TabelaNome;
    public string ICampoCodigo() => DBModelosDocumentosDicInfo.CampoCodigo;
    public string IPrefixo() => DBModelosDocumentosDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBModelosDocumentosDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBModelosDocumentosDicInfo.Nome => DBModelosDocumentosDicInfo.MdcNome,
        DBModelosDocumentosDicInfo.Remuneracao => DBModelosDocumentosDicInfo.MdcRemuneracao,
        DBModelosDocumentosDicInfo.Assinatura => DBModelosDocumentosDicInfo.MdcAssinatura,
        DBModelosDocumentosDicInfo.Header => DBModelosDocumentosDicInfo.MdcHeader,
        DBModelosDocumentosDicInfo.Footer => DBModelosDocumentosDicInfo.MdcFooter,
        DBModelosDocumentosDicInfo.Extra1 => DBModelosDocumentosDicInfo.MdcExtra1,
        DBModelosDocumentosDicInfo.Extra2 => DBModelosDocumentosDicInfo.MdcExtra2,
        DBModelosDocumentosDicInfo.Extra3 => DBModelosDocumentosDicInfo.MdcExtra3,
        DBModelosDocumentosDicInfo.Outorgante => DBModelosDocumentosDicInfo.MdcOutorgante,
        DBModelosDocumentosDicInfo.Outorgados => DBModelosDocumentosDicInfo.MdcOutorgados,
        DBModelosDocumentosDicInfo.Poderes => DBModelosDocumentosDicInfo.MdcPoderes,
        DBModelosDocumentosDicInfo.Objeto => DBModelosDocumentosDicInfo.MdcObjeto,
        DBModelosDocumentosDicInfo.Titulo => DBModelosDocumentosDicInfo.MdcTitulo,
        DBModelosDocumentosDicInfo.Testemunhas => DBModelosDocumentosDicInfo.MdcTestemunhas,
        DBModelosDocumentosDicInfo.TipoModeloDocumento => DBModelosDocumentosDicInfo.MdcTipoModeloDocumento,
        DBModelosDocumentosDicInfo.CSS => DBModelosDocumentosDicInfo.MdcCSS,
        DBModelosDocumentosDicInfo.GUID => DBModelosDocumentosDicInfo.MdcGUID,
        DBModelosDocumentosDicInfo.QuemCad => DBModelosDocumentosDicInfo.MdcQuemCad,
        DBModelosDocumentosDicInfo.DtCad => DBModelosDocumentosDicInfo.MdcDtCad,
        DBModelosDocumentosDicInfo.QuemAtu => DBModelosDocumentosDicInfo.MdcQuemAtu,
        DBModelosDocumentosDicInfo.DtAtu => DBModelosDocumentosDicInfo.MdcDtAtu,
        DBModelosDocumentosDicInfo.Visto => DBModelosDocumentosDicInfo.MdcVisto,
        _ => null
    };
    public static string TCampoCodigo => DBModelosDocumentosDicInfo.CampoCodigo;
    public static string TCampoNome => DBModelosDocumentosDicInfo.CampoNome;
    public static string TTabelaNome => DBModelosDocumentosDicInfo.TabelaNome;
    public static string TTablePrefix => DBModelosDocumentosDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBModelosDocumentosDicInfo.MdcNome, DBModelosDocumentosDicInfo.MdcRemuneracao, DBModelosDocumentosDicInfo.MdcAssinatura, DBModelosDocumentosDicInfo.MdcHeader, DBModelosDocumentosDicInfo.MdcFooter, DBModelosDocumentosDicInfo.MdcExtra1, DBModelosDocumentosDicInfo.MdcExtra2, DBModelosDocumentosDicInfo.MdcExtra3, DBModelosDocumentosDicInfo.MdcOutorgante, DBModelosDocumentosDicInfo.MdcOutorgados, DBModelosDocumentosDicInfo.MdcPoderes, DBModelosDocumentosDicInfo.MdcObjeto, DBModelosDocumentosDicInfo.MdcTitulo, DBModelosDocumentosDicInfo.MdcTestemunhas, DBModelosDocumentosDicInfo.MdcTipoModeloDocumento, DBModelosDocumentosDicInfo.MdcCSS, DBModelosDocumentosDicInfo.MdcGUID, DBModelosDocumentosDicInfo.MdcQuemCad, DBModelosDocumentosDicInfo.MdcDtCad, DBModelosDocumentosDicInfo.MdcQuemAtu, DBModelosDocumentosDicInfo.MdcDtAtu, DBModelosDocumentosDicInfo.MdcVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBModelosDocumentosDicInfo.MdcNome, DBModelosDocumentosDicInfo.MdcRemuneracao, DBModelosDocumentosDicInfo.MdcAssinatura, DBModelosDocumentosDicInfo.MdcHeader, DBModelosDocumentosDicInfo.MdcFooter, DBModelosDocumentosDicInfo.MdcExtra1, DBModelosDocumentosDicInfo.MdcExtra2, DBModelosDocumentosDicInfo.MdcExtra3, DBModelosDocumentosDicInfo.MdcOutorgante, DBModelosDocumentosDicInfo.MdcOutorgados, DBModelosDocumentosDicInfo.MdcPoderes, DBModelosDocumentosDicInfo.MdcObjeto, DBModelosDocumentosDicInfo.MdcTitulo, DBModelosDocumentosDicInfo.MdcTestemunhas, DBModelosDocumentosDicInfo.MdcTipoModeloDocumento, DBModelosDocumentosDicInfo.MdcCSS, DBModelosDocumentosDicInfo.MdcGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "mdcNome"
        };
        var result = campos.Where(campo => !campo.Equals(DBModelosDocumentosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "mdcCodigo",
            "mdcNome"
        };
        var result = campos.Where(campo => !campo.Equals(DBModelosDocumentosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
