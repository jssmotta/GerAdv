#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBNENotasODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBNENotasDicInfo.TabelaNome;
    public string ICampoCodigo() => DBNENotasDicInfo.CampoCodigo;
    public string IPrefixo() => DBNENotasDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBNENotasDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBNENotasDicInfo.Apenso => DBNENotasDicInfo.NepApenso,
        DBNENotasDicInfo.Precatoria => DBNENotasDicInfo.NepPrecatoria,
        DBNENotasDicInfo.Instancia => DBNENotasDicInfo.NepInstancia,
        DBNENotasDicInfo.MovPro => DBNENotasDicInfo.NepMovPro,
        DBNENotasDicInfo.Nome => DBNENotasDicInfo.NepNome,
        DBNENotasDicInfo.NotaExpedida => DBNENotasDicInfo.NepNotaExpedida,
        DBNENotasDicInfo.Revisada => DBNENotasDicInfo.NepRevisada,
        DBNENotasDicInfo.Processo => DBNENotasDicInfo.NepProcesso,
        DBNENotasDicInfo.PalavraChave => DBNENotasDicInfo.NepPalavraChave,
        DBNENotasDicInfo.Data => DBNENotasDicInfo.NepData,
        DBNENotasDicInfo.NotaPublicada => DBNENotasDicInfo.NepNotaPublicada,
        DBNENotasDicInfo.QuemCad => DBNENotasDicInfo.NepQuemCad,
        DBNENotasDicInfo.DtCad => DBNENotasDicInfo.NepDtCad,
        DBNENotasDicInfo.QuemAtu => DBNENotasDicInfo.NepQuemAtu,
        DBNENotasDicInfo.DtAtu => DBNENotasDicInfo.NepDtAtu,
        DBNENotasDicInfo.Visto => DBNENotasDicInfo.NepVisto,
        _ => null
    };
    public static string TCampoCodigo => DBNENotasDicInfo.CampoCodigo;
    public static string TCampoNome => DBNENotasDicInfo.CampoNome;
    public static string TTabelaNome => DBNENotasDicInfo.TabelaNome;
    public static string TTablePrefix => DBNENotasDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBNENotasDicInfo.NepApenso, DBNENotasDicInfo.NepPrecatoria, DBNENotasDicInfo.NepInstancia, DBNENotasDicInfo.NepMovPro, DBNENotasDicInfo.NepNome, DBNENotasDicInfo.NepNotaExpedida, DBNENotasDicInfo.NepRevisada, DBNENotasDicInfo.NepProcesso, DBNENotasDicInfo.NepPalavraChave, DBNENotasDicInfo.NepData, DBNENotasDicInfo.NepNotaPublicada, DBNENotasDicInfo.NepQuemCad, DBNENotasDicInfo.NepDtCad, DBNENotasDicInfo.NepQuemAtu, DBNENotasDicInfo.NepDtAtu, DBNENotasDicInfo.NepVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBNENotasDicInfo.NepApenso, DBNENotasDicInfo.NepPrecatoria, DBNENotasDicInfo.NepInstancia, DBNENotasDicInfo.NepMovPro, DBNENotasDicInfo.NepNome, DBNENotasDicInfo.NepNotaExpedida, DBNENotasDicInfo.NepRevisada, DBNENotasDicInfo.NepProcesso, DBNENotasDicInfo.NepPalavraChave, DBNENotasDicInfo.NepData, DBNENotasDicInfo.NepNotaPublicada];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "nepCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBNENotasDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "nepCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBNENotasDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
