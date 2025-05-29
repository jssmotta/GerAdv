// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBUF
{
    public const string CadastroGuid = "4b00329b-dd70-4159-ba8b-b05c5c0bb9ac";
#region AdministrativeMethods_UF
    public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE ufCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "UF";
    public const string CamposSqlX = " UF.* ";
    public const string SensivelCamposSqlX = " UF.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "ufCodigo";
    public const string CampoNome = "ufID";
    public const string PTabelaPrefixo = "uf";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}