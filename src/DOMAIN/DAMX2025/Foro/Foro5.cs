// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBForo
{
    public const string CadastroGuid = "aa5d533f-cb3d-4a50-a25b-7cd521fc8dd7";
    public const string PTabelaNome = "Foro";
    public const string CamposSqlX = " Foro.* ";
    public const string SensivelCamposSqlX = " Foro.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "forCodigo";
    public const string CampoNome = "forNome";
    public const string PTabelaPrefixo = "for";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}