// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBHorasTrab
{
    public const string CadastroGuid = "20846f98-4d22-4627-9166-88ea7fabc557";
    public const string PTabelaNome = "HorasTrab";
    public const string CamposSqlX = " HorasTrab.* ";
    public const string SensivelCamposSqlX = " HorasTrab.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "htbCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "htb";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}