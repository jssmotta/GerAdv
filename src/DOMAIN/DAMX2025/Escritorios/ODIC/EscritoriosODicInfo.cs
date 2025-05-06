#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBEscritoriosODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBEscritoriosDicInfo.TabelaNome;
    public string ICampoCodigo() => DBEscritoriosDicInfo.CampoCodigo;
    public string IPrefixo() => DBEscritoriosDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBEscritoriosDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBEscritoriosDicInfo.CNPJ => DBEscritoriosDicInfo.EscCNPJ,
        DBEscritoriosDicInfo.Casa => DBEscritoriosDicInfo.EscCasa,
        DBEscritoriosDicInfo.Parceria => DBEscritoriosDicInfo.EscParceria,
        DBEscritoriosDicInfo.Nome => DBEscritoriosDicInfo.EscNome,
        DBEscritoriosDicInfo.OAB => DBEscritoriosDicInfo.EscOAB,
        DBEscritoriosDicInfo.Endereco => DBEscritoriosDicInfo.EscEndereco,
        DBEscritoriosDicInfo.Cidade => DBEscritoriosDicInfo.EscCidade,
        DBEscritoriosDicInfo.Bairro => DBEscritoriosDicInfo.EscBairro,
        DBEscritoriosDicInfo.CEP => DBEscritoriosDicInfo.EscCEP,
        DBEscritoriosDicInfo.Fone => DBEscritoriosDicInfo.EscFone,
        DBEscritoriosDicInfo.Fax => DBEscritoriosDicInfo.EscFax,
        DBEscritoriosDicInfo.Site => DBEscritoriosDicInfo.EscSite,
        DBEscritoriosDicInfo.EMail => DBEscritoriosDicInfo.EscEMail,
        DBEscritoriosDicInfo.OBS => DBEscritoriosDicInfo.EscOBS,
        DBEscritoriosDicInfo.AdvResponsavel => DBEscritoriosDicInfo.EscAdvResponsavel,
        DBEscritoriosDicInfo.Secretaria => DBEscritoriosDicInfo.EscSecretaria,
        DBEscritoriosDicInfo.InscEst => DBEscritoriosDicInfo.EscInscEst,
        DBEscritoriosDicInfo.Correspondente => DBEscritoriosDicInfo.EscCorrespondente,
        DBEscritoriosDicInfo.Top => DBEscritoriosDicInfo.EscTop,
        DBEscritoriosDicInfo.Etiqueta => DBEscritoriosDicInfo.EscEtiqueta,
        DBEscritoriosDicInfo.Bold => DBEscritoriosDicInfo.EscBold,
        DBEscritoriosDicInfo.GUID => DBEscritoriosDicInfo.EscGUID,
        DBEscritoriosDicInfo.QuemCad => DBEscritoriosDicInfo.EscQuemCad,
        DBEscritoriosDicInfo.DtCad => DBEscritoriosDicInfo.EscDtCad,
        DBEscritoriosDicInfo.QuemAtu => DBEscritoriosDicInfo.EscQuemAtu,
        DBEscritoriosDicInfo.DtAtu => DBEscritoriosDicInfo.EscDtAtu,
        DBEscritoriosDicInfo.Visto => DBEscritoriosDicInfo.EscVisto,
        _ => null
    };
    public static string TCampoCodigo => DBEscritoriosDicInfo.CampoCodigo;
    public static string TCampoNome => DBEscritoriosDicInfo.CampoNome;
    public static string TTabelaNome => DBEscritoriosDicInfo.TabelaNome;
    public static string TTablePrefix => DBEscritoriosDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBEscritoriosDicInfo.EscCNPJ, DBEscritoriosDicInfo.EscCasa, DBEscritoriosDicInfo.EscParceria, DBEscritoriosDicInfo.EscNome, DBEscritoriosDicInfo.EscOAB, DBEscritoriosDicInfo.EscEndereco, DBEscritoriosDicInfo.EscCidade, DBEscritoriosDicInfo.EscBairro, DBEscritoriosDicInfo.EscCEP, DBEscritoriosDicInfo.EscFone, DBEscritoriosDicInfo.EscFax, DBEscritoriosDicInfo.EscSite, DBEscritoriosDicInfo.EscEMail, DBEscritoriosDicInfo.EscOBS, DBEscritoriosDicInfo.EscAdvResponsavel, DBEscritoriosDicInfo.EscSecretaria, DBEscritoriosDicInfo.EscInscEst, DBEscritoriosDicInfo.EscCorrespondente, DBEscritoriosDicInfo.EscTop, DBEscritoriosDicInfo.EscEtiqueta, DBEscritoriosDicInfo.EscBold, DBEscritoriosDicInfo.EscGUID, DBEscritoriosDicInfo.EscQuemCad, DBEscritoriosDicInfo.EscDtCad, DBEscritoriosDicInfo.EscQuemAtu, DBEscritoriosDicInfo.EscDtAtu, DBEscritoriosDicInfo.EscVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBEscritoriosDicInfo.EscCNPJ, DBEscritoriosDicInfo.EscCasa, DBEscritoriosDicInfo.EscParceria, DBEscritoriosDicInfo.EscNome, DBEscritoriosDicInfo.EscOAB, DBEscritoriosDicInfo.EscEndereco, DBEscritoriosDicInfo.EscCidade, DBEscritoriosDicInfo.EscBairro, DBEscritoriosDicInfo.EscCEP, DBEscritoriosDicInfo.EscFone, DBEscritoriosDicInfo.EscFax, DBEscritoriosDicInfo.EscSite, DBEscritoriosDicInfo.EscEMail, DBEscritoriosDicInfo.EscOBS, DBEscritoriosDicInfo.EscAdvResponsavel, DBEscritoriosDicInfo.EscSecretaria, DBEscritoriosDicInfo.EscInscEst, DBEscritoriosDicInfo.EscCorrespondente, DBEscritoriosDicInfo.EscTop, DBEscritoriosDicInfo.EscEtiqueta, DBEscritoriosDicInfo.EscBold, DBEscritoriosDicInfo.EscGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "escCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBEscritoriosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "escCodigo",
            "escNome"
        };
        var result = campos.Where(campo => !campo.Equals(DBEscritoriosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
