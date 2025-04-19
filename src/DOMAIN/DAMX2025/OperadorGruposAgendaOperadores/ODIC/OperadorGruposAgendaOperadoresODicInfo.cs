#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBOperadorGruposAgendaOperadoresODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBOperadorGruposAgendaOperadoresDicInfo.TabelaNome;
    public string ICampoCodigo() => DBOperadorGruposAgendaOperadoresDicInfo.CampoCodigo;
    public string IPrefixo() => DBOperadorGruposAgendaOperadoresDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => true;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBOperadorGruposAgendaOperadoresDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => true;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBOperadorGruposAgendaOperadoresDicInfo.OperadorGruposAgenda => DBOperadorGruposAgendaOperadoresDicInfo.OgpOperadorGruposAgenda,
        DBOperadorGruposAgendaOperadoresDicInfo.Operador => DBOperadorGruposAgendaOperadoresDicInfo.OgpOperador,
        DBOperadorGruposAgendaOperadoresDicInfo.GUID => DBOperadorGruposAgendaOperadoresDicInfo.OgpGUID,
        DBOperadorGruposAgendaOperadoresDicInfo.QuemCad => DBOperadorGruposAgendaOperadoresDicInfo.OgpQuemCad,
        DBOperadorGruposAgendaOperadoresDicInfo.DtCad => DBOperadorGruposAgendaOperadoresDicInfo.OgpDtCad,
        DBOperadorGruposAgendaOperadoresDicInfo.QuemAtu => DBOperadorGruposAgendaOperadoresDicInfo.OgpQuemAtu,
        DBOperadorGruposAgendaOperadoresDicInfo.DtAtu => DBOperadorGruposAgendaOperadoresDicInfo.OgpDtAtu,
        DBOperadorGruposAgendaOperadoresDicInfo.Visto => DBOperadorGruposAgendaOperadoresDicInfo.OgpVisto,
        _ => null
    };
    public static string TCampoCodigo => DBOperadorGruposAgendaOperadoresDicInfo.CampoCodigo;
    public static string TCampoNome => DBOperadorGruposAgendaOperadoresDicInfo.CampoNome;
    public static string TTabelaNome => DBOperadorGruposAgendaOperadoresDicInfo.TabelaNome;
    public static string TTablePrefix => DBOperadorGruposAgendaOperadoresDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBOperadorGruposAgendaOperadoresDicInfo.OgpOperadorGruposAgenda, DBOperadorGruposAgendaOperadoresDicInfo.OgpOperador, DBOperadorGruposAgendaOperadoresDicInfo.OgpGUID, DBOperadorGruposAgendaOperadoresDicInfo.OgpQuemCad, DBOperadorGruposAgendaOperadoresDicInfo.OgpDtCad, DBOperadorGruposAgendaOperadoresDicInfo.OgpQuemAtu, DBOperadorGruposAgendaOperadoresDicInfo.OgpDtAtu, DBOperadorGruposAgendaOperadoresDicInfo.OgpVisto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBOperadorGruposAgendaOperadoresDicInfo.OgpOperadorGruposAgenda, DBOperadorGruposAgendaOperadoresDicInfo.OgpOperador, DBOperadorGruposAgendaOperadoresDicInfo.OgpGUID];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "ogpOperador",
            "ogpOperadorGruposAgenda"
        };
        var result = campos.Where(campo => !campo.Equals(DBOperadorGruposAgendaOperadoresDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "ogpCodigo",
            "ogpOperador",
            "ogpOperadorGruposAgenda"
        };
        var result = campos.Where(campo => !campo.Equals(DBOperadorGruposAgendaOperadoresDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
