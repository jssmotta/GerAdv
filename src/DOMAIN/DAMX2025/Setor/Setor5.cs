// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBSetor
{
    public const string CadastroGuid = "c42e0daa-d80e-40a5-a53f-4f096a4ba4a0";
#region AdministrativeMethods_Setor
    public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE setCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "Setor";
    public const string CamposSqlX = " Setor.* ";
    public const string SensivelCamposSqlX = " Setor.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "setCodigo";
    public const string CampoNome = "setDescricao";
    public const string PTabelaPrefixo = "set";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}