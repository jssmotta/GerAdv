// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBTipoEndereco
{
    public const string CadastroGuid = "d435caed-ea2a-4c0c-90b1-a1b7f32bc4fe";
#region AdministrativeMethods_TipoEndereco
    public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE tipCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "TipoEndereco";
    public const string CamposSqlX = " TipoEndereco.* ";
    public const string SensivelCamposSqlX = " TipoEndereco.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "tipCodigo";
    public const string CampoNome = "tipDescricao";
    public const string PTabelaPrefixo = "tip";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}