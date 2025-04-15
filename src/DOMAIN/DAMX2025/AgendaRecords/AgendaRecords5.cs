// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBAgendaRecords
{
    public const string CadastroGuid = "47efdaf0-6a7c-4f63-ab30-fb16b4a65193";
#region AdministrativeMethods_AgendaRecords
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE ragCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "AgendaRecords";
    public const string CamposSqlX = " AgendaRecords.* ";
    public const string SensivelCamposSqlX = " AgendaRecords.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "ragCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "rag";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}