// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBGUTPeriodicidade
{
    public const string CadastroGuid = "b40fa6e5-8047-4e0b-8b6f-9a3403700f38";
#region AdministrativeMethods_GUTPeriodicidade
    public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE pcgCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "GUTPeriodicidade";
    public const string CamposSqlX = " GUTPeriodicidade.* ";
    public const string SensivelCamposSqlX = " GUTPeriodicidade.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "pcgCodigo";
    public const string CampoNome = "pcgNome";
    public const string PTabelaPrefixo = "pcg";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}