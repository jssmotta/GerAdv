// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBStatusBiu
{
    public const string CadastroGuid = "4cd70e36-ade6-4065-9c10-425bdd3c8f31";
#region AdministrativeMethods_StatusBiu
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE stbCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "StatusBiu";
    public const string CamposSqlX = " StatusBiu.* ";
    public const string SensivelCamposSqlX = " StatusBiu.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "stbCodigo";
    public const string CampoNome = "stbNome";
    public const string PTabelaPrefixo = "stb";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}