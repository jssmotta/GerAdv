#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBProBarCODEODicInfo : IODicInfo
{
    public ImmutableArray<DBInfoSystem> IListFields() => List;
    public ImmutableArray<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public ImmutableArray<DBInfoSystem> IPkFields() => ListPk();
    public ImmutableArray<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ITabelaNome() => DBProBarCODEDicInfo.TabelaNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoCodigo() => DBProBarCODEDicInfo.CampoCodigo;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string IPrefixo() => DBProBarCODEDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasAuditor() => true;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasNameId() => false;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoNome() => DBProBarCODEDicInfo.CampoNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string NameSpace() => nameof(GerAdv);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TemAuditor() => true;
    private static readonly FrozenDictionary<string, DBInfoSystem> _fieldLookup = List.ToFrozenDictionary(f => f.FNome, StringComparer.OrdinalIgnoreCase);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DBInfoSystem? GetInfoSystemByNameField(string campo) => _fieldLookup.GetValueOrDefault(campo);
    public static string TCampoCodigo => DBProBarCODEDicInfo.CampoCodigo;
    public static string TCampoNome => DBProBarCODEDicInfo.CampoNome;
    public static string TTabelaNome => DBProBarCODEDicInfo.TabelaNome;
    public static string TTablePrefix => DBProBarCODEDicInfo.TablePrefix;
    public static ImmutableArray<DBInfoSystem> List => [DBProBarCODEDicInfo.PbcBarCODE, DBProBarCODEDicInfo.PbcProcesso, DBProBarCODEDicInfo.PbcQuemCad, DBProBarCODEDicInfo.PbcDtCad, DBProBarCODEDicInfo.PbcQuemAtu, DBProBarCODEDicInfo.PbcDtAtu, DBProBarCODEDicInfo.PbcVisto];
    public static ImmutableArray<DBInfoSystem> ListWithoutAuditor => [DBProBarCODEDicInfo.PbcBarCODE, DBProBarCODEDicInfo.PbcProcesso];

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ImmutableArray<DBInfoSystem> ListPk() => [];
    public static ImmutableArray<DBInfoSystem> ListPkIndices()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["pbcBarCODE", "pbcProcesso"]);
        var result = campos.Where(campo => !campo.Equals(DBProBarCODEDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }
}
#endif
