// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBGraph
{
    public const string CadastroGuid = "1e1eed82-357f-4ff1-b7c0-d0b582579ebf";
#region AdministrativeMethods_Graph
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE gphCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "Graph";
    public const string CamposSqlX = " Graph.* ";
    public const string SensivelCamposSqlX = " Graph.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "gphCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "gph";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}