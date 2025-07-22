// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBPrepostos
{
    public const string CadastroGuid = "0f515911-252a-4cbf-bc7c-14488179be6f";
    public const string PTabelaNome = "Prepostos";
    public const string CamposSqlX = " Prepostos.* ";
    public const string SensivelCamposSqlX = " Prepostos.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "preCodigo";
    public const string CampoNome = "preNome";
    public const string PTabelaPrefixo = "pre";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}