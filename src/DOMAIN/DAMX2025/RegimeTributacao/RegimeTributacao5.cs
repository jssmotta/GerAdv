// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBRegimeTributacao
{
    public const string CadastroGuid = "7eb45a1b-3d96-413a-a86b-b6912eeba758";
#region AdministrativeMethods_RegimeTributacao
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE rdtCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "RegimeTributacao";
    public const string CamposSqlX = " RegimeTributacao.* ";
    public const string SensivelCamposSqlX = " RegimeTributacao.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "rdtCodigo";
    public const string CampoNome = "rdtNome";
    public const string PTabelaPrefixo = "rdt";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}