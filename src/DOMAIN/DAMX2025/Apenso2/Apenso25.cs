// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBApenso2
{
    public const string CadastroGuid = "dcdcf6a2-f011-49bb-a4c8-ae96b3a3ce55";
    public const string PTabelaNome = "Apenso2";
    public const string CamposSqlX = " Apenso2.* ";
    public const string SensivelCamposSqlX = " Apenso2.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "ap2Codigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "ap2";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}