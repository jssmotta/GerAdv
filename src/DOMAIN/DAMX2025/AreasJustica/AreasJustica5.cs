// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBAreasJustica
{
    public const string CadastroGuid = "c2404b2c-da3e-4d65-8b15-ba8fd844d568";
    public const string PTabelaNome = "AreasJustica";
    public const string CamposSqlX = " AreasJustica.* ";
    public const string SensivelCamposSqlX = " AreasJustica.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "arjCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "arj";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}