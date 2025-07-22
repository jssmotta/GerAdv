// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBProCDA
{
    public const string CadastroGuid = "a15e2368-b4ce-4fb9-8009-fd4f0b5ccbb6";
    public const string PTabelaNome = "ProCDA";
    public const string CamposSqlX = " ProCDA.* ";
    public const string SensivelCamposSqlX = " ProCDA.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "pcdCodigo";
    public const string CampoNome = "pcdNome";
    public const string PTabelaPrefixo = "pcd";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}