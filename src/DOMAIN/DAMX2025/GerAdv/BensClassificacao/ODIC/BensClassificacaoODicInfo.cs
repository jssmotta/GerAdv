#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBBensClassificacaoODicInfo : IODicInfo
{
    public ImmutableArray<DBInfoSystem> IListFields() => List;
    public ImmutableArray<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public ImmutableArray<DBInfoSystem> IPkFields() => ListPk();
    public ImmutableArray<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ITabelaNome() => DBBensClassificacaoDicInfo.TabelaNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoCodigo() => DBBensClassificacaoDicInfo.CampoCodigo;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string IPrefixo() => DBBensClassificacaoDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasAuditor() => true;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasNameId() => true;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoNome() => DBBensClassificacaoDicInfo.CampoNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string NameSpace() => nameof(GerAdv);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TemAuditor() => true;
    private static readonly FrozenDictionary<string, DBInfoSystem> _fieldLookup = List.ToFrozenDictionary(f => f.FNome, StringComparer.OrdinalIgnoreCase);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DBInfoSystem? GetInfoSystemByNameField(string campo) => _fieldLookup.GetValueOrDefault(campo);
    public static string TCampoCodigo => DBBensClassificacaoDicInfo.CampoCodigo;
    public static string TCampoNome => DBBensClassificacaoDicInfo.CampoNome;
    public static string TTabelaNome => DBBensClassificacaoDicInfo.TabelaNome;
    public static string TTablePrefix => DBBensClassificacaoDicInfo.TablePrefix;
    public static ImmutableArray<DBInfoSystem> List => [DBBensClassificacaoDicInfo.BcsNome, DBBensClassificacaoDicInfo.BcsBold, DBBensClassificacaoDicInfo.BcsGUID, DBBensClassificacaoDicInfo.BcsQuemCad, DBBensClassificacaoDicInfo.BcsDtCad, DBBensClassificacaoDicInfo.BcsQuemAtu, DBBensClassificacaoDicInfo.BcsDtAtu, DBBensClassificacaoDicInfo.BcsVisto];
    public static ImmutableArray<DBInfoSystem> ListWithoutAuditor => [DBBensClassificacaoDicInfo.BcsNome, DBBensClassificacaoDicInfo.BcsGUID];

    public static ImmutableArray<DBInfoSystem> ListPk()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["bcsCodigo"]);
        var result = campos.Where(campo => !campo.Equals(DBBensClassificacaoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }

    public static ImmutableArray<DBInfoSystem> ListPkIndices()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["bcsCodigo", "bcsNome"]);
        var result = campos.Where(campo => !campo.Equals(DBBensClassificacaoDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }
}
#endif
