// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBHistorico
{
    public const string CadastroGuid = "823c26b9-0792-4477-9b5f-632a61adb7bd";
#region AdministrativeMethods_Historico
    public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE hisCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "Historico";
    public const string CamposSqlX = " Historico.* ";
    public const string SensivelCamposSqlX = " Historico.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "hisCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "his";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}