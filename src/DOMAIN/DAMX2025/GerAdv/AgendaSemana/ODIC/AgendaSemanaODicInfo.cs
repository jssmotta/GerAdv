#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBAgendaSemanaODicInfo : IODicInfo
{
    public ImmutableArray<DBInfoSystem> IListFields() => List;
    public ImmutableArray<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public ImmutableArray<DBInfoSystem> IPkFields() => ListPk();
    public ImmutableArray<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ITabelaNome() => DBAgendaSemanaDicInfo.TabelaNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoCodigo() => DBAgendaSemanaDicInfo.CampoCodigo;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string IPrefixo() => DBAgendaSemanaDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasAuditor() => false;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasNameId() => true;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IIsStoredProcedureOrView() => true;
#pragma warning restore CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoNome() => DBAgendaSemanaDicInfo.CampoNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string NameSpace() => nameof(GerAdv);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TemAuditor() => false;
    private static readonly FrozenDictionary<string, DBInfoSystem> _fieldLookup = List.ToFrozenDictionary(f => f.FNome, StringComparer.OrdinalIgnoreCase);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DBInfoSystem? GetInfoSystemByNameField(string campo) => _fieldLookup.GetValueOrDefault(campo);
    public static string TCampoCodigo => DBAgendaSemanaDicInfo.CampoCodigo;
    public static string TCampoNome => DBAgendaSemanaDicInfo.CampoNome;
    public static string TTabelaNome => DBAgendaSemanaDicInfo.TabelaNome;
    public static string TTablePrefix => DBAgendaSemanaDicInfo.TablePrefix;
    public static ImmutableArray<DBInfoSystem> List => [DBAgendaSemanaDicInfo.XxxParaNome, DBAgendaSemanaDicInfo.XxxData, DBAgendaSemanaDicInfo.XxxFuncionario, DBAgendaSemanaDicInfo.XxxAdvogado, DBAgendaSemanaDicInfo.XxxHora, DBAgendaSemanaDicInfo.XxxTipoCompromisso, DBAgendaSemanaDicInfo.XxxCompromisso, DBAgendaSemanaDicInfo.XxxConcluido, DBAgendaSemanaDicInfo.XxxLiberado, DBAgendaSemanaDicInfo.XxxImportante, DBAgendaSemanaDicInfo.XxxHoraFinal, DBAgendaSemanaDicInfo.XxxNome, DBAgendaSemanaDicInfo.XxxCliente, DBAgendaSemanaDicInfo.XxxNomeCliente, DBAgendaSemanaDicInfo.XxxTipo];
    public static ImmutableArray<DBInfoSystem> ListWithoutAuditor => [DBAgendaSemanaDicInfo.XxxParaNome, DBAgendaSemanaDicInfo.XxxData, DBAgendaSemanaDicInfo.XxxFuncionario, DBAgendaSemanaDicInfo.XxxAdvogado, DBAgendaSemanaDicInfo.XxxHora, DBAgendaSemanaDicInfo.XxxTipoCompromisso, DBAgendaSemanaDicInfo.XxxCompromisso, DBAgendaSemanaDicInfo.XxxConcluido, DBAgendaSemanaDicInfo.XxxLiberado, DBAgendaSemanaDicInfo.XxxImportante, DBAgendaSemanaDicInfo.XxxHoraFinal, DBAgendaSemanaDicInfo.XxxNome, DBAgendaSemanaDicInfo.XxxCliente, DBAgendaSemanaDicInfo.XxxNomeCliente, DBAgendaSemanaDicInfo.XxxTipo];

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ImmutableArray<DBInfoSystem> ListPk() => [];
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ImmutableArray<DBInfoSystem> ListPkIndices() => [];
}
#endif
