// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBProSucumbencia
{
    public const string CadastroGuid = "9c439c1c-a26d-4566-954c-7342f5eb4fb6";
    public const string PTabelaNome = "ProSucumbencia";
    public const string CamposSqlX = " ProSucumbencia.* ";
    public const string SensivelCamposSqlX = " ProSucumbencia.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "scbCodigo";
    public const string CampoNome = "scbNome";
    public const string PTabelaPrefixo = "scb";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}