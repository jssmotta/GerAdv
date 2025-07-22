// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBTiposAcao
{
    public const string CadastroGuid = "2fed7fd7-af59-4e15-98ba-374bbd615dc5";
    public const string PTabelaNome = "TiposAcao";
    public const string CamposSqlX = " TiposAcao.* ";
    public const string SensivelCamposSqlX = " TiposAcao.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "tacCodigo";
    public const string CampoNome = "tacNome";
    public const string PTabelaPrefixo = "tac";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}