// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBAgendaFinanceiro
{
    public const string CadastroGuid = "f36e53d4-a9bc-43a2-a7fe-97265ca3f939";
#region AdministrativeMethods_AgendaFinanceiro
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE ageCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "AgendaFinanceiro";
    public const string CamposSqlX = " AgendaFinanceiro.* ";
    public const string SensivelCamposSqlX = " AgendaFinanceiro.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "ageCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "age";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}