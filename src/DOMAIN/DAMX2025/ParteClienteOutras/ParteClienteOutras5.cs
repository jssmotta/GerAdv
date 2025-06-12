// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBParteClienteOutras
{
    public const string CadastroGuid = "644f1875-f250-412b-87f8-963e6f3ca497";
    public const string PTabelaNome = "ParteClienteOutras";
    public const string CamposSqlX = " ParteClienteOutras.* ";
    public const string SensivelCamposSqlX = " ParteClienteOutras.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "pcoCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "pco";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}