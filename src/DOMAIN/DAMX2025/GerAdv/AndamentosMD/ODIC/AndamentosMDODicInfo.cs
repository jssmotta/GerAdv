#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBAndamentosMDODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBAndamentosMDDicInfo.TabelaNome;
    public string ICampoCodigo() => DBAndamentosMDDicInfo.CampoCodigo;
    public string IPrefixo() => DBAndamentosMDDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBAndamentosMDDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBAndamentosMDDicInfo.Nome => DBAndamentosMDDicInfo.AmdNome,
        DBAndamentosMDDicInfo.Processo => DBAndamentosMDDicInfo.AmdProcesso,
        DBAndamentosMDDicInfo.Andamento => DBAndamentosMDDicInfo.AmdAndamento,
        DBAndamentosMDDicInfo.PathFull => DBAndamentosMDDicInfo.AmdPathFull,
        DBAndamentosMDDicInfo.UNC => DBAndamentosMDDicInfo.AmdUNC,
        DBAndamentosMDDicInfo.GUID => DBAndamentosMDDicInfo.AmdGUID,
        DBAndamentosMDDicInfo.QuemCad => DBAndamentosMDDicInfo.AmdQuemCad,
        DBAndamentosMDDicInfo.DtCad => DBAndamentosMDDicInfo.AmdDtCad,
        DBAndamentosMDDicInfo.QuemAtu => DBAndamentosMDDicInfo.AmdQuemAtu,
        DBAndamentosMDDicInfo.DtAtu => DBAndamentosMDDicInfo.AmdDtAtu,
        DBAndamentosMDDicInfo.Visto => DBAndamentosMDDicInfo.AmdVisto,
        _ => null
    };
    public static string TCampoCodigo => DBAndamentosMDDicInfo.CampoCodigo;
    public static string TCampoNome => DBAndamentosMDDicInfo.CampoNome;
    public static string TTabelaNome => DBAndamentosMDDicInfo.TabelaNome;
    public static string TTablePrefix => DBAndamentosMDDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBAndamentosMDDicInfo.AmdNome, DBAndamentosMDDicInfo.AmdProcesso, DBAndamentosMDDicInfo.AmdAndamento, DBAndamentosMDDicInfo.AmdPathFull, DBAndamentosMDDicInfo.AmdUNC, DBAndamentosMDDicInfo.AmdGUID, DBAndamentosMDDicInfo.AmdQuemCad, DBAndamentosMDDicInfo.AmdDtCad, DBAndamentosMDDicInfo.AmdQuemAtu, DBAndamentosMDDicInfo.AmdDtAtu, DBAndamentosMDDicInfo.AmdVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBAndamentosMDDicInfo.AmdNome, DBAndamentosMDDicInfo.AmdProcesso, DBAndamentosMDDicInfo.AmdAndamento, DBAndamentosMDDicInfo.AmdPathFull, DBAndamentosMDDicInfo.AmdUNC, DBAndamentosMDDicInfo.AmdGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "amdCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBAndamentosMDDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "amdCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBAndamentosMDDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
