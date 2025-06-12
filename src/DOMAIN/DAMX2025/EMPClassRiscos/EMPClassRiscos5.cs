// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBEMPClassRiscos
{
    public const string CadastroGuid = "ec6c2f4b-cbe2-4e5d-855b-7f207dd3430d";
    public const string PTabelaNome = "EMPClassRiscos";
    public const string CamposSqlX = " EMPClassRiscos.* ";
    public const string SensivelCamposSqlX = " EMPClassRiscos.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "ecrCodigo";
    public const string CampoNome = "ecrNome";
    public const string PTabelaPrefixo = "ecr";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}