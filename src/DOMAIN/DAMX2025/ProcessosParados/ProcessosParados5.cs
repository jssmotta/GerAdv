// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBProcessosParados
{
    public const string CadastroGuid = "5aaf9af3-9b51-4041-868f-7d3623c6a1ba";
    public const string PTabelaNome = "ProcessosParados";
    public const string CamposSqlX = " ProcessosParados.* ";
    public const string SensivelCamposSqlX = " ProcessosParados.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "pprCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "ppr";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}