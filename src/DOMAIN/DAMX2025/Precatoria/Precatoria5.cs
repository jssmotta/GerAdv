// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBPrecatoria
{
    public const string CadastroGuid = "534f1e97-cb4b-44f6-9a86-1b3728c8e2b9";
    public const string PTabelaNome = "Precatoria";
    public const string CamposSqlX = " Precatoria.* ";
    public const string SensivelCamposSqlX = " Precatoria.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "preCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "pre";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}