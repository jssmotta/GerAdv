#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBPenhoraStatusODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBPenhoraStatusDicInfo.TabelaNome;
    public string ICampoCodigo() => DBPenhoraStatusDicInfo.CampoCodigo;
    public string IPrefixo() => DBPenhoraStatusDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBPenhoraStatusDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBPenhoraStatusDicInfo.Nome => DBPenhoraStatusDicInfo.PhsNome,
        DBPenhoraStatusDicInfo.GUID => DBPenhoraStatusDicInfo.PhsGUID,
        DBPenhoraStatusDicInfo.QuemCad => DBPenhoraStatusDicInfo.PhsQuemCad,
        DBPenhoraStatusDicInfo.DtCad => DBPenhoraStatusDicInfo.PhsDtCad,
        DBPenhoraStatusDicInfo.QuemAtu => DBPenhoraStatusDicInfo.PhsQuemAtu,
        DBPenhoraStatusDicInfo.DtAtu => DBPenhoraStatusDicInfo.PhsDtAtu,
        DBPenhoraStatusDicInfo.Visto => DBPenhoraStatusDicInfo.PhsVisto,
        _ => null
    };
    public static string TCampoCodigo => DBPenhoraStatusDicInfo.CampoCodigo;
    public static string TCampoNome => DBPenhoraStatusDicInfo.CampoNome;
    public static string TTabelaNome => DBPenhoraStatusDicInfo.TabelaNome;
    public static string TTablePrefix => DBPenhoraStatusDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBPenhoraStatusDicInfo.PhsNome, DBPenhoraStatusDicInfo.PhsGUID, DBPenhoraStatusDicInfo.PhsQuemCad, DBPenhoraStatusDicInfo.PhsDtCad, DBPenhoraStatusDicInfo.PhsQuemAtu, DBPenhoraStatusDicInfo.PhsDtAtu, DBPenhoraStatusDicInfo.PhsVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBPenhoraStatusDicInfo.PhsNome];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "phsCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBPenhoraStatusDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "phsCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBPenhoraStatusDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
