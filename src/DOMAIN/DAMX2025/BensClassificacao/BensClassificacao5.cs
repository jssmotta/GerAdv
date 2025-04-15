// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBBensClassificacao
{
    public const string CadastroGuid = "60ab272e-7169-4e0e-a1e4-4f669f1622d9";
#region AdministrativeMethods_BensClassificacao
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE bcsCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "BensClassificacao";
    public const string CamposSqlX = " BensClassificacao.* ";
    public const string SensivelCamposSqlX = " BensClassificacao.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "bcsCodigo";
    public const string CampoNome = "bcsNome";
    public const string PTabelaPrefixo = "bcs";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}