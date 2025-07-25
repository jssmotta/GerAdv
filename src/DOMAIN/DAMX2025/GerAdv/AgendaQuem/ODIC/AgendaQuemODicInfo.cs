#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBAgendaQuemODicInfo : IODicInfo
{
    public ImmutableArray<DBInfoSystem> IListFields() => List;
    public ImmutableArray<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public ImmutableArray<DBInfoSystem> IPkFields() => ListPk();
    public ImmutableArray<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ITabelaNome() => DBAgendaQuemDicInfo.TabelaNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoCodigo() => DBAgendaQuemDicInfo.CampoCodigo;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string IPrefixo() => DBAgendaQuemDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasAuditor() => false;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasNameId() => false;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoNome() => DBAgendaQuemDicInfo.CampoNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string NameSpace() => nameof(GerAdv);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TemAuditor() => false;
    private static readonly FrozenDictionary<string, DBInfoSystem> _fieldLookup = List.ToFrozenDictionary(f => f.FNome, StringComparer.OrdinalIgnoreCase);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DBInfoSystem? GetInfoSystemByNameField(string campo) => _fieldLookup.GetValueOrDefault(campo);
    public static string TCampoCodigo => DBAgendaQuemDicInfo.CampoCodigo;
    public static string TCampoNome => DBAgendaQuemDicInfo.CampoNome;
    public static string TTabelaNome => DBAgendaQuemDicInfo.TabelaNome;
    public static string TTablePrefix => DBAgendaQuemDicInfo.TablePrefix;
    public static ImmutableArray<DBInfoSystem> List => [DBAgendaQuemDicInfo.AgqIDAgenda, DBAgendaQuemDicInfo.AgqAdvogado, DBAgendaQuemDicInfo.AgqFuncionario, DBAgendaQuemDicInfo.AgqPreposto];
    public static ImmutableArray<DBInfoSystem> ListWithoutAuditor => [DBAgendaQuemDicInfo.AgqIDAgenda, DBAgendaQuemDicInfo.AgqAdvogado, DBAgendaQuemDicInfo.AgqFuncionario, DBAgendaQuemDicInfo.AgqPreposto];

    public static ImmutableArray<DBInfoSystem> ListPk()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["agqCodigo"]);
        var result = campos.Where(campo => !campo.Equals(DBAgendaQuemDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }

    public static ImmutableArray<DBInfoSystem> ListPkIndices()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["agqCodigo"]);
        var result = campos.Where(campo => !campo.Equals(DBAgendaQuemDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }
}
#endif
