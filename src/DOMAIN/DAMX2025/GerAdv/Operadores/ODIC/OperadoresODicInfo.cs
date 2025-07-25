#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBOperadoresODicInfo : IODicInfo
{
    public ImmutableArray<DBInfoSystem> IListFields() => List;
    public ImmutableArray<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public ImmutableArray<DBInfoSystem> IPkFields() => ListPk();
    public ImmutableArray<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ITabelaNome() => DBOperadoresDicInfo.TabelaNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoCodigo() => DBOperadoresDicInfo.CampoCodigo;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string IPrefixo() => DBOperadoresDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasAuditor() => true;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasNameId() => true;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoNome() => DBOperadoresDicInfo.CampoNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string NameSpace() => nameof(GerAdv);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TemAuditor() => true;
    private static readonly FrozenDictionary<string, DBInfoSystem> _fieldLookup = List.ToFrozenDictionary(f => f.FNome, StringComparer.OrdinalIgnoreCase);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DBInfoSystem? GetInfoSystemByNameField(string campo) => _fieldLookup.GetValueOrDefault(campo);
    public static string TCampoCodigo => DBOperadoresDicInfo.CampoCodigo;
    public static string TCampoNome => DBOperadoresDicInfo.CampoNome;
    public static string TTabelaNome => DBOperadoresDicInfo.TabelaNome;
    public static string TTablePrefix => DBOperadoresDicInfo.TablePrefix;
    public static ImmutableArray<DBInfoSystem> List => [DBOperadoresDicInfo.OperEnviado, DBOperadoresDicInfo.OperCasa, DBOperadoresDicInfo.OperCasaID, DBOperadoresDicInfo.OperCasaCodigo, DBOperadoresDicInfo.OperIsNovo, DBOperadoresDicInfo.OperCliente, DBOperadoresDicInfo.OperGrupo, DBOperadoresDicInfo.OperNome, DBOperadoresDicInfo.OperEMail, DBOperadoresDicInfo.OperSenha, DBOperadoresDicInfo.OperAtivado, DBOperadoresDicInfo.OperAtualizarSenha, DBOperadoresDicInfo.OperSenha256, DBOperadoresDicInfo.OperSuporteSenha256, DBOperadoresDicInfo.OperSuporteMaxAge, DBOperadoresDicInfo.OperQuemCad, DBOperadoresDicInfo.OperDtCad, DBOperadoresDicInfo.OperQuemAtu, DBOperadoresDicInfo.OperDtAtu, DBOperadoresDicInfo.OperVisto];
    public static ImmutableArray<DBInfoSystem> ListWithoutAuditor => [DBOperadoresDicInfo.OperEnviado, DBOperadoresDicInfo.OperCasa, DBOperadoresDicInfo.OperCasaID, DBOperadoresDicInfo.OperCasaCodigo, DBOperadoresDicInfo.OperIsNovo, DBOperadoresDicInfo.OperCliente, DBOperadoresDicInfo.OperGrupo, DBOperadoresDicInfo.OperNome, DBOperadoresDicInfo.OperEMail, DBOperadoresDicInfo.OperSenha, DBOperadoresDicInfo.OperAtivado, DBOperadoresDicInfo.OperAtualizarSenha, DBOperadoresDicInfo.OperSenha256, DBOperadoresDicInfo.OperSuporteSenha256, DBOperadoresDicInfo.OperSuporteMaxAge];

    public static ImmutableArray<DBInfoSystem> ListPk()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["operCodigo"]);
        var result = campos.Where(campo => !campo.Equals(DBOperadoresDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }

    public static ImmutableArray<DBInfoSystem> ListPkIndices()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["operCodigo", "operNome"]);
        var result = campos.Where(campo => !campo.Equals(DBOperadoresDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }
}
#endif
