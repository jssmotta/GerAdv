// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBAgendaStatus
{
    public const string CadastroGuid = "45d77390-357a-43fb-bb47-89da91865f26";
#region AdministrativeMethods_AgendaStatus
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE astCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "AgendaStatus";
    public const string CamposSqlX = " AgendaStatus.* ";
    public const string SensivelCamposSqlX = " AgendaStatus.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "astCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "ast";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}