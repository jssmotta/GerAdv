#if (!MenphisSI_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv.DicInfo;
[Serializable]
public partial class DBAgendaSemanaODicInfo : IODicInfo
{
    public List<DBInfoSystem> IListFields() => List;
    public List<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public List<DBInfoSystem> IPkFields() => ListPk();
    public List<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    public string ITabelaNome() => DBAgendaSemanaDicInfo.TabelaNome;
    public string ICampoCodigo() => DBAgendaSemanaDicInfo.CampoCodigo;
    public string IPrefixo() => DBAgendaSemanaDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    public bool HasAuditor() => false;
    public bool HasPersonSex() => false;
    public bool HasNameId() => true;
    public bool IIsStoredProcedureOrView() => true;
#pragma warning restore CA1822 // Mark members as static

    public string ICampoNome() => DBAgendaSemanaDicInfo.CampoNome;
    public string NameSpace() => nameof(GerAdv);
    public bool TemAuditor() => false;
    public bool TemPessoaSexo() => false;
    public DBInfoSystem? GetInfoSystemByNameField(string table) => table switch
    {
        DBAgendaSemanaDicInfo.ParaNome => DBAgendaSemanaDicInfo.XxxParaNome,
        DBAgendaSemanaDicInfo.Data => DBAgendaSemanaDicInfo.XxxData,
        DBAgendaSemanaDicInfo.Funcionario => DBAgendaSemanaDicInfo.XxxFuncionario,
        DBAgendaSemanaDicInfo.Advogado => DBAgendaSemanaDicInfo.XxxAdvogado,
        DBAgendaSemanaDicInfo.Hora => DBAgendaSemanaDicInfo.XxxHora,
        DBAgendaSemanaDicInfo.TipoCompromisso => DBAgendaSemanaDicInfo.XxxTipoCompromisso,
        DBAgendaSemanaDicInfo.Compromisso => DBAgendaSemanaDicInfo.XxxCompromisso,
        DBAgendaSemanaDicInfo.Concluido => DBAgendaSemanaDicInfo.XxxConcluido,
        DBAgendaSemanaDicInfo.Liberado => DBAgendaSemanaDicInfo.XxxLiberado,
        DBAgendaSemanaDicInfo.Importante => DBAgendaSemanaDicInfo.XxxImportante,
        DBAgendaSemanaDicInfo.HoraFinal => DBAgendaSemanaDicInfo.XxxHoraFinal,
        DBAgendaSemanaDicInfo.Nome => DBAgendaSemanaDicInfo.XxxNome,
        DBAgendaSemanaDicInfo.Cliente => DBAgendaSemanaDicInfo.XxxCliente,
        DBAgendaSemanaDicInfo.NomeCliente => DBAgendaSemanaDicInfo.XxxNomeCliente,
        DBAgendaSemanaDicInfo.Tipo => DBAgendaSemanaDicInfo.XxxTipo,
        _ => null
    };
    public static string TCampoCodigo => DBAgendaSemanaDicInfo.CampoCodigo;
    public static string TCampoNome => DBAgendaSemanaDicInfo.CampoNome;
    public static string TTabelaNome => DBAgendaSemanaDicInfo.TabelaNome;
    public static string TTablePrefix => DBAgendaSemanaDicInfo.TablePrefix;
    public static List<DBInfoSystem> List => [DBAgendaSemanaDicInfo.XxxParaNome, DBAgendaSemanaDicInfo.XxxData, DBAgendaSemanaDicInfo.XxxFuncionario, DBAgendaSemanaDicInfo.XxxAdvogado, DBAgendaSemanaDicInfo.XxxHora, DBAgendaSemanaDicInfo.XxxTipoCompromisso, DBAgendaSemanaDicInfo.XxxCompromisso, DBAgendaSemanaDicInfo.XxxConcluido, DBAgendaSemanaDicInfo.XxxLiberado, DBAgendaSemanaDicInfo.XxxImportante, DBAgendaSemanaDicInfo.XxxHoraFinal, DBAgendaSemanaDicInfo.XxxNome, DBAgendaSemanaDicInfo.XxxCliente, DBAgendaSemanaDicInfo.XxxNomeCliente, DBAgendaSemanaDicInfo.XxxTipo];
    public static List<DBInfoSystem> ListWithoutAuditor => [DBAgendaSemanaDicInfo.XxxParaNome, DBAgendaSemanaDicInfo.XxxData, DBAgendaSemanaDicInfo.XxxFuncionario, DBAgendaSemanaDicInfo.XxxAdvogado, DBAgendaSemanaDicInfo.XxxHora, DBAgendaSemanaDicInfo.XxxTipoCompromisso, DBAgendaSemanaDicInfo.XxxCompromisso, DBAgendaSemanaDicInfo.XxxConcluido, DBAgendaSemanaDicInfo.XxxLiberado, DBAgendaSemanaDicInfo.XxxImportante, DBAgendaSemanaDicInfo.XxxHoraFinal, DBAgendaSemanaDicInfo.XxxNome, DBAgendaSemanaDicInfo.XxxCliente, DBAgendaSemanaDicInfo.XxxNomeCliente, DBAgendaSemanaDicInfo.XxxTipo];

    public static List<DBInfoSystem> ListPk() => [];
    public static List<DBInfoSystem> ListPkIndices() => [];
}
#endif
