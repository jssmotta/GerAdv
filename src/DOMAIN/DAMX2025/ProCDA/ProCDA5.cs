// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBProCDA
{
    public const string CadastroGuid = "a15e2368-b4ce-4fb9-8009-fd4f0b5ccbb6";
#region AdministrativeMethods_ProCDA
    public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE pcdCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "ProCDA";
    public const string CamposSqlX = " ProCDA.* ";
    public const string SensivelCamposSqlX = " ProCDA.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "pcdCodigo";
    public const string CampoNome = "pcdNome";
    public const string PTabelaPrefixo = "pcd";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}