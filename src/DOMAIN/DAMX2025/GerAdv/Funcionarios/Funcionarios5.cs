// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBFuncionarios
{
    public const string CadastroGuid = "c9beefae-66db-4909-ac8f-c7b5480d7c06";
    public const string PTabelaNome = "Funcionarios";
    public const string CamposSqlX = " Funcionarios.* ";
    public const string SensivelCamposSqlX = " Funcionarios.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "funCodigo";
    public const string CampoNome = "funNome";
    public const string PTabelaPrefixo = "fun";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}