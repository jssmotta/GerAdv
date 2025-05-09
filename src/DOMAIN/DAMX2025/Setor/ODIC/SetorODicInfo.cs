#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBSetorODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBSetorDicInfo.TabelaNome;
    public string ICampoCodigo() => DBSetorDicInfo.CampoCodigo;
    public string IPrefixo() => DBSetorDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBSetorDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBSetorDicInfo.Descricao => DBSetorDicInfo.SetDescricao,
        DBSetorDicInfo.GUID => DBSetorDicInfo.SetGUID,
        DBSetorDicInfo.QuemCad => DBSetorDicInfo.SetQuemCad,
        DBSetorDicInfo.DtCad => DBSetorDicInfo.SetDtCad,
        DBSetorDicInfo.QuemAtu => DBSetorDicInfo.SetQuemAtu,
        DBSetorDicInfo.DtAtu => DBSetorDicInfo.SetDtAtu,
        DBSetorDicInfo.Visto => DBSetorDicInfo.SetVisto,
        _ => null
    };
    public static string TCampoCodigo => DBSetorDicInfo.CampoCodigo;
    public static string TCampoNome => DBSetorDicInfo.CampoNome;
    public static string TTabelaNome => DBSetorDicInfo.TabelaNome;
    public static string TTablePrefix => DBSetorDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBSetorDicInfo.SetDescricao, DBSetorDicInfo.SetGUID, DBSetorDicInfo.SetQuemCad, DBSetorDicInfo.SetDtCad, DBSetorDicInfo.SetQuemAtu, DBSetorDicInfo.SetDtAtu, DBSetorDicInfo.SetVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBSetorDicInfo.SetDescricao, DBSetorDicInfo.SetGUID];

    public static List<DBInfoSystem> ListPk() => [];
    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "setDescricao"
        };
        var result = campos.Where(campo => !campo.Equals(DBSetorDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
