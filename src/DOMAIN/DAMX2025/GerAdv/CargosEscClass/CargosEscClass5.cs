// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBCargosEscClass
{
    public const string CadastroGuid = "1b153ad2-ebe6-4cb4-a445-8f0fd35f16aa";
    public const string PTabelaNome = "CargosEscClass";
    public const string CamposSqlX = " CargosEscClass.* ";
    public const string SensivelCamposSqlX = " CargosEscClass.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "cecCodigo";
    public const string CampoNome = "cecNome";
    public const string PTabelaPrefixo = "cec";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}