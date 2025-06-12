// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBCargos
{
    public const string CadastroGuid = "e6bd2a5c-c6be-4e31-be05-6ab687ba544a";
    public const string PTabelaNome = "Cargos";
    public const string CamposSqlX = " Cargos.* ";
    public const string SensivelCamposSqlX = " Cargos.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "carCodigo";
    public const string CampoNome = "carNome";
    public const string PTabelaPrefixo = "car";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}