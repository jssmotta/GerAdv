#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBDocsRecebidosItensODicInfo : IODicInfo
{
    public ImmutableArray<DBInfoSystem> IListFields() => List;
    public ImmutableArray<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public ImmutableArray<DBInfoSystem> IPkFields() => ListPk();
    public ImmutableArray<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ITabelaNome() => DBDocsRecebidosItensDicInfo.TabelaNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoCodigo() => DBDocsRecebidosItensDicInfo.CampoCodigo;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string IPrefixo() => DBDocsRecebidosItensDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasAuditor() => true;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasNameId() => true;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoNome() => DBDocsRecebidosItensDicInfo.CampoNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string NameSpace() => nameof(GerAdv);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TemAuditor() => true;
    private static readonly FrozenDictionary<string, DBInfoSystem> _fieldLookup = List.ToFrozenDictionary(f => f.FNome, StringComparer.OrdinalIgnoreCase);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DBInfoSystem? GetInfoSystemByNameField(string campo) => _fieldLookup.GetValueOrDefault(campo);
    public static string TCampoCodigo => DBDocsRecebidosItensDicInfo.CampoCodigo;
    public static string TCampoNome => DBDocsRecebidosItensDicInfo.CampoNome;
    public static string TTabelaNome => DBDocsRecebidosItensDicInfo.TabelaNome;
    public static string TTablePrefix => DBDocsRecebidosItensDicInfo.TablePrefix;
    public static ImmutableArray<DBInfoSystem> List => [DBDocsRecebidosItensDicInfo.DriContatoCRM, DBDocsRecebidosItensDicInfo.DriNome, DBDocsRecebidosItensDicInfo.DriDevolvido, DBDocsRecebidosItensDicInfo.DriSeraDevolvido, DBDocsRecebidosItensDicInfo.DriObservacoes, DBDocsRecebidosItensDicInfo.DriBold, DBDocsRecebidosItensDicInfo.DriGUID, DBDocsRecebidosItensDicInfo.DriQuemCad, DBDocsRecebidosItensDicInfo.DriDtCad, DBDocsRecebidosItensDicInfo.DriQuemAtu, DBDocsRecebidosItensDicInfo.DriDtAtu, DBDocsRecebidosItensDicInfo.DriVisto];
    public static ImmutableArray<DBInfoSystem> ListWithoutAuditor => [DBDocsRecebidosItensDicInfo.DriContatoCRM, DBDocsRecebidosItensDicInfo.DriNome, DBDocsRecebidosItensDicInfo.DriDevolvido, DBDocsRecebidosItensDicInfo.DriSeraDevolvido, DBDocsRecebidosItensDicInfo.DriObservacoes, DBDocsRecebidosItensDicInfo.DriGUID];

    public static ImmutableArray<DBInfoSystem> ListPk()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["driCodigo"]);
        var result = campos.Where(campo => !campo.Equals(DBDocsRecebidosItensDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }

    public static ImmutableArray<DBInfoSystem> ListPkIndices()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["driCodigo"]);
        var result = campos.Where(campo => !campo.Equals(DBDocsRecebidosItensDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }
}
#endif
