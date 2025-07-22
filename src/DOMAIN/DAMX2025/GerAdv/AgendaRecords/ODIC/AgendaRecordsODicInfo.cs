#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBAgendaRecordsODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBAgendaRecordsDicInfo.TabelaNome;
    public string ICampoCodigo() => DBAgendaRecordsDicInfo.CampoCodigo;
    public string IPrefixo() => DBAgendaRecordsDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => false;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBAgendaRecordsDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => false;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBAgendaRecordsDicInfo.Agenda => DBAgendaRecordsDicInfo.RagAgenda,
        DBAgendaRecordsDicInfo.Julgador => DBAgendaRecordsDicInfo.RagJulgador,
        DBAgendaRecordsDicInfo.ClientesSocios => DBAgendaRecordsDicInfo.RagClientesSocios,
        DBAgendaRecordsDicInfo.Perito => DBAgendaRecordsDicInfo.RagPerito,
        DBAgendaRecordsDicInfo.Colaborador => DBAgendaRecordsDicInfo.RagColaborador,
        DBAgendaRecordsDicInfo.Foro => DBAgendaRecordsDicInfo.RagForo,
        DBAgendaRecordsDicInfo.Aviso1 => DBAgendaRecordsDicInfo.RagAviso1,
        DBAgendaRecordsDicInfo.Aviso2 => DBAgendaRecordsDicInfo.RagAviso2,
        DBAgendaRecordsDicInfo.Aviso3 => DBAgendaRecordsDicInfo.RagAviso3,
        DBAgendaRecordsDicInfo.CrmAviso1 => DBAgendaRecordsDicInfo.RagCrmAviso1,
        DBAgendaRecordsDicInfo.CrmAviso2 => DBAgendaRecordsDicInfo.RagCrmAviso2,
        DBAgendaRecordsDicInfo.CrmAviso3 => DBAgendaRecordsDicInfo.RagCrmAviso3,
        DBAgendaRecordsDicInfo.DataAviso1 => DBAgendaRecordsDicInfo.RagDataAviso1,
        DBAgendaRecordsDicInfo.DataAviso2 => DBAgendaRecordsDicInfo.RagDataAviso2,
        DBAgendaRecordsDicInfo.DataAviso3 => DBAgendaRecordsDicInfo.RagDataAviso3,
        _ => null
    };
    public static string TCampoCodigo => DBAgendaRecordsDicInfo.CampoCodigo;
    public static string TCampoNome => DBAgendaRecordsDicInfo.CampoNome;
    public static string TTabelaNome => DBAgendaRecordsDicInfo.TabelaNome;
    public static string TTablePrefix => DBAgendaRecordsDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBAgendaRecordsDicInfo.RagAgenda, DBAgendaRecordsDicInfo.RagJulgador, DBAgendaRecordsDicInfo.RagClientesSocios, DBAgendaRecordsDicInfo.RagPerito, DBAgendaRecordsDicInfo.RagColaborador, DBAgendaRecordsDicInfo.RagForo, DBAgendaRecordsDicInfo.RagAviso1, DBAgendaRecordsDicInfo.RagAviso2, DBAgendaRecordsDicInfo.RagAviso3, DBAgendaRecordsDicInfo.RagCrmAviso1, DBAgendaRecordsDicInfo.RagCrmAviso2, DBAgendaRecordsDicInfo.RagCrmAviso3, DBAgendaRecordsDicInfo.RagDataAviso1, DBAgendaRecordsDicInfo.RagDataAviso2, DBAgendaRecordsDicInfo.RagDataAviso3];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBAgendaRecordsDicInfo.RagAgenda, DBAgendaRecordsDicInfo.RagJulgador, DBAgendaRecordsDicInfo.RagClientesSocios, DBAgendaRecordsDicInfo.RagPerito, DBAgendaRecordsDicInfo.RagColaborador, DBAgendaRecordsDicInfo.RagForo, DBAgendaRecordsDicInfo.RagAviso1, DBAgendaRecordsDicInfo.RagAviso2, DBAgendaRecordsDicInfo.RagAviso3, DBAgendaRecordsDicInfo.RagCrmAviso1, DBAgendaRecordsDicInfo.RagCrmAviso2, DBAgendaRecordsDicInfo.RagCrmAviso3, DBAgendaRecordsDicInfo.RagDataAviso1, DBAgendaRecordsDicInfo.RagDataAviso2, DBAgendaRecordsDicInfo.RagDataAviso3];

    public static List<DBInfoSystem> ListPk()
    {
        string[] campos =
        {
            "ragAgenda"
        };
        var result = campos.Where(campo => !campo.Equals(DBAgendaRecordsDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }

    public static List<DBInfoSystem> ListPkIndices()
    {
        string[] campos =
        {
            "ragAgenda",
            "ragCodigo"
        };
        var result = campos.Where(campo => !campo.Equals(DBAgendaRecordsDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result ?? [];
    }
}
#endif
