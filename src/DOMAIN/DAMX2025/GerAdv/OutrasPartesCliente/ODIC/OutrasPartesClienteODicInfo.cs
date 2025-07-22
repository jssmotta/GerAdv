#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBOutrasPartesClienteODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBOutrasPartesClienteDicInfo.TabelaNome;
    public string ICampoCodigo() => DBOutrasPartesClienteDicInfo.CampoCodigo;
    public string IPrefixo() => DBOutrasPartesClienteDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => true;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBOutrasPartesClienteDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => true;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBOutrasPartesClienteDicInfo.Nome => DBOutrasPartesClienteDicInfo.OpcNome,
        DBOutrasPartesClienteDicInfo.Terceirizado => DBOutrasPartesClienteDicInfo.OpcTerceirizado,
        DBOutrasPartesClienteDicInfo.ClientePrincipal => DBOutrasPartesClienteDicInfo.OpcClientePrincipal,
        DBOutrasPartesClienteDicInfo.Tipo => DBOutrasPartesClienteDicInfo.OpcTipo,
        DBOutrasPartesClienteDicInfo.Sexo => DBOutrasPartesClienteDicInfo.OpcSexo,
        DBOutrasPartesClienteDicInfo.DtNasc => DBOutrasPartesClienteDicInfo.OpcDtNasc,
        DBOutrasPartesClienteDicInfo.CPF => DBOutrasPartesClienteDicInfo.OpcCPF,
        DBOutrasPartesClienteDicInfo.RG => DBOutrasPartesClienteDicInfo.OpcRG,
        DBOutrasPartesClienteDicInfo.CNPJ => DBOutrasPartesClienteDicInfo.OpcCNPJ,
        DBOutrasPartesClienteDicInfo.InscEst => DBOutrasPartesClienteDicInfo.OpcInscEst,
        DBOutrasPartesClienteDicInfo.NomeFantasia => DBOutrasPartesClienteDicInfo.OpcNomeFantasia,
        DBOutrasPartesClienteDicInfo.Endereco => DBOutrasPartesClienteDicInfo.OpcEndereco,
        DBOutrasPartesClienteDicInfo.Cidade => DBOutrasPartesClienteDicInfo.OpcCidade,
        DBOutrasPartesClienteDicInfo.CEP => DBOutrasPartesClienteDicInfo.OpcCEP,
        DBOutrasPartesClienteDicInfo.Bairro => DBOutrasPartesClienteDicInfo.OpcBairro,
        DBOutrasPartesClienteDicInfo.Fone => DBOutrasPartesClienteDicInfo.OpcFone,
        DBOutrasPartesClienteDicInfo.Fax => DBOutrasPartesClienteDicInfo.OpcFax,
        DBOutrasPartesClienteDicInfo.EMail => DBOutrasPartesClienteDicInfo.OpcEMail,
        DBOutrasPartesClienteDicInfo.Site => DBOutrasPartesClienteDicInfo.OpcSite,
        DBOutrasPartesClienteDicInfo.Class => DBOutrasPartesClienteDicInfo.OpcClass,
        DBOutrasPartesClienteDicInfo.Etiqueta => DBOutrasPartesClienteDicInfo.OpcEtiqueta,
        DBOutrasPartesClienteDicInfo.Ani => DBOutrasPartesClienteDicInfo.OpcAni,
        DBOutrasPartesClienteDicInfo.Bold => DBOutrasPartesClienteDicInfo.OpcBold,
        DBOutrasPartesClienteDicInfo.GUID => DBOutrasPartesClienteDicInfo.OpcGUID,
        DBOutrasPartesClienteDicInfo.QuemCad => DBOutrasPartesClienteDicInfo.OpcQuemCad,
        DBOutrasPartesClienteDicInfo.DtCad => DBOutrasPartesClienteDicInfo.OpcDtCad,
        DBOutrasPartesClienteDicInfo.QuemAtu => DBOutrasPartesClienteDicInfo.OpcQuemAtu,
        DBOutrasPartesClienteDicInfo.DtAtu => DBOutrasPartesClienteDicInfo.OpcDtAtu,
        DBOutrasPartesClienteDicInfo.Visto => DBOutrasPartesClienteDicInfo.OpcVisto,
        _ => null
    };
    public static string TCampoCodigo => DBOutrasPartesClienteDicInfo.CampoCodigo;
    public static string TCampoNome => DBOutrasPartesClienteDicInfo.CampoNome;
    public static string TTabelaNome => DBOutrasPartesClienteDicInfo.TabelaNome;
    public static string TTablePrefix => DBOutrasPartesClienteDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBOutrasPartesClienteDicInfo.OpcNome, DBOutrasPartesClienteDicInfo.OpcTerceirizado, DBOutrasPartesClienteDicInfo.OpcClientePrincipal, DBOutrasPartesClienteDicInfo.OpcTipo, DBOutrasPartesClienteDicInfo.OpcSexo, DBOutrasPartesClienteDicInfo.OpcDtNasc, DBOutrasPartesClienteDicInfo.OpcCPF, DBOutrasPartesClienteDicInfo.OpcRG, DBOutrasPartesClienteDicInfo.OpcCNPJ, DBOutrasPartesClienteDicInfo.OpcInscEst, DBOutrasPartesClienteDicInfo.OpcNomeFantasia, DBOutrasPartesClienteDicInfo.OpcEndereco, DBOutrasPartesClienteDicInfo.OpcCidade, DBOutrasPartesClienteDicInfo.OpcCEP, DBOutrasPartesClienteDicInfo.OpcBairro, DBOutrasPartesClienteDicInfo.OpcFone, DBOutrasPartesClienteDicInfo.OpcFax, DBOutrasPartesClienteDicInfo.OpcEMail, DBOutrasPartesClienteDicInfo.OpcSite, DBOutrasPartesClienteDicInfo.OpcClass, DBOutrasPartesClienteDicInfo.OpcEtiqueta, DBOutrasPartesClienteDicInfo.OpcAni, DBOutrasPartesClienteDicInfo.OpcBold, DBOutrasPartesClienteDicInfo.OpcGUID, DBOutrasPartesClienteDicInfo.OpcQuemCad, DBOutrasPartesClienteDicInfo.OpcDtCad, DBOutrasPartesClienteDicInfo.OpcQuemAtu, DBOutrasPartesClienteDicInfo.OpcDtAtu, DBOutrasPartesClienteDicInfo.OpcVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBOutrasPartesClienteDicInfo.OpcNome, DBOutrasPartesClienteDicInfo.OpcTerceirizado, DBOutrasPartesClienteDicInfo.OpcClientePrincipal, DBOutrasPartesClienteDicInfo.OpcTipo, DBOutrasPartesClienteDicInfo.OpcSexo, DBOutrasPartesClienteDicInfo.OpcDtNasc, DBOutrasPartesClienteDicInfo.OpcCPF, DBOutrasPartesClienteDicInfo.OpcRG, DBOutrasPartesClienteDicInfo.OpcCNPJ, DBOutrasPartesClienteDicInfo.OpcInscEst, DBOutrasPartesClienteDicInfo.OpcNomeFantasia, DBOutrasPartesClienteDicInfo.OpcEndereco, DBOutrasPartesClienteDicInfo.OpcCidade, DBOutrasPartesClienteDicInfo.OpcCEP, DBOutrasPartesClienteDicInfo.OpcBairro, DBOutrasPartesClienteDicInfo.OpcFone, DBOutrasPartesClienteDicInfo.OpcFax, DBOutrasPartesClienteDicInfo.OpcEMail, DBOutrasPartesClienteDicInfo.OpcSite, DBOutrasPartesClienteDicInfo.OpcClass, DBOutrasPartesClienteDicInfo.OpcGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "opcCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBOutrasPartesClienteDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "opcCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBOutrasPartesClienteDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
