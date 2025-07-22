// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBNENotas
{
    public const string CadastroGuid = "1c1fa8b4-29a9-456d-9dd5-767499264220";
    public const string PTabelaNome = "NENotas";
    public const string CamposSqlX = " NENotas.* ";
    public const string SensivelCamposSqlX = " NENotas.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "nepCodigo";
    public const string CampoNome = "nepNome";
    public const string PTabelaPrefixo = "nep";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}