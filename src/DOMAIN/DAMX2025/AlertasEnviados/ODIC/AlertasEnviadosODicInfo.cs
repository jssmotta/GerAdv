#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBAlertasEnviadosODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBAlertasEnviadosDicInfo.TabelaNome;
    public string ICampoCodigo() => DBAlertasEnviadosDicInfo.CampoCodigo;
    public string IPrefixo() => DBAlertasEnviadosDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => false;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBAlertasEnviadosDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => false;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBAlertasEnviadosDicInfo.Operador => DBAlertasEnviadosDicInfo.AloOperador,
        DBAlertasEnviadosDicInfo.Alerta => DBAlertasEnviadosDicInfo.AloAlerta,
        DBAlertasEnviadosDicInfo.DataAlertado => DBAlertasEnviadosDicInfo.AloDataAlertado,
        DBAlertasEnviadosDicInfo.Visualizado => DBAlertasEnviadosDicInfo.AloVisualizado,
        _ => null
    };
    public static string TCampoCodigo => DBAlertasEnviadosDicInfo.CampoCodigo;
    public static string TCampoNome => DBAlertasEnviadosDicInfo.CampoNome;
    public static string TTabelaNome => DBAlertasEnviadosDicInfo.TabelaNome;
    public static string TTablePrefix => DBAlertasEnviadosDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBAlertasEnviadosDicInfo.AloOperador, DBAlertasEnviadosDicInfo.AloAlerta, DBAlertasEnviadosDicInfo.AloDataAlertado, DBAlertasEnviadosDicInfo.AloVisualizado];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBAlertasEnviadosDicInfo.AloOperador, DBAlertasEnviadosDicInfo.AloAlerta, DBAlertasEnviadosDicInfo.AloDataAlertado, DBAlertasEnviadosDicInfo.AloVisualizado];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "aloAlerta",
            "aloOperador"
        };
        var result = campos.Where(campo => !campo.Equals(DBAlertasEnviadosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "aloAlerta",
            "aloCodigo",
            "aloOperador"
        };
        var result = campos.Where(campo => !campo.Equals(DBAlertasEnviadosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
