// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBContatoCRMOperador
{
    public const string CadastroGuid = "d7a1514f-38a6-4078-ae06-e30c62877f08";
#region AdministrativeMethods_ContatoCRMOperador
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE ccoCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "ContatoCRMOperador";
    public const string CamposSqlX = " ContatoCRMOperador.* ";
    public const string SensivelCamposSqlX = " ContatoCRMOperador.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "ccoCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "cco";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}