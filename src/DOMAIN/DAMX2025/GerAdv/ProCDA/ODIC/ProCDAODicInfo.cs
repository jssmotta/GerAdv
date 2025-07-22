#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBProCDAODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBProCDADicInfo.TabelaNome;
    public string ICampoCodigo() => DBProCDADicInfo.CampoCodigo;
    public string IPrefixo() => DBProCDADicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBProCDADicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBProCDADicInfo.Processo => DBProCDADicInfo.PcdProcesso,
        DBProCDADicInfo.Nome => DBProCDADicInfo.PcdNome,
        DBProCDADicInfo.NroInterno => DBProCDADicInfo.PcdNroInterno,
        DBProCDADicInfo.Bold => DBProCDADicInfo.PcdBold,
        DBProCDADicInfo.GUID => DBProCDADicInfo.PcdGUID,
        DBProCDADicInfo.QuemCad => DBProCDADicInfo.PcdQuemCad,
        DBProCDADicInfo.DtCad => DBProCDADicInfo.PcdDtCad,
        DBProCDADicInfo.QuemAtu => DBProCDADicInfo.PcdQuemAtu,
        DBProCDADicInfo.DtAtu => DBProCDADicInfo.PcdDtAtu,
        DBProCDADicInfo.Visto => DBProCDADicInfo.PcdVisto,
        _ => null
    };
    public static string TCampoCodigo => DBProCDADicInfo.CampoCodigo;
    public static string TCampoNome => DBProCDADicInfo.CampoNome;
    public static string TTabelaNome => DBProCDADicInfo.TabelaNome;
    public static string TTablePrefix => DBProCDADicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBProCDADicInfo.PcdProcesso, DBProCDADicInfo.PcdNome, DBProCDADicInfo.PcdNroInterno, DBProCDADicInfo.PcdBold, DBProCDADicInfo.PcdGUID, DBProCDADicInfo.PcdQuemCad, DBProCDADicInfo.PcdDtCad, DBProCDADicInfo.PcdQuemAtu, DBProCDADicInfo.PcdDtAtu, DBProCDADicInfo.PcdVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBProCDADicInfo.PcdProcesso, DBProCDADicInfo.PcdNome, DBProCDADicInfo.PcdNroInterno, DBProCDADicInfo.PcdGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "pcdCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBProCDADicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "pcdCodigo",
            "pcdNome",
            "pcdProcesso"
        };
        var result = campos.Where(campo => !campo.Equals(DBProCDADicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
