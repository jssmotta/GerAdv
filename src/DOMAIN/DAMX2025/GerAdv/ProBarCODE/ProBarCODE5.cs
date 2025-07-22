// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBProBarCODE
{
    public const string CadastroGuid = "6cfc1a3d-4d4b-4e68-84a5-68123749d5df";
    public const string PTabelaNome = "ProBarCODE";
    public const string CamposSqlX = " ProBarCODE.* ";
    public const string SensivelCamposSqlX = " ProBarCODE.* ";
    public static string CamposSqlAlias => CamposSqlX;
    public static string CampoCodigo => "";

    public const string CampoNome = "";
    public const string PTabelaPrefixo = "pbc";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}