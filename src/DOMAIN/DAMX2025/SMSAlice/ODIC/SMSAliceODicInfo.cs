#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBSMSAliceODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBSMSAliceDicInfo.TabelaNome;
    public string ICampoCodigo() => DBSMSAliceDicInfo.CampoCodigo;
    public string IPrefixo() => DBSMSAliceDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBSMSAliceDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBSMSAliceDicInfo.Operador => DBSMSAliceDicInfo.SmaOperador,
        DBSMSAliceDicInfo.Nome => DBSMSAliceDicInfo.SmaNome,
        DBSMSAliceDicInfo.TipoEMail => DBSMSAliceDicInfo.SmaTipoEMail,
        DBSMSAliceDicInfo.GUID => DBSMSAliceDicInfo.SmaGUID,
        DBSMSAliceDicInfo.QuemCad => DBSMSAliceDicInfo.SmaQuemCad,
        DBSMSAliceDicInfo.DtCad => DBSMSAliceDicInfo.SmaDtCad,
        DBSMSAliceDicInfo.QuemAtu => DBSMSAliceDicInfo.SmaQuemAtu,
        DBSMSAliceDicInfo.DtAtu => DBSMSAliceDicInfo.SmaDtAtu,
        DBSMSAliceDicInfo.Visto => DBSMSAliceDicInfo.SmaVisto,
        _ => null
    };
    public static string TCampoCodigo => DBSMSAliceDicInfo.CampoCodigo;
    public static string TCampoNome => DBSMSAliceDicInfo.CampoNome;
    public static string TTabelaNome => DBSMSAliceDicInfo.TabelaNome;
    public static string TTablePrefix => DBSMSAliceDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBSMSAliceDicInfo.SmaOperador, DBSMSAliceDicInfo.SmaNome, DBSMSAliceDicInfo.SmaTipoEMail, DBSMSAliceDicInfo.SmaGUID, DBSMSAliceDicInfo.SmaQuemCad, DBSMSAliceDicInfo.SmaDtCad, DBSMSAliceDicInfo.SmaQuemAtu, DBSMSAliceDicInfo.SmaDtAtu, DBSMSAliceDicInfo.SmaVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBSMSAliceDicInfo.SmaOperador, DBSMSAliceDicInfo.SmaNome, DBSMSAliceDicInfo.SmaTipoEMail, DBSMSAliceDicInfo.SmaGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "smaNome",
            "smaOperador"
        };
        var result = campos.Where(campo => !campo.Equals(DBSMSAliceDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "smaCodigo",
            "smaNome",
            "smaOperador"
        };
        var result = campos.Where(campo => !campo.Equals(DBSMSAliceDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
