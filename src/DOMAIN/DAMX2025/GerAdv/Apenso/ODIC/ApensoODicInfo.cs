#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBApensoODicInfo : IODicInfo
{
    public ImmutableArray<DBInfoSystem> IListFields() => List;
    public ImmutableArray<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public ImmutableArray<DBInfoSystem> IPkFields() => ListPk();
    public ImmutableArray<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ITabelaNome() => DBApensoDicInfo.TabelaNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoCodigo() => DBApensoDicInfo.CampoCodigo;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string IPrefixo() => DBApensoDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasAuditor() => true;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasNameId() => false;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoNome() => DBApensoDicInfo.CampoNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string NameSpace() => nameof(GerAdv);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TemAuditor() => true;
    private static readonly FrozenDictionary<string, DBInfoSystem> _fieldLookup = List.ToFrozenDictionary(f => f.FNome, StringComparer.OrdinalIgnoreCase);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DBInfoSystem? GetInfoSystemByNameField(string campo) => _fieldLookup.GetValueOrDefault(campo);
    public static string TCampoCodigo => DBApensoDicInfo.CampoCodigo;
    public static string TCampoNome => DBApensoDicInfo.CampoNome;
    public static string TTabelaNome => DBApensoDicInfo.TabelaNome;
    public static string TTablePrefix => DBApensoDicInfo.TablePrefix;
    public static ImmutableArray<DBInfoSystem> List => [DBApensoDicInfo.ApeProcesso, DBApensoDicInfo.ApeApenso, DBApensoDicInfo.ApeAcao, DBApensoDicInfo.ApeDtDist, DBApensoDicInfo.ApeOBS, DBApensoDicInfo.ApeValorCausa, DBApensoDicInfo.ApeQuemCad, DBApensoDicInfo.ApeDtCad, DBApensoDicInfo.ApeQuemAtu, DBApensoDicInfo.ApeDtAtu, DBApensoDicInfo.ApeVisto];
    public static ImmutableArray<DBInfoSystem> ListWithoutAuditor => [DBApensoDicInfo.ApeProcesso, DBApensoDicInfo.ApeApenso, DBApensoDicInfo.ApeAcao, DBApensoDicInfo.ApeDtDist, DBApensoDicInfo.ApeOBS, DBApensoDicInfo.ApeValorCausa];

    public static ImmutableArray<DBInfoSystem> ListPk()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["apeCodigo"]);
        var result = campos.Where(campo => !campo.Equals(DBApensoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }

    public static ImmutableArray<DBInfoSystem> ListPkIndices()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["apeCodigo"]);
        var result = campos.Where(campo => !campo.Equals(DBApensoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }
}
#endif
