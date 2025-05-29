// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBOperadorGrupos
{
    public const string CadastroGuid = "8eb70759-18f7-4dc9-be14-90fbfdc99b8d";
#region AdministrativeMethods_OperadorGrupos
    public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE opgCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "OperadorGrupos";
    public const string CamposSqlX = " OperadorGrupos.* ";
    public const string SensivelCamposSqlX = " OperadorGrupos.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "opgCodigo";
    public const string CampoNome = "opgNome";
    public const string PTabelaPrefixo = "opg";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}