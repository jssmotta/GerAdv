#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBStatusTarefasODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBStatusTarefasDicInfo.TabelaNome;
    public string ICampoCodigo() => DBStatusTarefasDicInfo.CampoCodigo;
    public string IPrefixo() => DBStatusTarefasDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBStatusTarefasDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBStatusTarefasDicInfo.Nome => DBStatusTarefasDicInfo.SttNome,
        DBStatusTarefasDicInfo.GUID => DBStatusTarefasDicInfo.SttGUID,
        DBStatusTarefasDicInfo.QuemCad => DBStatusTarefasDicInfo.SttQuemCad,
        DBStatusTarefasDicInfo.DtCad => DBStatusTarefasDicInfo.SttDtCad,
        DBStatusTarefasDicInfo.QuemAtu => DBStatusTarefasDicInfo.SttQuemAtu,
        DBStatusTarefasDicInfo.DtAtu => DBStatusTarefasDicInfo.SttDtAtu,
        DBStatusTarefasDicInfo.Visto => DBStatusTarefasDicInfo.SttVisto,
        _ => null
    };
    public static string TCampoCodigo => DBStatusTarefasDicInfo.CampoCodigo;
    public static string TCampoNome => DBStatusTarefasDicInfo.CampoNome;
    public static string TTabelaNome => DBStatusTarefasDicInfo.TabelaNome;
    public static string TTablePrefix => DBStatusTarefasDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBStatusTarefasDicInfo.SttNome, DBStatusTarefasDicInfo.SttGUID, DBStatusTarefasDicInfo.SttQuemCad, DBStatusTarefasDicInfo.SttDtCad, DBStatusTarefasDicInfo.SttQuemAtu, DBStatusTarefasDicInfo.SttDtAtu, DBStatusTarefasDicInfo.SttVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBStatusTarefasDicInfo.SttNome];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "sttCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBStatusTarefasDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "sttCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBStatusTarefasDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
