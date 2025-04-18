#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBDivisaoTribunalODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBDivisaoTribunalDicInfo.TabelaNome;
    public string ICampoCodigo() => DBDivisaoTribunalDicInfo.CampoCodigo;
    public string IPrefixo() => DBDivisaoTribunalDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBDivisaoTribunalDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBDivisaoTribunalDicInfo.NumCodigo => DBDivisaoTribunalDicInfo.DivNumCodigo,
        DBDivisaoTribunalDicInfo.Justica => DBDivisaoTribunalDicInfo.DivJustica,
        DBDivisaoTribunalDicInfo.NomeEspecial => DBDivisaoTribunalDicInfo.DivNomeEspecial,
        DBDivisaoTribunalDicInfo.Area => DBDivisaoTribunalDicInfo.DivArea,
        DBDivisaoTribunalDicInfo.Cidade => DBDivisaoTribunalDicInfo.DivCidade,
        DBDivisaoTribunalDicInfo.Foro => DBDivisaoTribunalDicInfo.DivForo,
        DBDivisaoTribunalDicInfo.Tribunal => DBDivisaoTribunalDicInfo.DivTribunal,
        DBDivisaoTribunalDicInfo.CodigoDiv => DBDivisaoTribunalDicInfo.DivCodigoDiv,
        DBDivisaoTribunalDicInfo.Endereco => DBDivisaoTribunalDicInfo.DivEndereco,
        DBDivisaoTribunalDicInfo.Fone => DBDivisaoTribunalDicInfo.DivFone,
        DBDivisaoTribunalDicInfo.Fax => DBDivisaoTribunalDicInfo.DivFax,
        DBDivisaoTribunalDicInfo.CEP => DBDivisaoTribunalDicInfo.DivCEP,
        DBDivisaoTribunalDicInfo.Obs => DBDivisaoTribunalDicInfo.DivObs,
        DBDivisaoTribunalDicInfo.EMail => DBDivisaoTribunalDicInfo.DivEMail,
        DBDivisaoTribunalDicInfo.Andar => DBDivisaoTribunalDicInfo.DivAndar,
        DBDivisaoTribunalDicInfo.Etiqueta => DBDivisaoTribunalDicInfo.DivEtiqueta,
        DBDivisaoTribunalDicInfo.Bold => DBDivisaoTribunalDicInfo.DivBold,
        DBDivisaoTribunalDicInfo.GUID => DBDivisaoTribunalDicInfo.DivGUID,
        DBDivisaoTribunalDicInfo.QuemCad => DBDivisaoTribunalDicInfo.DivQuemCad,
        DBDivisaoTribunalDicInfo.DtCad => DBDivisaoTribunalDicInfo.DivDtCad,
        DBDivisaoTribunalDicInfo.QuemAtu => DBDivisaoTribunalDicInfo.DivQuemAtu,
        DBDivisaoTribunalDicInfo.DtAtu => DBDivisaoTribunalDicInfo.DivDtAtu,
        DBDivisaoTribunalDicInfo.Visto => DBDivisaoTribunalDicInfo.DivVisto,
        _ => null
    };
    public static string TCampoCodigo => DBDivisaoTribunalDicInfo.CampoCodigo;
    public static string TCampoNome => DBDivisaoTribunalDicInfo.CampoNome;
    public static string TTabelaNome => DBDivisaoTribunalDicInfo.TabelaNome;
    public static string TTablePrefix => DBDivisaoTribunalDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBDivisaoTribunalDicInfo.DivNumCodigo, DBDivisaoTribunalDicInfo.DivJustica, DBDivisaoTribunalDicInfo.DivNomeEspecial, DBDivisaoTribunalDicInfo.DivArea, DBDivisaoTribunalDicInfo.DivCidade, DBDivisaoTribunalDicInfo.DivForo, DBDivisaoTribunalDicInfo.DivTribunal, DBDivisaoTribunalDicInfo.DivCodigoDiv, DBDivisaoTribunalDicInfo.DivEndereco, DBDivisaoTribunalDicInfo.DivFone, DBDivisaoTribunalDicInfo.DivFax, DBDivisaoTribunalDicInfo.DivCEP, DBDivisaoTribunalDicInfo.DivObs, DBDivisaoTribunalDicInfo.DivEMail, DBDivisaoTribunalDicInfo.DivAndar, DBDivisaoTribunalDicInfo.DivEtiqueta, DBDivisaoTribunalDicInfo.DivBold, DBDivisaoTribunalDicInfo.DivGUID, DBDivisaoTribunalDicInfo.DivQuemCad, DBDivisaoTribunalDicInfo.DivDtCad, DBDivisaoTribunalDicInfo.DivQuemAtu, DBDivisaoTribunalDicInfo.DivDtAtu, DBDivisaoTribunalDicInfo.DivVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBDivisaoTribunalDicInfo.DivNumCodigo, DBDivisaoTribunalDicInfo.DivJustica, DBDivisaoTribunalDicInfo.DivNomeEspecial, DBDivisaoTribunalDicInfo.DivArea, DBDivisaoTribunalDicInfo.DivCidade, DBDivisaoTribunalDicInfo.DivForo, DBDivisaoTribunalDicInfo.DivTribunal, DBDivisaoTribunalDicInfo.DivCodigoDiv, DBDivisaoTribunalDicInfo.DivEndereco, DBDivisaoTribunalDicInfo.DivFone, DBDivisaoTribunalDicInfo.DivFax, DBDivisaoTribunalDicInfo.DivCEP, DBDivisaoTribunalDicInfo.DivObs, DBDivisaoTribunalDicInfo.DivEMail, DBDivisaoTribunalDicInfo.DivAndar, DBDivisaoTribunalDicInfo.DivEtiqueta, DBDivisaoTribunalDicInfo.DivBold];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "divCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBDivisaoTribunalDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "divArea",
            "divCidade",
            "divCodigo",
            "divForo",
            "divJustica",
            "divNumCodigo",
            "divTribunal"
        };
        var result = campos.Where(campo => !campo.Equals(DBDivisaoTribunalDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
