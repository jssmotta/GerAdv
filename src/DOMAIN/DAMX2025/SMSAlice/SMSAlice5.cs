// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBSMSAlice
{
    public const string CadastroGuid = "ebe340c6-9dff-4840-af36-38bd15dae935";
    public const string PTabelaNome = "SMSAlice";
    public const string CamposSqlX = " SMSAlice.* ";
    public const string SensivelCamposSqlX = " SMSAlice.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "smaCodigo";
    public const string CampoNome = "smaNome";
    public const string PTabelaPrefixo = "sma";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}