// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBFuncionarios
{
    public const string CadastroGuid = "c9beefae-66db-4909-ac8f-c7b5480d7c06";
#region AdministrativeMethods_Funcionarios
    public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE funCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "Funcionarios";
    public const string CamposSqlX = " Funcionarios.* ";
    public const string SensivelCamposSqlX = " Funcionarios.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "funCodigo";
    public const string CampoNome = "funNome";
    public const string PTabelaPrefixo = "fun";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}