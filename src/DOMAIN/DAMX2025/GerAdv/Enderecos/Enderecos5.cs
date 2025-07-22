// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBEnderecos
{
    public const string CadastroGuid = "9c60b5bb-0070-4bab-8747-41c3d7447889";
    public const string PTabelaNome = "Enderecos";
    public const string CamposSqlX = " Enderecos.* ";
    public const string SensivelCamposSqlX = " Enderecos.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "endCodigo";
    public const string CampoNome = "endDescricao";
    public const string PTabelaPrefixo = "end";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}