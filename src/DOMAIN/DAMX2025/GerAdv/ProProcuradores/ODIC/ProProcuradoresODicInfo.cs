#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBProProcuradoresODicInfo : IODicInfo
{
    public ImmutableArray<DBInfoSystem> IListFields() => List;
    public ImmutableArray<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public ImmutableArray<DBInfoSystem> IPkFields() => ListPk();
    public ImmutableArray<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ITabelaNome() => DBProProcuradoresDicInfo.TabelaNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoCodigo() => DBProProcuradoresDicInfo.CampoCodigo;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string IPrefixo() => DBProProcuradoresDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasAuditor() => true;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasNameId() => true;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoNome() => DBProProcuradoresDicInfo.CampoNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string NameSpace() => nameof(GerAdv);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TemAuditor() => true;
    private static readonly FrozenDictionary<string, DBInfoSystem> _fieldLookup = List.ToFrozenDictionary(f => f.FNome, StringComparer.OrdinalIgnoreCase);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DBInfoSystem? GetInfoSystemByNameField(string campo) => _fieldLookup.GetValueOrDefault(campo);
    public static string TCampoCodigo => DBProProcuradoresDicInfo.CampoCodigo;
    public static string TCampoNome => DBProProcuradoresDicInfo.CampoNome;
    public static string TTabelaNome => DBProProcuradoresDicInfo.TabelaNome;
    public static string TTablePrefix => DBProProcuradoresDicInfo.TablePrefix;
    public static ImmutableArray<DBInfoSystem> List => [DBProProcuradoresDicInfo.PapAdvogado, DBProProcuradoresDicInfo.PapNome, DBProProcuradoresDicInfo.PapProcesso, DBProProcuradoresDicInfo.PapData, DBProProcuradoresDicInfo.PapSubstabelecimento, DBProProcuradoresDicInfo.PapProcuracao, DBProProcuradoresDicInfo.PapBold, DBProProcuradoresDicInfo.PapGUID, DBProProcuradoresDicInfo.PapQuemCad, DBProProcuradoresDicInfo.PapDtCad, DBProProcuradoresDicInfo.PapQuemAtu, DBProProcuradoresDicInfo.PapDtAtu, DBProProcuradoresDicInfo.PapVisto];
    public static ImmutableArray<DBInfoSystem> ListWithoutAuditor => [DBProProcuradoresDicInfo.PapAdvogado, DBProProcuradoresDicInfo.PapNome, DBProProcuradoresDicInfo.PapProcesso, DBProProcuradoresDicInfo.PapData, DBProProcuradoresDicInfo.PapSubstabelecimento, DBProProcuradoresDicInfo.PapProcuracao, DBProProcuradoresDicInfo.PapGUID];

    public static ImmutableArray<DBInfoSystem> ListPk()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["papCodigo"]);
        var result = campos.Where(campo => !campo.Equals(DBProProcuradoresDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }

    public static ImmutableArray<DBInfoSystem> ListPkIndices()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["papAdvogado", "papCodigo", "papData", "papNome", "papProcesso"]);
        var result = campos.Where(campo => !campo.Equals(DBProProcuradoresDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }
}
#endif
