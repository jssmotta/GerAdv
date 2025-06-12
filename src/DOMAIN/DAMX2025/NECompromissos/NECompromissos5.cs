// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBNECompromissos
{
    public const string CadastroGuid = "40ea8f61-728e-41a6-9816-e387e082f196";
    public const string PTabelaNome = "NECompromissos";
    public const string CamposSqlX = " NECompromissos.* ";
    public const string SensivelCamposSqlX = " NECompromissos.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "ncpCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "ncp";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}