#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBEMPClassRiscosODicInfo : IODicInfo
{
    public ImmutableArray<DBInfoSystem> IListFields() => List;
    public ImmutableArray<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public ImmutableArray<DBInfoSystem> IPkFields() => ListPk();
    public ImmutableArray<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ITabelaNome() => DBEMPClassRiscosDicInfo.TabelaNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoCodigo() => DBEMPClassRiscosDicInfo.CampoCodigo;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string IPrefixo() => DBEMPClassRiscosDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasAuditor() => true;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasNameId() => true;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoNome() => DBEMPClassRiscosDicInfo.CampoNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string NameSpace() => nameof(GerAdv);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TemAuditor() => true;
    private static readonly FrozenDictionary<string, DBInfoSystem> _fieldLookup = List.ToFrozenDictionary(f => f.FNome, StringComparer.OrdinalIgnoreCase);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DBInfoSystem? GetInfoSystemByNameField(string campo) => _fieldLookup.GetValueOrDefault(campo);
    public static string TCampoCodigo => DBEMPClassRiscosDicInfo.CampoCodigo;
    public static string TCampoNome => DBEMPClassRiscosDicInfo.CampoNome;
    public static string TTabelaNome => DBEMPClassRiscosDicInfo.TabelaNome;
    public static string TTablePrefix => DBEMPClassRiscosDicInfo.TablePrefix;
    public static ImmutableArray<DBInfoSystem> List => [DBEMPClassRiscosDicInfo.EcrNome, DBEMPClassRiscosDicInfo.EcrBold, DBEMPClassRiscosDicInfo.EcrGUID, DBEMPClassRiscosDicInfo.EcrQuemCad, DBEMPClassRiscosDicInfo.EcrDtCad, DBEMPClassRiscosDicInfo.EcrQuemAtu, DBEMPClassRiscosDicInfo.EcrDtAtu, DBEMPClassRiscosDicInfo.EcrVisto];
    public static ImmutableArray<DBInfoSystem> ListWithoutAuditor => [DBEMPClassRiscosDicInfo.EcrNome, DBEMPClassRiscosDicInfo.EcrGUID];

    public static ImmutableArray<DBInfoSystem> ListPk()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["ecrCodigo"]);
        var result = campos.Where(campo => !campo.Equals(DBEMPClassRiscosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }

    public static ImmutableArray<DBInfoSystem> ListPkIndices()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["ecrCodigo"]);
        var result = campos.Where(campo => !campo.Equals(DBEMPClassRiscosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }
}
#endif
