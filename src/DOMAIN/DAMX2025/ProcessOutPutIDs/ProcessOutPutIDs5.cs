// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBProcessOutPutIDs
{
    public const string CadastroGuid = "f64a2848-2862-473d-b89c-ffefe5a3b0d1";
#region AdministrativeMethods_ProcessOutPutIDs
    public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE poiCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "ProcessOutPutIDs";
    public const string CamposSqlX = " ProcessOutPutIDs.* ";
    public const string SensivelCamposSqlX = " ProcessOutPutIDs.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "poiCodigo";
    public const string CampoNome = "poiNome";
    public const string PTabelaPrefixo = "poi";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}