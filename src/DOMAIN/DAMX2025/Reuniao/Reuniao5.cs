// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBReuniao
{
    public const string CadastroGuid = "882c2384-1317-4666-9029-731704a802cd";
    public const string PTabelaNome = "Reuniao";
    public const string CamposSqlX = " Reuniao.* ";
    public const string SensivelCamposSqlX = " Reuniao.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "renCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "ren";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}