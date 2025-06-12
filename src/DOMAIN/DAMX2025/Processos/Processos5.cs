// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBProcessos
{
    public const string CadastroGuid = "262273ef-2d62-4c0b-ac25-c7298737a7df";
    public const string PTabelaNome = "Processos";
    public const string CamposSqlX = " Processos.* ";
    public const string SensivelCamposSqlX = " Processos.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "proCodigo";
    public const string CampoNome = "proNroPasta";
    public const string PTabelaPrefixo = "pro";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}