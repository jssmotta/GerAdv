// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBGUTAtividadesMatriz
{
    public const string CadastroGuid = "35fa105a-bb36-406b-b926-29f25a706590";
    public const string PTabelaNome = "GUTAtividadesMatriz";
    public const string CamposSqlX = " GUTAtividadesMatriz.* ";
    public const string SensivelCamposSqlX = " GUTAtividadesMatriz.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "amgCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "amg";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}