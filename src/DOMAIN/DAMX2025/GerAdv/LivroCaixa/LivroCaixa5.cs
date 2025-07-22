// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBLivroCaixa
{
    public const string CadastroGuid = "ae45879f-8100-41e3-9631-16f814096346";
    public const string PTabelaNome = "LivroCaixa";
    public const string CamposSqlX = " LivroCaixa.* ";
    public const string SensivelCamposSqlX = " LivroCaixa.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "livCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "liv";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}