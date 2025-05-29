// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBOutrasPartesCliente
{
    public const string CadastroGuid = "1f60b05c-e179-4ea4-8f0f-c69915a7175f";
#region AdministrativeMethods_OutrasPartesCliente
    public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE opcCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "OutrasPartesCliente";
    public const string CamposSqlX = " OutrasPartesCliente.* ";
    public const string SensivelCamposSqlX = " OutrasPartesCliente.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "opcCodigo";
    public const string CampoNome = "opcNome";
    public const string PTabelaPrefixo = "opc";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}