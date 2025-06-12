// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBAgenda
{
    public const string CadastroGuid = "c5860ced-cc58-4f59-acf7-a3b8e04a2d8c";
    public const string PTabelaNome = "Agenda";
    public const string CamposSqlX = " Agenda.* ";
    public const string SensivelCamposSqlX = " Agenda.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "ageCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "age";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}