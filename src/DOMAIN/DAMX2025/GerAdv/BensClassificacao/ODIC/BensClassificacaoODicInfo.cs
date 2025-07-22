#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBBensClassificacaoODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBBensClassificacaoDicInfo.TabelaNome;
    public string ICampoCodigo() => DBBensClassificacaoDicInfo.CampoCodigo;
    public string IPrefixo() => DBBensClassificacaoDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBBensClassificacaoDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBBensClassificacaoDicInfo.Nome => DBBensClassificacaoDicInfo.BcsNome,
        DBBensClassificacaoDicInfo.Bold => DBBensClassificacaoDicInfo.BcsBold,
        DBBensClassificacaoDicInfo.GUID => DBBensClassificacaoDicInfo.BcsGUID,
        DBBensClassificacaoDicInfo.QuemCad => DBBensClassificacaoDicInfo.BcsQuemCad,
        DBBensClassificacaoDicInfo.DtCad => DBBensClassificacaoDicInfo.BcsDtCad,
        DBBensClassificacaoDicInfo.QuemAtu => DBBensClassificacaoDicInfo.BcsQuemAtu,
        DBBensClassificacaoDicInfo.DtAtu => DBBensClassificacaoDicInfo.BcsDtAtu,
        DBBensClassificacaoDicInfo.Visto => DBBensClassificacaoDicInfo.BcsVisto,
        _ => null
    };
    public static string TCampoCodigo => DBBensClassificacaoDicInfo.CampoCodigo;
    public static string TCampoNome => DBBensClassificacaoDicInfo.CampoNome;
    public static string TTabelaNome => DBBensClassificacaoDicInfo.TabelaNome;
    public static string TTablePrefix => DBBensClassificacaoDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBBensClassificacaoDicInfo.BcsNome, DBBensClassificacaoDicInfo.BcsBold, DBBensClassificacaoDicInfo.BcsGUID, DBBensClassificacaoDicInfo.BcsQuemCad, DBBensClassificacaoDicInfo.BcsDtCad, DBBensClassificacaoDicInfo.BcsQuemAtu, DBBensClassificacaoDicInfo.BcsDtAtu, DBBensClassificacaoDicInfo.BcsVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBBensClassificacaoDicInfo.BcsNome, DBBensClassificacaoDicInfo.BcsGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "bcsCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBBensClassificacaoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "bcsCodigo",
            "bcsNome"
        };
        var result = campos.Where(campo => !campo.Equals(DBBensClassificacaoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
