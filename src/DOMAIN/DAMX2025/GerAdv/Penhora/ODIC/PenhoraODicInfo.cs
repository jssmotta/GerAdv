#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBPenhoraODicInfo : IODicInfo
{
    public ImmutableArray<DBInfoSystem> IListFields() => List;
    public ImmutableArray<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public ImmutableArray<DBInfoSystem> IPkFields() => ListPk();
    public ImmutableArray<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ITabelaNome() => DBPenhoraDicInfo.TabelaNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoCodigo() => DBPenhoraDicInfo.CampoCodigo;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string IPrefixo() => DBPenhoraDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasAuditor() => true;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasNameId() => true;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoNome() => DBPenhoraDicInfo.CampoNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string NameSpace() => nameof(GerAdv);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TemAuditor() => true;
    private static readonly FrozenDictionary<string, DBInfoSystem> _fieldLookup = List.ToFrozenDictionary(f => f.FNome, StringComparer.OrdinalIgnoreCase);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DBInfoSystem? GetInfoSystemByNameField(string campo) => _fieldLookup.GetValueOrDefault(campo);
    public static string TCampoCodigo => DBPenhoraDicInfo.CampoCodigo;
    public static string TCampoNome => DBPenhoraDicInfo.CampoNome;
    public static string TTabelaNome => DBPenhoraDicInfo.TabelaNome;
    public static string TTablePrefix => DBPenhoraDicInfo.TablePrefix;
    public static ImmutableArray<DBInfoSystem> List => [DBPenhoraDicInfo.PhrProcesso, DBPenhoraDicInfo.PhrNome, DBPenhoraDicInfo.PhrDescricao, DBPenhoraDicInfo.PhrDataPenhora, DBPenhoraDicInfo.PhrPenhoraStatus, DBPenhoraDicInfo.PhrMaster, DBPenhoraDicInfo.PhrGUID, DBPenhoraDicInfo.PhrQuemCad, DBPenhoraDicInfo.PhrDtCad, DBPenhoraDicInfo.PhrQuemAtu, DBPenhoraDicInfo.PhrDtAtu, DBPenhoraDicInfo.PhrVisto];
    public static ImmutableArray<DBInfoSystem> ListWithoutAuditor => [DBPenhoraDicInfo.PhrProcesso, DBPenhoraDicInfo.PhrNome, DBPenhoraDicInfo.PhrDescricao, DBPenhoraDicInfo.PhrDataPenhora, DBPenhoraDicInfo.PhrPenhoraStatus, DBPenhoraDicInfo.PhrMaster, DBPenhoraDicInfo.PhrGUID];

    public static ImmutableArray<DBInfoSystem> ListPk()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["phrCodigo"]);
        var result = campos.Where(campo => !campo.Equals(DBPenhoraDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }

    public static ImmutableArray<DBInfoSystem> ListPkIndices()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["phrCodigo"]);
        var result = campos.Where(campo => !campo.Equals(DBPenhoraDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }
}
#endif
