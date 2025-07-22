// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBAgendaRecords
{
    public const string CadastroGuid = "47efdaf0-6a7c-4f63-ab30-fb16b4a65193";
    public const string PTabelaNome = "AgendaRecords";
    public const string CamposSqlX = " AgendaRecords.* ";
    public const string SensivelCamposSqlX = " AgendaRecords.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "ragCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "rag";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}