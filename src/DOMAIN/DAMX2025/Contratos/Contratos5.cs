// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBContratos
{
    public const string CadastroGuid = "04a6c728-d660-48dc-be2c-449e4c553b02";
    public const string PTabelaNome = "Contratos";
    public const string CamposSqlX = " Contratos.* ";
    public const string SensivelCamposSqlX = " Contratos.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "cttCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "ctt";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}