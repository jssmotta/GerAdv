// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBProResumos
{
    public const string CadastroGuid = "1769c335-0d77-4414-bd25-628dbfa9942f";
    public const string PTabelaNome = "ProResumos";
    public const string CamposSqlX = " ProResumos.* ";
    public const string SensivelCamposSqlX = " ProResumos.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "prsCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "prs";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}