// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBPenhoraStatus
{
    public const string CadastroGuid = "5aa4d2e2-7a47-4263-8284-863c294a346c";
#region AdministrativeMethods_PenhoraStatus
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE phsCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "PenhoraStatus";
    public const string CamposSqlX = " PenhoraStatus.* ";
    public const string SensivelCamposSqlX = " PenhoraStatus.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "phsCodigo";
    public const string CampoNome = "phsNome";
    public const string PTabelaPrefixo = "phs";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}