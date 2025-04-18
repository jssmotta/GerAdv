#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBOponentesODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBOponentesDicInfo.TabelaNome;
    public string ICampoCodigo() => DBOponentesDicInfo.CampoCodigo;
    public string IPrefixo() => DBOponentesDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => true;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBOponentesDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => true;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBOponentesDicInfo.EMPFuncao => DBOponentesDicInfo.OpoEMPFuncao,
        DBOponentesDicInfo.CTPSNumero => DBOponentesDicInfo.OpoCTPSNumero,
        DBOponentesDicInfo.Site => DBOponentesDicInfo.OpoSite,
        DBOponentesDicInfo.CTPSSerie => DBOponentesDicInfo.OpoCTPSSerie,
        DBOponentesDicInfo.Nome => DBOponentesDicInfo.OpoNome,
        DBOponentesDicInfo.Adv => DBOponentesDicInfo.OpoAdv,
        DBOponentesDicInfo.EMPCliente => DBOponentesDicInfo.OpoEMPCliente,
        DBOponentesDicInfo.IDRep => DBOponentesDicInfo.OpoIDRep,
        DBOponentesDicInfo.PIS => DBOponentesDicInfo.OpoPIS,
        DBOponentesDicInfo.Contato => DBOponentesDicInfo.OpoContato,
        DBOponentesDicInfo.CNPJ => DBOponentesDicInfo.OpoCNPJ,
        DBOponentesDicInfo.RG => DBOponentesDicInfo.OpoRG,
        DBOponentesDicInfo.Juridica => DBOponentesDicInfo.OpoJuridica,
        DBOponentesDicInfo.Tipo => DBOponentesDicInfo.OpoTipo,
        DBOponentesDicInfo.Sexo => DBOponentesDicInfo.OpoSexo,
        DBOponentesDicInfo.CPF => DBOponentesDicInfo.OpoCPF,
        DBOponentesDicInfo.Endereco => DBOponentesDicInfo.OpoEndereco,
        DBOponentesDicInfo.Fone => DBOponentesDicInfo.OpoFone,
        DBOponentesDicInfo.Fax => DBOponentesDicInfo.OpoFax,
        DBOponentesDicInfo.Cidade => DBOponentesDicInfo.OpoCidade,
        DBOponentesDicInfo.Bairro => DBOponentesDicInfo.OpoBairro,
        DBOponentesDicInfo.CEP => DBOponentesDicInfo.OpoCEP,
        DBOponentesDicInfo.InscEst => DBOponentesDicInfo.OpoInscEst,
        DBOponentesDicInfo.Observacao => DBOponentesDicInfo.OpoObservacao,
        DBOponentesDicInfo.EMail => DBOponentesDicInfo.OpoEMail,
        DBOponentesDicInfo.Class => DBOponentesDicInfo.OpoClass,
        DBOponentesDicInfo.Top => DBOponentesDicInfo.OpoTop,
        DBOponentesDicInfo.Etiqueta => DBOponentesDicInfo.OpoEtiqueta,
        DBOponentesDicInfo.Bold => DBOponentesDicInfo.OpoBold,
        DBOponentesDicInfo.GUID => DBOponentesDicInfo.OpoGUID,
        DBOponentesDicInfo.QuemCad => DBOponentesDicInfo.OpoQuemCad,
        DBOponentesDicInfo.DtCad => DBOponentesDicInfo.OpoDtCad,
        DBOponentesDicInfo.QuemAtu => DBOponentesDicInfo.OpoQuemAtu,
        DBOponentesDicInfo.DtAtu => DBOponentesDicInfo.OpoDtAtu,
        DBOponentesDicInfo.Visto => DBOponentesDicInfo.OpoVisto,
        _ => null
    };
    public static string TCampoCodigo => DBOponentesDicInfo.CampoCodigo;
    public static string TCampoNome => DBOponentesDicInfo.CampoNome;
    public static string TTabelaNome => DBOponentesDicInfo.TabelaNome;
    public static string TTablePrefix => DBOponentesDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBOponentesDicInfo.OpoEMPFuncao, DBOponentesDicInfo.OpoCTPSNumero, DBOponentesDicInfo.OpoSite, DBOponentesDicInfo.OpoCTPSSerie, DBOponentesDicInfo.OpoNome, DBOponentesDicInfo.OpoAdv, DBOponentesDicInfo.OpoEMPCliente, DBOponentesDicInfo.OpoIDRep, DBOponentesDicInfo.OpoPIS, DBOponentesDicInfo.OpoContato, DBOponentesDicInfo.OpoCNPJ, DBOponentesDicInfo.OpoRG, DBOponentesDicInfo.OpoJuridica, DBOponentesDicInfo.OpoTipo, DBOponentesDicInfo.OpoSexo, DBOponentesDicInfo.OpoCPF, DBOponentesDicInfo.OpoEndereco, DBOponentesDicInfo.OpoFone, DBOponentesDicInfo.OpoFax, DBOponentesDicInfo.OpoCidade, DBOponentesDicInfo.OpoBairro, DBOponentesDicInfo.OpoCEP, DBOponentesDicInfo.OpoInscEst, DBOponentesDicInfo.OpoObservacao, DBOponentesDicInfo.OpoEMail, DBOponentesDicInfo.OpoClass, DBOponentesDicInfo.OpoTop, DBOponentesDicInfo.OpoEtiqueta, DBOponentesDicInfo.OpoBold, DBOponentesDicInfo.OpoGUID, DBOponentesDicInfo.OpoQuemCad, DBOponentesDicInfo.OpoDtCad, DBOponentesDicInfo.OpoQuemAtu, DBOponentesDicInfo.OpoDtAtu, DBOponentesDicInfo.OpoVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBOponentesDicInfo.OpoEMPFuncao, DBOponentesDicInfo.OpoCTPSNumero, DBOponentesDicInfo.OpoSite, DBOponentesDicInfo.OpoCTPSSerie, DBOponentesDicInfo.OpoNome, DBOponentesDicInfo.OpoAdv, DBOponentesDicInfo.OpoEMPCliente, DBOponentesDicInfo.OpoIDRep, DBOponentesDicInfo.OpoPIS, DBOponentesDicInfo.OpoContato, DBOponentesDicInfo.OpoCNPJ, DBOponentesDicInfo.OpoRG, DBOponentesDicInfo.OpoJuridica, DBOponentesDicInfo.OpoTipo, DBOponentesDicInfo.OpoSexo, DBOponentesDicInfo.OpoCPF, DBOponentesDicInfo.OpoEndereco, DBOponentesDicInfo.OpoFone, DBOponentesDicInfo.OpoFax, DBOponentesDicInfo.OpoCidade, DBOponentesDicInfo.OpoBairro, DBOponentesDicInfo.OpoCEP, DBOponentesDicInfo.OpoInscEst, DBOponentesDicInfo.OpoObservacao, DBOponentesDicInfo.OpoEMail, DBOponentesDicInfo.OpoClass, DBOponentesDicInfo.OpoTop, DBOponentesDicInfo.OpoEtiqueta, DBOponentesDicInfo.OpoBold];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "opoCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBOponentesDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "opoCodigo",
            "opoNome"
        };
        var result = campos.Where(campo => !campo.Equals(DBOponentesDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
