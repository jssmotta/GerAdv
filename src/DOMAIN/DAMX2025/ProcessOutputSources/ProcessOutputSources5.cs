// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBProcessOutputSources
{
    public const string CadastroGuid = "e720813e-25fc-4b1a-97c9-c742b6fdc711";
    public const string PTabelaNome = "ProcessOutputSources";
    public const string CamposSqlX = " ProcessOutputSources.* ";
    public const string SensivelCamposSqlX = " ProcessOutputSources.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "posCodigo";
    public const string CampoNome = "posNome";
    public const string PTabelaPrefixo = "pos";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}