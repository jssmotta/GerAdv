// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBAndComp
{
    public const string CadastroGuid = "4cc49faf-a28c-459e-bfd3-5cee03e08823";
#region AdministrativeMethods_AndComp
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE acpCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "AndComp";
    public const string CamposSqlX = " AndComp.* ";
    public const string SensivelCamposSqlX = " AndComp.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "acpCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "acp";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}