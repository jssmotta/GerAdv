// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBRecados
{
    public const string CadastroGuid = "32275cd3-f212-4fa5-a55d-6560d381690c";
    public const string PTabelaNome = "Recados";
    public const string CamposSqlX = " Recados.* ";
    public const string SensivelCamposSqlX = " Recados.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "recCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "rec";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}