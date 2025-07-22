#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBAgendaQuemODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBAgendaQuemDicInfo.TabelaNome;
    public string ICampoCodigo() => DBAgendaQuemDicInfo.CampoCodigo;
    public string IPrefixo() => DBAgendaQuemDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => false;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBAgendaQuemDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => false;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBAgendaQuemDicInfo.IDAgenda => DBAgendaQuemDicInfo.AgqIDAgenda,
        DBAgendaQuemDicInfo.Advogado => DBAgendaQuemDicInfo.AgqAdvogado,
        DBAgendaQuemDicInfo.Funcionario => DBAgendaQuemDicInfo.AgqFuncionario,
        DBAgendaQuemDicInfo.Preposto => DBAgendaQuemDicInfo.AgqPreposto,
        _ => null
    };
    public static string TCampoCodigo => DBAgendaQuemDicInfo.CampoCodigo;
    public static string TCampoNome => DBAgendaQuemDicInfo.CampoNome;
    public static string TTabelaNome => DBAgendaQuemDicInfo.TabelaNome;
    public static string TTablePrefix => DBAgendaQuemDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBAgendaQuemDicInfo.AgqIDAgenda, DBAgendaQuemDicInfo.AgqAdvogado, DBAgendaQuemDicInfo.AgqFuncionario, DBAgendaQuemDicInfo.AgqPreposto];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBAgendaQuemDicInfo.AgqIDAgenda, DBAgendaQuemDicInfo.AgqAdvogado, DBAgendaQuemDicInfo.AgqFuncionario, DBAgendaQuemDicInfo.AgqPreposto];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "agqCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBAgendaQuemDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "agqCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBAgendaQuemDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
