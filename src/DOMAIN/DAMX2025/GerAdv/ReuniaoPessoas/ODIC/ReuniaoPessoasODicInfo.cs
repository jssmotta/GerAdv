#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBReuniaoPessoasODicInfo : IODicInfo
{
    public ImmutableArray<DBInfoSystem> IListFields() => List;
    public ImmutableArray<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public ImmutableArray<DBInfoSystem> IPkFields() => ListPk();
    public ImmutableArray<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ITabelaNome() => DBReuniaoPessoasDicInfo.TabelaNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoCodigo() => DBReuniaoPessoasDicInfo.CampoCodigo;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string IPrefixo() => DBReuniaoPessoasDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasAuditor() => true;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasNameId() => false;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoNome() => DBReuniaoPessoasDicInfo.CampoNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string NameSpace() => nameof(GerAdv);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TemAuditor() => true;
    private static readonly FrozenDictionary<string, DBInfoSystem> _fieldLookup = List.ToFrozenDictionary(f => f.FNome, StringComparer.OrdinalIgnoreCase);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DBInfoSystem? GetInfoSystemByNameField(string campo) => _fieldLookup.GetValueOrDefault(campo);
    public static string TCampoCodigo => DBReuniaoPessoasDicInfo.CampoCodigo;
    public static string TCampoNome => DBReuniaoPessoasDicInfo.CampoNome;
    public static string TTabelaNome => DBReuniaoPessoasDicInfo.TabelaNome;
    public static string TTablePrefix => DBReuniaoPessoasDicInfo.TablePrefix;
    public static ImmutableArray<DBInfoSystem> List => [DBReuniaoPessoasDicInfo.RnpReuniao, DBReuniaoPessoasDicInfo.RnpOperador, DBReuniaoPessoasDicInfo.RnpQuemCad, DBReuniaoPessoasDicInfo.RnpDtCad, DBReuniaoPessoasDicInfo.RnpQuemAtu, DBReuniaoPessoasDicInfo.RnpDtAtu, DBReuniaoPessoasDicInfo.RnpVisto];
    public static ImmutableArray<DBInfoSystem> ListWithoutAuditor => [DBReuniaoPessoasDicInfo.RnpReuniao, DBReuniaoPessoasDicInfo.RnpOperador];

    public static ImmutableArray<DBInfoSystem> ListPk()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["rnpCodigo"]);
        var result = campos.Where(campo => !campo.Equals(DBReuniaoPessoasDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }

    public static ImmutableArray<DBInfoSystem> ListPkIndices()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["rnpCodigo", "rnpOperador", "rnpReuniao"]);
        var result = campos.Where(campo => !campo.Equals(DBReuniaoPessoasDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }
}
#endif
