#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBPenhoraODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBPenhoraDicInfo.TabelaNome;
    public string ICampoCodigo() => DBPenhoraDicInfo.CampoCodigo;
    public string IPrefixo() => DBPenhoraDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBPenhoraDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBPenhoraDicInfo.Processo => DBPenhoraDicInfo.PhrProcesso,
        DBPenhoraDicInfo.Nome => DBPenhoraDicInfo.PhrNome,
        DBPenhoraDicInfo.Descricao => DBPenhoraDicInfo.PhrDescricao,
        DBPenhoraDicInfo.DataPenhora => DBPenhoraDicInfo.PhrDataPenhora,
        DBPenhoraDicInfo.PenhoraStatus => DBPenhoraDicInfo.PhrPenhoraStatus,
        DBPenhoraDicInfo.Master => DBPenhoraDicInfo.PhrMaster,
        DBPenhoraDicInfo.GUID => DBPenhoraDicInfo.PhrGUID,
        DBPenhoraDicInfo.QuemCad => DBPenhoraDicInfo.PhrQuemCad,
        DBPenhoraDicInfo.DtCad => DBPenhoraDicInfo.PhrDtCad,
        DBPenhoraDicInfo.QuemAtu => DBPenhoraDicInfo.PhrQuemAtu,
        DBPenhoraDicInfo.DtAtu => DBPenhoraDicInfo.PhrDtAtu,
        DBPenhoraDicInfo.Visto => DBPenhoraDicInfo.PhrVisto,
        _ => null
    };
    public static string TCampoCodigo => DBPenhoraDicInfo.CampoCodigo;
    public static string TCampoNome => DBPenhoraDicInfo.CampoNome;
    public static string TTabelaNome => DBPenhoraDicInfo.TabelaNome;
    public static string TTablePrefix => DBPenhoraDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBPenhoraDicInfo.PhrProcesso, DBPenhoraDicInfo.PhrNome, DBPenhoraDicInfo.PhrDescricao, DBPenhoraDicInfo.PhrDataPenhora, DBPenhoraDicInfo.PhrPenhoraStatus, DBPenhoraDicInfo.PhrMaster, DBPenhoraDicInfo.PhrGUID, DBPenhoraDicInfo.PhrQuemCad, DBPenhoraDicInfo.PhrDtCad, DBPenhoraDicInfo.PhrQuemAtu, DBPenhoraDicInfo.PhrDtAtu, DBPenhoraDicInfo.PhrVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBPenhoraDicInfo.PhrProcesso, DBPenhoraDicInfo.PhrNome, DBPenhoraDicInfo.PhrDescricao, DBPenhoraDicInfo.PhrDataPenhora, DBPenhoraDicInfo.PhrPenhoraStatus, DBPenhoraDicInfo.PhrMaster];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "phrCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBPenhoraDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "phrCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBPenhoraDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
