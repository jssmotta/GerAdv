// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBAnexamentoRegistros
{
    public const string CadastroGuid = "84223586-4570-4f75-b958-bd1cc3ae566b";
    public const string PTabelaNome = "AnexamentoRegistros";
    public const string CamposSqlX = " AnexamentoRegistros.* ";
    public const string SensivelCamposSqlX = " AnexamentoRegistros.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "axrCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "axr";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}