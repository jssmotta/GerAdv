// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBGUTMatriz
{
    public const string CadastroGuid = "1e66bf25-adbb-43f0-853a-e2399f3ec945";
    public const string PTabelaNome = "GUTMatriz";
    public const string CamposSqlX = " GUTMatriz.* ";
    public const string SensivelCamposSqlX = " GUTMatriz.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "gutCodigo";
    public const string CampoNome = "gutDescricao";
    public const string PTabelaPrefixo = "gut";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}