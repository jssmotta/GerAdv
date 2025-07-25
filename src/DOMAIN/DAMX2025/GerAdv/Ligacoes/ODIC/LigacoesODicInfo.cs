#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBLigacoesODicInfo : IODicInfo
{
    public ImmutableArray<DBInfoSystem> IListFields() => List;
    public ImmutableArray<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public ImmutableArray<DBInfoSystem> IPkFields() => ListPk();
    public ImmutableArray<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ITabelaNome() => DBLigacoesDicInfo.TabelaNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoCodigo() => DBLigacoesDicInfo.CampoCodigo;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string IPrefixo() => DBLigacoesDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasAuditor() => true;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasNameId() => true;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoNome() => DBLigacoesDicInfo.CampoNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string NameSpace() => nameof(GerAdv);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TemAuditor() => true;
    private static readonly FrozenDictionary<string, DBInfoSystem> _fieldLookup = List.ToFrozenDictionary(f => f.FNome, StringComparer.OrdinalIgnoreCase);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DBInfoSystem? GetInfoSystemByNameField(string campo) => _fieldLookup.GetValueOrDefault(campo);
    public static string TCampoCodigo => DBLigacoesDicInfo.CampoCodigo;
    public static string TCampoNome => DBLigacoesDicInfo.CampoNome;
    public static string TTabelaNome => DBLigacoesDicInfo.TabelaNome;
    public static string TTablePrefix => DBLigacoesDicInfo.TablePrefix;
    public static ImmutableArray<DBInfoSystem> List => [DBLigacoesDicInfo.LigAssunto, DBLigacoesDicInfo.LigAgeClienteAvisado, DBLigacoesDicInfo.LigCelular, DBLigacoesDicInfo.LigCliente, DBLigacoesDicInfo.LigContato, DBLigacoesDicInfo.LigDataRealizada, DBLigacoesDicInfo.LigQuemID, DBLigacoesDicInfo.LigTelefonista, DBLigacoesDicInfo.LigUltimoAviso, DBLigacoesDicInfo.LigHoraFinal, DBLigacoesDicInfo.LigNome, DBLigacoesDicInfo.LigQuemCodigo, DBLigacoesDicInfo.LigSolicitante, DBLigacoesDicInfo.LigPara, DBLigacoesDicInfo.LigFone, DBLigacoesDicInfo.LigRamal, DBLigacoesDicInfo.LigParticular, DBLigacoesDicInfo.LigRealizada, DBLigacoesDicInfo.LigStatus, DBLigacoesDicInfo.LigData, DBLigacoesDicInfo.LigHora, DBLigacoesDicInfo.LigUrgente, DBLigacoesDicInfo.LigLigarPara, DBLigacoesDicInfo.LigProcesso, DBLigacoesDicInfo.LigStartScreen, DBLigacoesDicInfo.LigEmotion, DBLigacoesDicInfo.LigBold, DBLigacoesDicInfo.LigGUID, DBLigacoesDicInfo.LigQuemCad, DBLigacoesDicInfo.LigDtCad, DBLigacoesDicInfo.LigQuemAtu, DBLigacoesDicInfo.LigDtAtu, DBLigacoesDicInfo.LigVisto];
    public static ImmutableArray<DBInfoSystem> ListWithoutAuditor => [DBLigacoesDicInfo.LigAssunto, DBLigacoesDicInfo.LigAgeClienteAvisado, DBLigacoesDicInfo.LigCelular, DBLigacoesDicInfo.LigCliente, DBLigacoesDicInfo.LigContato, DBLigacoesDicInfo.LigDataRealizada, DBLigacoesDicInfo.LigQuemID, DBLigacoesDicInfo.LigTelefonista, DBLigacoesDicInfo.LigUltimoAviso, DBLigacoesDicInfo.LigHoraFinal, DBLigacoesDicInfo.LigNome, DBLigacoesDicInfo.LigQuemCodigo, DBLigacoesDicInfo.LigSolicitante, DBLigacoesDicInfo.LigPara, DBLigacoesDicInfo.LigFone, DBLigacoesDicInfo.LigRamal, DBLigacoesDicInfo.LigParticular, DBLigacoesDicInfo.LigRealizada, DBLigacoesDicInfo.LigStatus, DBLigacoesDicInfo.LigData, DBLigacoesDicInfo.LigHora, DBLigacoesDicInfo.LigUrgente, DBLigacoesDicInfo.LigLigarPara, DBLigacoesDicInfo.LigProcesso, DBLigacoesDicInfo.LigStartScreen, DBLigacoesDicInfo.LigEmotion, DBLigacoesDicInfo.LigGUID];

    public static ImmutableArray<DBInfoSystem> ListPk()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["ligCodigo"]);
        var result = campos.Where(campo => !campo.Equals(DBLigacoesDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }

    public static ImmutableArray<DBInfoSystem> ListPkIndices()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["ligCodigo"]);
        var result = campos.Where(campo => !campo.Equals(DBLigacoesDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }
}
#endif
