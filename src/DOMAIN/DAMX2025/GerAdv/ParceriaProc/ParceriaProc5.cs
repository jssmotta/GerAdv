// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBParceriaProc
{
    public const string CadastroGuid = "7945e61a-321c-4196-bbd1-afeb7fccdb47";
    public const string PTabelaNome = "ParceriaProc";
    public const string CamposSqlX = " ParceriaProc.* ";
    public const string SensivelCamposSqlX = " ParceriaProc.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "parCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "par";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}