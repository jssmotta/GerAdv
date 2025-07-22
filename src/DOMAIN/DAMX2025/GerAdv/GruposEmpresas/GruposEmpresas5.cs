// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBGruposEmpresas
{
    public const string CadastroGuid = "b43fa331-4333-421f-bcd5-0ce0ef458213";
    public const string PTabelaNome = "GruposEmpresas";
    public const string CamposSqlX = " GruposEmpresas.* ";
    public const string SensivelCamposSqlX = " GruposEmpresas.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "grpCodigo";
    public const string CampoNome = "grpDescricao";
    public const string PTabelaPrefixo = "grp";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}