#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBProValoresODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBProValoresDicInfo.TabelaNome;
    public string ICampoCodigo() => DBProValoresDicInfo.CampoCodigo;
    public string IPrefixo() => DBProValoresDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBProValoresDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBProValoresDicInfo.Processo => DBProValoresDicInfo.PrvProcesso,
        DBProValoresDicInfo.TipoValorProcesso => DBProValoresDicInfo.PrvTipoValorProcesso,
        DBProValoresDicInfo.Indice => DBProValoresDicInfo.PrvIndice,
        DBProValoresDicInfo.Ignorar => DBProValoresDicInfo.PrvIgnorar,
        DBProValoresDicInfo.Data => DBProValoresDicInfo.PrvData,
        DBProValoresDicInfo.ValorOriginal => DBProValoresDicInfo.PrvValorOriginal,
        DBProValoresDicInfo.PercMulta => DBProValoresDicInfo.PrvPercMulta,
        DBProValoresDicInfo.ValorMulta => DBProValoresDicInfo.PrvValorMulta,
        DBProValoresDicInfo.PercJuros => DBProValoresDicInfo.PrvPercJuros,
        DBProValoresDicInfo.ValorOriginalCorrigidoIndice => DBProValoresDicInfo.PrvValorOriginalCorrigidoIndice,
        DBProValoresDicInfo.ValorMultaCorrigido => DBProValoresDicInfo.PrvValorMultaCorrigido,
        DBProValoresDicInfo.ValorJurosCorrigido => DBProValoresDicInfo.PrvValorJurosCorrigido,
        DBProValoresDicInfo.ValorFinal => DBProValoresDicInfo.PrvValorFinal,
        DBProValoresDicInfo.DataUltimaCorrecao => DBProValoresDicInfo.PrvDataUltimaCorrecao,
        DBProValoresDicInfo.GUID => DBProValoresDicInfo.PrvGUID,
        DBProValoresDicInfo.QuemCad => DBProValoresDicInfo.PrvQuemCad,
        DBProValoresDicInfo.DtCad => DBProValoresDicInfo.PrvDtCad,
        DBProValoresDicInfo.QuemAtu => DBProValoresDicInfo.PrvQuemAtu,
        DBProValoresDicInfo.DtAtu => DBProValoresDicInfo.PrvDtAtu,
        DBProValoresDicInfo.Visto => DBProValoresDicInfo.PrvVisto,
        _ => null
    };
    public static string TCampoCodigo => DBProValoresDicInfo.CampoCodigo;
    public static string TCampoNome => DBProValoresDicInfo.CampoNome;
    public static string TTabelaNome => DBProValoresDicInfo.TabelaNome;
    public static string TTablePrefix => DBProValoresDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBProValoresDicInfo.PrvProcesso, DBProValoresDicInfo.PrvTipoValorProcesso, DBProValoresDicInfo.PrvIndice, DBProValoresDicInfo.PrvIgnorar, DBProValoresDicInfo.PrvData, DBProValoresDicInfo.PrvValorOriginal, DBProValoresDicInfo.PrvPercMulta, DBProValoresDicInfo.PrvValorMulta, DBProValoresDicInfo.PrvPercJuros, DBProValoresDicInfo.PrvValorOriginalCorrigidoIndice, DBProValoresDicInfo.PrvValorMultaCorrigido, DBProValoresDicInfo.PrvValorJurosCorrigido, DBProValoresDicInfo.PrvValorFinal, DBProValoresDicInfo.PrvDataUltimaCorrecao, DBProValoresDicInfo.PrvGUID, DBProValoresDicInfo.PrvQuemCad, DBProValoresDicInfo.PrvDtCad, DBProValoresDicInfo.PrvQuemAtu, DBProValoresDicInfo.PrvDtAtu, DBProValoresDicInfo.PrvVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBProValoresDicInfo.PrvProcesso, DBProValoresDicInfo.PrvTipoValorProcesso, DBProValoresDicInfo.PrvIndice, DBProValoresDicInfo.PrvIgnorar, DBProValoresDicInfo.PrvData, DBProValoresDicInfo.PrvValorOriginal, DBProValoresDicInfo.PrvPercMulta, DBProValoresDicInfo.PrvValorMulta, DBProValoresDicInfo.PrvPercJuros, DBProValoresDicInfo.PrvValorOriginalCorrigidoIndice, DBProValoresDicInfo.PrvValorMultaCorrigido, DBProValoresDicInfo.PrvValorJurosCorrigido, DBProValoresDicInfo.PrvValorFinal, DBProValoresDicInfo.PrvDataUltimaCorrecao, DBProValoresDicInfo.PrvGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "prvCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBProValoresDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "prvCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBProValoresDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
