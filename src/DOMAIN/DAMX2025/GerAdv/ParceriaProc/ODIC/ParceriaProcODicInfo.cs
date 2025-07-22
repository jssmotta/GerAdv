#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBParceriaProcODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBParceriaProcDicInfo.TabelaNome;
    public string ICampoCodigo() => DBParceriaProcDicInfo.CampoCodigo;
    public string IPrefixo() => DBParceriaProcDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBParceriaProcDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBParceriaProcDicInfo.Advogado => DBParceriaProcDicInfo.ParAdvogado,
        DBParceriaProcDicInfo.Processo => DBParceriaProcDicInfo.ParProcesso,
        DBParceriaProcDicInfo.GUID => DBParceriaProcDicInfo.ParGUID,
        DBParceriaProcDicInfo.QuemCad => DBParceriaProcDicInfo.ParQuemCad,
        DBParceriaProcDicInfo.DtCad => DBParceriaProcDicInfo.ParDtCad,
        DBParceriaProcDicInfo.QuemAtu => DBParceriaProcDicInfo.ParQuemAtu,
        DBParceriaProcDicInfo.DtAtu => DBParceriaProcDicInfo.ParDtAtu,
        DBParceriaProcDicInfo.Visto => DBParceriaProcDicInfo.ParVisto,
        _ => null
    };
    public static string TCampoCodigo => DBParceriaProcDicInfo.CampoCodigo;
    public static string TCampoNome => DBParceriaProcDicInfo.CampoNome;
    public static string TTabelaNome => DBParceriaProcDicInfo.TabelaNome;
    public static string TTablePrefix => DBParceriaProcDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBParceriaProcDicInfo.ParAdvogado, DBParceriaProcDicInfo.ParProcesso, DBParceriaProcDicInfo.ParGUID, DBParceriaProcDicInfo.ParQuemCad, DBParceriaProcDicInfo.ParDtCad, DBParceriaProcDicInfo.ParQuemAtu, DBParceriaProcDicInfo.ParDtAtu, DBParceriaProcDicInfo.ParVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBParceriaProcDicInfo.ParAdvogado, DBParceriaProcDicInfo.ParProcesso, DBParceriaProcDicInfo.ParGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "parCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBParceriaProcDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "parCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBParceriaProcDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
