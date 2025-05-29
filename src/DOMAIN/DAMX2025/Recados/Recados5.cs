// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBRecados
{
    public const string CadastroGuid = "32275cd3-f212-4fa5-a55d-6560d381690c";
#region AdministrativeMethods_Recados
    public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE recCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "Recados";
    public const string CamposSqlX = " Recados.* ";
    public const string SensivelCamposSqlX = " Recados.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "recCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "rec";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}