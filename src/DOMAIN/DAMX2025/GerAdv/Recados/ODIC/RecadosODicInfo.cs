#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBRecadosODicInfo : IODicInfo
{
    public ImmutableArray<DBInfoSystem> IListFields() => List;
    public ImmutableArray<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public ImmutableArray<DBInfoSystem> IPkFields() => ListPk();
    public ImmutableArray<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ITabelaNome() => DBRecadosDicInfo.TabelaNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoCodigo() => DBRecadosDicInfo.CampoCodigo;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string IPrefixo() => DBRecadosDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasAuditor() => true;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasNameId() => false;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoNome() => DBRecadosDicInfo.CampoNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string NameSpace() => nameof(GerAdv);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TemAuditor() => true;
    private static readonly FrozenDictionary<string, DBInfoSystem> _fieldLookup = List.ToFrozenDictionary(f => f.FNome, StringComparer.OrdinalIgnoreCase);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DBInfoSystem? GetInfoSystemByNameField(string campo) => _fieldLookup.GetValueOrDefault(campo);
    public static string TCampoCodigo => DBRecadosDicInfo.CampoCodigo;
    public static string TCampoNome => DBRecadosDicInfo.CampoNome;
    public static string TTabelaNome => DBRecadosDicInfo.TabelaNome;
    public static string TTablePrefix => DBRecadosDicInfo.TablePrefix;
    public static ImmutableArray<DBInfoSystem> List => [DBRecadosDicInfo.RecClienteNome, DBRecadosDicInfo.RecDe, DBRecadosDicInfo.RecPara, DBRecadosDicInfo.RecAssunto, DBRecadosDicInfo.RecConcluido, DBRecadosDicInfo.RecProcesso, DBRecadosDicInfo.RecCliente, DBRecadosDicInfo.RecRecado, DBRecadosDicInfo.RecUrgente, DBRecadosDicInfo.RecImportante, DBRecadosDicInfo.RecHora, DBRecadosDicInfo.RecData, DBRecadosDicInfo.RecVoltara, DBRecadosDicInfo.RecPessoal, DBRecadosDicInfo.RecRetornar, DBRecadosDicInfo.RecRetornoData, DBRecadosDicInfo.RecEmotion, DBRecadosDicInfo.RecInternetID, DBRecadosDicInfo.RecUploaded, DBRecadosDicInfo.RecNatureza, DBRecadosDicInfo.RecBIU, DBRecadosDicInfo.RecAguardarRetorno, DBRecadosDicInfo.RecAguardarRetornoPara, DBRecadosDicInfo.RecAguardarRetornoOK, DBRecadosDicInfo.RecParaID, DBRecadosDicInfo.RecNaoPublicavel, DBRecadosDicInfo.RecIsContatoCRM, DBRecadosDicInfo.RecMasterID, DBRecadosDicInfo.RecListaPara, DBRecadosDicInfo.RecTyped, DBRecadosDicInfo.RecAssuntoRecado, DBRecadosDicInfo.RecHistorico, DBRecadosDicInfo.RecContatoCRM, DBRecadosDicInfo.RecLigacoes, DBRecadosDicInfo.RecAgenda, DBRecadosDicInfo.RecGUID, DBRecadosDicInfo.RecQuemCad, DBRecadosDicInfo.RecDtCad, DBRecadosDicInfo.RecQuemAtu, DBRecadosDicInfo.RecDtAtu, DBRecadosDicInfo.RecVisto];
    public static ImmutableArray<DBInfoSystem> ListWithoutAuditor => [DBRecadosDicInfo.RecClienteNome, DBRecadosDicInfo.RecDe, DBRecadosDicInfo.RecPara, DBRecadosDicInfo.RecAssunto, DBRecadosDicInfo.RecConcluido, DBRecadosDicInfo.RecProcesso, DBRecadosDicInfo.RecCliente, DBRecadosDicInfo.RecRecado, DBRecadosDicInfo.RecUrgente, DBRecadosDicInfo.RecImportante, DBRecadosDicInfo.RecHora, DBRecadosDicInfo.RecData, DBRecadosDicInfo.RecVoltara, DBRecadosDicInfo.RecPessoal, DBRecadosDicInfo.RecRetornar, DBRecadosDicInfo.RecRetornoData, DBRecadosDicInfo.RecEmotion, DBRecadosDicInfo.RecInternetID, DBRecadosDicInfo.RecUploaded, DBRecadosDicInfo.RecNatureza, DBRecadosDicInfo.RecBIU, DBRecadosDicInfo.RecAguardarRetorno, DBRecadosDicInfo.RecAguardarRetornoPara, DBRecadosDicInfo.RecAguardarRetornoOK, DBRecadosDicInfo.RecParaID, DBRecadosDicInfo.RecNaoPublicavel, DBRecadosDicInfo.RecIsContatoCRM, DBRecadosDicInfo.RecMasterID, DBRecadosDicInfo.RecListaPara, DBRecadosDicInfo.RecTyped, DBRecadosDicInfo.RecAssuntoRecado, DBRecadosDicInfo.RecHistorico, DBRecadosDicInfo.RecContatoCRM, DBRecadosDicInfo.RecLigacoes, DBRecadosDicInfo.RecAgenda, DBRecadosDicInfo.RecGUID];

    public static ImmutableArray<DBInfoSystem> ListPk()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["recCodigo"]);
        var result = campos.Where(campo => !campo.Equals(DBRecadosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }

    public static ImmutableArray<DBInfoSystem> ListPkIndices()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["recCodigo"]);
        var result = campos.Where(campo => !campo.Equals(DBRecadosDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }
}
#endif
