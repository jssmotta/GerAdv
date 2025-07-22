// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBOperadorGrupos
{
    public const string CadastroGuid = "8eb70759-18f7-4dc9-be14-90fbfdc99b8d";
    public const string PTabelaNome = "OperadorGrupos";
    public const string CamposSqlX = " OperadorGrupos.* ";
    public const string SensivelCamposSqlX = " OperadorGrupos.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "opgCodigo";
    public const string CampoNome = "opgNome";
    public const string PTabelaPrefixo = "opg";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}