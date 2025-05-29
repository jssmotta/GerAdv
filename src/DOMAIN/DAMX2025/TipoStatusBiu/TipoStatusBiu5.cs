// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBTipoStatusBiu
{
    public const string CadastroGuid = "0dfb8721-003a-4116-b027-e069c6f019f0";
#region AdministrativeMethods_TipoStatusBiu
    public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE tsbCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "TipoStatusBiu";
    public const string CamposSqlX = " TipoStatusBiu.* ";
    public const string SensivelCamposSqlX = " TipoStatusBiu.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "tsbCodigo";
    public const string CampoNome = "tsbNome";
    public const string PTabelaPrefixo = "tsb";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}