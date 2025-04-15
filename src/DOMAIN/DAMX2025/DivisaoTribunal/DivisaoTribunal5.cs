// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBDivisaoTribunal
{
    public const string CadastroGuid = "c9d50cb2-6e39-4ff2-8162-9b198fd457d6";
#region AdministrativeMethods_DivisaoTribunal
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE divCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "DivisaoTribunal";
    public const string CamposSqlX = " DivisaoTribunal.* ";
    public const string SensivelCamposSqlX = " DivisaoTribunal.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "divCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "div";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}