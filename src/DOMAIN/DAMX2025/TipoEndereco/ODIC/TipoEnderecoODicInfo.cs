#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBTipoEnderecoODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBTipoEnderecoDicInfo.TabelaNome;
    public string ICampoCodigo() => DBTipoEnderecoDicInfo.CampoCodigo;
    public string IPrefixo() => DBTipoEnderecoDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBTipoEnderecoDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBTipoEnderecoDicInfo.Descricao => DBTipoEnderecoDicInfo.TipDescricao,
        DBTipoEnderecoDicInfo.GUID => DBTipoEnderecoDicInfo.TipGUID,
        DBTipoEnderecoDicInfo.QuemCad => DBTipoEnderecoDicInfo.TipQuemCad,
        DBTipoEnderecoDicInfo.DtCad => DBTipoEnderecoDicInfo.TipDtCad,
        DBTipoEnderecoDicInfo.QuemAtu => DBTipoEnderecoDicInfo.TipQuemAtu,
        DBTipoEnderecoDicInfo.DtAtu => DBTipoEnderecoDicInfo.TipDtAtu,
        DBTipoEnderecoDicInfo.Visto => DBTipoEnderecoDicInfo.TipVisto,
        _ => null
    };
    public static string TCampoCodigo => DBTipoEnderecoDicInfo.CampoCodigo;
    public static string TCampoNome => DBTipoEnderecoDicInfo.CampoNome;
    public static string TTabelaNome => DBTipoEnderecoDicInfo.TabelaNome;
    public static string TTablePrefix => DBTipoEnderecoDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBTipoEnderecoDicInfo.TipDescricao, DBTipoEnderecoDicInfo.TipGUID, DBTipoEnderecoDicInfo.TipQuemCad, DBTipoEnderecoDicInfo.TipDtCad, DBTipoEnderecoDicInfo.TipQuemAtu, DBTipoEnderecoDicInfo.TipDtAtu, DBTipoEnderecoDicInfo.TipVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBTipoEnderecoDicInfo.TipDescricao];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "tipCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBTipoEnderecoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "tipCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBTipoEnderecoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
