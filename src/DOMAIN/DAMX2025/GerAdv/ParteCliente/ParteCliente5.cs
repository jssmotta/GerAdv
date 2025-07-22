// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBParteCliente
{
    public const string CadastroGuid = "424d6979-0be5-4c54-bcee-95bd070c8e45";
    public const string PTabelaNome = "ParteCliente";
    public const string CamposSqlX = " ParteCliente.* ";
    public const string SensivelCamposSqlX = " ParteCliente.* ";
    public static string CamposSqlAlias => CamposSqlX;
    public static string CampoCodigo => "";

    public const string CampoNome = "";
    public const string PTabelaPrefixo = "cli";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}