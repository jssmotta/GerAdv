#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBContatoCRMODicInfo : IODicInfo
{
    public ImmutableArray<DBInfoSystem> IListFields() => List;
    public ImmutableArray<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public ImmutableArray<DBInfoSystem> IPkFields() => ListPk();
    public ImmutableArray<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ITabelaNome() => DBContatoCRMDicInfo.TabelaNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoCodigo() => DBContatoCRMDicInfo.CampoCodigo;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string IPrefixo() => DBContatoCRMDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasAuditor() => true;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasNameId() => false;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoNome() => DBContatoCRMDicInfo.CampoNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string NameSpace() => nameof(GerAdv);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TemAuditor() => true;
    private static readonly FrozenDictionary<string, DBInfoSystem> _fieldLookup = List.ToFrozenDictionary(f => f.FNome, StringComparer.OrdinalIgnoreCase);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DBInfoSystem? GetInfoSystemByNameField(string campo) => _fieldLookup.GetValueOrDefault(campo);
    public static string TCampoCodigo => DBContatoCRMDicInfo.CampoCodigo;
    public static string TCampoNome => DBContatoCRMDicInfo.CampoNome;
    public static string TTabelaNome => DBContatoCRMDicInfo.TabelaNome;
    public static string TTablePrefix => DBContatoCRMDicInfo.TablePrefix;
    public static ImmutableArray<DBInfoSystem> List => [DBContatoCRMDicInfo.CtcAgeClienteAvisado, DBContatoCRMDicInfo.CtcDocsViaRecebimento, DBContatoCRMDicInfo.CtcNaoPublicavel, DBContatoCRMDicInfo.CtcNotificar, DBContatoCRMDicInfo.CtcOcultar, DBContatoCRMDicInfo.CtcAssunto, DBContatoCRMDicInfo.CtcIsDocsRecebidos, DBContatoCRMDicInfo.CtcQuemNotificou, DBContatoCRMDicInfo.CtcDataNotificou, DBContatoCRMDicInfo.CtcOperador, DBContatoCRMDicInfo.CtcCliente, DBContatoCRMDicInfo.CtcHoraNotificou, DBContatoCRMDicInfo.CtcObjetoNotificou, DBContatoCRMDicInfo.CtcPessoaContato, DBContatoCRMDicInfo.CtcData, DBContatoCRMDicInfo.CtcTempo, DBContatoCRMDicInfo.CtcHoraInicial, DBContatoCRMDicInfo.CtcHoraFinal, DBContatoCRMDicInfo.CtcProcesso, DBContatoCRMDicInfo.CtcImportante, DBContatoCRMDicInfo.CtcUrgente, DBContatoCRMDicInfo.CtcGerarHoraTrabalhada, DBContatoCRMDicInfo.CtcExibirNoTopo, DBContatoCRMDicInfo.CtcTipoContatoCRM, DBContatoCRMDicInfo.CtcContato, DBContatoCRMDicInfo.CtcEmocao, DBContatoCRMDicInfo.CtcContinuar, DBContatoCRMDicInfo.CtcBold, DBContatoCRMDicInfo.CtcGUID, DBContatoCRMDicInfo.CtcQuemCad, DBContatoCRMDicInfo.CtcDtCad, DBContatoCRMDicInfo.CtcQuemAtu, DBContatoCRMDicInfo.CtcDtAtu, DBContatoCRMDicInfo.CtcVisto];
    public static ImmutableArray<DBInfoSystem> ListWithoutAuditor => [DBContatoCRMDicInfo.CtcAgeClienteAvisado, DBContatoCRMDicInfo.CtcDocsViaRecebimento, DBContatoCRMDicInfo.CtcNaoPublicavel, DBContatoCRMDicInfo.CtcNotificar, DBContatoCRMDicInfo.CtcOcultar, DBContatoCRMDicInfo.CtcAssunto, DBContatoCRMDicInfo.CtcIsDocsRecebidos, DBContatoCRMDicInfo.CtcQuemNotificou, DBContatoCRMDicInfo.CtcDataNotificou, DBContatoCRMDicInfo.CtcOperador, DBContatoCRMDicInfo.CtcCliente, DBContatoCRMDicInfo.CtcHoraNotificou, DBContatoCRMDicInfo.CtcObjetoNotificou, DBContatoCRMDicInfo.CtcPessoaContato, DBContatoCRMDicInfo.CtcData, DBContatoCRMDicInfo.CtcTempo, DBContatoCRMDicInfo.CtcHoraInicial, DBContatoCRMDicInfo.CtcHoraFinal, DBContatoCRMDicInfo.CtcProcesso, DBContatoCRMDicInfo.CtcImportante, DBContatoCRMDicInfo.CtcUrgente, DBContatoCRMDicInfo.CtcGerarHoraTrabalhada, DBContatoCRMDicInfo.CtcExibirNoTopo, DBContatoCRMDicInfo.CtcTipoContatoCRM, DBContatoCRMDicInfo.CtcContato, DBContatoCRMDicInfo.CtcEmocao, DBContatoCRMDicInfo.CtcContinuar, DBContatoCRMDicInfo.CtcGUID];

    public static ImmutableArray<DBInfoSystem> ListPk()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["ctcCodigo"]);
        var result = campos.Where(campo => !campo.Equals(DBContatoCRMDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }

    public static ImmutableArray<DBInfoSystem> ListPkIndices()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["ctcCodigo"]);
        var result = campos.Where(campo => !campo.Equals(DBContatoCRMDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }
}
#endif
