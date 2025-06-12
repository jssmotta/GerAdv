// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBReuniaoPessoas
{
    public const string CadastroGuid = "b6ffbe84-2fac-4bf1-bb39-938561dc52c3";
    public const string PTabelaNome = "ReuniaoPessoas";
    public const string CamposSqlX = " ReuniaoPessoas.* ";
    public const string SensivelCamposSqlX = " ReuniaoPessoas.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "rnpCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "rnp";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}