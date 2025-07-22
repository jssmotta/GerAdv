// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBGruposEmpresasCli
{
    public const string CadastroGuid = "561908bf-d1a1-4603-8f83-1063ca73003b";
    public const string PTabelaNome = "GruposEmpresasCli";
    public const string CamposSqlX = " GruposEmpresasCli.* ";
    public const string SensivelCamposSqlX = " GruposEmpresasCli.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "gecCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "gec";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}