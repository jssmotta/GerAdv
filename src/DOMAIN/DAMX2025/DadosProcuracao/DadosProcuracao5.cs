// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBDadosProcuracao
{
    public const string CadastroGuid = "154efa1e-ef70-409a-97e9-9dd297478509";
    public const string PTabelaNome = "DadosProcuracao";
    public const string CamposSqlX = " DadosProcuracao.* ";
    public const string SensivelCamposSqlX = " DadosProcuracao.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "prcCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "prc";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}