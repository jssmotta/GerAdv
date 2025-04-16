// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBFuncao
{
    public const string CadastroGuid = "a93afbd5-693c-495c-b65a-1178d76ae379";
#region AdministrativeMethods_Funcao
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE funCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "Funcao";
    public const string CamposSqlX = " Funcao.* ";
    public const string SensivelCamposSqlX = " Funcao.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "funCodigo";
    public const string CampoNome = "funDescricao";
    public const string PTabelaPrefixo = "fun";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}