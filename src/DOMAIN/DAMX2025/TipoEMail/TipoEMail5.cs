// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBTipoEMail
{
    public const string CadastroGuid = "40956813-2d7f-43b2-9ed6-e8a8925ae02b";
#region AdministrativeMethods_TipoEMail
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE tmlCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "TipoEMail";
    public const string CamposSqlX = " TipoEMail.* ";
    public const string SensivelCamposSqlX = " TipoEMail.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "tmlCodigo";
    public const string CampoNome = "tmlNome";
    public const string PTabelaPrefixo = "tml";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}