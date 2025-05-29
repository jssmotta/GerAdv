// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBProValores
{
    public const string CadastroGuid = "a42dcf2a-6b26-40fb-8ffc-0e87b1548709";
#region AdministrativeMethods_ProValores
    public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE prvCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "ProValores";
    public const string CamposSqlX = " ProValores.* ";
    public const string SensivelCamposSqlX = " ProValores.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "prvCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "prv";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}