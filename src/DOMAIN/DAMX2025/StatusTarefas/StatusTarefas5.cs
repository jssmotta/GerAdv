// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBStatusTarefas
{
    public const string CadastroGuid = "0a70a6fa-6c88-41c8-a427-6ddb3581daf2";
    public const string PTabelaNome = "StatusTarefas";
    public const string CamposSqlX = " StatusTarefas.* ";
    public const string SensivelCamposSqlX = " StatusTarefas.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "sttCodigo";
    public const string CampoNome = "sttNome";
    public const string PTabelaPrefixo = "stt";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}