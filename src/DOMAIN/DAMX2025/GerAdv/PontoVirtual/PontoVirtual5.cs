// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBPontoVirtual
{
    public const string CadastroGuid = "0c7c8be3-5710-43fb-9068-2e94529f01a5";
    public const string PTabelaNome = "PontoVirtual";
    public const string CamposSqlX = " PontoVirtual.* ";
    public const string SensivelCamposSqlX = " PontoVirtual.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "pvtCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "pvt";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}