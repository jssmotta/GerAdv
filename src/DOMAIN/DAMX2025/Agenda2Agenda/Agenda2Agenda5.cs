// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBAgenda2Agenda
{
    public const string CadastroGuid = "8a2b0d6d-c728-4502-8767-0d40a1a797ba";
    public const string PTabelaNome = "Agenda2Agenda";
    public const string CamposSqlX = " Agenda2Agenda.* ";
    public const string SensivelCamposSqlX = " Agenda2Agenda.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "ag2Codigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "ag2";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}