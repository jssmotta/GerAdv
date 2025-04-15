// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBPaises
{
    public const string CadastroGuid = "89c91314-ee22-4255-9853-b50afcf4b408";
#region AdministrativeMethods_Paises
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE paiCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "Paises";
    public const string CamposSqlX = " Paises.* ";
    public const string SensivelCamposSqlX = " Paises.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "paiCodigo";
    public const string CampoNome = "paiNome";
    public const string PTabelaPrefixo = "pai";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}