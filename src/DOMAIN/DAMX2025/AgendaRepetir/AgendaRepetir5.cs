// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBAgendaRepetir
{
    public const string CadastroGuid = "4c61b44e-a1f8-45a7-8323-88a117cea213";
#region AdministrativeMethods_AgendaRepetir
    public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE rptCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "AgendaRepetir";
    public const string CamposSqlX = " AgendaRepetir.* ";
    public const string SensivelCamposSqlX = " AgendaRepetir.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "rptCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "rpt";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}