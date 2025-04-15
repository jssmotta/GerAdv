// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBAnexamentoRegistros
{
    public const string CadastroGuid = "84223586-4570-4f75-b958-bd1cc3ae566b";
#region AdministrativeMethods_AnexamentoRegistros
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE axrCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "AnexamentoRegistros";
    public const string CamposSqlX = " AnexamentoRegistros.* ";
    public const string SensivelCamposSqlX = " AnexamentoRegistros.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "axrCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "axr";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}