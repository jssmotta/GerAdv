#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBProDepositosODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBProDepositosDicInfo.TabelaNome;
    public string ICampoCodigo() => DBProDepositosDicInfo.CampoCodigo;
    public string IPrefixo() => DBProDepositosDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBProDepositosDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBProDepositosDicInfo.Processo => DBProDepositosDicInfo.PdsProcesso,
        DBProDepositosDicInfo.Fase => DBProDepositosDicInfo.PdsFase,
        DBProDepositosDicInfo.Data => DBProDepositosDicInfo.PdsData,
        DBProDepositosDicInfo.Valor => DBProDepositosDicInfo.PdsValor,
        DBProDepositosDicInfo.TipoProDesposito => DBProDepositosDicInfo.PdsTipoProDesposito,
        DBProDepositosDicInfo.QuemCad => DBProDepositosDicInfo.PdsQuemCad,
        DBProDepositosDicInfo.DtCad => DBProDepositosDicInfo.PdsDtCad,
        DBProDepositosDicInfo.QuemAtu => DBProDepositosDicInfo.PdsQuemAtu,
        DBProDepositosDicInfo.DtAtu => DBProDepositosDicInfo.PdsDtAtu,
        DBProDepositosDicInfo.Visto => DBProDepositosDicInfo.PdsVisto,
        _ => null
    };
    public static string TCampoCodigo => DBProDepositosDicInfo.CampoCodigo;
    public static string TCampoNome => DBProDepositosDicInfo.CampoNome;
    public static string TTabelaNome => DBProDepositosDicInfo.TabelaNome;
    public static string TTablePrefix => DBProDepositosDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBProDepositosDicInfo.PdsProcesso, DBProDepositosDicInfo.PdsFase, DBProDepositosDicInfo.PdsData, DBProDepositosDicInfo.PdsValor, DBProDepositosDicInfo.PdsTipoProDesposito, DBProDepositosDicInfo.PdsQuemCad, DBProDepositosDicInfo.PdsDtCad, DBProDepositosDicInfo.PdsQuemAtu, DBProDepositosDicInfo.PdsDtAtu, DBProDepositosDicInfo.PdsVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBProDepositosDicInfo.PdsProcesso, DBProDepositosDicInfo.PdsFase, DBProDepositosDicInfo.PdsData, DBProDepositosDicInfo.PdsValor, DBProDepositosDicInfo.PdsTipoProDesposito];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "pdsCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBProDepositosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "pdsCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBProDepositosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
