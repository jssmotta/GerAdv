// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBAgendaRepetir
{
    public const string CadastroGuid = "4c61b44e-a1f8-45a7-8323-88a117cea213";
    public const string PTabelaNome = "AgendaRepetir";
    public const string CamposSqlX = " AgendaRepetir.* ";
    public const string SensivelCamposSqlX = " AgendaRepetir.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "rptCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "rpt";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}