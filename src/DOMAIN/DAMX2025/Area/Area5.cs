// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBArea
{
    public const string CadastroGuid = "657d74ee-73e8-4511-96f9-2db5e4b9c912";
#region AdministrativeMethods_Area
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE areCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "Area";
    public const string CamposSqlX = " Area.* ";
    public const string SensivelCamposSqlX = " Area.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "areCodigo";
    public const string CampoNome = "areDescricao";
    public const string PTabelaPrefixo = "are";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}