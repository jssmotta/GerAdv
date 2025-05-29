// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBServicos
{
    public const string CadastroGuid = "8a96d599-2fd8-47de-b78a-cee808d4523b";
#region AdministrativeMethods_Servicos
    public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE serCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "Servicos";
    public const string CamposSqlX = " Servicos.* ";
    public const string SensivelCamposSqlX = " Servicos.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "serCodigo";
    public const string CampoNome = "serDescricao";
    public const string PTabelaPrefixo = "ser";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}