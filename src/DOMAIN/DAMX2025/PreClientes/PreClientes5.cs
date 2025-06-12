// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBPreClientes
{
    public const string CadastroGuid = "90d2a515-a31f-4ea2-8ea0-5992aad18979";
    public const string PTabelaNome = "PreClientes";
    public const string CamposSqlX = " PreClientes.* ";
    public const string SensivelCamposSqlX = " PreClientes.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "cliCodigo";
    public const string CampoNome = "cliNome";
    public const string PTabelaPrefixo = "cli";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}