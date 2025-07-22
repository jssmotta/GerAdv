// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBAgendaSemana
{
    public const string PTabelaNome = "AgendaSemana";
    public const string CamposSqlX = " AgendaSemana.* ";
    public const string SensivelCamposSqlX = " AgendaSemana.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "xxxCodigo";
    public const string CampoNome = "xxxParaNome";
    public const string PTabelaPrefixo = "xxx";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}