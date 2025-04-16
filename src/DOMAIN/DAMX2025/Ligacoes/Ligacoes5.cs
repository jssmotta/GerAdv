// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBLigacoes
{
    public const string CadastroGuid = "64e08ef7-4fa7-4db2-95fd-3484cc16d972";
#region AdministrativeMethods_Ligacoes
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE ligCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "Ligacoes";
    public const string CamposSqlX = " Ligacoes.* ";
    public const string SensivelCamposSqlX = " Ligacoes.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "ligCodigo";
    public const string CampoNome = "ligNome";
    public const string PTabelaPrefixo = "lig";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}