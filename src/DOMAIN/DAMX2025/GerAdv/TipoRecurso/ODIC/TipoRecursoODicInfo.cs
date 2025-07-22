#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBTipoRecursoODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBTipoRecursoDicInfo.TabelaNome;
    public string ICampoCodigo() => DBTipoRecursoDicInfo.CampoCodigo;
    public string IPrefixo() => DBTipoRecursoDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBTipoRecursoDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBTipoRecursoDicInfo.Justica => DBTipoRecursoDicInfo.TrcJustica,
        DBTipoRecursoDicInfo.Area => DBTipoRecursoDicInfo.TrcArea,
        DBTipoRecursoDicInfo.Descricao => DBTipoRecursoDicInfo.TrcDescricao,
        DBTipoRecursoDicInfo.GUID => DBTipoRecursoDicInfo.TrcGUID,
        DBTipoRecursoDicInfo.QuemCad => DBTipoRecursoDicInfo.TrcQuemCad,
        DBTipoRecursoDicInfo.DtCad => DBTipoRecursoDicInfo.TrcDtCad,
        DBTipoRecursoDicInfo.QuemAtu => DBTipoRecursoDicInfo.TrcQuemAtu,
        DBTipoRecursoDicInfo.DtAtu => DBTipoRecursoDicInfo.TrcDtAtu,
        DBTipoRecursoDicInfo.Visto => DBTipoRecursoDicInfo.TrcVisto,
        _ => null
    };
    public static string TCampoCodigo => DBTipoRecursoDicInfo.CampoCodigo;
    public static string TCampoNome => DBTipoRecursoDicInfo.CampoNome;
    public static string TTabelaNome => DBTipoRecursoDicInfo.TabelaNome;
    public static string TTablePrefix => DBTipoRecursoDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBTipoRecursoDicInfo.TrcJustica, DBTipoRecursoDicInfo.TrcArea, DBTipoRecursoDicInfo.TrcDescricao, DBTipoRecursoDicInfo.TrcGUID, DBTipoRecursoDicInfo.TrcQuemCad, DBTipoRecursoDicInfo.TrcDtCad, DBTipoRecursoDicInfo.TrcQuemAtu, DBTipoRecursoDicInfo.TrcDtAtu, DBTipoRecursoDicInfo.TrcVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBTipoRecursoDicInfo.TrcJustica, DBTipoRecursoDicInfo.TrcArea, DBTipoRecursoDicInfo.TrcDescricao, DBTipoRecursoDicInfo.TrcGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "trcCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBTipoRecursoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "trcArea",
            "trcCodigo",
            "trcDescricao",
            "trcJustica"
        };
        var result = campos.Where(campo => !campo.Equals(DBTipoRecursoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
