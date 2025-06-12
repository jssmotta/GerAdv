// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBOperador
{
    public const string CadastroGuid = "410cd94a-fdd6-4598-bc50-e69d770fdb8d";
    public const string PTabelaNome = "Operador";
    public const string CamposSqlX = " Operador.* ";
    public const string SensivelCamposSqlX = " Operador.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "operCodigo";
    public const string CampoNome = "operNome";
    public const string PTabelaPrefixo = "oper";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}