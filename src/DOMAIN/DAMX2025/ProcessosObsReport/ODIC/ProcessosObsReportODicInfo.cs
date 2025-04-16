#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBProcessosObsReportODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBProcessosObsReportDicInfo.TabelaNome;
    public string ICampoCodigo() => DBProcessosObsReportDicInfo.CampoCodigo;
    public string IPrefixo() => DBProcessosObsReportDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBProcessosObsReportDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBProcessosObsReportDicInfo.Data => DBProcessosObsReportDicInfo.PrrData,
        DBProcessosObsReportDicInfo.Processo => DBProcessosObsReportDicInfo.PrrProcesso,
        DBProcessosObsReportDicInfo.Observacao => DBProcessosObsReportDicInfo.PrrObservacao,
        DBProcessosObsReportDicInfo.Historico => DBProcessosObsReportDicInfo.PrrHistorico,
        DBProcessosObsReportDicInfo.QuemCad => DBProcessosObsReportDicInfo.PrrQuemCad,
        DBProcessosObsReportDicInfo.DtCad => DBProcessosObsReportDicInfo.PrrDtCad,
        DBProcessosObsReportDicInfo.QuemAtu => DBProcessosObsReportDicInfo.PrrQuemAtu,
        DBProcessosObsReportDicInfo.DtAtu => DBProcessosObsReportDicInfo.PrrDtAtu,
        DBProcessosObsReportDicInfo.Visto => DBProcessosObsReportDicInfo.PrrVisto,
        _ => null
    };
    public static string TCampoCodigo => DBProcessosObsReportDicInfo.CampoCodigo;
    public static string TCampoNome => DBProcessosObsReportDicInfo.CampoNome;
    public static string TTabelaNome => DBProcessosObsReportDicInfo.TabelaNome;
    public static string TTablePrefix => DBProcessosObsReportDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBProcessosObsReportDicInfo.PrrData, DBProcessosObsReportDicInfo.PrrProcesso, DBProcessosObsReportDicInfo.PrrObservacao, DBProcessosObsReportDicInfo.PrrHistorico, DBProcessosObsReportDicInfo.PrrQuemCad, DBProcessosObsReportDicInfo.PrrDtCad, DBProcessosObsReportDicInfo.PrrQuemAtu, DBProcessosObsReportDicInfo.PrrDtAtu, DBProcessosObsReportDicInfo.PrrVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBProcessosObsReportDicInfo.PrrData, DBProcessosObsReportDicInfo.PrrProcesso, DBProcessosObsReportDicInfo.PrrObservacao, DBProcessosObsReportDicInfo.PrrHistorico];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "prrProcesso"
        };
        var result = campos.Where(campo => !campo.Equals(DBProcessosObsReportDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "prrCodigo",
            "prrProcesso"
        };
        var result = campos.Where(campo => !campo.Equals(DBProcessosObsReportDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
