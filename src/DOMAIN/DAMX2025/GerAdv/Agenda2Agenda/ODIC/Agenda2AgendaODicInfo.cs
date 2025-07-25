#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBAgenda2AgendaODicInfo : IODicInfo
{
    public ImmutableArray<DBInfoSystem> IListFields() => List;
    public ImmutableArray<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public ImmutableArray<DBInfoSystem> IPkFields() => ListPk();
    public ImmutableArray<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ITabelaNome() => DBAgenda2AgendaDicInfo.TabelaNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoCodigo() => DBAgenda2AgendaDicInfo.CampoCodigo;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string IPrefixo() => DBAgenda2AgendaDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasAuditor() => true;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasNameId() => false;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoNome() => DBAgenda2AgendaDicInfo.CampoNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string NameSpace() => nameof(GerAdv);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TemAuditor() => true;
    private static readonly FrozenDictionary<string, DBInfoSystem> _fieldLookup = List.ToFrozenDictionary(f => f.FNome, StringComparer.OrdinalIgnoreCase);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DBInfoSystem? GetInfoSystemByNameField(string campo) => _fieldLookup.GetValueOrDefault(campo);
    public static string TCampoCodigo => DBAgenda2AgendaDicInfo.CampoCodigo;
    public static string TCampoNome => DBAgenda2AgendaDicInfo.CampoNome;
    public static string TTabelaNome => DBAgenda2AgendaDicInfo.TabelaNome;
    public static string TTablePrefix => DBAgenda2AgendaDicInfo.TablePrefix;
    public static ImmutableArray<DBInfoSystem> List => [DBAgenda2AgendaDicInfo.Ag2Master, DBAgenda2AgendaDicInfo.Ag2Agenda, DBAgenda2AgendaDicInfo.Ag2QuemCad, DBAgenda2AgendaDicInfo.Ag2DtCad, DBAgenda2AgendaDicInfo.Ag2QuemAtu, DBAgenda2AgendaDicInfo.Ag2DtAtu, DBAgenda2AgendaDicInfo.Ag2Visto];
    public static ImmutableArray<DBInfoSystem> ListWithoutAuditor => [DBAgenda2AgendaDicInfo.Ag2Master, DBAgenda2AgendaDicInfo.Ag2Agenda];

    public static ImmutableArray<DBInfoSystem> ListPk()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["ag2Codigo"]);
        var result = campos.Where(campo => !campo.Equals(DBAgenda2AgendaDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }

    public static ImmutableArray<DBInfoSystem> ListPkIndices()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["ag2Agenda", "ag2Codigo", "ag2Master"]);
        var result = campos.Where(campo => !campo.Equals(DBAgenda2AgendaDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }
}
#endif
