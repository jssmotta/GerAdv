// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBContatoCRM
{
    public const string CadastroGuid = "a8c0b22a-4cb9-462b-9c77-9e93d8bb0452";
    public const string PTabelaNome = "ContatoCRM";
    public const string CamposSqlX = " ContatoCRM.* ";
    public const string SensivelCamposSqlX = " ContatoCRM.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "ctcCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "ctc";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}