// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBOperadorGrupo
{
    public const string CadastroGuid = "433cb568-9fee-4bd6-806d-c28ff14d053c";
    public const string PTabelaNome = "OperadorGrupo";
    public const string CamposSqlX = " OperadorGrupo.* ";
    public const string SensivelCamposSqlX = " OperadorGrupo.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "ogrCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "ogr";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}