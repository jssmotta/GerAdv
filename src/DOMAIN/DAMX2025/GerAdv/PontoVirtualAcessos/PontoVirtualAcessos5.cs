// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBPontoVirtualAcessos
{
    public const string CadastroGuid = "6f7ee8e0-f602-4112-b6af-20f86aa95d21";
    public const string PTabelaNome = "PontoVirtualAcessos";
    public const string CamposSqlX = " PontoVirtualAcessos.* ";
    public const string SensivelCamposSqlX = " PontoVirtualAcessos.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "pvaCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "pva";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}