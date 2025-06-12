// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBCidade
{
    public const string CadastroGuid = "91c4691e-a73c-4ed9-9b6f-4db05b38c736";
    public const string PTabelaNome = "Cidade";
    public const string CamposSqlX = " Cidade.* ";
    public const string SensivelCamposSqlX = " Cidade.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "cidCodigo";
    public const string CampoNome = "cidNome";
    public const string PTabelaPrefixo = "cid";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}