#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBTerceirosODicInfo : IODicInfo
{
    public ImmutableArray<DBInfoSystem> IListFields() => List;
    public ImmutableArray<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public ImmutableArray<DBInfoSystem> IPkFields() => ListPk();
    public ImmutableArray<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ITabelaNome() => DBTerceirosDicInfo.TabelaNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoCodigo() => DBTerceirosDicInfo.CampoCodigo;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string IPrefixo() => DBTerceirosDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasAuditor() => true;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasNameId() => true;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoNome() => DBTerceirosDicInfo.CampoNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string NameSpace() => nameof(GerAdv);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TemAuditor() => true;
    private static readonly FrozenDictionary<string, DBInfoSystem> _fieldLookup = List.ToFrozenDictionary(f => f.FNome, StringComparer.OrdinalIgnoreCase);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DBInfoSystem? GetInfoSystemByNameField(string campo) => _fieldLookup.GetValueOrDefault(campo);
    public static string TCampoCodigo => DBTerceirosDicInfo.CampoCodigo;
    public static string TCampoNome => DBTerceirosDicInfo.CampoNome;
    public static string TTabelaNome => DBTerceirosDicInfo.TabelaNome;
    public static string TTablePrefix => DBTerceirosDicInfo.TablePrefix;
    public static ImmutableArray<DBInfoSystem> List => [DBTerceirosDicInfo.TerProcesso, DBTerceirosDicInfo.TerNome, DBTerceirosDicInfo.TerSituacao, DBTerceirosDicInfo.TerCidade, DBTerceirosDicInfo.TerEndereco, DBTerceirosDicInfo.TerBairro, DBTerceirosDicInfo.TerCEP, DBTerceirosDicInfo.TerFone, DBTerceirosDicInfo.TerFax, DBTerceirosDicInfo.TerOBS, DBTerceirosDicInfo.TerEMail, DBTerceirosDicInfo.TerClass, DBTerceirosDicInfo.TerVaraForoComarca, DBTerceirosDicInfo.TerSexo, DBTerceirosDicInfo.TerBold, DBTerceirosDicInfo.TerGUID, DBTerceirosDicInfo.TerQuemCad, DBTerceirosDicInfo.TerDtCad, DBTerceirosDicInfo.TerQuemAtu, DBTerceirosDicInfo.TerDtAtu, DBTerceirosDicInfo.TerVisto];
    public static ImmutableArray<DBInfoSystem> ListWithoutAuditor => [DBTerceirosDicInfo.TerProcesso, DBTerceirosDicInfo.TerNome, DBTerceirosDicInfo.TerSituacao, DBTerceirosDicInfo.TerCidade, DBTerceirosDicInfo.TerEndereco, DBTerceirosDicInfo.TerBairro, DBTerceirosDicInfo.TerCEP, DBTerceirosDicInfo.TerFone, DBTerceirosDicInfo.TerFax, DBTerceirosDicInfo.TerOBS, DBTerceirosDicInfo.TerEMail, DBTerceirosDicInfo.TerClass, DBTerceirosDicInfo.TerVaraForoComarca, DBTerceirosDicInfo.TerSexo, DBTerceirosDicInfo.TerGUID];

    public static ImmutableArray<DBInfoSystem> ListPk()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["terCodigo"]);
        var result = campos.Where(campo => !campo.Equals(DBTerceirosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }

    public static ImmutableArray<DBInfoSystem> ListPkIndices()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["terCodigo", "terNome", "terProcesso"]);
        var result = campos.Where(campo => !campo.Equals(DBTerceirosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }
}
#endif
