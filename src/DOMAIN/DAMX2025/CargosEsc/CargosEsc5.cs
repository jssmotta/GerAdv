// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBCargosEsc
{
    public const string CadastroGuid = "6b6a57d1-9b27-4bc7-92ea-3f17818f3a81";
#region AdministrativeMethods_CargosEsc
    public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE cgeCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "CargosEsc";
    public const string CamposSqlX = " CargosEsc.* ";
    public const string SensivelCamposSqlX = " CargosEsc.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "cgeCodigo";
    public const string CampoNome = "cgeNome";
    public const string PTabelaPrefixo = "cge";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}