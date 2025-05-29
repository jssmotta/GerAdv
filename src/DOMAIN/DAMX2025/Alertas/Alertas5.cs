// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBAlertas
{
    public const string CadastroGuid = "31c3b771-a970-4e08-a310-d3b8b799be25";
#region AdministrativeMethods_Alertas
    public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE altCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "Alertas";
    public const string CamposSqlX = " Alertas.* ";
    public const string SensivelCamposSqlX = " Alertas.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "altCodigo";
    public const string CampoNome = "altNome";
    public const string PTabelaPrefixo = "alt";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}