// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBTerceiros
{
    public const string CadastroGuid = "052bc624-ca29-4cf6-8c59-120891b34dd1";
    public const string PTabelaNome = "Terceiros";
    public const string CamposSqlX = " Terceiros.* ";
    public const string SensivelCamposSqlX = " Terceiros.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "terCodigo";
    public const string CampoNome = "terNome";
    public const string PTabelaPrefixo = "ter";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}