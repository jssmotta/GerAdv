#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBFuncaoODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBFuncaoDicInfo.TabelaNome;
    public string ICampoCodigo() => DBFuncaoDicInfo.CampoCodigo;
    public string IPrefixo() => DBFuncaoDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBFuncaoDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBFuncaoDicInfo.Descricao => DBFuncaoDicInfo.FunDescricao,
        DBFuncaoDicInfo.QuemCad => DBFuncaoDicInfo.FunQuemCad,
        DBFuncaoDicInfo.DtCad => DBFuncaoDicInfo.FunDtCad,
        DBFuncaoDicInfo.QuemAtu => DBFuncaoDicInfo.FunQuemAtu,
        DBFuncaoDicInfo.DtAtu => DBFuncaoDicInfo.FunDtAtu,
        DBFuncaoDicInfo.Visto => DBFuncaoDicInfo.FunVisto,
        _ => null
    };
    public static string TCampoCodigo => DBFuncaoDicInfo.CampoCodigo;
    public static string TCampoNome => DBFuncaoDicInfo.CampoNome;
    public static string TTabelaNome => DBFuncaoDicInfo.TabelaNome;
    public static string TTablePrefix => DBFuncaoDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBFuncaoDicInfo.FunDescricao, DBFuncaoDicInfo.FunQuemCad, DBFuncaoDicInfo.FunDtCad, DBFuncaoDicInfo.FunQuemAtu, DBFuncaoDicInfo.FunDtAtu, DBFuncaoDicInfo.FunVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBFuncaoDicInfo.FunDescricao];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "funCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBFuncaoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "funCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBFuncaoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
