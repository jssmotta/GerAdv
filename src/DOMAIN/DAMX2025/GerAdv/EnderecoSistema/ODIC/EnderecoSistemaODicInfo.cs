#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBEnderecoSistemaODicInfo : IODicInfo
{
    public ImmutableArray<DBInfoSystem> IListFields() => List;
    public ImmutableArray<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public ImmutableArray<DBInfoSystem> IPkFields() => ListPk();
    public ImmutableArray<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ITabelaNome() => DBEnderecoSistemaDicInfo.TabelaNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoCodigo() => DBEnderecoSistemaDicInfo.CampoCodigo;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string IPrefixo() => DBEnderecoSistemaDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasAuditor() => true;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasNameId() => false;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoNome() => DBEnderecoSistemaDicInfo.CampoNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string NameSpace() => nameof(GerAdv);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TemAuditor() => true;
    private static readonly FrozenDictionary<string, DBInfoSystem> _fieldLookup = List.ToFrozenDictionary(f => f.FNome, StringComparer.OrdinalIgnoreCase);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DBInfoSystem? GetInfoSystemByNameField(string campo) => _fieldLookup.GetValueOrDefault(campo);
    public static string TCampoCodigo => DBEnderecoSistemaDicInfo.CampoCodigo;
    public static string TCampoNome => DBEnderecoSistemaDicInfo.CampoNome;
    public static string TTabelaNome => DBEnderecoSistemaDicInfo.TabelaNome;
    public static string TTablePrefix => DBEnderecoSistemaDicInfo.TablePrefix;
    public static ImmutableArray<DBInfoSystem> List => [DBEnderecoSistemaDicInfo.EstCadastro, DBEnderecoSistemaDicInfo.EstCadastroExCod, DBEnderecoSistemaDicInfo.EstTipoEnderecoSistema, DBEnderecoSistemaDicInfo.EstProcesso, DBEnderecoSistemaDicInfo.EstMotivo, DBEnderecoSistemaDicInfo.EstContatoNoLocal, DBEnderecoSistemaDicInfo.EstCidade, DBEnderecoSistemaDicInfo.EstEndereco, DBEnderecoSistemaDicInfo.EstBairro, DBEnderecoSistemaDicInfo.EstCEP, DBEnderecoSistemaDicInfo.EstFone, DBEnderecoSistemaDicInfo.EstFax, DBEnderecoSistemaDicInfo.EstObservacao, DBEnderecoSistemaDicInfo.EstGUID, DBEnderecoSistemaDicInfo.EstQuemCad, DBEnderecoSistemaDicInfo.EstDtCad, DBEnderecoSistemaDicInfo.EstQuemAtu, DBEnderecoSistemaDicInfo.EstDtAtu, DBEnderecoSistemaDicInfo.EstVisto];
    public static ImmutableArray<DBInfoSystem> ListWithoutAuditor => [DBEnderecoSistemaDicInfo.EstCadastro, DBEnderecoSistemaDicInfo.EstCadastroExCod, DBEnderecoSistemaDicInfo.EstTipoEnderecoSistema, DBEnderecoSistemaDicInfo.EstProcesso, DBEnderecoSistemaDicInfo.EstMotivo, DBEnderecoSistemaDicInfo.EstContatoNoLocal, DBEnderecoSistemaDicInfo.EstCidade, DBEnderecoSistemaDicInfo.EstEndereco, DBEnderecoSistemaDicInfo.EstBairro, DBEnderecoSistemaDicInfo.EstCEP, DBEnderecoSistemaDicInfo.EstFone, DBEnderecoSistemaDicInfo.EstFax, DBEnderecoSistemaDicInfo.EstObservacao, DBEnderecoSistemaDicInfo.EstGUID];

    public static ImmutableArray<DBInfoSystem> ListPk()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["estCodigo"]);
        var result = campos.Where(campo => !campo.Equals(DBEnderecoSistemaDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }

    public static ImmutableArray<DBInfoSystem> ListPkIndices()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["estCodigo"]);
        var result = campos.Where(campo => !campo.Equals(DBEnderecoSistemaDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }
}
#endif
