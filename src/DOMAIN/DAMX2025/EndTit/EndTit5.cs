// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBEndTit
{
    public const string CadastroGuid = "f94727d6-e2fe-4175-88c8-938ead99d373";
#region AdministrativeMethods_EndTit
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE ettCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "EndTit";
    public const string CamposSqlX = " EndTit.* ";
    public const string SensivelCamposSqlX = " EndTit.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "ettCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "ett";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}