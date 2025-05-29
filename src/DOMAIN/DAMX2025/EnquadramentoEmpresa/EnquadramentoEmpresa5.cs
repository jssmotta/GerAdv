// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBEnquadramentoEmpresa
{
    public const string CadastroGuid = "b6518734-ac12-4c61-8545-b1c6208cd242";
#region AdministrativeMethods_EnquadramentoEmpresa
    public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE eqeCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "EnquadramentoEmpresa";
    public const string CamposSqlX = " EnquadramentoEmpresa.* ";
    public const string SensivelCamposSqlX = " EnquadramentoEmpresa.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "eqeCodigo";
    public const string CampoNome = "eqeNome";
    public const string PTabelaPrefixo = "eqe";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}