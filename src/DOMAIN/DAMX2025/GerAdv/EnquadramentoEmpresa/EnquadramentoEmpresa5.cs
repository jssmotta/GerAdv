// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBEnquadramentoEmpresa
{
    public const string CadastroGuid = "b6518734-ac12-4c61-8545-b1c6208cd242";
    public const string PTabelaNome = "EnquadramentoEmpresa";
    public const string CamposSqlX = " EnquadramentoEmpresa.* ";
    public const string SensivelCamposSqlX = " EnquadramentoEmpresa.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "eqeCodigo";
    public const string CampoNome = "eqeNome";
    public const string PTabelaPrefixo = "eqe";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}