#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBEnderecosODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBEnderecosDicInfo.TabelaNome;
    public string ICampoCodigo() => DBEnderecosDicInfo.CampoCodigo;
    public string IPrefixo() => DBEnderecosDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBEnderecosDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBEnderecosDicInfo.TopIndex => DBEnderecosDicInfo.EndTopIndex,
        DBEnderecosDicInfo.Descricao => DBEnderecosDicInfo.EndDescricao,
        DBEnderecosDicInfo.Contato => DBEnderecosDicInfo.EndContato,
        DBEnderecosDicInfo.DtNasc => DBEnderecosDicInfo.EndDtNasc,
        DBEnderecosDicInfo.Endereco => DBEnderecosDicInfo.EndEndereco,
        DBEnderecosDicInfo.Bairro => DBEnderecosDicInfo.EndBairro,
        DBEnderecosDicInfo.Privativo => DBEnderecosDicInfo.EndPrivativo,
        DBEnderecosDicInfo.AddContato => DBEnderecosDicInfo.EndAddContato,
        DBEnderecosDicInfo.CEP => DBEnderecosDicInfo.EndCEP,
        DBEnderecosDicInfo.OAB => DBEnderecosDicInfo.EndOAB,
        DBEnderecosDicInfo.OBS => DBEnderecosDicInfo.EndOBS,
        DBEnderecosDicInfo.Fone => DBEnderecosDicInfo.EndFone,
        DBEnderecosDicInfo.Fax => DBEnderecosDicInfo.EndFax,
        DBEnderecosDicInfo.Tratamento => DBEnderecosDicInfo.EndTratamento,
        DBEnderecosDicInfo.Cidade => DBEnderecosDicInfo.EndCidade,
        DBEnderecosDicInfo.Site => DBEnderecosDicInfo.EndSite,
        DBEnderecosDicInfo.EMail => DBEnderecosDicInfo.EndEMail,
        DBEnderecosDicInfo.Quem => DBEnderecosDicInfo.EndQuem,
        DBEnderecosDicInfo.QuemIndicou => DBEnderecosDicInfo.EndQuemIndicou,
        DBEnderecosDicInfo.ReportECBOnly => DBEnderecosDicInfo.EndReportECBOnly,
        DBEnderecosDicInfo.Etiqueta => DBEnderecosDicInfo.EndEtiqueta,
        DBEnderecosDicInfo.Ani => DBEnderecosDicInfo.EndAni,
        DBEnderecosDicInfo.Bold => DBEnderecosDicInfo.EndBold,
        DBEnderecosDicInfo.GUID => DBEnderecosDicInfo.EndGUID,
        DBEnderecosDicInfo.QuemCad => DBEnderecosDicInfo.EndQuemCad,
        DBEnderecosDicInfo.DtCad => DBEnderecosDicInfo.EndDtCad,
        DBEnderecosDicInfo.QuemAtu => DBEnderecosDicInfo.EndQuemAtu,
        DBEnderecosDicInfo.DtAtu => DBEnderecosDicInfo.EndDtAtu,
        DBEnderecosDicInfo.Visto => DBEnderecosDicInfo.EndVisto,
        _ => null
    };
    public static string TCampoCodigo => DBEnderecosDicInfo.CampoCodigo;
    public static string TCampoNome => DBEnderecosDicInfo.CampoNome;
    public static string TTabelaNome => DBEnderecosDicInfo.TabelaNome;
    public static string TTablePrefix => DBEnderecosDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBEnderecosDicInfo.EndTopIndex, DBEnderecosDicInfo.EndDescricao, DBEnderecosDicInfo.EndContato, DBEnderecosDicInfo.EndDtNasc, DBEnderecosDicInfo.EndEndereco, DBEnderecosDicInfo.EndBairro, DBEnderecosDicInfo.EndPrivativo, DBEnderecosDicInfo.EndAddContato, DBEnderecosDicInfo.EndCEP, DBEnderecosDicInfo.EndOAB, DBEnderecosDicInfo.EndOBS, DBEnderecosDicInfo.EndFone, DBEnderecosDicInfo.EndFax, DBEnderecosDicInfo.EndTratamento, DBEnderecosDicInfo.EndCidade, DBEnderecosDicInfo.EndSite, DBEnderecosDicInfo.EndEMail, DBEnderecosDicInfo.EndQuem, DBEnderecosDicInfo.EndQuemIndicou, DBEnderecosDicInfo.EndReportECBOnly, DBEnderecosDicInfo.EndEtiqueta, DBEnderecosDicInfo.EndAni, DBEnderecosDicInfo.EndBold, DBEnderecosDicInfo.EndGUID, DBEnderecosDicInfo.EndQuemCad, DBEnderecosDicInfo.EndDtCad, DBEnderecosDicInfo.EndQuemAtu, DBEnderecosDicInfo.EndDtAtu, DBEnderecosDicInfo.EndVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBEnderecosDicInfo.EndTopIndex, DBEnderecosDicInfo.EndDescricao, DBEnderecosDicInfo.EndContato, DBEnderecosDicInfo.EndDtNasc, DBEnderecosDicInfo.EndEndereco, DBEnderecosDicInfo.EndBairro, DBEnderecosDicInfo.EndPrivativo, DBEnderecosDicInfo.EndAddContato, DBEnderecosDicInfo.EndCEP, DBEnderecosDicInfo.EndOAB, DBEnderecosDicInfo.EndOBS, DBEnderecosDicInfo.EndFone, DBEnderecosDicInfo.EndFax, DBEnderecosDicInfo.EndTratamento, DBEnderecosDicInfo.EndCidade, DBEnderecosDicInfo.EndSite, DBEnderecosDicInfo.EndEMail, DBEnderecosDicInfo.EndQuem, DBEnderecosDicInfo.EndQuemIndicou, DBEnderecosDicInfo.EndReportECBOnly, DBEnderecosDicInfo.EndGUID];

    public static List<DBInfoSystem> ListPk() => [];
    public static List<DBInfoSystem> ListPkIndices() => [];
}
#endif
