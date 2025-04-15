// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBOponentesRepLegal
{
    public const string CadastroGuid = "12fcbede-90db-412a-bc17-20065b840d67";
#region AdministrativeMethods_OponentesRepLegal
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE oprCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "OponentesRepLegal";
    public const string CamposSqlX = " OponentesRepLegal.* ";
    public const string SensivelCamposSqlX = " OponentesRepLegal.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "oprCodigo";
    public const string CampoNome = "oprNome";
    public const string PTabelaPrefixo = "opr";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}