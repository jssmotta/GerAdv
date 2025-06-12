// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBGraph
{
    public const string CadastroGuid = "1e1eed82-357f-4ff1-b7c0-d0b582579ebf";
    public const string PTabelaNome = "Graph";
    public const string CamposSqlX = " Graph.* ";
    public const string SensivelCamposSqlX = " Graph.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "gphCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "gph";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}