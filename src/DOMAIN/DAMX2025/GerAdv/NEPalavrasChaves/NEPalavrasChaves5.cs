// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBNEPalavrasChaves
{
    public const string CadastroGuid = "b293c404-a761-489e-bb53-f569eec6d9c6";
    public const string PTabelaNome = "NEPalavrasChaves";
    public const string CamposSqlX = " NEPalavrasChaves.* ";
    public const string SensivelCamposSqlX = " NEPalavrasChaves.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "npcCodigo";
    public const string CampoNome = "npcNome";
    public const string PTabelaPrefixo = "npc";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}