#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBAgendaRelatorioODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBAgendaRelatorioDicInfo.TabelaNome;
    public string ICampoCodigo() => DBAgendaRelatorioDicInfo.CampoCodigo;
    public string IPrefixo() => DBAgendaRelatorioDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => false;
    public bool HasPersonSex() => false;
    public bool HasNameId() => false;
    public bool IIsStoredProcedureOrView() => true;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBAgendaRelatorioDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => false;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBAgendaRelatorioDicInfo.Data => DBAgendaRelatorioDicInfo.VqaData,
        DBAgendaRelatorioDicInfo.Processo => DBAgendaRelatorioDicInfo.VqaProcesso,
        DBAgendaRelatorioDicInfo.ParaNome => DBAgendaRelatorioDicInfo.XxxParaNome,
        DBAgendaRelatorioDicInfo.ParaPessoas => DBAgendaRelatorioDicInfo.XxxParaPessoas,
        DBAgendaRelatorioDicInfo.BoxAudiencia => DBAgendaRelatorioDicInfo.XxxBoxAudiencia,
        DBAgendaRelatorioDicInfo.BoxAudienciaMobile => DBAgendaRelatorioDicInfo.XxxBoxAudienciaMobile,
        DBAgendaRelatorioDicInfo.NomeAdvogado => DBAgendaRelatorioDicInfo.XxxNomeAdvogado,
        DBAgendaRelatorioDicInfo.NomeForo => DBAgendaRelatorioDicInfo.XxxNomeForo,
        DBAgendaRelatorioDicInfo.NomeJustica => DBAgendaRelatorioDicInfo.XxxNomeJustica,
        DBAgendaRelatorioDicInfo.NomeArea => DBAgendaRelatorioDicInfo.XxxNomeArea,
        _ => null
    };
    public static string TCampoCodigo => DBAgendaRelatorioDicInfo.CampoCodigo;
    public static string TCampoNome => DBAgendaRelatorioDicInfo.CampoNome;
    public static string TTabelaNome => DBAgendaRelatorioDicInfo.TabelaNome;
    public static string TTablePrefix => DBAgendaRelatorioDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBAgendaRelatorioDicInfo.VqaData, DBAgendaRelatorioDicInfo.VqaProcesso, DBAgendaRelatorioDicInfo.XxxParaNome, DBAgendaRelatorioDicInfo.XxxParaPessoas, DBAgendaRelatorioDicInfo.XxxBoxAudiencia, DBAgendaRelatorioDicInfo.XxxBoxAudienciaMobile, DBAgendaRelatorioDicInfo.XxxNomeAdvogado, DBAgendaRelatorioDicInfo.XxxNomeForo, DBAgendaRelatorioDicInfo.XxxNomeJustica, DBAgendaRelatorioDicInfo.XxxNomeArea];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBAgendaRelatorioDicInfo.VqaData, DBAgendaRelatorioDicInfo.VqaProcesso, DBAgendaRelatorioDicInfo.XxxParaNome, DBAgendaRelatorioDicInfo.XxxParaPessoas, DBAgendaRelatorioDicInfo.XxxBoxAudiencia, DBAgendaRelatorioDicInfo.XxxBoxAudienciaMobile, DBAgendaRelatorioDicInfo.XxxNomeAdvogado, DBAgendaRelatorioDicInfo.XxxNomeForo, DBAgendaRelatorioDicInfo.XxxNomeJustica, DBAgendaRelatorioDicInfo.XxxNomeArea];

    public static List<DBInfoSystem> ListPk() => [];
    public static List<DBInfoSystem> ListPkIndices() => [];
}
#endif
