// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBTerceiros
{
    public const string CadastroGuid = "052bc624-ca29-4cf6-8c59-120891b34dd1";
#region AdministrativeMethods_Terceiros
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE terCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "Terceiros";
    public const string CamposSqlX = " Terceiros.* ";
    public const string SensivelCamposSqlX = " Terceiros.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "terCodigo";
    public const string CampoNome = "terNome";
    public const string PTabelaPrefixo = "ter";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}