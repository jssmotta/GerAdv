// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBColaboradores
{
    public const string CadastroGuid = "9842827f-6df0-40e6-b3c2-ceca2fbb661f";
    public const string PTabelaNome = "Colaboradores";
    public const string CamposSqlX = " Colaboradores.* ";
    public const string SensivelCamposSqlX = " Colaboradores.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "colCodigo";
    public const string CampoNome = "colNome";
    public const string PTabelaPrefixo = "col";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}