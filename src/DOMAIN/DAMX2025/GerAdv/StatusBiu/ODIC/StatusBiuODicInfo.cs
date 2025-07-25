#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBStatusBiuODicInfo : IODicInfo
{
    public ImmutableArray<DBInfoSystem> IListFields() => List;
    public ImmutableArray<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public ImmutableArray<DBInfoSystem> IPkFields() => ListPk();
    public ImmutableArray<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ITabelaNome() => DBStatusBiuDicInfo.TabelaNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoCodigo() => DBStatusBiuDicInfo.CampoCodigo;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string IPrefixo() => DBStatusBiuDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasAuditor() => false;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasNameId() => true;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoNome() => DBStatusBiuDicInfo.CampoNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string NameSpace() => nameof(GerAdv);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TemAuditor() => false;
    private static readonly FrozenDictionary<string, DBInfoSystem> _fieldLookup = List.ToFrozenDictionary(f => f.FNome, StringComparer.OrdinalIgnoreCase);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DBInfoSystem? GetInfoSystemByNameField(string campo) => _fieldLookup.GetValueOrDefault(campo);
    public static string TCampoCodigo => DBStatusBiuDicInfo.CampoCodigo;
    public static string TCampoNome => DBStatusBiuDicInfo.CampoNome;
    public static string TTabelaNome => DBStatusBiuDicInfo.TabelaNome;
    public static string TTablePrefix => DBStatusBiuDicInfo.TablePrefix;
    public static ImmutableArray<DBInfoSystem> List => [DBStatusBiuDicInfo.StbNome, DBStatusBiuDicInfo.StbTipoStatusBiu, DBStatusBiuDicInfo.StbOperador, DBStatusBiuDicInfo.StbIcone];
    public static ImmutableArray<DBInfoSystem> ListWithoutAuditor => [DBStatusBiuDicInfo.StbNome, DBStatusBiuDicInfo.StbTipoStatusBiu, DBStatusBiuDicInfo.StbOperador, DBStatusBiuDicInfo.StbIcone];

    public static ImmutableArray<DBInfoSystem> ListPk()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["stbCodigo"]);
        var result = campos.Where(campo => !campo.Equals(DBStatusBiuDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }

    public static ImmutableArray<DBInfoSystem> ListPkIndices()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["stbCodigo"]);
        var result = campos.Where(campo => !campo.Equals(DBStatusBiuDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }
}
#endif
