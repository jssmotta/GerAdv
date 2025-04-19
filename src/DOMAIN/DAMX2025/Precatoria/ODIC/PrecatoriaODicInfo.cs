#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBPrecatoriaODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBPrecatoriaDicInfo.TabelaNome;
    public string ICampoCodigo() => DBPrecatoriaDicInfo.CampoCodigo;
    public string IPrefixo() => DBPrecatoriaDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBPrecatoriaDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBPrecatoriaDicInfo.DtDist => DBPrecatoriaDicInfo.PreDtDist,
        DBPrecatoriaDicInfo.Processo => DBPrecatoriaDicInfo.PreProcesso,
        DBPrecatoriaDicInfo.Precatoria => DBPrecatoriaDicInfo.PrePrecatoria,
        DBPrecatoriaDicInfo.Deprecante => DBPrecatoriaDicInfo.PreDeprecante,
        DBPrecatoriaDicInfo.Deprecado => DBPrecatoriaDicInfo.PreDeprecado,
        DBPrecatoriaDicInfo.OBS => DBPrecatoriaDicInfo.PreOBS,
        DBPrecatoriaDicInfo.Bold => DBPrecatoriaDicInfo.PreBold,
        DBPrecatoriaDicInfo.GUID => DBPrecatoriaDicInfo.PreGUID,
        DBPrecatoriaDicInfo.QuemCad => DBPrecatoriaDicInfo.PreQuemCad,
        DBPrecatoriaDicInfo.DtCad => DBPrecatoriaDicInfo.PreDtCad,
        DBPrecatoriaDicInfo.QuemAtu => DBPrecatoriaDicInfo.PreQuemAtu,
        DBPrecatoriaDicInfo.DtAtu => DBPrecatoriaDicInfo.PreDtAtu,
        DBPrecatoriaDicInfo.Visto => DBPrecatoriaDicInfo.PreVisto,
        _ => null
    };
    public static string TCampoCodigo => DBPrecatoriaDicInfo.CampoCodigo;
    public static string TCampoNome => DBPrecatoriaDicInfo.CampoNome;
    public static string TTabelaNome => DBPrecatoriaDicInfo.TabelaNome;
    public static string TTablePrefix => DBPrecatoriaDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBPrecatoriaDicInfo.PreDtDist, DBPrecatoriaDicInfo.PreProcesso, DBPrecatoriaDicInfo.PrePrecatoria, DBPrecatoriaDicInfo.PreDeprecante, DBPrecatoriaDicInfo.PreDeprecado, DBPrecatoriaDicInfo.PreOBS, DBPrecatoriaDicInfo.PreBold, DBPrecatoriaDicInfo.PreGUID, DBPrecatoriaDicInfo.PreQuemCad, DBPrecatoriaDicInfo.PreDtCad, DBPrecatoriaDicInfo.PreQuemAtu, DBPrecatoriaDicInfo.PreDtAtu, DBPrecatoriaDicInfo.PreVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBPrecatoriaDicInfo.PreDtDist, DBPrecatoriaDicInfo.PreProcesso, DBPrecatoriaDicInfo.PrePrecatoria, DBPrecatoriaDicInfo.PreDeprecante, DBPrecatoriaDicInfo.PreDeprecado, DBPrecatoriaDicInfo.PreOBS, DBPrecatoriaDicInfo.PreBold, DBPrecatoriaDicInfo.PreGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "preCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBPrecatoriaDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "preCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBPrecatoriaDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
