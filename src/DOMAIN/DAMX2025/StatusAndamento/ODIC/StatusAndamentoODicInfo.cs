#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBStatusAndamentoODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBStatusAndamentoDicInfo.TabelaNome;
    public string ICampoCodigo() => DBStatusAndamentoDicInfo.CampoCodigo;
    public string IPrefixo() => DBStatusAndamentoDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBStatusAndamentoDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBStatusAndamentoDicInfo.Nome => DBStatusAndamentoDicInfo.SanNome,
        DBStatusAndamentoDicInfo.Icone => DBStatusAndamentoDicInfo.SanIcone,
        DBStatusAndamentoDicInfo.Bold => DBStatusAndamentoDicInfo.SanBold,
        DBStatusAndamentoDicInfo.GUID => DBStatusAndamentoDicInfo.SanGUID,
        DBStatusAndamentoDicInfo.QuemCad => DBStatusAndamentoDicInfo.SanQuemCad,
        DBStatusAndamentoDicInfo.DtCad => DBStatusAndamentoDicInfo.SanDtCad,
        DBStatusAndamentoDicInfo.QuemAtu => DBStatusAndamentoDicInfo.SanQuemAtu,
        DBStatusAndamentoDicInfo.DtAtu => DBStatusAndamentoDicInfo.SanDtAtu,
        DBStatusAndamentoDicInfo.Visto => DBStatusAndamentoDicInfo.SanVisto,
        _ => null
    };
    public static string TCampoCodigo => DBStatusAndamentoDicInfo.CampoCodigo;
    public static string TCampoNome => DBStatusAndamentoDicInfo.CampoNome;
    public static string TTabelaNome => DBStatusAndamentoDicInfo.TabelaNome;
    public static string TTablePrefix => DBStatusAndamentoDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBStatusAndamentoDicInfo.SanNome, DBStatusAndamentoDicInfo.SanIcone, DBStatusAndamentoDicInfo.SanBold, DBStatusAndamentoDicInfo.SanGUID, DBStatusAndamentoDicInfo.SanQuemCad, DBStatusAndamentoDicInfo.SanDtCad, DBStatusAndamentoDicInfo.SanQuemAtu, DBStatusAndamentoDicInfo.SanDtAtu, DBStatusAndamentoDicInfo.SanVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBStatusAndamentoDicInfo.SanNome, DBStatusAndamentoDicInfo.SanIcone, DBStatusAndamentoDicInfo.SanBold];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "sanCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBStatusAndamentoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "sanCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBStatusAndamentoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
