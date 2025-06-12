// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBViaRecebimento
{
    public const string CadastroGuid = "b346e500-5274-44b4-8b31-91b6f508a930";
    public const string PTabelaNome = "ViaRecebimento";
    public const string CamposSqlX = " ViaRecebimento.* ";
    public const string SensivelCamposSqlX = " ViaRecebimento.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "vrbCodigo";
    public const string CampoNome = "vrbNome";
    public const string PTabelaPrefixo = "vrb";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}