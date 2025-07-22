// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBStatusInstancia
{
    public const string CadastroGuid = "d416179b-dabd-431a-86e4-1041826653ef";
    public const string PTabelaNome = "StatusInstancia";
    public const string CamposSqlX = " StatusInstancia.* ";
    public const string SensivelCamposSqlX = " StatusInstancia.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "istCodigo";
    public const string CampoNome = "istNome";
    public const string PTabelaPrefixo = "ist";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}