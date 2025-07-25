#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBPrecatoriaODicInfo : IODicInfo
{
    public ImmutableArray<DBInfoSystem> IListFields() => List;
    public ImmutableArray<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public ImmutableArray<DBInfoSystem> IPkFields() => ListPk();
    public ImmutableArray<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ITabelaNome() => DBPrecatoriaDicInfo.TabelaNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoCodigo() => DBPrecatoriaDicInfo.CampoCodigo;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string IPrefixo() => DBPrecatoriaDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasAuditor() => true;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasNameId() => false;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoNome() => DBPrecatoriaDicInfo.CampoNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string NameSpace() => nameof(GerAdv);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TemAuditor() => true;
    private static readonly FrozenDictionary<string, DBInfoSystem> _fieldLookup = List.ToFrozenDictionary(f => f.FNome, StringComparer.OrdinalIgnoreCase);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DBInfoSystem? GetInfoSystemByNameField(string campo) => _fieldLookup.GetValueOrDefault(campo);
    public static string TCampoCodigo => DBPrecatoriaDicInfo.CampoCodigo;
    public static string TCampoNome => DBPrecatoriaDicInfo.CampoNome;
    public static string TTabelaNome => DBPrecatoriaDicInfo.TabelaNome;
    public static string TTablePrefix => DBPrecatoriaDicInfo.TablePrefix;
    public static ImmutableArray<DBInfoSystem> List => [DBPrecatoriaDicInfo.PreDtDist, DBPrecatoriaDicInfo.PreProcesso, DBPrecatoriaDicInfo.PrePrecatoria, DBPrecatoriaDicInfo.PreDeprecante, DBPrecatoriaDicInfo.PreDeprecado, DBPrecatoriaDicInfo.PreOBS, DBPrecatoriaDicInfo.PreBold, DBPrecatoriaDicInfo.PreGUID, DBPrecatoriaDicInfo.PreQuemCad, DBPrecatoriaDicInfo.PreDtCad, DBPrecatoriaDicInfo.PreQuemAtu, DBPrecatoriaDicInfo.PreDtAtu, DBPrecatoriaDicInfo.PreVisto];
    public static ImmutableArray<DBInfoSystem> ListWithoutAuditor => [DBPrecatoriaDicInfo.PreDtDist, DBPrecatoriaDicInfo.PreProcesso, DBPrecatoriaDicInfo.PrePrecatoria, DBPrecatoriaDicInfo.PreDeprecante, DBPrecatoriaDicInfo.PreDeprecado, DBPrecatoriaDicInfo.PreOBS, DBPrecatoriaDicInfo.PreGUID];

    public static ImmutableArray<DBInfoSystem> ListPk()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["preCodigo"]);
        var result = campos.Where(campo => !campo.Equals(DBPrecatoriaDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }

    public static ImmutableArray<DBInfoSystem> ListPkIndices()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["preCodigo"]);
        var result = campos.Where(campo => !campo.Equals(DBPrecatoriaDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }
}
#endif
