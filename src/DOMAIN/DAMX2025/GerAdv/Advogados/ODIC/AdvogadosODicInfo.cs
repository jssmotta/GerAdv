#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBAdvogadosODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBAdvogadosDicInfo.TabelaNome;
    public string ICampoCodigo() => DBAdvogadosDicInfo.CampoCodigo;
    public string IPrefixo() => DBAdvogadosDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => true;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBAdvogadosDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => true;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBAdvogadosDicInfo.Cargo => DBAdvogadosDicInfo.AdvCargo,
        DBAdvogadosDicInfo.EMailPro => DBAdvogadosDicInfo.AdvEMailPro,
        DBAdvogadosDicInfo.CPF => DBAdvogadosDicInfo.AdvCPF,
        DBAdvogadosDicInfo.Nome => DBAdvogadosDicInfo.AdvNome,
        DBAdvogadosDicInfo.RG => DBAdvogadosDicInfo.AdvRG,
        DBAdvogadosDicInfo.Casa => DBAdvogadosDicInfo.AdvCasa,
        DBAdvogadosDicInfo.NomeMae => DBAdvogadosDicInfo.AdvNomeMae,
        DBAdvogadosDicInfo.Escritorio => DBAdvogadosDicInfo.AdvEscritorio,
        DBAdvogadosDicInfo.Estagiario => DBAdvogadosDicInfo.AdvEstagiario,
        DBAdvogadosDicInfo.OAB => DBAdvogadosDicInfo.AdvOAB,
        DBAdvogadosDicInfo.NomeCompleto => DBAdvogadosDicInfo.AdvNomeCompleto,
        DBAdvogadosDicInfo.Endereco => DBAdvogadosDicInfo.AdvEndereco,
        DBAdvogadosDicInfo.Cidade => DBAdvogadosDicInfo.AdvCidade,
        DBAdvogadosDicInfo.CEP => DBAdvogadosDicInfo.AdvCEP,
        DBAdvogadosDicInfo.Sexo => DBAdvogadosDicInfo.AdvSexo,
        DBAdvogadosDicInfo.Bairro => DBAdvogadosDicInfo.AdvBairro,
        DBAdvogadosDicInfo.CTPSSerie => DBAdvogadosDicInfo.AdvCTPSSerie,
        DBAdvogadosDicInfo.CTPS => DBAdvogadosDicInfo.AdvCTPS,
        DBAdvogadosDicInfo.Fone => DBAdvogadosDicInfo.AdvFone,
        DBAdvogadosDicInfo.Fax => DBAdvogadosDicInfo.AdvFax,
        DBAdvogadosDicInfo.Comissao => DBAdvogadosDicInfo.AdvComissao,
        DBAdvogadosDicInfo.DtInicio => DBAdvogadosDicInfo.AdvDtInicio,
        DBAdvogadosDicInfo.DtFim => DBAdvogadosDicInfo.AdvDtFim,
        DBAdvogadosDicInfo.DtNasc => DBAdvogadosDicInfo.AdvDtNasc,
        DBAdvogadosDicInfo.Salario => DBAdvogadosDicInfo.AdvSalario,
        DBAdvogadosDicInfo.Secretaria => DBAdvogadosDicInfo.AdvSecretaria,
        DBAdvogadosDicInfo.TextoProcuracao => DBAdvogadosDicInfo.AdvTextoProcuracao,
        DBAdvogadosDicInfo.EMail => DBAdvogadosDicInfo.AdvEMail,
        DBAdvogadosDicInfo.Especializacao => DBAdvogadosDicInfo.AdvEspecializacao,
        DBAdvogadosDicInfo.Pasta => DBAdvogadosDicInfo.AdvPasta,
        DBAdvogadosDicInfo.Observacao => DBAdvogadosDicInfo.AdvObservacao,
        DBAdvogadosDicInfo.ContaBancaria => DBAdvogadosDicInfo.AdvContaBancaria,
        DBAdvogadosDicInfo.ParcTop => DBAdvogadosDicInfo.AdvParcTop,
        DBAdvogadosDicInfo.Class => DBAdvogadosDicInfo.AdvClass,
        DBAdvogadosDicInfo.Top => DBAdvogadosDicInfo.AdvTop,
        DBAdvogadosDicInfo.Etiqueta => DBAdvogadosDicInfo.AdvEtiqueta,
        DBAdvogadosDicInfo.Ani => DBAdvogadosDicInfo.AdvAni,
        DBAdvogadosDicInfo.Bold => DBAdvogadosDicInfo.AdvBold,
        DBAdvogadosDicInfo.GUID => DBAdvogadosDicInfo.AdvGUID,
        DBAdvogadosDicInfo.QuemCad => DBAdvogadosDicInfo.AdvQuemCad,
        DBAdvogadosDicInfo.DtCad => DBAdvogadosDicInfo.AdvDtCad,
        DBAdvogadosDicInfo.QuemAtu => DBAdvogadosDicInfo.AdvQuemAtu,
        DBAdvogadosDicInfo.DtAtu => DBAdvogadosDicInfo.AdvDtAtu,
        DBAdvogadosDicInfo.Visto => DBAdvogadosDicInfo.AdvVisto,
        _ => null
    };
    public static string TCampoCodigo => DBAdvogadosDicInfo.CampoCodigo;
    public static string TCampoNome => DBAdvogadosDicInfo.CampoNome;
    public static string TTabelaNome => DBAdvogadosDicInfo.TabelaNome;
    public static string TTablePrefix => DBAdvogadosDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBAdvogadosDicInfo.AdvCargo, DBAdvogadosDicInfo.AdvEMailPro, DBAdvogadosDicInfo.AdvCPF, DBAdvogadosDicInfo.AdvNome, DBAdvogadosDicInfo.AdvRG, DBAdvogadosDicInfo.AdvCasa, DBAdvogadosDicInfo.AdvNomeMae, DBAdvogadosDicInfo.AdvEscritorio, DBAdvogadosDicInfo.AdvEstagiario, DBAdvogadosDicInfo.AdvOAB, DBAdvogadosDicInfo.AdvNomeCompleto, DBAdvogadosDicInfo.AdvEndereco, DBAdvogadosDicInfo.AdvCidade, DBAdvogadosDicInfo.AdvCEP, DBAdvogadosDicInfo.AdvSexo, DBAdvogadosDicInfo.AdvBairro, DBAdvogadosDicInfo.AdvCTPSSerie, DBAdvogadosDicInfo.AdvCTPS, DBAdvogadosDicInfo.AdvFone, DBAdvogadosDicInfo.AdvFax, DBAdvogadosDicInfo.AdvComissao, DBAdvogadosDicInfo.AdvDtInicio, DBAdvogadosDicInfo.AdvDtFim, DBAdvogadosDicInfo.AdvDtNasc, DBAdvogadosDicInfo.AdvSalario, DBAdvogadosDicInfo.AdvSecretaria, DBAdvogadosDicInfo.AdvTextoProcuracao, DBAdvogadosDicInfo.AdvEMail, DBAdvogadosDicInfo.AdvEspecializacao, DBAdvogadosDicInfo.AdvPasta, DBAdvogadosDicInfo.AdvObservacao, DBAdvogadosDicInfo.AdvContaBancaria, DBAdvogadosDicInfo.AdvParcTop, DBAdvogadosDicInfo.AdvClass, DBAdvogadosDicInfo.AdvTop, DBAdvogadosDicInfo.AdvEtiqueta, DBAdvogadosDicInfo.AdvAni, DBAdvogadosDicInfo.AdvBold, DBAdvogadosDicInfo.AdvGUID, DBAdvogadosDicInfo.AdvQuemCad, DBAdvogadosDicInfo.AdvDtCad, DBAdvogadosDicInfo.AdvQuemAtu, DBAdvogadosDicInfo.AdvDtAtu, DBAdvogadosDicInfo.AdvVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBAdvogadosDicInfo.AdvCargo, DBAdvogadosDicInfo.AdvEMailPro, DBAdvogadosDicInfo.AdvCPF, DBAdvogadosDicInfo.AdvNome, DBAdvogadosDicInfo.AdvRG, DBAdvogadosDicInfo.AdvCasa, DBAdvogadosDicInfo.AdvNomeMae, DBAdvogadosDicInfo.AdvEscritorio, DBAdvogadosDicInfo.AdvEstagiario, DBAdvogadosDicInfo.AdvOAB, DBAdvogadosDicInfo.AdvNomeCompleto, DBAdvogadosDicInfo.AdvEndereco, DBAdvogadosDicInfo.AdvCidade, DBAdvogadosDicInfo.AdvCEP, DBAdvogadosDicInfo.AdvSexo, DBAdvogadosDicInfo.AdvBairro, DBAdvogadosDicInfo.AdvCTPSSerie, DBAdvogadosDicInfo.AdvCTPS, DBAdvogadosDicInfo.AdvFone, DBAdvogadosDicInfo.AdvFax, DBAdvogadosDicInfo.AdvComissao, DBAdvogadosDicInfo.AdvDtInicio, DBAdvogadosDicInfo.AdvDtFim, DBAdvogadosDicInfo.AdvDtNasc, DBAdvogadosDicInfo.AdvSalario, DBAdvogadosDicInfo.AdvSecretaria, DBAdvogadosDicInfo.AdvTextoProcuracao, DBAdvogadosDicInfo.AdvEMail, DBAdvogadosDicInfo.AdvEspecializacao, DBAdvogadosDicInfo.AdvPasta, DBAdvogadosDicInfo.AdvObservacao, DBAdvogadosDicInfo.AdvContaBancaria, DBAdvogadosDicInfo.AdvParcTop, DBAdvogadosDicInfo.AdvClass, DBAdvogadosDicInfo.AdvTop, DBAdvogadosDicInfo.AdvGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "advCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBAdvogadosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "advCodigo",
            "advEscritorio",
            "advNome"
        };
        var result = campos.Where(campo => !campo.Equals(DBAdvogadosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
