// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBProDepositos
{
    public const string CadastroGuid = "e06f84a1-0ffd-411e-9356-61498fdfc6a1";
    public const string PTabelaNome = "ProDepositos";
    public const string CamposSqlX = " ProDepositos.* ";
    public const string SensivelCamposSqlX = " ProDepositos.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "pdsCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "pds";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}