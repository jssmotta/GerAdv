#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBClientesSociosODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBClientesSociosDicInfo.TabelaNome;
    public string ICampoCodigo() => DBClientesSociosDicInfo.CampoCodigo;
    public string IPrefixo() => DBClientesSociosDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => true;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBClientesSociosDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => true;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBClientesSociosDicInfo.SomenteRepresentante => DBClientesSociosDicInfo.CscSomenteRepresentante,
        DBClientesSociosDicInfo.Idade => DBClientesSociosDicInfo.CscIdade,
        DBClientesSociosDicInfo.IsRepresentanteLegal => DBClientesSociosDicInfo.CscIsRepresentanteLegal,
        DBClientesSociosDicInfo.Qualificacao => DBClientesSociosDicInfo.CscQualificacao,
        DBClientesSociosDicInfo.Sexo => DBClientesSociosDicInfo.CscSexo,
        DBClientesSociosDicInfo.DtNasc => DBClientesSociosDicInfo.CscDtNasc,
        DBClientesSociosDicInfo.Nome => DBClientesSociosDicInfo.CscNome,
        DBClientesSociosDicInfo.Site => DBClientesSociosDicInfo.CscSite,
        DBClientesSociosDicInfo.RepresentanteLegal => DBClientesSociosDicInfo.CscRepresentanteLegal,
        DBClientesSociosDicInfo.Cliente => DBClientesSociosDicInfo.CscCliente,
        DBClientesSociosDicInfo.Endereco => DBClientesSociosDicInfo.CscEndereco,
        DBClientesSociosDicInfo.Bairro => DBClientesSociosDicInfo.CscBairro,
        DBClientesSociosDicInfo.CEP => DBClientesSociosDicInfo.CscCEP,
        DBClientesSociosDicInfo.Cidade => DBClientesSociosDicInfo.CscCidade,
        DBClientesSociosDicInfo.RG => DBClientesSociosDicInfo.CscRG,
        DBClientesSociosDicInfo.CPF => DBClientesSociosDicInfo.CscCPF,
        DBClientesSociosDicInfo.Fone => DBClientesSociosDicInfo.CscFone,
        DBClientesSociosDicInfo.Participacao => DBClientesSociosDicInfo.CscParticipacao,
        DBClientesSociosDicInfo.Cargo => DBClientesSociosDicInfo.CscCargo,
        DBClientesSociosDicInfo.EMail => DBClientesSociosDicInfo.CscEMail,
        DBClientesSociosDicInfo.Obs => DBClientesSociosDicInfo.CscObs,
        DBClientesSociosDicInfo.CNH => DBClientesSociosDicInfo.CscCNH,
        DBClientesSociosDicInfo.DataContrato => DBClientesSociosDicInfo.CscDataContrato,
        DBClientesSociosDicInfo.CNPJ => DBClientesSociosDicInfo.CscCNPJ,
        DBClientesSociosDicInfo.InscEst => DBClientesSociosDicInfo.CscInscEst,
        DBClientesSociosDicInfo.SocioEmpresaAdminNome => DBClientesSociosDicInfo.CscSocioEmpresaAdminNome,
        DBClientesSociosDicInfo.EnderecoSocio => DBClientesSociosDicInfo.CscEnderecoSocio,
        DBClientesSociosDicInfo.BairroSocio => DBClientesSociosDicInfo.CscBairroSocio,
        DBClientesSociosDicInfo.CEPSocio => DBClientesSociosDicInfo.CscCEPSocio,
        DBClientesSociosDicInfo.CidadeSocio => DBClientesSociosDicInfo.CscCidadeSocio,
        DBClientesSociosDicInfo.RGDataExp => DBClientesSociosDicInfo.CscRGDataExp,
        DBClientesSociosDicInfo.SocioEmpresaAdminSomente => DBClientesSociosDicInfo.CscSocioEmpresaAdminSomente,
        DBClientesSociosDicInfo.Tipo => DBClientesSociosDicInfo.CscTipo,
        DBClientesSociosDicInfo.Fax => DBClientesSociosDicInfo.CscFax,
        DBClientesSociosDicInfo.Class => DBClientesSociosDicInfo.CscClass,
        DBClientesSociosDicInfo.Etiqueta => DBClientesSociosDicInfo.CscEtiqueta,
        DBClientesSociosDicInfo.Ani => DBClientesSociosDicInfo.CscAni,
        DBClientesSociosDicInfo.Bold => DBClientesSociosDicInfo.CscBold,
        DBClientesSociosDicInfo.GUID => DBClientesSociosDicInfo.CscGUID,
        DBClientesSociosDicInfo.QuemCad => DBClientesSociosDicInfo.CscQuemCad,
        DBClientesSociosDicInfo.DtCad => DBClientesSociosDicInfo.CscDtCad,
        DBClientesSociosDicInfo.QuemAtu => DBClientesSociosDicInfo.CscQuemAtu,
        DBClientesSociosDicInfo.DtAtu => DBClientesSociosDicInfo.CscDtAtu,
        DBClientesSociosDicInfo.Visto => DBClientesSociosDicInfo.CscVisto,
        _ => null
    };
    public static string TCampoCodigo => DBClientesSociosDicInfo.CampoCodigo;
    public static string TCampoNome => DBClientesSociosDicInfo.CampoNome;
    public static string TTabelaNome => DBClientesSociosDicInfo.TabelaNome;
    public static string TTablePrefix => DBClientesSociosDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBClientesSociosDicInfo.CscSomenteRepresentante, DBClientesSociosDicInfo.CscIdade, DBClientesSociosDicInfo.CscIsRepresentanteLegal, DBClientesSociosDicInfo.CscQualificacao, DBClientesSociosDicInfo.CscSexo, DBClientesSociosDicInfo.CscDtNasc, DBClientesSociosDicInfo.CscNome, DBClientesSociosDicInfo.CscSite, DBClientesSociosDicInfo.CscRepresentanteLegal, DBClientesSociosDicInfo.CscCliente, DBClientesSociosDicInfo.CscEndereco, DBClientesSociosDicInfo.CscBairro, DBClientesSociosDicInfo.CscCEP, DBClientesSociosDicInfo.CscCidade, DBClientesSociosDicInfo.CscRG, DBClientesSociosDicInfo.CscCPF, DBClientesSociosDicInfo.CscFone, DBClientesSociosDicInfo.CscParticipacao, DBClientesSociosDicInfo.CscCargo, DBClientesSociosDicInfo.CscEMail, DBClientesSociosDicInfo.CscObs, DBClientesSociosDicInfo.CscCNH, DBClientesSociosDicInfo.CscDataContrato, DBClientesSociosDicInfo.CscCNPJ, DBClientesSociosDicInfo.CscInscEst, DBClientesSociosDicInfo.CscSocioEmpresaAdminNome, DBClientesSociosDicInfo.CscEnderecoSocio, DBClientesSociosDicInfo.CscBairroSocio, DBClientesSociosDicInfo.CscCEPSocio, DBClientesSociosDicInfo.CscCidadeSocio, DBClientesSociosDicInfo.CscRGDataExp, DBClientesSociosDicInfo.CscSocioEmpresaAdminSomente, DBClientesSociosDicInfo.CscTipo, DBClientesSociosDicInfo.CscFax, DBClientesSociosDicInfo.CscClass, DBClientesSociosDicInfo.CscEtiqueta, DBClientesSociosDicInfo.CscAni, DBClientesSociosDicInfo.CscBold, DBClientesSociosDicInfo.CscGUID, DBClientesSociosDicInfo.CscQuemCad, DBClientesSociosDicInfo.CscDtCad, DBClientesSociosDicInfo.CscQuemAtu, DBClientesSociosDicInfo.CscDtAtu, DBClientesSociosDicInfo.CscVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBClientesSociosDicInfo.CscSomenteRepresentante, DBClientesSociosDicInfo.CscIdade, DBClientesSociosDicInfo.CscIsRepresentanteLegal, DBClientesSociosDicInfo.CscQualificacao, DBClientesSociosDicInfo.CscSexo, DBClientesSociosDicInfo.CscDtNasc, DBClientesSociosDicInfo.CscNome, DBClientesSociosDicInfo.CscSite, DBClientesSociosDicInfo.CscRepresentanteLegal, DBClientesSociosDicInfo.CscCliente, DBClientesSociosDicInfo.CscEndereco, DBClientesSociosDicInfo.CscBairro, DBClientesSociosDicInfo.CscCEP, DBClientesSociosDicInfo.CscCidade, DBClientesSociosDicInfo.CscRG, DBClientesSociosDicInfo.CscCPF, DBClientesSociosDicInfo.CscFone, DBClientesSociosDicInfo.CscParticipacao, DBClientesSociosDicInfo.CscCargo, DBClientesSociosDicInfo.CscEMail, DBClientesSociosDicInfo.CscObs, DBClientesSociosDicInfo.CscCNH, DBClientesSociosDicInfo.CscDataContrato, DBClientesSociosDicInfo.CscCNPJ, DBClientesSociosDicInfo.CscInscEst, DBClientesSociosDicInfo.CscSocioEmpresaAdminNome, DBClientesSociosDicInfo.CscEnderecoSocio, DBClientesSociosDicInfo.CscBairroSocio, DBClientesSociosDicInfo.CscCEPSocio, DBClientesSociosDicInfo.CscCidadeSocio, DBClientesSociosDicInfo.CscRGDataExp, DBClientesSociosDicInfo.CscSocioEmpresaAdminSomente, DBClientesSociosDicInfo.CscTipo, DBClientesSociosDicInfo.CscFax, DBClientesSociosDicInfo.CscClass, DBClientesSociosDicInfo.CscEtiqueta, DBClientesSociosDicInfo.CscAni, DBClientesSociosDicInfo.CscBold];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "cscCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBClientesSociosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "cscCliente",
            "cscCodigo",
            "cscNome"
        };
        var result = campos.Where(campo => !campo.Equals(DBClientesSociosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
