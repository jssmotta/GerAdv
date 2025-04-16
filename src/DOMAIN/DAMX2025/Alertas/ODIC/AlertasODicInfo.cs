#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBAlertasODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBAlertasDicInfo.TabelaNome;
    public string ICampoCodigo() => DBAlertasDicInfo.CampoCodigo;
    public string IPrefixo() => DBAlertasDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBAlertasDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBAlertasDicInfo.Nome => DBAlertasDicInfo.AltNome,
        DBAlertasDicInfo.Data => DBAlertasDicInfo.AltData,
        DBAlertasDicInfo.Operador => DBAlertasDicInfo.AltOperador,
        DBAlertasDicInfo.DataAte => DBAlertasDicInfo.AltDataAte,
        DBAlertasDicInfo.QuemCad => DBAlertasDicInfo.AltQuemCad,
        DBAlertasDicInfo.DtCad => DBAlertasDicInfo.AltDtCad,
        DBAlertasDicInfo.QuemAtu => DBAlertasDicInfo.AltQuemAtu,
        DBAlertasDicInfo.DtAtu => DBAlertasDicInfo.AltDtAtu,
        DBAlertasDicInfo.Visto => DBAlertasDicInfo.AltVisto,
        _ => null
    };
    public static string TCampoCodigo => DBAlertasDicInfo.CampoCodigo;
    public static string TCampoNome => DBAlertasDicInfo.CampoNome;
    public static string TTabelaNome => DBAlertasDicInfo.TabelaNome;
    public static string TTablePrefix => DBAlertasDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBAlertasDicInfo.AltNome, DBAlertasDicInfo.AltData, DBAlertasDicInfo.AltOperador, DBAlertasDicInfo.AltDataAte, DBAlertasDicInfo.AltQuemCad, DBAlertasDicInfo.AltDtCad, DBAlertasDicInfo.AltQuemAtu, DBAlertasDicInfo.AltDtAtu, DBAlertasDicInfo.AltVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBAlertasDicInfo.AltNome, DBAlertasDicInfo.AltData, DBAlertasDicInfo.AltOperador, DBAlertasDicInfo.AltDataAte];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "altCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBAlertasDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "altCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBAlertasDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
