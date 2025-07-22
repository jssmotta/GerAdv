#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBAgenda2AgendaODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBAgenda2AgendaDicInfo.TabelaNome;
    public string ICampoCodigo() => DBAgenda2AgendaDicInfo.CampoCodigo;
    public string IPrefixo() => DBAgenda2AgendaDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBAgenda2AgendaDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBAgenda2AgendaDicInfo.Master => DBAgenda2AgendaDicInfo.Ag2Master,
        DBAgenda2AgendaDicInfo.Agenda => DBAgenda2AgendaDicInfo.Ag2Agenda,
        DBAgenda2AgendaDicInfo.QuemCad => DBAgenda2AgendaDicInfo.Ag2QuemCad,
        DBAgenda2AgendaDicInfo.DtCad => DBAgenda2AgendaDicInfo.Ag2DtCad,
        DBAgenda2AgendaDicInfo.QuemAtu => DBAgenda2AgendaDicInfo.Ag2QuemAtu,
        DBAgenda2AgendaDicInfo.DtAtu => DBAgenda2AgendaDicInfo.Ag2DtAtu,
        DBAgenda2AgendaDicInfo.Visto => DBAgenda2AgendaDicInfo.Ag2Visto,
        _ => null
    };
    public static string TCampoCodigo => DBAgenda2AgendaDicInfo.CampoCodigo;
    public static string TCampoNome => DBAgenda2AgendaDicInfo.CampoNome;
    public static string TTabelaNome => DBAgenda2AgendaDicInfo.TabelaNome;
    public static string TTablePrefix => DBAgenda2AgendaDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBAgenda2AgendaDicInfo.Ag2Master, DBAgenda2AgendaDicInfo.Ag2Agenda, DBAgenda2AgendaDicInfo.Ag2QuemCad, DBAgenda2AgendaDicInfo.Ag2DtCad, DBAgenda2AgendaDicInfo.Ag2QuemAtu, DBAgenda2AgendaDicInfo.Ag2DtAtu, DBAgenda2AgendaDicInfo.Ag2Visto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBAgenda2AgendaDicInfo.Ag2Master, DBAgenda2AgendaDicInfo.Ag2Agenda];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "ag2Codigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBAgenda2AgendaDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "ag2Agenda",
            "ag2Codigo",
            "ag2Master"
        };
        var result = campos.Where(campo => !campo.Equals(DBAgenda2AgendaDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
