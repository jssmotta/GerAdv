#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBProcessosODicInfo : IODicInfo
{
    public ImmutableArray<DBInfoSystem> IListFields() => List;
    public ImmutableArray<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public ImmutableArray<DBInfoSystem> IPkFields() => ListPk();
    public ImmutableArray<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ITabelaNome() => DBProcessosDicInfo.TabelaNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoCodigo() => DBProcessosDicInfo.CampoCodigo;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string IPrefixo() => DBProcessosDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasAuditor() => true;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasNameId() => true;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoNome() => DBProcessosDicInfo.CampoNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string NameSpace() => nameof(GerAdv);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TemAuditor() => true;
    private static readonly FrozenDictionary<string, DBInfoSystem> _fieldLookup = List.ToFrozenDictionary(f => f.FNome, StringComparer.OrdinalIgnoreCase);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DBInfoSystem? GetInfoSystemByNameField(string campo) => _fieldLookup.GetValueOrDefault(campo);
    public static string TCampoCodigo => DBProcessosDicInfo.CampoCodigo;
    public static string TCampoNome => DBProcessosDicInfo.CampoNome;
    public static string TTabelaNome => DBProcessosDicInfo.TabelaNome;
    public static string TTablePrefix => DBProcessosDicInfo.TablePrefix;
    public static ImmutableArray<DBInfoSystem> List => [DBProcessosDicInfo.ProAdvParc, DBProcessosDicInfo.ProAJGPedidoNegado, DBProcessosDicInfo.ProAJGCliente, DBProcessosDicInfo.ProAJGPedidoNegadoOPO, DBProcessosDicInfo.ProNotificarPOE, DBProcessosDicInfo.ProValorProvisionado, DBProcessosDicInfo.ProAJGOponente, DBProcessosDicInfo.ProValorCacheCalculo, DBProcessosDicInfo.ProAJGPedidoOPO, DBProcessosDicInfo.ProValorCacheCalculoProv, DBProcessosDicInfo.ProConsiderarParado, DBProcessosDicInfo.ProValorCalculado, DBProcessosDicInfo.ProAJGConcedidoOPO, DBProcessosDicInfo.ProCobranca, DBProcessosDicInfo.ProDataEntrada, DBProcessosDicInfo.ProPenhora, DBProcessosDicInfo.ProAJGPedido, DBProcessosDicInfo.ProTipoBaixa, DBProcessosDicInfo.ProClassRisco, DBProcessosDicInfo.ProIsApenso, DBProcessosDicInfo.ProValorCausaInicial, DBProcessosDicInfo.ProAJGConcedido, DBProcessosDicInfo.ProObsBCX, DBProcessosDicInfo.ProValorCausaDefinitivo, DBProcessosDicInfo.ProPercProbExito, DBProcessosDicInfo.ProMNA, DBProcessosDicInfo.ProPercExito, DBProcessosDicInfo.ProNroExtra, DBProcessosDicInfo.ProAdvOpo, DBProcessosDicInfo.ProExtra, DBProcessosDicInfo.ProJustica, DBProcessosDicInfo.ProAdvogado, DBProcessosDicInfo.ProNroCaixa, DBProcessosDicInfo.ProPreposto, DBProcessosDicInfo.ProCliente, DBProcessosDicInfo.ProOponente, DBProcessosDicInfo.ProArea, DBProcessosDicInfo.ProCidade, DBProcessosDicInfo.ProSituacao, DBProcessosDicInfo.ProIDSituacao, DBProcessosDicInfo.ProValor, DBProcessosDicInfo.ProRito, DBProcessosDicInfo.ProFato, DBProcessosDicInfo.ProNroPasta, DBProcessosDicInfo.ProAtividade, DBProcessosDicInfo.ProCaixaMorto, DBProcessosDicInfo.ProBaixado, DBProcessosDicInfo.ProDtBaixa, DBProcessosDicInfo.ProMotivoBaixa, DBProcessosDicInfo.ProOBS, DBProcessosDicInfo.ProPrinted, DBProcessosDicInfo.ProZKey, DBProcessosDicInfo.ProZKeyQuem, DBProcessosDicInfo.ProZKeyQuando, DBProcessosDicInfo.ProResumo, DBProcessosDicInfo.ProNaoImprimir, DBProcessosDicInfo.ProEletronico, DBProcessosDicInfo.ProNroContrato, DBProcessosDicInfo.ProPercProbExitoJustificativa, DBProcessosDicInfo.ProHonorarioValor, DBProcessosDicInfo.ProHonorarioPercentual, DBProcessosDicInfo.ProHonorarioSucumbencia, DBProcessosDicInfo.ProFaseAuditoria, DBProcessosDicInfo.ProValorCondenacao, DBProcessosDicInfo.ProValorCondenacaoCalculado, DBProcessosDicInfo.ProValorCondenacaoProvisorio, DBProcessosDicInfo.ProGUID, DBProcessosDicInfo.ProQuemCad, DBProcessosDicInfo.ProDtCad, DBProcessosDicInfo.ProQuemAtu, DBProcessosDicInfo.ProDtAtu, DBProcessosDicInfo.ProVisto];
    public static ImmutableArray<DBInfoSystem> ListWithoutAuditor => [DBProcessosDicInfo.ProAdvParc, DBProcessosDicInfo.ProAJGPedidoNegado, DBProcessosDicInfo.ProAJGCliente, DBProcessosDicInfo.ProAJGPedidoNegadoOPO, DBProcessosDicInfo.ProNotificarPOE, DBProcessosDicInfo.ProValorProvisionado, DBProcessosDicInfo.ProAJGOponente, DBProcessosDicInfo.ProValorCacheCalculo, DBProcessosDicInfo.ProAJGPedidoOPO, DBProcessosDicInfo.ProValorCacheCalculoProv, DBProcessosDicInfo.ProConsiderarParado, DBProcessosDicInfo.ProValorCalculado, DBProcessosDicInfo.ProAJGConcedidoOPO, DBProcessosDicInfo.ProCobranca, DBProcessosDicInfo.ProDataEntrada, DBProcessosDicInfo.ProPenhora, DBProcessosDicInfo.ProAJGPedido, DBProcessosDicInfo.ProTipoBaixa, DBProcessosDicInfo.ProClassRisco, DBProcessosDicInfo.ProIsApenso, DBProcessosDicInfo.ProValorCausaInicial, DBProcessosDicInfo.ProAJGConcedido, DBProcessosDicInfo.ProObsBCX, DBProcessosDicInfo.ProValorCausaDefinitivo, DBProcessosDicInfo.ProPercProbExito, DBProcessosDicInfo.ProMNA, DBProcessosDicInfo.ProPercExito, DBProcessosDicInfo.ProNroExtra, DBProcessosDicInfo.ProAdvOpo, DBProcessosDicInfo.ProExtra, DBProcessosDicInfo.ProJustica, DBProcessosDicInfo.ProAdvogado, DBProcessosDicInfo.ProNroCaixa, DBProcessosDicInfo.ProPreposto, DBProcessosDicInfo.ProCliente, DBProcessosDicInfo.ProOponente, DBProcessosDicInfo.ProArea, DBProcessosDicInfo.ProCidade, DBProcessosDicInfo.ProSituacao, DBProcessosDicInfo.ProIDSituacao, DBProcessosDicInfo.ProValor, DBProcessosDicInfo.ProRito, DBProcessosDicInfo.ProFato, DBProcessosDicInfo.ProNroPasta, DBProcessosDicInfo.ProAtividade, DBProcessosDicInfo.ProCaixaMorto, DBProcessosDicInfo.ProBaixado, DBProcessosDicInfo.ProDtBaixa, DBProcessosDicInfo.ProMotivoBaixa, DBProcessosDicInfo.ProOBS, DBProcessosDicInfo.ProPrinted, DBProcessosDicInfo.ProZKey, DBProcessosDicInfo.ProZKeyQuem, DBProcessosDicInfo.ProZKeyQuando, DBProcessosDicInfo.ProResumo, DBProcessosDicInfo.ProNaoImprimir, DBProcessosDicInfo.ProEletronico, DBProcessosDicInfo.ProNroContrato, DBProcessosDicInfo.ProPercProbExitoJustificativa, DBProcessosDicInfo.ProHonorarioValor, DBProcessosDicInfo.ProHonorarioPercentual, DBProcessosDicInfo.ProHonorarioSucumbencia, DBProcessosDicInfo.ProFaseAuditoria, DBProcessosDicInfo.ProValorCondenacao, DBProcessosDicInfo.ProValorCondenacaoCalculado, DBProcessosDicInfo.ProValorCondenacaoProvisorio, DBProcessosDicInfo.ProGUID];

    public static ImmutableArray<DBInfoSystem> ListPk()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["proCodigo"]);
        var result = campos.Where(campo => !campo.Equals(DBProcessosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }

    public static ImmutableArray<DBInfoSystem> ListPkIndices()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["proCodigo"]);
        var result = campos.Where(campo => !campo.Equals(DBProcessosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }
}
#endif
