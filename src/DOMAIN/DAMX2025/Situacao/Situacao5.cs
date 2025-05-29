// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBSituacao
{
    public const string CadastroGuid = "23bff2f8-d595-4a5d-b943-4eff761fe4d4";
#region AdministrativeMethods_Situacao
    public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE sitCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "Situacao";
    public const string CamposSqlX = " Situacao.* ";
    public const string SensivelCamposSqlX = " Situacao.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "sitCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "sit";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}