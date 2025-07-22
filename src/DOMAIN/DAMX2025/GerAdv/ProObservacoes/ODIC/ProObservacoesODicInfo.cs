#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBProObservacoesODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBProObservacoesDicInfo.TabelaNome;
    public string ICampoCodigo() => DBProObservacoesDicInfo.CampoCodigo;
    public string IPrefixo() => DBProObservacoesDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBProObservacoesDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBProObservacoesDicInfo.Processo => DBProObservacoesDicInfo.PobProcesso,
        DBProObservacoesDicInfo.Nome => DBProObservacoesDicInfo.PobNome,
        DBProObservacoesDicInfo.Observacoes => DBProObservacoesDicInfo.PobObservacoes,
        DBProObservacoesDicInfo.Data => DBProObservacoesDicInfo.PobData,
        DBProObservacoesDicInfo.GUID => DBProObservacoesDicInfo.PobGUID,
        DBProObservacoesDicInfo.QuemCad => DBProObservacoesDicInfo.PobQuemCad,
        DBProObservacoesDicInfo.DtCad => DBProObservacoesDicInfo.PobDtCad,
        DBProObservacoesDicInfo.QuemAtu => DBProObservacoesDicInfo.PobQuemAtu,
        DBProObservacoesDicInfo.DtAtu => DBProObservacoesDicInfo.PobDtAtu,
        DBProObservacoesDicInfo.Visto => DBProObservacoesDicInfo.PobVisto,
        _ => null
    };
    public static string TCampoCodigo => DBProObservacoesDicInfo.CampoCodigo;
    public static string TCampoNome => DBProObservacoesDicInfo.CampoNome;
    public static string TTabelaNome => DBProObservacoesDicInfo.TabelaNome;
    public static string TTablePrefix => DBProObservacoesDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBProObservacoesDicInfo.PobProcesso, DBProObservacoesDicInfo.PobNome, DBProObservacoesDicInfo.PobObservacoes, DBProObservacoesDicInfo.PobData, DBProObservacoesDicInfo.PobGUID, DBProObservacoesDicInfo.PobQuemCad, DBProObservacoesDicInfo.PobDtCad, DBProObservacoesDicInfo.PobQuemAtu, DBProObservacoesDicInfo.PobDtAtu, DBProObservacoesDicInfo.PobVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBProObservacoesDicInfo.PobProcesso, DBProObservacoesDicInfo.PobNome, DBProObservacoesDicInfo.PobObservacoes, DBProObservacoesDicInfo.PobData, DBProObservacoesDicInfo.PobGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "pobCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBProObservacoesDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "pobCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBProObservacoesDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
