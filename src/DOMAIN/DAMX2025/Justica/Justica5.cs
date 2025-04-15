// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBJustica
{
    public const string CadastroGuid = "30cab9c6-3b84-4ff5-a320-54fcc6ff8685";
#region AdministrativeMethods_Justica
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE jusCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "Justica";
    public const string CamposSqlX = " Justica.* ";
    public const string SensivelCamposSqlX = " Justica.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "jusCodigo";
    public const string CampoNome = "jusNome";
    public const string PTabelaPrefixo = "jus";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}