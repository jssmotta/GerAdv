#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBCargosODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBCargosDicInfo.TabelaNome;
    public string ICampoCodigo() => DBCargosDicInfo.CampoCodigo;
    public string IPrefixo() => DBCargosDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBCargosDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBCargosDicInfo.Nome => DBCargosDicInfo.CarNome,
        DBCargosDicInfo.QuemCad => DBCargosDicInfo.CarQuemCad,
        DBCargosDicInfo.DtCad => DBCargosDicInfo.CarDtCad,
        DBCargosDicInfo.QuemAtu => DBCargosDicInfo.CarQuemAtu,
        DBCargosDicInfo.DtAtu => DBCargosDicInfo.CarDtAtu,
        DBCargosDicInfo.Visto => DBCargosDicInfo.CarVisto,
        _ => null
    };
    public static string TCampoCodigo => DBCargosDicInfo.CampoCodigo;
    public static string TCampoNome => DBCargosDicInfo.CampoNome;
    public static string TTabelaNome => DBCargosDicInfo.TabelaNome;
    public static string TTablePrefix => DBCargosDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBCargosDicInfo.CarNome, DBCargosDicInfo.CarQuemCad, DBCargosDicInfo.CarDtCad, DBCargosDicInfo.CarQuemAtu, DBCargosDicInfo.CarDtAtu, DBCargosDicInfo.CarVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBCargosDicInfo.CarNome];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "carCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBCargosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "carCodigo",
            "carNome"
        };
        var result = campos.Where(campo => !campo.Equals(DBCargosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
