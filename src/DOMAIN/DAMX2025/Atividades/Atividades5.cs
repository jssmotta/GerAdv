// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBAtividades
{
    public const string CadastroGuid = "1d8b5bbf-83a7-4781-b602-7a8568adfb2b";
    public const string PTabelaNome = "Atividades";
    public const string CamposSqlX = " Atividades.* ";
    public const string SensivelCamposSqlX = " Atividades.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "atvCodigo";
    public const string CampoNome = "atvDescricao";
    public const string PTabelaPrefixo = "atv";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}