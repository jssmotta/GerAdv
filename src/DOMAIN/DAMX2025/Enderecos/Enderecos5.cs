// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBEnderecos
{
    public const string CadastroGuid = "9c60b5bb-0070-4bab-8747-41c3d7447889";
#region AdministrativeMethods_Enderecos
    public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE endCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "Enderecos";
    public const string CamposSqlX = " Enderecos.* ";
    public const string SensivelCamposSqlX = " Enderecos.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "endCodigo";
    public const string CampoNome = "endDescricao";
    public const string PTabelaPrefixo = "end";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}