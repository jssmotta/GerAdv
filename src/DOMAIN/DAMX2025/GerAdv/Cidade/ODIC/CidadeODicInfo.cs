#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBCidadeODicInfo : IODicInfo
{
    public ImmutableArray<DBInfoSystem> IListFields() => List;
    public ImmutableArray<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public ImmutableArray<DBInfoSystem> IPkFields() => ListPk();
    public ImmutableArray<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ITabelaNome() => DBCidadeDicInfo.TabelaNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoCodigo() => DBCidadeDicInfo.CampoCodigo;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string IPrefixo() => DBCidadeDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasAuditor() => true;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasNameId() => true;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoNome() => DBCidadeDicInfo.CampoNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string NameSpace() => nameof(GerAdv);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TemAuditor() => true;
    private static readonly FrozenDictionary<string, DBInfoSystem> _fieldLookup = List.ToFrozenDictionary(f => f.FNome, StringComparer.OrdinalIgnoreCase);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DBInfoSystem? GetInfoSystemByNameField(string campo) => _fieldLookup.GetValueOrDefault(campo);
    public static string TCampoCodigo => DBCidadeDicInfo.CampoCodigo;
    public static string TCampoNome => DBCidadeDicInfo.CampoNome;
    public static string TTabelaNome => DBCidadeDicInfo.TabelaNome;
    public static string TTablePrefix => DBCidadeDicInfo.TablePrefix;
    public static ImmutableArray<DBInfoSystem> List => [DBCidadeDicInfo.CidDDD, DBCidadeDicInfo.CidTop, DBCidadeDicInfo.CidComarca, DBCidadeDicInfo.CidCapital, DBCidadeDicInfo.CidNome, DBCidadeDicInfo.CidUF, DBCidadeDicInfo.CidSigla, DBCidadeDicInfo.CidGUID, DBCidadeDicInfo.CidQuemCad, DBCidadeDicInfo.CidDtCad, DBCidadeDicInfo.CidQuemAtu, DBCidadeDicInfo.CidDtAtu, DBCidadeDicInfo.CidVisto];
    public static ImmutableArray<DBInfoSystem> ListWithoutAuditor => [DBCidadeDicInfo.CidDDD, DBCidadeDicInfo.CidTop, DBCidadeDicInfo.CidComarca, DBCidadeDicInfo.CidCapital, DBCidadeDicInfo.CidNome, DBCidadeDicInfo.CidUF, DBCidadeDicInfo.CidSigla, DBCidadeDicInfo.CidGUID];

    public static ImmutableArray<DBInfoSystem> ListPk()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["cidCodigo"]);
        var result = campos.Where(campo => !campo.Equals(DBCidadeDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }

    public static ImmutableArray<DBInfoSystem> ListPkIndices()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["cidCodigo", "cidNome", "cidUF"]);
        var result = campos.Where(campo => !campo.Equals(DBCidadeDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }
}
#endif
