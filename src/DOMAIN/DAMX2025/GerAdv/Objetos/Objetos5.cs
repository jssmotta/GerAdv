// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBObjetos
{
    public const string CadastroGuid = "24ba4b17-9a36-4df5-9514-e5fadc370d1a";
    public const string PTabelaNome = "Objetos";
    public const string CamposSqlX = " Objetos.* ";
    public const string SensivelCamposSqlX = " Objetos.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "ojtCodigo";
    public const string CampoNome = "ojtNome";
    public const string PTabelaPrefixo = "ojt";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}