// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBOperadorGruposAgendaOperadores
{
    public const string CadastroGuid = "1154a710-abc0-4f43-a82b-b2074f9e1eed";
#region AdministrativeMethods_OperadorGruposAgendaOperadores
    public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE ogpCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "OperadorGruposAgendaOperadores";
    public const string CamposSqlX = " OperadorGruposAgendaOperadores.* ";
    public const string SensivelCamposSqlX = " OperadorGruposAgendaOperadores.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "ogpCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "ogp";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}