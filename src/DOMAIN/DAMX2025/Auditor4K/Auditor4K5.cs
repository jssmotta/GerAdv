// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBAuditor4K
{
    public const string CadastroGuid = "6a4b3bfb-34f2-49de-b8b5-785c1dc717dc";
    public const string PTabelaNome = "Auditor4K";
    public const string CamposSqlX = " Auditor4K.* ";
    public const string SensivelCamposSqlX = " Auditor4K.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "audCodigo";
    public const string CampoNome = "audNome";
    public const string PTabelaPrefixo = "aud";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}