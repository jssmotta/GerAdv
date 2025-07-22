#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBApensoODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBApensoDicInfo.TabelaNome;
    public string ICampoCodigo() => DBApensoDicInfo.CampoCodigo;
    public string IPrefixo() => DBApensoDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBApensoDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBApensoDicInfo.Processo => DBApensoDicInfo.ApeProcesso,
        DBApensoDicInfo.Apenso => DBApensoDicInfo.ApeApenso,
        DBApensoDicInfo.Acao => DBApensoDicInfo.ApeAcao,
        DBApensoDicInfo.DtDist => DBApensoDicInfo.ApeDtDist,
        DBApensoDicInfo.OBS => DBApensoDicInfo.ApeOBS,
        DBApensoDicInfo.ValorCausa => DBApensoDicInfo.ApeValorCausa,
        DBApensoDicInfo.QuemCad => DBApensoDicInfo.ApeQuemCad,
        DBApensoDicInfo.DtCad => DBApensoDicInfo.ApeDtCad,
        DBApensoDicInfo.QuemAtu => DBApensoDicInfo.ApeQuemAtu,
        DBApensoDicInfo.DtAtu => DBApensoDicInfo.ApeDtAtu,
        DBApensoDicInfo.Visto => DBApensoDicInfo.ApeVisto,
        _ => null
    };
    public static string TCampoCodigo => DBApensoDicInfo.CampoCodigo;
    public static string TCampoNome => DBApensoDicInfo.CampoNome;
    public static string TTabelaNome => DBApensoDicInfo.TabelaNome;
    public static string TTablePrefix => DBApensoDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBApensoDicInfo.ApeProcesso, DBApensoDicInfo.ApeApenso, DBApensoDicInfo.ApeAcao, DBApensoDicInfo.ApeDtDist, DBApensoDicInfo.ApeOBS, DBApensoDicInfo.ApeValorCausa, DBApensoDicInfo.ApeQuemCad, DBApensoDicInfo.ApeDtCad, DBApensoDicInfo.ApeQuemAtu, DBApensoDicInfo.ApeDtAtu, DBApensoDicInfo.ApeVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBApensoDicInfo.ApeProcesso, DBApensoDicInfo.ApeApenso, DBApensoDicInfo.ApeAcao, DBApensoDicInfo.ApeDtDist, DBApensoDicInfo.ApeOBS, DBApensoDicInfo.ApeValorCausa];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "apeCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBApensoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "apeCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBApensoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
