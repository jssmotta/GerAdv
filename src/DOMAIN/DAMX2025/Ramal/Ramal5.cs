// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBRamal
{
    public const string CadastroGuid = "017ee386-ca0c-45f7-b40f-95471adf9599";
#region AdministrativeMethods_Ramal
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE ramCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "Ramal";
    public const string CamposSqlX = " Ramal.* ";
    public const string SensivelCamposSqlX = " Ramal.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "ramCodigo";
    public const string CampoNome = "ramNome";
    public const string PTabelaPrefixo = "ram";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}