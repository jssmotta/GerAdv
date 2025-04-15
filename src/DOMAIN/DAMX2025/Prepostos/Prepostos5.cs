// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBPrepostos
{
    public const string CadastroGuid = "0f515911-252a-4cbf-bc7c-14488179be6f";
#region AdministrativeMethods_Prepostos
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE preCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "Prepostos";
    public const string CamposSqlX = " Prepostos.* ";
    public const string SensivelCamposSqlX = " Prepostos.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "preCodigo";
    public const string CampoNome = "preNome";
    public const string PTabelaPrefixo = "pre";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}