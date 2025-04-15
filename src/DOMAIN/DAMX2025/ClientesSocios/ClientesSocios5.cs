// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBClientesSocios
{
    public const string CadastroGuid = "cac65867-1e7d-4c7c-ace1-ddd651778218";
#region AdministrativeMethods_ClientesSocios
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE cscCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "ClientesSocios";
    public const string CamposSqlX = " ClientesSocios.* ";
    public const string SensivelCamposSqlX = " ClientesSocios.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "cscCodigo";
    public const string CampoNome = "cscNome";
    public const string PTabelaPrefixo = "csc";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}