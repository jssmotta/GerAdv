#if (!MenphisSI_SG_GerAdv_DicOff)
// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv.DicInfo;
[Serializable]
public partial class DBClientesODicInfo : IODicInfo
{
    public ImmutableArray<DBInfoSystem> IListFields() => List;
    public ImmutableArray<DBInfoSystem> IFieldsRaw() => ListWithoutAuditor;
    public ImmutableArray<DBInfoSystem> IPkFields() => ListPk();
    public ImmutableArray<DBInfoSystem> IPkIndicesFields() => ListPkIndices();
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ITabelaNome() => DBClientesDicInfo.TabelaNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoCodigo() => DBClientesDicInfo.CampoCodigo;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string IPrefixo() => DBClientesDicInfo.TablePrefix;
#pragma warning disable CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasAuditor() => true;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool HasNameId() => true;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IIsStoredProcedureOrView() => false;
#pragma warning restore CA1822 // Mark members as static

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ICampoNome() => DBClientesDicInfo.CampoNome;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string NameSpace() => nameof(GerAdv);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TemAuditor() => true;
    private static readonly FrozenDictionary<string, DBInfoSystem> _fieldLookup = List.ToFrozenDictionary(f => f.FNome, StringComparer.OrdinalIgnoreCase);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DBInfoSystem? GetInfoSystemByNameField(string campo) => _fieldLookup.GetValueOrDefault(campo);
    public static string TCampoCodigo => DBClientesDicInfo.CampoCodigo;
    public static string TCampoNome => DBClientesDicInfo.CampoNome;
    public static string TTabelaNome => DBClientesDicInfo.TabelaNome;
    public static string TTablePrefix => DBClientesDicInfo.TablePrefix;
    public static ImmutableArray<DBInfoSystem> List => [DBClientesDicInfo.CliEmpresa, DBClientesDicInfo.CliIcone, DBClientesDicInfo.CliNomeMae, DBClientesDicInfo.CliRGDataExp, DBClientesDicInfo.CliInativo, DBClientesDicInfo.CliQuemIndicou, DBClientesDicInfo.CliSendEMail, DBClientesDicInfo.CliNome, DBClientesDicInfo.CliAdv, DBClientesDicInfo.CliIDRep, DBClientesDicInfo.CliJuridica, DBClientesDicInfo.CliNomeFantasia, DBClientesDicInfo.CliClass, DBClientesDicInfo.CliTipo, DBClientesDicInfo.CliDtNasc, DBClientesDicInfo.CliInscEst, DBClientesDicInfo.CliQualificacao, DBClientesDicInfo.CliSexo, DBClientesDicInfo.CliIdade, DBClientesDicInfo.CliCNPJ, DBClientesDicInfo.CliCPF, DBClientesDicInfo.CliRG, DBClientesDicInfo.CliTipoCaptacao, DBClientesDicInfo.CliObservacao, DBClientesDicInfo.CliEndereco, DBClientesDicInfo.CliBairro, DBClientesDicInfo.CliCidade, DBClientesDicInfo.CliCEP, DBClientesDicInfo.CliFax, DBClientesDicInfo.CliFone, DBClientesDicInfo.CliData, DBClientesDicInfo.CliHomePage, DBClientesDicInfo.CliEMail, DBClientesDicInfo.CliObito, DBClientesDicInfo.CliNomePai, DBClientesDicInfo.CliRGOExpeditor, DBClientesDicInfo.CliRegimeTributacao, DBClientesDicInfo.CliEnquadramentoEmpresa, DBClientesDicInfo.CliReportECBOnly, DBClientesDicInfo.CliProBono, DBClientesDicInfo.CliCNH, DBClientesDicInfo.CliPessoaContato, DBClientesDicInfo.CliEtiqueta, DBClientesDicInfo.CliAni, DBClientesDicInfo.CliBold, DBClientesDicInfo.CliGUID, DBClientesDicInfo.CliQuemCad, DBClientesDicInfo.CliDtCad, DBClientesDicInfo.CliQuemAtu, DBClientesDicInfo.CliDtAtu, DBClientesDicInfo.CliVisto];
    public static ImmutableArray<DBInfoSystem> ListWithoutAuditor => [DBClientesDicInfo.CliEmpresa, DBClientesDicInfo.CliIcone, DBClientesDicInfo.CliNomeMae, DBClientesDicInfo.CliRGDataExp, DBClientesDicInfo.CliInativo, DBClientesDicInfo.CliQuemIndicou, DBClientesDicInfo.CliSendEMail, DBClientesDicInfo.CliNome, DBClientesDicInfo.CliAdv, DBClientesDicInfo.CliIDRep, DBClientesDicInfo.CliJuridica, DBClientesDicInfo.CliNomeFantasia, DBClientesDicInfo.CliClass, DBClientesDicInfo.CliTipo, DBClientesDicInfo.CliDtNasc, DBClientesDicInfo.CliInscEst, DBClientesDicInfo.CliQualificacao, DBClientesDicInfo.CliSexo, DBClientesDicInfo.CliIdade, DBClientesDicInfo.CliCNPJ, DBClientesDicInfo.CliCPF, DBClientesDicInfo.CliRG, DBClientesDicInfo.CliTipoCaptacao, DBClientesDicInfo.CliObservacao, DBClientesDicInfo.CliEndereco, DBClientesDicInfo.CliBairro, DBClientesDicInfo.CliCidade, DBClientesDicInfo.CliCEP, DBClientesDicInfo.CliFax, DBClientesDicInfo.CliFone, DBClientesDicInfo.CliData, DBClientesDicInfo.CliHomePage, DBClientesDicInfo.CliEMail, DBClientesDicInfo.CliObito, DBClientesDicInfo.CliNomePai, DBClientesDicInfo.CliRGOExpeditor, DBClientesDicInfo.CliRegimeTributacao, DBClientesDicInfo.CliEnquadramentoEmpresa, DBClientesDicInfo.CliReportECBOnly, DBClientesDicInfo.CliProBono, DBClientesDicInfo.CliCNH, DBClientesDicInfo.CliPessoaContato, DBClientesDicInfo.CliGUID];

    public static ImmutableArray<DBInfoSystem> ListPk()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["cliCodigo"]);
        var result = campos.Where(campo => !campo.Equals(DBClientesDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }

    public static ImmutableArray<DBInfoSystem> ListPkIndices()
    {
        ImmutableArray<string> campos = ImmutableArray.CreateRange(["cliCodigo", "cliNome"]);
        var result = campos.Where(campo => !campo.Equals(DBClientesDicInfo.CampoCodigo)).Select(campo => List.FirstOrDefault(t => t.FNome == campo)).Where(item => item != null).Cast<DBInfoSystem>().Distinct().ToList();
        return result.Count > 0 ? [..result] : ImmutableArray<DBInfoSystem>.Empty;
    }
}
#endif
