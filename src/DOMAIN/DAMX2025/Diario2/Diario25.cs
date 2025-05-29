// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBDiario2
{
    public const string CadastroGuid = "2b5c2ec7-b8e7-409f-a76e-45c8268e3dab";
#region AdministrativeMethods_Diario2
    public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE diaCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "Diario2";
    public const string CamposSqlX = " Diario2.* ";
    public const string SensivelCamposSqlX = " Diario2.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "diaCodigo";
    public const string CampoNome = "diaNome";
    public const string PTabelaPrefixo = "dia";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}