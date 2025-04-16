#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBPreClientesODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBPreClientesDicInfo.TabelaNome;
    public string ICampoCodigo() => DBPreClientesDicInfo.CampoCodigo;
    public string IPrefixo() => DBPreClientesDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => true;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBPreClientesDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => true;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBPreClientesDicInfo.Inativo => DBPreClientesDicInfo.CliInativo,
        DBPreClientesDicInfo.QuemIndicou => DBPreClientesDicInfo.CliQuemIndicou,
        DBPreClientesDicInfo.Nome => DBPreClientesDicInfo.CliNome,
        DBPreClientesDicInfo.Adv => DBPreClientesDicInfo.CliAdv,
        DBPreClientesDicInfo.IDRep => DBPreClientesDicInfo.CliIDRep,
        DBPreClientesDicInfo.Juridica => DBPreClientesDicInfo.CliJuridica,
        DBPreClientesDicInfo.NomeFantasia => DBPreClientesDicInfo.CliNomeFantasia,
        DBPreClientesDicInfo.Class => DBPreClientesDicInfo.CliClass,
        DBPreClientesDicInfo.Tipo => DBPreClientesDicInfo.CliTipo,
        DBPreClientesDicInfo.DtNasc => DBPreClientesDicInfo.CliDtNasc,
        DBPreClientesDicInfo.InscEst => DBPreClientesDicInfo.CliInscEst,
        DBPreClientesDicInfo.Qualificacao => DBPreClientesDicInfo.CliQualificacao,
        DBPreClientesDicInfo.Sexo => DBPreClientesDicInfo.CliSexo,
        DBPreClientesDicInfo.Idade => DBPreClientesDicInfo.CliIdade,
        DBPreClientesDicInfo.CNPJ => DBPreClientesDicInfo.CliCNPJ,
        DBPreClientesDicInfo.CPF => DBPreClientesDicInfo.CliCPF,
        DBPreClientesDicInfo.RG => DBPreClientesDicInfo.CliRG,
        DBPreClientesDicInfo.TipoCaptacao => DBPreClientesDicInfo.CliTipoCaptacao,
        DBPreClientesDicInfo.Observacao => DBPreClientesDicInfo.CliObservacao,
        DBPreClientesDicInfo.Endereco => DBPreClientesDicInfo.CliEndereco,
        DBPreClientesDicInfo.Bairro => DBPreClientesDicInfo.CliBairro,
        DBPreClientesDicInfo.Cidade => DBPreClientesDicInfo.CliCidade,
        DBPreClientesDicInfo.CEP => DBPreClientesDicInfo.CliCEP,
        DBPreClientesDicInfo.Fax => DBPreClientesDicInfo.CliFax,
        DBPreClientesDicInfo.Fone => DBPreClientesDicInfo.CliFone,
        DBPreClientesDicInfo.Data => DBPreClientesDicInfo.CliData,
        DBPreClientesDicInfo.HomePage => DBPreClientesDicInfo.CliHomePage,
        DBPreClientesDicInfo.EMail => DBPreClientesDicInfo.CliEMail,
        DBPreClientesDicInfo.Assistido => DBPreClientesDicInfo.CliAssistido,
        DBPreClientesDicInfo.AssRG => DBPreClientesDicInfo.CliAssRG,
        DBPreClientesDicInfo.AssCPF => DBPreClientesDicInfo.CliAssCPF,
        DBPreClientesDicInfo.AssEndereco => DBPreClientesDicInfo.CliAssEndereco,
        DBPreClientesDicInfo.CNH => DBPreClientesDicInfo.CliCNH,
        DBPreClientesDicInfo.Etiqueta => DBPreClientesDicInfo.CliEtiqueta,
        DBPreClientesDicInfo.Ani => DBPreClientesDicInfo.CliAni,
        DBPreClientesDicInfo.Bold => DBPreClientesDicInfo.CliBold,
        DBPreClientesDicInfo.QuemCad => DBPreClientesDicInfo.CliQuemCad,
        DBPreClientesDicInfo.DtCad => DBPreClientesDicInfo.CliDtCad,
        DBPreClientesDicInfo.QuemAtu => DBPreClientesDicInfo.CliQuemAtu,
        DBPreClientesDicInfo.DtAtu => DBPreClientesDicInfo.CliDtAtu,
        DBPreClientesDicInfo.Visto => DBPreClientesDicInfo.CliVisto,
        _ => null
    };
    public static string TCampoCodigo => DBPreClientesDicInfo.CampoCodigo;
    public static string TCampoNome => DBPreClientesDicInfo.CampoNome;
    public static string TTabelaNome => DBPreClientesDicInfo.TabelaNome;
    public static string TTablePrefix => DBPreClientesDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBPreClientesDicInfo.CliInativo, DBPreClientesDicInfo.CliQuemIndicou, DBPreClientesDicInfo.CliNome, DBPreClientesDicInfo.CliAdv, DBPreClientesDicInfo.CliIDRep, DBPreClientesDicInfo.CliJuridica, DBPreClientesDicInfo.CliNomeFantasia, DBPreClientesDicInfo.CliClass, DBPreClientesDicInfo.CliTipo, DBPreClientesDicInfo.CliDtNasc, DBPreClientesDicInfo.CliInscEst, DBPreClientesDicInfo.CliQualificacao, DBPreClientesDicInfo.CliSexo, DBPreClientesDicInfo.CliIdade, DBPreClientesDicInfo.CliCNPJ, DBPreClientesDicInfo.CliCPF, DBPreClientesDicInfo.CliRG, DBPreClientesDicInfo.CliTipoCaptacao, DBPreClientesDicInfo.CliObservacao, DBPreClientesDicInfo.CliEndereco, DBPreClientesDicInfo.CliBairro, DBPreClientesDicInfo.CliCidade, DBPreClientesDicInfo.CliCEP, DBPreClientesDicInfo.CliFax, DBPreClientesDicInfo.CliFone, DBPreClientesDicInfo.CliData, DBPreClientesDicInfo.CliHomePage, DBPreClientesDicInfo.CliEMail, DBPreClientesDicInfo.CliAssistido, DBPreClientesDicInfo.CliAssRG, DBPreClientesDicInfo.CliAssCPF, DBPreClientesDicInfo.CliAssEndereco, DBPreClientesDicInfo.CliCNH, DBPreClientesDicInfo.CliEtiqueta, DBPreClientesDicInfo.CliAni, DBPreClientesDicInfo.CliBold, DBPreClientesDicInfo.CliQuemCad, DBPreClientesDicInfo.CliDtCad, DBPreClientesDicInfo.CliQuemAtu, DBPreClientesDicInfo.CliDtAtu, DBPreClientesDicInfo.CliVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBPreClientesDicInfo.CliInativo, DBPreClientesDicInfo.CliQuemIndicou, DBPreClientesDicInfo.CliNome, DBPreClientesDicInfo.CliAdv, DBPreClientesDicInfo.CliIDRep, DBPreClientesDicInfo.CliJuridica, DBPreClientesDicInfo.CliNomeFantasia, DBPreClientesDicInfo.CliClass, DBPreClientesDicInfo.CliTipo, DBPreClientesDicInfo.CliDtNasc, DBPreClientesDicInfo.CliInscEst, DBPreClientesDicInfo.CliQualificacao, DBPreClientesDicInfo.CliSexo, DBPreClientesDicInfo.CliIdade, DBPreClientesDicInfo.CliCNPJ, DBPreClientesDicInfo.CliCPF, DBPreClientesDicInfo.CliRG, DBPreClientesDicInfo.CliTipoCaptacao, DBPreClientesDicInfo.CliObservacao, DBPreClientesDicInfo.CliEndereco, DBPreClientesDicInfo.CliBairro, DBPreClientesDicInfo.CliCidade, DBPreClientesDicInfo.CliCEP, DBPreClientesDicInfo.CliFax, DBPreClientesDicInfo.CliFone, DBPreClientesDicInfo.CliData, DBPreClientesDicInfo.CliHomePage, DBPreClientesDicInfo.CliEMail, DBPreClientesDicInfo.CliAssistido, DBPreClientesDicInfo.CliAssRG, DBPreClientesDicInfo.CliAssCPF, DBPreClientesDicInfo.CliAssEndereco, DBPreClientesDicInfo.CliCNH, DBPreClientesDicInfo.CliEtiqueta, DBPreClientesDicInfo.CliAni, DBPreClientesDicInfo.CliBold];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "cliCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBPreClientesDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "cliCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBPreClientesDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
