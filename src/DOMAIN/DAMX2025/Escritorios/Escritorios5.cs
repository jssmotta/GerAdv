// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBEscritorios
{
    public const string CadastroGuid = "5f8f8f19-72d5-403a-901f-b613580d2e4f";
#region AdministrativeMethods_Escritorios
    public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE escCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "Escritorios";
    public const string CamposSqlX = " Escritorios.* ";
    public const string SensivelCamposSqlX = " Escritorios.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "escCodigo";
    public const string CampoNome = "escNome";
    public const string PTabelaPrefixo = "esc";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}