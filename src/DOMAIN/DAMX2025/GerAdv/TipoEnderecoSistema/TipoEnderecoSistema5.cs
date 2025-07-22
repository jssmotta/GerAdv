// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBTipoEnderecoSistema
{
    public const string CadastroGuid = "1db43792-de67-49ad-b041-ca8c06c2fa38";
    public const string PTabelaNome = "TipoEnderecoSistema";
    public const string CamposSqlX = " TipoEnderecoSistema.* ";
    public const string SensivelCamposSqlX = " TipoEnderecoSistema.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "tesCodigo";
    public const string CampoNome = "tesNome";
    public const string PTabelaPrefixo = "tes";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}