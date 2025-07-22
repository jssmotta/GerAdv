// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBTipoModeloDocumento
{
    public const string CadastroGuid = "65927bd0-4d2e-4159-ba1c-136c1050b5cb";
    public const string PTabelaNome = "TipoModeloDocumento";
    public const string CamposSqlX = " TipoModeloDocumento.* ";
    public const string SensivelCamposSqlX = " TipoModeloDocumento.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "tpdCodigo";
    public const string CampoNome = "tpdNome";
    public const string PTabelaPrefixo = "tpd";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}