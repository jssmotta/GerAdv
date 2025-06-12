// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBOperadorEMailPopup
{
    public const string CadastroGuid = "db42a519-a7ab-4494-a991-316f4593d823";
    public const string PTabelaNome = "OperadorEMailPopup";
    public const string CamposSqlX = " OperadorEMailPopup.* ";
    public const string SensivelCamposSqlX = " OperadorEMailPopup.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "oepCodigo";
    public const string CampoNome = "oepNome";
    public const string PTabelaPrefixo = "oep";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}