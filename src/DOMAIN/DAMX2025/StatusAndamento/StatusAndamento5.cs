// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBStatusAndamento
{
    public const string CadastroGuid = "641ef4f1-b717-4b73-910b-e770c6b919b9";
#region AdministrativeMethods_StatusAndamento
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE sanCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "StatusAndamento";
    public const string CamposSqlX = " StatusAndamento.* ";
    public const string SensivelCamposSqlX = " StatusAndamento.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "sanCodigo";
    public const string CampoNome = "sanNome";
    public const string PTabelaPrefixo = "san";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}