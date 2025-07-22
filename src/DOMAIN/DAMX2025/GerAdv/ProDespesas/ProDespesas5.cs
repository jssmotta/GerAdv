// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBProDespesas
{
    public const string CadastroGuid = "005a8e80-39a5-4f7c-962b-2deea82b0888";
    public const string PTabelaNome = "ProDespesas";
    public const string CamposSqlX = " ProDespesas.* ";
    public const string SensivelCamposSqlX = " ProDespesas.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "desCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "des";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}