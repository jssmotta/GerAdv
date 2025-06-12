// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBAndamentosMD
{
    public const string CadastroGuid = "6fb3f20f-9abc-43a4-ba8b-08cdb42b9260";
    public const string PTabelaNome = "AndamentosMD";
    public const string CamposSqlX = " AndamentosMD.* ";
    public const string SensivelCamposSqlX = " AndamentosMD.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "amdCodigo";
    public const string CampoNome = "amdNome";
    public const string PTabelaPrefixo = "amd";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}