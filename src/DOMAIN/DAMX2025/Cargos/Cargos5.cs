// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBCargos
{
    public const string CadastroGuid = "e6bd2a5c-c6be-4e31-be05-6ab687ba544a";
#region AdministrativeMethods_Cargos
    public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE carCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "Cargos";
    public const string CamposSqlX = " Cargos.* ";
    public const string SensivelCamposSqlX = " Cargos.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "carCodigo";
    public const string CampoNome = "carNome";
    public const string PTabelaPrefixo = "car";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}