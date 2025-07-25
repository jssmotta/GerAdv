#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBAgendaRecordsODicInfo : IODicInfo
{
    public ImmutableArray<DBInfoSystem> IListFields() => List;
    public ImmutableArray<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public ImmutableArray<DBInfoSystem> IPkFields() => ListPk();
    public ImmutableArray<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ITabelaNome() => DBAgendaRecordsDicInfo.TabelaNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoCodigo() => DBAgendaRecordsDicInfo.CampoCodigo;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string IPrefixo() => DBAgendaRecordsDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasAuditor() => false;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasNameId() => false;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoNome() => DBAgendaRecordsDicInfo.CampoNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string NameSpace() => nameof(GerAdv);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TemAuditor() => false;
    private static readonly FrozenDictionary<string, DBInfoSystem> _fieldLookup = List.ToFrozenDictionary(f => f.FNome, StringComparer.OrdinalIgnoreCase);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DBInfoSystem? GetInfoSystemByNameField(string campo) => _fieldLookup.GetValueOrDefault(campo);
    public static string TCampoCodigo => DBAgendaRecordsDicInfo.CampoCodigo;
    public static string TCampoNome => DBAgendaRecordsDicInfo.CampoNome;
    public static string TTabelaNome => DBAgendaRecordsDicInfo.TabelaNome;
    public static string TTablePrefix => DBAgendaRecordsDicInfo.TablePrefix;
    public static ImmutableArray<DBInfoSystem> List => [DBAgendaRecordsDicInfo.RagAgenda, DBAgendaRecordsDicInfo.RagJulgador, DBAgendaRecordsDicInfo.RagClientesSocios, DBAgendaRecordsDicInfo.RagPerito, DBAgendaRecordsDicInfo.RagColaborador, DBAgendaRecordsDicInfo.RagForo, DBAgendaRecordsDicInfo.RagAviso1, DBAgendaRecordsDicInfo.RagAviso2, DBAgendaRecordsDicInfo.RagAviso3, DBAgendaRecordsDicInfo.RagCrmAviso1, DBAgendaRecordsDicInfo.RagCrmAviso2, DBAgendaRecordsDicInfo.RagCrmAviso3, DBAgendaRecordsDicInfo.RagDataAviso1, DBAgendaRecordsDicInfo.RagDataAviso2, DBAgendaRecordsDicInfo.RagDataAviso3];
    public static ImmutableArray<DBInfoSystem> ListWithoutAuditor => [DBAgendaRecordsDicInfo.RagAgenda, DBAgendaRecordsDicInfo.RagJulgador, DBAgendaRecordsDicInfo.RagClientesSocios, DBAgendaRecordsDicInfo.RagPerito, DBAgendaRecordsDicInfo.RagColaborador, DBAgendaRecordsDicInfo.RagForo, DBAgendaRecordsDicInfo.RagAviso1, DBAgendaRecordsDicInfo.RagAviso2, DBAgendaRecordsDicInfo.RagAviso3, DBAgendaRecordsDicInfo.RagCrmAviso1, DBAgendaRecordsDicInfo.RagCrmAviso2, DBAgendaRecordsDicInfo.RagCrmAviso3, DBAgendaRecordsDicInfo.RagDataAviso1, DBAgendaRecordsDicInfo.RagDataAviso2, DBAgendaRecordsDicInfo.RagDataAviso3];

    public static ImmutableArray<DBInfoSystem> ListPk()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["ragAgenda"]);
        var result = campos.Where(campo => !campo.Equals(DBAgendaRecordsDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }

    public static ImmutableArray<DBInfoSystem> ListPkIndices()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["ragAgenda", "ragCodigo"]);
        var result = campos.Where(campo => !campo.Equals(DBAgendaRecordsDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }
}
#endif
