// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBTipoEMail
{
    public const string CadastroGuid = "40956813-2d7f-43b2-9ed6-e8a8925ae02b";
    public const string PTabelaNome = "TipoEMail";
    public const string CamposSqlX = " TipoEMail.* ";
    public const string SensivelCamposSqlX = " TipoEMail.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "tmlCodigo";
    public const string CampoNome = "tmlNome";
    public const string PTabelaPrefixo = "tml";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}