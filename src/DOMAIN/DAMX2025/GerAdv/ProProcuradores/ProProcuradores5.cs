// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBProProcuradores
{
    public const string CadastroGuid = "d7fd51f7-07d3-43eb-b430-885af97148a1";
    public const string PTabelaNome = "ProProcuradores";
    public const string CamposSqlX = " ProProcuradores.* ";
    public const string SensivelCamposSqlX = " ProProcuradores.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "papCodigo";
    public const string CampoNome = "papNome";
    public const string PTabelaPrefixo = "pap";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}