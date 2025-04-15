// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBTipoProDesposito
{
    public const string CadastroGuid = "632bb835-8abf-44f8-922e-970d741613f3";
#region AdministrativeMethods_TipoProDesposito
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE tpdCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "TipoProDesposito";
    public const string CamposSqlX = " TipoProDesposito.* ";
    public const string SensivelCamposSqlX = " TipoProDesposito.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "tpdCodigo";
    public const string CampoNome = "tpdNome";
    public const string PTabelaPrefixo = "tpd";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}