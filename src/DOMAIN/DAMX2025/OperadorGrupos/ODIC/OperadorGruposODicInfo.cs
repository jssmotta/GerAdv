#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBOperadorGruposODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBOperadorGruposDicInfo.TabelaNome;
    public string ICampoCodigo() => DBOperadorGruposDicInfo.CampoCodigo;
    public string IPrefixo() => DBOperadorGruposDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBOperadorGruposDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBOperadorGruposDicInfo.Nome => DBOperadorGruposDicInfo.OpgNome,
        DBOperadorGruposDicInfo.QuemCad => DBOperadorGruposDicInfo.OpgQuemCad,
        DBOperadorGruposDicInfo.DtCad => DBOperadorGruposDicInfo.OpgDtCad,
        DBOperadorGruposDicInfo.QuemAtu => DBOperadorGruposDicInfo.OpgQuemAtu,
        DBOperadorGruposDicInfo.DtAtu => DBOperadorGruposDicInfo.OpgDtAtu,
        DBOperadorGruposDicInfo.Visto => DBOperadorGruposDicInfo.OpgVisto,
        _ => null
    };
    public static string TCampoCodigo => DBOperadorGruposDicInfo.CampoCodigo;
    public static string TCampoNome => DBOperadorGruposDicInfo.CampoNome;
    public static string TTabelaNome => DBOperadorGruposDicInfo.TabelaNome;
    public static string TTablePrefix => DBOperadorGruposDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBOperadorGruposDicInfo.OpgNome, DBOperadorGruposDicInfo.OpgQuemCad, DBOperadorGruposDicInfo.OpgDtCad, DBOperadorGruposDicInfo.OpgQuemAtu, DBOperadorGruposDicInfo.OpgDtAtu, DBOperadorGruposDicInfo.OpgVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBOperadorGruposDicInfo.OpgNome];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "opgCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBOperadorGruposDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "opgCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBOperadorGruposDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
