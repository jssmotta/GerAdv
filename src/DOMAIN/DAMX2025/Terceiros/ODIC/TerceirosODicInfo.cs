#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBTerceirosODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBTerceirosDicInfo.TabelaNome;
    public string ICampoCodigo() => DBTerceirosDicInfo.CampoCodigo;
    public string IPrefixo() => DBTerceirosDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => true;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBTerceirosDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => true;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBTerceirosDicInfo.Processo => DBTerceirosDicInfo.TerProcesso,
        DBTerceirosDicInfo.Nome => DBTerceirosDicInfo.TerNome,
        DBTerceirosDicInfo.Situacao => DBTerceirosDicInfo.TerSituacao,
        DBTerceirosDicInfo.Cidade => DBTerceirosDicInfo.TerCidade,
        DBTerceirosDicInfo.Endereco => DBTerceirosDicInfo.TerEndereco,
        DBTerceirosDicInfo.Bairro => DBTerceirosDicInfo.TerBairro,
        DBTerceirosDicInfo.CEP => DBTerceirosDicInfo.TerCEP,
        DBTerceirosDicInfo.Fone => DBTerceirosDicInfo.TerFone,
        DBTerceirosDicInfo.Fax => DBTerceirosDicInfo.TerFax,
        DBTerceirosDicInfo.OBS => DBTerceirosDicInfo.TerOBS,
        DBTerceirosDicInfo.EMail => DBTerceirosDicInfo.TerEMail,
        DBTerceirosDicInfo.Class => DBTerceirosDicInfo.TerClass,
        DBTerceirosDicInfo.VaraForoComarca => DBTerceirosDicInfo.TerVaraForoComarca,
        DBTerceirosDicInfo.Sexo => DBTerceirosDicInfo.TerSexo,
        DBTerceirosDicInfo.Bold => DBTerceirosDicInfo.TerBold,
        DBTerceirosDicInfo.GUID => DBTerceirosDicInfo.TerGUID,
        DBTerceirosDicInfo.QuemCad => DBTerceirosDicInfo.TerQuemCad,
        DBTerceirosDicInfo.DtCad => DBTerceirosDicInfo.TerDtCad,
        DBTerceirosDicInfo.QuemAtu => DBTerceirosDicInfo.TerQuemAtu,
        DBTerceirosDicInfo.DtAtu => DBTerceirosDicInfo.TerDtAtu,
        DBTerceirosDicInfo.Visto => DBTerceirosDicInfo.TerVisto,
        _ => null
    };
    public static string TCampoCodigo => DBTerceirosDicInfo.CampoCodigo;
    public static string TCampoNome => DBTerceirosDicInfo.CampoNome;
    public static string TTabelaNome => DBTerceirosDicInfo.TabelaNome;
    public static string TTablePrefix => DBTerceirosDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBTerceirosDicInfo.TerProcesso, DBTerceirosDicInfo.TerNome, DBTerceirosDicInfo.TerSituacao, DBTerceirosDicInfo.TerCidade, DBTerceirosDicInfo.TerEndereco, DBTerceirosDicInfo.TerBairro, DBTerceirosDicInfo.TerCEP, DBTerceirosDicInfo.TerFone, DBTerceirosDicInfo.TerFax, DBTerceirosDicInfo.TerOBS, DBTerceirosDicInfo.TerEMail, DBTerceirosDicInfo.TerClass, DBTerceirosDicInfo.TerVaraForoComarca, DBTerceirosDicInfo.TerSexo, DBTerceirosDicInfo.TerBold, DBTerceirosDicInfo.TerGUID, DBTerceirosDicInfo.TerQuemCad, DBTerceirosDicInfo.TerDtCad, DBTerceirosDicInfo.TerQuemAtu, DBTerceirosDicInfo.TerDtAtu, DBTerceirosDicInfo.TerVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBTerceirosDicInfo.TerProcesso, DBTerceirosDicInfo.TerNome, DBTerceirosDicInfo.TerSituacao, DBTerceirosDicInfo.TerCidade, DBTerceirosDicInfo.TerEndereco, DBTerceirosDicInfo.TerBairro, DBTerceirosDicInfo.TerCEP, DBTerceirosDicInfo.TerFone, DBTerceirosDicInfo.TerFax, DBTerceirosDicInfo.TerOBS, DBTerceirosDicInfo.TerEMail, DBTerceirosDicInfo.TerClass, DBTerceirosDicInfo.TerVaraForoComarca, DBTerceirosDicInfo.TerSexo, DBTerceirosDicInfo.TerBold, DBTerceirosDicInfo.TerGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "terCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBTerceirosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "terCodigo",
            "terNome",
            "terProcesso"
        };
        var result = campos.Where(campo => !campo.Equals(DBTerceirosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
