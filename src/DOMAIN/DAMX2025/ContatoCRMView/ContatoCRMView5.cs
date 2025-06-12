// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBContatoCRMView
{
    public const string CadastroGuid = "75a21d12-b014-4c8d-9196-6243a9c55cb7";
    public const string PTabelaNome = "ContatoCRMView";
    public const string CamposSqlX = " ContatoCRMView.* ";
    public const string SensivelCamposSqlX = " ContatoCRMView.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "ccwCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "ccw";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}