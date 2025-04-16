// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBFornecedores
{
    public const string CadastroGuid = "47eceb0c-f965-41a1-99b6-18697663ee6b";
#region AdministrativeMethods_Fornecedores
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE forCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "Fornecedores";
    public const string CamposSqlX = " Fornecedores.* ";
    public const string SensivelCamposSqlX = " Fornecedores.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "forCodigo";
    public const string CampoNome = "forNome";
    public const string PTabelaPrefixo = "for";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}