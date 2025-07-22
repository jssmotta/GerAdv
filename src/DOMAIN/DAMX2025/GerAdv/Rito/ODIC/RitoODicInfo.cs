#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBRitoODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBRitoDicInfo.TabelaNome;
    public string ICampoCodigo() => DBRitoDicInfo.CampoCodigo;
    public string IPrefixo() => DBRitoDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBRitoDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBRitoDicInfo.Descricao => DBRitoDicInfo.RitDescricao,
        DBRitoDicInfo.Top => DBRitoDicInfo.RitTop,
        DBRitoDicInfo.Bold => DBRitoDicInfo.RitBold,
        DBRitoDicInfo.GUID => DBRitoDicInfo.RitGUID,
        DBRitoDicInfo.QuemCad => DBRitoDicInfo.RitQuemCad,
        DBRitoDicInfo.DtCad => DBRitoDicInfo.RitDtCad,
        DBRitoDicInfo.QuemAtu => DBRitoDicInfo.RitQuemAtu,
        DBRitoDicInfo.DtAtu => DBRitoDicInfo.RitDtAtu,
        DBRitoDicInfo.Visto => DBRitoDicInfo.RitVisto,
        _ => null
    };
    public static string TCampoCodigo => DBRitoDicInfo.CampoCodigo;
    public static string TCampoNome => DBRitoDicInfo.CampoNome;
    public static string TTabelaNome => DBRitoDicInfo.TabelaNome;
    public static string TTablePrefix => DBRitoDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBRitoDicInfo.RitDescricao, DBRitoDicInfo.RitTop, DBRitoDicInfo.RitBold, DBRitoDicInfo.RitGUID, DBRitoDicInfo.RitQuemCad, DBRitoDicInfo.RitDtCad, DBRitoDicInfo.RitQuemAtu, DBRitoDicInfo.RitDtAtu, DBRitoDicInfo.RitVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBRitoDicInfo.RitDescricao, DBRitoDicInfo.RitTop, DBRitoDicInfo.RitGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "ritCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBRitoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "ritCodigo",
            "ritDescricao"
        };
        var result = campos.Where(campo => !campo.Equals(DBRitoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
