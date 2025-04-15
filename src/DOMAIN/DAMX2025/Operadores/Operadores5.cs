// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBOperadores
{
    public const string CadastroGuid = "e8b7914e-c750-4163-acfe-091e4625715c";
#region AdministrativeMethods_Operadores
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE operCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "Operadores";
    public const string CamposSqlX = " Operadores.* ";
    public const string SensivelCamposSqlX = " Operadores.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "operCodigo";
    public const string CampoNome = "operNome";
    public const string PTabelaPrefixo = "oper";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}