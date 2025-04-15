// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBTipoContatoCRM
{
    public const string CadastroGuid = "6e07a77b-04b7-4d94-852a-b3b863d56997";
#region AdministrativeMethods_TipoContatoCRM
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE tccCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "TipoContatoCRM";
    public const string CamposSqlX = " TipoContatoCRM.* ";
    public const string SensivelCamposSqlX = " TipoContatoCRM.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "tccCodigo";
    public const string CampoNome = "tccNome";
    public const string PTabelaPrefixo = "tcc";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}