// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBAndComp
{
    public const string CadastroGuid = "4cc49faf-a28c-459e-bfd3-5cee03e08823";
    public const string PTabelaNome = "AndComp";
    public const string CamposSqlX = " AndComp.* ";
    public const string SensivelCamposSqlX = " AndComp.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "acpCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "acp";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}