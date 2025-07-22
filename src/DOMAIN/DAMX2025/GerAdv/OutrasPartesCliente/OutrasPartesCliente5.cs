// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBOutrasPartesCliente
{
    public const string CadastroGuid = "1f60b05c-e179-4ea4-8f0f-c69915a7175f";
    public const string PTabelaNome = "OutrasPartesCliente";
    public const string CamposSqlX = " OutrasPartesCliente.* ";
    public const string SensivelCamposSqlX = " OutrasPartesCliente.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "opcCodigo";
    public const string CampoNome = "opcNome";
    public const string PTabelaPrefixo = "opc";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}