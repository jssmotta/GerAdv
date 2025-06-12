// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBAgendaStatus
{
    public const string CadastroGuid = "45d77390-357a-43fb-bb47-89da91865f26";
    public const string PTabelaNome = "AgendaStatus";
    public const string CamposSqlX = " AgendaStatus.* ";
    public const string SensivelCamposSqlX = " AgendaStatus.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "astCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "ast";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}