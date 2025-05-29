// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBContatoCRM
{
    public const string CadastroGuid = "a8c0b22a-4cb9-462b-9c77-9e93d8bb0452";
#region AdministrativeMethods_ContatoCRM
    public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE ctcCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "ContatoCRM";
    public const string CamposSqlX = " ContatoCRM.* ";
    public const string SensivelCamposSqlX = " ContatoCRM.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "ctcCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "ctc";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}