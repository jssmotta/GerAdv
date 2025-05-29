// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBProDespesas
{
    public const string CadastroGuid = "005a8e80-39a5-4f7c-962b-2deea82b0888";
#region AdministrativeMethods_ProDespesas
    public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE desCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "ProDespesas";
    public const string CamposSqlX = " ProDespesas.* ";
    public const string SensivelCamposSqlX = " ProDespesas.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "desCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "des";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}