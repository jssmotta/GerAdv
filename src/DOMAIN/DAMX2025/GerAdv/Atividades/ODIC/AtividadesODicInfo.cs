#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBAtividadesODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBAtividadesDicInfo.TabelaNome;
    public string ICampoCodigo() => DBAtividadesDicInfo.CampoCodigo;
    public string IPrefixo() => DBAtividadesDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBAtividadesDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBAtividadesDicInfo.Descricao => DBAtividadesDicInfo.AtvDescricao,
        DBAtividadesDicInfo.GUID => DBAtividadesDicInfo.AtvGUID,
        DBAtividadesDicInfo.QuemCad => DBAtividadesDicInfo.AtvQuemCad,
        DBAtividadesDicInfo.DtCad => DBAtividadesDicInfo.AtvDtCad,
        DBAtividadesDicInfo.QuemAtu => DBAtividadesDicInfo.AtvQuemAtu,
        DBAtividadesDicInfo.DtAtu => DBAtividadesDicInfo.AtvDtAtu,
        DBAtividadesDicInfo.Visto => DBAtividadesDicInfo.AtvVisto,
        _ => null
    };
    public static string TCampoCodigo => DBAtividadesDicInfo.CampoCodigo;
    public static string TCampoNome => DBAtividadesDicInfo.CampoNome;
    public static string TTabelaNome => DBAtividadesDicInfo.TabelaNome;
    public static string TTablePrefix => DBAtividadesDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBAtividadesDicInfo.AtvDescricao, DBAtividadesDicInfo.AtvGUID, DBAtividadesDicInfo.AtvQuemCad, DBAtividadesDicInfo.AtvDtCad, DBAtividadesDicInfo.AtvQuemAtu, DBAtividadesDicInfo.AtvDtAtu, DBAtividadesDicInfo.AtvVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBAtividadesDicInfo.AtvDescricao, DBAtividadesDicInfo.AtvGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "atvCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBAtividadesDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "atvCodigo",
            "atvDescricao"
        };
        var result = campos.Where(campo => !campo.Equals(DBAtividadesDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
