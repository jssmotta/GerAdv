// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBStatusAndamento
{
    public const string CadastroGuid = "641ef4f1-b717-4b73-910b-e770c6b919b9";
    public const string PTabelaNome = "StatusAndamento";
    public const string CamposSqlX = " StatusAndamento.* ";
    public const string SensivelCamposSqlX = " StatusAndamento.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "sanCodigo";
    public const string CampoNome = "sanNome";
    public const string PTabelaPrefixo = "san";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}