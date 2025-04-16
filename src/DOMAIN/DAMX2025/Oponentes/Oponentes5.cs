// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBOponentes
{
    public const string CadastroGuid = "dc714717-a0ea-404a-8e83-a9df72c3a432";
#region AdministrativeMethods_Oponentes
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE opoCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "Oponentes";
    public const string CamposSqlX = " Oponentes.* ";
    public const string SensivelCamposSqlX = " Oponentes.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "opoCodigo";
    public const string CampoNome = "opoNome";
    public const string PTabelaPrefixo = "opo";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}