// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBAgendaQuem
{
    public const string CadastroGuid = "262da2df-2dbd-4c8b-84e1-96ac2bf41d5e";
    public const string PTabelaNome = "AgendaQuem";
    public const string CamposSqlX = " AgendaQuem.* ";
    public const string SensivelCamposSqlX = " AgendaQuem.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "agqCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "agq";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}