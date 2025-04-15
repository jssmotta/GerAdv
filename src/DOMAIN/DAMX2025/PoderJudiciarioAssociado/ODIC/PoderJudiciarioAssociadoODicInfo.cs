#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBPoderJudiciarioAssociadoODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBPoderJudiciarioAssociadoDicInfo.TabelaNome;
    public string ICampoCodigo() => DBPoderJudiciarioAssociadoDicInfo.CampoCodigo;
    public string IPrefixo() => DBPoderJudiciarioAssociadoDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBPoderJudiciarioAssociadoDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBPoderJudiciarioAssociadoDicInfo.Justica => DBPoderJudiciarioAssociadoDicInfo.PjaJustica,
        DBPoderJudiciarioAssociadoDicInfo.JusticaNome => DBPoderJudiciarioAssociadoDicInfo.PjaJusticaNome,
        DBPoderJudiciarioAssociadoDicInfo.Area => DBPoderJudiciarioAssociadoDicInfo.PjaArea,
        DBPoderJudiciarioAssociadoDicInfo.AreaNome => DBPoderJudiciarioAssociadoDicInfo.PjaAreaNome,
        DBPoderJudiciarioAssociadoDicInfo.Tribunal => DBPoderJudiciarioAssociadoDicInfo.PjaTribunal,
        DBPoderJudiciarioAssociadoDicInfo.TribunalNome => DBPoderJudiciarioAssociadoDicInfo.PjaTribunalNome,
        DBPoderJudiciarioAssociadoDicInfo.Foro => DBPoderJudiciarioAssociadoDicInfo.PjaForo,
        DBPoderJudiciarioAssociadoDicInfo.ForoNome => DBPoderJudiciarioAssociadoDicInfo.PjaForoNome,
        DBPoderJudiciarioAssociadoDicInfo.Cidade => DBPoderJudiciarioAssociadoDicInfo.PjaCidade,
        DBPoderJudiciarioAssociadoDicInfo.SubDivisaoNome => DBPoderJudiciarioAssociadoDicInfo.PjaSubDivisaoNome,
        DBPoderJudiciarioAssociadoDicInfo.CidadeNome => DBPoderJudiciarioAssociadoDicInfo.PjaCidadeNome,
        DBPoderJudiciarioAssociadoDicInfo.SubDivisao => DBPoderJudiciarioAssociadoDicInfo.PjaSubDivisao,
        DBPoderJudiciarioAssociadoDicInfo.Tipo => DBPoderJudiciarioAssociadoDicInfo.PjaTipo,
        DBPoderJudiciarioAssociadoDicInfo.GUID => DBPoderJudiciarioAssociadoDicInfo.PjaGUID,
        DBPoderJudiciarioAssociadoDicInfo.QuemCad => DBPoderJudiciarioAssociadoDicInfo.PjaQuemCad,
        DBPoderJudiciarioAssociadoDicInfo.DtCad => DBPoderJudiciarioAssociadoDicInfo.PjaDtCad,
        DBPoderJudiciarioAssociadoDicInfo.QuemAtu => DBPoderJudiciarioAssociadoDicInfo.PjaQuemAtu,
        DBPoderJudiciarioAssociadoDicInfo.DtAtu => DBPoderJudiciarioAssociadoDicInfo.PjaDtAtu,
        DBPoderJudiciarioAssociadoDicInfo.Visto => DBPoderJudiciarioAssociadoDicInfo.PjaVisto,
        _ => null
    };
    public static string TCampoCodigo => DBPoderJudiciarioAssociadoDicInfo.CampoCodigo;
    public static string TCampoNome => DBPoderJudiciarioAssociadoDicInfo.CampoNome;
    public static string TTabelaNome => DBPoderJudiciarioAssociadoDicInfo.TabelaNome;
    public static string TTablePrefix => DBPoderJudiciarioAssociadoDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBPoderJudiciarioAssociadoDicInfo.PjaJustica, DBPoderJudiciarioAssociadoDicInfo.PjaJusticaNome, DBPoderJudiciarioAssociadoDicInfo.PjaArea, DBPoderJudiciarioAssociadoDicInfo.PjaAreaNome, DBPoderJudiciarioAssociadoDicInfo.PjaTribunal, DBPoderJudiciarioAssociadoDicInfo.PjaTribunalNome, DBPoderJudiciarioAssociadoDicInfo.PjaForo, DBPoderJudiciarioAssociadoDicInfo.PjaForoNome, DBPoderJudiciarioAssociadoDicInfo.PjaCidade, DBPoderJudiciarioAssociadoDicInfo.PjaSubDivisaoNome, DBPoderJudiciarioAssociadoDicInfo.PjaCidadeNome, DBPoderJudiciarioAssociadoDicInfo.PjaSubDivisao, DBPoderJudiciarioAssociadoDicInfo.PjaTipo, DBPoderJudiciarioAssociadoDicInfo.PjaGUID, DBPoderJudiciarioAssociadoDicInfo.PjaQuemCad, DBPoderJudiciarioAssociadoDicInfo.PjaDtCad, DBPoderJudiciarioAssociadoDicInfo.PjaQuemAtu, DBPoderJudiciarioAssociadoDicInfo.PjaDtAtu, DBPoderJudiciarioAssociadoDicInfo.PjaVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBPoderJudiciarioAssociadoDicInfo.PjaJustica, DBPoderJudiciarioAssociadoDicInfo.PjaJusticaNome, DBPoderJudiciarioAssociadoDicInfo.PjaArea, DBPoderJudiciarioAssociadoDicInfo.PjaAreaNome, DBPoderJudiciarioAssociadoDicInfo.PjaTribunal, DBPoderJudiciarioAssociadoDicInfo.PjaTribunalNome, DBPoderJudiciarioAssociadoDicInfo.PjaForo, DBPoderJudiciarioAssociadoDicInfo.PjaForoNome, DBPoderJudiciarioAssociadoDicInfo.PjaCidade, DBPoderJudiciarioAssociadoDicInfo.PjaSubDivisaoNome, DBPoderJudiciarioAssociadoDicInfo.PjaCidadeNome, DBPoderJudiciarioAssociadoDicInfo.PjaSubDivisao, DBPoderJudiciarioAssociadoDicInfo.PjaTipo];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "pjaCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBPoderJudiciarioAssociadoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "pjaArea",
            "pjaCodigo",
            "pjaForo",
            "pjaGUID",
            "pjaJustica",
            "pjaSubDivisao",
            "pjaTribunal"
        };
        var result = campos.Where(campo => !campo.Equals(DBPoderJudiciarioAssociadoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
