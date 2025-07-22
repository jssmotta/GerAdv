// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBClientes
{
    public const string CadastroGuid = "68f80361-b762-4d58-8b83-e1a790183858";
    public const string PTabelaNome = "Clientes";
    public const string CamposSqlX = " Clientes.* ";
    public const string SensivelCamposSqlX = " Clientes.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "cliCodigo";
    public const string CampoNome = "cliNome";
    public const string PTabelaPrefixo = "cli";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}