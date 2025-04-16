#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBContatoCRMOperadorODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBContatoCRMOperadorDicInfo.TabelaNome;
    public string ICampoCodigo() => DBContatoCRMOperadorDicInfo.CampoCodigo;
    public string IPrefixo() => DBContatoCRMOperadorDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBContatoCRMOperadorDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBContatoCRMOperadorDicInfo.ContatoCRM => DBContatoCRMOperadorDicInfo.CcoContatoCRM,
        DBContatoCRMOperadorDicInfo.CargoEsc => DBContatoCRMOperadorDicInfo.CcoCargoEsc,
        DBContatoCRMOperadorDicInfo.Operador => DBContatoCRMOperadorDicInfo.CcoOperador,
        DBContatoCRMOperadorDicInfo.QuemCad => DBContatoCRMOperadorDicInfo.CcoQuemCad,
        DBContatoCRMOperadorDicInfo.DtCad => DBContatoCRMOperadorDicInfo.CcoDtCad,
        DBContatoCRMOperadorDicInfo.QuemAtu => DBContatoCRMOperadorDicInfo.CcoQuemAtu,
        DBContatoCRMOperadorDicInfo.DtAtu => DBContatoCRMOperadorDicInfo.CcoDtAtu,
        DBContatoCRMOperadorDicInfo.Visto => DBContatoCRMOperadorDicInfo.CcoVisto,
        _ => null
    };
    public static string TCampoCodigo => DBContatoCRMOperadorDicInfo.CampoCodigo;
    public static string TCampoNome => DBContatoCRMOperadorDicInfo.CampoNome;
    public static string TTabelaNome => DBContatoCRMOperadorDicInfo.TabelaNome;
    public static string TTablePrefix => DBContatoCRMOperadorDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBContatoCRMOperadorDicInfo.CcoContatoCRM, DBContatoCRMOperadorDicInfo.CcoCargoEsc, DBContatoCRMOperadorDicInfo.CcoOperador, DBContatoCRMOperadorDicInfo.CcoQuemCad, DBContatoCRMOperadorDicInfo.CcoDtCad, DBContatoCRMOperadorDicInfo.CcoQuemAtu, DBContatoCRMOperadorDicInfo.CcoDtAtu, DBContatoCRMOperadorDicInfo.CcoVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBContatoCRMOperadorDicInfo.CcoContatoCRM, DBContatoCRMOperadorDicInfo.CcoCargoEsc, DBContatoCRMOperadorDicInfo.CcoOperador];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "ccoCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBContatoCRMOperadorDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "ccoCargoEsc",
            "ccoCodigo",
            "ccoContatoCRM",
            "ccoOperador"
        };
        var result = campos.Where(campo => !campo.Equals(DBContatoCRMOperadorDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
