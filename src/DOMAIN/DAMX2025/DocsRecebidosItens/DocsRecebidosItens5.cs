// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBDocsRecebidosItens
{
    public const string CadastroGuid = "c1d86c15-c9da-4d13-b939-432221e50fb9";
#region AdministrativeMethods_DocsRecebidosItens
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE driCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "DocsRecebidosItens";
    public const string CamposSqlX = " DocsRecebidosItens.* ";
    public const string SensivelCamposSqlX = " DocsRecebidosItens.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "driCodigo";
    public const string CampoNome = "driNome";
    public const string PTabelaPrefixo = "dri";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}