#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBCargosEscODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBCargosEscDicInfo.TabelaNome;
    public string ICampoCodigo() => DBCargosEscDicInfo.CampoCodigo;
    public string IPrefixo() => DBCargosEscDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBCargosEscDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBCargosEscDicInfo.Percentual => DBCargosEscDicInfo.CgePercentual,
        DBCargosEscDicInfo.Nome => DBCargosEscDicInfo.CgeNome,
        DBCargosEscDicInfo.Classificacao => DBCargosEscDicInfo.CgeClassificacao,
        DBCargosEscDicInfo.GUID => DBCargosEscDicInfo.CgeGUID,
        DBCargosEscDicInfo.QuemCad => DBCargosEscDicInfo.CgeQuemCad,
        DBCargosEscDicInfo.DtCad => DBCargosEscDicInfo.CgeDtCad,
        DBCargosEscDicInfo.QuemAtu => DBCargosEscDicInfo.CgeQuemAtu,
        DBCargosEscDicInfo.DtAtu => DBCargosEscDicInfo.CgeDtAtu,
        DBCargosEscDicInfo.Visto => DBCargosEscDicInfo.CgeVisto,
        _ => null
    };
    public static string TCampoCodigo => DBCargosEscDicInfo.CampoCodigo;
    public static string TCampoNome => DBCargosEscDicInfo.CampoNome;
    public static string TTabelaNome => DBCargosEscDicInfo.TabelaNome;
    public static string TTablePrefix => DBCargosEscDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBCargosEscDicInfo.CgePercentual, DBCargosEscDicInfo.CgeNome, DBCargosEscDicInfo.CgeClassificacao, DBCargosEscDicInfo.CgeGUID, DBCargosEscDicInfo.CgeQuemCad, DBCargosEscDicInfo.CgeDtCad, DBCargosEscDicInfo.CgeQuemAtu, DBCargosEscDicInfo.CgeDtAtu, DBCargosEscDicInfo.CgeVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBCargosEscDicInfo.CgePercentual, DBCargosEscDicInfo.CgeNome, DBCargosEscDicInfo.CgeClassificacao];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "cgeCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBCargosEscDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "cgeCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBCargosEscDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
