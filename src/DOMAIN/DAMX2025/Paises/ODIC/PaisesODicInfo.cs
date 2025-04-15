#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBPaisesODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBPaisesDicInfo.TabelaNome;
    public string ICampoCodigo() => DBPaisesDicInfo.CampoCodigo;
    public string IPrefixo() => DBPaisesDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBPaisesDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBPaisesDicInfo.Nome => DBPaisesDicInfo.PaiNome,
        DBPaisesDicInfo.GUID => DBPaisesDicInfo.PaiGUID,
        DBPaisesDicInfo.QuemCad => DBPaisesDicInfo.PaiQuemCad,
        DBPaisesDicInfo.DtCad => DBPaisesDicInfo.PaiDtCad,
        DBPaisesDicInfo.QuemAtu => DBPaisesDicInfo.PaiQuemAtu,
        DBPaisesDicInfo.DtAtu => DBPaisesDicInfo.PaiDtAtu,
        DBPaisesDicInfo.Visto => DBPaisesDicInfo.PaiVisto,
        _ => null
    };
    public static string TCampoCodigo => DBPaisesDicInfo.CampoCodigo;
    public static string TCampoNome => DBPaisesDicInfo.CampoNome;
    public static string TTabelaNome => DBPaisesDicInfo.TabelaNome;
    public static string TTablePrefix => DBPaisesDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBPaisesDicInfo.PaiNome, DBPaisesDicInfo.PaiGUID, DBPaisesDicInfo.PaiQuemCad, DBPaisesDicInfo.PaiDtCad, DBPaisesDicInfo.PaiQuemAtu, DBPaisesDicInfo.PaiDtAtu, DBPaisesDicInfo.PaiVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBPaisesDicInfo.PaiNome];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "paiCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBPaisesDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "paiCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBPaisesDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
