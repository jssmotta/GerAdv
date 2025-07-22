// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBParteOponente
{
    public const string CadastroGuid = "96544eac-46ab-4dc0-9b3c-1e9df808cabc";
    public const string PTabelaNome = "ParteOponente";
    public const string CamposSqlX = " ParteOponente.* ";
    public const string SensivelCamposSqlX = " ParteOponente.* ";
    public static string CamposSqlAlias => CamposSqlX;
    public static string CampoCodigo => "";

    public const string CampoNome = "";
    public const string PTabelaPrefixo = "opo";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}