// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBModelosDocumentos
{
    public const string CadastroGuid = "49435fc5-d5ce-4e3d-9de8-8577caf071bf";
    public const string PTabelaNome = "ModelosDocumentos";
    public const string CamposSqlX = " ModelosDocumentos.* ";
    public const string SensivelCamposSqlX = " ModelosDocumentos.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "mdcCodigo";
    public const string CampoNome = "mdcNome";
    public const string PTabelaPrefixo = "mdc";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}