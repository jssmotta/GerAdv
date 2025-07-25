#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBAnexamentoRegistrosODicInfo : IODicInfo
{
    public ImmutableArray<DBInfoSystem> IListFields() => List;
    public ImmutableArray<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public ImmutableArray<DBInfoSystem> IPkFields() => ListPk();
    public ImmutableArray<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ITabelaNome() => DBAnexamentoRegistrosDicInfo.TabelaNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoCodigo() => DBAnexamentoRegistrosDicInfo.CampoCodigo;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string IPrefixo() => DBAnexamentoRegistrosDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasAuditor() => true;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasNameId() => false;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoNome() => DBAnexamentoRegistrosDicInfo.CampoNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string NameSpace() => nameof(GerAdv);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TemAuditor() => true;
    private static readonly FrozenDictionary<string, DBInfoSystem> _fieldLookup = List.ToFrozenDictionary(f => f.FNome, StringComparer.OrdinalIgnoreCase);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DBInfoSystem? GetInfoSystemByNameField(string campo) => _fieldLookup.GetValueOrDefault(campo);
    public static string TCampoCodigo => DBAnexamentoRegistrosDicInfo.CampoCodigo;
    public static string TCampoNome => DBAnexamentoRegistrosDicInfo.CampoNome;
    public static string TTabelaNome => DBAnexamentoRegistrosDicInfo.TabelaNome;
    public static string TTablePrefix => DBAnexamentoRegistrosDicInfo.TablePrefix;
    public static ImmutableArray<DBInfoSystem> List => [DBAnexamentoRegistrosDicInfo.AxrCliente, DBAnexamentoRegistrosDicInfo.AxrGUIDReg, DBAnexamentoRegistrosDicInfo.AxrCodigoReg, DBAnexamentoRegistrosDicInfo.AxrIDReg, DBAnexamentoRegistrosDicInfo.AxrData, DBAnexamentoRegistrosDicInfo.AxrGUID, DBAnexamentoRegistrosDicInfo.AxrQuemCad, DBAnexamentoRegistrosDicInfo.AxrDtCad, DBAnexamentoRegistrosDicInfo.AxrQuemAtu, DBAnexamentoRegistrosDicInfo.AxrDtAtu, DBAnexamentoRegistrosDicInfo.AxrVisto];
    public static ImmutableArray<DBInfoSystem> ListWithoutAuditor => [DBAnexamentoRegistrosDicInfo.AxrCliente, DBAnexamentoRegistrosDicInfo.AxrGUIDReg, DBAnexamentoRegistrosDicInfo.AxrCodigoReg, DBAnexamentoRegistrosDicInfo.AxrIDReg, DBAnexamentoRegistrosDicInfo.AxrData, DBAnexamentoRegistrosDicInfo.AxrGUID];

    public static ImmutableArray<DBInfoSystem> ListPk()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["axrCodigo"]);
        var result = campos.Where(campo => !campo.Equals(DBAnexamentoRegistrosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }

    public static ImmutableArray<DBInfoSystem> ListPkIndices()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["axrCodigo", "axrCodigoReg", "axrGUIDReg", "axrIDReg"]);
        var result = campos.Where(campo => !campo.Equals(DBAnexamentoRegistrosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }
}
#endif
