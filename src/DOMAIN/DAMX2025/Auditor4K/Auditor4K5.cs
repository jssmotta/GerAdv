// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBAuditor4K
{
    public const string CadastroGuid = "6a4b3bfb-34f2-49de-b8b5-785c1dc717dc";
#region AdministrativeMethods_Auditor4K
    public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE audCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "Auditor4K";
    public const string CamposSqlX = " Auditor4K.* ";
    public const string SensivelCamposSqlX = " Auditor4K.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "audCodigo";
    public const string CampoNome = "audNome";
    public const string PTabelaPrefixo = "aud";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}