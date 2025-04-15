// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBParteClienteOutras
{
    public const string CadastroGuid = "644f1875-f250-412b-87f8-963e6f3ca497";
#region AdministrativeMethods_ParteClienteOutras
    public bool DeletarItem(int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => DeletarItem(DevourerOne.InteropOperId32(), nId, oCnn, oTrans);
    public bool DeletarItem(in int nOper, in int nId, SqlConnection? oCnn, SqlTransaction? oTrans) => nId > 0 && ConfiguracoesDBT.ExecuteSql($"{ConfiguracoesDBT.DeleteCommand(oCnn, true)} FROM dbo.{PTabelaNome} WHERE pcoCodigo={nId};", oCnn, oTrans);
#endregion
    public const string PTabelaNome = "ParteClienteOutras";
    public const string CamposSqlX = " ParteClienteOutras.* ";
    public const string SensivelCamposSqlX = " ParteClienteOutras.* ";
    public static string CamposSqlAlias => CamposSqlX;

    public const string CampoCodigo = "pcoCodigo";
    public const string CampoNome = "";
    public const string PTabelaPrefixo = "pco";
#pragma warning disable CA1822 // Mark members as static

    public string Prefixo => PTabelaPrefixo;
#pragma warning restore CA1822 // Mark members as static

}