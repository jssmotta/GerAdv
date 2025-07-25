#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBAlarmSMSODicInfo : IODicInfo
{
    public ImmutableArray<DBInfoSystem> IListFields() => List;
    public ImmutableArray<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public ImmutableArray<DBInfoSystem> IPkFields() => ListPk();
    public ImmutableArray<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ITabelaNome() => DBAlarmSMSDicInfo.TabelaNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoCodigo() => DBAlarmSMSDicInfo.CampoCodigo;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string IPrefixo() => DBAlarmSMSDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasAuditor() => true;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasNameId() => true;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoNome() => DBAlarmSMSDicInfo.CampoNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string NameSpace() => nameof(GerAdv);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TemAuditor() => true;
    private static readonly FrozenDictionary<string, DBInfoSystem> _fieldLookup = List.ToFrozenDictionary(f => f.FNome, StringComparer.OrdinalIgnoreCase);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DBInfoSystem? GetInfoSystemByNameField(string campo) => _fieldLookup.GetValueOrDefault(campo);
    public static string TCampoCodigo => DBAlarmSMSDicInfo.CampoCodigo;
    public static string TCampoNome => DBAlarmSMSDicInfo.CampoNome;
    public static string TTabelaNome => DBAlarmSMSDicInfo.TabelaNome;
    public static string TTablePrefix => DBAlarmSMSDicInfo.TablePrefix;
    public static ImmutableArray<DBInfoSystem> List => [DBAlarmSMSDicInfo.AlrDescricao, DBAlarmSMSDicInfo.AlrHora, DBAlarmSMSDicInfo.AlrMinuto, DBAlarmSMSDicInfo.AlrD1, DBAlarmSMSDicInfo.AlrD2, DBAlarmSMSDicInfo.AlrD3, DBAlarmSMSDicInfo.AlrD4, DBAlarmSMSDicInfo.AlrD5, DBAlarmSMSDicInfo.AlrD6, DBAlarmSMSDicInfo.AlrD7, DBAlarmSMSDicInfo.AlrEMail, DBAlarmSMSDicInfo.AlrDesativar, DBAlarmSMSDicInfo.AlrToday, DBAlarmSMSDicInfo.AlrExcetoDiasFelizes, DBAlarmSMSDicInfo.AlrDesktop, DBAlarmSMSDicInfo.AlrAlertarDataHora, DBAlarmSMSDicInfo.AlrOperador, DBAlarmSMSDicInfo.AlrGuidExo, DBAlarmSMSDicInfo.AlrAgenda, DBAlarmSMSDicInfo.AlrRecado, DBAlarmSMSDicInfo.AlrEmocao, DBAlarmSMSDicInfo.AlrGUID, DBAlarmSMSDicInfo.AlrQuemCad, DBAlarmSMSDicInfo.AlrDtCad, DBAlarmSMSDicInfo.AlrQuemAtu, DBAlarmSMSDicInfo.AlrDtAtu, DBAlarmSMSDicInfo.AlrVisto];
    public static ImmutableArray<DBInfoSystem> ListWithoutAuditor => [DBAlarmSMSDicInfo.AlrDescricao, DBAlarmSMSDicInfo.AlrHora, DBAlarmSMSDicInfo.AlrMinuto, DBAlarmSMSDicInfo.AlrD1, DBAlarmSMSDicInfo.AlrD2, DBAlarmSMSDicInfo.AlrD3, DBAlarmSMSDicInfo.AlrD4, DBAlarmSMSDicInfo.AlrD5, DBAlarmSMSDicInfo.AlrD6, DBAlarmSMSDicInfo.AlrD7, DBAlarmSMSDicInfo.AlrEMail, DBAlarmSMSDicInfo.AlrDesativar, DBAlarmSMSDicInfo.AlrToday, DBAlarmSMSDicInfo.AlrExcetoDiasFelizes, DBAlarmSMSDicInfo.AlrDesktop, DBAlarmSMSDicInfo.AlrAlertarDataHora, DBAlarmSMSDicInfo.AlrOperador, DBAlarmSMSDicInfo.AlrGuidExo, DBAlarmSMSDicInfo.AlrAgenda, DBAlarmSMSDicInfo.AlrRecado, DBAlarmSMSDicInfo.AlrEmocao, DBAlarmSMSDicInfo.AlrGUID];

    public static ImmutableArray<DBInfoSystem> ListPk()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["alrCodigo"]);
        var result = campos.Where(campo => !campo.Equals(DBAlarmSMSDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }

    public static ImmutableArray<DBInfoSystem> ListPkIndices()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["alrCodigo"]);
        var result = campos.Where(campo => !campo.Equals(DBAlarmSMSDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }
}
#endif
