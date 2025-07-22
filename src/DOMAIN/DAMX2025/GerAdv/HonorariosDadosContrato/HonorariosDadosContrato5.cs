// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBHonorariosDadosContrato
{
    public const string CadastroGuid = "58ba3455-bf80-4cf3-b932-0dab9c435db7";
    public const string PTabelaNome = "HonorariosDadosContrato";
    public const string CamposSqlX = " HonorariosDadosContrato.* ";
    public const string SensivelCamposSqlX = " HonorariosDadosContrato.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "hdcCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "hdc";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}