// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBHorasTrab
{
    public const string CadastroGuid = "20846f98-4d22-4627-9166-88ea7fabc557";
#region AdministrativeMethods_HorasTrab
    public bool DeletarItem(int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, MsiSqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteDelete($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM {PTabelaNome.dbo(oCnn)} WHERE htbCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "HorasTrab";
    public const string CamposSqlX = " HorasTrab.* ";
    public const string SensivelCamposSqlX = " HorasTrab.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "htbCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "htb";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}