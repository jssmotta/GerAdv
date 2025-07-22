// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBEscritorios
{
    public const string CadastroGuid = "5f8f8f19-72d5-403a-901f-b613580d2e4f";
    public const string PTabelaNome = "Escritorios";
    public const string CamposSqlX = " Escritorios.* ";
    public const string SensivelCamposSqlX = " Escritorios.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "escCodigo";
    public const string CampoNome = "escNome";
    public const string PTabelaPrefixo = "esc";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}