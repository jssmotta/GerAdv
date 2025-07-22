// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBSituacao
{
    public const string CadastroGuid = "23bff2f8-d595-4a5d-b943-4eff761fe4d4";
    public const string PTabelaNome = "Situacao";
    public const string CamposSqlX = " Situacao.* ";
    public const string SensivelCamposSqlX = " Situacao.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "sitCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "sit";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}