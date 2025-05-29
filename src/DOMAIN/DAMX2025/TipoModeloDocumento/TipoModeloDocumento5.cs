// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBTipoModeloDocumento
{
    public const string CadastroGuid = "65927bd0-4d2e-4159-ba1c-136c1050b5cb";
#region AdministrativeMethods_TipoModeloDocumento
    public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE tpdCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "TipoModeloDocumento";
    public const string CamposSqlX = " TipoModeloDocumento.* ";
    public const string SensivelCamposSqlX = " TipoModeloDocumento.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "tpdCodigo";
    public const string CampoNome = "tpdNome";
    public const string PTabelaPrefixo = "tpd";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}