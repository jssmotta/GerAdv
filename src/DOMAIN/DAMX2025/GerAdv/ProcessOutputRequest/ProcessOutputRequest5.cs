// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBProcessOutputRequest
{
    public const string CadastroGuid = "f9076107-adce-401f-8f19-f78c6f573b0e";
    public const string PTabelaNome = "ProcessOutputRequest";
    public const string CamposSqlX = " ProcessOutputRequest.* ";
    public const string SensivelCamposSqlX = " ProcessOutputRequest.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "porCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "por";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}