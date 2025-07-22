// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBAgendaRelatorio
{
    public const string PTabelaNome = "AgendaRelatorio";
    public const string CamposSqlX = " AgendaRelatorio.* ";
    public const string SensivelCamposSqlX = " AgendaRelatorio.* ";
    public static string CamposSqlAlias => CamposSqlX;
    public static string CampoCodigo => "";

    public const string CampoNome = "advNome";
    public const string PTabelaPrefixo = "xxx";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}