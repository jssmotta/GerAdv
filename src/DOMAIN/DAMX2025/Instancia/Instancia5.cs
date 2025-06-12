// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBInstancia
{
    public const string CadastroGuid = "3b4c9b77-1ffb-4911-b0a3-b00fd1b54268";
    public const string PTabelaNome = "Instancia";
    public const string CamposSqlX = " Instancia.* ";
    public const string SensivelCamposSqlX = " Instancia.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "insCodigo";
    public const string CampoNome = "insNroProcesso";
    public const string PTabelaPrefixo = "ins";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}