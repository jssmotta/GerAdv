#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBContatoCRMOperadorODicInfo : IODicInfo
{
    public ImmutableArray<DBInfoSystem> IListFields() => List;
    public ImmutableArray<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public ImmutableArray<DBInfoSystem> IPkFields() => ListPk();
    public ImmutableArray<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ITabelaNome() => DBContatoCRMOperadorDicInfo.TabelaNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoCodigo() => DBContatoCRMOperadorDicInfo.CampoCodigo;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string IPrefixo() => DBContatoCRMOperadorDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasAuditor() => true;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasNameId() => false;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoNome() => DBContatoCRMOperadorDicInfo.CampoNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string NameSpace() => nameof(GerAdv);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TemAuditor() => true;
    private static readonly FrozenDictionary<string, DBInfoSystem> _fieldLookup = List.ToFrozenDictionary(f => f.FNome, StringComparer.OrdinalIgnoreCase);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DBInfoSystem? GetInfoSystemByNameField(string campo) => _fieldLookup.GetValueOrDefault(campo);
    public static string TCampoCodigo => DBContatoCRMOperadorDicInfo.CampoCodigo;
    public static string TCampoNome => DBContatoCRMOperadorDicInfo.CampoNome;
    public static string TTabelaNome => DBContatoCRMOperadorDicInfo.TabelaNome;
    public static string TTablePrefix => DBContatoCRMOperadorDicInfo.TablePrefix;
    public static ImmutableArray<DBInfoSystem> List => [DBContatoCRMOperadorDicInfo.CcoContatoCRM, DBContatoCRMOperadorDicInfo.CcoCargoEsc, DBContatoCRMOperadorDicInfo.CcoOperador, DBContatoCRMOperadorDicInfo.CcoQuemCad, DBContatoCRMOperadorDicInfo.CcoDtCad, DBContatoCRMOperadorDicInfo.CcoQuemAtu, DBContatoCRMOperadorDicInfo.CcoDtAtu, DBContatoCRMOperadorDicInfo.CcoVisto];
    public static ImmutableArray<DBInfoSystem> ListWithoutAuditor => [DBContatoCRMOperadorDicInfo.CcoContatoCRM, DBContatoCRMOperadorDicInfo.CcoCargoEsc, DBContatoCRMOperadorDicInfo.CcoOperador];

    public static ImmutableArray<DBInfoSystem> ListPk()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["ccoCodigo"]);
        var result = campos.Where(campo => !campo.Equals(DBContatoCRMOperadorDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }

    public static ImmutableArray<DBInfoSystem> ListPkIndices()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["ccoCargoEsc", "ccoCodigo", "ccoContatoCRM", "ccoOperador"]);
        var result = campos.Where(campo => !campo.Equals(DBContatoCRMOperadorDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }
}
#endif
