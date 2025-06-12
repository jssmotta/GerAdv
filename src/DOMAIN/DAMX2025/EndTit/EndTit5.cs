// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBEndTit
{
    public const string CadastroGuid = "f94727d6-e2fe-4175-88c8-938ead99d373";
    public const string PTabelaNome = "EndTit";
    public const string CamposSqlX = " EndTit.* ";
    public const string SensivelCamposSqlX = " EndTit.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "ettCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "ett";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}