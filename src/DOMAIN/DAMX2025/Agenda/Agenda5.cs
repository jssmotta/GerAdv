// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBAgenda
{
    public const string CadastroGuid = "c5860ced-cc58-4f59-acf7-a3b8e04a2d8c";
#region AdministrativeMethods_Agenda
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE ageCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "Agenda";
    public const string CamposSqlX = " Agenda.* ";
    public const string SensivelCamposSqlX = " Agenda.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "ageCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "age";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}