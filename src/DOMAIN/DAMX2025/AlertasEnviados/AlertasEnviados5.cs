// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBAlertasEnviados
{
    public const string CadastroGuid = "1379670d-e564-4c51-a066-a7570c39c7ca";
#region AdministrativeMethods_AlertasEnviados
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE aloCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "AlertasEnviados";
    public const string CamposSqlX = " AlertasEnviados.* ";
    public const string SensivelCamposSqlX = " AlertasEnviados.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "aloCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "alo";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}