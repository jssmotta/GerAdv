#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBForoODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBForoDicInfo.TabelaNome;
    public string ICampoCodigo() => DBForoDicInfo.CampoCodigo;
    public string IPrefixo() => DBForoDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBForoDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBForoDicInfo.EMail => DBForoDicInfo.ForEMail,
        DBForoDicInfo.Nome => DBForoDicInfo.ForNome,
        DBForoDicInfo.Unico => DBForoDicInfo.ForUnico,
        DBForoDicInfo.Cidade => DBForoDicInfo.ForCidade,
        DBForoDicInfo.Site => DBForoDicInfo.ForSite,
        DBForoDicInfo.Endereco => DBForoDicInfo.ForEndereco,
        DBForoDicInfo.Bairro => DBForoDicInfo.ForBairro,
        DBForoDicInfo.Fone => DBForoDicInfo.ForFone,
        DBForoDicInfo.Fax => DBForoDicInfo.ForFax,
        DBForoDicInfo.CEP => DBForoDicInfo.ForCEP,
        DBForoDicInfo.OBS => DBForoDicInfo.ForOBS,
        DBForoDicInfo.UnicoConfirmado => DBForoDicInfo.ForUnicoConfirmado,
        DBForoDicInfo.Web => DBForoDicInfo.ForWeb,
        DBForoDicInfo.Etiqueta => DBForoDicInfo.ForEtiqueta,
        DBForoDicInfo.Bold => DBForoDicInfo.ForBold,
        DBForoDicInfo.QuemCad => DBForoDicInfo.ForQuemCad,
        DBForoDicInfo.DtCad => DBForoDicInfo.ForDtCad,
        DBForoDicInfo.QuemAtu => DBForoDicInfo.ForQuemAtu,
        DBForoDicInfo.DtAtu => DBForoDicInfo.ForDtAtu,
        DBForoDicInfo.Visto => DBForoDicInfo.ForVisto,
        _ => null
    };
    public static string TCampoCodigo => DBForoDicInfo.CampoCodigo;
    public static string TCampoNome => DBForoDicInfo.CampoNome;
    public static string TTabelaNome => DBForoDicInfo.TabelaNome;
    public static string TTablePrefix => DBForoDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBForoDicInfo.ForEMail, DBForoDicInfo.ForNome, DBForoDicInfo.ForUnico, DBForoDicInfo.ForCidade, DBForoDicInfo.ForSite, DBForoDicInfo.ForEndereco, DBForoDicInfo.ForBairro, DBForoDicInfo.ForFone, DBForoDicInfo.ForFax, DBForoDicInfo.ForCEP, DBForoDicInfo.ForOBS, DBForoDicInfo.ForUnicoConfirmado, DBForoDicInfo.ForWeb, DBForoDicInfo.ForEtiqueta, DBForoDicInfo.ForBold, DBForoDicInfo.ForQuemCad, DBForoDicInfo.ForDtCad, DBForoDicInfo.ForQuemAtu, DBForoDicInfo.ForDtAtu, DBForoDicInfo.ForVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBForoDicInfo.ForEMail, DBForoDicInfo.ForNome, DBForoDicInfo.ForUnico, DBForoDicInfo.ForCidade, DBForoDicInfo.ForSite, DBForoDicInfo.ForEndereco, DBForoDicInfo.ForBairro, DBForoDicInfo.ForFone, DBForoDicInfo.ForFax, DBForoDicInfo.ForCEP, DBForoDicInfo.ForOBS, DBForoDicInfo.ForUnicoConfirmado, DBForoDicInfo.ForWeb];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "forCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBForoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "forCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBForoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
