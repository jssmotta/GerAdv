// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBTribunal
{
    public const string CadastroGuid = "77af9337-0d36-4e64-a96b-cc6a70933537";
#region AdministrativeMethods_Tribunal
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE triCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "Tribunal";
    public const string CamposSqlX = " Tribunal.* ";
    public const string SensivelCamposSqlX = " Tribunal.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "triCodigo";
    public const string CampoNome = "triNome";
    public const string PTabelaPrefixo = "tri";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}