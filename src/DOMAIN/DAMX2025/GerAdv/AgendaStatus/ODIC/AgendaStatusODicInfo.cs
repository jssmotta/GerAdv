#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBAgendaStatusODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBAgendaStatusDicInfo.TabelaNome;
    public string ICampoCodigo() => DBAgendaStatusDicInfo.CampoCodigo;
    public string IPrefixo() => DBAgendaStatusDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBAgendaStatusDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBAgendaStatusDicInfo.Agenda => DBAgendaStatusDicInfo.AstAgenda,
        DBAgendaStatusDicInfo.Completed => DBAgendaStatusDicInfo.AstCompleted,
        DBAgendaStatusDicInfo.QuemCad => DBAgendaStatusDicInfo.AstQuemCad,
        DBAgendaStatusDicInfo.DtCad => DBAgendaStatusDicInfo.AstDtCad,
        DBAgendaStatusDicInfo.QuemAtu => DBAgendaStatusDicInfo.AstQuemAtu,
        DBAgendaStatusDicInfo.DtAtu => DBAgendaStatusDicInfo.AstDtAtu,
        DBAgendaStatusDicInfo.Visto => DBAgendaStatusDicInfo.AstVisto,
        _ => null
    };
    public static string TCampoCodigo => DBAgendaStatusDicInfo.CampoCodigo;
    public static string TCampoNome => DBAgendaStatusDicInfo.CampoNome;
    public static string TTabelaNome => DBAgendaStatusDicInfo.TabelaNome;
    public static string TTablePrefix => DBAgendaStatusDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBAgendaStatusDicInfo.AstAgenda, DBAgendaStatusDicInfo.AstCompleted, DBAgendaStatusDicInfo.AstQuemCad, DBAgendaStatusDicInfo.AstDtCad, DBAgendaStatusDicInfo.AstQuemAtu, DBAgendaStatusDicInfo.AstDtAtu, DBAgendaStatusDicInfo.AstVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBAgendaStatusDicInfo.AstAgenda, DBAgendaStatusDicInfo.AstCompleted];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "astCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBAgendaStatusDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "astAgenda",
            "astCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBAgendaStatusDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
