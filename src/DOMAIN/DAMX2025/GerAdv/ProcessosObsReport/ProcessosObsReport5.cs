// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBProcessosObsReport
{
    public const string CadastroGuid = "ede80309-1e4e-4984-8c0d-3760af531cfd";
    public const string PTabelaNome = "ProcessosObsReport";
    public const string CamposSqlX = " ProcessosObsReport.* ";
    public const string SensivelCamposSqlX = " ProcessosObsReport.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "prrCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "prr";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}