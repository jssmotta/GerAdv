#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBDiario2ODicInfo : IODicInfo
{
    public ImmutableArray<DBInfoSystem> IListFields() => List;
    public ImmutableArray<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public ImmutableArray<DBInfoSystem> IPkFields() => ListPk();
    public ImmutableArray<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ITabelaNome() => DBDiario2DicInfo.TabelaNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoCodigo() => DBDiario2DicInfo.CampoCodigo;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string IPrefixo() => DBDiario2DicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasAuditor() => true;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasNameId() => true;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoNome() => DBDiario2DicInfo.CampoNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string NameSpace() => nameof(GerAdv);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TemAuditor() => true;
    private static readonly FrozenDictionary<string, DBInfoSystem> _fieldLookup = List.ToFrozenDictionary(f => f.FNome, StringComparer.OrdinalIgnoreCase);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DBInfoSystem? GetInfoSystemByNameField(string campo) => _fieldLookup.GetValueOrDefault(campo);
    public static string TCampoCodigo => DBDiario2DicInfo.CampoCodigo;
    public static string TCampoNome => DBDiario2DicInfo.CampoNome;
    public static string TTabelaNome => DBDiario2DicInfo.TabelaNome;
    public static string TTablePrefix => DBDiario2DicInfo.TablePrefix;
    public static ImmutableArray<DBInfoSystem> List => [DBDiario2DicInfo.DiaData, DBDiario2DicInfo.DiaHora, DBDiario2DicInfo.DiaOperador, DBDiario2DicInfo.DiaNome, DBDiario2DicInfo.DiaOcorrencia, DBDiario2DicInfo.DiaCliente, DBDiario2DicInfo.DiaBold, DBDiario2DicInfo.DiaGUID, DBDiario2DicInfo.DiaQuemCad, DBDiario2DicInfo.DiaDtCad, DBDiario2DicInfo.DiaQuemAtu, DBDiario2DicInfo.DiaDtAtu, DBDiario2DicInfo.DiaVisto];
    public static ImmutableArray<DBInfoSystem> ListWithoutAuditor => [DBDiario2DicInfo.DiaData, DBDiario2DicInfo.DiaHora, DBDiario2DicInfo.DiaOperador, DBDiario2DicInfo.DiaNome, DBDiario2DicInfo.DiaOcorrencia, DBDiario2DicInfo.DiaCliente, DBDiario2DicInfo.DiaGUID];

    public static ImmutableArray<DBInfoSystem> ListPk()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["diaCodigo"]);
        var result = campos.Where(campo => !campo.Equals(DBDiario2DicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }

    public static ImmutableArray<DBInfoSystem> ListPkIndices()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["diaCodigo"]);
        var result = campos.Where(campo => !campo.Equals(DBDiario2DicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }
}
#endif
