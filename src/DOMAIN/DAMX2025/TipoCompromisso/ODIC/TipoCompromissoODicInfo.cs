#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBTipoCompromissoODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBTipoCompromissoDicInfo.TabelaNome;
    public string ICampoCodigo() => DBTipoCompromissoDicInfo.CampoCodigo;
    public string IPrefixo() => DBTipoCompromissoDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBTipoCompromissoDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBTipoCompromissoDicInfo.Icone => DBTipoCompromissoDicInfo.TipIcone,
        DBTipoCompromissoDicInfo.Descricao => DBTipoCompromissoDicInfo.TipDescricao,
        DBTipoCompromissoDicInfo.Financeiro => DBTipoCompromissoDicInfo.TipFinanceiro,
        DBTipoCompromissoDicInfo.Bold => DBTipoCompromissoDicInfo.TipBold,
        DBTipoCompromissoDicInfo.GUID => DBTipoCompromissoDicInfo.TipGUID,
        DBTipoCompromissoDicInfo.QuemCad => DBTipoCompromissoDicInfo.TipQuemCad,
        DBTipoCompromissoDicInfo.DtCad => DBTipoCompromissoDicInfo.TipDtCad,
        DBTipoCompromissoDicInfo.QuemAtu => DBTipoCompromissoDicInfo.TipQuemAtu,
        DBTipoCompromissoDicInfo.DtAtu => DBTipoCompromissoDicInfo.TipDtAtu,
        DBTipoCompromissoDicInfo.Visto => DBTipoCompromissoDicInfo.TipVisto,
        _ => null
    };
    public static string TCampoCodigo => DBTipoCompromissoDicInfo.CampoCodigo;
    public static string TCampoNome => DBTipoCompromissoDicInfo.CampoNome;
    public static string TTabelaNome => DBTipoCompromissoDicInfo.TabelaNome;
    public static string TTablePrefix => DBTipoCompromissoDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBTipoCompromissoDicInfo.TipIcone, DBTipoCompromissoDicInfo.TipDescricao, DBTipoCompromissoDicInfo.TipFinanceiro, DBTipoCompromissoDicInfo.TipBold, DBTipoCompromissoDicInfo.TipGUID, DBTipoCompromissoDicInfo.TipQuemCad, DBTipoCompromissoDicInfo.TipDtCad, DBTipoCompromissoDicInfo.TipQuemAtu, DBTipoCompromissoDicInfo.TipDtAtu, DBTipoCompromissoDicInfo.TipVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBTipoCompromissoDicInfo.TipIcone, DBTipoCompromissoDicInfo.TipDescricao, DBTipoCompromissoDicInfo.TipFinanceiro, DBTipoCompromissoDicInfo.TipBold];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "tipCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBTipoCompromissoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "tipCodigo",
            "tipDescricao"
        };
        var result = campos.Where(campo => !campo.Equals(DBTipoCompromissoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
