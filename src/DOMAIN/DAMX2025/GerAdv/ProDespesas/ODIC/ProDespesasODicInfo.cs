#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBProDespesasODicInfo : IODicInfo
{
    public ImmutableArray<DBInfoSystem> IListFields() => List;
    public ImmutableArray<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public ImmutableArray<DBInfoSystem> IPkFields() => ListPk();
    public ImmutableArray<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ITabelaNome() => DBProDespesasDicInfo.TabelaNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoCodigo() => DBProDespesasDicInfo.CampoCodigo;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string IPrefixo() => DBProDespesasDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasAuditor() => true;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasNameId() => false;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoNome() => DBProDespesasDicInfo.CampoNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string NameSpace() => nameof(GerAdv);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TemAuditor() => true;
    private static readonly FrozenDictionary<string, DBInfoSystem> _fieldLookup = List.ToFrozenDictionary(f => f.FNome, StringComparer.OrdinalIgnoreCase);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DBInfoSystem? GetInfoSystemByNameField(string campo) => _fieldLookup.GetValueOrDefault(campo);
    public static string TCampoCodigo => DBProDespesasDicInfo.CampoCodigo;
    public static string TCampoNome => DBProDespesasDicInfo.CampoNome;
    public static string TTabelaNome => DBProDespesasDicInfo.TabelaNome;
    public static string TTablePrefix => DBProDespesasDicInfo.TablePrefix;
    public static ImmutableArray<DBInfoSystem> List => [DBProDespesasDicInfo.DesLigacaoID, DBProDespesasDicInfo.DesCliente, DBProDespesasDicInfo.DesCorrigido, DBProDespesasDicInfo.DesData, DBProDespesasDicInfo.DesValorOriginal, DBProDespesasDicInfo.DesProcesso, DBProDespesasDicInfo.DesQuitado, DBProDespesasDicInfo.DesDataCorrecao, DBProDespesasDicInfo.DesValor, DBProDespesasDicInfo.DesTipo, DBProDespesasDicInfo.DesHistorico, DBProDespesasDicInfo.DesLivroCaixa, DBProDespesasDicInfo.DesGUID, DBProDespesasDicInfo.DesQuemCad, DBProDespesasDicInfo.DesDtCad, DBProDespesasDicInfo.DesQuemAtu, DBProDespesasDicInfo.DesDtAtu, DBProDespesasDicInfo.DesVisto];
    public static ImmutableArray<DBInfoSystem> ListWithoutAuditor => [DBProDespesasDicInfo.DesLigacaoID, DBProDespesasDicInfo.DesCliente, DBProDespesasDicInfo.DesCorrigido, DBProDespesasDicInfo.DesData, DBProDespesasDicInfo.DesValorOriginal, DBProDespesasDicInfo.DesProcesso, DBProDespesasDicInfo.DesQuitado, DBProDespesasDicInfo.DesDataCorrecao, DBProDespesasDicInfo.DesValor, DBProDespesasDicInfo.DesTipo, DBProDespesasDicInfo.DesHistorico, DBProDespesasDicInfo.DesLivroCaixa, DBProDespesasDicInfo.DesGUID];

    public static ImmutableArray<DBInfoSystem> ListPk()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["desCodigo"]);
        var result = campos.Where(campo => !campo.Equals(DBProDespesasDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }

    public static ImmutableArray<DBInfoSystem> ListPkIndices()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["desCodigo"]);
        var result = campos.Where(campo => !campo.Equals(DBProDespesasDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }
}
#endif
