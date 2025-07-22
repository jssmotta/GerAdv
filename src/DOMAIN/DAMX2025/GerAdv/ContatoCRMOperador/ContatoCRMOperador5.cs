// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBContatoCRMOperador
{
    public const string CadastroGuid = "d7a1514f-38a6-4078-ae06-e30c62877f08";
    public const string PTabelaNome = "ContatoCRMOperador";
    public const string CamposSqlX = " ContatoCRMOperador.* ";
    public const string SensivelCamposSqlX = " ContatoCRMOperador.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "ccoCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "cco";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}