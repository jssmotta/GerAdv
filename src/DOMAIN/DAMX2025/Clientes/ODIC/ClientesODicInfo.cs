#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBClientesODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBClientesDicInfo.TabelaNome;
    public string ICampoCodigo() => DBClientesDicInfo.CampoCodigo;
    public string IPrefixo() => DBClientesDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => true;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBClientesDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => true;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBClientesDicInfo.Empresa => DBClientesDicInfo.CliEmpresa,
        DBClientesDicInfo.Icone => DBClientesDicInfo.CliIcone,
        DBClientesDicInfo.NomeMae => DBClientesDicInfo.CliNomeMae,
        DBClientesDicInfo.RGDataExp => DBClientesDicInfo.CliRGDataExp,
        DBClientesDicInfo.Inativo => DBClientesDicInfo.CliInativo,
        DBClientesDicInfo.QuemIndicou => DBClientesDicInfo.CliQuemIndicou,
        DBClientesDicInfo.SendEMail => DBClientesDicInfo.CliSendEMail,
        DBClientesDicInfo.Nome => DBClientesDicInfo.CliNome,
        DBClientesDicInfo.Adv => DBClientesDicInfo.CliAdv,
        DBClientesDicInfo.IDRep => DBClientesDicInfo.CliIDRep,
        DBClientesDicInfo.Juridica => DBClientesDicInfo.CliJuridica,
        DBClientesDicInfo.NomeFantasia => DBClientesDicInfo.CliNomeFantasia,
        DBClientesDicInfo.Class => DBClientesDicInfo.CliClass,
        DBClientesDicInfo.Tipo => DBClientesDicInfo.CliTipo,
        DBClientesDicInfo.DtNasc => DBClientesDicInfo.CliDtNasc,
        DBClientesDicInfo.InscEst => DBClientesDicInfo.CliInscEst,
        DBClientesDicInfo.Qualificacao => DBClientesDicInfo.CliQualificacao,
        DBClientesDicInfo.Sexo => DBClientesDicInfo.CliSexo,
        DBClientesDicInfo.Idade => DBClientesDicInfo.CliIdade,
        DBClientesDicInfo.CNPJ => DBClientesDicInfo.CliCNPJ,
        DBClientesDicInfo.CPF => DBClientesDicInfo.CliCPF,
        DBClientesDicInfo.RG => DBClientesDicInfo.CliRG,
        DBClientesDicInfo.TipoCaptacao => DBClientesDicInfo.CliTipoCaptacao,
        DBClientesDicInfo.Observacao => DBClientesDicInfo.CliObservacao,
        DBClientesDicInfo.Endereco => DBClientesDicInfo.CliEndereco,
        DBClientesDicInfo.Bairro => DBClientesDicInfo.CliBairro,
        DBClientesDicInfo.Cidade => DBClientesDicInfo.CliCidade,
        DBClientesDicInfo.CEP => DBClientesDicInfo.CliCEP,
        DBClientesDicInfo.Fax => DBClientesDicInfo.CliFax,
        DBClientesDicInfo.Fone => DBClientesDicInfo.CliFone,
        DBClientesDicInfo.Data => DBClientesDicInfo.CliData,
        DBClientesDicInfo.HomePage => DBClientesDicInfo.CliHomePage,
        DBClientesDicInfo.EMail => DBClientesDicInfo.CliEMail,
        DBClientesDicInfo.Obito => DBClientesDicInfo.CliObito,
        DBClientesDicInfo.NomePai => DBClientesDicInfo.CliNomePai,
        DBClientesDicInfo.RGOExpeditor => DBClientesDicInfo.CliRGOExpeditor,
        DBClientesDicInfo.RegimeTributacao => DBClientesDicInfo.CliRegimeTributacao,
        DBClientesDicInfo.EnquadramentoEmpresa => DBClientesDicInfo.CliEnquadramentoEmpresa,
        DBClientesDicInfo.ReportECBOnly => DBClientesDicInfo.CliReportECBOnly,
        DBClientesDicInfo.ProBono => DBClientesDicInfo.CliProBono,
        DBClientesDicInfo.CNH => DBClientesDicInfo.CliCNH,
        DBClientesDicInfo.PessoaContato => DBClientesDicInfo.CliPessoaContato,
        DBClientesDicInfo.Etiqueta => DBClientesDicInfo.CliEtiqueta,
        DBClientesDicInfo.Ani => DBClientesDicInfo.CliAni,
        DBClientesDicInfo.Bold => DBClientesDicInfo.CliBold,
        DBClientesDicInfo.GUID => DBClientesDicInfo.CliGUID,
        DBClientesDicInfo.QuemCad => DBClientesDicInfo.CliQuemCad,
        DBClientesDicInfo.DtCad => DBClientesDicInfo.CliDtCad,
        DBClientesDicInfo.QuemAtu => DBClientesDicInfo.CliQuemAtu,
        DBClientesDicInfo.DtAtu => DBClientesDicInfo.CliDtAtu,
        DBClientesDicInfo.Visto => DBClientesDicInfo.CliVisto,
        _ => null
    };
    public static string TCampoCodigo => DBClientesDicInfo.CampoCodigo;
    public static string TCampoNome => DBClientesDicInfo.CampoNome;
    public static string TTabelaNome => DBClientesDicInfo.TabelaNome;
    public static string TTablePrefix => DBClientesDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBClientesDicInfo.CliEmpresa, DBClientesDicInfo.CliIcone, DBClientesDicInfo.CliNomeMae, DBClientesDicInfo.CliRGDataExp, DBClientesDicInfo.CliInativo, DBClientesDicInfo.CliQuemIndicou, DBClientesDicInfo.CliSendEMail, DBClientesDicInfo.CliNome, DBClientesDicInfo.CliAdv, DBClientesDicInfo.CliIDRep, DBClientesDicInfo.CliJuridica, DBClientesDicInfo.CliNomeFantasia, DBClientesDicInfo.CliClass, DBClientesDicInfo.CliTipo, DBClientesDicInfo.CliDtNasc, DBClientesDicInfo.CliInscEst, DBClientesDicInfo.CliQualificacao, DBClientesDicInfo.CliSexo, DBClientesDicInfo.CliIdade, DBClientesDicInfo.CliCNPJ, DBClientesDicInfo.CliCPF, DBClientesDicInfo.CliRG, DBClientesDicInfo.CliTipoCaptacao, DBClientesDicInfo.CliObservacao, DBClientesDicInfo.CliEndereco, DBClientesDicInfo.CliBairro, DBClientesDicInfo.CliCidade, DBClientesDicInfo.CliCEP, DBClientesDicInfo.CliFax, DBClientesDicInfo.CliFone, DBClientesDicInfo.CliData, DBClientesDicInfo.CliHomePage, DBClientesDicInfo.CliEMail, DBClientesDicInfo.CliObito, DBClientesDicInfo.CliNomePai, DBClientesDicInfo.CliRGOExpeditor, DBClientesDicInfo.CliRegimeTributacao, DBClientesDicInfo.CliEnquadramentoEmpresa, DBClientesDicInfo.CliReportECBOnly, DBClientesDicInfo.CliProBono, DBClientesDicInfo.CliCNH, DBClientesDicInfo.CliPessoaContato, DBClientesDicInfo.CliEtiqueta, DBClientesDicInfo.CliAni, DBClientesDicInfo.CliBold, DBClientesDicInfo.CliGUID, DBClientesDicInfo.CliQuemCad, DBClientesDicInfo.CliDtCad, DBClientesDicInfo.CliQuemAtu, DBClientesDicInfo.CliDtAtu, DBClientesDicInfo.CliVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBClientesDicInfo.CliEmpresa, DBClientesDicInfo.CliIcone, DBClientesDicInfo.CliNomeMae, DBClientesDicInfo.CliRGDataExp, DBClientesDicInfo.CliInativo, DBClientesDicInfo.CliQuemIndicou, DBClientesDicInfo.CliSendEMail, DBClientesDicInfo.CliNome, DBClientesDicInfo.CliAdv, DBClientesDicInfo.CliIDRep, DBClientesDicInfo.CliJuridica, DBClientesDicInfo.CliNomeFantasia, DBClientesDicInfo.CliClass, DBClientesDicInfo.CliTipo, DBClientesDicInfo.CliDtNasc, DBClientesDicInfo.CliInscEst, DBClientesDicInfo.CliQualificacao, DBClientesDicInfo.CliSexo, DBClientesDicInfo.CliIdade, DBClientesDicInfo.CliCNPJ, DBClientesDicInfo.CliCPF, DBClientesDicInfo.CliRG, DBClientesDicInfo.CliTipoCaptacao, DBClientesDicInfo.CliObservacao, DBClientesDicInfo.CliEndereco, DBClientesDicInfo.CliBairro, DBClientesDicInfo.CliCidade, DBClientesDicInfo.CliCEP, DBClientesDicInfo.CliFax, DBClientesDicInfo.CliFone, DBClientesDicInfo.CliData, DBClientesDicInfo.CliHomePage, DBClientesDicInfo.CliEMail, DBClientesDicInfo.CliObito, DBClientesDicInfo.CliNomePai, DBClientesDicInfo.CliRGOExpeditor, DBClientesDicInfo.CliRegimeTributacao, DBClientesDicInfo.CliEnquadramentoEmpresa, DBClientesDicInfo.CliReportECBOnly, DBClientesDicInfo.CliProBono, DBClientesDicInfo.CliCNH, DBClientesDicInfo.CliPessoaContato, DBClientesDicInfo.CliEtiqueta, DBClientesDicInfo.CliAni, DBClientesDicInfo.CliBold];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "cliCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBClientesDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "cliCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBClientesDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
