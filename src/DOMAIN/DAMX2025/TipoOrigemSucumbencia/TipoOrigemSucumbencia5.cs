// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBTipoOrigemSucumbencia
{
    public const string CadastroGuid = "9ddc38c3-ec1e-49a0-ac63-e74f842d538f";
#region AdministrativeMethods_TipoOrigemSucumbencia
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE tosCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "TipoOrigemSucumbencia";
    public const string CamposSqlX = " TipoOrigemSucumbencia.* ";
    public const string SensivelCamposSqlX = " TipoOrigemSucumbencia.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "tosCodigo";
    public const string CampoNome = "tosNome";
    public const string PTabelaPrefixo = "tos";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}