#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBFornecedoresODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBFornecedoresDicInfo.TabelaNome;
    public string ICampoCodigo() => DBFornecedoresDicInfo.CampoCodigo;
    public string IPrefixo() => DBFornecedoresDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => true;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBFornecedoresDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => true;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBFornecedoresDicInfo.Grupo => DBFornecedoresDicInfo.ForGrupo,
        DBFornecedoresDicInfo.Nome => DBFornecedoresDicInfo.ForNome,
        DBFornecedoresDicInfo.SubGrupo => DBFornecedoresDicInfo.ForSubGrupo,
        DBFornecedoresDicInfo.Tipo => DBFornecedoresDicInfo.ForTipo,
        DBFornecedoresDicInfo.Sexo => DBFornecedoresDicInfo.ForSexo,
        DBFornecedoresDicInfo.CNPJ => DBFornecedoresDicInfo.ForCNPJ,
        DBFornecedoresDicInfo.InscEst => DBFornecedoresDicInfo.ForInscEst,
        DBFornecedoresDicInfo.CPF => DBFornecedoresDicInfo.ForCPF,
        DBFornecedoresDicInfo.RG => DBFornecedoresDicInfo.ForRG,
        DBFornecedoresDicInfo.Endereco => DBFornecedoresDicInfo.ForEndereco,
        DBFornecedoresDicInfo.Bairro => DBFornecedoresDicInfo.ForBairro,
        DBFornecedoresDicInfo.CEP => DBFornecedoresDicInfo.ForCEP,
        DBFornecedoresDicInfo.Cidade => DBFornecedoresDicInfo.ForCidade,
        DBFornecedoresDicInfo.Fone => DBFornecedoresDicInfo.ForFone,
        DBFornecedoresDicInfo.Fax => DBFornecedoresDicInfo.ForFax,
        DBFornecedoresDicInfo.Email => DBFornecedoresDicInfo.ForEmail,
        DBFornecedoresDicInfo.Site => DBFornecedoresDicInfo.ForSite,
        DBFornecedoresDicInfo.Obs => DBFornecedoresDicInfo.ForObs,
        DBFornecedoresDicInfo.Produtos => DBFornecedoresDicInfo.ForProdutos,
        DBFornecedoresDicInfo.Contatos => DBFornecedoresDicInfo.ForContatos,
        DBFornecedoresDicInfo.Etiqueta => DBFornecedoresDicInfo.ForEtiqueta,
        DBFornecedoresDicInfo.Bold => DBFornecedoresDicInfo.ForBold,
        DBFornecedoresDicInfo.GUID => DBFornecedoresDicInfo.ForGUID,
        DBFornecedoresDicInfo.QuemCad => DBFornecedoresDicInfo.ForQuemCad,
        DBFornecedoresDicInfo.DtCad => DBFornecedoresDicInfo.ForDtCad,
        DBFornecedoresDicInfo.QuemAtu => DBFornecedoresDicInfo.ForQuemAtu,
        DBFornecedoresDicInfo.DtAtu => DBFornecedoresDicInfo.ForDtAtu,
        DBFornecedoresDicInfo.Visto => DBFornecedoresDicInfo.ForVisto,
        _ => null
    };
    public static string TCampoCodigo => DBFornecedoresDicInfo.CampoCodigo;
    public static string TCampoNome => DBFornecedoresDicInfo.CampoNome;
    public static string TTabelaNome => DBFornecedoresDicInfo.TabelaNome;
    public static string TTablePrefix => DBFornecedoresDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBFornecedoresDicInfo.ForGrupo, DBFornecedoresDicInfo.ForNome, DBFornecedoresDicInfo.ForSubGrupo, DBFornecedoresDicInfo.ForTipo, DBFornecedoresDicInfo.ForSexo, DBFornecedoresDicInfo.ForCNPJ, DBFornecedoresDicInfo.ForInscEst, DBFornecedoresDicInfo.ForCPF, DBFornecedoresDicInfo.ForRG, DBFornecedoresDicInfo.ForEndereco, DBFornecedoresDicInfo.ForBairro, DBFornecedoresDicInfo.ForCEP, DBFornecedoresDicInfo.ForCidade, DBFornecedoresDicInfo.ForFone, DBFornecedoresDicInfo.ForFax, DBFornecedoresDicInfo.ForEmail, DBFornecedoresDicInfo.ForSite, DBFornecedoresDicInfo.ForObs, DBFornecedoresDicInfo.ForProdutos, DBFornecedoresDicInfo.ForContatos, DBFornecedoresDicInfo.ForEtiqueta, DBFornecedoresDicInfo.ForBold, DBFornecedoresDicInfo.ForGUID, DBFornecedoresDicInfo.ForQuemCad, DBFornecedoresDicInfo.ForDtCad, DBFornecedoresDicInfo.ForQuemAtu, DBFornecedoresDicInfo.ForDtAtu, DBFornecedoresDicInfo.ForVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBFornecedoresDicInfo.ForGrupo, DBFornecedoresDicInfo.ForNome, DBFornecedoresDicInfo.ForSubGrupo, DBFornecedoresDicInfo.ForTipo, DBFornecedoresDicInfo.ForSexo, DBFornecedoresDicInfo.ForCNPJ, DBFornecedoresDicInfo.ForInscEst, DBFornecedoresDicInfo.ForCPF, DBFornecedoresDicInfo.ForRG, DBFornecedoresDicInfo.ForEndereco, DBFornecedoresDicInfo.ForBairro, DBFornecedoresDicInfo.ForCEP, DBFornecedoresDicInfo.ForCidade, DBFornecedoresDicInfo.ForFone, DBFornecedoresDicInfo.ForFax, DBFornecedoresDicInfo.ForEmail, DBFornecedoresDicInfo.ForSite, DBFornecedoresDicInfo.ForObs, DBFornecedoresDicInfo.ForProdutos, DBFornecedoresDicInfo.ForContatos, DBFornecedoresDicInfo.ForGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "forCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBFornecedoresDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "forCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBFornecedoresDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
