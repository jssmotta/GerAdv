// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBPontoVirtualAcessos
{
    public const string CadastroGuid = "6f7ee8e0-f602-4112-b6af-20f86aa95d21";
#region AdministrativeMethods_PontoVirtualAcessos
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE pvaCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "PontoVirtualAcessos";
    public const string CamposSqlX = " PontoVirtualAcessos.* ";
    public const string SensivelCamposSqlX = " PontoVirtualAcessos.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "pvaCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "pva";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}