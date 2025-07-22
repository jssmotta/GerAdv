#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBPrepostosODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBPrepostosDicInfo.TabelaNome;
    public string ICampoCodigo() => DBPrepostosDicInfo.CampoCodigo;
    public string IPrefixo() => DBPrepostosDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => true;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBPrepostosDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => true;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBPrepostosDicInfo.Nome => DBPrepostosDicInfo.PreNome,
        DBPrepostosDicInfo.Funcao => DBPrepostosDicInfo.PreFuncao,
        DBPrepostosDicInfo.Setor => DBPrepostosDicInfo.PreSetor,
        DBPrepostosDicInfo.DtNasc => DBPrepostosDicInfo.PreDtNasc,
        DBPrepostosDicInfo.Qualificacao => DBPrepostosDicInfo.PreQualificacao,
        DBPrepostosDicInfo.Sexo => DBPrepostosDicInfo.PreSexo,
        DBPrepostosDicInfo.Idade => DBPrepostosDicInfo.PreIdade,
        DBPrepostosDicInfo.CPF => DBPrepostosDicInfo.PreCPF,
        DBPrepostosDicInfo.RG => DBPrepostosDicInfo.PreRG,
        DBPrepostosDicInfo.Periodo_Ini => DBPrepostosDicInfo.PrePeriodo_Ini,
        DBPrepostosDicInfo.Periodo_Fim => DBPrepostosDicInfo.PrePeriodo_Fim,
        DBPrepostosDicInfo.Registro => DBPrepostosDicInfo.PreRegistro,
        DBPrepostosDicInfo.CTPSNumero => DBPrepostosDicInfo.PreCTPSNumero,
        DBPrepostosDicInfo.CTPSSerie => DBPrepostosDicInfo.PreCTPSSerie,
        DBPrepostosDicInfo.CTPSDtEmissao => DBPrepostosDicInfo.PreCTPSDtEmissao,
        DBPrepostosDicInfo.PIS => DBPrepostosDicInfo.PrePIS,
        DBPrepostosDicInfo.Salario => DBPrepostosDicInfo.PreSalario,
        DBPrepostosDicInfo.LiberaAgenda => DBPrepostosDicInfo.PreLiberaAgenda,
        DBPrepostosDicInfo.Observacao => DBPrepostosDicInfo.PreObservacao,
        DBPrepostosDicInfo.Endereco => DBPrepostosDicInfo.PreEndereco,
        DBPrepostosDicInfo.Bairro => DBPrepostosDicInfo.PreBairro,
        DBPrepostosDicInfo.Cidade => DBPrepostosDicInfo.PreCidade,
        DBPrepostosDicInfo.CEP => DBPrepostosDicInfo.PreCEP,
        DBPrepostosDicInfo.Fone => DBPrepostosDicInfo.PreFone,
        DBPrepostosDicInfo.Fax => DBPrepostosDicInfo.PreFax,
        DBPrepostosDicInfo.EMail => DBPrepostosDicInfo.PreEMail,
        DBPrepostosDicInfo.Pai => DBPrepostosDicInfo.PrePai,
        DBPrepostosDicInfo.Mae => DBPrepostosDicInfo.PreMae,
        DBPrepostosDicInfo.Class => DBPrepostosDicInfo.PreClass,
        DBPrepostosDicInfo.Etiqueta => DBPrepostosDicInfo.PreEtiqueta,
        DBPrepostosDicInfo.Ani => DBPrepostosDicInfo.PreAni,
        DBPrepostosDicInfo.Bold => DBPrepostosDicInfo.PreBold,
        DBPrepostosDicInfo.GUID => DBPrepostosDicInfo.PreGUID,
        DBPrepostosDicInfo.QuemCad => DBPrepostosDicInfo.PreQuemCad,
        DBPrepostosDicInfo.DtCad => DBPrepostosDicInfo.PreDtCad,
        DBPrepostosDicInfo.QuemAtu => DBPrepostosDicInfo.PreQuemAtu,
        DBPrepostosDicInfo.DtAtu => DBPrepostosDicInfo.PreDtAtu,
        DBPrepostosDicInfo.Visto => DBPrepostosDicInfo.PreVisto,
        _ => null
    };
    public static string TCampoCodigo => DBPrepostosDicInfo.CampoCodigo;
    public static string TCampoNome => DBPrepostosDicInfo.CampoNome;
    public static string TTabelaNome => DBPrepostosDicInfo.TabelaNome;
    public static string TTablePrefix => DBPrepostosDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBPrepostosDicInfo.PreNome, DBPrepostosDicInfo.PreFuncao, DBPrepostosDicInfo.PreSetor, DBPrepostosDicInfo.PreDtNasc, DBPrepostosDicInfo.PreQualificacao, DBPrepostosDicInfo.PreSexo, DBPrepostosDicInfo.PreIdade, DBPrepostosDicInfo.PreCPF, DBPrepostosDicInfo.PreRG, DBPrepostosDicInfo.PrePeriodo_Ini, DBPrepostosDicInfo.PrePeriodo_Fim, DBPrepostosDicInfo.PreRegistro, DBPrepostosDicInfo.PreCTPSNumero, DBPrepostosDicInfo.PreCTPSSerie, DBPrepostosDicInfo.PreCTPSDtEmissao, DBPrepostosDicInfo.PrePIS, DBPrepostosDicInfo.PreSalario, DBPrepostosDicInfo.PreLiberaAgenda, DBPrepostosDicInfo.PreObservacao, DBPrepostosDicInfo.PreEndereco, DBPrepostosDicInfo.PreBairro, DBPrepostosDicInfo.PreCidade, DBPrepostosDicInfo.PreCEP, DBPrepostosDicInfo.PreFone, DBPrepostosDicInfo.PreFax, DBPrepostosDicInfo.PreEMail, DBPrepostosDicInfo.PrePai, DBPrepostosDicInfo.PreMae, DBPrepostosDicInfo.PreClass, DBPrepostosDicInfo.PreEtiqueta, DBPrepostosDicInfo.PreAni, DBPrepostosDicInfo.PreBold, DBPrepostosDicInfo.PreGUID, DBPrepostosDicInfo.PreQuemCad, DBPrepostosDicInfo.PreDtCad, DBPrepostosDicInfo.PreQuemAtu, DBPrepostosDicInfo.PreDtAtu, DBPrepostosDicInfo.PreVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBPrepostosDicInfo.PreNome, DBPrepostosDicInfo.PreFuncao, DBPrepostosDicInfo.PreSetor, DBPrepostosDicInfo.PreDtNasc, DBPrepostosDicInfo.PreQualificacao, DBPrepostosDicInfo.PreSexo, DBPrepostosDicInfo.PreIdade, DBPrepostosDicInfo.PreCPF, DBPrepostosDicInfo.PreRG, DBPrepostosDicInfo.PrePeriodo_Ini, DBPrepostosDicInfo.PrePeriodo_Fim, DBPrepostosDicInfo.PreRegistro, DBPrepostosDicInfo.PreCTPSNumero, DBPrepostosDicInfo.PreCTPSSerie, DBPrepostosDicInfo.PreCTPSDtEmissao, DBPrepostosDicInfo.PrePIS, DBPrepostosDicInfo.PreSalario, DBPrepostosDicInfo.PreLiberaAgenda, DBPrepostosDicInfo.PreObservacao, DBPrepostosDicInfo.PreEndereco, DBPrepostosDicInfo.PreBairro, DBPrepostosDicInfo.PreCidade, DBPrepostosDicInfo.PreCEP, DBPrepostosDicInfo.PreFone, DBPrepostosDicInfo.PreFax, DBPrepostosDicInfo.PreEMail, DBPrepostosDicInfo.PrePai, DBPrepostosDicInfo.PreMae, DBPrepostosDicInfo.PreClass, DBPrepostosDicInfo.PreGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "preCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBPrepostosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "preCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBPrepostosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
