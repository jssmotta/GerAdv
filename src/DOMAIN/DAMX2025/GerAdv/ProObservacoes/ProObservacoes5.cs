// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBProObservacoes
{
    public const string CadastroGuid = "5b6010e6-1838-477e-af33-65cdeaf106fc";
    public const string PTabelaNome = "ProObservacoes";
    public const string CamposSqlX = " ProObservacoes.* ";
    public const string SensivelCamposSqlX = " ProObservacoes.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "pobCodigo";
    public const string CampoNome = "pobNome";
    public const string PTabelaPrefixo = "pob";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}