// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBLivroCaixaClientes
{
    public const string CadastroGuid = "0139201e-95aa-4416-af52-fad584a537a4";
#region AdministrativeMethods_LivroCaixaClientes
    public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE lccCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "LivroCaixaClientes";
    public const string CamposSqlX = " LivroCaixaClientes.* ";
    public const string SensivelCamposSqlX = " LivroCaixaClientes.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "lccCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "lcc";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}