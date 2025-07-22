// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBFase
{
    public const string CadastroGuid = "08919325-19aa-467a-965a-f723bd4e9c41";
    public const string PTabelaNome = "Fase";
    public const string CamposSqlX = " Fase.* ";
    public const string SensivelCamposSqlX = " Fase.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "fasCodigo";
    public const string CampoNome = "fasDescricao";
    public const string PTabelaPrefixo = "fas";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}