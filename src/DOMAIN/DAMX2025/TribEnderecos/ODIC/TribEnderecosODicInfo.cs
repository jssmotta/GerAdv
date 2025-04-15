#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBTribEnderecosODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBTribEnderecosDicInfo.TabelaNome;
    public string ICampoCodigo() => DBTribEnderecosDicInfo.CampoCodigo;
    public string IPrefixo() => DBTribEnderecosDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => false;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBTribEnderecosDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => false;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBTribEnderecosDicInfo.Tribunal => DBTribEnderecosDicInfo.TreTribunal,
        DBTribEnderecosDicInfo.Cidade => DBTribEnderecosDicInfo.TreCidade,
        DBTribEnderecosDicInfo.Endereco => DBTribEnderecosDicInfo.TreEndereco,
        DBTribEnderecosDicInfo.CEP => DBTribEnderecosDicInfo.TreCEP,
        DBTribEnderecosDicInfo.Fone => DBTribEnderecosDicInfo.TreFone,
        DBTribEnderecosDicInfo.Fax => DBTribEnderecosDicInfo.TreFax,
        DBTribEnderecosDicInfo.OBS => DBTribEnderecosDicInfo.TreOBS,
        _ => null
    };
    public static string TCampoCodigo => DBTribEnderecosDicInfo.CampoCodigo;
    public static string TCampoNome => DBTribEnderecosDicInfo.CampoNome;
    public static string TTabelaNome => DBTribEnderecosDicInfo.TabelaNome;
    public static string TTablePrefix => DBTribEnderecosDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBTribEnderecosDicInfo.TreTribunal, DBTribEnderecosDicInfo.TreCidade, DBTribEnderecosDicInfo.TreEndereco, DBTribEnderecosDicInfo.TreCEP, DBTribEnderecosDicInfo.TreFone, DBTribEnderecosDicInfo.TreFax, DBTribEnderecosDicInfo.TreOBS];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBTribEnderecosDicInfo.TreTribunal, DBTribEnderecosDicInfo.TreCidade, DBTribEnderecosDicInfo.TreEndereco, DBTribEnderecosDicInfo.TreCEP, DBTribEnderecosDicInfo.TreFone, DBTribEnderecosDicInfo.TreFax, DBTribEnderecosDicInfo.TreOBS];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "treCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBTribEnderecosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "treCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBTribEnderecosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
