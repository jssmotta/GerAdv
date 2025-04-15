// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBBensMateriais
{
    public const string CadastroGuid = "f1264025-ca8c-47a3-985a-37ab5a45d9e9";
#region AdministrativeMethods_BensMateriais
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE bmtCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "BensMateriais";
    public const string CamposSqlX = " BensMateriais.* ";
    public const string SensivelCamposSqlX = " BensMateriais.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "bmtCodigo";
    public const string CampoNome = "bmtNome";
    public const string PTabelaPrefixo = "bmt";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}