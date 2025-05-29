// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBTipoRecurso
{
    public const string CadastroGuid = "21dc6657-9979-42b9-b6ec-aada56fedf40";
#region AdministrativeMethods_TipoRecurso
    public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE trcCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "TipoRecurso";
    public const string CamposSqlX = " TipoRecurso.* ";
    public const string SensivelCamposSqlX = " TipoRecurso.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "trcCodigo";
    public const string CampoNome = "trcDescricao";
    public const string PTabelaPrefixo = "trc";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}