#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBGUTAtividadesMatrizODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBGUTAtividadesMatrizDicInfo.TabelaNome;
    public string ICampoCodigo() => DBGUTAtividadesMatrizDicInfo.CampoCodigo;
    public string IPrefixo() => DBGUTAtividadesMatrizDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBGUTAtividadesMatrizDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBGUTAtividadesMatrizDicInfo.GUTMatriz => DBGUTAtividadesMatrizDicInfo.AmgGUTMatriz,
        DBGUTAtividadesMatrizDicInfo.GUTAtividade => DBGUTAtividadesMatrizDicInfo.AmgGUTAtividade,
        DBGUTAtividadesMatrizDicInfo.GUID => DBGUTAtividadesMatrizDicInfo.AmgGUID,
        DBGUTAtividadesMatrizDicInfo.QuemCad => DBGUTAtividadesMatrizDicInfo.AmgQuemCad,
        DBGUTAtividadesMatrizDicInfo.DtCad => DBGUTAtividadesMatrizDicInfo.AmgDtCad,
        DBGUTAtividadesMatrizDicInfo.QuemAtu => DBGUTAtividadesMatrizDicInfo.AmgQuemAtu,
        DBGUTAtividadesMatrizDicInfo.DtAtu => DBGUTAtividadesMatrizDicInfo.AmgDtAtu,
        DBGUTAtividadesMatrizDicInfo.Visto => DBGUTAtividadesMatrizDicInfo.AmgVisto,
        _ => null
    };
    public static string TCampoCodigo => DBGUTAtividadesMatrizDicInfo.CampoCodigo;
    public static string TCampoNome => DBGUTAtividadesMatrizDicInfo.CampoNome;
    public static string TTabelaNome => DBGUTAtividadesMatrizDicInfo.TabelaNome;
    public static string TTablePrefix => DBGUTAtividadesMatrizDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBGUTAtividadesMatrizDicInfo.AmgGUTMatriz, DBGUTAtividadesMatrizDicInfo.AmgGUTAtividade, DBGUTAtividadesMatrizDicInfo.AmgGUID, DBGUTAtividadesMatrizDicInfo.AmgQuemCad, DBGUTAtividadesMatrizDicInfo.AmgDtCad, DBGUTAtividadesMatrizDicInfo.AmgQuemAtu, DBGUTAtividadesMatrizDicInfo.AmgDtAtu, DBGUTAtividadesMatrizDicInfo.AmgVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBGUTAtividadesMatrizDicInfo.AmgGUTMatriz, DBGUTAtividadesMatrizDicInfo.AmgGUTAtividade];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "amgGUTAtividade",
            "amgGUTMatriz"
        };
        var result = campos.Where(campo => !campo.Equals(DBGUTAtividadesMatrizDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "amgCodigo",
            "amgGUTAtividade",
            "amgGUTMatriz"
        };
        var result = campos.Where(campo => !campo.Equals(DBGUTAtividadesMatrizDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
