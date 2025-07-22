#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBUFODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBUFDicInfo.TabelaNome;
    public string ICampoCodigo() => DBUFDicInfo.CampoCodigo;
    public string IPrefixo() => DBUFDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBUFDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBUFDicInfo.DDD => DBUFDicInfo.UfDDD,
        DBUFDicInfo.ID => DBUFDicInfo.UfID,
        DBUFDicInfo.Pais => DBUFDicInfo.UfPais,
        DBUFDicInfo.Top => DBUFDicInfo.UfTop,
        DBUFDicInfo.Descricao => DBUFDicInfo.UfDescricao,
        DBUFDicInfo.GUID => DBUFDicInfo.UfGUID,
        DBUFDicInfo.QuemCad => DBUFDicInfo.UfQuemCad,
        DBUFDicInfo.DtCad => DBUFDicInfo.UfDtCad,
        DBUFDicInfo.QuemAtu => DBUFDicInfo.UfQuemAtu,
        DBUFDicInfo.DtAtu => DBUFDicInfo.UfDtAtu,
        DBUFDicInfo.Visto => DBUFDicInfo.UfVisto,
        _ => null
    };
    public static string TCampoCodigo => DBUFDicInfo.CampoCodigo;
    public static string TCampoNome => DBUFDicInfo.CampoNome;
    public static string TTabelaNome => DBUFDicInfo.TabelaNome;
    public static string TTablePrefix => DBUFDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBUFDicInfo.UfDDD, DBUFDicInfo.UfID, DBUFDicInfo.UfPais, DBUFDicInfo.UfTop, DBUFDicInfo.UfDescricao, DBUFDicInfo.UfGUID, DBUFDicInfo.UfQuemCad, DBUFDicInfo.UfDtCad, DBUFDicInfo.UfQuemAtu, DBUFDicInfo.UfDtAtu, DBUFDicInfo.UfVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBUFDicInfo.UfDDD, DBUFDicInfo.UfID, DBUFDicInfo.UfPais, DBUFDicInfo.UfTop, DBUFDicInfo.UfDescricao, DBUFDicInfo.UfGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "ufCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBUFDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "ufCodigo",
            "ufID",
            "ufPais"
        };
        var result = campos.Where(campo => !campo.Equals(DBUFDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
