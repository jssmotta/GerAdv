// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBAgendaRepetirDias
{
    public const string CadastroGuid = "94b3d914-f051-4d83-a36b-30fa1b8a3c9d";
    public const string PTabelaNome = "AgendaRepetirDias";
    public const string CamposSqlX = " AgendaRepetirDias.* ";
    public const string SensivelCamposSqlX = " AgendaRepetirDias.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "rpdCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "rpd";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}