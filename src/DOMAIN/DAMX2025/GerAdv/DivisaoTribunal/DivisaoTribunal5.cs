// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBDivisaoTribunal
{
    public const string CadastroGuid = "c9d50cb2-6e39-4ff2-8162-9b198fd457d6";
    public const string PTabelaNome = "DivisaoTribunal";
    public const string CamposSqlX = " DivisaoTribunal.* ";
    public const string SensivelCamposSqlX = " DivisaoTribunal.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "divCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "div";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}