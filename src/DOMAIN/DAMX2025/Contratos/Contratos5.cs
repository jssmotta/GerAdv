// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBContratos
{
    public const string CadastroGuid = "04a6c728-d660-48dc-be2c-449e4c553b02";
#region AdministrativeMethods_Contratos
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE cttCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "Contratos";
    public const string CamposSqlX = " Contratos.* ";
    public const string SensivelCamposSqlX = " Contratos.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "cttCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "ctt";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}