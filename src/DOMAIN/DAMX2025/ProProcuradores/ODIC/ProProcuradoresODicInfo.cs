#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBProProcuradoresODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBProProcuradoresDicInfo.TabelaNome;
    public string ICampoCodigo() => DBProProcuradoresDicInfo.CampoCodigo;
    public string IPrefixo() => DBProProcuradoresDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBProProcuradoresDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBProProcuradoresDicInfo.Advogado => DBProProcuradoresDicInfo.PapAdvogado,
        DBProProcuradoresDicInfo.Nome => DBProProcuradoresDicInfo.PapNome,
        DBProProcuradoresDicInfo.Processo => DBProProcuradoresDicInfo.PapProcesso,
        DBProProcuradoresDicInfo.Data => DBProProcuradoresDicInfo.PapData,
        DBProProcuradoresDicInfo.Substabelecimento => DBProProcuradoresDicInfo.PapSubstabelecimento,
        DBProProcuradoresDicInfo.Procuracao => DBProProcuradoresDicInfo.PapProcuracao,
        DBProProcuradoresDicInfo.Bold => DBProProcuradoresDicInfo.PapBold,
        DBProProcuradoresDicInfo.GUID => DBProProcuradoresDicInfo.PapGUID,
        DBProProcuradoresDicInfo.QuemCad => DBProProcuradoresDicInfo.PapQuemCad,
        DBProProcuradoresDicInfo.DtCad => DBProProcuradoresDicInfo.PapDtCad,
        DBProProcuradoresDicInfo.QuemAtu => DBProProcuradoresDicInfo.PapQuemAtu,
        DBProProcuradoresDicInfo.DtAtu => DBProProcuradoresDicInfo.PapDtAtu,
        DBProProcuradoresDicInfo.Visto => DBProProcuradoresDicInfo.PapVisto,
        _ => null
    };
    public static string TCampoCodigo => DBProProcuradoresDicInfo.CampoCodigo;
    public static string TCampoNome => DBProProcuradoresDicInfo.CampoNome;
    public static string TTabelaNome => DBProProcuradoresDicInfo.TabelaNome;
    public static string TTablePrefix => DBProProcuradoresDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBProProcuradoresDicInfo.PapAdvogado, DBProProcuradoresDicInfo.PapNome, DBProProcuradoresDicInfo.PapProcesso, DBProProcuradoresDicInfo.PapData, DBProProcuradoresDicInfo.PapSubstabelecimento, DBProProcuradoresDicInfo.PapProcuracao, DBProProcuradoresDicInfo.PapBold, DBProProcuradoresDicInfo.PapGUID, DBProProcuradoresDicInfo.PapQuemCad, DBProProcuradoresDicInfo.PapDtCad, DBProProcuradoresDicInfo.PapQuemAtu, DBProProcuradoresDicInfo.PapDtAtu, DBProProcuradoresDicInfo.PapVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBProProcuradoresDicInfo.PapAdvogado, DBProProcuradoresDicInfo.PapNome, DBProProcuradoresDicInfo.PapProcesso, DBProProcuradoresDicInfo.PapData, DBProProcuradoresDicInfo.PapSubstabelecimento, DBProProcuradoresDicInfo.PapProcuracao, DBProProcuradoresDicInfo.PapBold];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "papCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBProProcuradoresDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "papAdvogado",
            "papCodigo",
            "papData",
            "papNome",
            "papProcesso"
        };
        var result = campos.Where(campo => !campo.Equals(DBProProcuradoresDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
