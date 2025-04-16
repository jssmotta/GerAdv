// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBRito
{
    public const string CadastroGuid = "5cb2413e-45ba-4efc-9762-d565a1e3f948";
#region AdministrativeMethods_Rito
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE ritCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "Rito";
    public const string CamposSqlX = " Rito.* ";
    public const string SensivelCamposSqlX = " Rito.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "ritCodigo";
    public const string CampoNome = "ritDescricao";
    public const string PTabelaPrefixo = "rit";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}