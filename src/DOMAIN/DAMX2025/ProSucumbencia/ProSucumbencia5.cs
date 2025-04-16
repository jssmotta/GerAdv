// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBProSucumbencia
{
    public const string CadastroGuid = "9c439c1c-a26d-4566-954c-7342f5eb4fb6";
#region AdministrativeMethods_ProSucumbencia
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE scbCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "ProSucumbencia";
    public const string CamposSqlX = " ProSucumbencia.* ";
    public const string SensivelCamposSqlX = " ProSucumbencia.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "scbCodigo";
    public const string CampoNome = "scbNome";
    public const string PTabelaPrefixo = "scb";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}