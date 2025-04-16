// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBParceriaProc
{
    public const string CadastroGuid = "7945e61a-321c-4196-bbd1-afeb7fccdb47";
#region AdministrativeMethods_ParceriaProc
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE parCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "ParceriaProc";
    public const string CamposSqlX = " ParceriaProc.* ";
    public const string SensivelCamposSqlX = " ParceriaProc.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "parCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "par";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}