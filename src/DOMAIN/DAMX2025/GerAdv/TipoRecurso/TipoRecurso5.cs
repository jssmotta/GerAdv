// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBTipoRecurso
{
    public const string CadastroGuid = "21dc6657-9979-42b9-b6ec-aada56fedf40";
    public const string PTabelaNome = "TipoRecurso";
    public const string CamposSqlX = " TipoRecurso.* ";
    public const string SensivelCamposSqlX = " TipoRecurso.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "trcCodigo";
    public const string CampoNome = "trcDescricao";
    public const string PTabelaPrefixo = "trc";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}