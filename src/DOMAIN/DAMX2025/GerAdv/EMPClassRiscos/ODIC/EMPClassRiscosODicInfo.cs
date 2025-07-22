#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBEMPClassRiscosODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBEMPClassRiscosDicInfo.TabelaNome;
    public string ICampoCodigo() => DBEMPClassRiscosDicInfo.CampoCodigo;
    public string IPrefixo() => DBEMPClassRiscosDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBEMPClassRiscosDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBEMPClassRiscosDicInfo.Nome => DBEMPClassRiscosDicInfo.EcrNome,
        DBEMPClassRiscosDicInfo.Bold => DBEMPClassRiscosDicInfo.EcrBold,
        DBEMPClassRiscosDicInfo.GUID => DBEMPClassRiscosDicInfo.EcrGUID,
        DBEMPClassRiscosDicInfo.QuemCad => DBEMPClassRiscosDicInfo.EcrQuemCad,
        DBEMPClassRiscosDicInfo.DtCad => DBEMPClassRiscosDicInfo.EcrDtCad,
        DBEMPClassRiscosDicInfo.QuemAtu => DBEMPClassRiscosDicInfo.EcrQuemAtu,
        DBEMPClassRiscosDicInfo.DtAtu => DBEMPClassRiscosDicInfo.EcrDtAtu,
        DBEMPClassRiscosDicInfo.Visto => DBEMPClassRiscosDicInfo.EcrVisto,
        _ => null
    };
    public static string TCampoCodigo => DBEMPClassRiscosDicInfo.CampoCodigo;
    public static string TCampoNome => DBEMPClassRiscosDicInfo.CampoNome;
    public static string TTabelaNome => DBEMPClassRiscosDicInfo.TabelaNome;
    public static string TTablePrefix => DBEMPClassRiscosDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBEMPClassRiscosDicInfo.EcrNome, DBEMPClassRiscosDicInfo.EcrBold, DBEMPClassRiscosDicInfo.EcrGUID, DBEMPClassRiscosDicInfo.EcrQuemCad, DBEMPClassRiscosDicInfo.EcrDtCad, DBEMPClassRiscosDicInfo.EcrQuemAtu, DBEMPClassRiscosDicInfo.EcrDtAtu, DBEMPClassRiscosDicInfo.EcrVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBEMPClassRiscosDicInfo.EcrNome, DBEMPClassRiscosDicInfo.EcrGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "ecrCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBEMPClassRiscosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "ecrCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBEMPClassRiscosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
