#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBDocsRecebidosItensODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBDocsRecebidosItensDicInfo.TabelaNome;
    public string ICampoCodigo() => DBDocsRecebidosItensDicInfo.CampoCodigo;
    public string IPrefixo() => DBDocsRecebidosItensDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBDocsRecebidosItensDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBDocsRecebidosItensDicInfo.ContatoCRM => DBDocsRecebidosItensDicInfo.DriContatoCRM,
        DBDocsRecebidosItensDicInfo.Nome => DBDocsRecebidosItensDicInfo.DriNome,
        DBDocsRecebidosItensDicInfo.Devolvido => DBDocsRecebidosItensDicInfo.DriDevolvido,
        DBDocsRecebidosItensDicInfo.SeraDevolvido => DBDocsRecebidosItensDicInfo.DriSeraDevolvido,
        DBDocsRecebidosItensDicInfo.Observacoes => DBDocsRecebidosItensDicInfo.DriObservacoes,
        DBDocsRecebidosItensDicInfo.Bold => DBDocsRecebidosItensDicInfo.DriBold,
        DBDocsRecebidosItensDicInfo.GUID => DBDocsRecebidosItensDicInfo.DriGUID,
        DBDocsRecebidosItensDicInfo.QuemCad => DBDocsRecebidosItensDicInfo.DriQuemCad,
        DBDocsRecebidosItensDicInfo.DtCad => DBDocsRecebidosItensDicInfo.DriDtCad,
        DBDocsRecebidosItensDicInfo.QuemAtu => DBDocsRecebidosItensDicInfo.DriQuemAtu,
        DBDocsRecebidosItensDicInfo.DtAtu => DBDocsRecebidosItensDicInfo.DriDtAtu,
        DBDocsRecebidosItensDicInfo.Visto => DBDocsRecebidosItensDicInfo.DriVisto,
        _ => null
    };
    public static string TCampoCodigo => DBDocsRecebidosItensDicInfo.CampoCodigo;
    public static string TCampoNome => DBDocsRecebidosItensDicInfo.CampoNome;
    public static string TTabelaNome => DBDocsRecebidosItensDicInfo.TabelaNome;
    public static string TTablePrefix => DBDocsRecebidosItensDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBDocsRecebidosItensDicInfo.DriContatoCRM, DBDocsRecebidosItensDicInfo.DriNome, DBDocsRecebidosItensDicInfo.DriDevolvido, DBDocsRecebidosItensDicInfo.DriSeraDevolvido, DBDocsRecebidosItensDicInfo.DriObservacoes, DBDocsRecebidosItensDicInfo.DriBold, DBDocsRecebidosItensDicInfo.DriGUID, DBDocsRecebidosItensDicInfo.DriQuemCad, DBDocsRecebidosItensDicInfo.DriDtCad, DBDocsRecebidosItensDicInfo.DriQuemAtu, DBDocsRecebidosItensDicInfo.DriDtAtu, DBDocsRecebidosItensDicInfo.DriVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBDocsRecebidosItensDicInfo.DriContatoCRM, DBDocsRecebidosItensDicInfo.DriNome, DBDocsRecebidosItensDicInfo.DriDevolvido, DBDocsRecebidosItensDicInfo.DriSeraDevolvido, DBDocsRecebidosItensDicInfo.DriObservacoes, DBDocsRecebidosItensDicInfo.DriBold];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "driCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBDocsRecebidosItensDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "driCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBDocsRecebidosItensDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
