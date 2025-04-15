#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBPosicaoOutrasPartesODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBPosicaoOutrasPartesDicInfo.TabelaNome;
    public string ICampoCodigo() => DBPosicaoOutrasPartesDicInfo.CampoCodigo;
    public string IPrefixo() => DBPosicaoOutrasPartesDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBPosicaoOutrasPartesDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBPosicaoOutrasPartesDicInfo.Descricao => DBPosicaoOutrasPartesDicInfo.PosDescricao,
        DBPosicaoOutrasPartesDicInfo.Bold => DBPosicaoOutrasPartesDicInfo.PosBold,
        DBPosicaoOutrasPartesDicInfo.GUID => DBPosicaoOutrasPartesDicInfo.PosGUID,
        DBPosicaoOutrasPartesDicInfo.QuemCad => DBPosicaoOutrasPartesDicInfo.PosQuemCad,
        DBPosicaoOutrasPartesDicInfo.DtCad => DBPosicaoOutrasPartesDicInfo.PosDtCad,
        DBPosicaoOutrasPartesDicInfo.QuemAtu => DBPosicaoOutrasPartesDicInfo.PosQuemAtu,
        DBPosicaoOutrasPartesDicInfo.DtAtu => DBPosicaoOutrasPartesDicInfo.PosDtAtu,
        DBPosicaoOutrasPartesDicInfo.Visto => DBPosicaoOutrasPartesDicInfo.PosVisto,
        _ => null
    };
    public static string TCampoCodigo => DBPosicaoOutrasPartesDicInfo.CampoCodigo;
    public static string TCampoNome => DBPosicaoOutrasPartesDicInfo.CampoNome;
    public static string TTabelaNome => DBPosicaoOutrasPartesDicInfo.TabelaNome;
    public static string TTablePrefix => DBPosicaoOutrasPartesDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBPosicaoOutrasPartesDicInfo.PosDescricao, DBPosicaoOutrasPartesDicInfo.PosBold, DBPosicaoOutrasPartesDicInfo.PosGUID, DBPosicaoOutrasPartesDicInfo.PosQuemCad, DBPosicaoOutrasPartesDicInfo.PosDtCad, DBPosicaoOutrasPartesDicInfo.PosQuemAtu, DBPosicaoOutrasPartesDicInfo.PosDtAtu, DBPosicaoOutrasPartesDicInfo.PosVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBPosicaoOutrasPartesDicInfo.PosDescricao, DBPosicaoOutrasPartesDicInfo.PosBold];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "posCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBPosicaoOutrasPartesDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "posCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBPosicaoOutrasPartesDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
