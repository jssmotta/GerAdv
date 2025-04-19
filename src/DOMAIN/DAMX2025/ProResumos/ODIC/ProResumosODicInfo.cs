#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBProResumosODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBProResumosDicInfo.TabelaNome;
    public string ICampoCodigo() => DBProResumosDicInfo.CampoCodigo;
    public string IPrefixo() => DBProResumosDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBProResumosDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBProResumosDicInfo.Processo => DBProResumosDicInfo.PrsProcesso,
        DBProResumosDicInfo.Data => DBProResumosDicInfo.PrsData,
        DBProResumosDicInfo.Resumo => DBProResumosDicInfo.PrsResumo,
        DBProResumosDicInfo.TipoResumo => DBProResumosDicInfo.PrsTipoResumo,
        DBProResumosDicInfo.Bold => DBProResumosDicInfo.PrsBold,
        DBProResumosDicInfo.GUID => DBProResumosDicInfo.PrsGUID,
        DBProResumosDicInfo.QuemCad => DBProResumosDicInfo.PrsQuemCad,
        DBProResumosDicInfo.DtCad => DBProResumosDicInfo.PrsDtCad,
        DBProResumosDicInfo.QuemAtu => DBProResumosDicInfo.PrsQuemAtu,
        DBProResumosDicInfo.DtAtu => DBProResumosDicInfo.PrsDtAtu,
        DBProResumosDicInfo.Visto => DBProResumosDicInfo.PrsVisto,
        _ => null
    };
    public static string TCampoCodigo => DBProResumosDicInfo.CampoCodigo;
    public static string TCampoNome => DBProResumosDicInfo.CampoNome;
    public static string TTabelaNome => DBProResumosDicInfo.TabelaNome;
    public static string TTablePrefix => DBProResumosDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBProResumosDicInfo.PrsProcesso, DBProResumosDicInfo.PrsData, DBProResumosDicInfo.PrsResumo, DBProResumosDicInfo.PrsTipoResumo, DBProResumosDicInfo.PrsBold, DBProResumosDicInfo.PrsGUID, DBProResumosDicInfo.PrsQuemCad, DBProResumosDicInfo.PrsDtCad, DBProResumosDicInfo.PrsQuemAtu, DBProResumosDicInfo.PrsDtAtu, DBProResumosDicInfo.PrsVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBProResumosDicInfo.PrsProcesso, DBProResumosDicInfo.PrsData, DBProResumosDicInfo.PrsResumo, DBProResumosDicInfo.PrsTipoResumo, DBProResumosDicInfo.PrsBold, DBProResumosDicInfo.PrsGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "prsCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBProResumosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "prsCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBProResumosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
