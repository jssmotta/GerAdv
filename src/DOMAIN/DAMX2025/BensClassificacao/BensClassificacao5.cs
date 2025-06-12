// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBBensClassificacao
{
    public const string CadastroGuid = "60ab272e-7169-4e0e-a1e4-4f669f1622d9";
    public const string PTabelaNome = "BensClassificacao";
    public const string CamposSqlX = " BensClassificacao.* ";
    public const string SensivelCamposSqlX = " BensClassificacao.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "bcsCodigo";
    public const string CampoNome = "bcsNome";
    public const string PTabelaPrefixo = "bcs";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}