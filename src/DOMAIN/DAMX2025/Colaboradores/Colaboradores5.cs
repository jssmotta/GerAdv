// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBColaboradores
{
    public const string CadastroGuid = "9842827f-6df0-40e6-b3c2-ceca2fbb661f";
#region AdministrativeMethods_Colaboradores
    public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE colCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "Colaboradores";
    public const string CamposSqlX = " Colaboradores.* ";
    public const string SensivelCamposSqlX = " Colaboradores.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "colCodigo";
    public const string CampoNome = "colNome";
    public const string PTabelaPrefixo = "col";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}