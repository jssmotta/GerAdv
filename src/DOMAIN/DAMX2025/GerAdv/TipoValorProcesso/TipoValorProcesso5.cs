// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBTipoValorProcesso
{
    public const string CadastroGuid = "f3fca6bf-e589-477e-9b6f-2de37b128bdc";
    public const string PTabelaNome = "TipoValorProcesso";
    public const string CamposSqlX = " TipoValorProcesso.* ";
    public const string SensivelCamposSqlX = " TipoValorProcesso.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "ptvCodigo";
    public const string CampoNome = "ptvDescricao";
    public const string PTabelaPrefixo = "ptv";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}