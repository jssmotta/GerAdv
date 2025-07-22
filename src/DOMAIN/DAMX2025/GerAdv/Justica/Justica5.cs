// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBJustica
{
    public const string CadastroGuid = "30cab9c6-3b84-4ff5-a320-54fcc6ff8685";
    public const string PTabelaNome = "Justica";
    public const string CamposSqlX = " Justica.* ";
    public const string SensivelCamposSqlX = " Justica.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "jusCodigo";
    public const string CampoNome = "jusNome";
    public const string PTabelaPrefixo = "jus";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}