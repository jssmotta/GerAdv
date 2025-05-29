// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBGruposEmpresasCli
{
    public const string CadastroGuid = "561908bf-d1a1-4603-8f83-1063ca73003b";
#region AdministrativeMethods_GruposEmpresasCli
    public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE gecCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "GruposEmpresasCli";
    public const string CamposSqlX = " GruposEmpresasCli.* ";
    public const string SensivelCamposSqlX = " GruposEmpresasCli.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "gecCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "gec";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}