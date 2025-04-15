// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBAcao
{
    public const string CadastroGuid = "3a165993-5970-4024-9021-d1448e1ff0c6";
#region AdministrativeMethods_Acao
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE acaCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "Acao";
    public const string CamposSqlX = " Acao.* ";
    public const string SensivelCamposSqlX = " Acao.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "acaCodigo";
    public const string CampoNome = "acaDescricao";
    public const string PTabelaPrefixo = "aca";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}