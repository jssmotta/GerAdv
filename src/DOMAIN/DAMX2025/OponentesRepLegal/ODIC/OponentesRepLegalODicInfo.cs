#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBOponentesRepLegalODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBOponentesRepLegalDicInfo.TabelaNome;
    public string ICampoCodigo() => DBOponentesRepLegalDicInfo.CampoCodigo;
    public string IPrefixo() => DBOponentesRepLegalDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => true;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBOponentesRepLegalDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => true;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBOponentesRepLegalDicInfo.Nome => DBOponentesRepLegalDicInfo.OprNome,
        DBOponentesRepLegalDicInfo.Fone => DBOponentesRepLegalDicInfo.OprFone,
        DBOponentesRepLegalDicInfo.Oponente => DBOponentesRepLegalDicInfo.OprOponente,
        DBOponentesRepLegalDicInfo.Sexo => DBOponentesRepLegalDicInfo.OprSexo,
        DBOponentesRepLegalDicInfo.CPF => DBOponentesRepLegalDicInfo.OprCPF,
        DBOponentesRepLegalDicInfo.RG => DBOponentesRepLegalDicInfo.OprRG,
        DBOponentesRepLegalDicInfo.Endereco => DBOponentesRepLegalDicInfo.OprEndereco,
        DBOponentesRepLegalDicInfo.Bairro => DBOponentesRepLegalDicInfo.OprBairro,
        DBOponentesRepLegalDicInfo.CEP => DBOponentesRepLegalDicInfo.OprCEP,
        DBOponentesRepLegalDicInfo.Cidade => DBOponentesRepLegalDicInfo.OprCidade,
        DBOponentesRepLegalDicInfo.Fax => DBOponentesRepLegalDicInfo.OprFax,
        DBOponentesRepLegalDicInfo.EMail => DBOponentesRepLegalDicInfo.OprEMail,
        DBOponentesRepLegalDicInfo.Site => DBOponentesRepLegalDicInfo.OprSite,
        DBOponentesRepLegalDicInfo.Observacao => DBOponentesRepLegalDicInfo.OprObservacao,
        DBOponentesRepLegalDicInfo.Bold => DBOponentesRepLegalDicInfo.OprBold,
        DBOponentesRepLegalDicInfo.QuemCad => DBOponentesRepLegalDicInfo.OprQuemCad,
        DBOponentesRepLegalDicInfo.DtCad => DBOponentesRepLegalDicInfo.OprDtCad,
        DBOponentesRepLegalDicInfo.QuemAtu => DBOponentesRepLegalDicInfo.OprQuemAtu,
        DBOponentesRepLegalDicInfo.DtAtu => DBOponentesRepLegalDicInfo.OprDtAtu,
        DBOponentesRepLegalDicInfo.Visto => DBOponentesRepLegalDicInfo.OprVisto,
        _ => null
    };
    public static string TCampoCodigo => DBOponentesRepLegalDicInfo.CampoCodigo;
    public static string TCampoNome => DBOponentesRepLegalDicInfo.CampoNome;
    public static string TTabelaNome => DBOponentesRepLegalDicInfo.TabelaNome;
    public static string TTablePrefix => DBOponentesRepLegalDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBOponentesRepLegalDicInfo.OprNome, DBOponentesRepLegalDicInfo.OprFone, DBOponentesRepLegalDicInfo.OprOponente, DBOponentesRepLegalDicInfo.OprSexo, DBOponentesRepLegalDicInfo.OprCPF, DBOponentesRepLegalDicInfo.OprRG, DBOponentesRepLegalDicInfo.OprEndereco, DBOponentesRepLegalDicInfo.OprBairro, DBOponentesRepLegalDicInfo.OprCEP, DBOponentesRepLegalDicInfo.OprCidade, DBOponentesRepLegalDicInfo.OprFax, DBOponentesRepLegalDicInfo.OprEMail, DBOponentesRepLegalDicInfo.OprSite, DBOponentesRepLegalDicInfo.OprObservacao, DBOponentesRepLegalDicInfo.OprBold, DBOponentesRepLegalDicInfo.OprQuemCad, DBOponentesRepLegalDicInfo.OprDtCad, DBOponentesRepLegalDicInfo.OprQuemAtu, DBOponentesRepLegalDicInfo.OprDtAtu, DBOponentesRepLegalDicInfo.OprVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBOponentesRepLegalDicInfo.OprNome, DBOponentesRepLegalDicInfo.OprFone, DBOponentesRepLegalDicInfo.OprOponente, DBOponentesRepLegalDicInfo.OprSexo, DBOponentesRepLegalDicInfo.OprCPF, DBOponentesRepLegalDicInfo.OprRG, DBOponentesRepLegalDicInfo.OprEndereco, DBOponentesRepLegalDicInfo.OprBairro, DBOponentesRepLegalDicInfo.OprCEP, DBOponentesRepLegalDicInfo.OprCidade, DBOponentesRepLegalDicInfo.OprFax, DBOponentesRepLegalDicInfo.OprEMail, DBOponentesRepLegalDicInfo.OprSite, DBOponentesRepLegalDicInfo.OprObservacao, DBOponentesRepLegalDicInfo.OprBold];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "oprCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBOponentesRepLegalDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "oprCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBOponentesRepLegalDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
