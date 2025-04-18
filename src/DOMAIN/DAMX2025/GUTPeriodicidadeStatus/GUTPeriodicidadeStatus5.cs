// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBGUTPeriodicidadeStatus
{
    public const string CadastroGuid = "fa7f8699-bca9-44b5-90a9-e79e35ccaff2";
#region AdministrativeMethods_GUTPeriodicidadeStatus
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE pgsCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "GUTPeriodicidadeStatus";
    public const string CamposSqlX = " GUTPeriodicidadeStatus.* ";
    public const string SensivelCamposSqlX = " GUTPeriodicidadeStatus.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "pgsCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "pgs";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}