// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBEnderecoSistema
{
    public const string CadastroGuid = "4decbea7-1574-4bce-bf54-6b644c67ed74";
    public const string PTabelaNome = "EnderecoSistema";
    public const string CamposSqlX = " EnderecoSistema.* ";
    public const string SensivelCamposSqlX = " EnderecoSistema.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "estCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "est";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}