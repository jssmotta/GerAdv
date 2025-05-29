// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBContaCorrente
{
    public const string CadastroGuid = "0ef68b12-4bc4-4275-b3d3-a5f214c7f685";
#region AdministrativeMethods_ContaCorrente
    public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE ctoCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "ContaCorrente";
    public const string CamposSqlX = " ContaCorrente.* ";
    public const string SensivelCamposSqlX = " ContaCorrente.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "ctoCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "cto";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}