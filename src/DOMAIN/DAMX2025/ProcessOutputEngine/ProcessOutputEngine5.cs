// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBProcessOutputEngine
{
    public const string CadastroGuid = "d7887e3b-ba63-4e00-a81a-c226042d47e0";
#region AdministrativeMethods_ProcessOutputEngine
    public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE poeCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "ProcessOutputEngine";
    public const string CamposSqlX = " ProcessOutputEngine.* ";
    public const string SensivelCamposSqlX = " ProcessOutputEngine.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "poeCodigo";
    public const string CampoNome = "poeNome";
    public const string PTabelaPrefixo = "poe";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}