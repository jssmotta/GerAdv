// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBEventoPrazoAgenda
{
    public const string CadastroGuid = "12d29741-1731-4722-90f8-4b3291394f11";
#region AdministrativeMethods_EventoPrazoAgenda
    public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE epaCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "EventoPrazoAgenda";
    public const string CamposSqlX = " EventoPrazoAgenda.* ";
    public const string SensivelCamposSqlX = " EventoPrazoAgenda.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "epaCodigo";
    public const string CampoNome = "epaNome";
    public const string PTabelaPrefixo = "epa";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}