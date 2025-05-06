#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBTipoValorProcessoODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBTipoValorProcessoDicInfo.TabelaNome;
    public string ICampoCodigo() => DBTipoValorProcessoDicInfo.CampoCodigo;
    public string IPrefixo() => DBTipoValorProcessoDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => false;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBTipoValorProcessoDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => false;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBTipoValorProcessoDicInfo.Descricao => DBTipoValorProcessoDicInfo.PtvDescricao,
        DBTipoValorProcessoDicInfo.GUID => DBTipoValorProcessoDicInfo.PtvGUID,
        _ => null
    };
    public static string TCampoCodigo => DBTipoValorProcessoDicInfo.CampoCodigo;
    public static string TCampoNome => DBTipoValorProcessoDicInfo.CampoNome;
    public static string TTabelaNome => DBTipoValorProcessoDicInfo.TabelaNome;
    public static string TTablePrefix => DBTipoValorProcessoDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBTipoValorProcessoDicInfo.PtvDescricao, DBTipoValorProcessoDicInfo.PtvGUID];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBTipoValorProcessoDicInfo.PtvDescricao, DBTipoValorProcessoDicInfo.PtvGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "ptvDescricao"
        };
        var result = campos.Where(campo => !campo.Equals(DBTipoValorProcessoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "ptvCodigo",
            "ptvDescricao"
        };
        var result = campos.Where(campo => !campo.Equals(DBTipoValorProcessoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
