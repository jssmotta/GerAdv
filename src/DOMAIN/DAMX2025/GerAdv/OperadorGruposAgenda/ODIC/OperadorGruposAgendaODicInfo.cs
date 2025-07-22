#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBOperadorGruposAgendaODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBOperadorGruposAgendaDicInfo.TabelaNome;
    public string ICampoCodigo() => DBOperadorGruposAgendaDicInfo.CampoCodigo;
    public string IPrefixo() => DBOperadorGruposAgendaDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBOperadorGruposAgendaDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBOperadorGruposAgendaDicInfo.SQLWhere => DBOperadorGruposAgendaDicInfo.GroSQLWhere,
        DBOperadorGruposAgendaDicInfo.Nome => DBOperadorGruposAgendaDicInfo.GroNome,
        DBOperadorGruposAgendaDicInfo.Operador => DBOperadorGruposAgendaDicInfo.GroOperador,
        DBOperadorGruposAgendaDicInfo.GUID => DBOperadorGruposAgendaDicInfo.GroGUID,
        DBOperadorGruposAgendaDicInfo.QuemCad => DBOperadorGruposAgendaDicInfo.GroQuemCad,
        DBOperadorGruposAgendaDicInfo.DtCad => DBOperadorGruposAgendaDicInfo.GroDtCad,
        DBOperadorGruposAgendaDicInfo.QuemAtu => DBOperadorGruposAgendaDicInfo.GroQuemAtu,
        DBOperadorGruposAgendaDicInfo.DtAtu => DBOperadorGruposAgendaDicInfo.GroDtAtu,
        DBOperadorGruposAgendaDicInfo.Visto => DBOperadorGruposAgendaDicInfo.GroVisto,
        _ => null
    };
    public static string TCampoCodigo => DBOperadorGruposAgendaDicInfo.CampoCodigo;
    public static string TCampoNome => DBOperadorGruposAgendaDicInfo.CampoNome;
    public static string TTabelaNome => DBOperadorGruposAgendaDicInfo.TabelaNome;
    public static string TTablePrefix => DBOperadorGruposAgendaDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBOperadorGruposAgendaDicInfo.GroSQLWhere, DBOperadorGruposAgendaDicInfo.GroNome, DBOperadorGruposAgendaDicInfo.GroOperador, DBOperadorGruposAgendaDicInfo.GroGUID, DBOperadorGruposAgendaDicInfo.GroQuemCad, DBOperadorGruposAgendaDicInfo.GroDtCad, DBOperadorGruposAgendaDicInfo.GroQuemAtu, DBOperadorGruposAgendaDicInfo.GroDtAtu, DBOperadorGruposAgendaDicInfo.GroVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBOperadorGruposAgendaDicInfo.GroSQLWhere, DBOperadorGruposAgendaDicInfo.GroNome, DBOperadorGruposAgendaDicInfo.GroOperador, DBOperadorGruposAgendaDicInfo.GroGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "groCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBOperadorGruposAgendaDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "groCodigo",
            "groNome"
        };
        var result = campos.Where(campo => !campo.Equals(DBOperadorGruposAgendaDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
