// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBUltimosProcessos
{
    public const string CadastroGuid = "ed23ee2c-85ac-43f7-bba3-293580068db1";
    public const string PTabelaNome = "UltimosProcessos";
    public const string CamposSqlX = " UltimosProcessos.* ";
    public const string SensivelCamposSqlX = " UltimosProcessos.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "ultCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "ult";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}