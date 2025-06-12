// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBTribEnderecos
{
    public const string CadastroGuid = "2afc1238-3a29-4d4a-aee4-8c1e765bf211";
    public const string PTabelaNome = "TribEnderecos";
    public const string CamposSqlX = " TribEnderecos.* ";
    public const string SensivelCamposSqlX = " TribEnderecos.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "treCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "tre";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}