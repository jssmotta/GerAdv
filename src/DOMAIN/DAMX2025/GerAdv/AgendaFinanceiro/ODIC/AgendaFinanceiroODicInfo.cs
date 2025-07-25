#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBAgendaFinanceiroODicInfo : IODicInfo
{
    public ImmutableArray<DBInfoSystem> IListFields() => List;
    public ImmutableArray<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public ImmutableArray<DBInfoSystem> IPkFields() => ListPk();
    public ImmutableArray<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ITabelaNome() => DBAgendaFinanceiroDicInfo.TabelaNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoCodigo() => DBAgendaFinanceiroDicInfo.CampoCodigo;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string IPrefixo() => DBAgendaFinanceiroDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasAuditor() => true;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasNameId() => false;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoNome() => DBAgendaFinanceiroDicInfo.CampoNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string NameSpace() => nameof(GerAdv);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TemAuditor() => true;
    private static readonly FrozenDictionary<string, DBInfoSystem> _fieldLookup = List.ToFrozenDictionary(f => f.FNome, StringComparer.OrdinalIgnoreCase);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DBInfoSystem? GetInfoSystemByNameField(string campo) => _fieldLookup.GetValueOrDefault(campo);
    public static string TCampoCodigo => DBAgendaFinanceiroDicInfo.CampoCodigo;
    public static string TCampoNome => DBAgendaFinanceiroDicInfo.CampoNome;
    public static string TTabelaNome => DBAgendaFinanceiroDicInfo.TabelaNome;
    public static string TTablePrefix => DBAgendaFinanceiroDicInfo.TablePrefix;
    public static ImmutableArray<DBInfoSystem> List => [DBAgendaFinanceiroDicInfo.AgeIDCOB, DBAgendaFinanceiroDicInfo.AgeIDNE, DBAgendaFinanceiroDicInfo.AgePrazoProvisionado, DBAgendaFinanceiroDicInfo.AgeCidade, DBAgendaFinanceiroDicInfo.AgeOculto, DBAgendaFinanceiroDicInfo.AgeCartaPrecatoria, DBAgendaFinanceiroDicInfo.AgeRepetirDias, DBAgendaFinanceiroDicInfo.AgeHrFinal, DBAgendaFinanceiroDicInfo.AgeRepetir, DBAgendaFinanceiroDicInfo.AgeAdvogado, DBAgendaFinanceiroDicInfo.AgeEventoGerador, DBAgendaFinanceiroDicInfo.AgeEventoData, DBAgendaFinanceiroDicInfo.AgeFuncionario, DBAgendaFinanceiroDicInfo.AgeData, DBAgendaFinanceiroDicInfo.AgeEventoPrazo, DBAgendaFinanceiroDicInfo.AgeHora, DBAgendaFinanceiroDicInfo.AgeCompromisso, DBAgendaFinanceiroDicInfo.AgeTipoCompromisso, DBAgendaFinanceiroDicInfo.AgeCliente, DBAgendaFinanceiroDicInfo.AgeDDias, DBAgendaFinanceiroDicInfo.AgeDias, DBAgendaFinanceiroDicInfo.AgeLiberado, DBAgendaFinanceiroDicInfo.AgeImportante, DBAgendaFinanceiroDicInfo.AgeConcluido, DBAgendaFinanceiroDicInfo.AgeArea, DBAgendaFinanceiroDicInfo.AgeJustica, DBAgendaFinanceiroDicInfo.AgeProcesso, DBAgendaFinanceiroDicInfo.AgeIDHistorico, DBAgendaFinanceiroDicInfo.AgeIDInsProcesso, DBAgendaFinanceiroDicInfo.AgeUsuario, DBAgendaFinanceiroDicInfo.AgePreposto, DBAgendaFinanceiroDicInfo.AgeQuemID, DBAgendaFinanceiroDicInfo.AgeQuemCodigo, DBAgendaFinanceiroDicInfo.AgeStatus, DBAgendaFinanceiroDicInfo.AgeValor, DBAgendaFinanceiroDicInfo.AgeCompromissoHTML, DBAgendaFinanceiroDicInfo.AgeDecisao, DBAgendaFinanceiroDicInfo.AgeRevisar, DBAgendaFinanceiroDicInfo.AgeRevisarP2, DBAgendaFinanceiroDicInfo.AgeSempre, DBAgendaFinanceiroDicInfo.AgePrazoDias, DBAgendaFinanceiroDicInfo.AgeProtocoloIntegrado, DBAgendaFinanceiroDicInfo.AgeDataInicioPrazo, DBAgendaFinanceiroDicInfo.AgeUsuarioCiente, DBAgendaFinanceiroDicInfo.AgeGUID, DBAgendaFinanceiroDicInfo.AgeQuemCad, DBAgendaFinanceiroDicInfo.AgeDtCad, DBAgendaFinanceiroDicInfo.AgeQuemAtu, DBAgendaFinanceiroDicInfo.AgeDtAtu, DBAgendaFinanceiroDicInfo.AgeVisto];
    public static ImmutableArray<DBInfoSystem> ListWithoutAuditor => [DBAgendaFinanceiroDicInfo.AgeIDCOB, DBAgendaFinanceiroDicInfo.AgeIDNE, DBAgendaFinanceiroDicInfo.AgePrazoProvisionado, DBAgendaFinanceiroDicInfo.AgeCidade, DBAgendaFinanceiroDicInfo.AgeOculto, DBAgendaFinanceiroDicInfo.AgeCartaPrecatoria, DBAgendaFinanceiroDicInfo.AgeRepetirDias, DBAgendaFinanceiroDicInfo.AgeHrFinal, DBAgendaFinanceiroDicInfo.AgeRepetir, DBAgendaFinanceiroDicInfo.AgeAdvogado, DBAgendaFinanceiroDicInfo.AgeEventoGerador, DBAgendaFinanceiroDicInfo.AgeEventoData, DBAgendaFinanceiroDicInfo.AgeFuncionario, DBAgendaFinanceiroDicInfo.AgeData, DBAgendaFinanceiroDicInfo.AgeEventoPrazo, DBAgendaFinanceiroDicInfo.AgeHora, DBAgendaFinanceiroDicInfo.AgeCompromisso, DBAgendaFinanceiroDicInfo.AgeTipoCompromisso, DBAgendaFinanceiroDicInfo.AgeCliente, DBAgendaFinanceiroDicInfo.AgeDDias, DBAgendaFinanceiroDicInfo.AgeDias, DBAgendaFinanceiroDicInfo.AgeLiberado, DBAgendaFinanceiroDicInfo.AgeImportante, DBAgendaFinanceiroDicInfo.AgeConcluido, DBAgendaFinanceiroDicInfo.AgeArea, DBAgendaFinanceiroDicInfo.AgeJustica, DBAgendaFinanceiroDicInfo.AgeProcesso, DBAgendaFinanceiroDicInfo.AgeIDHistorico, DBAgendaFinanceiroDicInfo.AgeIDInsProcesso, DBAgendaFinanceiroDicInfo.AgeUsuario, DBAgendaFinanceiroDicInfo.AgePreposto, DBAgendaFinanceiroDicInfo.AgeQuemID, DBAgendaFinanceiroDicInfo.AgeQuemCodigo, DBAgendaFinanceiroDicInfo.AgeStatus, DBAgendaFinanceiroDicInfo.AgeValor, DBAgendaFinanceiroDicInfo.AgeCompromissoHTML, DBAgendaFinanceiroDicInfo.AgeDecisao, DBAgendaFinanceiroDicInfo.AgeRevisar, DBAgendaFinanceiroDicInfo.AgeRevisarP2, DBAgendaFinanceiroDicInfo.AgeSempre, DBAgendaFinanceiroDicInfo.AgePrazoDias, DBAgendaFinanceiroDicInfo.AgeProtocoloIntegrado, DBAgendaFinanceiroDicInfo.AgeDataInicioPrazo, DBAgendaFinanceiroDicInfo.AgeUsuarioCiente, DBAgendaFinanceiroDicInfo.AgeGUID];

    public static ImmutableArray<DBInfoSystem> ListPk()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["ageCodigo"]);
        var result = campos.Where(campo => !campo.Equals(DBAgendaFinanceiroDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }

    public static ImmutableArray<DBInfoSystem> ListPkIndices()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["ageCodigo"]);
        var result = campos.Where(campo => !campo.Equals(DBAgendaFinanceiroDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }
}
#endif
