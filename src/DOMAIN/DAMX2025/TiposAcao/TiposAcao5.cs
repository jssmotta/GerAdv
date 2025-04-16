// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBTiposAcao
{
    public const string CadastroGuid = "2fed7fd7-af59-4e15-98ba-374bbd615dc5";
#region AdministrativeMethods_TiposAcao
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE tacCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "TiposAcao";
    public const string CamposSqlX = " TiposAcao.* ";
    public const string SensivelCamposSqlX = " TiposAcao.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "tacCodigo";
    public const string CampoNome = "tacNome";
    public const string PTabelaPrefixo = "tac";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}