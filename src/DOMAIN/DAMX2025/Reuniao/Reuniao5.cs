// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBReuniao
{
    public const string CadastroGuid = "882c2384-1317-4666-9029-731704a802cd";
#region AdministrativeMethods_Reuniao
    public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE renCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "Reuniao";
    public const string CamposSqlX = " Reuniao.* ";
    public const string SensivelCamposSqlX = " Reuniao.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "renCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "ren";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}