// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBProPartes
{
    public const string CadastroGuid = "8c05cc6d-a6d0-42c7-9642-2ba9a17bc570";
#region AdministrativeMethods_ProPartes
    public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE oppCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "ProPartes";
    public const string CamposSqlX = " ProPartes.* ";
    public const string SensivelCamposSqlX = " ProPartes.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "oppCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "opp";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}