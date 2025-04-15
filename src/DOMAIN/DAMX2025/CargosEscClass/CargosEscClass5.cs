// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBCargosEscClass
{
    public const string CadastroGuid = "1b153ad2-ebe6-4cb4-a445-8f0fd35f16aa";
#region AdministrativeMethods_CargosEscClass
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE cecCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "CargosEscClass";
    public const string CamposSqlX = " CargosEscClass.* ";
    public const string SensivelCamposSqlX = " CargosEscClass.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "cecCodigo";
    public const string CampoNome = "cecNome";
    public const string PTabelaPrefixo = "cec";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}