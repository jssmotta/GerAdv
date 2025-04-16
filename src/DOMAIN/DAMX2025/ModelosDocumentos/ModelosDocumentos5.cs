// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBModelosDocumentos
{
    public const string CadastroGuid = "49435fc5-d5ce-4e3d-9de8-8577caf071bf";
#region AdministrativeMethods_ModelosDocumentos
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE mdcCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "ModelosDocumentos";
    public const string CamposSqlX = " ModelosDocumentos.* ";
    public const string SensivelCamposSqlX = " ModelosDocumentos.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "mdcCodigo";
    public const string CampoNome = "mdcNome";
    public const string PTabelaPrefixo = "mdc";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}