// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBProcessosObsReport
{
    public const string CadastroGuid = "ede80309-1e4e-4984-8c0d-3760af531cfd";
#region AdministrativeMethods_ProcessosObsReport
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE prrCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "ProcessosObsReport";
    public const string CamposSqlX = " ProcessosObsReport.* ";
    public const string SensivelCamposSqlX = " ProcessosObsReport.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "prrCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "prr";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}