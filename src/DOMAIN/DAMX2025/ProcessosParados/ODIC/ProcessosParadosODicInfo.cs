#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBProcessosParadosODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBProcessosParadosDicInfo.TabelaNome;
    public string ICampoCodigo() => DBProcessosParadosDicInfo.CampoCodigo;
    public string IPrefixo() => DBProcessosParadosDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => false;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBProcessosParadosDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => false;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBProcessosParadosDicInfo.Processo => DBProcessosParadosDicInfo.PprProcesso,
        DBProcessosParadosDicInfo.Semana => DBProcessosParadosDicInfo.PprSemana,
        DBProcessosParadosDicInfo.Ano => DBProcessosParadosDicInfo.PprAno,
        DBProcessosParadosDicInfo.DataHora => DBProcessosParadosDicInfo.PprDataHora,
        DBProcessosParadosDicInfo.Operador => DBProcessosParadosDicInfo.PprOperador,
        DBProcessosParadosDicInfo.DataHistorico => DBProcessosParadosDicInfo.PprDataHistorico,
        DBProcessosParadosDicInfo.DataNENotas => DBProcessosParadosDicInfo.PprDataNENotas,
        _ => null
    };
    public static string TCampoCodigo => DBProcessosParadosDicInfo.CampoCodigo;
    public static string TCampoNome => DBProcessosParadosDicInfo.CampoNome;
    public static string TTabelaNome => DBProcessosParadosDicInfo.TabelaNome;
    public static string TTablePrefix => DBProcessosParadosDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBProcessosParadosDicInfo.PprProcesso, DBProcessosParadosDicInfo.PprSemana, DBProcessosParadosDicInfo.PprAno, DBProcessosParadosDicInfo.PprDataHora, DBProcessosParadosDicInfo.PprOperador, DBProcessosParadosDicInfo.PprDataHistorico, DBProcessosParadosDicInfo.PprDataNENotas];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBProcessosParadosDicInfo.PprProcesso, DBProcessosParadosDicInfo.PprSemana, DBProcessosParadosDicInfo.PprAno, DBProcessosParadosDicInfo.PprDataHora, DBProcessosParadosDicInfo.PprOperador, DBProcessosParadosDicInfo.PprDataHistorico, DBProcessosParadosDicInfo.PprDataNENotas];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "pprAno",
            "pprProcesso",
            "pprSemana"
        };
        var result = campos.Where(campo => !campo.Equals(DBProcessosParadosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "pprAno",
            "pprCodigo",
            "pprProcesso",
            "pprSemana"
        };
        var result = campos.Where(campo => !campo.Equals(DBProcessosParadosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
