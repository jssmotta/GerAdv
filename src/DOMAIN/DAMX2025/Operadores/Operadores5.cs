// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBOperadores
{
    public const string CadastroGuid = "e8b7914e-c750-4163-acfe-091e4625715c";
    public const string PTabelaNome = "Operadores";
    public const string CamposSqlX = " Operadores.* ";
    public const string SensivelCamposSqlX = " Operadores.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "operCodigo";
    public const string CampoNome = "operNome";
    public const string PTabelaPrefixo = "oper";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}