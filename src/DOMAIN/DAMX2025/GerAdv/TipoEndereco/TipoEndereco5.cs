// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBTipoEndereco
{
    public const string CadastroGuid = "d435caed-ea2a-4c0c-90b1-a1b7f32bc4fe";
    public const string PTabelaNome = "TipoEndereco";
    public const string CamposSqlX = " TipoEndereco.* ";
    public const string SensivelCamposSqlX = " TipoEndereco.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "tipCodigo";
    public const string CampoNome = "tipDescricao";
    public const string PTabelaPrefixo = "tip";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}