#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBGUTTipoODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBGUTTipoDicInfo.TabelaNome;
    public string ICampoCodigo() => DBGUTTipoDicInfo.CampoCodigo;
    public string IPrefixo() => DBGUTTipoDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBGUTTipoDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBGUTTipoDicInfo.Nome => DBGUTTipoDicInfo.GttNome,
        DBGUTTipoDicInfo.Ordem => DBGUTTipoDicInfo.GttOrdem,
        DBGUTTipoDicInfo.GUID => DBGUTTipoDicInfo.GttGUID,
        DBGUTTipoDicInfo.QuemCad => DBGUTTipoDicInfo.GttQuemCad,
        DBGUTTipoDicInfo.DtCad => DBGUTTipoDicInfo.GttDtCad,
        DBGUTTipoDicInfo.QuemAtu => DBGUTTipoDicInfo.GttQuemAtu,
        DBGUTTipoDicInfo.DtAtu => DBGUTTipoDicInfo.GttDtAtu,
        DBGUTTipoDicInfo.Visto => DBGUTTipoDicInfo.GttVisto,
        _ => null
    };
    public static string TCampoCodigo => DBGUTTipoDicInfo.CampoCodigo;
    public static string TCampoNome => DBGUTTipoDicInfo.CampoNome;
    public static string TTabelaNome => DBGUTTipoDicInfo.TabelaNome;
    public static string TTablePrefix => DBGUTTipoDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBGUTTipoDicInfo.GttNome, DBGUTTipoDicInfo.GttOrdem, DBGUTTipoDicInfo.GttGUID, DBGUTTipoDicInfo.GttQuemCad, DBGUTTipoDicInfo.GttDtCad, DBGUTTipoDicInfo.GttQuemAtu, DBGUTTipoDicInfo.GttDtAtu, DBGUTTipoDicInfo.GttVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBGUTTipoDicInfo.GttNome, DBGUTTipoDicInfo.GttOrdem, DBGUTTipoDicInfo.GttGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "gttCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBGUTTipoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "gttCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBGUTTipoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
