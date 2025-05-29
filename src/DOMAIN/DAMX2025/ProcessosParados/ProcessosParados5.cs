// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBProcessosParados
{
    public const string CadastroGuid = "5aaf9af3-9b51-4041-868f-7d3623c6a1ba";
#region AdministrativeMethods_ProcessosParados
    public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE pprCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "ProcessosParados";
    public const string CamposSqlX = " ProcessosParados.* ";
    public const string SensivelCamposSqlX = " ProcessosParados.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "pprCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "ppr";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}