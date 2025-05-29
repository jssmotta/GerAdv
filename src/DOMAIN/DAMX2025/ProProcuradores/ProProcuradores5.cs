// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBProProcuradores
{
    public const string CadastroGuid = "d7fd51f7-07d3-43eb-b430-885af97148a1";
#region AdministrativeMethods_ProProcuradores
    public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE papCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "ProProcuradores";
    public const string CamposSqlX = " ProProcuradores.* ";
    public const string SensivelCamposSqlX = " ProProcuradores.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "papCodigo";
    public const string CampoNome = "papNome";
    public const string PTabelaPrefixo = "pap";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}