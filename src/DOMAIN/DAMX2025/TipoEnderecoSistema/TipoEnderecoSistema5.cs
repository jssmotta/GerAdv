// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBTipoEnderecoSistema
{
    public const string CadastroGuid = "1db43792-de67-49ad-b041-ca8c06c2fa38";
#region AdministrativeMethods_TipoEnderecoSistema
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE tesCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "TipoEnderecoSistema";
    public const string CamposSqlX = " TipoEnderecoSistema.* ";
    public const string SensivelCamposSqlX = " TipoEnderecoSistema.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "tesCodigo";
    public const string CampoNome = "tesNome";
    public const string PTabelaPrefixo = "tes";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}