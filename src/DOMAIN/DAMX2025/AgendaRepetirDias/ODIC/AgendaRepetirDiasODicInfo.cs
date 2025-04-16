#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBAgendaRepetirDiasODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBAgendaRepetirDiasDicInfo.TabelaNome;
    public string ICampoCodigo() => DBAgendaRepetirDiasDicInfo.CampoCodigo;
    public string IPrefixo() => DBAgendaRepetirDiasDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => false;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBAgendaRepetirDiasDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => false;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBAgendaRepetirDiasDicInfo.HoraFinal => DBAgendaRepetirDiasDicInfo.RpdHoraFinal,
        DBAgendaRepetirDiasDicInfo.Master => DBAgendaRepetirDiasDicInfo.RpdMaster,
        DBAgendaRepetirDiasDicInfo.Dia => DBAgendaRepetirDiasDicInfo.RpdDia,
        DBAgendaRepetirDiasDicInfo.Hora => DBAgendaRepetirDiasDicInfo.RpdHora,
        _ => null
    };
    public static string TCampoCodigo => DBAgendaRepetirDiasDicInfo.CampoCodigo;
    public static string TCampoNome => DBAgendaRepetirDiasDicInfo.CampoNome;
    public static string TTabelaNome => DBAgendaRepetirDiasDicInfo.TabelaNome;
    public static string TTablePrefix => DBAgendaRepetirDiasDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBAgendaRepetirDiasDicInfo.RpdHoraFinal, DBAgendaRepetirDiasDicInfo.RpdMaster, DBAgendaRepetirDiasDicInfo.RpdDia, DBAgendaRepetirDiasDicInfo.RpdHora];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBAgendaRepetirDiasDicInfo.RpdHoraFinal, DBAgendaRepetirDiasDicInfo.RpdMaster, DBAgendaRepetirDiasDicInfo.RpdDia, DBAgendaRepetirDiasDicInfo.RpdHora];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "rpdCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBAgendaRepetirDiasDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "rpdCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBAgendaRepetirDiasDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
