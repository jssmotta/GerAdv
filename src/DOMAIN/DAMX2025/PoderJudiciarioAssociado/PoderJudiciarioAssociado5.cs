// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBPoderJudiciarioAssociado
{
    public const string CadastroGuid = "11ebf621-ae74-46a5-9ba0-3cae36afde5e";
#region AdministrativeMethods_PoderJudiciarioAssociado
    public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE pjaCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "PoderJudiciarioAssociado";
    public const string CamposSqlX = " PoderJudiciarioAssociado.* ";
    public const string SensivelCamposSqlX = " PoderJudiciarioAssociado.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "pjaCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "pja";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}