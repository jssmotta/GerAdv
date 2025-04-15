// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBApenso
{
    public const string CadastroGuid = "c72a5efd-61b0-4ff9-bafc-8a899c6b5a0b";
#region AdministrativeMethods_Apenso
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE apeCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "Apenso";
    public const string CamposSqlX = " Apenso.* ";
    public const string SensivelCamposSqlX = " Apenso.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "apeCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "ape";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}