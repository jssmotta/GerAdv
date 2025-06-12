// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBStatusHTrab
{
    public const string CadastroGuid = "caecc283-6aa4-4299-8c29-bb13d0d461b5";
    public const string PTabelaNome = "StatusHTrab";
    public const string CamposSqlX = " StatusHTrab.* ";
    public const string SensivelCamposSqlX = " StatusHTrab.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "shtCodigo";
    public const string CampoNome = "shtDescricao";
    public const string PTabelaPrefixo = "sht";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}