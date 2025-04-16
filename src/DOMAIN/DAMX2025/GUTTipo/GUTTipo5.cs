// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBGUTTipo
{
    public const string CadastroGuid = "fa72de59-f337-432a-aa1f-78d37cb01f9f";
#region AdministrativeMethods_GUTTipo
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE gttCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "GUTTipo";
    public const string CamposSqlX = " GUTTipo.* ";
    public const string SensivelCamposSqlX = " GUTTipo.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "gttCodigo";
    public const string CampoNome = "gttNome";
    public const string PTabelaPrefixo = "gtt";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}