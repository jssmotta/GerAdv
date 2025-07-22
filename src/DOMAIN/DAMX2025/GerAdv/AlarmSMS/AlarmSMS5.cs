// ReSharper disable once CheckNamespace
namespace MenphisSI.SG.GerAdv;
public partial class DBAlarmSMS
{
    public const string CadastroGuid = "e4199787-a8be-4f50-80ad-03a0976af734";
    public const string PTabelaNome = "AlarmSMS";
    public const string CamposSqlX = " AlarmSMS.* ";
    public const string SensivelCamposSqlX = " AlarmSMS.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "alrCodigo";
    public const string CampoNome = "alrDescricao";
    public const string PTabelaPrefixo = "alr";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}