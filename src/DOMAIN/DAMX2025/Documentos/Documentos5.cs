// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBDocumentos
{
    public const string CadastroGuid = "9fcd5a8f-f156-432a-8e58-ef7a6f21f3ab";
#region AdministrativeMethods_Documentos
    public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE docCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "Documentos";
    public const string CamposSqlX = " Documentos.* ";
    public const string SensivelCamposSqlX = " Documentos.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "docCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "doc";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}