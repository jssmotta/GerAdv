// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBProTipoBaixa
{
    public const string CadastroGuid = "f726841a-4bff-4d8a-8947-789ae1b16625";
#region AdministrativeMethods_ProTipoBaixa
    public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE ptxCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "ProTipoBaixa";
    public const string CamposSqlX = " ProTipoBaixa.* ";
    public const string SensivelCamposSqlX = " ProTipoBaixa.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "ptxCodigo";
    public const string CampoNome = "ptxNome";
    public const string PTabelaPrefixo = "ptx";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}