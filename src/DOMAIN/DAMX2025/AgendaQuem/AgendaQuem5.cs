// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBAgendaQuem
{
    public const string CadastroGuid = "262da2df-2dbd-4c8b-84e1-96ac2bf41d5e";
#region AdministrativeMethods_AgendaQuem
    public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE agqCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "AgendaQuem";
    public const string CamposSqlX = " AgendaQuem.* ";
    public const string SensivelCamposSqlX = " AgendaQuem.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "agqCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "agq";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}