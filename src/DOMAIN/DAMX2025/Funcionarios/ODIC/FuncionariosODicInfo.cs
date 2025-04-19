#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBFuncionariosODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBFuncionariosDicInfo.TabelaNome;
    public string ICampoCodigo() => DBFuncionariosDicInfo.CampoCodigo;
    public string IPrefixo() => DBFuncionariosDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => true;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBFuncionariosDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => true;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBFuncionariosDicInfo.EMailPro => DBFuncionariosDicInfo.FunEMailPro,
        DBFuncionariosDicInfo.Cargo => DBFuncionariosDicInfo.FunCargo,
        DBFuncionariosDicInfo.Nome => DBFuncionariosDicInfo.FunNome,
        DBFuncionariosDicInfo.Funcao => DBFuncionariosDicInfo.FunFuncao,
        DBFuncionariosDicInfo.Sexo => DBFuncionariosDicInfo.FunSexo,
        DBFuncionariosDicInfo.Registro => DBFuncionariosDicInfo.FunRegistro,
        DBFuncionariosDicInfo.CPF => DBFuncionariosDicInfo.FunCPF,
        DBFuncionariosDicInfo.RG => DBFuncionariosDicInfo.FunRG,
        DBFuncionariosDicInfo.Tipo => DBFuncionariosDicInfo.FunTipo,
        DBFuncionariosDicInfo.Observacao => DBFuncionariosDicInfo.FunObservacao,
        DBFuncionariosDicInfo.Endereco => DBFuncionariosDicInfo.FunEndereco,
        DBFuncionariosDicInfo.Bairro => DBFuncionariosDicInfo.FunBairro,
        DBFuncionariosDicInfo.Cidade => DBFuncionariosDicInfo.FunCidade,
        DBFuncionariosDicInfo.CEP => DBFuncionariosDicInfo.FunCEP,
        DBFuncionariosDicInfo.Contato => DBFuncionariosDicInfo.FunContato,
        DBFuncionariosDicInfo.Fax => DBFuncionariosDicInfo.FunFax,
        DBFuncionariosDicInfo.Fone => DBFuncionariosDicInfo.FunFone,
        DBFuncionariosDicInfo.EMail => DBFuncionariosDicInfo.FunEMail,
        DBFuncionariosDicInfo.Periodo_Ini => DBFuncionariosDicInfo.FunPeriodo_Ini,
        DBFuncionariosDicInfo.Periodo_Fim => DBFuncionariosDicInfo.FunPeriodo_Fim,
        DBFuncionariosDicInfo.CTPSNumero => DBFuncionariosDicInfo.FunCTPSNumero,
        DBFuncionariosDicInfo.CTPSSerie => DBFuncionariosDicInfo.FunCTPSSerie,
        DBFuncionariosDicInfo.PIS => DBFuncionariosDicInfo.FunPIS,
        DBFuncionariosDicInfo.Salario => DBFuncionariosDicInfo.FunSalario,
        DBFuncionariosDicInfo.CTPSDtEmissao => DBFuncionariosDicInfo.FunCTPSDtEmissao,
        DBFuncionariosDicInfo.DtNasc => DBFuncionariosDicInfo.FunDtNasc,
        DBFuncionariosDicInfo.Data => DBFuncionariosDicInfo.FunData,
        DBFuncionariosDicInfo.LiberaAgenda => DBFuncionariosDicInfo.FunLiberaAgenda,
        DBFuncionariosDicInfo.Pasta => DBFuncionariosDicInfo.FunPasta,
        DBFuncionariosDicInfo.Class => DBFuncionariosDicInfo.FunClass,
        DBFuncionariosDicInfo.Etiqueta => DBFuncionariosDicInfo.FunEtiqueta,
        DBFuncionariosDicInfo.Ani => DBFuncionariosDicInfo.FunAni,
        DBFuncionariosDicInfo.Bold => DBFuncionariosDicInfo.FunBold,
        DBFuncionariosDicInfo.GUID => DBFuncionariosDicInfo.FunGUID,
        DBFuncionariosDicInfo.QuemCad => DBFuncionariosDicInfo.FunQuemCad,
        DBFuncionariosDicInfo.DtCad => DBFuncionariosDicInfo.FunDtCad,
        DBFuncionariosDicInfo.QuemAtu => DBFuncionariosDicInfo.FunQuemAtu,
        DBFuncionariosDicInfo.DtAtu => DBFuncionariosDicInfo.FunDtAtu,
        DBFuncionariosDicInfo.Visto => DBFuncionariosDicInfo.FunVisto,
        _ => null
    };
    public static string TCampoCodigo => DBFuncionariosDicInfo.CampoCodigo;
    public static string TCampoNome => DBFuncionariosDicInfo.CampoNome;
    public static string TTabelaNome => DBFuncionariosDicInfo.TabelaNome;
    public static string TTablePrefix => DBFuncionariosDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBFuncionariosDicInfo.FunEMailPro, DBFuncionariosDicInfo.FunCargo, DBFuncionariosDicInfo.FunNome, DBFuncionariosDicInfo.FunFuncao, DBFuncionariosDicInfo.FunSexo, DBFuncionariosDicInfo.FunRegistro, DBFuncionariosDicInfo.FunCPF, DBFuncionariosDicInfo.FunRG, DBFuncionariosDicInfo.FunTipo, DBFuncionariosDicInfo.FunObservacao, DBFuncionariosDicInfo.FunEndereco, DBFuncionariosDicInfo.FunBairro, DBFuncionariosDicInfo.FunCidade, DBFuncionariosDicInfo.FunCEP, DBFuncionariosDicInfo.FunContato, DBFuncionariosDicInfo.FunFax, DBFuncionariosDicInfo.FunFone, DBFuncionariosDicInfo.FunEMail, DBFuncionariosDicInfo.FunPeriodo_Ini, DBFuncionariosDicInfo.FunPeriodo_Fim, DBFuncionariosDicInfo.FunCTPSNumero, DBFuncionariosDicInfo.FunCTPSSerie, DBFuncionariosDicInfo.FunPIS, DBFuncionariosDicInfo.FunSalario, DBFuncionariosDicInfo.FunCTPSDtEmissao, DBFuncionariosDicInfo.FunDtNasc, DBFuncionariosDicInfo.FunData, DBFuncionariosDicInfo.FunLiberaAgenda, DBFuncionariosDicInfo.FunPasta, DBFuncionariosDicInfo.FunClass, DBFuncionariosDicInfo.FunEtiqueta, DBFuncionariosDicInfo.FunAni, DBFuncionariosDicInfo.FunBold, DBFuncionariosDicInfo.FunGUID, DBFuncionariosDicInfo.FunQuemCad, DBFuncionariosDicInfo.FunDtCad, DBFuncionariosDicInfo.FunQuemAtu, DBFuncionariosDicInfo.FunDtAtu, DBFuncionariosDicInfo.FunVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBFuncionariosDicInfo.FunEMailPro, DBFuncionariosDicInfo.FunCargo, DBFuncionariosDicInfo.FunNome, DBFuncionariosDicInfo.FunFuncao, DBFuncionariosDicInfo.FunSexo, DBFuncionariosDicInfo.FunRegistro, DBFuncionariosDicInfo.FunCPF, DBFuncionariosDicInfo.FunRG, DBFuncionariosDicInfo.FunTipo, DBFuncionariosDicInfo.FunObservacao, DBFuncionariosDicInfo.FunEndereco, DBFuncionariosDicInfo.FunBairro, DBFuncionariosDicInfo.FunCidade, DBFuncionariosDicInfo.FunCEP, DBFuncionariosDicInfo.FunContato, DBFuncionariosDicInfo.FunFax, DBFuncionariosDicInfo.FunFone, DBFuncionariosDicInfo.FunEMail, DBFuncionariosDicInfo.FunPeriodo_Ini, DBFuncionariosDicInfo.FunPeriodo_Fim, DBFuncionariosDicInfo.FunCTPSNumero, DBFuncionariosDicInfo.FunCTPSSerie, DBFuncionariosDicInfo.FunPIS, DBFuncionariosDicInfo.FunSalario, DBFuncionariosDicInfo.FunCTPSDtEmissao, DBFuncionariosDicInfo.FunDtNasc, DBFuncionariosDicInfo.FunData, DBFuncionariosDicInfo.FunLiberaAgenda, DBFuncionariosDicInfo.FunPasta, DBFuncionariosDicInfo.FunClass, DBFuncionariosDicInfo.FunEtiqueta, DBFuncionariosDicInfo.FunAni, DBFuncionariosDicInfo.FunBold, DBFuncionariosDicInfo.FunGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "funCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBFuncionariosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "funCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBFuncionariosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
